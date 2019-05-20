using Microsoft.Extensions.Hosting;
using NetCoreWinService.Helpers;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWinService
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            InitialLogger();

            try
            {
                var hostBuilder = CreateHostBuilder();
                var isService = !(Debugger.IsAttached || args.Contains("--console"));

                //Log.Logger.Information($"Service Start, Env: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}, isService: {isService}");

                if (isService)
                {
                    await hostBuilder.RunAsServiceAsync();
                }
                else
                {
                    await hostBuilder.RunConsoleAsync();
                }
            }
            catch (Exception ex)
            {
                //Log.Logger.Error($"Service Start Error, {ex.ToString()}");
            }
        }

        private static IHostBuilder CreateHostBuilder() =>
            new HostBuilder()
            .ConfigureHostConfiguration(Startup.ConfigureHostConfiguration)
            .ConfigureServices(Startup.ConfigureServices);

        private static void InitialLogger()
        {
            // initial logger.....
        }
    }
}
