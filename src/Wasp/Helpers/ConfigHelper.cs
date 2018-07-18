using System;
using System.Collections.Concurrent;
using System.Configuration;
using System.IO;



namespace Wasp.Helpers
{
    public class ConfigHelper
    {
        private static readonly Lazy<ConfigHelper> Lazy =
            new Lazy<ConfigHelper>(() => new ConfigHelper());

        public ConfigHelper()
        {
            this.Config = new ConcurrentDictionary<string, string>();
            this.LoadConfiguration();
        }

        public ConcurrentDictionary<string, string> Config { get; set; }

        public string HomeUri => this.Config["HomeUri"] ?? throw new EntryPointNotFoundException("HomeUri not set in config");

        public string SeleniumHubServer => this.Config["SeleniumHubServer"] ?? throw new EntryPointNotFoundException("Selenium grid adress not set in config");

        public bool IsLocalTestRun => string.IsNullOrEmpty(this.Config["IsLocal"]) || Convert.ToBoolean(this.Config["IsLocal"]);

        public string ScreenshotPath => this.Config["ScreenshotPath"] ?? $"{AppDomain.CurrentDomain.BaseDirectory}/screenshots";

        public string WebDriverName => this.Config["webDriverName"];

        public TimeSpan DefaultImplicitWait => TimeSpan.FromSeconds(15);

        public static ConfigHelper GetInstance()
        {
            return Lazy.Value;
        }

        private void LoadConfiguration()
        {
#if NETFULL
            this.Config.TryAdd("ScreenshotPath", ConfigurationManager.AppSettings.Get("ScreenShotPath"));
            this.Config.TryAdd("HomeUri", ConfigurationManager.AppSettings.Get("HomeUri"));
            this.Config.TryAdd("SeleniumHubServer", ConfigurationManager.AppSettings.Get("SeleniumHubServerAdress"));
            this.Config.TryAdd("IsLocal", ConfigurationManager.AppSettings.Get("IsLocal"));
            this.Config.TryAdd("webDriverName", ConfigurationManager.AppSettings.Get("webDriverName"));
#endif

#if NETCORE
            var configBuilder = new Microsoft.Extensions.Configuration.ConfigurationBuilder();
            Microsoft.Extensions.Configuration.FileConfigurationExtensions.SetBasePath(configBuilder, Directory.GetCurrentDirectory());
            Microsoft.Extensions.Configuration.JsonConfigurationExtensions.AddJsonFile(configBuilder, "appsettings.json");
            var fileConfig = configBuilder.Build();

            this.Config.TryAdd("SystemName", fileConfig["SystemName"]);
            this.Config.TryAdd("ScreenshotPath", fileConfig["ScreenshotPath"] ?? $"{AppDomain.CurrentDomain.BaseDirectory}/screenshots");
            this.Config.TryAdd("HomeUri", fileConfig["HomeUri"] ?? Environment.GetEnvironmentVariable("LUXITE_URI"));
            this.Config.TryAdd("SeleniumHubServer", fileConfig["SeleniumHubServer"] ?? "hub");
            this.Config.TryAdd("IsLocal", fileConfig["IsLocal"]);
            this.Config.TryAdd("webDriverName", fileConfig["webDriverName"]);
#endif
        }
    }
}
