using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.ScheduleApi.Utilities.Hosting
{
    public static class WebHostBuilderExtensions
    {
        /// <summary>
        /// Use the given configuration settings on the web host. Compatible with the configuration section.
        /// </summary>
        /// <param name="hostBuilder">The <see cref="IWebHostBuilder"/> to configure.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> containing settings to be used.</param>
        /// <returns>The <see cref="IWebHostBuilder"/>.</returns>
        public static IWebHostBuilder UseConfigurationSection(this IWebHostBuilder hostBuilder, IConfiguration configuration)
        {
            foreach (var setting in configuration.AsEnumerable(true))
            {
                hostBuilder.UseSetting(setting.Key, setting.Value);
            }

            return hostBuilder;
        }

    }
}
