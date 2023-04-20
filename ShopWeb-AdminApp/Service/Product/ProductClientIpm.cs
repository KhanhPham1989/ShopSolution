using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopWebModels.Catalog.Images;
using ShopWebModels.Catalog.Products;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShopWeb_AdminApp.Service.Product
{
    public class ProductClientIpm : BaseAPI, IProductClientInterface
    {
        //public ProductClientIpm(IHttpClientFactory httpClient, IConfiguration configuration,
        //    IHttpContextAccessor httpContextAccessor) : base(httpClient, configuration, httpContextAccessor)

        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _conf;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductClientIpm(IHttpClientFactory httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(httpClient, configuration, httpContextAccessor)
        {
            _httpClient = httpClient;
            _conf = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<APIResult<bool>> Create(ProductCreateRequest request)
        {
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_conf["Uri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);

            var requestContent = new MultipartFormDataContent();

            if (request.ThumbnaiImage != null)
            {
                byte[] data;

                using (var br = new BinaryReader(request.ThumbnaiImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnaiImage.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);

                //public void Add(HttpContent content, string name, string fileName);

                requestContent.Add(bytes, "ThumbnaiImage", request.ThumbnaiImage.FileName);
                requestContent.Add(new StringContent(request.CaptionImage.ToString()), "CaptionImage");
            }
            //MultipartFormDataContent.Add(HttpContent content, string name);
            //httpContent.StringContent(string content);
            //public StringContent(string content, Encoding? encoding, string? mediaType);
            requestContent.Add(new StringContent(request.Name), "Name");
            requestContent.Add(new StringContent(request.Price.ToString()), "Price");
            requestContent.Add(new StringContent(request.OriginalPrice.ToString()), "OriginalPrice");
            requestContent.Add(new StringContent(request.Stock.ToString()), "Stock");
            requestContent.Add(new StringContent(request.Description.ToString()), "Description");
            requestContent.Add(new StringContent(request.Details.ToString()), "Details");
            requestContent.Add(new StringContent(request.SeoAlias.ToString()), "SeoAlias");
            requestContent.Add(new StringContent(request.langId.ToString()), "langId");

            var respone = await client.PostAsync("/api/Products/CreateProduct", requestContent);
            var result = await respone.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject(result);
            if (respone.IsSuccessStatusCode)
            {
                return new APISuccessResult<bool>();
            }

            return new APIFailResult<bool>(result.ToString());
        }

        public Task<APIResult<int>> Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<APIResult<List<ProductViewModel>>> GetAll()
        {
            //string url = $"/api/Products/GetAllProduct";
            //var data = await base.GetAsync<APIResult<List<ProductViewModel>>>(url);

            return null;
        }

        public async Task<APIResult<PageResult<ProductViewModel>>> GetAllPaging(GetManageProductPagingRequest request)
        {
            string url = $"/api/Products/GetAllPaging?Key={request.Key}&Categori={request.Categori}&PageSize={request.PageSize}&PageIndex={request.PageIndex}";
            // var data = await base.GetAsync<APIResult<PageResult<ProductViewModel>>>(url);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_conf["Uri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.BearerToken);

            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<APISuccessResult<PageResult<ProductViewModel>>>(body);
                return result;
            }
            return JsonConvert.DeserializeObject<APIFailResult<PageResult<ProductViewModel>>>("Loi");
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