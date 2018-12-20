using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace WebAPI2_Test.Filters
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            HttpError err = new HttpError("Exception captured by WebApiExceptionFilter: " +
                context.Exception.GetBaseException().Message);
            var resp = context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);
            context.Response = resp;
        }
    }
}