using ShopWebModels.Catalog;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPIApp.Service.RoleClient
{
    public interface IRoleClientService
    {
        Task<APIResult<List<RoleViewModel>>> GetAllRole();
    }
}