using ShopWebModels.Catalog.Products;
using ShopWebModels.Catalog.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Common
{
    public class HomeViewModel
    {
        public List<SlideViewModel> slides { get; set; }

        public List<ProductViewModel> FeartureProduct { get; set; }

        public List<ProductViewModel> LatestProduct { get; set; }
    }
}