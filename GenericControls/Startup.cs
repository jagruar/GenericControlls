using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericControls.Data;
using GenericControls.Models.Internal;
using GenericControls.Services;
using GenericControls.Services.Repositories;
using GenericControls.Services.ViewEngine;
using GenericControls.Services.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GenericControls
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var connection = @"Server=(localdb)\mssqllocaldb;Database=GenericControls;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<Context>(options => options.UseSqlServer(connection));

            services.AddTransient<IPageGenerator, PageGenerator>();
            services.AddTransient<IPageRepository, PageRepository>();

            services.AddTransient<CarViewModelService>();
            services.AddTransient<PropertyViewModelService>();
            services.AddTransient<Func<ViewModelServiceType, IViewModelService>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case (ViewModelServiceType.Car):
                        return serviceProvider.GetService<CarViewModelService>();
                    case (ViewModelServiceType.Property):
                        return serviceProvider.GetService<PropertyViewModelService>();
                    default:
                        throw new KeyNotFoundException();
                }
            });

            var sp = services.BuildServiceProvider();

            services.AddMvc();
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationFormats.Add("{0}" + RazorViewEngine.ViewExtension);
                options.FileProviders.Add(new DatabaseFileProvider(sp.GetService<IPageRepository>()));
            });

                //SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                //.AddViewOptions(options =>
                //{
                //    options.ViewEngines.Clear();
                //    options.ViewEngines.Add(new CustomViewEngine(sp.GetService<IPageRepository>()));
                //});
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Pages}/{action=Index}/{id?}");
            });
        }
    }
}
