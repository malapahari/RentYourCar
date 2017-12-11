using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentYourCar.DAL;
using RentYourCar.Models;

namespace RentYourCar.Controllers
{
    public class UserController : Controller
    {

        RentYourCarDBContext db = new RentYourCarDBContext();

        public ActionResult Index()
        {
            return View ("Login");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        public ActionResult LogOut()
        {            
            this.Session["user"] = null;
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            try {

                var user = db.Users
                             .Where(i => i.EmailAddress == login.Email && i.Password == login.Password)
                             .FirstOrDefault();
                

                if(user.UserId > 0){
                    ViewData["username"] = user.EmailAddress;
                    Session["user"] = user;

                    return RedirectToAction("MyCars","Car");
                }
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            try {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            } catch(Exception ex){                
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(user);
        }


    }
}