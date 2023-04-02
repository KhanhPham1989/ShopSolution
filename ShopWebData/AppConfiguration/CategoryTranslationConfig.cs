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
    public class CategoryTranslationConfig : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
       
            builder.ToTable("CategoryTranslation").HasKey((x) => new { x.LangueId, x.CategoryId });

            builder.HasOne(p => p.Category).WithMany(x => x.CategoryTranslations)
                    .HasForeignKey(x => x.CategoryId);
            builder.HasOne(p => p.Language).WithMany(x => x.CategoryTranslations)
                   .HasForeignKey(x => x.LangueId);
        }

    }

}
