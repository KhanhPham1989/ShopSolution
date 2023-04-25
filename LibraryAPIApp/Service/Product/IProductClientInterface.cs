using ShopWebModels.Catalog.Images;
using ShopWebModels.Catalog.Products;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPIApp.Service.Product
{
    public interface IProductClientInterface
    {
        Task<APIResult<bool>> Create(ProductCreateRequest request);

        Task<APIResult<bool>> Update(ProductEditRequest request);

        Task<APIResult<int>> Delete(int productId);

        Task<APIResult<ProductViewModel>> GetById(int productId, int languageID);

        Task<APIResult<List<ProductViewModel>>> GetAll();

        //Task<List<ProductViewModel>> GetAllPaging(string key, int pageIndex, int pageSize);
        //PageViewModel 1 class tra ve dang list theo du lieu truyen vao <>;
        // dua tat ca tham so vao 1 class, tuy nhien co class ko can key

        Task<APIResult<PageResult<ProductViewModel>>> GetAllPaging(GetManageProductPagingRequest request);

        Task<APIResult<bool>> UpdateViewCount(int ProductId);

        Task<APIResult<bool>> UpdatePrice(int ProductId, decimal newPrice);

        Task<APIResult<bool>> UpdateStock(int ProductId, int newStock);

        Task<APIResult<int>> AddImages(int productId, ImageCreateRequest request);

        Task<APIResult<int>> RemoveImages(int productId, int ImageId);

        Task<APIResult<int>> UpdateImage(int productId, int ImageId, ImageEditRequest request);

        Task<List<ImageViewModels>> GetListImages(int productId);

        Task<APIResult<ImageViewModels>> GetImageById(int ImageId);
    }
}