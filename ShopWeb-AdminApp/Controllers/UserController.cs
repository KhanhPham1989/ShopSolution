using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public UserController(IUserService userService, IConfiguration Iconfiguration)
        {
            _userService = userService;
            _config = Iconfiguration;
        }

        public IActionResult Index(string Keyword, int PageIndex = 1, int PageSize = 10)
        {
            var session = HttpContext.Session.GetString("Token");
            var GetUser = new GetUserPagingRequest()
            {
                BearerToken = session,
                PageIndex = PageIndex,
                PageSize = PageSize,
                Keyword = Keyword
            };
            var data = _userService.GetUserPaging(GetUser);
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            // bat buoc log out nhung session cu khi vao login
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
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
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = true,

                //nhận hoặc đặt xem phiên xác thực có được duy trì qua nhiều yêu cầu hay khong
            };
            HttpContext.Session.SetString("Token", token);

            await HttpContext.SignInAsync(
                                            scheme: CookieAuthenticationDefaults.AuthenticationScheme,
                                            principal: userPrinciple,
                                            properties: auth);
            // pt nhan 2 hoac 3 tham so, => string cookie, Priciple, 1 thiet lap thoi gian
            return RedirectToAction(nameof(Index), "Home");
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