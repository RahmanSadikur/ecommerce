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
        public byte[] Productimage { get; set; }
        public int productId { get; set; }
        [ForeignKey("productId")]
        public Product Products { get; set; }
    }
}