using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Catalog.User
{
    public class RegisterRequest : LoginRequest
    {
        public string FullName { get; set; }
        public string PassWordConfirm { get; set; }
        public string UserPhone { get; set; }
        public string Email { get; set; }
    }
}