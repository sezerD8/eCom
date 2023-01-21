using BusinnesLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCom.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProductRepository productRepository = new ProductRepository();
        DataContext db = new DataContext();
        public PartialViewResult PopularProduct()
        {
            var products = productRepository.products();
            ViewBag.Products = products;
            return PartialView();
        }
        public ActionResult ProductDetails(int id)
        {
            var details = productRepository.GetById(id);
            var comment = db.Comments.Where(x => x.ProductId == id).ToList();
            ViewBag.yrm = comment;
            return View(details);
        }
        [HttpPost]
        public ActionResult Comment(Comment data)
        {
            if (User.Identity.IsAuthenticated)
            {
                db.Comments.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index","AllProducts");
            }
            return RedirectToAction("AuthError", "Error");
        }
    }
}