using Microsoft.AspNetCore.Builder;
using NetCoreWebApiPlayGround.Middlewares;

namespace NetCoreWebApiPlayGround.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseRequestLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLogMiddleware>();
        }

        public static IApplicationBuilder UseResponseLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseLogMiddleware>();
        }
    }
}