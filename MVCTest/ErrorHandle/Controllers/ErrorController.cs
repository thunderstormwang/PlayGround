using ErrorHandle.Models.ViewModels;
using System;
using System.Web.Mvc;

namespace ErrorHandle2.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult GeneralPartialView()
        {
            ErrorModel errorModel = new ErrorModel()
            {
                Exception = (Exception)TempData["Exception"]
            };

            return PartialView("_GeneralPartialView", errorModel);
        }
    }
}