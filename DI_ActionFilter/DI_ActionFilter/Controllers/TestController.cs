using System.Diagnostics;
using DI_ActionFilter.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DI_ActionFilter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("Test")]
        [MyActionFilter]
        public string Test()
        {
            Debug.WriteLine($"Hello World Test");
            return "Hello World Test";
        }
        
        [HttpGet]
        [Route("Test2")]
        [ServiceFilter(typeof(MyServiceFilter))]
        public string Test2()
        {
            Debug.WriteLine($"Hello World Test2");
            return "Hello World Test2";
        }
        
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