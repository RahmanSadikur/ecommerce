using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NMS.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int productId { get; set; }
        [Required]
        public string productName { get; set; }
        public string productDescription { get; set; }
        public double productPrice { get; set; }
        [Required]
        public string productStatus { get; set; }
        [Required]
        public string contact { get; set; }
        [Required]
        public int subCategoryId { get; set; }
        public bool isPinnedProduct { get; set; }
        public bool isFavourite { get; set; }
        public string color{ get; set; }
        [ForeignKey("subCategoryId")]
        public SubCategory SubCategorys { get; set; }
        public ICollection<Image> Images { get; set; }
        
    }
}