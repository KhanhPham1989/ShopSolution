using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using LibraryAPIApp.Service.User;
using ShopWebModels.Catalog.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ShopWebException.Common;

namespace ShopWeb_AdminApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(IUserService userService, IConfiguration Iconfiguration, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _config = Iconfiguration;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // bat buoc log out nhung session cu khi vao login
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // _httpContextAccessor.HttpContext.Session.Remove("Token");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                foreach (var item in ModelState)
                {
                    return View(item.ToString());
                }
            }

            var token = await _userService.LoginAuthenticate(request);
            if (string.IsNullOrEmpty(token))
            {
                ModelState.AddModelError("", "Wrong User Name or PassWord");
                return View();
            }
            var userPrinciple = this.ValidateToken(token);
            var auth = new AuthenticationProperties()
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(5),
                IsPersistent = false,

                //nhận hoặc đặt xem phiên xác thực có được duy trì qua nhiều yêu cầu hay khong
            };

            _httpContextAccessor.HttpContext.Session.SetString("Token", token);

            await HttpContext.SignInAsync(
                                            scheme: CookieAuthenticationDefaults.AuthenticationScheme,
                                            principal: userPrinciple,
                                            properties: auth);
            // pt nhan 2 hoac 3 tham so, => string cookie, Priciple, 1 thiet lap thoi gian

            return RedirectToAction("Index", "Home1");
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            //var AppsettingRoot = _config.GetSection("Token");
            //var TokenKey = AppsettingRoot["Key"];
            //var TokenIssuer = AppsettingRoot["Issuer"];
            IdentityModelEventSource.ShowPII = true;

            SecurityToken ValidateToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();
            // package Microsoft.IdentityModel.Tokens;
            //var AppsettingRoot = _config.GetSection("Token");
            //var TokenKey = AppsettingRoot["Key"];
            //var TokenIssuer = AppsettingRoot["Issuer"];

            var TokenKey = _config["Token:Key"];
            var TokenIssuer = _config["Token:Issuer"];

            validationParameters.ValidateLifetime = true; // kiem soat token moi luc
            validationParameters.ValidAudience = TokenIssuer;
            validationParameters.ValidIssuer = TokenIssuer;
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out ValidateToken);
            return principal;
        }
    }
}