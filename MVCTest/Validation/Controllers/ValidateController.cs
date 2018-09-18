using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validation.Models;

namespace Validation.Controllers
{
    public class ValidateController : Controller
    {
        // GET: Validate
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(RequestBase input)
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
    }
}