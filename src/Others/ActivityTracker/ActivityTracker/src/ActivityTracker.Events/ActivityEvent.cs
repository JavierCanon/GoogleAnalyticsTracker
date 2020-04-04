using System;

namespace ActivityTracker.Events
{
    public abstract class ActivityEvent : IActivityEvent
    {
        protected ActivityEvent(DateTimeOffset dateTimeOffset)
        {
            Timestamp = dateTimeOffset;
        }

        public DateTimeOffset Timestamp { get; }
    }
}