using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NMS.Models.ViewModel
{
    public class ProductImageNavViewModel
    {
        public List<Image> Images { get; set; }
       
        public Product products { get; set; }
    }
}