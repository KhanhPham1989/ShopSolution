using ShopWebModels.Catalog.User;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb_AdminApp.Service.User //adminapp
{
    public interface IUserService
    {
        Task<string> LoginAuthenticate(LoginRequest request);

        Task<APIResult<bool>> Register(RegisterRequest request);

        Task<APIResult<bool>> UpdateUser(Guid id, EditRequest request);

        Task<APIResult<PageResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request);

        Task<APIResult<UserViewModel>> GetById(Guid id);
    }
}