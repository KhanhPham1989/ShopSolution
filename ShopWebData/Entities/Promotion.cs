using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopWebData.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebData.Entities
{
    [Table("Promotion")]
    public class Promotion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool ApplyForAll { get; set; }
        [Required]
        [Range(10,150,ErrorMessage = "{0} nằm trong khoảng từ {1} đến {2}")]
        public decimal DiscountPercent { get; set; }
        [Required]
       
        public decimal DiscountAmount { get; set; }
        public int ProductId { get; set; }
        //public int ProductCategoryId { get; set; }
        public Status Status { get; set; }

        public Product Product { get; set; }
    }
}
