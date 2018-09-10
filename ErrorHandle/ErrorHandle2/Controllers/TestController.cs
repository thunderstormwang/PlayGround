using ErrorHandle2.Filter;
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
        [AjaxFilter(ReturnPartialView = false)]
        public ActionResult MakeExceptionInAjax(RequestBase request)
        {
            throw new NotImplementedException();

            ResponseBase resonse = new ResponseBase()
            {
                Status = true,
                ErrorMessage = "成功"
            };
            return Json(resonse);
        }

        [AjaxFilter(ReturnPartialView = true)]
        [HttpPost]
        public ActionResult MakeExceptionInAjaxBeginForm(RequestBase request)
        {
            throw new NotImplementedException();
            return PartialView("_MakeExceptionInAjax");
        }
    }
}