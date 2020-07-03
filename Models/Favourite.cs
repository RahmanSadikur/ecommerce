using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NMS.Models
{
    [Table("Favourite")]
    public class Favourite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int favouriteId { get; set; }
        
        public int userId { get; set; }
        public int productId { get; set; }
        [ForeignKey("userId")]
        public User Users { get; set; }
        [ForeignKey("productId")]
        public Product Products { get; set; }
    }
}