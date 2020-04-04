using System.Configuration;

namespace ActivityTracker.WindowsServiceHost
{
    class AppConfig
    {
        public string FileStorePath { get; internal set; }
    }

    static class AppConfigKeys
    {
        public const string FileStorePath = "FileStorePath";
    }

    class AppConfigFactory
    {
        public static AppConfig ReadFromConfig()
        {
            return new AppConfig()
            {
                FileStorePath = ConfigurationManager.AppSettings[AppConfigKeys.FileStorePath]
            };
        }
    }
}
