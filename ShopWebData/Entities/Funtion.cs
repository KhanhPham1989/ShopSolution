using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebData.Entities
{
    [Table("Funtion")]
    public class Funtion
    {
        [Key]
        public Guid FunID { get; set; }

        public List<SystemActivities> SystemActivities { get; set; }
    }
}
