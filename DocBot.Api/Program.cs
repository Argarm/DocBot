using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace DocBot {
    public class Program {
        private static string DummyConnectionString = "DummyConnectionString";
        private const string Development = "Development";

        public static void Main(string[] args) {
            var host = Host.CreateDefaultBuilder(args)
                .UseEnvironment(Development)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.ConfigureAppConfiguration((context, configurationBuilder) => {
                        configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath)
                            .AddJsonFile("appsettings.json", true, true)
                            .AddJsonFile("environment.json", true);
                    }).UseStartup<Startup>();
                }).Build();
            host.Run();
        }

    }

}