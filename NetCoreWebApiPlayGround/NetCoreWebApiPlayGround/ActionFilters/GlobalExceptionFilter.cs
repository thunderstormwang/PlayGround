using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NetCoreWebApiPlayGround.Models;

namespace NetCoreWebApiPlayGround.ActionFilters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger) => _logger = logger;
        
        public void OnException(ExceptionContext context)
        {
            var apiResult = new ApiResult(ResultCode.OtherException,
                context.Exception.Message);
            var exceptionType = context.Exception.GetType();
            context.ExceptionHandled = true;

            HttpStatusCode status;
            var exMessage = context.Exception.Message;
            if (exceptionType == typeof(CustomException))
            {
                var ex = context.Exception as CustomException;
                apiResult = new ApiResult(ex);
                status = HttpStatusCode.OK;
                if (string.IsNullOrWhiteSpace(exMessage))
                {
                    exMessage = $"({ex.CustomResultCode ?? string.Empty}) {ex.CustomMessage ?? string.Empty}";
                }

                _logger.LogInformation(exMessage);
            }
            else if (exceptionType == typeof(UnauthorizedAccessException))
            {
                status = HttpStatusCode.Unauthorized;
                _logger.LogWarning(context.Exception,
                    $"Unauthorized Access Exception Massage: {exMessage}");
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                _logger.LogError(context.Exception,
                    $"Ex massage: {exMessage}, StackTrace: {context.Exception.StackTrace}");
            }

            var response = context.HttpContext.Response;
            response.StatusCode = (int) status;
            response.ContentType = MediaTypeNames.Application.Json;
            response.WriteAsync(JsonSerializer.Serialize(apiResult));
        }
    }
}