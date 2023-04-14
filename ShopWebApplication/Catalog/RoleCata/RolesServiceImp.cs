using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopWebData.Entities;
using ShopWebModels.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApplication.Catalog.RoleCata
{
    public class RolesServiceImp : IRolesService
    {
        private readonly RoleManager<RoleIdentity> _roleManager;

        public RolesServiceImp(RoleManager<RoleIdentity> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<RoleViewModel>> GetAllRole()
        {
            var roles = await _roleManager.Roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();
            if (roles == null)
            {
                return null;
            }
            return roles;
        }
    }
}