using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCom.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult AuthError()
        {
            return View();
        }
        public ActionResult UserUpdateError()
        {
            return View();
        }
    }
}