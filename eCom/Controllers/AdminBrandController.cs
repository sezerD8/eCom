using BusinnesLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCom.Controllers
{
    public class AdminBrandController : Controller
    {
        // GET: AdminBrand

        BrandRepository brandRepository = new BrandRepository();
        [Authorize(Roles = ("Admin"))]
        public ActionResult Index()
            {
                return View(brandRepository.List());
            }

        [Authorize(Roles = ("Admin"))]
        public ActionResult Create()
            {
                return View();
            }

            [ValidateAntiForgeryToken]
            [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public ActionResult Create(Brand p)
            {
                if (ModelState.IsValid)
                {
                    brandRepository.Insert(p);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Bir hata oluştu.");
                return View();
            }
        [Authorize(Roles = ("Admin"))]
        public ActionResult Delete(int id)
            {
                var deleteId = brandRepository.GetById(id);
                brandRepository.Delete(deleteId);
                return RedirectToAction("Index");
            }

        [Authorize(Roles = ("Admin"))]
        public ActionResult Update(int id)
            {
                var updateId = brandRepository.GetById(id);
                return View(updateId);
            }

            [ValidateAntiForgeryToken]
            [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public ActionResult Update(Brand p)
            {
                if (ModelState.IsValid)
                {
                    var updateId = brandRepository.GetById(p.Id);
                    updateId.Name = p.Name;
                    brandRepository.Update(updateId);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Bir hata oluştu.");
                return View();
            }
        }
    }
