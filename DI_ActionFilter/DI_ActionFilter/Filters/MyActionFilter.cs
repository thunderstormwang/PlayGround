using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DI_ActionFilter.Filters
{
    public class MyActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine($"MyActionFilter");
        }
    }
}