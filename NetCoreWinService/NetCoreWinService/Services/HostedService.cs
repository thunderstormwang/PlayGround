using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreWinService.Services
{
    public class HostedService : IHostedService
    {
        private Task executingTask;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(i);
                }
            }
            catch (Exception ex)
            {
                //_Logger.LogError($"HostedService StartAsync Error: {ex.ToString()}");
            }

            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (this.executingTask == null)
            {
                return;
            }

            await Task.WhenAny(this.executingTask, Task.Delay(-1, cancellationToken));
        }
    }
}