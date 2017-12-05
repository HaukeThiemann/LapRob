using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace LapRob
{
    class LapRobLogic
    {
        private Robot robot;
        private TrackingSystem trackingSystem;
        private bool translation=false;
        private bool rotation = false;
        //GUI

        public LapRobLogic() {
            float[] home = { 0, -90, 0, 0, 0, 0 };
            string status = "flip lefty";
            string logPath = "C:\\Users\\hauke\\Desktop\\Praktikum\\LapRob\\Logs";
            robot = new Robot(home,status,logPath);
            trackingSystem = new TrackingSystem(logPath);
        }
        public bool ConnectRobot(String ip,String port){
            return robot.Connect(IPAddress.Parse(ip),int.Parse(port));
        }
        public bool ConnectRobot(IPAddress ip, int port)
        {
            return robot.Connect(ip,port);
        }
        public bool DisconnectRobot() {
            return robot.Disconnect();
        }
        public bool ConnectTracker(String ip, String port)
        {
            return trackingSystem.Connect(IPAddress.Parse(ip), int.Parse(port));
        }
        public bool ConnectTracker(IPAddress ip, int port)
        {
            return trackingSystem.Connect(ip,port);
        }
        public bool DisconnectTracker()
        {
            return trackingSystem.Disconnect();
        }
        public bool DisconnectAll() {
            return DisconnectRobot() && DisconnectTracker();
        }
        public String GetStatus() {
            return robot.GetStatus() + trackingSystem.GetStatus();
        }
        public bool SetMarker(string marker){
             return trackingSystem.chooseMarker(marker);
        }
        public bool SetFormat(string format,bool markermode, bool framenumber){
            return trackingSystem.chooseFormat(format,markermode,framenumber);
        }
        public bool SetVerbosity(int verbosity){
            return robot.SetVerbosity(verbosity) && trackingSystem.setLogLevel(verbosity);
        }
        public bool SetRobotSpeed(int speed) {
            return robot.SetSpeed(speed);
        }
        public bool GoHome() {
            return robot.GoHome();
        }
        public bool MoveHomRowWise(float [,] matrix) {
            return robot.MoveHomRowWise(matrix);
        }
        public bool ToggleRotation(){
            return rotation = !rotation;
        }
        public bool ToggleTranslation()
        {
            return translation = !translation;
        }
        public String GetPosition() {
            return "Robot:" + robot.GetPositionMatrix() + "\n Tracker:" + trackingSystem.GetPosition();
        }
        public bool LockRotation(bool locking) {
            return rotation = locking;
        }
        public bool LockTranslation(bool locking)
        {
            return translation = locking;
        }
        public bool LockDoF(bool rotaionLock, bool translationLock) {
            return LockRotation(rotaionLock) && LockTranslation(translationLock);
        }
        public bool IsRobotConnected() {
            return  robot.IsConnected();
        }
        public bool IsTrackerConnected() {
            return trackingSystem.IsConnected();
        }
        public string[] GetMarker() {
            return trackingSystem.GetMarker();
        }
    }
}
