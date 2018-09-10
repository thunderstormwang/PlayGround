using ErrorHandle2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ErrorHandle2.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult GeneralPartialView()
        {
            ViewModelError viewModelError = new ViewModelError()
            {
                Exception = (Exception)TempData["Exception"]
            };

            return PartialView("_GeneralPartialView", viewModelError);
        }
    }
}