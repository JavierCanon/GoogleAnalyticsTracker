using System;

namespace ActivityTracker.Events
{
    public class ServiceStoppedActivityEvent : ActivityEvent
    {
        public ServiceStoppedActivityEvent(DateTimeOffset dateTimeOffset)
            : base(dateTimeOffset)
        {
        }
    }
}