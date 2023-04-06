using Newtonsoft.Json;
using ShopWebModels.Catalog.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopWeb_AdminApp.Service.User
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
    }
}