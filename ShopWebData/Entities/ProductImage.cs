using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebData.Entities
{
    [Table("ProductImage")]
    public class ProductImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ImagePath { get; set; } // la 1 file anh
        [Required]
        [StringLength(200)]
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public DateTime DateCreate { get; set; }
        public int SortOrder { get; set; }
        public long FileSize { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Chọn một file")]
        [DataType(DataType.Upload)]
        //[BindProperty] // tu dong binding khi form post len
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        public IFormFile ThumbnailFile { get; set; }

        [ForeignKey("productId")]
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
