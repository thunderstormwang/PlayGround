using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace InputValidation.Filters
{
    public class GetInput : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 方法1
            object obj = filterContext.ActionParameters["input"];
            string jsonString = JsonConvert.SerializeObject(obj);

            // 方法2
            string str2 = string.Empty;
            foreach (var item in filterContext.Controller.ControllerContext.RequestContext.HttpContext.Request.Form.AllKeys)
            {
                str2 += $"{item}={filterContext.Controller.ControllerContext.RequestContext.HttpContext.Request.Form[item]};"; 
            }
        }
    }
}