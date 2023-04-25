using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebData.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [Range(1000, double.MaxValue, ErrorMessage = "{0} phải lớn hơn {1} VND")]
        public decimal Price { get; set; }

        [Required]
        [Range(1000, double.MaxValue, ErrorMessage = "{0} phải lớn hơn {1} VND")]
        public decimal OriginalPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Nhập số lượng hàng tồn kho, {0} không thể âm")]
        public int Stock { get; set; }

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

        [Required]
        public string SeoAlias { get; set; }

        public bool? IsFeatured { get; set; }
        public List<ProductInCaterogy> ProductInCaterogies { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<ProductTranslation> ProductTranslations { get; set; }
        public List<Promotion> Promotions { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}