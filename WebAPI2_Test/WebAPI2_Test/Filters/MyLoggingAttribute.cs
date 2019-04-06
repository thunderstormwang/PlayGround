using Newtonsoft.Json;
using NLog;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebAPI2_Test.Filters
{
    public class MyLoggingAttribute : ActionFilterAttribute
    {
        private static Logger _Logger = LogManager.GetCurrentClassLogger();

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var logObj = new
            {
                RequestUri = actionContext.ControllerContext.Request.RequestUri.AbsolutePath,
                RequestBody = actionContext.Request.Content.ReadAsStringAsync().Result,
                ModelBindingRequest = actionContext.ActionArguments
            };

            _Logger.Info($"Begin {JsonConvert.SerializeObject(logObj)}");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var logObj = new
            {
                RequestUri = actionExecutedContext.Request.RequestUri.AbsoluteUri,
                RequestBody = actionExecutedContext.Request.Content.ReadAsStringAsync().Result,
                ModelBindingRequest = actionExecutedContext.ActionContext.ActionArguments,
                ResponseBody = actionExecutedContext.Response != null ? actionExecutedContext.Response.Content.ReadAsStringAsync().Result : string.Empty
            };

            _Logger.Info($"End {JsonConvert.SerializeObject(logObj)}");
        }
    }
}