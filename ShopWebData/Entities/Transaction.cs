using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace ShopWebData.Entities
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ExternalTransactionId { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public string Result { get; set; }
        public string Message { get; set; }
        public TransactionStatus Status { get; set; }
        public string Provider { get; set; }
        [ForeignKey("UserID")]
        public Guid UserID { set; get; }

        public AppUser AppUser { set; get; }
    }
}
