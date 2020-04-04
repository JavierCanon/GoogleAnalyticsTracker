using ActivityTracker.EventStore;
using ActivityTracker.Service;
using ToLog4NetEventStore;

namespace AppConfiguration.Ninject
{
    public class DevEnvServiceNinjectModule : ServiceNinjectModule
    {
        public override void Load()
        {
            Bind<IActivityTrackerService>().To<ActivityTrackerService>();
            Bind<IEventStore>().To<MemoryEventStore.MemoryEventStore>().WhenInjectedInto<LoggingEventStoreDecorator>();
            Bind<IEventStore>().To<LoggingEventStoreDecorator>();
        }
    }
}