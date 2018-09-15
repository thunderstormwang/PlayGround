using ErrorHandle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ErrorHandle.Controllers
{
    public class TestController : Controller
    {
        public ActionResult MakeException()
        {
            // 出錯會顯示黃底畫面

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
            // 出錯會在畫面 alert 錯誤訊息

            throw new NotImplementedException();
            return Json(request);
        }

        [HttpPost]
        public ActionResult MakeExceptionInAjaxBeginForm(RequestBase request)
        {
            // 出錯會在畫面 alert 錯誤訊息

            throw new NotImplementedException();
            return PartialView("_MakeExceptionInAjax");
        }
    }
}