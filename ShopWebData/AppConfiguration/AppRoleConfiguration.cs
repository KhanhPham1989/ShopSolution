using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWebData.Entities;

namespace ShopWebData.AppConfiguration
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<RoleIdentity>
    {
        public void Configure(EntityTypeBuilder<RoleIdentity> builder)
        {
            builder.ToTable("AppRoles").HasKey(x => x.Id);
        }
    }
}
