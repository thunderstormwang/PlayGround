using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace NetCoreWebApiPlayGround.Middlewares
{
    public class RequestLogMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;
        
        public RequestLogMiddleware(RequestDelegate next, ILoggerFactory factory)
        {
            _next = next;
            _logger = factory.CreateLogger("RequestLog");
        }

        public async Task Invoke(HttpContext context)
        {
            var url = context.Request.GetDisplayUrl();
            if (url.EndsWith("home.html"))
            {
                await _next(context);
            }
            else
            {
                var requestBodyStream = new MemoryStream();
                var originalRequestBody = context.Request.Body;

                await context.Request.Body.CopyToAsync(requestBodyStream);
                requestBodyStream.Seek(0, SeekOrigin.Begin);

                string content;
                using (var requestBody = new StreamReader(requestBodyStream, Encoding.UTF8, true, 1024, true))
                {
                    var codePage = requestBody.CurrentEncoding.CodePage;
                    content = await requestBody.ReadToEndAsync();
                    _logger.LogInformation(
                        $"REQUEST METHOD: {context.Request.Method}, CodePage: {codePage}, REQUEST BODY: {content}, REQUEST URL: {url}");
                }

                requestBodyStream.Seek(0, SeekOrigin.Begin);
                context.Request.Body = requestBodyStream;
                context.Items.Add("Body", content);

                await _next(context);
                context.Request.Body = originalRequestBody;
            }
        }
    }
}