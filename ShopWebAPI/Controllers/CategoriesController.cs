using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWebApplication.Catalog.Categories;
using ShopWebModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IManageCategori _manageCategori;

        public CategoriesController(IManageCategori manageCategori)
        {
            _manageCategori = manageCategori;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var result = await _manageCategori.GetAllCategory();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{proId}")]
        public async Task<IActionResult> GetCateByProductId(int proId)
        {
            var result = await _manageCategori.GetCateByProductId(proId);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut("{proId}/CategoriAssign")]
        public async Task<IActionResult> CategoriAssign(int proId, [FromBody] CategoriAssign request)
        {
            var result = await _manageCategori.AssignCategori(proId, request);
            if (result.Success)
                return Ok(result);

            return BadRequest(result.Message);
        }
    }
}