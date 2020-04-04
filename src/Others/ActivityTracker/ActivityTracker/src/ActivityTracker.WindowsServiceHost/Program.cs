using ActivityTracker.Service;
using AppConfiguration.Ninject;
using Topshelf;
using Topshelf.Ninject;

namespace ActivityTracker.WindowsServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            HostFactory.Run(x =>
            {
                x.Service<IActivityTrackerService>(sc =>
                {
                    sc.ConstructUsingNinject();
                    sc.WhenStarted(s => s.OnStart());
                    sc.WhenStopped(s => s.OnStop());
                    sc.WhenSessionChanged(OnSessionChanged);
                    sc.WhenShutdown(s => s.OnShutdown());
                });
                ConfigureNinject(x);
                x.EnableSessionChanged();
                x.UseLog4Net("log4net.xml");
                x.SetServiceName("ActivityTracker");
                x.SetDisplayName("ActivityTracker");
                x.SetDescription("Track Logged User activities - like login/logout");
            });
        }

        private static void ConfigureNinject(Topshelf.HostConfigurators.HostConfigurator x)
        {
            var config = AppConfigFactory.ReadFromConfig();
            x.UseNinject(new TestEnvServiceNinjectModule(config.FileStorePath));
        }

        private static void OnSessionChanged(IActivityTrackerService trackerService, HostControl host, SessionChangedArguments arg)
        {
            switch (arg.ReasonCode)
            {
                case SessionChangeReasonCode.SessionLogon:
                    trackerService.OnLogon();
                    break;
                case SessionChangeReasonCode.SessionLogoff:
                    trackerService.OnLogoff();
                    break;
                case SessionChangeReasonCode.SessionLock:
                    trackerService.OnLock();
                    break;
                case SessionChangeReasonCode.SessionUnlock:
                    trackerService.Unlock();
                    break;
            }
        }
    }
}
