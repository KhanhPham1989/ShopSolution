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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [TempData]
        public string thongbao { get; set; }

        public UserController(IUserService userService, IConfiguration Iconfiguration, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _config = Iconfiguration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index(string Keyword, int PageIndex = 1, int PageSize = 10)
        {
            //var session = HttpContext.Session.GetString("Token");
            //TokenSession = session;
            var GetUser = new GetUserPagingRequest()
            {
                // BearerToken = session,
                PageIndex = PageIndex,
                PageSize = PageSize,
                Keyword = Keyword
            };
            var data = await _userService.GetUserPaging(GetUser);
            if (!string.IsNullOrEmpty(thongbao))
            {
                ViewBag.message = thongbao;
            };
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
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var resurl = await _userService.Register(request);
            if (!resurl.Success)
            {
                ModelState.AddModelError("", resurl.Message);
                return View(request);
            }

            return RedirectToAction(nameof(Index), "Login");
        }

        [HttpGet]
        public async Task<IActionResult> EditInforUser(Guid id)
        {
            var result = await _userService.GetById(id);
            if (result.Success)
            {
                var user = result.ObjResult;
                var UserUpdateRequet = new EditRequest()
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    UserPhone = user.UserPhone,
                    DOB = user.DOB,
                    id = user.id
                };
                return View(UserUpdateRequet);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> EditInforUser(Guid id, EditRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var resurl = await _userService.UpdateUser(id, request);

            //ModelState.AddModelError("", resurl.Message);
            //return View(request);

            if (resurl.Success)
            {
                thongbao = $"Ban vua cap nhat thanh cong tai khoan {request.FullName} ";
                return RedirectToAction("Index", "User");
            }
            if (resurl.Message != null)
            {
                return BadRequest(resurl.Message);
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _userService.GetById(id);
            if (result.Success)
            {
                var user = result.ObjResult;
                var UserInformation = new UserViewModel()
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    UserPhone = user.UserPhone,
                    DOB = user.DOB,
                    id = user.id
                };
                return View(UserInformation);
            }
            return BadRequest($"{id} khong ton tai, kiem tra lai");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.GetById(id);
            if (result.Success)
            {
                var user = result.ObjResult;
                var UserInformation = new UserViewModel()
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    UserPhone = user.UserPhone,
                    DOB = user.DOB,
                    id = user.id
                };
                return View(UserInformation);
            }
            return BadRequest($"{id} khong ton tai, kiem tra lai");
        }

        private string Name { get; set; }

        [HttpPost]
        public async Task<IActionResult> Delete(UserViewModel request)
        {
            Name = request.FullName;
            var result = await _userService.Delete(request.id);
            if (result.Success == true)
            {
                thongbao = $"bạn vừa xóa tai khoan {Name} thanh cong ";
                return RedirectToAction("Index", "User");
            }
            return BadRequest(result.Message);
        }
    }
}