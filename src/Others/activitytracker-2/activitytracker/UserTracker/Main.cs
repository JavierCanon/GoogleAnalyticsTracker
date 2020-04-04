// This code is distributed under MIT license. 
// Copyright (c) 2015 George Mamaladze
// See license.txt or http://opensource.org/licenses/mit-license.php

using System;
using System.ComponentModel;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using Gma.System.MouseKeyHook.Implementation;
using System.Timers;

namespace UserTracker
{
    public partial class Main : Form
    {
        private IKeyboardMouseEvents m_Events;
        private System.Timers.Timer idleTimer = new System.Timers.Timer();
        private System.Timers.Timer activeTimer = new System.Timers.Timer();

        public Main()
        {
            InitializeComponent();
            radioGlobal.Checked = true;
            SubscribeGlobal();
            FormClosing += Main_Closing;
            InitTimer();
        }

        private void InitTimer()
        {
            idleTimer.Elapsed += new ElapsedEventHandler(OnIdleEvent);
            idleTimer.Interval = 1000 * 60 * 30;  //1000 is 1 second
            idleTimer.Start();

            activeTimer.Elapsed += new ElapsedEventHandler(OnActiveEvent);
            activeTimer.Interval = 1000 * 60 * 60; // 1hour
            activeTimer.Start();
        }

        private void ResetIdleTimer()
        {
            idleTimer.Stop();
            idleTimer.Start();
        }

        private void ResetActiveTimer()
        {
            activeTimer.Stop();
            activeTimer.Start();
        }
        private void StopAllTimer()
        {
            Console.WriteLine("Stop all timers");
            idleTimer.Stop();
            activeTimer.Stop();
        }


        private void OnIdleEvent(object sender, ElapsedEventArgs e)
        {
            ResetActiveTimer();
            Console.WriteLine("Idle event activated, signal time \t{0} ", e.SignalTime);
            //IdleTimer.Text = string.Format("Come back to work!");
            //Log(string.Format("Come back to work"));
            //SendMsg("Come back to work");
            LocalSound.playBackWork();
        }

        private void OnActiveEvent(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Active event activated, signal time \t{0} ", e.SignalTime);
            //IdleTimer.Text = string.Format("You need to take a break!");
            //Log(string.Format("You need to take a break"));
            //SendMsg("You need to take a break!");
            LocalSound.playTakeBreak();
        }

        private void Main_Closing(object sender, CancelEventArgs e)
        {
            Unsubscribe();
        }

        private void SubscribeApplication()
        {
            Unsubscribe();
            Subscribe(Hook.AppEvents());
        }

        private void SubscribeGlobal()
        {
            Unsubscribe();
            Subscribe(Hook.GlobalEvents());
            ResetIdleTimer();
            ResetActiveTimer();
        }

        private void Subscribe(IKeyboardMouseEvents events)
        {
            m_Events = events;
            m_Events.KeyDown += OnKeyDown;
            m_Events.KeyUp += OnKeyUp;
            m_Events.KeyPress += HookManager_KeyPress;

            m_Events.MouseUp += OnMouseUp;
            m_Events.MouseClick += OnMouseClick;
            m_Events.MouseDoubleClick += OnMouseDoubleClick;

            m_Events.MouseMove += HookManager_MouseMove;

            m_Events.MouseDragStarted += OnMouseDragStarted;
            m_Events.MouseDragFinished += OnMouseDragFinished;

            m_Events.MouseWheel += HookManager_MouseWheel;
            //if (checkBoxSupressMouseWheel.Checked)
            //    m_Events.MouseWheelExt += HookManager_MouseWheelExt;
            //else
            //    m_Events.MouseWheel += HookManager_MouseWheel;

            m_Events.MouseDown += OnMouseDown;
            //if (checkBoxSuppressMouse.Checked)
            //    m_Events.MouseDownExt += HookManager_Supress;
            //else
            //    m_Events.MouseDown += OnMouseDown;
        }

        private void Unsubscribe()
        {
            if (m_Events == null) return;
            m_Events.KeyDown -= OnKeyDown;
            m_Events.KeyUp -= OnKeyUp;
            m_Events.KeyPress -= HookManager_KeyPress;

            m_Events.MouseUp -= OnMouseUp;
            m_Events.MouseClick -= OnMouseClick;
            m_Events.MouseDoubleClick -= OnMouseDoubleClick;

            m_Events.MouseMove -= HookManager_MouseMove;

            m_Events.MouseDragStarted -= OnMouseDragStarted;
            m_Events.MouseDragFinished -= OnMouseDragFinished;

            m_Events.MouseWheel -= HookManager_MouseWheel;
            //if (checkBoxSupressMouseWheel.Checked)
            //    m_Events.MouseWheelExt -= HookManager_MouseWheelExt;
            //else
            //    m_Events.MouseWheel -= HookManager_MouseWheel;

            m_Events.MouseDown -= OnMouseDown;
            //if (checkBoxSuppressMouse.Checked)
            //    m_Events.MouseDownExt -= HookManager_Supress;
            //else
            //    m_Events.MouseDown -= OnMouseDown;

            m_Events.Dispose();
            m_Events = null;
            StopAllTimer();
        }

        //private void SendMsg(string message)
        //{
        //    //IdleTimer.Text = string.Format("Come back to work!");
        //    //Log(string.Format("Come back to work"));
        //    //textBoxLog.AppendText("Come back to work");
        //    //textBoxLog.ScrollToCaret();
        //}

        private void HookManager_Supress(object sender, MouseEventExtArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                Log(string.Format("MouseDown \t\t {0}\n", e.Button));
                return;
            }

            Log(string.Format("MouseDown \t\t {0} Suppressed\n", e.Button));
            e.Handled = true;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            IdleManager();
            Log(string.Format("KeyDown  \t\t {0}\n", e.KeyCode));
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            Log(string.Format("KeyUp  \t\t {0}\n", e.KeyCode));
        }

        private void HookManager_KeyPress(object sender, KeyPressEventArgs e)
        {
            IdleManager();
            Log(string.Format("KeyPress \t\t {0}\n", e.KeyChar));
        }

        private void HookManager_MouseMove(object sender, MouseEventArgs e)
        {
            IdleManager();
            labelMousePosition.Text = string.Format("x={0:0000}; y={1:0000}", e.X, e.Y);
        }

        private void IdleManager()
        {
            ResetIdleTimer();
            IdleTimer.Text = string.Format("User is Working");
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            Log(string.Format("MouseDown \t\t {0}\n", e.Button));
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            IdleManager();
            Log(string.Format("MouseUp \t\t {0}\n", e.Button));
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            IdleManager();
            Log(string.Format("MouseClick \t\t {0}\n", e.Button));
        }

        private void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            IdleManager();
            Log(string.Format("MouseDoubleClick \t\t {0}\n", e.Button));
        }

        private void OnMouseDragStarted(object sender, MouseEventArgs e)
        {
            IdleManager();
            Log("MouseDragStarted\n");
        }

        private void OnMouseDragFinished(object sender, MouseEventArgs e)
        {
            Log("MouseDragFinished\n");
        }

        private void HookManager_MouseWheel(object sender, MouseEventArgs e)
        {
            IdleManager();
            labelWheel.Text = string.Format("Wheel={0:000}", e.Delta);
        }
        
        private void HookManager_MouseWheelExt(object sender, MouseEventExtArgs e)
        {
            labelWheel.Text = string.Format("Wheel={0:000}", e.Delta);
            Log("Mouse Wheel Move Suppressed.\n");
            e.Handled = true;
        }

        private void Log(string text)
        {
            if (IsDisposed) return;
            textBoxLog.AppendText(text);
            textBoxLog.ScrollToCaret();
        }

        //private void radioApplication_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (((RadioButton) sender).Checked) SubscribeApplication();
        //}

        private void radioGlobal_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton) sender).Checked) SubscribeGlobal();
        }

        private void radioNone_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked) Unsubscribe();
        }

        //private void checkBoxSupressMouseWheel_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (m_Events == null) return;

        //    m_Events.MouseWheelExt -= HookManager_MouseWheelExt;
        //    m_Events.MouseWheel += HookManager_MouseWheel;

        //    //if (((CheckBox)sender).Checked)
        //    //{
        //    //    m_Events.MouseWheel -= HookManager_MouseWheel;
        //    //    m_Events.MouseWheelExt += HookManager_MouseWheelExt;
        //    //}
        //    //else
        //    //{
        //    //    m_Events.MouseWheelExt -= HookManager_MouseWheelExt;
        //    //    m_Events.MouseWheel += HookManager_MouseWheel;
        //    //}
        //}

        //private void checkBoxSuppressMouse_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (m_Events == null) return;

        //    m_Events.MouseDownExt -= HookManager_Supress;
        //    m_Events.MouseDown += OnMouseDown;

        //    //if (((CheckBox)sender).Checked)
        //    //{
        //    //    m_Events.MouseDown -= OnMouseDown;
        //    //    m_Events.MouseDownExt += HookManager_Supress;
        //    //}
        //    //else
        //    //{
        //    //    m_Events.MouseDownExt -= HookManager_Supress;
        //    //    m_Events.MouseDown += OnMouseDown;
        //    //}
        //}

        private void clearLog_Click(object sender, EventArgs e)
        {
            textBoxLog.Clear();
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // Main
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 261);
        //    this.Name = "Main";
        //    this.Load += new System.EventHandler(this.Main_Load);
        //    this.ResumeLayout(false);

        //}

        private void Main_Load(object sender, EventArgs e)
        {
        }
      //      this.notifyIcon1.Icon = 
      //((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));


        private void TrayMinimizerForm_Resize(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "Activity Tracker";
            notifyIcon1.BalloonTipText = "Your activity tracker is still working in backgound";

            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        //private void Main_Resize(object sender, EventArgs e)
        //{
        //    //if the form is minimized  
        //    //hide it from the task bar  
        //    //and show the system tray icon (represented by the NotifyIcon control)  
        //    if (this.WindowState == FormWindowState.Minimized)
        //    {
        //        Hide();
        //        notifyIcon1.Visible = true;
        //    }

        //}

    }
}