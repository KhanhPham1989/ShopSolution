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
        private readonly string _productContentFolder;
        private const string Product_Content_Folder_Name = "/themes/images/products/No.jpg";

        public CartController(IProductClientInterface product, IHttpContextAccessor context, IWebHostEnvironment web)
        {
            _product = product;
            _context = context;
            _web = web;
        }

        private string ImagePaths()
        {
            var path = Path.Combine(_web.WebRootPath, Product_Content_Folder_Name);
            return path;
        }

        public IActionResult Index()
        {
            var currentCart = new List<CartItemRequest>();
            var sesion = HttpContext.Session.GetString(CartsOrder.Cart);
            if (sesion != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemRequest>>(sesion);

            return View(currentCart);
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
    }
}