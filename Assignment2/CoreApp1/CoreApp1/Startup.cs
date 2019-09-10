using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoreApp1
{
    public class Startup
    {
        //Variable Declaration
        private IConfiguration _configuration;

        #region "Constructor"
        //Constructor
        public Startup(IConfiguration config)
        {
            _configuration = config;
        }
        #endregion

        #region "Configure Services Method"
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }
        #endregion

        #region "Configure Method"
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                #region "Paerforming Mathematical operations as per users choice"
                Console.WriteLine("1.factorial of Number");
                Console.WriteLine("2.Prime Number");
                Console.WriteLine("3.Armstrong Number");
                Console.WriteLine("Enter Your Choice");
                int c = Convert.ToInt16(Console.ReadLine());

                switch (c)
                {
                    case 1:
                        //Finding the factorial of given number.
                        int i, fact = 1, number;
                        Console.Write("Enter any Number to find factorial:");
                        number = Int32.Parse(Console.ReadLine());
                        for (i = 1; i <= number; i++)
                        {
                            fact *= i;
                        }
                        Console.Write("Factorial of " + number + " is: " + fact + "\n" + "\n");
                        break;

                    case 2:
                        //Checks wheather the given number is prime or not.
                        int n, m = 0, flag = 0;
                        Console.Write("\n" + "Enter any Number to find wheather it is prime or not:");
                        n = int.Parse(Console.ReadLine());
                        m = n / 2;
                        for (i = 2; i <= m; i++)
                        {
                            if (n % i == 0)
                            {
                                Console.Write("Number is not Prime.");
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 0)
                            Console.Write("Number is Prime.");
                        break;

                    case 3:
                        //Checks wheather the given number is armstrong or not.
                        Console.Write("\n" + "\n");
                        int num, remainder, sum = 0;
                        Console.Write("Enter a number to find wheather it is Armstrong number or not : ");
                        num = int.Parse(Console.ReadLine());
                        for (i = num; i > 0; i = i / 10)
                        {
                            remainder = i % 10;
                            sum += remainder * remainder * remainder;
                        }

                        if (sum == num)
                            Console.Write("Entered number is an Armstrong number.");

                        else
                            Console.Write("Entered number is not an Armstrong number.");

                        Console.Write("\n" + "\n");
                        break;

                    default:
                        Console.WriteLine("Choose Only 1 To 3 ");
                        break;
                }
                #endregion

                //Printing on console using IConfiguration and "MyKey":from appSetting.json"
                await context.Response.WriteAsync("Hello Form StartUp.cs" + "\n");
                await context.Response.WriteAsync(_configuration["MyKey"] + "\n");
                await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            });
        }
        #endregion
    }
}