using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreWebApiPlayGround.ActionFilters;
using NetCoreWebApiPlayGround.Extensions;
using NetCoreWebApiPlayGround.Services;

namespace NetCoreWebApiPlayGround
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseRequestLogMiddleware();
            app.UseResponseLogMiddleware();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}