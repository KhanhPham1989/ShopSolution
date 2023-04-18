using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWeb_AdminApp.Service.Product;
using ShopWebModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb_AdminApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductClientInterface _pro;

        [TempData]
        private string thongbao { get; set; }

        public ProductController(IProductClientInterface pro)
        {
            _pro = pro;
        }

        public async Task<IActionResult> Index(string Key = "a", int PageSize = 5, int PageIndex = 1)
        {
            var session = HttpContext.Session.GetString("Token");
            var request = new GetManageProductPagingRequest
            {
                BearerToken = session,
                Key = Key,
                PageIndex = PageIndex,
                PageSize = PageSize,
            };
            var data = await _pro.GetAllPaging(request);
            if (!string.IsNullOrEmpty(thongbao))
            {
                ViewBag.message = thongbao;
            }

            if (data.ObjResult != null)
            {
                return View(data.ObjResult);
            }
            return BadRequest(data.Message);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var product = await _pro.Create(request);
                if (product.Success)
                {
                    thongbao = "Tao thanh cong san pham";
                    return RedirectToAction("Index", "Product");
                }
                ViewBag.mess = product.Message;
                return View(product.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}