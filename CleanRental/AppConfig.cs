using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanRental
{
    internal class AppConfig
    {
        public static IConfiguration Configuration { get; set; }

        static AppConfig()
        {
            if (Configuration == null)
            {
                Configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appConfig.json")
                    .Build();
            }
        }
        public static string? GetConnectionString() => Configuration.GetConnectionString("postgres");
    }
}
