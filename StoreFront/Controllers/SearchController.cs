using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Store_Front.Models;
using System.Data.SqlClient;
using System.Data.Entity.Validation;

namespace Store_Front.Controllers
{
    public class SearchController : Controller
    {
        private StoreFrontDB db = new StoreFrontDB();

        // GET: Search
        [Authorize]
        public ActionResult Index()
        {
            var model = new SearchViewModel();

            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                return View(model);
            }
            else
            {
                int id = Int32.Parse(HttpContext.User.Identity.Name);
                using (var db = new StoreFrontDB())
                {
                    model.Name = db.User.Find(id).UserName;
                }

                return View(model);
            }
        }


        [Authorize]
        public ActionResult Search(SearchViewModel m)
        {
            int id = Int32.Parse(HttpContext.User.Identity.Name);
            m.getUserName(id);
            if (!String.IsNullOrEmpty(m.SearchText))
            {
                using (db)
                {
                    var products = db.Product.Where(p => p.ProductName.Contains(m.SearchText) || p.Description.Contains(m.SearchText));
                    m.Results = products.Select(p => new SearchResultsViewModel
                    {
                        ProductName = p.ProductName,
                        Price = p.Price ?? 999999,
                        ImageFile = p.ImageFile,
                        ProductID = p.ProductID
                    }).ToList();
                }
            }

            return View(m);
        }


        [HttpPost]
        public JsonResult AddToCart(string id)
        {
            int pid = Int32.Parse(id);
            try
            {
                ShoppingCartViewModel cartMdl = new ShoppingCartViewModel();
                cartMdl.UserID = Int32.Parse(HttpContext.User.Identity.Name);


                string message = cartMdl.AddShoppingCartItem(pid);


                var result = new { Success = "True", Message = message };
                return Json(result,JsonRequestBehavior.AllowGet);
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

    }
}

