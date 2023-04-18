using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShopWeb_AdminApp.Service
{
    public class BaseAPI
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _conf;
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseAPI(IHttpClientFactory httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _conf = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        // nhan vao gia tri nao thi tra ve gia tri tuong tu
        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_conf["Uri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TResponse result = (TResponse)JsonConvert.DeserializeObject(body, typeof(TResponse));
                return result;
            }
            return JsonConvert.DeserializeObject<TResponse>(body);
        }
    }
}