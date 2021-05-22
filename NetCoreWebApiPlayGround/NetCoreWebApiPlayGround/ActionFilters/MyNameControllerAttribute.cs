using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using NetCoreWebApiPlayGround.Enums;

namespace NetCoreWebApiPlayGround.ActionFilters
{
    /// <summary>
    /// 測試用, 與 TypeFilter 結合使用
    /// </summary>
    public class MyNameControllerAttribute : ActionFilterAttribute
    {
        private string Name { get; set; }
        private ActionFilterEnum ActionFilter { get; set; }

        public MyNameControllerAttribute(string name, ActionFilterEnum actionFilter)
        {
            Name = name;
            ActionFilter = actionFilter;
        }
        
        public override void OnActionExecuting(ActionExecutingContext context) =>
            Debug.WriteLine($"Name: {Name} in {ActionFilter}");
    }
}