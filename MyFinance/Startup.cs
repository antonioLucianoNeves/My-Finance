using System;
using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MyFinance
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {


            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
        // public void ConfigureServices(ServiceCollection services)
        // {
        //services.AddMvc();
        //           services.AddSession();
        //      }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDirectoryBrowser();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("Home/error");
            }
            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
