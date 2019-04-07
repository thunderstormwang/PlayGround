using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NetCoreWebAPI_Test.Models;

namespace NetCoreWebAPI_Test.Filters
{
    public class MyExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        protected readonly ILogger<MyExceptionHandlerAttribute> _Logger;

        public MyExceptionHandlerAttribute(ILogger<MyExceptionHandlerAttribute> logger)
        {
            _Logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            _Logger.LogError(context.Exception.ToString());

            BaseResponse<string> result = new BaseResponse<string>
            {
                Status = false,
                ErrorMessage = context.Exception.Message,
                Data = context.Exception.ToString()
            };
            context.Result = new JsonResult(result);
        }
    }
}