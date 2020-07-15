using NMS.Data;
using NMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NMS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult logout()
        {
            
                Session.Abandon();
                return RedirectToAction("Index", "Guest");

            
            
        }

        
        public ActionResult Verify(User user)
        {
            var contex = new _Context();
            var users = contex.Users.FirstOrDefault(u => u.userName == user.userName);
            if(users!=null)
            {
                Session["userName"] = users.userName;
                Session["userId"] = users.userId;
                Session["userTypeId"] = users.userTypeId;
                if (users.userTypeId==1)
                {
                    return RedirectToAction("Index", "Owner");
                }
                else if(users.userTypeId == 1){
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index","Customer");
                }
            }
            else
            {
                return Redirect("Index");
            }
           
        }
    }
}