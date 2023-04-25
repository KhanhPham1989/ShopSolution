using ShopWebModels.Catalog.Products;
using ShopWebModels.Catalog.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPIApp.Service.SlideClient
{
    public interface ISlideClient
    {
        Task<List<SlideViewModel>> GetAll();

        Task<List<ProductViewModel>> GetFeartureProduct(int PageSize);

        Task<List<ProductViewModel>> GetLatestProduct(int PageSize);
    }
}