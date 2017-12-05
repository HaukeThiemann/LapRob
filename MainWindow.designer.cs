namespace LapRob
{
    partial class MainWindow
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_ConnectTracker = new System.Windows.Forms.Button();
            this.button_ConnectRob = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_TrackerPort = new System.Windows.Forms.TextBox();
            this.textBox_TrackerIP = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_RobPort = new System.Windows.Forms.TextBox();
            this.textBox_RobIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_GetStatus = new System.Windows.Forms.Button();
            this.GB_Marker = new System.Windows.Forms.GroupBox();
            this.button_Calibrate = new System.Windows.Forms.Button();
            this.button_SetFormat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Format = new System.Windows.Forms.ComboBox();
            this.button_SetMarker = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Marker = new System.Windows.Forms.ComboBox();
            this.GB_Log = new System.Windows.Forms.GroupBox();
            this.button_GetPos = new System.Windows.Forms.Button();
            this.checkedListBox_Verbosity = new System.Windows.Forms.CheckedListBox();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.trackBar_Speed = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkedListBox_DoFLock = new System.Windows.Forms.CheckedListBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_GoHome = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.GB_Marker.SuspendLayout();
            this.GB_Log.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Speed)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_ConnectTracker);
            this.groupBox1.Controls.Add(this.button_ConnectRob);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox_TrackerPort);
            this.groupBox1.Controls.Add(this.textBox_TrackerIP);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_RobPort);
            this.groupBox1.Controls.Add(this.textBox_RobIP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // button_ConnectTracker
            // 
            this.button_ConnectTracker.Location = new System.Drawing.Point(196, 60);
            this.button_ConnectTracker.Name = "button_ConnectTracker";
            this.button_ConnectTracker.Size = new System.Drawing.Size(75, 22);
            this.button_ConnectTracker.TabIndex = 5;
            this.button_ConnectTracker.Text = "Connect";
            this.button_ConnectTracker.UseVisualStyleBackColor = true;
            this.button_ConnectTracker.Click += new System.EventHandler(this.button_ConnectTracker_Click);
            // 
            // button_ConnectRob
            // 
            this.button_ConnectRob.Location = new System.Drawing.Point(196, 35);
            this.button_ConnectRob.Name = "button_ConnectRob";
            this.button_ConnectRob.Size = new System.Drawing.Size(75, 22);
            this.button_ConnectRob.TabIndex = 2;
            this.button_ConnectRob.Text = "Connect";
            this.button_ConnectRob.UseVisualStyleBackColor = true;
            this.button_ConnectRob.Click += new System.EventHandler(this.button_ConnectRob_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(144, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = ":";
            // 
            // textBox_TrackerPort
            // 
            this.textBox_TrackerPort.Location = new System.Drawing.Point(154, 61);
            this.textBox_TrackerPort.Name = "textBox_TrackerPort";
            this.textBox_TrackerPort.Size = new System.Drawing.Size(36, 20);
            this.textBox_TrackerPort.TabIndex = 4;
            this.textBox_TrackerPort.Text = "5000";
            this.textBox_TrackerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_TrackerIP
            // 
            this.textBox_TrackerIP.Location = new System.Drawing.Point(52, 61);
            this.textBox_TrackerIP.Name = "textBox_TrackerIP";
            this.textBox_TrackerIP.Size = new System.Drawing.Size(92, 20);
            this.textBox_TrackerIP.TabIndex = 3;
            this.textBox_TrackerIP.Text = "127.0.0.1";
            this.textBox_TrackerIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Tracker";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(144, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(150, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Port";
            // 
            // textBox_RobPort
            // 
            this.textBox_RobPort.Location = new System.Drawing.Point(154, 36);
            this.textBox_RobPort.Name = "textBox_RobPort";
            this.textBox_RobPort.Size = new System.Drawing.Size(36, 20);
            this.textBox_RobPort.TabIndex = 1;
            this.textBox_RobPort.Text = "5005";
            this.textBox_RobPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_RobIP
            // 
            this.textBox_RobIP.Location = new System.Drawing.Point(52, 36);
            this.textBox_RobIP.Name = "textBox_RobIP";
            this.textBox_RobIP.Size = new System.Drawing.Size(92, 20);
            this.textBox_RobIP.TabIndex = 0;
            this.textBox_RobIP.Text = "127.0.0.1";
            this.textBox_RobIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Robot";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address";
            // 
            // button_GetStatus
            // 
            this.button_GetStatus.Location = new System.Drawing.Point(6, 473);
            this.button_GetStatus.Name = "button_GetStatus";
            this.button_GetStatus.Size = new System.Drawing.Size(76, 23);
            this.button_GetStatus.TabIndex = 2;
            this.button_GetStatus.Text = "Get Status";
            this.button_GetStatus.UseVisualStyleBackColor = true;
            this.button_GetStatus.Click += new System.EventHandler(this.button_GetStatus_Click);
            // 
            // GB_Marker
            // 
            this.GB_Marker.Controls.Add(this.button_Calibrate);
            this.GB_Marker.Controls.Add(this.button_SetFormat);
            this.GB_Marker.Controls.Add(this.label4);
            this.GB_Marker.Controls.Add(this.comboBox_Format);
            this.GB_Marker.Controls.Add(this.button_SetMarker);
            this.GB_Marker.Controls.Add(this.label3);
            this.GB_Marker.Controls.Add(this.comboBox_Marker);
            this.GB_Marker.Location = new System.Drawing.Point(12, 112);
            this.GB_Marker.Name = "GB_Marker";
            this.GB_Marker.Size = new System.Drawing.Size(282, 106);
            this.GB_Marker.TabIndex = 1;
            this.GB_Marker.TabStop = false;
            this.GB_Marker.Text = "Tracking Setup";
            // 
            // button_Calibrate
            // 
            this.button_Calibrate.Location = new System.Drawing.Point(103, 72);
            this.button_Calibrate.Name = "button_Calibrate";
            this.button_Calibrate.Size = new System.Drawing.Size(76, 23);
            this.button_Calibrate.TabIndex = 4;
            this.button_Calibrate.Text = "Calibrate";
            this.button_Calibrate.UseVisualStyleBackColor = true;
            this.button_Calibrate.Click += new System.EventHandler(this.button_Calibrate_Click);
            // 
            // button_SetFormat
            // 
            this.button_SetFormat.Location = new System.Drawing.Point(234, 44);
            this.button_SetFormat.Name = "button_SetFormat";
            this.button_SetFormat.Size = new System.Drawing.Size(38, 23);
            this.button_SetFormat.TabIndex = 3;
            this.button_SetFormat.Text = "Set";
            this.button_SetFormat.UseVisualStyleBackColor = true;
            this.button_SetFormat.Click += new System.EventHandler(this.button_SetFormat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Format";
            // 
            // comboBox_Format
            // 
            this.comboBox_Format.FormattingEnabled = true;
            this.comboBox_Format.Items.AddRange(new object[] {
            "Quaternion",
            "Matrix (row wise)"});
            this.comboBox_Format.Location = new System.Drawing.Point(52, 45);
            this.comboBox_Format.Name = "comboBox_Format";
            this.comboBox_Format.Size = new System.Drawing.Size(176, 21);
            this.comboBox_Format.TabIndex = 2;
            // 
            // button_SetMarker
            // 
            this.button_SetMarker.Location = new System.Drawing.Point(234, 18);
            this.button_SetMarker.Name = "button_SetMarker";
            this.button_SetMarker.Size = new System.Drawing.Size(38, 23);
            this.button_SetMarker.TabIndex = 1;
            this.button_SetMarker.Text = "Set";
            this.button_SetMarker.UseVisualStyleBackColor = true;
            this.button_SetMarker.Click += new System.EventHandler(this.button_SetMarker_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Marker";
            // 
            // comboBox_Marker
            // 
            this.comboBox_Marker.FormattingEnabled = true;
            this.comboBox_Marker.Location = new System.Drawing.Point(52, 19);
            this.comboBox_Marker.Name = "comboBox_Marker";
            this.comboBox_Marker.Size = new System.Drawing.Size(176, 21);
            this.comboBox_Marker.TabIndex = 0;
            // 
            // GB_Log
            // 
            this.GB_Log.Controls.Add(this.button_GetPos);
            this.GB_Log.Controls.Add(this.button_GetStatus);
            this.GB_Log.Controls.Add(this.checkedListBox_Verbosity);
            this.GB_Log.Controls.Add(this.textBox_Log);
            this.GB_Log.Location = new System.Drawing.Point(301, 12);
            this.GB_Log.Name = "GB_Log";
            this.GB_Log.Size = new System.Drawing.Size(312, 507);
            this.GB_Log.TabIndex = 3;
            this.GB_Log.TabStop = false;
            this.GB_Log.Text = "Log";
            // 
            // button_GetPos
            // 
            this.button_GetPos.Location = new System.Drawing.Point(88, 473);
            this.button_GetPos.Name = "button_GetPos";
            this.button_GetPos.Size = new System.Drawing.Size(76, 23);
            this.button_GetPos.TabIndex = 3;
            this.button_GetPos.Text = "Get Position";
            this.button_GetPos.UseVisualStyleBackColor = true;
            this.button_GetPos.Click += new System.EventHandler(this.button_GetPos_Click);
            // 
            // checkedListBox_Verbosity
            // 
            this.checkedListBox_Verbosity.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBox_Verbosity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox_Verbosity.ColumnWidth = 100;
            this.checkedListBox_Verbosity.FormattingEnabled = true;
            this.checkedListBox_Verbosity.Items.AddRange(new object[] {
            "Error",
            "Warning",
            "Information"});
            this.checkedListBox_Verbosity.Location = new System.Drawing.Point(6, 19);
            this.checkedListBox_Verbosity.MultiColumn = true;
            this.checkedListBox_Verbosity.Name = "checkedListBox_Verbosity";
            this.checkedListBox_Verbosity.Size = new System.Drawing.Size(300, 15);
            this.checkedListBox_Verbosity.TabIndex = 0;
            this.checkedListBox_Verbosity.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_Verbosity_ItemCheck);
            // 
            // textBox_Log
            // 
            this.textBox_Log.Location = new System.Drawing.Point(6, 37);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.ReadOnly = true;
            this.textBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Log.Size = new System.Drawing.Size(300, 430);
            this.textBox_Log.TabIndex = 1;
            this.textBox_Log.TextChanged += new System.EventHandler(this.textBox_Log_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.button_Start);
            this.groupBox2.Controls.Add(this.button_GoHome);
            this.groupBox2.Location = new System.Drawing.Point(13, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 199);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.trackBar_Speed);
            this.groupBox4.Location = new System.Drawing.Point(9, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(265, 74);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Speed";
            // 
            // trackBar_Speed
            // 
            this.trackBar_Speed.Location = new System.Drawing.Point(7, 19);
            this.trackBar_Speed.Name = "trackBar_Speed";
            this.trackBar_Speed.Size = new System.Drawing.Size(252, 45);
            this.trackBar_Speed.TabIndex = 26;
            this.trackBar_Speed.Value = 5;
            this.trackBar_Speed.ValueChanged += new System.EventHandler(this.trackBar_Speed_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkedListBox_DoFLock);
            this.groupBox3.Location = new System.Drawing.Point(9, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(265, 58);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DoF Lock";
            // 
            // checkedListBox_DoFLock
            // 
            this.checkedListBox_DoFLock.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBox_DoFLock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox_DoFLock.FormattingEnabled = true;
            this.checkedListBox_DoFLock.Items.AddRange(new object[] {
            "Orientation (All axis)",
            "Translation (Longitudinal axis)"});
            this.checkedListBox_DoFLock.Location = new System.Drawing.Point(7, 20);
            this.checkedListBox_DoFLock.Name = "checkedListBox_DoFLock";
            this.checkedListBox_DoFLock.Size = new System.Drawing.Size(165, 30);
            this.checkedListBox_DoFLock.TabIndex = 0;
            this.checkedListBox_DoFLock.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_DoFLock_ItemCheck);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(91, 163);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(76, 23);
            this.button_Start.TabIndex = 1;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_GoHome
            // 
            this.button_GoHome.Location = new System.Drawing.Point(9, 163);
            this.button_GoHome.Name = "button_GoHome";
            this.button_GoHome.Size = new System.Drawing.Size(76, 23);
            this.button_GoHome.TabIndex = 0;
            this.button_GoHome.Text = "Go Home";
            this.button_GoHome.UseVisualStyleBackColor = true;
            this.button_GoHome.Click += new System.EventHandler(this.button_GoHome_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 531);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GB_Log);
            this.Controls.Add(this.GB_Marker);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainWindow";
            this.Text = "LapRob";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GB_Marker.ResumeLayout(false);
            this.GB_Marker.PerformLayout();
            this.GB_Log.ResumeLayout(false);
            this.GB_Log.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Speed)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_RobIP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_RobPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_TrackerPort;
        private System.Windows.Forms.TextBox textBox_TrackerIP;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_ConnectTracker;
        private System.Windows.Forms.Button button_ConnectRob;
        private System.Windows.Forms.Button button_GetStatus;
        private System.Windows.Forms.GroupBox GB_Marker;
        private System.Windows.Forms.ComboBox comboBox_Marker;
        private System.Windows.Forms.Button button_SetMarker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_Format;
        private System.Windows.Forms.Button button_SetFormat;
        private System.Windows.Forms.GroupBox GB_Log;
        private System.Windows.Forms.CheckedListBox checkedListBox_Verbosity;
        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.Button button_Calibrate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_GoHome;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox checkedListBox_DoFLock;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TrackBar trackBar_Speed;
        private System.Windows.Forms.Button button_GetPos;
    }
}

