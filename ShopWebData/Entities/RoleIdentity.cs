using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebData.Entities
{
    public class RoleIdentity : IdentityRole<Guid>
    {
        [StringLength(200)]
        public string Description { get; set; }
    }
}
