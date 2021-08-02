using System;
using System.Diagnostics;
using System.Threading;
using System.Web.Http;
using Utility;

namespace NetAsyncPlayground.Controllers
{
    public class BlockController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            var result = new BlockHelper().GetRemoteData().Result;
            return $"result: {result}";
        }
    }
}