using System.Collections.Generic;
using System.Web.Mvc;

namespace InputValidation.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult InputErrorPartialView()
        {
            IEnumerable<string> errorMessages = (IEnumerable<string>)TempData["ErrorMessage"];

            return PartialView("_InputError", errorMessages);
        }
    }
}