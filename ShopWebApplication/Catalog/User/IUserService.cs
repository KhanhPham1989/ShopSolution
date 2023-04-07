using ShopWebModels.Catalog.User;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApplication.Catalog.User
{
    public interface IUserService
    {
        Task<string> Authencated(LoginRequest request);

        Task<bool> RegisterUser(RegisterRequest request);

        Task<UserViewModel> EditUser(string userlogin, EditRequest request);

        Task<bool> ChangPassWord(string userlogin, ChangePassWord request);

        Task<PageResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request);
    }
}