using System;

namespace ActivityTracker.Events
{
    public class UserLogonActivityEvent : ActivityEvent
    {
        public UserLogonActivityEvent(DateTimeOffset dateTimeOffset)
            : base(dateTimeOffset)
        {
        }
    }
}