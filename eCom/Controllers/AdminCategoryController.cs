using BusinnesLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCom.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryRepository categoryRepository = new CategoryRepository();

        [Authorize(Roles = ("Admin"))]
        public ActionResult Index()
        {
            return View(categoryRepository.List());
        }

        [Authorize(Roles = ("Admin"))]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = ("Admin"))]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Category p)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Insert(p);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir hata oluştu.");
            return View();
        }

        [Authorize(Roles = ("Admin"))]
        public ActionResult Delete(int id)
        {
            var deleteId = categoryRepository.GetById(id);
            categoryRepository.Delete(deleteId);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = ("Admin"))]
        public ActionResult Update(int id)
        {
            var updateId = categoryRepository.GetById(id);
            return View(updateId);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public ActionResult Update(Category p)
        {
            if (ModelState.IsValid)
            {
                var updateId = categoryRepository.GetById(p.Id);
                updateId.Name = p.Name;
                updateId.Description = p.Description;
                categoryRepository.Update(updateId);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir hata oluştu.");
            return View();
        }
    }
}