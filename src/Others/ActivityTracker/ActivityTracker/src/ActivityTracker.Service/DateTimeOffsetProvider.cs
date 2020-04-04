using System;

namespace ActivityTracker.Service
{
    public class DateTimeOffsetProvider : IDateTimeOffsetFactory
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}