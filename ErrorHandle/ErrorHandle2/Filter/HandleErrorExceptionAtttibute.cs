using ErrorHandle2.Models;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;

namespace ErrorHandle2.Filter
{
    public class HandleErrorExceptionAtttibute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //var controllerName = filterContext.RouteData.Values["controller"];
            //var actionName = filterContext.RouteData.Values["action"];

            if (filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Exception != null)
            {
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;

                RouteData routeData = new RouteData();
                routeData.Values.Add("controller", "Error");
                routeData.Values.Add("action", "GeneralPartialView");
                filterContext.Controller.TempData["Exception"] = filterContext.Exception;

                filterContext.Result = new RedirectToRouteResult(routeData.Values);
                filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
            }
            else
            {
                base.OnException(filterContext);
            }
        }
    }
}