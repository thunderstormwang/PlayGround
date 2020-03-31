using System.Diagnostics;
using DI_ActionFilter.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DI_ActionFilter.Controllers
{
    public class Test2Controller : Controller
    {
        [HttpGet]
        [Route("Test2")]
        [ServiceFilter(typeof(MyServiceFilter))]
        public string Test2()
        {
            Debug.WriteLine($"Hello World Test2");
            return "Hello World Test2";
        }
    }
}