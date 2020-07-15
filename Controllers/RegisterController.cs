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
            try
            {
                var users = _context.Users.FirstOrDefault(u => u.userName == user.userName || u.userId == user.userId);
                if (users == null)
                {
                    users = new User();
                    _context.Users.Add(users);
                }
                users.userName = user.userName;
                users.password = user.password;
                users.phone = user.phone;
                users.email = user.email;
                users.address = user.address;
                users.description = "Customer";
                users.designation = "none";
                users.userTypeId = 3;
                _context.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("Index", "Register");
            }
          
        }

    }
}