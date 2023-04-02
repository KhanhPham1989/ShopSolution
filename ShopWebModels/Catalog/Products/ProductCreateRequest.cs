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
        public decimal Price { get; set; }

        public int OriginalPrice { get; set; }

        public int Stock { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public IFormFile ThumbnaiImage { get; set; }
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public DateTime DateCreate { get; set; }
        public int SortOrderImage { get; set; }
        public long FileSize { get; set; }
    }
}
