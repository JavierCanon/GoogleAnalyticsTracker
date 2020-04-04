using System;

namespace ActivityTracker.Events
{
    public class UserUnlockSessionActivityEvent : ActivityEvent
    {
        public UserUnlockSessionActivityEvent(DateTimeOffset dateTimeOffset)
            : base(dateTimeOffset)
        {
        }
    }
}