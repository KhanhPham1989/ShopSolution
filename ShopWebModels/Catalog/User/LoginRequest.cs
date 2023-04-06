using ShopWebModels.Catalog.User.ValadateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Catalog.User
{
    public class LoginRequest
    {
        public string UserLogin { get; set; }
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }
    }
}