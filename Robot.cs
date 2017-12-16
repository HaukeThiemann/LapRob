using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace LapRob
{
    class Robot
    {
        private float[] home;
        private RobotProtocolComunicator robCom;
        private string robot;
        private string status;
        private int speed;

        public Robot(float[] home,string status,string logPath) {
            Init(home, status, logPath);
        }
        public Robot(float[] home,string status, IPAddress iPAddress, int port, string logPath) {
            Init(home, status, logPath);
            this.robCom.Connect(iPAddress,port);
        }

        private void Init(float[] home,string status, string logPath)
        {
            this.home = home;
            this.robCom = new RobotProtocolComunicator(logPath);
            this.status = status;
            this.speed = 5;
            
        }

        public bool IsConnected() {
            return robCom.IsConnected();
        }

        public bool Connect(IPAddress iPAddress, int port) {
            if (this.robCom.Connect(iPAddress, port)) {
                this.GetRobot();
                SetSpeed(speed);
                SetStatus(status);
                return true;
            }
            return false;
        }

        public bool Disconnect() {
            if (robCom.Disconnect()) {
                this.robot =null;
                return true;
            }
            return false;
        }

        public bool Reconnect() {
            return robCom.Reconnect();
        }

        public bool GoHome(){
            return robCom.MovePTPJoints(home);
        }

        public bool SetSpeed(int speed)
        {
            if (speed > -1 && speed < 11) {
                this.speed = speed;
                return robCom.SetAdeptSpeed(speed);
            }
            return false;
        }

        public string GetRobot() {
            return robot == null ? robot : robot = robCom.GetRobot();
        }
        
        public float[] GetPositionJoints() {
            return robCom.GetPositionJoints();
        }
        public double[][] GetPositionMatrix() {
            return robCom.GetPositionHomRowWise();
        }

        public bool SetVerbosity(int verbosity) {
            return this.robCom.SetVerbosity(verbosity);
        }

        public bool MoveHomRowWise(float[,] Coordinates) {
            return robCom.MoveRTHomRowWise(Coordinates);
        }

        public bool SetStatus(string status) {
            return robCom.MoveMinChangeRowWiseStatus(GetPositionMatrix(), status);
        }
        public string GetStatus() {
            return "Robot:" + GetRobot()+"\n Status:"+robCom.GetStatus();
        }
    }
}
