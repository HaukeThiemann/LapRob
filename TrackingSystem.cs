using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace LapRob
{
    class TrackingSystem
    {
        private TrackingProtocolComunicator TrackCom;
        private float Protocol;
        private float Revision;
        private int miss = 0;
        private int treshhold=100;
        string [] marker;
        private int Misscount {
            set {
                if (value>0&&value<treshhold) {
                    miss = value;
                }
                if (value > treshhold) {
                    warn();
                }
            }
            get{
                return miss;
            }
        }
       

        public TrackingSystem(string logPath)
        {
            TrackCom = new TrackingProtocolComunicator(logPath);
        }

        private void init(string logPath) {
            TrackCom = new TrackingProtocolComunicator(logPath);
        }

        public bool Connect(IPAddress ip, int port){
            if (TrackCom.Connect(ip, port))
            {
                refreshStatus();
                return true;
            }
            return false;
        }
        public bool chooseMarker(string marker){
            if (this.marker.Contains(marker)) {
                return TrackCom.chooseMarker(marker);
            }
            return false;
        }
        public bool chooseFormat(string format,bool markermode, bool framenumber){
            if(format=="Matrix"){
                return TrackCom.setFormatMatrix(markermode,framenumber);
            }
            return TrackCom.setFormatQuaternions(markermode,framenumber);
        }

        public bool Disconnect() {
            return TrackCom.Disconnect();
        }

        public string  GetStatus(){
            refreshStatus();
            return "Protocol:" + Protocol + "\n Revison:" + Revision + "\n Tracker:" + marker.ToString();
        }

        private void refreshStatus() {
            try
            {
                Dictionary<string, List<string>> info = TrackCom.GetSystem();
                Protocol = float.Parse(info["Protocol"].ToArray()[0]);
                Revision = float.Parse(info["Revision"].ToArray()[0]);
                marker = info["Tracker"].ToArray<string>();
            }
            catch (Exception e) {
                
            }
        }

        public float [,] GetPosition(){
            TrackerValue trackerValue = TrackCom.NextValue();
            if(!trackerValue.visibility){
                Misscount++;
            }
            else{
                Misscount--;
             }
            return trackerValue.values;
        }

        public string [] GetMarker() {
            return marker;
        }

        public bool setLogLevel(int level){
            return TrackCom.SetLogLevel(level);
        }

        public bool IsConnected() {
            return TrackCom.IsConnected();
        }

        public void warn() { 
            // TODO
        }

    }
}
