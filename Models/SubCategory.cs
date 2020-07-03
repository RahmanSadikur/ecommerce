using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NMS.Models
{
    [Table("SubCategory")]
    public class SubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int subCategoryId { get; set; }
        public string subCategoryName { get; set; }
        public int categoryId { get; set; }
        [ForeignKey("categoryId")]
        public Category Categorys { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}