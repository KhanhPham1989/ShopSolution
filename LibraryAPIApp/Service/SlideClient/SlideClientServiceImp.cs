using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ShopWebModels.Catalog.Products;
using ShopWebModels.Catalog.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPIApp.Service.SlideClient
{
    public class SlideClientServiceImp : BaseAPI, ISlideClient
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _conf;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SlideClientServiceImp(IHttpClientFactory httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(httpClient, configuration, httpContextAccessor)
        {
            _httpClient = httpClient;
            _conf = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<SlideViewModel>> GetAll()
        {
            string url = "/api/Slides/GetAllSlide";
            var respone = await GetListAsync<SlideViewModel>(url);
            if (respone.Count > 0)
            {
                return respone;
            }
            return null;
        }

        public async Task<List<ProductViewModel>> GetFeartureProduct(int PageSize)
        {
            string url = $"/api/Slides/GetFeartureProduct/{PageSize}";
            var respone = await GetListAsync<ProductViewModel>(url);
            if (respone.Count > 0)
            {
                return respone;
            }
            return null;
        }

        public async Task<List<ProductViewModel>> GetLatestProduct(int PageSize)
        {
            string url = $"/api/Slides/GetLatestProduct/{PageSize}";
            var respone = await GetListAsync<ProductViewModel>(url);
            if (respone.Count > 0)
            {
                return respone;
            }
            return null;
        }
    }
}