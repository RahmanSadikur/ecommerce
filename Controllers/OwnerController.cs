using NMS.Data;
using NMS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NMS.Models;
using System.IO;

namespace NMS.Controllers
{
    public class OwnerController : Controller
    {
        public _Context contex;
        // GET: Owner
        public OwnerController()
        {
            contex = new _Context();

        }
        public ActionResult Index()
        {
            var product = contex.Products.ToList();
            var imageProduct = new ImageProduct();
            imageProduct.products = product;

            return View(imageProduct);
        }
        [HttpPost]
        public ActionResult UploadImage(ImageProduct imageProduct)
        {
            try
            {
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(imageProduct.File.InputStream))
                {
                    bytes = br.ReadBytes(imageProduct.File.ContentLength);
                }
                Image img = new Image();
                img.ImageTitle = Path.GetFileName(imageProduct.File.FileName);
                img.ImageData = bytes;
                img.productId = imageProduct.Images.productId;
                img.isPinned = false;
                contex.Images.Add(img);
                contex.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return Content(imageProduct.Images.productId+ex.Message);
            }

           
        }

        [Route("Owner/EditCategory/{id}")]
        public ActionResult EditCategory(int id)
        {
            var category = contex.Categories.FirstOrDefault(m => m.categoryId == id);
            if(category==null)
            {
                category = new Category();
            }

            return View("EditCategory",category);
        }
        [Route("Owner/EditCategory/{category}")]
        [HttpPost]
        public ActionResult EditCategory(Category Category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var category = contex.Categories.FirstOrDefault(m => m.categoryId == Category.categoryId);
                    if (category == null)
                    {
                        category = new Category();
                        contex.Categories.Add(category);
                        
                    }
                    category.categoryName = Category.categoryName;
                    contex.SaveChanges();
                    return RedirectToAction("CategoryList", "Owner");
                }

                return RedirectToAction("EditCategory", "Owner");


            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
            
        }
        [Route("Owner/EditSubCategory/{id}")]
        public ActionResult EditSubCategory(int id)
        {
            var categoryViewMOdel = new CategoryViewModel();
            var subcategory = contex.SubCategories.FirstOrDefault(m => m.subCategoryId == id);
            var category = contex.Categories.ToList();
            if(subcategory==null)
            {
                subcategory = new SubCategory();
            }
            categoryViewMOdel.subCategory = subcategory;
            categoryViewMOdel.Categories = category;

            return View("EditSubCategory", categoryViewMOdel);
        }
        
        [Route("Owner/EditSubCategory/{subCategory}")]
        [HttpPost]
        public ActionResult EditSubCategory(SubCategory subCategory)
        {

            try {
                if (ModelState.IsValid)
                {
                    var subcategory = contex.SubCategories.FirstOrDefault(m => m.subCategoryId ==subCategory.subCategoryId);

                    if (subcategory == null)
                    {
                        subcategory = new SubCategory();
                        contex.SubCategories.Add(subcategory);
                    }
                    subcategory.subCategoryName =subCategory.subCategoryName;
                    subcategory.categoryId = subCategory.categoryId;
                    contex.SaveChanges();






                    return RedirectToAction("SubCategoryList", "Owner");
                }
                return RedirectToAction("EditSubCategory", "Owner");
                
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
           
            
            

            
        }
        [Route("Owner/EditProduct/{id}")]
        public ActionResult EditProduct(int id)
        {
            var categoryViewMOdel = new CategoryViewModel();
            var product = contex.Products.FirstOrDefault(m => m.productId == id);
            var subCategory = contex.SubCategories.ToList();
            
            if (product == null)
            {
                product = new Product();
            }
            categoryViewMOdel.SubCategories = subCategory;
            categoryViewMOdel.product = product;

            return View("EditProduct", categoryViewMOdel);

           
        }
        [Route("Owner/EditProduct/{product}")]
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var products = contex.Products.FirstOrDefault(m => m.productId == product.productId);

                    if (products == null)
                    {
                        products = new Product();
                        contex.Products.Add(products);
                    }
                    products.productName = product.productName;
                    products.productDescription = product.productDescription;
                    products.productPrice = product.productPrice;
                    products.productStatus = product.productStatus;
                    products.isPinnedProduct = product.isPinnedProduct;
                    products.contact = product.contact;
                    products.color = product.color;
                  
                    products.subCategoryId = product.subCategoryId;
                    contex.SaveChanges();






                    return RedirectToAction("ProductList", "Owner");
                }
                return RedirectToAction("EditProduct", "Owner");

            }
            catch (Exception e)
            {
                return Content(e.Message);
            }


        }
        [Route("Owner/SubCategoryList")]
        public ActionResult SubCategoryList()
        {
            var sub = contex.SubCategories.ToList();
            var category = contex.Categories.ToList();
            var categoryViewMOdel = new CategoryViewModel();
            categoryViewMOdel.SubCategories = sub;
            categoryViewMOdel.Categories = category;

            return View("SubCategoryList", categoryViewMOdel);
        }
        [Route("Owner/UserList")]
        public ActionResult UserList()
        {
            var userViewModel = new UserViewModel();
            var users = contex.Users.Where(m=>m.userTypeId==2).ToList();
            var userCredentials = contex.UserCredentials.ToList();

            userViewModel.UserCredentials = userCredentials;

            userViewModel.Users = users;
            

            return View("UserList", userViewModel);
        }
        [Route("Owner/CustomerList")]
        public ActionResult CustomerList()
        {
            var userViewModel = new UserViewModel();
            var users = contex.Users.Where(m => m.userTypeId == 3).ToList();
            
                var userCredentials = contex.UserCredentials.ToList();

                userViewModel.UserCredentials = userCredentials;

            

            userViewModel.Users = users;


            return View("CustomerList", userViewModel);
        }
        [Route("Owner/UserCredentialList")]
        public ActionResult UserCredentialList()
        {
            var userViewModel = new UserViewModel();
            

            var userCredentials = contex.UserCredentials.ToList();

            userViewModel.UserCredentials = userCredentials;



           


            return View("UserCredentialList", userViewModel);
        }
        [Route("Owner/EditUserCredential/{id}")]
        public ActionResult EditUserCredential(int id)
        {
            var userViewModel = new UserViewModel();


            var userCredential = contex.UserCredentials.FirstOrDefault(m => m.userTypeId == id);
            if(userCredential==null)
            {
                userCredential = new UserCredential();
            }


            userViewModel.UserCredential = userCredential;






            return View("EditUserCredential", userViewModel);
        }
        [HttpPost]
        [Route("Owner/EditUserCredential/{userViewModel}")]
        public ActionResult EditUserCredential(UserViewModel userViewModel)
        {

            if (ModelState.IsValid)
            {
                var userCredential = contex.UserCredentials.FirstOrDefault(m => m.userTypeId == userViewModel.UserCredential.userTypeId);
                if (userCredential == null)
                {
                    userCredential = new UserCredential();
                    contex.UserCredentials.Add(userCredential);
                }
                userCredential.userTypeName = userViewModel.UserCredential.userTypeName;
                contex.SaveChanges();






                return RedirectToAction("UserCredentialList", "Owner");
            }
            return View("EditUserCredential", userViewModel);

        }
        [HttpPost]
        [Route("Owner/DeleteUserCredential/{id}")]
        public ActionResult DeleteUserCredential(int id)
        {

           
                var userCredential = contex.UserCredentials.FirstOrDefault(m => m.userTypeId == id);
               
                    contex.UserCredentials.Remove(userCredential);
              
                contex.SaveChanges();






                return RedirectToAction("UserCredentialList", "Owner");
           

        }
        [Route("Owner/CategoryList")]
        public ActionResult CategoryList()
        {

            var category = contex.Categories.ToList();
            return View("CategoryList",category);
        }
        [Route("Owner/ProductList")]
        public ActionResult ProductList()
        {
            var sub = contex.SubCategories.ToList();
            var product = contex.Products.ToList();
            var categoryViewMOdel = new CategoryViewModel();
            categoryViewMOdel.SubCategories = sub;
            categoryViewMOdel.Products = product;
            return View("ProductList", categoryViewMOdel);
        }
        [Route("Owner/Company")]
        public ActionResult Company()
        {

            return View();
        }
        [Route("Owner/Profile/{id}")]
        public ActionResult Profile(int id)
        {

            return View();
        }
    }
}