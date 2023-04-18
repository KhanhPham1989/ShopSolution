using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Catalog.User
{
    public class UserViewModel
    {
        public Guid id { get; set; }
        public string FullName { get; set; }
        public string UserPhone { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public IList<string> RoleUser { get; set; }
    }
}