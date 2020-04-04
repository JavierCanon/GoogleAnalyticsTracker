using System.Diagnostics;
using System.Threading;

namespace IDK {
    
    /// <summary>
    /// Task that manages running processes
    /// </summary>
    class ProcessManagingTask : Task {

        // screenshot taking delegate
        public delegate void TakeScreenshot(string nameExtra);

        // used to take screenshots from this task
        private TakeScreenshot ScreenshotTaker;

        // process kill delay after taking a screeshot (in milliseconds)
        private const int KILL_DELAY = 1000;

        /// <summary>
        /// Class constructor
        /// </summary>
        public ProcessManagingTask() : base(Config.GetInstance().Settings.APP_CLOSING_INTERVAL) { }

        /// <summary>
        /// Class constructor
        /// </summary>
        public ProcessManagingTask(TakeScreenshot screenshotTaker) : base(Config.GetInstance().Settings.APP_CLOSING_INTERVAL) {
            ScreenshotTaker += screenshotTaker;
        }

        /// <summary>
        /// Detaches screenshot taking logic from this process manager (prevents this task from taking screenshots)
        /// </summary>
        public void DetachScreenshotTaker() {
            ScreenshotTaker = null;
        }

        /// <summary>
        /// Method that gets called before the task executes to perform necessary initialization
        /// </summary>
        public override void Initialize() {}
        
        /// <summary>
        /// Method that gets called when processes need to be managed
        /// </summary>
        public override void Update() {
            KillProcesses();
        }

        /// <summary>
        /// Kills all processes that are on the Config.AppSettings.APPS_TO_CLOSE list
        /// </summary>
        private void KillProcesses() {
            try {
                foreach (string processName in Config.GetInstance().Settings.APPS_TO_CLOSE) {
                    Process[] processes = Process.GetProcessesByName(processName);

                    foreach (Process process in processes) {
                        if (Config.GetInstance().Settings.TAKE_SCREENSHOTS && ScreenshotTaker != null) {
                            ScreenshotTaker("Before_Closing_" + processName);
                            Thread.Sleep(KILL_DELAY);
                        }

                        try {
                            process.Kill();
                            process.Dispose();
                        } catch { }

                        if (Config.GetInstance().Settings.TAKE_SCREENSHOTS && ScreenshotTaker != null) {
                            Thread.Sleep(KILL_DELAY);
                            ScreenshotTaker("After_Closing_" + processName);
                        }
                    }
                }
            } catch { }
        }
    }
}
