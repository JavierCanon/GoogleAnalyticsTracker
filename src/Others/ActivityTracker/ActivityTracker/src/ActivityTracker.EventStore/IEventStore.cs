using ActivityTracker.Events;

namespace ActivityTracker.EventStore
{
    public interface IEventStore
    {
        void Store(IActivityEvent activityEvent);
    }
}