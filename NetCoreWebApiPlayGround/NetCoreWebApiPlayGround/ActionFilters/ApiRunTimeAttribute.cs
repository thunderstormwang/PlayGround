using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace NetCoreWebApiPlayGround.ActionFilters
{
    /// <summary>
    /// 記錄 api 執行時間並回傳
    /// </summary>
    public class ApiRunTimeAttribute : ActionFilterAttribute
    {
        private readonly ILogger<ApiRunTimeAttribute> _logger;
        private readonly Stopwatch _stopWatch = new Stopwatch();

        public ApiRunTimeAttribute(ILogger<ApiRunTimeAttribute> logger) => _logger = logger;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _stopWatch.Start();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var httpMethod = context.HttpContext.Request.Method;
            var controllerName = context.ActionDescriptor.RouteValues["controller"];
            var actionName = context.ActionDescriptor.RouteValues["action"];

            _stopWatch.Stop();
            var timeSpan = _stopWatch.Elapsed;
            _stopWatch.Reset();

            var timerLog = $"API Timer: {timeSpan.ToString()} from {httpMethod} /{controllerName}/{actionName}";
            Debug.WriteLine(timerLog);
            _logger.LogInformation(timerLog);

            context.HttpContext.Response.Headers.Add("X-API-Timer",
                timeSpan.ToString());
        }
    }
}