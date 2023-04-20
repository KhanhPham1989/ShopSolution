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

            var result = await _userService.Authencated(request);
            if (string.IsNullOrEmpty(result))
                return BadRequest("UserName or Password is incorrect");

            //HttpContext.Session.SetString("Token", result); // luu vao session
            return Ok(result);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest register)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var account = await _userService.RegisterUser(register);
            if (!account.Success)
                return BadRequest(account.Message);

            return Ok(account);
        }

        [HttpPatch("ChangePassWord/{userLogin}")]
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

        //PUT : http://locolhost/api/Users/EditInfoUser/id
        [HttpPut("{id}")]
        public async Task<IActionResult> EditInforUser(Guid id, [FromBody] EditRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.EditUser(request.id, request);
            if (!result.Success)
            {
                if (result.Message == null)
                {
                    return BadRequest("Server khong ket noi duoc");
                }
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        //http://localhost/api/Users/GetUserPaging?pageIndex=1&pageSize=10&keyword=
        [HttpGet("GetUserPaging")]
        public async Task<IActionResult> GetUserPaging([FromQuery] GetUserPagingRequest request)
        {
            var UserList = await _userService.GetUserPaging(request);
            if (UserList.TotalRecords > 0)
            {
                return Ok(UserList);
            }
            return BadRequest("khong ton tai acc nao");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var UserList = await _userService.GetById(id);
            if (UserList.Success)
            {
                return Ok(UserList);
            }
            return BadRequest(UserList.Message);
        }

        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _userService.DeleteUser(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest("Check user");
        }

        [HttpPut("{id}/RoleAsign")]
        public async Task<IActionResult> RoleAsign(Guid id, [FromBody] RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RoleAssign(id, request);
            if (!result.Success)
            {
                if (result.Message == null)
                {
                    return BadRequest("Server khong ket noi duoc");
                }
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}