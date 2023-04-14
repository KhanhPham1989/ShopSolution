using Microsoft.EntityFrameworkCore;
using ShopWebData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopWebData.AppConfiguration
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole").HasKey(x => new { x.UserId, x.RoleId });
        }
    }
}