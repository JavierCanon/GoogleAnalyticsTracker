using System;

namespace ActivityTracker.Events
{
    public class MachineShutdownActivityEvent : ActivityEvent
    {
        public MachineShutdownActivityEvent(DateTimeOffset dateTimeOffset)
            : base(dateTimeOffset)
        {
        }
    }
}