using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NMS.Data;
using NMS.Models;

namespace NMS.Controllers
{
    public class RegisterController : Controller
    {

        public _Context _context { get; set; }
        public RegisterController()
        {
            _context = new _Context();
        }
        // GET: Register

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult adduser( User user)
        {

            return View();
        }

    }
}