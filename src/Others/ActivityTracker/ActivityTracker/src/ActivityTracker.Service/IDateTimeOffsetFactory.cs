using System;

namespace ActivityTracker.Service
{
    public interface IDateTimeOffsetFactory
    {
        DateTimeOffset Now { get; }
    }
}