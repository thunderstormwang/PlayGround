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
                bool isReturnPartialView = false;
                foreach (var method in filterContext.Controller.GetType().GetMethods())
                {
                    if ((string)filterContext.RouteData.Values["action"] == method.Name)
                    {
                        object[] CustomAttributes = method.GetCustomAttributes(typeof(AjaxFilter), true);
                        if (CustomAttributes != null && CustomAttributes.Length >= 1)
                        {
                            AjaxFilter attr = (AjaxFilter)CustomAttributes[0];
                            isReturnPartialView = attr.ReturnPartialView;
                            break;
                        }
                    }
                }

                if (isReturnPartialView)
                {
                    RouteData routeData = new RouteData();
                    routeData.Values.Add("controller", "Error");
                    routeData.Values.Add("action", "GeneralPartialView");
                    filterContext.Controller.TempData["Exception"] = filterContext.Exception;

                    filterContext.Result = new RedirectToRouteResult(routeData.Values);
                }
                else
                {
                    filterContext.Result = new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new ResponseBase()
                        {
                            Status = false,
                            ErrorMessage = filterContext.Exception.Message
                        }
                    };
                }

                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                filterContext.ExceptionHandled = true;
            }
            else
            {
                base.OnException(filterContext);
            }
        }
    }
}