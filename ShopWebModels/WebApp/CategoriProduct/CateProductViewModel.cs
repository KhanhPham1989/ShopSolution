using ShopWebData.Entities;
using ShopWebModels.Catalog.Categories;
using ShopWebModels.Catalog.Products;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.WebApp.CategoriProduct
{
    public class CateProductViewModel : PageResultBase
    {
        public CategoryViewModel Category { get; set; }
        public PageResult<ProductViewModel> proList { get; set; }
    }
}