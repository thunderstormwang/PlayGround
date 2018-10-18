using Login_Test.Models;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Login_Test.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginRequest request)
        {
            if (request.PassWord == "111111")
            {
                UserData userData = new UserData()
                {
                    Name = request.Name,
                    Company = "Boyu"
                };

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    request.Name,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    true,
                    JsonConvert.SerializeObject(userData),
                    FormsAuthentication.FormsCookiePath);

                string encTicket = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                cookie.HttpOnly = true;

                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Test");
        }

        [Authorize]
        public ActionResult Test()
        {
            return View();
        }
    }
}