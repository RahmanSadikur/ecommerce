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
        public string productName { get; set; }
        public string productDescription { get; set; }
        public double productPrice { get; set; } 
        public string productStatus { get; set; }
        public string contact { get; set; }
        public int subCategoryId { get; set; }
        [ForeignKey("subCategoryId")]
        public SubCategory SubCategorys { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
    }
}