using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopWebApplication.Catalog.RoleCata;
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
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _roleService;

        public RolesController(IRolesService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetAllRole")]
        public async Task<IActionResult> GetAllRole()
        {
            var roles = await _roleService.GetAllRole();
            if (roles != null)
                return Ok(roles);

            var content = new ContentResult()
            {
                Content = "Vui long tao moi Role",
                // StatusCode = HttpContext.Response.StatusCode,
            };
            return Content("Vui long tao moi Role");
        }
    }
}