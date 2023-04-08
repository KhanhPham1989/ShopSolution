using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using ShopWeb_AdminApp.Service.User;
using ShopWebModels.Catalog.User;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopWeb_AdminApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public UserController(IUserService userService, IConfiguration Iconfiguration)
        {
            _userService = userService;
            _config = Iconfiguration;
        }

        public async Task<IActionResult> Index(string Keyword, int PageIndex = 1, int PageSize = 10)
        {
            var session = HttpContext.Session.GetString("Token");
            //TokenSession = session;
            var GetUser = new GetUserPagingRequest()
            {
                BearerToken = session,
                PageIndex = PageIndex,
                PageSize = PageSize,
                Keyword = Keyword
            };
            var data = await _userService.GetUserPaging(GetUser);
            return View(data);
        }

        public IActionResult ChangePassWord()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var TokenSession = HttpContext.Session.GetString("Token");
            if (TokenSession != null)
                HttpContext.Session.Remove(TokenSession);
            return RedirectToAction(nameof(Index), "Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var resurl = await _userService.Register(request);
            if (!resurl)
                return View();
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}