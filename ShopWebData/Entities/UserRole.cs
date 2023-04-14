using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebData.Entities
{
    [Table("UserRole")]
    public class UserRole : IdentityUserRole<Guid>
    {
        public AppUser appUser { get; set; }
        public RoleIdentity roleIdentity { get; set; }
    }
}