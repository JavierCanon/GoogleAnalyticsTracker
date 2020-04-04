using System;

namespace ActivityTracker.Events
{
    public class UserLogoffActivityEvent : ActivityEvent
    {
        public UserLogoffActivityEvent(DateTimeOffset dateTimeOffset)
            : base(dateTimeOffset)
        {
        }
    }
}