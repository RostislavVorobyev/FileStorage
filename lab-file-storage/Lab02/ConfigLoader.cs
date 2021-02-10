using Microsoft.Extensions.Configuration;
using System;

namespace Lab02
{
    internal static class ConfigLoader
    {
        private static IConfiguration configuration;
        private static readonly string _path = $"{AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"))}appsettings.json";
        
        public static IConfiguration GetConfiguration()
        {
            if (configuration == null)
            {
                ConfigurationBuilder builder = new ConfigurationBuilder();
                JsonConfigurationExtensions.AddJsonFile(builder, _path);
                configuration = builder.Build();
            }
            return configuration;
        }

    }
}
