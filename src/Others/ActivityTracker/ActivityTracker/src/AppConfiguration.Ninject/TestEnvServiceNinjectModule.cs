using ActivityTracker.EventStore;
using ActivityTracker.Service;
using ToLog4NetEventStore;

namespace AppConfiguration.Ninject
{
    public class TestEnvServiceNinjectModule : ServiceNinjectModule
    {
        private readonly string _eventStoreFullPath;

        public TestEnvServiceNinjectModule(string eventStoreFullPath)
        {
            _eventStoreFullPath = eventStoreFullPath;
        }

        public override void Load()
        {
            Bind<IActivityTrackerService>().To<ActivityTrackerService>();
            Bind<IEventStore>()
                .To<FileEventStore.FileEventStore>()
                .WhenInjectedInto<LoggingEventStoreDecorator>()
                .WithConstructorArgument(_eventStoreFullPath);
            Bind<IEventStore>().To<LoggingEventStoreDecorator>();
            Bind<IDateTimeOffsetFactory>().To<DateTimeOffsetProvider>();
        }
    }
}