using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopWebData.Entities;
using ShopWebModels.Catalog.User;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApplication.Catalog.User
{
    public class UserServiceImp : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly RoleManager<RoleIdentity> _roleManager;
        private readonly IConfiguration _config;

        public UserServiceImp(UserManager<AppUser> userManager, SignInManager<AppUser> signinManager,
            RoleManager<RoleIdentity> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _roleManager = roleManager;
            _config = config;
        }

        public async Task<string> Authencated(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserLogin);
            if (user == null)
                return null;

            var result = await _signinManager.PasswordSignInAsync(user, request.PassWord, request.RememberMe, false);
            //var result = await _signinManager.CheckPasswordSignInAsync(user, request.PassWord, true);
            if (!result.Succeeded)
                throw new Exception(result.ToString());

            //user.LastLoginDate = DateTime.Now;
            //await _userManager.UpdateAsync(user);

            //lấy tiếp ra các role của user, chuyeern thanh chuoi trong claim
            var roles = await _userManager.GetRolesAsync(user);

            //thông tin về người dùng.Nó chứa thông tin dưới dạng Key - Value pairs, trong đó Key là loại Type và Value
            // là giá trị của loại Type đó.Claim có thể là bất cứ thứ gì ví dụ Name Claim,
            // => lấy ra thông tin người dùng
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FullName),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("PhoneNumber", user.PhoneNumber),
                new Claim(ClaimTypes.Role, string.Join(";", roles))
            };

            //doc du lieu trong app setting
            //var testoptions = configuration.GetSection("TestOptions");  // Đọc một Section trả về IConfigurationSection
            //var opt_key1 = testoptions["opt_key1"];                  // Đọc giá trị trong Section
            //var k1 = testoptions.GetSection("opt_key2")["k1"]; // Đọc giá trị trong Section con
            //var k2 = configuration["TestOptions:opt_key2:k2"]; // Đọc giá trị trong Section

            //stb.Append($"   TestOptions.opt_key1:  {opt_key1}\n");
            //stb.Append($"TestOptions.opt_key2.k1:  {k1}\n");
            //stb.Append($"TestOptions.opt_key2.k2:  {k2}\n");

            // Ma hoa cac Claim
            var AppsettingRoot = _config.GetSection("Token");

            var TokenKey = AppsettingRoot["Key"];
            var TokenIssuer = AppsettingRoot["Issuer"];
            var key = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(TokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(TokenIssuer,
                    TokenIssuer,
                    claims,
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: creds
                    );

            var tokenstring = new JwtSecurityTokenHandler().WriteToken(Token);
            return tokenstring;
        }

        public async Task<bool> ChangPassWord(string userlogin, ChangePassWord request)
        {
            var checkUser = await _userManager.FindByNameAsync(userlogin);
            if (checkUser == null)
                return false;

            if (request.NewPassWord != request.PassWordConfirm)
                throw new Exception("Check PassWordConfirm agian");
            //checkUser.PasswordHash = request.NewPassWord;
            var resurl = await _userManager.ChangePasswordAsync(checkUser, request.PassWord, request.PassWordConfirm);
            if (!resurl.Succeeded)
                resurl.Errors.ToList().ForEach(error => throw new Exception(error.Description));

            return true;
        }

        public async Task<UserViewModel> EditUser(string userlogin, EditRequest request)
        {
            var checkUser = await _userManager.FindByNameAsync(userlogin);
            if (checkUser == null)
                return null;

            checkUser.Email = request.Email == null ? checkUser.Email : request.Email;
            checkUser.FullName = request.FullName == null ? checkUser.FullName : request.FullName;
            checkUser.PhoneNumber = request.UserPhone == null ? checkUser.PhoneNumber : request.UserPhone;
            var result = await _userManager.UpdateAsync(checkUser);
            if (!result.Succeeded)
                result.Errors.ToList().ForEach(error => throw new Exception(error.Description));

            var user = new UserViewModel()
            {
                FullName = checkUser.FullName,
                Email = checkUser.Email,
                UserPhone = checkUser.PhoneNumber
            };
            return user;
        }

        public async Task<bool> RegisterUser(RegisterRequest request)
        {
            var checkName = await _userManager.FindByNameAsync(request.UserLogin);
            if (checkName != null)
                throw new Exception($"{request.UserLogin} have already exits..., try to annother");

            var checkEmail = await _userManager.FindByEmailAsync(request.Email);
            if (checkEmail != null)
                throw new Exception($"{request.Email} have already exits..., try to annother");

            if (request.PassWord != request.PassWordConfirm)
                throw new Exception($"Check again {request.PassWord} and {request.PassWordConfirm} ");

            var newUser = new AppUser
            {
                UserName = request.UserLogin,
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.UserPhone,
                PasswordHash = request.PassWord,
            };
            var result = await _userManager.CreateAsync(newUser, request.PassWord);
            if (!result.Succeeded)
                result.Errors.ToList().ForEach(error => throw new Exception(error.Description));
            return true;
        }

        public async Task<PageResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request)
        {
            var querry = _userManager.Users;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                querry = querry.Where(x => x.UserName.Contains(request.Keyword) || x.Email.Contains(request.Keyword));
            }

            var totalUser = await querry.CountAsync();
            var resurl = await querry.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                          .Select(x => new UserViewModel()
                          {
                              id = x.Id,
                              FullName = x.FullName,
                              Email = x.Email,
                              UserPhone = x.PhoneNumber
                          }).ToListAsync();

            var pageUser = new PageResult<UserViewModel>()
            {
                Item = resurl,
                TotalRecord = totalUser
            };
            return pageUser;
        }
    }
}