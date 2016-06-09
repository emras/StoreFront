using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Store_Front.Models;

namespace Store_Front.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ShoppingCartViewModel mdl = new ShoppingCartViewModel();
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            mdl.ShoppingCartItems = from p in db.spGetShoppingCartItems(mdl.UserID)
                                    select p;
            return View(mdl);
        }



        // GET: ShoppingCart/Create
        public ActionResult Create()
        {
            return View();
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
