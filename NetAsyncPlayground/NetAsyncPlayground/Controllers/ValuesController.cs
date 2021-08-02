using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Utility;

namespace NetAsyncPlayground.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        public string Test()
        {
            return $"Hello World";
        }

        [HttpGet]
        public string Get()
        {
            Debug.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            var result = new SomeHelper().GetRemoteData().Result;
            // var result = GetRemoteData().ConfigureAwait(false).GetAwaiter().GetResult();
            
            Debug.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return $"result: {result}";
        }
    }
}
