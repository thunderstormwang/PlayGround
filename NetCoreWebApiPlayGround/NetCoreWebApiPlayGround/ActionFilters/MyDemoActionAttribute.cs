﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NetCoreWebApiPlayGround.ActionFilters
{
    /// <summary>
    /// 測試用, 當建構子不需要 DI 的用法
    /// </summary>
    public class MyDemoActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("My ActionFilter in action");
        }
    }
}