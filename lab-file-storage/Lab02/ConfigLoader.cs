using Microsoft.Extensions.Configuration;

namespace Lab02
{
    internal class ConfigLoader
    {
        private static IConfiguration configuration;
        private const string path = @"C:\Users\r.vorobyov\Desktop\VorobyovMastery\Unit2_Net\Lab\Minsk-Rostislav-Vorobyov\lab-file-storage\Lab02\appsettings.json";

        internal static IConfiguration GetConfiguration()
        {
            if (configuration == null)
            {
                ConfigurationBuilder builder = new ConfigurationBuilder();
                JsonConfigurationExtensions.AddJsonFile(builder, path);
                configuration = builder.Build();
            }
            return configuration;
        }
    }
}
