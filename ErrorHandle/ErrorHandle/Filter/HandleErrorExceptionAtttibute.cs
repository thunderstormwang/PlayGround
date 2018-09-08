using System.Net;
using System.Web.Mvc;

namespace ErrorHandle.Filter
{
    public class HandleErrorExceptionAtttibute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //var controllerName = filterContext.RouteData.Values["controller"];
            //var actionName = filterContext.RouteData.Values["action"];

            if (filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Exception != null)
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        filterContext.Exception.Message
                    }
                };
                filterContext.ExceptionHandled = true;
            }
            else
            {
                base.OnException(filterContext);
            }
        }

    }
}