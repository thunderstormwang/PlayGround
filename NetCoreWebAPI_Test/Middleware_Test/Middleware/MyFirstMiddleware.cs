using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Middleware_Test.Middleware
{
    public class MyFirstMiddleware
    {
        private readonly RequestDelegate _next;

        public MyFirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"{nameof(MyFirstMiddleware)} in. \r\n");
            
            // Call the next delegate/middleware in the pipeline
            await _next(context);
            
            await context.Response.WriteAsync($"{nameof(MyFirstMiddleware)} out. \r\n");
        }
    }
}