using BusinnesLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;

namespace eCom.Controllers
{
    public class AllProductsController : Controller
    {
        // GET: AllProducts
        // GET: Product
        ProductRepository productRepository = new ProductRepository();
        public ActionResult Index(int sayfa = 1)
        {
            return View(productRepository.List().ToPagedList(sayfa, 8));
        }
    }
}