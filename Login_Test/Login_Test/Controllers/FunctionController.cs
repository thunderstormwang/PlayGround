using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_Test.Controllers
{
    public class FunctionController : Controller
    {
        // GET: Function
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}