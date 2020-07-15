using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NMS.Models.ViewModel
{
    public class CategoryViewModel
    {
        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<Product> Products { get; set; }
        public List<Image> Images { get; set; }
        public Product products { get; set; }
        public Category sategory { get; set; }
        public SubCategory subCategory { get; set; }
        public Image image { get; set; }
    }
}