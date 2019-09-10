using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspCoreWebApplication2
{
    public class Startup
    {
        #region "Configure Services Action Method"
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }
        #endregion

        #region "HandleMapTest1 middleware"
        /// <summary>
        /// HandleMapTest1 middleware
        /// </summary>
        /// <param name="app"></param>
        private static void HandleMapTest1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 1");
                await context.Response.WriteAsync("Current Middleware is the HandleMapTest1 is called using the map()");
            });
        }
        #endregion
                      
        #region "Handle Query"
        /// <summary>
        /// HandleQuery function exexuted for mapWhen()
        /// </summary>
        /// <param name="app"></param>
        private static void HandleQuery(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Return from HandleQuery using mapWhen");
            });
        }
        #endregion

        #region "Configure Method"
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            app.UseMiddleware<MyCustomMiddleware>();

            //UseDeveloperExceptionPage is called when the environment is developer
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //map() method maps the particular path of middleware for HandleMapTest1
            app.Map("/map1", HandleMapTest1);

            //Execute when "q" is there in query string
            app.MapWhen(context =>
            {
                return context.Request.Query.ContainsKey("q");
            }, HandleQuery);
            
            //Non terminal middleware1 using use() passes request to next middleware
            app.Use(async (context, next) =>
            {
                logger.LogInformation("Http incoming request at middleware 1");
                await next();
                logger.LogInformation("Http outgoing response from middleware 1");
            });

            //Non terminal middleware2 using use() passes request to next middleware
            app.Use(async (context, next) =>
            {
                logger.LogInformation("Http incoming request at middleware 2");
                await next();
                logger.LogInformation("Http outgoing response from middleware 2");
            });

            //Terminal middleware3 using run() 
            app.Run(async (context) =>
            {
                logger.LogInformation("Http incoming request at middleware 3");
                logger.LogInformation("Request Handle And Response Produced");
                await context.Response.WriteAsync("Request Handle And Response Produced We are at middleware 3");
                logger.LogInformation("Http outgoing response from middleware 3");
            });

            //        app.MapWhen(context => context.Request.Path.Value.StartsWithSegments("/assets"),
            //appBuilder => appBuilder.UseStaticFiles());
        }
        #endregion
    }
}