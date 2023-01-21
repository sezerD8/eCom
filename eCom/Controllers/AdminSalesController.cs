using BusinnesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace eCom.Controllers
{
    public class AdminSalesController : Controller
    {
        // GET: AdminSales
        SalesRepository salesRepository = new SalesRepository();
        public ActionResult Index(SalesRepository salesRepository, int sayfa = 1)
        {
            return View(salesRepository.List().ToPagedList(sayfa, 5));
        }
        public ActionResult Delete(int id)
        {
            var deleteId = salesRepository.GetById(id);
            deleteId.Product.Stock += deleteId.Quantity;
            salesRepository.Delete(deleteId);
            return RedirectToAction("Index");
        }
    }
}