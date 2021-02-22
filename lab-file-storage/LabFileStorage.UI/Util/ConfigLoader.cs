using System;
using Microsoft.Extensions.Configuration;

namespace LabFileStorage.UI.Util
{
    public static class ConfigLoader
    {
        private static IConfiguration _configuration;
        private static readonly string _path = $"{AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"))}appsettings.json";

        public static IConfiguration GetConfiguration()
        {
            if (_configuration == null)
            {
                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.AddJsonFile(_path);
                _configuration = builder.Build();
            }

            return _configuration;
        }
    }
}
