using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AspCoreWebApplication2
{
    #region "MyCustomMiddleware Class"
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        #region "MyCustomMiddleware"
        /// <summary>
        /// MyCustomMiddleware 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="loggerFactory"></param>
        public MyCustomMiddleware(RequestDelegate next,ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("MyCustomMiddleware");
        }
        #endregion

        #region "Invoke"
        /// <summary>
        /// Invoke Method
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("My Custom Middleware is Executing");
            return _next(httpContext);
        }
        #endregion
    }
    #endregion

    #region "MyCustomMiddlewareExtensions"
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<MyCustomMiddleware>();
            return app;
        }
    }
    #endregion
}
