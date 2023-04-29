using LibraryAPIApp.Service.Categories;
using LibraryAPIApp.Service.Product;
using Microsoft.AspNetCore.Mvc;
using ShopWebModels.Catalog.Products;
using ShopWebModels.WebApp;
using ShopWebModels.WebApp.CategoriProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Controllers
{
    public class ProductAppController : Controller
    {
        private readonly IProductClientInterface _productClient;
        private readonly ICategoriesService _cateClient;

        public ProductAppController(IProductClientInterface productClient, ICategoriesService cateClient)
        {
            _productClient = productClient;
            _cateClient = cateClient;
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int Id)
        {
            var product = await _productClient.GetById(Id, 1);
            var category = await _cateClient.GetProductByCateId(product.ObjResult.CategoriId, 1);
            return View(new ProductDetailsViewModel()
            {
                product = product.ObjResult,
                category = category
            });
        }

        [HttpGet]
        public async Task<IActionResult> Categories(int Id, int langId = 1, int pageIndex = 1)
        {
            var result = await _productClient.GetAllPaging(new GetManageProductPagingRequest
            {
                langugeId = langId,
                PageIndex = pageIndex,
                PageSize = 4,
                Key = "a",
                Categori = Id
            });

            return View(new CateProductViewModel()
            {
                Category = await _cateClient.GetProductByCateId(Id, langId),
                proList = result.ObjResult,
                PageIndex = result.ObjResult.PageIndex,
                PageSize = 4,
                TotalRecords = result.ObjResult.TotalRecords,
            });
        }
    }
}