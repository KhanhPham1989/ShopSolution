using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebModels.Catalog.User
{
    public class ChangePassWord
    {
        [Required]
        public string PassWord { get; set; }

        [Required]
        public string NewPassWord { get; set; }

        [Required]
        public string PassWordConfirm { get; set; }
    }
}