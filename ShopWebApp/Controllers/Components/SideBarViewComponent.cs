using LibraryAPIApp.Service.Categories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Controllers.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly ICategoriesService _cate;

        public SideBarViewComponent(ICategoriesService cate)
        {
            _cate = cate;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _cate.GetAllCategory();
            return View(result);
        }
    }
}