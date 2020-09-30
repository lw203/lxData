using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lx.Services.Api.Extensions
{
    public class Global
    {
        static IConfigurationRoot config = null;
        static Global()
        {
            config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public static string GetConfig(string str)
        {
            return config.GetConnectionString("DefaultConnection");
        }
    }
}
