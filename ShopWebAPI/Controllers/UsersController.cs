using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWebApplication.Catalog.User;
using ShopWebModels.Catalog.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) => _userService = userService;

        [HttpPost("LoginAuthenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAuthenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                // ModelState.ToList().ForEach(error => throw new Exception(error.ToString()));
                return BadRequest(ModelState);

            var userLogin = await _userService.Authencated(request);
            if (string.IsNullOrEmpty(userLogin))
                return BadRequest(userLogin);

            return Ok(new { token = userLogin });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] RegisterRequest register)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var account = await _userService.RegisterUser(register);
            if (!account)
                return BadRequest(account.ToString());

            return Ok(register.FullName);
        }

        [HttpPatch("{userLogin}")]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassWord(string userLogin, [FromForm] ChangePassWord request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reset = await _userService.ChangPassWord(userLogin, request);
            if (!reset)
                return BadRequest(reset);

            return Ok();
        }

        [HttpPut("{userlogin}")]
        [AllowAnonymous]
        public async Task<IActionResult> EditInforUser(string userlogin, [FromForm] EditRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reset = await _userService.EditUser(userlogin, request);
            if (reset == null)
                return BadRequest(reset);

            return Ok(reset);
        }
    }
}