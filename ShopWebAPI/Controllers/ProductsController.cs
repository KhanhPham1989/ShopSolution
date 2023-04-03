using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWebApplication.Catalog.Products;
using ShopWebModels.Catalog.Images;
using ShopWebModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IManageProductService _manager;
        private readonly IPublicProductService _public;

        public ProductsController(IManageProductService manager, IPublicProductService _ipublic)
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
        //[HttpGet("GetPublic_ProductByID")] // dat ten trong method de phan biet 2 PT GET

        [HttpGet("{langugeId}")] // http://locolhost:port/Products?PageIndex =1&pageSize=5&CategoryId = ?
        public async Task<IActionResult> GetPaging(int langugeId, [FromQuery] GetPublicProductPagingRequest request)
        {
            var data = await _public.GetAllByCategoryById(langugeId, request);
            return Ok(data);
        }

        // http://locolhost:port/controller/1
        [HttpGet("GetById/{productId}/{langugeId}")]
        public async Task<IActionResult> GetManager_ProductByID([FromForm] int productId, int langugeId)
        {
            var data = await _manager.GetById(productId, langugeId);
            if (data == null) return BadRequest("ID not exits");

            return Created(nameof(GetManager_ProductByID), data.Id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var productID = await _manager.Create(request);
            if (productID == 0)
                return BadRequest();

            var product = await _manager.GetById(productID, request.langId);
            //   return Created(nameof(GetManager_ProductByID), product);
            return CreatedAtAction(nameof(GetManager_ProductByID), product, new { id = productID });
            // tra ve 1 action, 1 object va 1 id
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductEditRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var affective = await _manager.Update(request);
            if (affective == 0)
                return BadRequest();

            return Ok();
        }

        [HttpPatch("UpdatePrice/{productId}/{newPrice}")] // ==> update 1 phan cua bang ghi
        public async Task<IActionResult> UpdatePrice([FromForm] int productId, decimal newPrice) // cho nay la decimal
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

        // IMAGE
        [HttpGet("{productId}/images/{imageId}")] // => dạng nested : cha con
        public async Task<IActionResult> GetImageByID(int productId, int imageId)
        {
            var product = await _manager.GetByIdNoLanguage(productId);
            if (product == null)
                throw new Exception($"{productId} not exits...");
            var result = await _manager.GetImageById(imageId);
            if (result != null)
                return Ok(result);
            return BadRequest($"{imageId} not exits...");
        }

        [HttpPost("{productId}/CreateImage")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ImageCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("All property must take note");
            var resurl = await _manager.AddImages(productId, request);
            if (resurl > 0)
            {
                var image = await _manager.GetImageById(resurl);
                return CreatedAtAction(nameof(GetImageByID), image, new { id = resurl });
            }
            return NotFound();
        }

        [HttpPut("{productId}/images/{ImageId}")]
        public async Task<IActionResult> UpdateImage(int productId, int ImageId, [FromForm] ImageEditRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("All property must take note");
            var resurl = await _manager.UpdateImage(productId, ImageId, request);
            if (resurl.Count > 0)
                return CreatedAtAction(nameof(GetImageByID), resurl, new { id = resurl.Values });
            return NotFound();
        }

        [HttpDelete("{productId}/images/{ImageId}")]
        public async Task<IActionResult> RemoveImages(int productId, int ImageId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var resurl = await _manager.RemoveImages(productId, ImageId);
            if (resurl != 0)
                return Ok();
            return BadRequest();
        }
    }
}