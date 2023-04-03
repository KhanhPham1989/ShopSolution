using Microsoft.AspNetCore.Http;
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
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductEditRequest request);
        Task<int> Delete(int productId);
        Task<ProductViewModel> GetById(int productId, int languageID);

        Task<List<Product>> GetAll();
        //Task<List<ProductViewModel>> GetAllPaging(string key, int pageIndex, int pageSize);
        //PageViewModel 1 class tra ve dang list theo du lieu truyen vao <>;
        // dua tat ca tham so vao 1 class, tuy nhien co class ko can key

        Task<PageResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task UpdateViewCount(int ProductId);

        Task<bool> UpdatePrice(int ProductId,decimal newPrice);

        Task<bool> UpdateStock(int ProductId, int newStock);

        Task<int> AddImages(int ProductId, List<IFormFile> productImages);

        Task<int> RemoveImages(int imageId);
        Task<int> UpdateImage(int imageId, string caption, bool Isdefault);
    }
}
