using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWebApplication.Catalog.Products;
using ShopWebModels.Catalog.Products;
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

        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            var data = await _manager.GetAll();
            return Ok(data);
        }

        // http://locolhost:port/controller
        [HttpGet("PublicGet")]
        public async Task<IActionResult> Get()
        {
            var data = await _public.GetAll();
            return Ok(data);
        }

        // http://locolhost:port/controller/GetPublic_ProductByID
        [HttpGet("GetPublic_ProductByID")] // dat ten trong method de phan biet 2 PT GET
        public async Task<IActionResult> Get([FromQuery]GetPublicProductPagingRequest request)
        {
            var data = await _public.GetAllByCategoryById(request);
            return Ok(data);
        }
        // http://locolhost:port/controller/1
        [HttpGet("GetById/{productId}/{langugeId}")]
        public async Task<IActionResult> GetManager_ProductByID([FromForm]int productId,int langugeId)
        {
            var data = await _manager.GetById(productId, langugeId);
            if (data == null) return BadRequest("ID not exits");

            return Created(nameof(GetManager_ProductByID), data.Id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm]ProductCreateRequest request)
        {
            var productID = await _manager.Create(request);
            if (productID == 0)
                return BadRequest();

            var product = await _manager.GetById(productID,request.langId);
            //   return Created(nameof(GetManager_ProductByID), product); 
            return CreatedAtAction(nameof(GetManager_ProductByID), product, new { id = productID });
            // tra ve 1 action, 1 object va 1 id
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductEditRequest request)
        {
            var affective = await _manager.Update(request);
            if (affective == 0)
                return BadRequest();

            return Ok();
        }
        [HttpPut("UpdatePrice/{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice([FromForm]int productId, decimal newPrice) // cho nay la decimal
        {
            var isSuccess = await _manager.UpdatePrice(productId, newPrice);
            if (!isSuccess)
                return BadRequest();

            return Ok();
        }

        [HttpPut("UpdateStock/{productId}/{newStock}")]
        public async Task<IActionResult> UpdateStock([FromForm] int productId, int newStock)
        {
            var isSuccess = await _manager.UpdateStock(productId, newStock);
            if (!isSuccess)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("Delete/{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var isSuccess = await _manager.Delete(productId);
            if (isSuccess == 0)
                return BadRequest();

            return RedirectToAction(nameof(Get));
        }
    }
}
