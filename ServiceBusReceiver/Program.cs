using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace ServiceBusReceiver
{
    public class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args)
        {
           return WebHost.CreateDefaultBuilder(args)
            .UseKestrel(options => options.AddServerHeader = false)
            .UseStartup<Startup>();
        }
    }
}
