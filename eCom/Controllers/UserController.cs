using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCom.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        DataContext db = new DataContext();
        public ActionResult Update()
        {
            if (User.Identity.IsAuthenticated)
            {
                var username = (string)Session["Mail"];
                var degerler = db.Users.FirstOrDefault(x => x.Email == username);
                return View(degerler);
            }
            return RedirectToAction("AuthError", "Error");
        }


        [HttpPost]
        public ActionResult Update(User p)
        {
                if (User.Identity.IsAuthenticated)
                {
                try
                {
                    var username = (string)Session["Mail"];
                    var user = db.Users.Where(x => x.Email == username).FirstOrDefault();
                    user.Name = p.Name;
                    user.SurName = p.SurName;
                    user.UserName = p.UserName;
                    user.Password = p.Password;
                    user.RePassword = p.RePassword;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {

                    return RedirectToAction("UserUpdateError", "Error");
                }
                }

                return RedirectToAction("AuthError", "Error");
        }                                                                                                             

    }
}