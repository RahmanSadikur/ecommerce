using NMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NMS.Controllers
{
    public class GuestController : Controller
    {
        _Context Context;
        public GuestController()
        {
             Context = new _Context();
            
        }
        // GET: Guest
        public ActionResult Index()
        {

            var allItem = Context.Products.ToList();
            return View(allItem);
        }
        [Route("Getsubcat/{id}")]
        public ActionResult GetProduct(int id)
        {

            var products = Context.Products.Where(pd => pd.subCategoryId == id).ToList();
            return View(products);

        } 
        
    }
}