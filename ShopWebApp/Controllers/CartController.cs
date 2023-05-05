using LibraryAPIApp.Service.Payment;
using LibraryAPIApp.Service.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopWebException.Common;
using ShopWebModels.WebApp.Cart;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductClientInterface _product;
        private readonly IHttpContextAccessor _context;
        private readonly IWebHostEnvironment _web;
        private readonly IPayment _pay;

        private const string Product_Content_Folder_Name = "/themes/images/products/No.jpg";

        [TempData]
        public string thongbao { get; set; }

        public CartController(IProductClientInterface product, IHttpContextAccessor context,
            IWebHostEnvironment web, IPayment pay)
        {
            _product = product;
            _context = context;
            _web = web;
            _pay = pay;
        }

        private string ImagePaths()
        {
            var path = Path.Combine(_web.WebRootPath, Product_Content_Folder_Name);
            return path;
        }

        public IActionResult Index()
        {
            var currentCart = this.GetCartItem();
            if (!string.IsNullOrEmpty(thongbao))
                ViewBag.mess = thongbao;
            return View(currentCart);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCart(int productId, int quantity)
        {
            var currenCart = this.GetCartItem();
            if (quantity <= 0)
            {
                var productInCart = currenCart.Where(x => x.ProductId == productId).SingleOrDefault();
                currenCart.Remove(productInCart);
                this.SaveCart(currenCart);
                thongbao = $"san pham {productInCart.ProductName} nho hon 0 nen xoa khoi gio hang";
                return Ok();
            }

            var productstock = await _product.GetById(productId, 1);

            if (quantity > productstock.ObjResult.Stock)
            {
                thongbao = $"hang ton kho it hon so luong dat, vui long dat khong nhieu " +
                    $"hon {productstock.ObjResult.Stock} san pham";
                quantity = productstock.ObjResult.Stock;
                return Ok();
            }

            foreach (var item in currenCart)
            {
                if (item.ProductId == productId)
                {
                    item.Quantity = quantity;
                    SaveCart(currenCart);
                    thongbao = $"san pham {item.ProductName} cap nhat thanh cong";
                }
            }
            return Ok();
        }

        private void SaveCart(List<CartItemRequest> cartlist)
        {
            var cartSave = JsonConvert.SerializeObject(cartlist);
            HttpContext.Session.SetString(CartsOrder.Cart, cartSave);
        }

        private void RemoveItemCart()
        {
            HttpContext.Session.Remove(CartsOrder.Cart);
        }

        [HttpGet]
        public List<CartItemRequest> GetCartItem()
        {
            var currentCart = new List<CartItemRequest>();
            var sesion = HttpContext.Session.GetString(CartsOrder.Cart);
            if (sesion != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemRequest>>(sesion);
            return currentCart;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int Id)
        {
            var currentCart = new List<CartItemRequest>();
            var sesion = HttpContext.Session.GetString(CartsOrder.Cart);

            if (sesion != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemRequest>>(sesion);

            var product = await _product.GetById(Id, 1);
            int quantity = 1;
            if (currentCart.Any(x => x.ProductId == Id))
            {
                currentCart.First(x => x.ProductId == Id).Quantity += quantity;
            }
            else
            {
                currentCart.Add(new CartItemRequest()
                {
                    CateId = product.ObjResult.CategoriId,
                    ProductId = Id,
                    Description = product.ObjResult.Description,
                    Quantity = quantity,
                    ImagePath = product.ObjResult.ThumnailFile == null ? this.ImagePaths() : product.ObjResult.ThumnailFile,
                    ProductName = product.ObjResult.ProductName,
                    Price = product.ObjResult.Price
                });
            }
            _context.HttpContext.Session.SetString(CartsOrder.Cart, JsonConvert.SerializeObject(currentCart));

            return Ok(currentCart);
        }

        [HttpGet]
        public IActionResult PaymentRequest()
        {
            var currentCart = new List<CartItemRequest>();
            var sessionCart = HttpContext.Session.GetString(CartsOrder.Cart);
            if (sessionCart == null)
            {
                thongbao = "Khong co san pham nao de thanh toan";
                return View("Index");
            }

            currentCart = JsonConvert.DeserializeObject<List<CartItemRequest>>(sessionCart);
            var payment = new PaymentRequest()
            {
                cartItem = currentCart
            };

            return View(payment);
        }

        [HttpPost]
        public async Task<IActionResult> PaymentRequest(PaymentRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);
            var currentCart = this.GetCartItem();

            request.cartItem = currentCart;
            var result = await _pay.PaymentRequest(request);
            if (result > 0)
            {
                this.RemoveItemCart();
                thongbao = $"ban da dat hang thanh cong don hang {result} ";
                return RedirectToAction("Index");
            }

            return View(request);
        }
    }
}