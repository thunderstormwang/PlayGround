using ErrorHandle.Filter;
using System.Web.Mvc;

namespace ErrorHandle
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // 這裡記得用對應的 filter

            //filters.Add(new HandleErrorAttribute());
            //filters.Add(new HandleErrorExceptionAtttibute());
            filters.Add(new HandleErrorExceptionV2Atttibute());
        }
    }
}