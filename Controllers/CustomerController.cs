using NMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NMS.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public CustomerController()
        {
           var Context = new _Context();
        }
        public ActionResult Index()
        {

            return View();
        }
    }
}