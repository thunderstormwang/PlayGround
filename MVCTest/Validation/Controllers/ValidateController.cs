﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Validation.Filter;
using Validation.Models;

namespace Validation.Controllers
{
    public class ValidateController : Controller
    {
        // GET: Validate
        public ActionResult SubmitByFormPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitByFormPost(RequestBase input)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage);

                return View(input);
            }

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
        [Validate]
        [AjaxFilter(ReturnPartialView = true)]
        public ActionResult SubmitByAjaxBeginForm(RequestBase input)
        {
            return PartialView("_Result");
        }

        [HttpPost]
        [Validate]
        [AjaxFilter(ReturnPartialView = false)]
        public ActionResult SubmitByAjax(RequestBase input)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage);

                ResponseBase<IEnumerable<string>> errorResponse = new ResponseBase<IEnumerable<string>>
                {
                    Status = false,
                    ErrorMessage = "You Shall Not Passe The Validation",
                    Data = messages
                };
                return Json(errorResponse);
            }

            ResponseBase<string> successResponse = new ResponseBase<string>
            {
                Status = true,
                ErrorMessage = "You Passed The Validation"
            };
            return Json(successResponse);
        }
    }
}