using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using ShopWeb_AdminApp.Service.User;
using ShopWebModels.Catalog.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
            var userPrinciple = this.ValidateToken(token);
            var auth = new AuthenticationProperties()
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(5),
                IsPersistent = true,

                //nhận hoặc đặt xem phiên xác thực có được duy trì qua nhiều yêu cầu hay khong
            };
            HttpContext.Session.SetString("Token", token);

            await HttpContext.SignInAsync(
                                            scheme: CookieAuthenticationDefaults.AuthenticationScheme,
                                            principal: userPrinciple,
                                            properties: auth);
            // pt nhan 2 hoac 3 tham so, => string cookie, Priciple, 1 thiet lap thoi gian
            return RedirectToAction("Index", "Home");
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            //var AppsettingRoot = _config.GetSection("Token");
            //var TokenKey = AppsettingRoot["Key"];
            //var TokenIssuer = AppsettingRoot["Issuer"];
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validateToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();
            validationParameters.ValidateLifetime = true; // kiem soat token moi luc
            validationParameters.ValidAudience = _config["Token:Issuer"];
            validationParameters.ValidIssuer = _config["Token:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validateToken);
            return principal;
        }
    }
}