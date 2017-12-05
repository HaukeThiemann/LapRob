using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LapRob
{
    public partial class MainWindow : Form
    {
        private bool isCalibrated = false;
        private bool isRobotConnected = false,isTrackerConnected=false;
        private LapRobLogic lapRob = new LapRobLogic();
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Events
        private void button_ConnectRob_Click(object sender, EventArgs e)
        {
            if (lapRob.IsRobotConnected())
            {
                if (lapRob.DisconnectRobot()) {
                    
                    button_ConnectRob.Text = "Connect";
                    isRobotConnected = false;
                    ToLog("Robot Disonnected");
                }
        
            }
            else
            {
                if (lapRob.ConnectRobot(IPAddress.Parse(textBox_RobIP.Text), int.Parse(textBox_RobPort.Text))) {
                    button_ConnectRob.Text = "Disconnect";
                    isRobotConnected = true;
                    ToLog("Robot Connected");
                }     
            }
        }

        private void button_ConnectTracker_Click(object sender, EventArgs e)
        {
            if (lapRob.IsTrackerConnected())
            {
                if (lapRob.DisconnectTracker()) {
                    button_ConnectTracker.Text = "Connect";
                    isTrackerConnected = false;
                    ToLog("Tracker Disconnected");
                }
            }
            else
            {
                if (lapRob.ConnectTracker(IPAddress.Parse(textBox_TrackerIP.Text), int.Parse(textBox_TrackerPort.Text))) {
                    button_ConnectTracker.Text = "Disconnect";
                    //TODELETE
                    if (lapRob.SetMarker("AURORA_36997C02")) {
                        if (lapRob.SetFormat("Matrix",false,false)) {
                            ToLog("Tracker Connected");
                            isTrackerConnected = true;
                        }
                    }

                    //UNTIL HERE
                }
            }
        }

        private void button_SetMarker_Click(object sender, EventArgs e)
        {
            if (isConnected())
            {
                lapRob.SetMarker(comboBox_Marker.SelectedItem.ToString());
            }
        }

        private void button_SetFormat_Click(object sender, EventArgs e)
        {
            if (isConnected())
            {
                lapRob.SetFormat(comboBox_Format.SelectedItem.ToString(), false, false);//markermode framenumber
            }
        }

        private void button_Calibrate_Click(object sender, EventArgs e)
        {
            if (isConnected()) { 
                if (isCalibrated)
                {   
                    DialogResult reCalibrate = MessageBox.Show("The system has already been calibrated. Do you want to re-calibrate?", "Re-Calibrate", MessageBoxButtons.YesNo);
                    if (reCalibrate == DialogResult.Yes) {
                        //Calibrate();
                    }
                }
                else
                {
                    //Calibrate();
                    button_Calibrate.Text = "Re-Calibrate";
                }
            }
        }

        private void button_GoHome_Click(object sender, EventArgs e)
        {
            if (isConnected())
            {
                lapRob.GoHome();
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            //Start();
        }

        private void trackBar_Speed_ValueChanged(object sender, EventArgs e)
        {
            if (isConnected()) {
                if (lapRob.SetRobotSpeed(trackBar_Speed.Value)) {
                    ToLog("Speed set to " + trackBar_Speed);
                }
            }
        }

        private void checkedListBox_Verbosity_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isConnected())
            {
                int v = 0;
                if (checkedListBox_Verbosity.GetItemChecked(2))
                {
                    v = 4;
                    checkedListBox_Verbosity.SetItemChecked(0, true);
                    checkedListBox_Verbosity.SetItemChecked(1, true);
                }
                else if (checkedListBox_Verbosity.GetItemChecked(2))
                {
                    v = 2;
                    checkedListBox_Verbosity.SetItemChecked(0, true);
                }
                else if (checkedListBox_Verbosity.GetItemChecked(2))
                {
                    v = 1;
                }
                if (lapRob.SetVerbosity(v))
                {
                    ToLog("Verbosity succesfully set to " + v);
                }
            }
        }

        private void checkedListBox_DoFLock_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isConnected())
            {
                lapRob.LockDoF(checkedListBox_DoFLock.GetItemChecked(0), checkedListBox_DoFLock.GetItemChecked(1));
            }
        }

        private void button_GetStatus_Click(object sender, EventArgs e)
        {
            if (isConnected())
            {
                ToLog(lapRob.GetStatus());
            }
        }

        private void button_GetPos_Click(object sender, EventArgs e)
        {
            if (isConnected())
            {
                ToLog(lapRob.GetPosition());
            }
        }

        #endregion

        #region Functions
        private void ToLog_Offline()
        {
            ToLog(" system is offline \r\n");
        }

        private void ToLog(Exception ex)
        {
            ToLog(ex.Message);
        }

        private void ToLog(string msg)
        {
            Console.WriteLine("Window:"+ DateTime.Now.ToString("t") + " " + msg);
        }
        private void ToLog(string[] msgs)
        {
            foreach (string msg in msgs)
            {
                ToLog(msg);
            }
        }
        private bool isConnected() {
            return isRobotConnected && isTrackerConnected;
        }

       
        #endregion

        private void textBox_Log_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
