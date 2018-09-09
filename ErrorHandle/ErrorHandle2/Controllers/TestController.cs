using ErrorHandle2.Models;
using System;
using System.Web.Mvc;

namespace ErrorHandle.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MakeException()
        {
            throw new NotImplementedException();
            return View();
        }

        public ActionResult MakeExceptionInAjax()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakeExceptionInAjax(RequestBase request)
        {
            throw new NotImplementedException();
            return Json(request);
        }

        [HttpPost]
        public ActionResult MakeExceptionInAjaxBeginForm(RequestBase request)
        {
            throw new NotImplementedException();
            return PartialView("_MakeExceptionInAjax");
        }
    }
}