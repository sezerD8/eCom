using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using EntityLayer.Entities;

namespace eCom.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        DataContext db = new DataContext();
        public ActionResult Index(int sayfa=1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciAdi = User.Identity.Name;
                var kullanici = db.Users.FirstOrDefault(x => x.Email == kullaniciAdi);
                var model = db.Sales.Where(x => x.UserId == kullanici.Id).ToList().ToPagedList(sayfa,5);
                return View(model);
            }
            return RedirectToAction("AuthError", "Error");
        }

        public ActionResult Buy(int id)
        {
            var model = db.Carts.FirstOrDefault(x => x.Id == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Buy2(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = db.Carts.FirstOrDefault(x => x.Id == id);
                    var satis = new Sales
                    {
                        UserId = model.Id,
                        Product = model.Product,
                        Quantity = model.Quantity,
                        Price = model.Price,
                        Date = model.Date
                    };
                    db.Carts.Remove(model);
                    db.Sales.Add(satis);
                    db.SaveChanges();
                    ViewBag.islem = "Satış başarıyla gerçekleşmiştir.";
                }
            }
            catch (Exception)
            {
                ViewBag.islem = "Satış işlemi başarısız.";

            }
            return View("islem");
        }

        public ActionResult BuyAll(decimal? tutar)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciAdi = User.Identity.Name;
                var kullanici = db.Users.FirstOrDefault(x => x.Email == kullaniciAdi);
                var model = db.Carts.Where(x => x.UserId == kullanici.Id).ToList();
                var kid = db.Carts.FirstOrDefault(x => x.UserId == kullanici.Id);
                if (model !=null )
                {
                    if (kid == null)
                    {
                        ViewBag.tutar = "Sepetinizde ürün bulunmamaktadır.";
                    }
                    else if (kid!=null)
                    {
                        tutar = db.Carts.Where(x => x.UserId == kid.UserId).Sum(x => x.Product.Price * x.Quantity);
                        ViewBag.tutar = tutar; 
                    }
                    return View(model);
                }
                return View();
            }
            return RedirectToAction("AuthError", "Error");
        }

        [HttpPost]
        public ActionResult BuyAll2()
        {
            var kullaniciAdi = User.Identity.Name;
            var kullanici = db.Users.FirstOrDefault(x => x.Email == kullaniciAdi);
            var model = db.Carts.Where(x => x.UserId == kullanici.Id).ToList();
            int row = 0;
            foreach (var item in model)
            {
                var satis = new Sales
                {
                    UserId = model[row].UserId,
                    ProductId = model[row].ProductId,
                    Quantity = model[row].Quantity,
                    Price = model[row].Price,
                    Date = DateTime.Now
                };
                db.Sales.Add(satis);
                db.SaveChanges();
                row++;
            }
            db.Carts.RemoveRange(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Cart");

        }
    }
}