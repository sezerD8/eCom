using BusinnesLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCom.Controllers
{
    public class AdminGenderController : Controller
    {
        // GET: AdminGender
        GenderRepository genderRepository = new GenderRepository();
        [Authorize(Roles = ("Admin"))]
        public ActionResult Index()
        {
            return View(genderRepository.List());
        }

        [Authorize(Roles = ("Admin"))]
        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]

        [Authorize(Roles = ("Admin"))]
        public ActionResult Create(Gender p)
        {
            if (ModelState.IsValid)
            {
                genderRepository.Insert(p);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir hata oluştu.");
            return View();
        }

        [Authorize(Roles = ("Admin"))]
        public ActionResult Delete(int id)
        {
            var deleteId = genderRepository.GetById(id);
            genderRepository.Delete(deleteId);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = ("Admin"))]
        public ActionResult Update(int id)
        {
            var updateId = genderRepository.GetById(id);
            return View(updateId);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]

        [Authorize(Roles = ("Admin"))]
        public ActionResult Update(Gender p)
        {
            if (ModelState.IsValid)
            {
                var updateId = genderRepository.GetById(p.Id);
                updateId.Name = p.Name;
                genderRepository.Update(updateId);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir hata oluştu.");
            return View();
        }
    }
}