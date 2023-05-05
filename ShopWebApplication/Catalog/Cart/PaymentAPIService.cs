using ShopWebData.DbContextData;
using ShopWebData.Entities;
using ShopWebModels.WebApp.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApplication.Catalog.Cart
{
    public class PaymentAPIService : IPaymentAPI
    {
        private readonly TeduDbContext _data;

        public PaymentAPIService(TeduDbContext data)
        {
            _data = data;
        }

        public async Task<int> PaymentRequest(PaymentRequest request)
        {
            var order = new Order()
            {
                ShipName = request.ShipName,
                ShipAddress = request.ShipAddress,
                ShipEmail = request.ShipEmail,
                ShipPhone = request.ShipPhone,
                OrderDate = DateTime.Now,
                UserId = Guid.Parse("0a0cd31a-383b-4723-4e10-08db3a6375eb"),
            };
            await _data.Orders.AddAsync(order);
            await _data.SaveChangesAsync();

            var orderId = order.OrderId;
            foreach (var item in request.cartItem)
            {
                await _data.OrderDetails.AddAsync(new OrderDetail()
                {
                    OrderId = orderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price * item.Quantity,
                });
                await _data.SaveChangesAsync();
            }

            return orderId;
        }
    }
}