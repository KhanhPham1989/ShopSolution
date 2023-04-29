using ShopWebModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.WebApp.Cart
{
    public class CartItemRequest
    {
        public int CateId { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public int Quantity { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
    }
}