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
    public class SearchController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();
        public SearchViewModel mdl = new SearchViewModel();
        // GET: Search
        public ActionResult Index()
        {
            return View(mdl);

        }


        public ActionResult Search(string sString)
        {
            if (!String.IsNullOrEmpty(sString))
            {
                mdl.Products = from p in db.spSearchProducts(sString)
                               select p;
            }

            return View(mdl);
        }

        [HttpPost]
        public string RegisterUser()
        {
            return " was successfully registered.";
        }

        [HttpPost]
        public void AddToCart(int? id)
        {
            int cartID = getShoppingCart(mdl.UserID);

            if (cartID >-1)
            {
                db.spAddShoppingCartItem(id, cartID);
            }

            return;
        }

        public int getShoppingCart(int UserId)
        {
            int? cart = (from s in db.spGetShoppingCart(UserId)
                        select s).First().ShoppingCartID;

            if (cart != null)
            {
                return cart.Value;
            }else
            {
                return -1;
            }

        }

        // GET: Search/Create
        public ActionResult Create()
        {
            return View();
        }




        // POST: Search/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,SearchViewModelId,UserName")] SearchViewModel searchViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(searchViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(searchViewModel);
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

