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

        Task<APIResult<bool>> RegisterUser(RegisterRequest request);

        Task<APIResult<UserViewModel>> EditUser(Guid id, EditRequest request);

        Task<bool> ChangPassWord(string userlogin, ChangePassWord request);

        Task<PageResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request);

        Task<APIResult<UserViewModel>> GetById(Guid id);

        Task<APIResult<bool>> DeleteUser(Guid id);

        Task<APIResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
    }
}