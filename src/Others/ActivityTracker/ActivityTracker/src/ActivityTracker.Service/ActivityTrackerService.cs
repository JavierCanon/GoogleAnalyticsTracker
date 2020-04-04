using ActivityTracker.Events;
using ActivityTracker.EventStore;

namespace ActivityTracker.Service
{
    public class ActivityTrackerService : IActivityTrackerService
    {
        private readonly IDateTimeOffsetFactory _dateTimeOffsetFactory;
        private readonly IEventStore _eventStore;

        public ActivityTrackerService(IEventStore eventStore, IDateTimeOffsetFactory dateTimeOffsetFactory)
        {
            _eventStore = eventStore;
            _dateTimeOffsetFactory = dateTimeOffsetFactory;
        }

        public void OnStart()
        {
            _eventStore.Store(new ServiceStartedActivityEvent(_dateTimeOffsetFactory.Now));
        }

        public void OnStop()
        {
            _eventStore.Store(new ServiceStoppedActivityEvent(_dateTimeOffsetFactory.Now));
        }

        public void OnLogon()
        {
            _eventStore.Store(new UserLogonActivityEvent(_dateTimeOffsetFactory.Now));
        }

        public void OnLogoff()
        {
            _eventStore.Store(new UserLogoffActivityEvent(_dateTimeOffsetFactory.Now));
        }

        public void Unlock()
        {
            _eventStore.Store(new UserUnlockSessionActivityEvent(_dateTimeOffsetFactory.Now));
        }

        public void OnLock()
        {
            _eventStore.Store(new UserLockSessionActivityEvent(_dateTimeOffsetFactory.Now));
        }

        public void OnShutdown()
        {
            _eventStore.Store(new MachineShutdownActivityEvent(_dateTimeOffsetFactory.Now));
        }
    }
}