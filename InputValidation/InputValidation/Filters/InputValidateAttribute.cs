using InputValidation.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace InputValidation.Filters
{
    public class InputValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var controllerName = filterContext.RouteData.Values["controller"];
            //var actionName = filterContext.RouteData.Values["action"];

            if (filterContext.Controller.ViewData.ModelState.IsValid)
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            #region 非 ajax 的 Model 驗證失敗處理方式

            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                // 我從這裡拿不到 model, 但回傳的畫面又可正常顯示, 不知原因....
                //var m = filterContext.Controller.ViewData.Model;

                filterContext.Result = new ViewResult
                {
                    ViewData = filterContext.Controller.ViewData,
                };

                return;
            }

            #endregion 非 ajax 的 Model 驗證失敗處理方式

            #region ajax 的 Model 驗證失敗處理方式

            bool isReturnPartialView = false;
            foreach (var method in filterContext.Controller.GetType().GetMethods())
            {
                if ((string)filterContext.RouteData.Values["action"] == method.Name)
                {
                    object[] CustomAttributes = method.GetCustomAttributes(typeof(AjaxFilterAttribute), true);
                    if (CustomAttributes != null && CustomAttributes.Length >= 1)
                    {
                        AjaxFilterAttribute attr = (AjaxFilterAttribute)CustomAttributes[0];
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

            #endregion ajax 的 Model 驗證失敗處理方式
        }
    }
}