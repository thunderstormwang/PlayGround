using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Utility;

namespace NetAsyncPlayground.Controllers
{
    public class MockConfigureAwaitController : ApiController
    {
        [HttpGet]
        public string TaskResult()
        {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            var result = new SomeConfigureAwaitHelper().GetRemoteData().Result;
            
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return $"result: {result}";
        }
        
        [HttpGet]
        public string GetResult()
        {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            var result = new SomeConfigureAwaitHelper().GetRemoteData().ConfigureAwait(false).GetAwaiter().GetResult();
            
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return $"result: {result}";
        }

        [HttpGet]
        public async Task<string> AsyncAwait()
        {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            var result = await new SomeConfigureAwaitHelper().GetRemoteData().ConfigureAwait(false);
            
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return $"result: {result}";
        }
    }
}