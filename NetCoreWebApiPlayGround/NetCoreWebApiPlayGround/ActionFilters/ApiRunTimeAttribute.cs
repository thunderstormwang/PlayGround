using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NetCoreWebApiPlayGround.ActionFilters
{
    public class ApiRunTimeAttribute : ActionFilterAttribute
    {
        private readonly Stopwatch _stopWatch = new Stopwatch();
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _stopWatch.Start();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string httpMethod = context.HttpContext.Request.Method;
            string controllerName = context.ActionDescriptor.RouteValues["controller"];
            string actionName = context.ActionDescriptor.RouteValues["action"];
            
            _stopWatch.Stop();
            var timeSpan = _stopWatch.Elapsed;
            _stopWatch.Reset();

            var timerLog = $"API Timer: {timeSpan.ToString()} from {httpMethod} /{controllerName}/{actionName}";
            Debug.WriteLine(timerLog);
            
            context.HttpContext.Response.Headers.Add("X-API-Timer", timeSpan.ToString());
        }
    }
}