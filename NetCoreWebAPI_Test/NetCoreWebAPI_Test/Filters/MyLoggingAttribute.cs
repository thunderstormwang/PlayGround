using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;

namespace NetCoreWebAPI_Test.Filters
{
    public class MyLoggingAttribute : ActionFilterAttribute
    {
        protected readonly ILogger<MyLoggingAttribute> _Logger;

        public MyLoggingAttribute(ILogger<MyLoggingAttribute> logger)
        {
            _Logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var requestBody = string.Empty;
            var request = context.HttpContext.Request;

            request.EnableRewind();
            request.Body.Seek(0, SeekOrigin.Begin);
            requestBody = new StreamReader(context.HttpContext.Request.Body).ReadToEnd();

            var logObj = new
            {
                Path = context.HttpContext.Request.Path,
                QueryString = context.HttpContext.Request.QueryString.Value,
                Body = requestBody,
                BindingModels = context.ActionArguments,
            };

            _Logger.LogInformation($"Begin {context.HttpContext.Request.Path}, {JsonConvert.SerializeObject(logObj)}");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var requestBody = string.Empty;
            var request = context.HttpContext.Request;

            request.EnableRewind();
            request.Body.Seek(0, SeekOrigin.Begin);
            requestBody = new StreamReader(context.HttpContext.Request.Body).ReadToEnd();

            var logObj = new
            {
                Path = context.HttpContext.Request.Path,
                QueryString = context.HttpContext.Request.QueryString.Value,
                Body = requestBody,
                Result = context.Result,
            };

            _Logger.LogInformation($"End {context.HttpContext.Request.Path}, {JsonConvert.SerializeObject(logObj)}");
        }
    }
}