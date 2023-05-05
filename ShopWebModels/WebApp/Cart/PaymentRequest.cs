using ShopWebData.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.WebApp.Cart
{
    public class PaymentRequest
    {
        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipEmail { get; set; }

        public string ShipPhone { get; set; }

        public OrderStatus Status { get; set; }

        public Guid UserId { get; set; }
        //0a0cd31a-383b-4723-4e10-08db3a6375eb

        public DateTime OrderDate { get; set; }

        public List<CartItemRequest> cartItem { get; set; }

        public string SendItem(DateTime request)
        {
            var dateNow = new DateTime(request.Year, request.Month, request.Day);
            var date = dateNow.AddDays(7);
            return date.ToShortDateString().ToString();
        }
    }
}