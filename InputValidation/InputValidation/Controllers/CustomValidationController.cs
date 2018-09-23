using InputValidation.Models;
using System.Web.Mvc;

namespace InputValidation.Controllers
{
    public class CustomValidationController : Controller
    {
        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Test(Person Input)
        {
            return View("Result");
        }

        public ActionResult TestV2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TestV2(Person Input)
        {
            return View("Result");
        }

    }
}