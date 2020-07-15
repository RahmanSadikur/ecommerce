using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NMS.Models.ViewModel
{
    public class ImageProduct
    {
        public Image Images { get; set; }
        public List< Product> products { get; set; }
       
        public HttpPostedFileBase File { get; set; }
    }
}