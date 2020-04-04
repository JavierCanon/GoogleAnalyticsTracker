using System;
using ActivityTracker.Events;

namespace FileEventStore
{
    public class ActivitySerializer
    {
        public static ActivityDto Serialize(IActivityEvent activityEvent)
        {
            return new ActivityDto(activityEvent.GetType().AssemblyQualifiedName,
                activityEvent.Timestamp.Date,
                activityEvent.Timestamp.TimeOfDay);
        }

        public static IActivityEvent Deserialize(ActivityDto activityDto)
        {
            return (IActivityEvent)Activator.CreateInstance(Type.GetType(activityDto.Type), new []{ new DateTimeOffset(activityDto.Date, activityDto.Time) });
        }
    }
}