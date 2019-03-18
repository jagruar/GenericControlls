using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortalCore.DataAccess;
using PortalCore.DataAccess.Internal;
using PortalCore.Interfaces.Internal;
using PortalCore.Interfaces.Internal.DataAccess;
using PortalCore.Interfaces.Portal;
using PortalCore.Models.ViewModels;
using PortalCore.Models.ViewModels.Vehicles;
using PortalCore.Services.Internal.Installation;
using PortalCore.Services.ViewModels.Buildings;
using PortalCore.Services.ViewModels.Vehicles;

namespace PortalCore.Admin
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddTransient<IViewModel, CarViewModel>();
            services.AddTransient<IViewModel, DriverViewModel>();
            services.AddTransient<IViewModel, TyreViewModel>();

            services.AddTransient<IViewModelService, CarViewModelService>();
            services.AddTransient<IViewModelService, HouseViewModelService>();

            services.AddTransient<IEntityBuilder, EntityBuilder>();
            services.AddTransient<IInstallService, InstallService>();
            services.AddTransient<IModelRepository, ModelRepository>();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
