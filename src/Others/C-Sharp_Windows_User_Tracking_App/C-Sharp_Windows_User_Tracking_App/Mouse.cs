using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace IDK {

    /// <summary>
    /// Mouse class to perform mouse events on the screen
    /// </summary>
    class Mouse {

        // declare an external method from the user32.dll to perform mouse events
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        // Mouse actions
        public const int MOUSE_EVENT_LEFTDOWN = 0x02;
        public const int MOUSE_EVENT_LEFTUP = 0x04;
        public const int MOUSE_EVENT_RIGHTDOWN = 0x08;
        public const int MOUSE_EVENT_RIGHTUP = 0x10;

        // mouse position
        private Point Position;

        /// <summary>
        /// Class constructor. Initializes required variables
        /// </summary>
        public Mouse() {
            Position = new Point();
        }

        /// <summary>
        /// Performs a mouse event
        /// </summary>
        /// <param name="action">mouse event to perform</param>
        public void Event(int action) {
            mouse_event(Convert.ToUInt32(action), (uint) Position.X, (uint) Position.Y, 0, 0);
        }

        /// <summary>
        /// Sets the position of the mouse cursor
        /// </summary>
        /// <param name="x">x position on the screen</param>
        /// <param name="y">y position on the screen</param>
        public void SetPosition(int x, int y) {
            Position.X = x;
            Position.Y = y;
            Cursor.Position = Position;
        }
    }
}
