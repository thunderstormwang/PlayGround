using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace NetCoreAsyncPlayground.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MockController : ControllerBase
    {
        [HttpGet]
        [Route("TaskResult")]
        public string TaskResult()
        {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            var result = new MockHelper().GetRemoteData().Result;

            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return $"result: {result}";
        }
        
        [HttpGet]
        [Route("GetResult")]
        public string GetResult()
        {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            var result = new MockHelper().GetRemoteData().ConfigureAwait(false).GetAwaiter().GetResult();

            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return $"result: {result}";
        }

        [HttpGet]
        [Route("AsyncAwait")]
        public async Task<string> AsyncAwait()
        {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            var result = await new MockHelper().GetRemoteData();

            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return $"result: {result}";
        }
    }
}