using ErrorHandle.Filter;
using System.Web.Mvc;

namespace ErrorHandle
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleErrorExceptionAtttibute());
        }
    }
}