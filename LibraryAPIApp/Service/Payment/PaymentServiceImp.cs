using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopWebModels.WebApp.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPIApp.Service.Payment
{
    public class PaymentServiceImp : IPayment
    {
        private readonly IHttpContextAccessor _httpContext;
        private IHttpClientFactory _httpClient;
        private readonly IConfiguration _confi;

        public PaymentServiceImp(IHttpContextAccessor httpContext, IHttpClientFactory httpClient, IConfiguration confi)
        {
            _httpContext = httpContext;
            _httpClient = httpClient;
            _confi = confi;
        }

        public async Task<int> PaymentRequest(PaymentRequest request)
        {
            var session = _httpContext.HttpContext.Session.GetString("Token");
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(_confi["Uri"]);
            var Json = JsonConvert.SerializeObject(request);
            var Jsonstring = new StringContent(Json, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);
            var respone = await client.PostAsync("/api/Carts", Jsonstring);
            var data = await respone.Content.ReadAsStringAsync();
            if (respone.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<int>(data);
            }

            return 0;
        }
    }
}