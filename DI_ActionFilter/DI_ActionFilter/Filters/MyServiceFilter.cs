using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DI_ActionFilter.Filters
{
    public class MyServiceFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine($"MyServiceFilter");
        }
    }
}