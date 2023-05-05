using ShopWebModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Range(1, int.MaxValue, ErrorMessage = "{0} phai co so luong it nhat la 1")]
        public int Quantity { get; set; }

        public string ImagePath { get; set; }
        public decimal Price { get; set; }
    }
}