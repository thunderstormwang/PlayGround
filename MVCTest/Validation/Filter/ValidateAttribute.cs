using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Validation.Filter
{
    public class ValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.Controller.ViewData.ModelState.IsValid)
            {
                // todo return error json

                var messages = filterContext.Controller.ViewData.ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage);

                RouteData routeData = new RouteData();
                routeData.Values.Add("controller", "Error");
                routeData.Values.Add("action", "InputErrorPartialView");
                filterContext.Controller.TempData["ErrorMessage"] = messages;

                filterContext.Result = new RedirectToRouteResult(routeData.Values);
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}