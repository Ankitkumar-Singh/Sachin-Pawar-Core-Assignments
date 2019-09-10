using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AspCoreWebApplication2
{
    public class Program
    {
        #region "Main Method"
        /// <summary>
        /// Main Method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        } 
        #endregion

        #region "CreateWebHostBuilder Action Method"
        /// <summary>
        /// CreateWebHostBuilder Action Method uses IWebHostBuilder interface
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        #endregion
    }
}