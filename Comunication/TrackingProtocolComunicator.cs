using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace LapRob
{
    public struct TrackerValue {
        public bool matrix;
        public float[,] values;
        public float timestamp;
        public bool visibility;
        public float quality;
        public TrackerValue(bool matrix,float[,] values, float timestamp,bool visibility, float quality){
            this.matrix = matrix;
            this.values = values;
            this.timestamp = timestamp;
            this.visibility = visibility;
            this.quality = quality;
        }
        
    }
    class TrackingProtocolComunicator
    {
        private const string SERVERTRUE = "ANS_TRUE\n";
        private const string SERVERPONG = "PONG";
        private const string MARKER = "MARKER";
        private const string GETSYSTEM = "CM_GETSYSTEM";
        private const string FORMAT = "FORMAT";
        private const string SETAVGMODE = "CM_SETAVGMODE";
        private const string SETVISMODE = "CM_SETVISMODE";
        private const string NEXTVALUE = "CM_NEXTVALUE";
        private const string NEXTVALUEBLOCK = "CM_NEXTVALUE_BLOCK";
        private const string PUSHVALUES = "CM_SETPUSHVALUES";
        private const string KILLSERVER = "CM_KILLSERVER";
        private const string GETVALUEAT = "CM_GETVALUEAT";
        private const string GETTRACKERS = "CM_GETTRACKERS";
        private const string GETTRACKERINFO = "CM_GETTRACKERINFO";
        private const string GETNUMVIRTUAL = "CM_GETNUMVIRTUAL";
        private const string PING = "CM_PING";
        private const string SETLOGLEVEL = "CM_SETLOGLEVEL";
        private const string GETVERSION = "CM_GETREVISION";
        private const string QUIT = "CM_QUITCONNECTION";
        private const string SETADDINFO = "CM_SETADDINFO";
        private const string GETSTROBEMODE = "CM_GETSTROBEMODE";
        private const string SETSTROBEMODE = "CM_SETSTROBEMODE";
        private const string GETSTROBEVALUE = "CM_GETSTROBEVALUE";

        private string[] AVGMODES = { " AVERAGE,", " WEIGHTEDSUM,", " EXPSMOOTHING," };
        private string[] LOGMODES = { " LOGLEVEL_QUIET", " LOGLEVEL_ERROR", " LOGLEVEL_WARN", " LOGLEVEL_INFO", " LOGLEVEL_DEBUG" }; 

        private Dictionary<String, String> ANS;
        private IPAddress iPAddress;
        private int port;
        private TcpClient client;
        private NetworkStream stream;
        private byte[] writeBuffer;
        private byte[] readBuffer;
        private StringBuilder message;
        private bool connected = false;
        private string logPath;

        public TrackingProtocolComunicator(string logPath) {
            this.writeBuffer = new byte[1024];
            this.readBuffer = new byte[1024];
            this.message = new StringBuilder();
            this.logPath = logPath;

            ANS = new Dictionary<string, string>();

            ANS.Add(FORMAT, SERVERTRUE);
            ANS.Add(SETAVGMODE, SERVERTRUE);
            ANS.Add(SETVISMODE, SERVERTRUE);
            ANS.Add(PUSHVALUES, SERVERTRUE);
            ANS.Add(PING,SERVERPONG);
            ANS.Add(SETLOGLEVEL, SERVERTRUE);
            ANS.Add(SETSTROBEMODE, SERVERTRUE);
            ANS.Add(MARKER, SERVERTRUE);
        }

        private void SendMsg(String key, String paramters)
        {
            if (this.IsConnected())
            {
                String msg = key  + paramters+ "\r\n";
                ToLog(msg);
                Send(msg);
            }
            else
            {
                ToLog_Offline();
            }
        }

        private void SendMsg(String key)
        {
            SendMsg(key, "");
        }


        private Boolean CheckReceive(String key)
        {
            if (this.IsConnected())
            {
                String msg = Receive();
                ToLog(msg);
                return msg == ANS[key];
            }
            return false;
        }

        private String ReceiveMsg()
        {
            if (this.IsConnected())
            {
                String msg = Receive();
                ToLog(msg);
                return msg;
            }
            throw new Exception();
        }


        private String SendAndReceive(String key)
        {
            SendMsg(key);
            return ReceiveMsg();
        }

        private String SendAndReceive(String key, String parameters)
        {
            SendMsg(key, parameters);
            return ReceiveMsg();
        }

        private Boolean SendAndCheckReceive(String key)
        {
            SendMsg(key);
            return CheckReceive(key);
        }

        private Boolean SendAndCheckReceive(String key, String parameters)
        {
            SendMsg(key, parameters);
            return CheckReceive(key);
        }


        private void Send(String msg)
        {
            Array.Clear(writeBuffer, 0, writeBuffer.Length);
            writeBuffer = Encoding.ASCII.GetBytes(msg);
            stream.Write(writeBuffer, 0, writeBuffer.Length);
        }


        private String Receive()
        {
            try
            {
                int msgLength = 0;

                Array.Clear(readBuffer, 0, readBuffer.Length);
                message.Length = 0;

                msgLength = stream.Read(readBuffer, 0, readBuffer.Length);
                message.AppendFormat("{0}", Encoding.ASCII.GetString(readBuffer, 0, msgLength));

                return message.ToString();
            }
            catch (Exception e)
            {
                ToLog(e);
                throw e;
            }
        }


        public void SendDirectMsg(String msg)
        {
            Send(msg);
        }

        public String ReceiveDirectMsg()
        {
            return Receive();
        }

        private void ToLog(string msg)
        {
            string filename = "\\" + DateTime.Today + "-" + DateTime.Now + "-Tracker.txt";
            string path = Path.Combine(logPath, filename);
            path = ToSafeFileName(path);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path,true))
                file.WriteLine(DateTime.Now.ToString("t") + " " + msg + " \r\n");
            Console.WriteLine("Tracker:" + DateTime.Now.ToString("t") + " " + msg);
        }
        private string ToSafeFileName(string s)
        {
            return s
                .Replace("\\", "")
                .Replace("/", "")
                .Replace("\"", "")
                .Replace("*", "")
                .Replace(":", "")
                .Replace("?", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");
        }
        private void ToLog_Offline()
        {
            ToLog("system is offline ");
        }

        private void ToLog(Exception ex)
        {
            ToLog("Error: " + ex.ToString());
        }


        public bool IsConnected() {
            return this.connected;
        }

        public bool Connect(String iPAdress, String port)
        {
            return Connect(IPAddress.Parse(iPAdress), int.Parse(port));

        }

        public bool Connect(IPAddress iPAddress, int port)
        {
            if (!IsConnected())
            {
                try
                {
                    this.iPAddress = iPAddress;

                    this.port = port;
                    client = new TcpClient();

                    //Connect to robot
                    client.Connect(this.iPAddress, this.port);

                    //Create communication stream
                    stream = client.GetStream();
                    connected = true;

                }
                catch (Exception ex)
                {
                    ToLog(ex);
                    connected = false;
                    throw ex;
                }
            }
            return connected;
       }

        public Dictionary<string, List<string>> GetSystem() {
            String[] answers = SendAndReceive(GETSYSTEM).Split(' ');
            Dictionary<string, List<string>> sysParameters = new Dictionary<string, List<string>>();
            if (answers[0] == "ANS_TRUE")
            {
               
                for (int i = 1; i < answers.Length; i++)
                {
                    string key = answers[i].Split('=')[0];
                    List<string> values = new List<string>(answers[i].Split('=')[1].Split(';'));
                    sysParameters.Add(key, values);
                }
            }
            return sysParameters;
        }

        public bool chooseMarker(string marker) {
            SendMsg("",marker);
            return CheckReceive(MARKER);
        }

        public bool setFormatMatrix(bool markermode,bool framenumber) {
            String param = "_MATRIXROWWISE";
            if (markermode) {
                param += "_M";
            }
            if (framenumber) {
                param += "_FRAMES";
            }
            return SendAndCheckReceive(FORMAT, param);

        }

        public bool setFormatQuaternions(bool markermode, bool framenumber)
        {
            String param = "_QUATERNIONS";
            if (markermode)
            {
                param += "_M";
            }
            if (framenumber)
            {
                param += "_FRAMES";
            }
            return SendAndCheckReceive(FORMAT, param);
        }

        public bool SetAvgMode(int mode, int windowsize) {
            return SendAndCheckReceive(SETAVGMODE, AVGMODES[mode] + windowsize);
        }

        public bool SetVisMode(int visisbilityFlag) {
            return SendAndCheckReceive(SETVISMODE, " " + visisbilityFlag);
        }

        private TrackerValue Reformat(String [] msg) {
            float[,] values;
            bool matrix;
            if (msg.Length > 10)
            {
                matrix = true;
                values = new float[4, 3];
                for (int i = 2; i < msg.Length-2; i++)
                {
                    values[(i - 2) / 3, (i - 2) % 3] = float.Parse(msg[i]);
                }
            }
            else {
                matrix = false;
                values = new float[2, 4];
                for (int i = 2; i < msg.Length-1; i++)
                {
                    values[(i - 2) / 4, (i - 2) % 4] = float.Parse(msg[i]);
                }
            }
            return new TrackerValue(matrix,values, float.Parse(msg[0]), msg[1].ToCharArray()[0]=='y', float.Parse(msg[msg.Length - 2]));
        }


        public TrackerValue NextValue() {
            string s = SendAndReceive(NEXTVALUE).Replace('.', ',');
            return Reformat(s.Split(' '));
        }

        public TrackerValue NextValueBlock()
        {
            return Reformat(SendAndReceive(NEXTVALUEBLOCK).Split(' '));
        }

        public bool SetPushValues(bool push) {
            if (push)
            {
                return SendAndCheckReceive(PUSHVALUES, " ON");
            }
            else {
                return SendAndCheckReceive(PUSHVALUES, " OFF");
            }
        }

        public void KillServer() {
            this.SendAndReceive(KILLSERVER);
        }

        public TrackerValue GetValueAt(float timestamp) {
            return Reformat(SendAndReceive(GETVALUEAT, " " + timestamp).Split(' '));
        }

        public List<string> GetTrackers() {
            return new List<string>(SendAndReceive(GETTRACKERS).Split(';'));

        }
        public string GetTrackerInfo(string name) {
            return SendAndReceive(GETTRACKERINFO, " " + name);
        }

        public int GetNumVirtual(string tracker) {
            return int.Parse(SendAndReceive(GETNUMVIRTUAL, " " + tracker));
        }
        public bool Ping() {
            return SendAndCheckReceive(PING);
        }

        public bool SetLogLevel(int level) {
            return SendAndCheckReceive(SETLOGLEVEL, LOGMODES[level]);
        }
        public String GetVersion() {
            return SendAndReceive(GETVERSION);
        }
        public bool Disconnect() {
            if (this.connected)
            {
                try
                {
                    SendAndReceive(QUIT);
                    connected = false;
                    stream.Close();
                    client.Close();
                }
                catch (Exception ex)
                {
                    ToLog(ex);
                    connected = true;
                    throw ex;
                }
            }
            return !this.connected;
        }

        public void SetAddInfo(bool on) {
            if (on) {
                SendMsg(SETADDINFO, " on");
            }
            else
            {
                SendMsg(SETADDINFO, " off");
            }
        }

        public int GetStrobeMode() {
            return int.Parse(SendAndReceive(GETSTROBEMODE));
        }

        public bool SetStrobeMode(int mode) {
            return SendAndCheckReceive(SETSTROBEMODE, " " + mode);
        }

        public int GetStrobeValue() {
            return int.Parse(SendAndReceive(GETSTROBEVALUE));
        }
    }


}
