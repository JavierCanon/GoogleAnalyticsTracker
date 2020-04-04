namespace UserTracker
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.radioGlobal = new System.Windows.Forms.RadioButton();
            this.radioNone = new System.Windows.Forms.RadioButton();
            this.labelWheel = new System.Windows.Forms.Label();
            this.labelMousePosition = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.IdleTimer = new System.Windows.Forms.Label();
            this.clearLogButton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSeparator
            // 
            this.panelSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSeparator.BackColor = System.Drawing.Color.White;
            this.panelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSeparator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelSeparator.Location = new System.Drawing.Point(6, 34);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(584, 1);
            this.panelSeparator.TabIndex = 11;
            // 
            // radioGlobal
            // 
            this.radioGlobal.AutoSize = true;
            this.radioGlobal.BackColor = System.Drawing.Color.White;
            this.radioGlobal.Checked = true;
            this.radioGlobal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGlobal.Location = new System.Drawing.Point(12, 11);
            this.radioGlobal.Name = "radioGlobal";
            this.radioGlobal.Size = new System.Drawing.Size(92, 17);
            this.radioGlobal.TabIndex = 10;
            this.radioGlobal.TabStop = true;
            this.radioGlobal.Text = "Start Tracking";
            this.radioGlobal.UseVisualStyleBackColor = false;
            this.radioGlobal.CheckedChanged += new System.EventHandler(this.radioGlobal_CheckedChanged);
            // 
            // radioNone
            // 
            this.radioNone.AutoSize = true;
            this.radioNone.BackColor = System.Drawing.Color.White;
            this.radioNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNone.Location = new System.Drawing.Point(220, 13);
            this.radioNone.Name = "radioNone";
            this.radioNone.Size = new System.Drawing.Size(92, 17);
            this.radioNone.TabIndex = 14;
            this.radioNone.Text = "Stop Tracking";
            this.radioNone.UseVisualStyleBackColor = false;
            this.radioNone.CheckedChanged += new System.EventHandler(this.radioNone_CheckedChanged);
            // 
            // labelWheel
            // 
            this.labelWheel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWheel.AutoSize = true;
            this.labelWheel.BackColor = System.Drawing.Color.White;
            this.labelWheel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWheel.Location = new System.Drawing.Point(9, 70);
            this.labelWheel.Name = "labelWheel";
            this.labelWheel.Size = new System.Drawing.Size(89, 13);
            this.labelWheel.TabIndex = 6;
            this.labelWheel.Text = "Wheel={0:####}";
            // 
            // labelMousePosition
            // 
            this.labelMousePosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMousePosition.AutoSize = true;
            this.labelMousePosition.BackColor = System.Drawing.Color.White;
            this.labelMousePosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMousePosition.Location = new System.Drawing.Point(9, 46);
            this.labelMousePosition.Name = "labelMousePosition";
            this.labelMousePosition.Size = new System.Drawing.Size(125, 13);
            this.labelMousePosition.TabIndex = 2;
            this.labelMousePosition.Text = "x={0:####}; y={1:####}";
            // 
            // textBoxLog
            // 
            this.textBoxLog.BackColor = System.Drawing.Color.White;
            this.textBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLog.Location = new System.Drawing.Point(0, 98);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(602, 215);
            this.textBoxLog.TabIndex = 8;
            this.textBoxLog.WordWrap = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.IdleTimer);
            this.groupBox2.Controls.Add(this.clearLogButton);
            this.groupBox2.Controls.Add(this.panelSeparator);
            this.groupBox2.Controls.Add(this.radioGlobal);
            this.groupBox2.Controls.Add(this.radioNone);
            this.groupBox2.Controls.Add(this.labelWheel);
            this.groupBox2.Controls.Add(this.labelMousePosition);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 98);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // IdleTimer
            // 
            this.IdleTimer.AutoSize = true;
            this.IdleTimer.Location = new System.Drawing.Point(151, 46);
            this.IdleTimer.Name = "IdleTimer";
            this.IdleTimer.Size = new System.Drawing.Size(51, 13);
            this.IdleTimer.TabIndex = 17;
            this.IdleTimer.Text = "idle time: ";
            // 
            // clearLogButton
            // 
            this.clearLogButton.Location = new System.Drawing.Point(515, 66);
            this.clearLogButton.Name = "clearLogButton";
            this.clearLogButton.Size = new System.Drawing.Size(75, 21);
            this.clearLogButton.TabIndex = 16;
            this.clearLogButton.Text = "Clear Log";
            this.clearLogButton.UseVisualStyleBackColor = true;
            this.clearLogButton.Click += new System.EventHandler(this.clearLog_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Activity Tracker";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 313);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.groupBox2);
            this.Name = "Main";
            this.Text = "Activity Tracker";
            this.Resize += new System.EventHandler(this.TrayMinimizerForm_Resize);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.CheckBox checkBoxSuppressMouse;
        private System.Windows.Forms.Panel panelSeparator;
        private System.Windows.Forms.RadioButton radioGlobal;
        private System.Windows.Forms.RadioButton radioNone;
        private System.Windows.Forms.Label labelWheel;
        private System.Windows.Forms.Label labelMousePosition;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.GroupBox groupBox2;
        //private System.Windows.Forms.CheckBox checkBoxSupressMouseWheel;
        private System.Windows.Forms.Button clearLogButton;
        private System.Windows.Forms.Label IdleTimer;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

