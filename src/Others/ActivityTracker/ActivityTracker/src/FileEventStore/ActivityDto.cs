using System;

namespace FileEventStore
{
    public class ActivityDto
    {
        public ActivityDto(string type, DateTime timeStamp, TimeSpan time)
        {
            Type = type;
            Date = timeStamp.Date;
            Time = time;
        }

        public string Type { get; }
        public DateTime Date { get; }

        public TimeSpan Time { get; }
    }
}