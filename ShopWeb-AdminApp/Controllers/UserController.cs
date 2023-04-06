using Microsoft.AspNetCore.Mvc;
using ShopWeb_AdminApp.Service.User;
using ShopWebModels.Catalog.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb_AdminApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
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
            return View(token);
        }
    }
}