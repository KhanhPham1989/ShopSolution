using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using LibraryAPIApp.Service.RoleClient;
using LibraryAPIApp.Service.User;
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
        private readonly IRoleClientService _roleClientService;

        [TempData]
        public string thongbao { get; set; }

        public UserController(IRoleClientService roleClientService, IUserService userService, IConfiguration Iconfiguration, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _config = Iconfiguration;
            _httpContextAccessor = httpContextAccessor;
            _roleClientService = roleClientService;
        }

        public async Task<IActionResult> Index(string Keyword, int PageIndex = 1, int PageSize = 10)
        {
            //var session = HttpContext.Session.GetString("Token");
            //TokenSession = session;
            var GetUser = new GetUserPagingRequest()
            {
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
            return RedirectToAction("Error", "Home1");
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

        [HttpGet]
        public async Task<IActionResult> RoleAssign(Guid id)
        {
            var result = await GetAllRoleAssign(id);
            if (result != null)
            {
                return View(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> RoleAssign(RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var resurl = await _userService.RoleAssign(request.id, request);
            if (resurl.Success)
            {
                thongbao = "Cap nhat quyen thanh cong";
                return RedirectToAction("Index", "User");
            }

            ModelState.AddModelError("", resurl.Message);
            var userRoleAssign = await GetAllRoleAssign(request.id);
            return View(userRoleAssign);
        }

        private async Task<RoleAssignRequest> GetAllRoleAssign(Guid id)
        {
            var userRole = await _userService.GetById(id);  // lay role trong user

            var AllRoles = await _roleClientService.GetAllRole(); // lay tat ca role
            var UserRoleAssign = new RoleAssignRequest(); //
            foreach (var role in AllRoles.ObjResult)
            {
                // UserRoleAssign.id = id;
                var check = new Role_Selected()
                {
                    IdRole = role.Id.ToString(),
                    Name = role.Name,
                    Selected = userRole.ObjResult.RoleUser.Contains(role.Name),
                };
                UserRoleAssign.Roles.Add(check);
            }
            return UserRoleAssign;
        }
    }
}