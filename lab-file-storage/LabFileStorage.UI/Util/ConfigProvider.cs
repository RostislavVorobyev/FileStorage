
using Microsoft.Extensions.Configuration;

namespace LabFileStorage.UI.Util
{
    public static class ConfigProvider
    {
        private static IConfiguration _configuration;
        private static IConfiguration Сonfiguration
        {
            get
            {
                if (_configuration == null)
                {
                    GetConfiguration();
                }

                return _configuration;
            }
        }
        private static readonly string _path = $"appsettings.json";

        private static IConfiguration GetConfiguration()
        {
            if (_configuration == null)
            {
                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.AddJsonFile(_path);
                _configuration = builder.Build();
                return builder.Build();
            }

            return _configuration;
        }

        public static string GetLogin()
        {
            return Сonfiguration["Login"];
        }

        public static string GetPassword()
        {
            return Сonfiguration["Password"];
        }

        public static string GetStoragePath()
        {
            return Сonfiguration["Storage path"];
        }

        public static string GetCreationDate()
        {
            return Сonfiguration["Creation date"];
        }
    }
}
