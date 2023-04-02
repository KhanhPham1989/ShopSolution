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
    public class ProductInCategoryConfig : IEntityTypeConfiguration<ProductInCaterogy>
    {
        public void Configure(EntityTypeBuilder<ProductInCaterogy> builder)
        {
            builder.ToTable("ProductCategory").HasKey((x) => new { x.CategoryId, x.ProductId });

            builder.HasOne(p => p.Product).WithMany(x => x.ProductInCaterogies)
                    .HasForeignKey(x => x.ProductId);
            builder.HasOne(p => p.Categories).WithMany(x => x.ProductInCaterogies)
                   .HasForeignKey(x => x.CategoryId);
        }
    }
}
