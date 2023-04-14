using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Catalog.User
{
    public class RoleAssignRequest
    {
        public Guid id { get; set; }
        public List<Role_Selected> Roles { get; set; } = new List<Role_Selected>();
        // khong khai bao khi add vao se bi null
    }
}