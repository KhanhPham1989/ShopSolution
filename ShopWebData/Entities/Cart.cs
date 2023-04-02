using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebData.Entities
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        [Range(1,double.MaxValue,ErrorMessage = "Sản phẩm không được nhỏ hơn 1")]
        public int Quantity { get; set; }
        
        public decimal Price { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        [ForeignKey("UserID")]
        public Guid UserID { set; get; }
        public Product Product { get; set; }
        public AppUser User { get; set; }
    }
}
