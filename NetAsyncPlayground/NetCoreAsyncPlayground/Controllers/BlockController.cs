using Microsoft.AspNetCore.Mvc;
using Utility;

namespace NetCoreAsyncPlayground.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlockController : ControllerBase
    {
        [HttpGet]
        [Route("Get")]
        public string Get()
        {
            var result = new BlockHelper().GetRemoteData().Result;
            return $"result: {result}";
        }
    }
}