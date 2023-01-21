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
    public class GenderController : Controller
    {
        // GET: Gender
        GenderRepository genderRepository = new GenderRepository();
        public PartialViewResult GenderListAllProduct()
        {
            return PartialView(genderRepository.List());
        }
        public ActionResult DetailsAllProduct(int id, int sayfa = 1)
        {
            var category = genderRepository.GenderDetails(id);
            return View(category.ToPagedList(sayfa, 6));
        }
    }
}