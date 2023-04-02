using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebData.Entities
{
    [Table("CategoryTranslation")]
    public class CategoryTranslation
    {
       
        public string Name { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }

        public int CategoryId { get; set; }
        public int LangueId { get; set; }

        public Category Category { get; set; }
        public Language Language { get; set; }
    }
}
