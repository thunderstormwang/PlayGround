﻿using InputValidation.Filter;
using InputValidation.Models;
using System.Web.Mvc;

namespace InputValidation.Controllers
{
    public class ValidateController : Controller
    {
        // GET: Validate
        public ActionResult SubmitByFormPost()
        {
            return View();
        }

        [HttpPost]
        [InputValidate]
        public ActionResult SubmitByFormPost(RequestBase input)
        {
            return RedirectToAction("Result");
        }

        public ActionResult Result()
        {
            return View();
        }

        public ActionResult SubmitByAjax()
        {
            return View();
        }

        [HttpPost]
        [InputValidate]
        [AjaxFilter(ReturnPartialView = true)]
        public ActionResult SubmitByAjaxBeginForm(RequestBase input)
        {
            return PartialView("_Result");
        }

        [HttpPost]
        [InputValidate]
        [AjaxFilter(ReturnPartialView = false)]
        public ActionResult SubmitByAjax(RequestBase input)
        {
            ResponseBase<string> successResponse = new ResponseBase<string>
            {
                Status = true,
                ErrorMessage = "You Passed The Validation"
            };
            return Json(successResponse);
        }
    }
}