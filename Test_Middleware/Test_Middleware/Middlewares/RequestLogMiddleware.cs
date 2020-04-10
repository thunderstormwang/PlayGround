using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Test_Middleware.Middlewares
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var fakeRequestBody = new MemoryStream();
            var originalRequestBody = context.Request.Body;

            await context.Request.Body.CopyToAsync(fakeRequestBody);
            fakeRequestBody.Seek(0, SeekOrigin.Begin);

            string content;
            using (var requestBody = new StreamReader(fakeRequestBody, Encoding.UTF8,
                true, 1024, true))
            {
                content = await requestBody.ReadToEndAsync();
            }

            fakeRequestBody.Seek(0, SeekOrigin.Begin);
            context.Request.Body = fakeRequestBody;

            Debug.WriteLine($"Request Url: {context.Request.Path.ToString()}");
            Debug.WriteLine($"Request QueryString: {context.Request.QueryString.ToString()}");
            Debug.WriteLine($"Request Body: {content}");
            
            // Call the next delegate/middleware in the pipeline
            await _next(context);
            
            context.Request.Body = originalRequestBody;
        }
    }
}