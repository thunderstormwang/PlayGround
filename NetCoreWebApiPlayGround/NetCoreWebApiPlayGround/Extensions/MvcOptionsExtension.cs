using Microsoft.AspNetCore.Mvc;
using NetCoreWebApiPlayGround.ActionFilters;

namespace NetCoreWebApiPlayGround.Extensions
{
    public static class MvcOptionsExtension
    {
        public static void RegisterGlobalActionFilters(this MvcOptions options)
        {
            options.Filters.Add<MyCacheGlobalAttribute>();
            options.Filters.Add<MyDemoGlobalAttribute>();
            options.Filters.Add<ApiRunTimeAttribute>();
            options.Filters.Add<UnifiedResultAttribute>();
            options.Filters.Add<GlobalExceptionFilter>();
        }
    }
}