using System.Collections.Generic;
using ActivityTracker.Events;
using ActivityTracker.EventStore;

namespace MemoryEventStore
{
    public class MemoryEventStore : IEventStore
    {
        protected LinkedList<IActivityEvent> _events = new LinkedList<IActivityEvent>();
        public void Store(IActivityEvent activityEvent)
        {
            _events.AddLast(activityEvent);
        }
    }
}
