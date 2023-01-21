using BusinnesLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace eCom.Controllers
{
    public class AdminProductController : Controller
    {
        // GET: AdminProduct
        ProductRepository productRepository = new ProductRepository();
        DataContext db = new DataContext();
        [Authorize(Roles = ("Admin"))]
        public ActionResult Index(ProductRepository productRepository, int sayfa = 1)
        {
            return View(productRepository.List().ToPagedList(sayfa,5));
        }

        [Authorize(Roles = ("Admin"))]
        public ActionResult Create()
        {
            List<SelectListItem> kategori = (from i in db.Categories.ToList() 
                select new SelectListItem 
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }).ToList();
            ViewBag.ktgr = kategori;

            List<SelectListItem> marka = (from i in db.Brands.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Name,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.mrk = marka;

            List<SelectListItem> beden = (from i in db.Sizes.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Name,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.bdn = beden;

            List<SelectListItem> cinsiyet = (from i in db.Genders.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.Name,
                                              Value = i.Id.ToString()
                                          }).ToList();
            ViewBag.cnsyt = cinsiyet;

            return View();
        }

        [Authorize(Roles = ("Admin"))]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Product p,HttpPostedFileBase File)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bir hata oluştu.");
            }
            string path = Path.Combine("~/Content/img/" + File.FileName);
            File.SaveAs(Server.MapPath(path));
            p.Image = File.FileName.ToString();
            productRepository.Insert(p);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = ("Admin"))]
        public ActionResult Delete(int id)
        {
            var deleteId = productRepository.GetById(id);
            productRepository.Delete(deleteId);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = ("Admin"))]
        public ActionResult Update(int id)
        {
            List<SelectListItem> kategori = (from i in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.ktgr = kategori;

            List<SelectListItem> marka = (from i in db.Brands.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Name,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.mrk = marka;

            List<SelectListItem> beden = (from i in db.Sizes.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.Name,
                                              Value = i.Id.ToString()
                                          }).ToList();
            ViewBag.bdn = beden;

            List<SelectListItem> cinsiyet = (from i in db.Genders.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.Name,
                                              Value = i.Id.ToString()
                                          }).ToList();
            ViewBag.cnsyt = cinsiyet;

            var updateId = productRepository.GetById(id);
            return View(updateId);
        }

        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        public ActionResult Update(Product p, HttpPostedFileBase File)
        {
            var updateId = productRepository.GetById(p.Id);
            if (!ModelState.IsValid)
            {
                if (File == null)
                {
                    updateId = productRepository.GetById(p.Id);
                    updateId.Name = p.Name;
                    updateId.Description = p.Description;
                    updateId.Price = p.Price;
                    updateId.Stock = p.Stock;
                    updateId.Popular = p.Popular;
                    updateId.isApproved = p.isApproved;
                    updateId.CategoryId = p.CategoryId;
                    updateId.BrandId = p.BrandId;
                    updateId.SizeId = p.SizeId;
                    productRepository.Update(p); 
                    return RedirectToAction("Index");
                }
                else
                {
                    updateId.Description = p.Description;
                    updateId.Name = p.Name;
                    updateId.Image = File.FileName.ToString();
                    updateId.Price = p.Price;
                    updateId.Stock = p.Stock;
                    updateId.Popular = p.Popular;
                    updateId.isApproved = p.isApproved;
                    updateId.CategoryId = p.CategoryId;
                    updateId.BrandId = p.BrandId;
                    updateId.SizeId = p.SizeId;
                    productRepository.Update(updateId);
                    return RedirectToAction("Index");
                }
            }
            return View(updateId);

        }
    }
}