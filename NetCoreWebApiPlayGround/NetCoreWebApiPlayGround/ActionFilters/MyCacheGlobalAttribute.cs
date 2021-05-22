using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using NetCoreWebApiPlayGround.Services;

namespace NetCoreWebApiPlayGround.ActionFilters
{
    /// <summary>
    /// 測試用, 當建構子需要 DI 的用法, 與 ServiceFilter 結合使用
    /// </summary>
    public class MyCacheGlobalAttribute : ActionFilterAttribute
    {
        private readonly ICacheService _cacheService;

        public MyCacheGlobalAttribute(ICacheService cacheService) =>
            _cacheService = cacheService;
        
        public override void OnActionExecuting(ActionExecutingContext context) =>
            Debug.WriteLine($"MyCache {_cacheService.Get()} in global");
    }
}