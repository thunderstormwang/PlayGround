using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Validation.Models;

namespace Validation.Filter
{
    public class ValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 只處理 ajax request 的 Model 驗證
            if (!filterContext.HttpContext.Request.IsAjaxRequest() || filterContext.Controller.ViewData.ModelState.IsValid)
            {
                base.OnActionExecuting(filterContext);
            }

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

            var messages = filterContext.Controller.ViewData.ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage);

            if (isReturnPartialView)
            {
                // 如果是 ajax request 且 isReturnPartialView 為 true
                // 將錯誤用 partial view 傳回給前端

                RouteData routeData = new RouteData();
                routeData.Values.Add("controller", "Error");
                routeData.Values.Add("action", "InputErrorPartialView");
                filterContext.Controller.TempData["ErrorMessage"] = messages;

                filterContext.Result = new RedirectToRouteResult(routeData.Values);
            }
            else
            {
                // 如果是 ajax request 且 isReturnPartialView 為 false
                // 將錯誤用 json 回傳給前端

                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new ResponseBase<IEnumerable<string>>
                    {
                        Status = false,
                        ErrorMessage = "You Shall Not Passe The Validation",
                        Data = messages
                    }
                };
            }
        }
    }
}