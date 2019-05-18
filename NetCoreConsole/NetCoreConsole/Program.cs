using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace NetCoreConsole
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", false);
            var configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(provider =>
                {
                    return configuration;
                })
                .AddSingleton<ICalculator, Calculator>()
                .BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<ICalculator>();

            Console.WriteLine(service.Add(5, 3));

            return 0;
        }
    }
}