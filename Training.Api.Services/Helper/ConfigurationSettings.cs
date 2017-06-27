namespace Training.Api.Services.Helper
{
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public class ConfigurationSettings
    {
        public string GetConfigurationSetting(string key)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath((Directory.GetCurrentDirectory()));
            builder.AddJsonFile("appsettings.json").Build();
            var config = builder.Build();
            return config.GetSection("AppSettings").GetSection(key).Value;
        }
    }
}
