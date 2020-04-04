using System;

namespace ActivityTracker.Events
{
    public class UserLockSessionActivityEvent : ActivityEvent
    {
        public UserLockSessionActivityEvent(DateTimeOffset dateTimeOffset)
            : base(dateTimeOffset)
        {
        }
    }
}