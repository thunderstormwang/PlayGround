using System;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using NetCoreWebApiPlayGround.ActionFilters;
using NetCoreWebApiPlayGround.Extensions;
using NetCoreWebApiPlayGround.Services;
using Newtonsoft.Json;

namespace NetCoreWebApiPlayGround
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck<EnvironmentCheck>("ENV");

            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<ICalculateService, CalculateService>();

            services.AddScoped<OtpValidationAttribute>();
            services.AddScoped<MyCacheActionAttribute>();
            services.AddScoped<MyCacheControllerAttribute>();

            services.AddControllers(options => { options.RegisterGlobalActionFilters(); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/health",
                new HealthCheckOptions
                {
                    ResponseWriter = MyCustomHealthCheckResponse
                });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseRequestLogMiddleware();
            app.UseResponseLogMiddleware();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private async Task MyCustomHealthCheckResponse(HttpContext context,
            HealthReport report)
        {
            var result = new
            {
                status = report.Status.ToString(),
                data = report.Entries.Select(e => new
                {
                    key = e.Key, 
                    description = e.Value.Description,
                    data = e.Value.Data,
                    status = Enum.GetName(typeof(HealthStatus), e.Value.Status)
                })
            };

            var json = JsonConvert.SerializeObject(result);
            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync(json);
        }
    }
}