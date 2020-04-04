using System;

namespace ActivityTracker.Events
{
    public class ServiceStartedActivityEvent : ActivityEvent
    {
        public ServiceStartedActivityEvent(DateTimeOffset dateTimeOffset)
            : base(dateTimeOffset)
        {
        }
    }
}