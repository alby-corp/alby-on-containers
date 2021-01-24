using System.Reflection;
using IdentityServer.Extensions;
using IdentityServer.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var hulkConnection = Configuration.GetConnectionString("Hulk");
            var sunshineConnection = Configuration.GetConnectionString("Sunshine");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentity(hulkConnection, migrationsAssembly);
            services.AddIdentityServer(hulkConnection, migrationsAssembly, Configuration.GetValue("EnableDevspaces", false));
            services.AddHealthCheck(sunshineConnection);

            services.AddOptions(Configuration);

            services.AddMediatR(typeof(Startup));
            services.AddMassTransit(Configuration);

            services.AddTransient<IRedirectService, RedirectService>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseIdentityServer();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapHealthChecks();
            });
        }
    }
}