using System;
using System.Threading;
using System.Threading.Tasks;
using Utility;

namespace NetConsoleAsyncPlayground
{
    public class Program
    {
        public static async Task Main(string[] args)
        // public static void Main(string[] args)
        {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            // var result = new MockHelper().GetRemoteData().Result;
            // var result = new MockHelper().GetRemoteData().ConfigureAwait(false).GetAwaiter().GetResult();
            var result = await new MockHelper().GetRemoteData();
            
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"result: {result}");
            
            Console.WriteLine($"================================");
            
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            // var result02 = new SomeConfigureAwaitHelper().GetRemoteData().Result;
            // var result02 = new SomeConfigureAwaitHelper().GetRemoteData().ConfigureAwait(false).GetAwaiter().GetResult();
            var result02 = await new SomeConfigureAwaitHelper().GetRemoteData();
            
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"result: {result02}");
        }
    }
}