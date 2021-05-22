using System.Threading;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebApiPlayGround.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet("Echo")]
        public string Echo()
        {
            Thread.Sleep(500);
            return "Hello World";
        }
    }
}