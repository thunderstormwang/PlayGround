using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Middleware_Test.Middleware
{
    public class ResponseLogMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string responseContent;
            var originalBodyStream = context.Response.Body;
            using (var fakeResponseBody = new MemoryStream())
            {
                context.Response.Body = fakeResponseBody;

                // Call the next delegate/middleware in the pipeline
                await _next(context);

                fakeResponseBody.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(fakeResponseBody))
                {
                    responseContent = await reader.ReadToEndAsync();
                    fakeResponseBody.Seek(0, SeekOrigin.Begin);

                    await fakeResponseBody.CopyToAsync(originalBodyStream);
                }
            }
            Debug.WriteLine($"Response Body={responseContent}");
        }
    }
}