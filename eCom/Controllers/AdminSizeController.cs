using BusinnesLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCom.Controllers
{
    public class AdminSizeController : Controller
    {
        // GET: AdminSize
        SizeRepository sizeRepository = new SizeRepository();
        [Authorize(Roles = ("Admin"))]
        public ActionResult Index()
        {
            return View(sizeRepository.List());
        }

        [Authorize(Roles = ("Admin"))]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = ("Admin"))]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Size p)
        {
            if (ModelState.IsValid)
            {
                sizeRepository.Insert(p);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir hata oluştu.");
            return View();
        }

        [Authorize(Roles = ("Admin"))]
        public ActionResult Delete(int id)
        {
            var deleteId = sizeRepository.GetById(id);
            sizeRepository.Delete(deleteId);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = ("Admin"))]
        public ActionResult Update(int id)
        {
            var updateId = sizeRepository.GetById(id);
            return View(updateId);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public ActionResult Update(Size p)
        {
            if (ModelState.IsValid)
            {
                var updateId = sizeRepository.GetById(p.Id);
                updateId.Name = p.Name;
                sizeRepository.Update(updateId);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir hata oluştu.");
            return View();
        }
    }
}