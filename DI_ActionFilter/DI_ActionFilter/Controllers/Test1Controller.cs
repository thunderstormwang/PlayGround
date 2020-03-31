using System.Diagnostics;
using DI_ActionFilter.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DI_ActionFilter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Test1Controller : ControllerBase
    {
        [HttpGet]
        [Route("Test")]
        [MyActionFilter]
        public string Test()
        {
            Debug.WriteLine($"Hello World Test");
            return "Hello World Test";
        }
    }
}