using BusinnesLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCom.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryRepository categoryRepository = new CategoryRepository();
        public PartialViewResult CatergoryList()
        {
            return PartialView (categoryRepository.List());
        }
        public PartialViewResult CatergoryListAllProduct()
        {
            return PartialView(categoryRepository.List());
        }

        public ActionResult Details(int id,int sayfa = 1)
        {
            var category = categoryRepository.CategoryDetails(id);
            return View(category.ToPagedList(sayfa, 6));
        }
        public ActionResult DetailsAllProduct(int id, int sayfa = 1)
        {
            var category = categoryRepository.CategoryDetails(id);
            return View(category.ToPagedList(sayfa, 6));
        }
    }
}