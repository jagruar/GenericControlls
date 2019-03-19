using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortalCore.DataAccess;
using PortalCore.DataAccess.Internal;
using PortalCore.Interfaces.Internal;
using PortalCore.Interfaces.Internal.DataAccess;
using PortalCore.Interfaces.Portal;
using PortalCore.Models.Internal.Types;
using PortalCore.Models.Internal.Types.Identification;
using PortalCore.Portal.Mvc.FileProviders;
using PortalCore.Services.Internal.Pages;
using PortalCore.Services.ViewModels.Buildings;
using PortalCore.Services.ViewModels.Vehicles;
using System;
using System.Collections.Generic;

namespace PortalCore.Portal
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

            services.AddDbContext<PagesContext>(
                options =>
                {
                    options.UseSqlServer(
                        Configuration.GetConnectionString("PortalCore_Pages"),
                        sqlServerOptions => sqlServerOptions.MigrationsAssembly("PortalCore.DataAccess"));
                });


            services.AddTransient<IPageGenerator, PageGenerator>();
            services.AddTransient<IPageRepository, PageRepository>();
            services.AddTransient<IModelRepository, ModelRepository>();
            services.AddTransient<IControlFactory, ControlFactory>();

            services.AddTransient<CarViewModelService>();
            services.AddTransient<HouseViewModelService>();
            services.AddTransient<Func<ModelId, IViewModelService>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case (ModelId.Car):
                        return serviceProvider.GetService<CarViewModelService>();
                    case (ModelId.House):
                        return serviceProvider.GetService<HouseViewModelService>();
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
