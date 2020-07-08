using NMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NMS.Models.ViewModel;

namespace NMS.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav

        public ActionResult NavMenu()
        {
            var context = new _Context();
            var categories = context.Categories.ToList();
            var subcategories = context.SubCategories.ToList();
            var CategoryViewModel = new CategoryViewModel();
            CategoryViewModel.Categories = categories;
            CategoryViewModel.SubCategories = subcategories;
            return PartialView("NavMenu", CategoryViewModel);
        }
        public ActionResult Footer()
        {
            var context = new _Context();
            var company = context.Companies.ToList();
          
            return PartialView("Footer", company);
        }

        [HttpPost]
        [Route("Nav/Autocomplete")]
        public ActionResult Autocomplete(string term)
        {
            var context = new _Context();
        
            var producs = context.Products.Where(pd => pd.productName.ToLower().Contains(term.ToLower()) || pd.productId.ToString().Contains(term)).ToList();
            
           
            return Json(producs, JsonRequestBehavior.AllowGet);
        }
       
        [Route("Nav/GetDetail/{id}")]
        public ActionResult GetDetail(int id)
        {
            var context = new _Context();
            var product = context.Products.Where(p => p.productId == id).FirstOrDefault();
            var productimg = new ProductImageViewModel();
            if (product != null)
            {
                var image = context.Images.Where(im => im.productId == product.productId).ToList();

                productimg.Images = image;
                productimg.products = product;
            }
           

        
            return View(productimg);
        }
    }
}