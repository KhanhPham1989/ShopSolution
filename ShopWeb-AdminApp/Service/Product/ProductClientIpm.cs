using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ShopWebModels.Catalog.Images;
using ShopWebModels.Catalog.Products;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopWeb_AdminApp.Service.Product
{
    public class ProductClientIpm : IProductClientInterface
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _conf;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductClientIpm(IHttpClientFactory httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _conf = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<APIResult<int>> Create(ProductCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<APIResult<int>> Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<APIResult<List<IProductClient>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<APIResult<PageResult<ProductViewModel>>> GetAllPaging(GetManageProductPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<APIResult<ProductViewModel>> GetById(int productId, int languageID)
        {
            throw new NotImplementedException();
        }

        public Task<APIResult<ImageViewModels>> GetImageById(int ImageId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ImageViewModels>> GetListImages(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<APIResult<int>> RemoveImages(int productId, int ImageId)
        {
            throw new NotImplementedException();
        }

        public Task<APIResult<int>> Update(ProductEditRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<APIResult<int>> UpdateImage(int productId, int ImageId, ImageEditRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<APIResult<bool>> UpdatePrice(int ProductId, decimal newPrice)
        {
            throw new NotImplementedException();
        }

        public Task<APIResult<bool>> UpdateStock(int ProductId, int newStock)
        {
            throw new NotImplementedException();
        }

        public Task<APIResult<bool>> UpdateViewCount(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<APIResult<int>> AddImages(int productId, ImageCreateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}