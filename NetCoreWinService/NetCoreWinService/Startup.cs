using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreWinService.Services;

namespace NetCoreWinService
{
    public class Startup
    {
        public static void ConfigureHostConfiguration(IConfigurationBuilder configHost)
        {
            // set configuration...
        }

        public static void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            services.AddHostedService<HostedService>();
        }
    }
}