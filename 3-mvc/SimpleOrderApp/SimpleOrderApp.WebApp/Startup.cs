using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleOrderApp.Data;
using SimpleOrderApp.Data.Model;
using SimpleOrderApp.Domain;

namespace SimpleOrderApp.WebApp
{
    public class Startup
    {
        // this configuration object gets constructed from multiple sources of key-value pairs

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // teach ASP.NET Core about the dbcontext (so one can be created for each thing that needs it)
            services.AddDbContext<SimpleOrderContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("Sqlite")));

            // ^ if you get a NullReferenceException there, it's because you need to put this in
            // user secrets:
            //"ConnectionStrings": {
            //    "Sqlite": "Data Source=C:/revature/simpleorder.db"
            //}

            // "if anyone asks for an ILocationRepository, construct a LocationRepository"
            //services.AddScoped<ILocationRepository, LocationRepository>();

            // flexible... e.g.:
            if (Configuration["WhichRepository"] == "1")
            {
                services.AddScoped<ILocationRepository, LocationRepository>();
            }
            else
            {
                services.AddScoped<ILocationRepository, LocationRepository>();
            }

            //services.AddScoped<LocationRepository>();
            // (equivalent to:)
            //services.AddScoped<LocationRepository>(sp => new LocationRepository(sp.GetService<SimpleOrderContext>()));

            // three service lifetimes:
            // - singleton: one instance for the whole app lifetime
            // - scoped: one instance per HTTP request cycle, shared by anything within that one request's scope
            //      (default for the dbcontext)
            // - transient: a new instance for every time a different object needs one

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
