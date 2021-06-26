using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace NetCoreWebApiPlayGround
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseSerilog((hostContext,
                            loggerConfiguration) =>
                        {
                            switch (hostContext.HostingEnvironment.EnvironmentName)
                            {
                                case "Development":
                                    loggerConfiguration.MinimumLevel.Information()
                                        .WriteTo.LiterateConsole();
                                    break;
                                default:
                                    break;
                            }
                        })
                        .UseStartup<Startup>();
                });
    }
}