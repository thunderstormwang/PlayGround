using Microsoft.AspNetCore.Http;
using Middleware_Test.Models;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Middleware_Test.Middleware
{
    public class MyExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        private static Logger _Logger = LogManager.GetCurrentClassLogger();

        public MyExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            _Logger.Error(ex.ToString());

            BaseResponse<string> result = new BaseResponse<string>
            {
                Status = false,
                ErrorMessage = ex.Message,
                Data = ex.ToString()
            };

            var jsonResponse = JsonConvert.SerializeObject(result);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
