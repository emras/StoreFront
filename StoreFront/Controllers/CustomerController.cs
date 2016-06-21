using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using Store_Front.Models;
using System.Web.Security;
using System.Data.Entity.Validation;

namespace Store_Front.Controllers
{
    public class CustomerController : Controller
    {

        public ActionResult Index()
        {
            var model = new LoginViewModel();

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


        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                return View(model);
            }
            else
            {
                int id = Int32.Parse(HttpContext.User.Identity.Name);
                model.getUserName(id);

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {

            if (ModelState.IsValid)
            {
                var user = login.IsValid();
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserID.ToString(), false);
                    login.Name = user.UserName;

                    return View(login);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }
            }
            else
            {
                ModelState.AddModelError("", "Unable to log in");
            }

            return View(login);

        }



        [HttpGet]
        public ActionResult Logout()
        {
            var m = new LoginViewModel();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Customer", m);
        }

        [HttpGet]
        public ActionResult Register()
        {
            var model = new RegistrationViewModel();
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


        [HttpPost]
        public ActionResult Register(RegistrationViewModel register)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    using (var db = new StoreFrontDB())
                    {
                        if(db.User.Any(u => u.UserName == register.UserName))
                        {
                            ModelState.AddModelError("", "Username is already in use!");
                            return View(register);
                        }
                        var newUser = db.User.Create();
                        newUser.EmailAddress = register.EmailAddress;
                        newUser.UserName = register.UserName;
                        newUser.DateCreated = System.DateTime.Now;
                        newUser.CreatedBy = register.UserName;
                        db.User.Add(newUser);
                        db.SaveChanges();
                        newUser = db.User.Where(u => u.UserName == register.UserName).FirstOrDefault();
                        register.UserID = newUser.UserID;
                        newUser.Password = register.hashPassword();
                        db.SaveChanges();
                        FormsAuthentication.SetAuthCookie(newUser.UserID.ToString(), false);
                        register.Name = newUser.UserName;
                        return View(register);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "");
                }
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
            return View(register);
        }

        [HttpPost]
        public JsonResult IfUserExists(string UserName)
        {
            using (StoreFrontDB db = new StoreFrontDB())
            {
                return Json(!db.User.Any(u => u.UserName == UserName), JsonRequestBehavior.AllowGet);
            }

        }


    }
}

