using ShopWebModels.Catalog.Categories;
using ShopWebModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.WebApp
{
    public class ProductDetailsViewModel
    {
        public CategoryViewModel category { get; set; }
        public ProductViewModel product { get; set; }
    }
}