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
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
      
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUser").HasKey(x => x.Id);
        }
    }
}
