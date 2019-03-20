using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortalCore.DataAccess;
using PortalCore.Interfaces.Internal.DataAccess;
using PortalCore.Ioc;
using PortalCore.Portal.Mvc.FileProviders;

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

            ServiceConfiguration.ConfigurePageStore(services);

            services.AddDbContext<PagesContext>(
                options =>
                {
                    options.UseSqlServer(
                        Configuration.GetConnectionString("PortalCore_Pages"),
                        sqlServerOptions => sqlServerOptions.MigrationsAssembly("PortalCore.DataAccess"));
                });

            var tempServicePropvider = services.BuildServiceProvider();

            services.AddMvc();
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationFormats.Add("{0}" + RazorViewEngine.ViewExtension);
                options.FileProviders.Add(new DatabaseFileProvider(tempServicePropvider.GetService<IPageRepository>()));
            });

            ServiceConfiguration.ConfigureServices(services);
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
