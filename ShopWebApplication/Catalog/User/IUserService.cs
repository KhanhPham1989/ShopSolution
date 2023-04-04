using ShopWebModels.Catalog.User;
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

        Task<GetUserView> EditUser(string userlogin, EditRequest request);

        Task<bool> ChangPassWord(string userlogin, ChangePassWord request);
    }
}