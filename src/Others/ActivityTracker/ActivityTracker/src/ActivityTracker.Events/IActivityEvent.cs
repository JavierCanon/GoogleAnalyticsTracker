using System;

namespace ActivityTracker.Events
{
    public interface IActivityEvent
    {
        DateTimeOffset Timestamp { get; }
    }
}