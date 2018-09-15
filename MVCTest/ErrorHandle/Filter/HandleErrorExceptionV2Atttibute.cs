using ErrorHandle.Models;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;

namespace ErrorHandle.Filter
{
    public class HandleErrorExceptionV2Atttibute : HandleErrorAttribute
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
                    // 如果是 ajax request 且 isReturnPartialView 為 true
                    // 將錯誤用 partial view 傳回給前端

                    RouteData routeData = new RouteData();
                    routeData.Values.Add("controller", "Error");
                    routeData.Values.Add("action", "GeneralPartialView");
                    filterContext.Controller.TempData["Exception"] = filterContext.Exception;

                    filterContext.Result = new RedirectToRouteResult(routeData.Values);
                }
                else
                {
                    // 如果是 ajax request 且 isReturnPartialView 為 false
                    // 將錯誤用 json 回傳給前端

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