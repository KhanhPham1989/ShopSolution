using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Catalog.Products
{
    public class ProductEditRequest
    {
        public int Proid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }

        public int LangId { get; set; } // dufng de query
        public IFormFile ThumbnaiImage { get; set; }
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public long FileSize { get; set; }
        public bool? IsFeatured { get; set; }
    }
}