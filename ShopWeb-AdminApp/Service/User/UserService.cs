using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopWebModels.Catalog.User;
using ShopWebModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopWeb_AdminApp.Service.User
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public UserService(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task<string> LoginAuthenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpcontent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://localhost:4564");
            var response = await client.PostAsync("/api/Users/LoginAuthenticate", httpcontent);
            var token = await response.Content.ReadAsStringAsync();
            return token;
        }

        public async Task<PageResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request)
        {
            //if (request.Keyword == null)
            //    throw new Exception("Keyword must be input");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.BearerToken);

            client.BaseAddress = new Uri(_config["Uri"]);

            var reponse = await client.GetAsync($"api/Users/GetUserPaging?PageIndex={request.PageIndex}" +
                $"&PageSize={request.PageSize}&Keyword={request.Keyword}");
            var data = await reponse.Content.ReadAsStringAsync();
            var UserList = JsonConvert.DeserializeObject<PageResult<UserViewModel>>(data);
            return UserList;
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config["Uri"]);
            var JsonString = JsonConvert.SerializeObject(request);
            var httpcontext = new StringContent(JsonString, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"api/Users/Register", httpcontext);

            return response.IsSuccessStatusCode;
        }
    }
}