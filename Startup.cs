using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace AngularCliAspNetCore
{
    public class Startup
    {
        private Process npmProcess;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Starts "npm start" command.
                try
                {
                    npmProcess = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "cmd.exe",
                            Arguments = "/C npm start",
                            UseShellExecute = false
                        }
                    };
                    npmProcess.Start();
                    // Registers the application shutdown event.
                    var applicationLifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();
                    applicationLifetime.ApplicationStopping.Register(OnShutDown);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            // Router on the server must match the router on the client (see app.routing.module.ts) to use PathLocationStrategy.
            var appRoutes = new[] {
                 "/home",
                 "/resource"
            };

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.HasValue && appRoutes.Contains(context.Request.Path.Value))
                {
                    context.Request.Path = new PathString("/");
                }

                await next();
            });

            app.UseMvc();

            // Microsoft.AspNetCore.StaticFiles: API for starting the application from wwwroot.
            // Uses default files as index.html.
            app.UseDefaultFiles();
            // Uses static file for the current path.
            app.UseStaticFiles();
        }

        private void OnShutDown()
        {
            if (npmProcess != null)
            {
                try
                {
                    Console.WriteLine($"Killing process npm process ( {npmProcess.StartInfo.FileName} {npmProcess.StartInfo.Arguments} )");
                    npmProcess.Kill();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unable to kill npm process ( {npmProcess.StartInfo.FileName} {npmProcess.StartInfo.Arguments} )");
                    Console.WriteLine($"Exception: {ex}");
                }
            }
        }
    }
}
