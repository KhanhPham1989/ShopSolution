using ShopWebModels.Catalog.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb_AdminApp.Service.User
{
    public interface IUserService
    {
        Task<string> LoginAuthenticate(LoginRequest request);
    }
}