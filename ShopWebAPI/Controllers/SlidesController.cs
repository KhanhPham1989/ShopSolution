using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopWebApplication.Catalog.RoleCata;
using ShopWebApplication.Catalog.Slide;
using ShopWebData.Entities;
using ShopWebModels.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidesController : ControllerBase
    {
        private readonly ISlideService _SlideService;

        public SlidesController(ISlideService SlideService)
        {
            _SlideService = SlideService;
        }

        [HttpGet("GetAllSlide")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllSlide()
        {
            var Slides = await _SlideService.GetAll();
            if (Slides != null)
                return Ok(Slides);

            var content = new ContentResult()
            {
                Content = "Vui long tao moi Slide",
                // StatusCode = HttpContext.Response.StatusCode,
            };
            return Content("Vui long tao moi Slide");
        }

        [HttpGet("GetFeartureProduct/{Pagesize}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFeartureProduct(int Pagesize)
        {
            var Products = await _SlideService.GetFeartureProduct(Pagesize);
            if (Products != null)
                return Ok(Products);

            var content = new ContentResult()
            {
                Content = "Vui long tao moi Slide",
                // StatusCode = HttpContext.Response.StatusCode,
            };
            return Content("Vui long tao moi Slide");
        }

        [HttpGet("GetLatestProduct/{Pagesize}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLatestProduct(int Pagesize)
        {
            var Products = await _SlideService.GetLatestProduct(Pagesize);
            if (Products != null)
                return Ok(Products);

            var content = new ContentResult()
            {
                Content = "Vui long tao moi Slide",
                // StatusCode = HttpContext.Response.StatusCode,
            };
            return Content("Vui long tao moi Slide");
        }
    }
}