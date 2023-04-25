using LibraryAPIApp.Service.SlideClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopWebApp.Models;
using ShopWebException.Common;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Controllers
{
    //[Area("Shop/Controller")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISlideClient _slide;

        public HomeController(ILogger<HomeController> logger, ISlideClient slide)
        {
            _logger = logger;
            _slide = slide;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _slide.GetAll();
            var product = await _slide.GetFeartureProduct(ProductSettings.NumberOfProductFearture);
            var latest = await _slide.GetLatestProduct(ProductSettings.NumberOfProductLatest);
            if (data != null && product != null)
            {
                var resurl = new HomeViewModel()
                {
                    slides = data,
                    FeartureProduct = product,
                    LatestProduct = latest
                };
                return View(resurl);
            }

            return BadRequest();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}