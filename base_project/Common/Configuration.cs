using Microsoft.Extensions.Configuration;
using System.IO;

namespace Base.Common
{
    public class BaseConfiguration
    {
        public static IConfiguration con;
        public static IConfiguration Get()
        {
            if (con == null)
            {
                con = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            }

            return con;
        }
    }
}