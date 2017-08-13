using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Euricom.MjrCenter.Shared.Hosting;

namespace Euricom.MjrCenter.VoucherApi
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; private set; }

        public static void Main(string[] args)
        {
            Configuration = BuildConfiguration();

            var host = new WebHostBuilder()
                .UseSetting("detailedErrors", IsDevelopmentMode.ToString())
                .CaptureStartupErrors(IsDevelopmentMode)
                .UseConfigurationSection(Configuration.GetSection("hosting")) 
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseEnvironment(Environment)
                .UseStartup<Startup>()
                .UseKestrel()
                .Build();
            host.Run();            
        }

        internal static IConfigurationRoot BuildConfiguration(){
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.development.json", optional: true)
                .AddEnvironmentVariables("MJRAPI-");
            return builder.Build();            
        }
        
        private static string Environment => Configuration.GetSection("hosting").GetValue<string>("environment", Constants.ProductionEnvironment);
        public static bool IsDevelopmentMode =>  Environment == Constants.DevelopmentEnvironment;
    }
}
