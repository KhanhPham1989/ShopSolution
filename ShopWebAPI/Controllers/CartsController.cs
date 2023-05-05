using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWebApplication.Catalog.Cart;
using ShopWebData.Entities;
using ShopWebModels.WebApp.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IPaymentAPI _cart;

        public CartsController(IPaymentAPI cart)
        {
            _cart = cart;
        }

        [HttpPost]
        public async Task<IActionResult> PaymentRequest([FromBody] PaymentRequest request)
        {
            var result = await _cart.PaymentRequest(request);
            if (result != 0)
                return Ok(result);

            return BadRequest();
        }
    }
}