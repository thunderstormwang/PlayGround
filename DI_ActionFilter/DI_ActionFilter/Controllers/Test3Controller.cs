using System.Diagnostics;
using DI_ActionFilter.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DI_ActionFilter.Controllers
{
    public class Test3Controller : Controller
    {
        [HttpGet]
        [Route("Test3")]
        [TypeFilter(typeof(MyTypeFilter))]
        public string Test3()
        {
            Debug.WriteLine($"Hello World Test3");
            return "Hello World Test3";
        }
    }
}