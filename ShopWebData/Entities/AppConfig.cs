using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebData.Entities
{
    [Table("AppConfig")]
    public class AppConfig
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Key { get; set; }
        public string Keys { get; set; }
        public string Value { get; set; }
    }
}
