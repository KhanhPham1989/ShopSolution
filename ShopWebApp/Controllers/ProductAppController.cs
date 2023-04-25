using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Controllers
{
    public class ProductAppController : Controller
    {
        public IActionResult Detail(int proId)
        {
            return View();
        }

        public IActionResult Categories(int cateId)
        {
            return View();
        }
    }
}