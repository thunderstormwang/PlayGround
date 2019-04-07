using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCoreWebAPI_Test.Filters;

namespace NetCoreWebAPI_Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MyExceptionHandlerAttribute>();
            services.AddScoped<MyLoggingAttribute>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                // 關閉 ApiController 的驗證功能
                options.SuppressModelStateInvalidFilter = true;
            })
            .AddMvc(config =>
            {
                // 將 filter 註冊成 service, 讓它可以被注入
                config.Filters.AddService(typeof(MyExceptionHandlerAttribute));
                config.Filters.AddService(typeof(MyLoggingAttribute));
                // 若該 filter 不用被注入, 用這這種方式即可註冊成全域
                config.Filters.Add(new MyValidationAttribute());
            })            
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
