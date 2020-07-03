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
    }
}