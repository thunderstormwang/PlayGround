using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Utility;

namespace NetAsyncPlayground.Controllers
{
    public class DeadlockController : ApiController
    {
        [HttpGet]
        public string TaskResult()
        {
            var result = 0;

            result = new DeadlockHelper().GetRemoteData().Result;
            return $"result: {result}";
        }
    }
}