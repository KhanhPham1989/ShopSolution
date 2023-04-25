using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryAPIApp.Service.Categories;
using LibraryAPIApp.Service.Product;
using ShopWebModels.Catalog.Categories;
using ShopWebModels.Catalog.Products;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb_AdminApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductClientInterface _pro;
        private readonly ICategoriesService _cate;

        [TempData]
        private string thongbao { get; set; }

        public ProductController(IProductClientInterface pro, ICategoriesService cate)
        {
            _pro = pro;
            _cate = cate;
        }

        public async Task<IActionResult> Index(int? cateId, string Key, int PageSize = 5, int PageIndex = 1)
        {
            var session = HttpContext.Session.GetString("Token");
            var request = new GetManageProductPagingRequest
            {
                BearerToken = session,
                Key = Key,
                PageIndex = PageIndex,
                PageSize = PageSize,
                Categori = cateId == null ? 1 : cateId
            };
            var data = await _pro.GetAllPaging(request);
            ViewBag.Key = Key;
            var cateList = await _cate.GetAllCategory();
            if (cateList.Count > 0)
            {
                ViewBag.categori = cateList.Select(x => new SelectListItem()
                {
                    Text = x.CateName,
                    Value = x.CateId.ToString(),
                    Selected = cateId.HasValue && cateId.Value == x.CateId
                });
            }
            if (!string.IsNullOrEmpty(thongbao))
            {
                ViewBag.message = thongbao;
            }

            if (data.Success)
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

        [HttpGet]
        public async Task<IActionResult> CategoriAssign(int Id)
        {
            try
            {
                var product = await _cate.GetCateByProductId(Id);
                var categories = await _cate.GetAllCategory();

                var categoriAssign = new CategoriAssign();
                if (product == null)
                {
                    categoriAssign.ProId = Id;
                    categoriAssign.Selected = categories;
                    return View(categoriAssign);
                }
                foreach (var item in categories)
                {
                    var check = new CategoriSelected()
                    {
                        CateId = item.CateId,
                        CateName = item.CateName,
                        cateSelected = product.Selected.Select(x => x.CateName).Contains(item.CateName)
                    };
                    categoriAssign.Selected.Add(check);
                }

                categoriAssign.ProId = Id;

                return View(categoriAssign);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CategoriAssign(int proId, [FromForm] CategoriAssign request)
        {
            var result = await _cate.AssignCategori(proId, request);
            if (result.Success)
            {
                thongbao = "Gan quyen thanh cong";
                return RedirectToAction("Index", "Product");
            }
            thongbao = "Gan quyen khong thanh cong";
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int Id)
        {
            var product = await _pro.GetById(Id, 1);
            if (product.Success)
            {
                var data = product.ObjResult;
                var result = new ProductEditRequest()
                {
                    Proid = Id,
                    LangId = 1,
                    Name = data.ProductName,
                    SeoAlias = data.SeoAlias,
                    Description = data.Description,
                    SeoTitle = data.SeoTitle,
                    Details = data.TranslationDetails,
                    ImagePath = data.ThumnailFile
                };
                return View(result);
            };

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct([FromForm] ProductEditRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var data = await _pro.Update(request);
            if (data.Success)
            {
                thongbao = "Ban cap nhat thanh cong";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cap nhat khong thanh cong");
            return View(request);
        }
    }
}