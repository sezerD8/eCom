using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Web;
using System.Web.Caching;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using static System.Collections.Specialized.BitVector32;

namespace eCom.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        DataContext db = new DataContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User data)
        {
            var bilgi = db.Users.FirstOrDefault(x => x.Email == data.Email && x.Password == data.Password);
            if (bilgi != null){
                FormsAuthentication.SetAuthCookie(bilgi.Email, false);
                Session["Mail"] = bilgi.Email.ToString();
                Session["Ad"] = bilgi.Name.ToString();
                Session["Soyad"] = bilgi.SurName.ToString();
                Session["userId"] = bilgi.Id.ToString();
                return RedirectToActionPermanent("Index", "Home");
            }
            ViewBag.hata = "Mail veya şifreniz hatalı.";
            return View(data);
        }

        [HttpPost]
        
        public ActionResult Register(User data)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(data);
                data.Role = "User";
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "Bir hata oluştu.");
            return View("Login", data);
        }

        public ActionResult LogOut()
        {
            Session.RemoveAll();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToActionPermanent("Login", "Account");
        }
    }
}