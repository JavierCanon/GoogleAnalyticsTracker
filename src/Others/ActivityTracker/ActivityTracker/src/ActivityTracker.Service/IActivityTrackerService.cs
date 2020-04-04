namespace ActivityTracker.Service
{
    public interface IActivityTrackerService
    {
        void OnStart();
        void OnStop();
        void OnLogon();
        void OnLogoff();
        void Unlock();
        void OnLock();
        void OnShutdown();
    }
}