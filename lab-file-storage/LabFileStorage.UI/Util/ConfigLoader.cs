using System;
using Microsoft.Extensions.Configuration;

namespace LabFileStorage.UI.Util
{
    public static class ConfigLoader
    {
        private static IConfiguration configuration;
        private static readonly string _path = $"{AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"))}appsettings.json";

        public static IConfiguration GetConfiguration()
        {
            if (configuration == null)
            {
                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.AddJsonFile(_path);
                configuration = builder.Build();
            }
            return configuration;
        }

    }
}
