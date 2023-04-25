using ShopWebModels.Catalog.User;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPIApp.Service.User //adminapp
{
    public interface IUserService
    {
        Task<string> LoginAuthenticate(LoginRequest request);

        Task<APIResult<bool>> Register(RegisterRequest request);

        Task<APIResult<UserViewModel>> UpdateUser(Guid id, EditRequest request);

        Task<PageResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request);

        Task<APIResult<UserViewModel>> GetById(Guid id);

        Task<APIResult<bool>> Delete(Guid id);

        Task<APIResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
    }
}