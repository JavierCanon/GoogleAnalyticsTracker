using ActivityTracker.Events;

namespace ActivityTracker.EventStore
{
    public class EventStore : IEventStore
    {
        public void Store(IActivityEvent activityEvent) { }
    }
}
