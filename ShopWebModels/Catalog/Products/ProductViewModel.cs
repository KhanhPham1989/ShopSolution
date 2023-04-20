using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Catalog.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal OriginalPrice { get; set; }

        public int Stock { get; set; }
        public int CategoriId { get; set; }
        public int ViewCount { get; set; }
        private DateTime _datecreate;

        public DateTime DateCreated
        {
            get
            {
                return _datecreate;
            }
            set
            {
                _datecreate = DateTime.Today;
            }
        }

        public string SeoAlias { get; set; }
        public string TranslationName { get; set; }
        public string TranslationDescription { get; set; }
        public string TranslationDetails { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
    }
}