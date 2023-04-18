using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebData.Entities
{
    public class RoleIdentity : IdentityRole<Guid>
    {
        [StringLength(200)]
        public string Description { get; set; }

        public List<UserRole> userRole { get; set; } = new List<UserRole>();
    }
}