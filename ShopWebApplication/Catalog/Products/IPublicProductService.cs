using ShopWebData.Entities;
using ShopWebModels.Catalog.Products;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopWebApplication.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PageResult<ProductViewModel>> GetAllByCategoryById(GetPublicProductPagingRequest request);

        Task<List<ProductViewModel>> GetAll();
       // Task<List<Product>> GetList();
    }
}
