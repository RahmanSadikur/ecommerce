using NMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NMS.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
    
        public ActionResult Index()
        {
            var context = new _Context();
            var company = context.Companies.ToList();
            return PartialView("Index", company);
        }
        [Route("About/{id}")]
        public ActionResult About(int id)
        {
            var context = new _Context();
            var company = context.Companies.ToList();
            return View(company);
        }
    }
}