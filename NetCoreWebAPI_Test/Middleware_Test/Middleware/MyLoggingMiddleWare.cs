using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using NLog;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Middleware_Test.Middleware
{
    public class MyLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        private static Logger _Logger = LogManager.GetCurrentClassLogger();

        public MyLoggingMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        // 測試結果會讓 Action 做 model binding 時失敗......

        public async Task Invoke(HttpContext context)
        {
            _Logger.Info(await FormatRequest(context.Request));

            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                _Logger.Info(await FormatResponse(context.Response));
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;
            request.EnableRewind();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body = body;

            return $"Begin {request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return $"End Response {text}";
        }
    }
}