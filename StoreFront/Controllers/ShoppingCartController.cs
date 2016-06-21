using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Store_Front.Models;
using System.Data.Entity.Validation;
using Microsoft.AspNet.Identity;

namespace Store_Front.Controllers
{
    public class ShoppingCartController : Controller
    {

        private StoreFrontDB db = new StoreFrontDB();

        // GET: ShoppingCart
        [Authorize]
        public ActionResult Index()
        {
            ShoppingCartViewModel mdl = new ShoppingCartViewModel();
            mdl.UserID = Int32.Parse(HttpContext.User.Identity.Name);
            mdl.getUserName(mdl.UserID);
            mdl.getCart();
            mdl.getProducts();
            mdl.getCartCount();

            return View(mdl);

        }

        [ChildActionOnly]
        public ActionResult CartSize(CustomerBaseViewModel mdl)
        {

            ShoppingCartViewModel model = new ShoppingCartViewModel
            {
                Name = mdl.Name
            };
            using (var db = new StoreFrontDB())
            {
                model.UserID = db.User.Where(u => u.UserName == mdl.Name).FirstOrDefault().UserID;
            }
            int cartID = model.getCart();
            model.getProducts();
            model.getCartCount();

            return PartialView(model);
        }

        [HttpPost]
        public JsonResult UpdateCart(int productId, int quantity)
        {
            try
            {
                ShoppingCartViewModel mdl = new ShoppingCartViewModel();
                mdl.UserID = Int32.Parse(HttpContext.User.Identity.Name);
                mdl.getUserName(mdl.UserID);
                if (quantity < 0)
                {
                    mdl.Message = "Quantity must be a positive number.";
                    var r = new { Success = "False", Message = mdl.Message };
                    return Json(r, JsonRequestBehavior.AllowGet);
                }

                int cartID = mdl.getCart();

                var product = (from p in db.ShoppingCartProduct
                               where p.ProductID == productId && p.ShoppingCartID == cartID
                               select p).Single();

                if (product.Quantity != quantity)
                {
                    if (quantity == 0)
                    {
                        db.ShoppingCartProduct.Remove(product);
                        db.SaveChanges();
                    }
                    else
                    {
                        product.Quantity = quantity;
                        product.DateModified = System.DateTime.Now;
                        product.ModifiedBy = mdl.Name;
                        product.Price = db.Product.Find(productId).Price * quantity;
                    }

                    var cart = db.ShoppingCart.Find(cartID);
                    cart.ModifiedBy = mdl.Name;
                    cart.DateModified = System.DateTime.Now;
                    db.SaveChanges();
                }

                var result = new { Success = "True", Message = "Cart Updated" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                }
                throw;
            }
        }

        [HttpPost]
        public ActionResult Remove(int pid)
        {

            ShoppingCartViewModel mdl = new ShoppingCartViewModel();
            mdl.UserID = Int32.Parse(HttpContext.User.Identity.Name);
            int cartID = mdl.getCart();
            mdl.getProducts();
            mdl.getCart();
            try
            {
                string rmessage = mdl.removeProduct(pid);
                db.SaveChanges();
                var result = new ShoppingCartViewModel
                {
                    Message = rmessage,
                    deleteID = pid,
                    CartCount = mdl.getCartCount()
                };
                return Json(result);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
