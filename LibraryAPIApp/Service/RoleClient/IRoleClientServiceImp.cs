using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopWebModels.Catalog;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LibraryAPIApp.Service.RoleClient
{
    public class IRoleClientServiceImp : IRoleClientService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;

        public IRoleClientServiceImp(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _config = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResult<List<RoleViewModel>>> GetAllRole()
        {
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config["Uri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync("/api/Roles/GetAllRole");
            var data = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                List<RoleViewModel> roleObj = (List<RoleViewModel>)JsonConvert.DeserializeObject(data, typeof(List<RoleViewModel>));
                var result = new APISuccessResult<List<RoleViewModel>>(roleObj);
                return result;
            }

            var failResurl = JsonConvert.DeserializeObject<APIFailResult<List<RoleViewModel>>>(data);
            return failResurl;
        }
    }
}