using Microsoft.AspNetCore.Http;
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
    public class UserService : IUserService //adminapp
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpClientFactory httpClientFactory, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> LoginAuthenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpcontent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://localhost:4564");
            var response = await client.PostAsync("api/Users/LoginAuthenticate", httpcontent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                // var resultSuccess = JsonConvert.DeserializeObject<APISuccessResult<string>>(result);
                //return resultSuccess;
                return result;
            }
            // var resultFail = JsonConvert.DeserializeObject<APIFailResult<string>>(result);
            //return resultFail;
            return null;
        }

        public async Task<APIResult<PageResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request)
        {
            //if (request.Keyword == null)
            //    throw new Exception("Keyword must be input");
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);

            client.BaseAddress = new Uri(_config["Uri"]);

            var reponse = await client.GetAsync($"api/Users/GetUserPaging?PageIndex={request.PageIndex}" +
                $"&PageSize={request.PageSize}&Keyword={request.Keyword}");
            var data = await reponse.Content.ReadAsStringAsync();
            var UserList = JsonConvert.DeserializeObject<APIResult<PageResult<UserViewModel>>>(data);

            return UserList;
        }

        public async Task<APIResult<bool>> Register(RegisterRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config["Uri"]);
            var JsonString = JsonConvert.SerializeObject(request);
            var httpcontext = new StringContent(JsonString, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"api/Users/Register", httpcontext);
            var data = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<APISuccessResult<bool>>(data);
                return result;
            }

            return JsonConvert.DeserializeObject<APIFailResult<bool>>(data);
        }

        public async Task<APIResult<bool>> UpdateUser(Guid id, EditRequest request)
        {
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config["Uri"]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);
            var Jsonstring = JsonConvert.SerializeObject(request);
            var httpcontext = new StringContent(Jsonstring, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"api/Users/EditInforUser/{id}", httpcontext);
            var data = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<APISuccessResult<bool>>(data);
                return result;
            }
            return JsonConvert.DeserializeObject<APIFailResult<bool>>(data);
        }

        public async Task<APIResult<UserViewModel>> GetById(Guid id)
        {
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_config["Uri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"api/User/{id}");
            var data = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<APISuccessResult<UserViewModel>>(data);
                return result;
            }
            return JsonConvert.DeserializeObject<APIFailResult<UserViewModel>>(data);
        }
    }
}