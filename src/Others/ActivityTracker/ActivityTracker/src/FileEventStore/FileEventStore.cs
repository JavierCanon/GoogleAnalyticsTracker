using System.Collections.Generic;
using System.IO;
using ActivityTracker.Events;
using ActivityTracker.EventStore;
using Newtonsoft.Json;

namespace FileEventStore
{
    public class FileEventStore : IEventStore
    {
        private readonly string _fileFullPath;

        public FileEventStore(string fileFullPath)
        {
            Validate(fileFullPath);
            _fileFullPath = fileFullPath;
        }

        public void Store(IActivityEvent activityEvent)
        {
            File.AppendAllLines(_fileFullPath,
                new List<string> {JsonConvert.SerializeObject(ActivitySerializer.Serialize(activityEvent))});
        }

        private void Validate(string rootPath)
        {
            if (!File.Exists(rootPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(rootPath));
                File.Create(rootPath,
                    512,
                    FileOptions.SequentialScan | FileOptions.WriteThrough).Close();
            }
        }
    }
}