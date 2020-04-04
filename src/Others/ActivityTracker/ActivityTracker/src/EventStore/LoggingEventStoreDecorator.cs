using ActivityTracker.Events;
using ActivityTracker.EventStore;
using log4net;

namespace EventStore
{
    public class LoggingEventStoreDecorator : IEventStore
    {
        protected readonly IEventStore _eventStore;
        protected readonly ILog _log;
        public LoggingEventStoreDecorator(IEventStore eventStore, ILog log)
        {
            _eventStore = eventStore;
            _log = log ?? LogManager.GetLogger(typeof(LoggingEventStoreDecorator));
        }

        public LoggingEventStoreDecorator(IEventStore eventStore) : this(eventStore, null) { }

        public void Store(IActivityEvent activityEvent)
        {
            _log.Debug($"Event {activityEvent.GetType().Name} : {activityEvent.Timestamp} stored.");
        }
    }
}
