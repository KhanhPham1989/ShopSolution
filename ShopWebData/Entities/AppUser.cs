﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebData.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        [Required]
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastLoginDate { get; set; }
        public List<Order> Orders { get; set; }
        public List<SystemActivities> SystemActivities { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Transaction> Transactions { get; set; }
       // public List<UserRole> userRoles { get; set; }
    }
}
