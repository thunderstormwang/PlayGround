using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace NetCoreAsyncPlayground.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SomeConfigureAwaitController : ControllerBase
    {
        [HttpGet]
        [Route("AsyncGet")]
        public async Task<string> AsyncGet()
        {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            var result = await new SomeConfigureAwaitHelper().GetRemoteData();

            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return $"result: {result}";
        }

        [HttpGet]
        [Route("Get")]
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