using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Utility;

namespace NetAsyncPlayground.Controllers
{
    public class SomeConfigureAwaitController : ApiController
    {
        [HttpGet]
        public async Task<string> AsyncGet()
        {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            var result = await new SomeConfigureAwaitHelper().GetRemoteData();
            
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return $"result: {result}";
        }
        
        [HttpGet]
        public string Get()
        {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            // var result = new SomeConfigureAwaitHelper().GetRemoteData().Result;
            var result = new SomeConfigureAwaitHelper().GetRemoteData().ConfigureAwait(false).GetAwaiter().GetResult();
            
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return $"result: {result}";
        }
    }
}