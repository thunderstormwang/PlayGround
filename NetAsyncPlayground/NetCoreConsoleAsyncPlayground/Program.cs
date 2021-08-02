using System;
using System.Threading;
using System.Threading.Tasks;
using Utility;

namespace NetCoreConsoleAsyncPlayground
{
    public class Program
    {
        // static void Main(string[] args)
        // {
        //     Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        //     var result = new BlockHelper().GetRemoteData().Result;
        //     
        //     Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        //     Console.WriteLine($"result: {result}");
        // }
        
        public static async Task Main(string[] args)
        // public static void Main(string[] args)
        {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            // var result = new SomeHelper().GetRemoteData().Result;
            // var result = new SomeHelper().GetRemoteData().ConfigureAwait(false).GetAwaiter().GetResult();
            var result = await new SomeHelper().GetRemoteData();
            
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