using ErrorHandle.Filter;
using ErrorHandle.Models;
using System;
using System.Web.Mvc;

namespace ErrorHandle.Controllers
{
    public class TestV2Controller : Controller
    {
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
            // 出錯會在畫面 alert 錯誤訊息

            throw new NotImplementedException();

            ResponseBase resonse = new ResponseBase()
            {
                Status = true,
                ErrorMessage = "成功"
            };
            return Json(resonse);
        }

        [HttpPost]
        [AjaxFilter(ReturnPartialView = true)]
        public ActionResult MakeExceptionInAjaxBeginForm(RequestBase request)
        {
            // 將錯誤用 partial view 傳回給前端

            throw new NotImplementedException();
            return PartialView("_MakeExceptionInAjax");
        }
    }
}