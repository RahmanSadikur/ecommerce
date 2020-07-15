using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NMS.Models
{
    [Table("Image")]
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int imageId { get; set; }
        [Required]
        public string ImageTitle { get; set; }
        [Required]
        public byte[] ImageData { get; set; }
        public bool isPinned { get; set; }
        [Required]
        public int productId { get; set; }
        [ForeignKey("productId")]
        public Product Products { get; set; }
    }
}