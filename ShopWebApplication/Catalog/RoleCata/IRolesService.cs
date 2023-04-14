using ShopWebModels.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApplication.Catalog.RoleCata
{
    public interface IRolesService
    {
        Task<List<RoleViewModel>> GetAllRole();
    }
}