using System;
using System.Drawing;

namespace IDK {

    /// <summary>
    /// Screenshot class to take screenshots of the screen
    /// </summary>
    class Screenshot {

        private Bitmap Bitmap;      // screenshot pixel data 
        private Graphics Graphics;  // graphics to get the screenshot
        private Size Size;          // size of the screenshot

        /// <summary>
        /// Class constructor. Initializes required variables
        /// </summary>
        /// <param name="width">width of the screenshot</param>
        /// <param name="height">height of the screenshot</param>
        public Screenshot(int width, int height) {
            Bitmap = new Bitmap(width, height);
            Size = new Size(width, height);
            Graphics = Graphics.FromImage(Bitmap);
        }

        /// <summary>
        /// Takes a screenshot
        /// </summary>
        /// <returns>reference to the Bitmap with pixel data</returns>
        public Bitmap Take() {
            Graphics.CopyFromScreen(0, 0, 0, 0, Size);
            return Bitmap;
        }

        /// <summary>
        /// Disposes of the screenshot's bitmap and graphics
        /// </summary>
        public void Dispose() {
            Bitmap.Dispose();
            Graphics.Dispose();
        }
    }
}
