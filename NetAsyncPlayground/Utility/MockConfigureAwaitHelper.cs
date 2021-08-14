﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Utility
{
    public class SomeConfigureAwaitHelper
    {
        public async Task<int> GetRemoteData()
        {
            Console.WriteLine($"Before Task.Delay Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(2 * 1000).ConfigureAwait(false);
            var result = 32767;

            Console.WriteLine($"After Task.Delay Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            return result;
        }
    }
}