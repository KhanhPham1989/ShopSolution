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
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        private DateTime orderdate;
        public DateTime OrderDate
        {
            get
            {
                return orderdate;
            }
            set
            {
                orderdate = DateTime.Today;
            }
        }
        [Required]
        public string ShipName { get; set; }
        [Required]
        public string ShipAddress { get; set; }
        [Required]
        public string ShipEmail { get; set; }
        [Required]
        public string ShipPhone { get; set; }
        public OrderStatus Status { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        public AppUser GetUser { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
