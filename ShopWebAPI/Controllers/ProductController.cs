using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWebApplication.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IManageProductService _manager;
        private readonly IPublicProductService _public;

        public ProductController(IManageProductService manager, IPublicProductService _ipublic)
        {
            _manager = manager;
            _public = _ipublic;
        }

        //[HttpGet("GetAll")]
        //public async Task<IActionResult> GetAllProduct()
        //{
        //    var data = await _public.GetList();
        //    return Ok(data);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _public.GetAll();
            return Ok(data);
        }
    }
}
