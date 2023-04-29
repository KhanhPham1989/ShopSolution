using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        public int CateId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int OriginalPrice { get; set; }

        public int Stock { get; set; }

        public string Description { get; set; }
        public string Details { get; set; }

        public string CaptionImage { get; set; }
        public string SeoAlias { get; set; }
        public int langId { get; set; }
        public string LangName { get; set; }
        public string SeoDescription { get; set; }

        public string SeoTitle { get; set; }
        public IFormFile ThumbnaiImage { get; set; }
    }
}