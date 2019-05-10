using Newtonsoft.Json;
using NLog;
using System;
using System.IO;
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
                RequestBody = GetRawRequest(actionContext),
                ModelBindingRequest = actionContext.ActionArguments
            };

            _Logger.Info($"Begin {JsonConvert.SerializeObject(logObj)}");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var logObj = new
            {
                RequestUri = actionExecutedContext.Request.RequestUri.AbsoluteUri,
                RequestBody = GetRawRequest(actionExecutedContext.ActionContext),
                ModelBindingRequest = actionExecutedContext.ActionContext.ActionArguments,
                ResponseBody = actionExecutedContext.Response != null ? actionExecutedContext.Response.Content.ReadAsStringAsync().Result : string.Empty
            };

            _Logger.Info($"End {JsonConvert.SerializeObject(logObj)}");
        }

        private string GetRawRequest(HttpActionContext actionContext)
        {
            actionContext.Request.Content.ReadAsStreamAsync().Result.Seek(0, SeekOrigin.Begin);
            return actionContext.Request.Content.ReadAsStringAsync().Result;
        }
    }
}