using Microsoft.AspNetCore.Mvc;
using NetCoreWebApiPlayGround.ActionFilters;
using NetCoreWebApiPlayGround.Enums;

namespace NetCoreWebApiPlayGround.Controllers
{
    [TypeFilter(typeof(MyNameControllerAttribute), Arguments = new object[] {"MyNameController", ActionFilterEnum.Controller})]
    [ServiceFilter(typeof(MyCacheControllerAttribute))]
    [MyDemoController]
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : Controller
    {
        [TypeFilter(typeof(MyNameActionAttribute), Arguments = new object[] {"MyNameAction", ActionFilterEnum.Action})]
        [ServiceFilter(typeof(MyCacheActionAttribute))]
        [MyDemoAction]
        [HttpGet("Echo")]
        public string Echo()
        {
            return "Hello World";
        }
    }
}