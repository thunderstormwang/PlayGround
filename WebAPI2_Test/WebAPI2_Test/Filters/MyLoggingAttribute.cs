using Newtonsoft.Json;
using NLog;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebAPI2_Test.Filters
{
    public class MyLoggingAttribute : ActionFilterAttribute
    {
        private static Logger _Logger = LogManager.GetCurrentClassLogger();

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var logObj = new
            {
                RequestUri = actionExecutedContext.Request.RequestUri.AbsoluteUri,
                RouteValue = actionExecutedContext.ActionContext.RequestContext.RouteData.Values,
                QueryString = actionExecutedContext.ActionContext.Request.RequestUri.Query,
                RequestBody = GetRawRequest(actionExecutedContext.ActionContext),
                ModelBindingRequest = actionExecutedContext.ActionContext.ActionArguments,
                ResponseBody = actionExecutedContext.Response != null ? actionExecutedContext.Response.Content.ReadAsStringAsync().Result : string.Empty
            };

            _Logger.Info($"End {TrimChar(JsonConvert.SerializeObject(logObj))}");
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var logObj = new
            {
                RequestUri = actionContext.ControllerContext.Request.RequestUri.AbsolutePath,
                RouteValue = actionContext.RequestContext.RouteData.Values,
                QueryString = actionContext.ControllerContext.Request.RequestUri.Query,
                RequestBody = GetRawRequest(actionContext),
                ModelBindingRequest = actionContext.ActionArguments
            };

            _Logger.Info($"Begin {TrimChar(JsonConvert.SerializeObject(logObj))}");
        }

        private string GetRawRequest(HttpActionContext actionContext)
        {
            actionContext.Request.Content.ReadAsStreamAsync().Result.Seek(0, SeekOrigin.Begin);
            return actionContext.Request.Content.ReadAsStringAsync().Result;
        }

        private string TrimChar(string value)
        {
            return Regex.Replace(value, @"\t|\n", string.Empty);
        }
    }
}