using DataAccessLayer.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCom.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataContext db = new DataContext();
        [Authorize(Roles = ("Admin"))]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = ("Admin"))]
        public ActionResult Comment(int sayfa = 1)
        {
            return View(db.Comments.ToList().ToPagedList(sayfa,5));
        }
        [Authorize(Roles = ("Admin"))]
        public ActionResult Delete(int id)
        {
            var delete = db.Comments.Where(x => x.Id == id).FirstOrDefault();
            db.Comments.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Comment");
        }
    }
}