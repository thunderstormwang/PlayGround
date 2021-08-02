using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var delayTask = AsyncTask();
            delayTask.Wait();
        }

        private static async Task AsyncTask()
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("async: starting");
            var delay = Task.Delay(5 * 1000);
            Console.WriteLine($"async: running for {sw.Elapsed.TotalSeconds} seconds");
            await delay;
            Console.WriteLine($"async: running for {sw.Elapsed.TotalSeconds} seconds");
            Console.WriteLine("async: done");
        }

        private static void SyncCode()
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("sync: starting");
            Thread.Sleep(5 * 1000);
            Console.WriteLine($"sync: running for {sw.Elapsed.TotalSeconds} seconds");
            Console.WriteLine("sync: done");
        }
    }
}