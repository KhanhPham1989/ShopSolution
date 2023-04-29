using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopWebModels.Catalog.Categories;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPIApp.Service.Categories
{
    public class CategoriServiceImp : BaseAPI, ICategoriesService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _conf;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoriServiceImp(IHttpClientFactory httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(httpClient, configuration, httpContextAccessor)
        {
            _httpClient = httpClient;
            _conf = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<APIResult<bool>> AssignCategori(int proId, CategoriAssign request)
        {
            string url = $"/api/Categories/{request.ProId}/CategoriAssign";
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_conf["Uri"]);
            var json = JsonConvert.SerializeObject(request);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var respone = await client.PutAsync(url, content);
            var data = await respone.Content.ReadAsStringAsync();
            if (respone.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<APISuccessResult<bool>>(data);
                return result;
            }

            return JsonConvert.DeserializeObject<APIFailResult<bool>>(data);
        }

        public async Task<List<CategoriSelected>> GetAllCategory()
        {
            string url = "/api/Categories";
            var respone = await GetListAsync<CategoriSelected>(url);
            if (respone.Count > 0)
            {
                return respone;
            }
            return null;
        }

        public async Task<CategoriAssign> GetCateByProductId(int proId)
        {
            string url = $"/api/Categories/{proId}";
            var respone = await GetAsync<CategoriAssign>(url);
            if (respone.ProId != 0)
            {
                return respone;
            }
            return null;
        }

        public async Task<CategoryViewModel> GetProductByCateId(int cateID, int langId)
        {
            string url = $"/api/Categories/{cateID}/{langId}";
            var respone = await GetAsync<CategoryViewModel>(url);
            if (respone.CateId != 0)
            {
                return respone;
            }
            return null;
        }

        //public async Task<List<CategoryViewModel>> GetAllCategory()
        //{
        //    string url = "/api/Categories?cateID=" + cateID;
        //    var respone = await GetListAsync<CategoryViewModel>(url);
        //    if (respone.Count > 0)
        //    {
        //        return respone;
        //    }
        //    return null;
        //}
    }
}