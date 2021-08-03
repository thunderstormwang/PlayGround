using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Utility;

namespace NetAsyncPlayground.Controllers
{
    public class MockController : ApiController
    {
        [HttpGet]
        public string TaskResult()
        {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            var result = new MockHelper().GetRemoteData().Result;
            
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return $"result: {result}";
        }
        
        [HttpGet]
        public string GetResult()
        {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            var result = new MockHelper().GetRemoteData().ConfigureAwait(false).GetAwaiter().GetResult();
            
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return $"result: {result}";
        }
        
        [HttpGet]
        public async Task<string> AsyncAwait()
        {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            var result = await new MockHelper().GetRemoteData();
            
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return $"result: {result}";
        }
    }
}