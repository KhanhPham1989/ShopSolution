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
                //return new APIFailResult<string>("Tai khoan khong ton tai"); ;
                return null;

            var result = await _signinManager.PasswordSignInAsync(user, request.PassWord, request.RememberMe, false);
            //var result = await _signinManager.CheckPasswordSignInAsync(user, request.PassWord, true);
            if (!result.Succeeded)
                // return new APIFailResult<string>("Mat khau khong dung");
                return null;

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
            //var s = new APISuccessResult<string>()
            //{
            //    ObjResult = tokenstring,
            //};
            //return new APISuccessResult<string>(tokenstring);
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

        public async Task<APIResult<UserViewModel>> EditUser(Guid id, EditRequest request)
        {
            var checkuser = await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id);
            if (checkuser)
                return new APIFailResult<UserViewModel>("Email da ton tai");

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                user.Email = request.Email;
                user.FullName = request.FullName;
                user.PhoneNumber = request.UserPhone;
                user.DOB = request.DOB;
                user.Id = request.id;
            }

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return new APIFailResult<UserViewModel>("Khong thanh cong");

            var userUpdate = new UserViewModel()
            {
                id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                UserPhone = user.PhoneNumber,
                DOB = user.DOB
            };

            return new APISuccessResult<UserViewModel>(userUpdate);
        }

        public async Task<APIResult<bool>> RegisterUser(RegisterRequest request)
        {
            var checkName = await _userManager.FindByNameAsync(request.UserLogin);
            if (checkName != null)
                return new APIFailResult<bool>($"{request.UserLogin} have already exits..., try to annother");

            var checkEmail = await _userManager.FindByEmailAsync(request.Email);
            if (checkEmail != null)
                return new APIFailResult<bool>($"{request.Email} have already exits..., try to annother");

            if (request.PassWord != request.PassWordConfirm)
                return new APIFailResult<bool>($"Check again {request.PassWord} and {request.PassWordConfirm} ");

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
                return new APIFailResult<bool>(result.Errors.ToString());
            return new APISuccessResult<bool>();
        }

        public async Task<PageResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request)
        {
            var querry = _userManager.Users;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                querry = querry.Where(x =>
                    x.UserName.Contains(request.Keyword) ||
                    x.Email.Contains(request.Keyword) ||
                    x.FullName.Equals(request.Keyword) ||
                    x.PhoneNumber.Equals(request.Keyword));
            }
            if (!querry.Any())
            {
                var userList = _userManager.Users;
                var totalnull = await userList.CountAsync();
                var data = await userList.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                          .Select(x => new UserViewModel()
                          {
                              id = x.Id,
                              FullName = x.FullName,
                              Email = x.Email,
                              UserPhone = x.PhoneNumber,
                              DOB = x.DOB
                          }).ToListAsync();

                var page = new PageResult<UserViewModel>()
                {
                    Item = data,
                    TotalRecord = totalnull
                };
                return page;
            }
            var totalUser = await querry.CountAsync();
            var resurl = await querry.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                          .Select(x => new UserViewModel()
                          {
                              id = x.Id,
                              FullName = x.FullName,
                              Email = x.Email,
                              UserPhone = x.PhoneNumber,
                              DOB = x.DOB
                          }).ToListAsync();

            var pageUser = new PageResult<UserViewModel>()
            {
                Item = resurl,
                TotalRecord = totalUser
            };
            return pageUser;
        }

        public async Task<APIResult<UserViewModel>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return new APIFailResult<UserViewModel>("ID khong ton tai");

            var userRole = await _userManager.GetRolesAsync(user);
            var userViewModel = new UserViewModel()
            {
                id = id,
                FullName = user.FullName,
                Email = user.Email,
                UserPhone = user.PhoneNumber,
                DOB = user.DOB,
                RoleUser = userRole
            };

            return new APISuccessResult<UserViewModel>(userViewModel);
        }

        public async Task<APIResult<bool>> DeleteUser(Guid id)
        {
            var resurl = await _userManager.FindByIdAsync(id.ToString());
            if (resurl != null)
            {
                await _userManager.DeleteAsync(resurl);
                return new APISuccessResult<bool>();
            }
            return new APIFailResult<bool>("Check again information");
        }

        public async Task<APIResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.id.ToString());
            if (user == null)
            {
                return new APIFailResult<bool>($"{request.id} khong ton tai");
            }
            else
            {
                var roleUser = await _userManager.GetRolesAsync(user);
                user.roles = roleUser;
                var removeRoles = request.Roles.Where(x => x.Selected == false).Select(x => x.Name).ToList();
                await _userManager.RemoveFromRolesAsync(user, removeRoles);
                var addRoles = request.Roles.Where(x => x.Selected == true).Select(x => x.Name).ToList();

                foreach (var roleName in addRoles)
                {
                    // kiem tra user co chua role dc chon hay ko
                    // var checkUserInRole = await _userManager.IsInRoleAsync(user, roleName);
                    if (await _userManager.IsInRoleAsync(user, roleName) == false)
                    {
                        var check = await _userManager.AddToRoleAsync(user, roleName);
                    }
                }
            }
            // lay ra nhung role ko dc chon
            return new APISuccessResult<bool>();
            // return new APIFailResult<bool>();
        }
    }
}