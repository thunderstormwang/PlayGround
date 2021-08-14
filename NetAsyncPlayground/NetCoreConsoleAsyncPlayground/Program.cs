using System;
using System.Threading;
using System.Threading.Tasks;
using Utility;

namespace NetCoreConsoleAsyncPlayground
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var result = 0;
            
            Console.WriteLine($"Task.Result");
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            result = new MockHelper().GetRemoteData().Result;
            
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"result: {result}");
            Console.WriteLine($"================================");
            
            Console.WriteLine($"async/await");
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            result = await new MockHelper().GetRemoteData();
            
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"result: {result}");
            
            Console.WriteLine($"================================");
            
            Console.WriteLine($"ConfigureAwait(false) Task.Result");
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            result = new SomeConfigureAwaitHelper().GetRemoteData().Result;
            
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"result: {result}");
            
            Console.WriteLine($"================================");
            
            Console.WriteLine($"ConfigureAwait(false) async/await");
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            result = await new SomeConfigureAwaitHelper().GetRemoteData().ConfigureAwait(false);
            
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"result: {result}");
        }
    }
}