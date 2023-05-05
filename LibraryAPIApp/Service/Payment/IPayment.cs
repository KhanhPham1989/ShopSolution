using ShopWebModels.WebApp.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPIApp.Service.Payment
{
    public interface IPayment
    {
        Task<int> PaymentRequest(PaymentRequest request);
    }
}