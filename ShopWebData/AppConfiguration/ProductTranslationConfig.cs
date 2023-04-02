using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopWebData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebData.AppConfiguration
{
    public class ProductTranslationConfig : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
           
            builder.ToTable("ProductTranslation").HasKey((x) => new { x.LangueId, x.ProductId });

            builder.HasOne(p => p.Product).WithMany(x => x.ProductTranslations)
                    .HasForeignKey(x => x.ProductId);
            builder.HasOne(p => p.Language).WithMany(x =>x.ProductTranslations)
                   .HasForeignKey(x => x.LangueId);
        }
    
    }
}
