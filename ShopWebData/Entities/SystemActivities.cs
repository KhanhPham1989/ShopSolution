using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebData.Entities
{
    [Table("SystemActivities")]
    public class SystemActivities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ActionName { get; set; }
        public DateTime ActionDate { get; set; }
        [ForeignKey("FuntionId")]
        public Guid FuntionId { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public string ClientIP { get; set; }

        public Funtion Funtion { get; set; }
        public AppUser Users { get; set; }
    }
}
