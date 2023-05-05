using ShopWebModels.WebApp.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApplication.Catalog.Cart
{
    public interface IPaymentAPI
    {
        Task<int> PaymentRequest(PaymentRequest request);
    }
}