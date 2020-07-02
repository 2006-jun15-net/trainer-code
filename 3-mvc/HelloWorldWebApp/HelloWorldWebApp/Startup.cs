using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloWorldWebApp
{
    // a controller will take responsibility for handling some subset of requests to the app
    // (usually based upon the path in the URL.)
    // e.g. if I want o user to be able to access pages like /account/myprofile, /account/browse
    // /catalog/purchase, maybe i'd have an AccountController and a CatalogController.



    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // teach asp.net about controllers and views
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // here we plug in "middleware" in some order to the request processing pipeline of ASP.NET Core

            // each of these "app.UseSomething" lines plugs in some middleware
            // in order, which will have a chance ot look at and maybe respond to every incoming HTTP request
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // C# supports anonymous types like new { prop = "a", prop2 = 1 }
                // we can set up multiple routes - each one will give a rule for a certain pattern of URL
                // that can decide what the controller and action are.
                endpoints.MapControllerRoute("hello-route", "hello", new { controller = "Hello", action = "Hello1" });
                // for each request, it starts with the first route and if that doesn't match, it tries each succeeding one
                // in order
                // if you pull the controller or action directly from the pattern, you don't need any default for it
                endpoints.MapControllerRoute("default", "{controller}/{action}");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            // for every request, just respond with hello world html
            //app.Run(async context =>
            //{
            //    context.Response.StatusCode = 200; // success
            //    context.Response.ContentType = "text/html";
            //    await context.Response.WriteAsync("<!DOCTYPE html><html><head></head><body>Hello world</body></html>");
            //});

            // for every request, look in the url for a relative path, and respond
            // with the contents of that file.
            app.Run(async context =>
            {
                string path = $"wwwroot{context.Request.Path}";

                try
                {
                    string text = await File.ReadAllTextAsync(path);
                    // assume it's an HTML file
                    context.Response.StatusCode = 200; // success
                    context.Response.ContentType = "text/html";
                    await context.Response.WriteAsync(text);
                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = 500; // error
                }



//                await context.Response.WriteAsync(@$" <!DOCTYPE html>
//<html>
//    <head>
//    </head>
//    <body>
//        Path: {context.Request.Path}
//    </body>
//</html>");
            });
        }
    }
}
