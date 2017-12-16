using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace LapRob
{
    public class RobotProtocolComunicator
    {
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
        public RobotProtocolComunicator(string logPath)
        {

            this.writeBuffer = new byte[1024];
            this.readBuffer = new byte[1024];
            this.message = new StringBuilder();
            this.logPath = logPath;

            ANS = new Dictionary<string, string>();

            ANS.Add("Hello Robot","accepted\n");
            ANS.Add("GetRobot", null);
            ANS.Add("IsAdept", "true\n");
            ANS.Add("GetVersion", null);
            ANS.Add("Quit", "bye!\n");
            ANS.Add("GetTimeStamp", null);
            ANS.Add("PingRobot", null);
            ANS.Add("CMPING", "PONG\n");
            ANS.Add("SetVerbosity", "true\n");
            ANS.Add("SetAdeptSpeed", "true\n");
            ANS.Add("SetAdeptAccel", "true\n");
            ANS.Add("GetJointsMaxChange", null);
            ANS.Add("SetJointsMaxChange", "");
            ANS.Add("SetSingleJointMaxChange", "true\n");
            ANS.Add("GetJointsMaxTurnMax", null);
            ANS.Add("SetJointsMaxTurnMax", "true\n");
            ANS.Add("SetSingleJointMaxTurnMax", "true\n");
            ANS.Add("GetJointsMinChange", "true\n");
            ANS.Add("GetJointsMaxTurnMin", null);
            ANS.Add("SetJointsMaxTurnMin", "true\n");
            ANS.Add("SetSingleJointMaxTurnMin", "true\n");
            ANS.Add("ResetJointsMaxChange", "true\n"); //?? parameters for what?
            ANS.Add("ResetJointsMaxTurn", "true\n"); // ?? parameters for what?
            ANS.Add("MoveMinChangeRowWiseStatus", "true\n");
            ANS.Add("MovePTPJoints", "true\n");
            ANS.Add("MoveRTHomRowWise", "true\n");
            ANS.Add("GetPositionHomRowWise", null);
            ANS.Add("GetPositionJoints", null);
            ANS.Add("GetStatus", null);
        }

        private void SendMsg(String key, String paramters)
        {
            if (this.IsConnected())
            {
                String msg = key + " " + paramters;
                ToLog(msg);
                Send(msg);
            }
            else
            {
                ToLog_Offline();
            }
        }

        private  void SendMsg(String key) {
            SendMsg(key,"");
        }


        private Boolean CheckReceive(String key) {
            if (this.IsConnected()) {
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
            return null;
        }


        private String SendAndReceive(String key) {
            SendMsg(key);
            return ReceiveMsg();
        }

        private String SendAndReceive(String key, String parameters)
        {
            SendMsg(key, parameters);
            return ReceiveMsg();
        }

        private Boolean SendAndCheckReceive(String key) {
            SendMsg(key);
            return CheckReceive(key);
        }

        private Boolean SendAndCheckReceive(String key,String parameters)
        {
            SendMsg(key,parameters);
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
            catch (Exception e) {
                ToLog(e);
                throw e;
            }
        }


        public void SendDirectMsg(String msg) {
            Send(msg);
        }

        public String ReceiveDirectMsg() {
            return Receive();
        }

        private void ToLog(string msg)
        {
            string filename =DateTime.Today + "-" + DateTime.Now + "-Robot.txt";
            string path = Path.Combine(logPath, "\\" + DateTime.Today + "-" + DateTime.Now + "-Tracker.txt");
            path = ToSafeFileName(path);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path,true))
                file.WriteLine(DateTime.Now.ToString("t") + " " + msg + " \r\n");
            Console.WriteLine("Robot:" + DateTime.Now.ToString("t") + " " + msg);
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

        public Boolean Connect(String iPAdress, String port) {
            return Connect(IPAddress.Parse(iPAdress),int.Parse(port));

        }

        public Boolean Connect(IPAddress iPAddress, int port)
        {
            if (!this.connected)
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
                    Receive();
                    connected = SendAndCheckReceive("Hello Robot");

                }
                catch (Exception ex)
                {
                    ToLog(ex);
                    connected = false;
                    throw ex;
                }
            }
            return this.connected;
        }

        public String GetRobot()
        {
            return SendAndReceive("GetRobot");
        }

        public Boolean IsAdept() {
            return SendAndCheckReceive("IsAdept");
        }

        public String GetVersion() {
            return SendAndReceive("GetVersion");
        }

        public Boolean Disconnect()
        {
            if (this.connected)
            {
                try
                {
                    connected = SendAndCheckReceive("Quit");
                    if (!connected) { 
                        stream.Close();
                        client.Close();
                    }

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

        public bool Reconnect() {
            if (iPAddress != null) {
                return this.Connect(this.iPAddress,this.port);
            }
            return false;
        }

        public String GetTimeStamp() {
            return SendAndReceive("GetTimeStamp");
        }

        public float PingRobot(int pings, int waittimeInMs) {
            return float.Parse(SendAndReceive("PingRobot"," "+pings+" "+waittimeInMs));
        }

        public Boolean CMPing() {
            return SendAndCheckReceive("CMPING");
        }

        public Boolean IsConnected()
        {
            return this.connected;
        }

        public Boolean SetVerbosity(int verbosity) {
            if (verbosity > -1 && verbosity < 5)
            {
                return SendAndCheckReceive("SetVerbosity", " " + verbosity);
            }
            return false;
        }

        public Boolean SetAdeptFine(int accuracy) {
            if (accuracy > 0 && accuracy < 101) {
                return SendAndCheckReceive("SetAdeptFine", " " + accuracy);
            }
            return false;
        }

        public Boolean SetAdeptSpeed(int speed) {
            //Set Adapt speed
            if (speed > -1 && speed < 121)
            {
                return SendAndCheckReceive("SetAdeptSpeed", " " + speed);
            }
            return false;
        }

        public Boolean SetAdeptAccel(int acceleration) {
            if (acceleration > -1 && acceleration < 121) {
                return SendAndCheckReceive("SetAdeptAccel", " " + acceleration);
            }
            return false;
        }


        public float[] GetJointsMaxChange() {
            String msg = SendAndReceive("GetJointsMaxChange");
            String [] sJoints = msg.Split(' ');
            float [] joints = new float[sJoints.Length];
            for (int i= 0;i < sJoints.Length;i++) {
                joints[i] = float.Parse(sJoints[i]);
            }
            return joints;
        }

        public Boolean SetJointsMaxChange(int[] jointsMaxChange) {
            String parameters = "";
            foreach (int j in jointsMaxChange) {
                parameters += " " + j;
            }
            return SendAndCheckReceive("SetJointsMaxChange", parameters);
        }

        public Boolean SetSingleJointMaxChange(int joint,int change) {
            return SendAndCheckReceive("SetSingleJointMaxChange", " " + joint + " " + change);
        }

        public float[] GetJointsMaxTurnMax()
        {
            String msg = SendAndReceive("GetJointsMaxTurnMax");
            String[] sJoints = msg.Split(' ');
            float[] joints = new float[sJoints.Length];
            for (int i = 0; i < sJoints.Length; i++)
            {
                joints[i] = float.Parse(sJoints[i]);
            }
            return joints;
        }
        public Boolean SetJointsMaxTurnMax(int[] jointsMaxChange)
        {
            String parameters = "";
            foreach (int j in jointsMaxChange)
            {
                parameters += " " + j;
            }
            return SendAndCheckReceive("SetJointsMaxTurnMax", parameters);
        }

        public Boolean SetSingleJointMaxTurnMax(int joint, int change)
        {
            return SendAndCheckReceive("SetSingleJointMaxTurnMax", " " + joint + " " + change);
        }

        public float[] GetJointsMinChange()
        {
            String msg = SendAndReceive("GetJointsMinChange");
            String[] sJoints = msg.Split(' ');
            float[] joints = new float[sJoints.Length];
            for (int i = 0; i < sJoints.Length; i++)
            {
                joints[i] = float.Parse(sJoints[i]);
            }
            return joints;
        }

        public float[] GetJointsMaxTurnMin()
        {
            String msg = SendAndReceive("GetJointsMaxTurnMin");
            String[] sJoints = msg.Split(' ');
            float[] joints = new float[sJoints.Length];
            for (int i = 0; i < sJoints.Length; i++)
            {
                joints[i] = float.Parse(sJoints[i]);
            }
            return joints;
        }
        public Boolean SetJointsMaxTurnMin(int[] jointsMaxChange)
        {
            String parameters = "";
            foreach (int j in jointsMaxChange)
            {
                parameters += " " + j;
            }
            return SendAndCheckReceive("SetJointsMaxTurnMin", parameters);
        }

        public Boolean SetSingleJointMaxTurnMin(int joint, int change)
        {
            return SendAndCheckReceive("SetSingleJointMaxTurnMax", " " + joint + " " + change);
        }

        public Boolean ResetMaxTurn(int joint, int change)
        {
            return SendAndCheckReceive("ResetMaxTurn", " " + joint + " " + change);
        }

        public Boolean ResetMaxChange(int joint, int change)
        {
            return SendAndCheckReceive("ResetMaxChange", " " + joint + " " + change);
        }

        public Boolean MoveMinChangeRowWiseStatus(float[,] Coordinates, string parameters) {

            string pos = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int x = (int)Math.Round(Coordinates[i, j],0);
                    pos += " " + x;
                }
            }

            return SendAndCheckReceive("MoveMinChangeRowWiseStatus", pos+" "+ parameters);
        }

        public Boolean MoveMinChangeRowWiseStatus(float[,] Coordinates, Boolean flip, Boolean noFlip,Boolean toggleHand, Boolean noToggleHand, Boolean up, Boolean down,Boolean toggleElbow,Boolean noToggleElbow,Boolean lefty, Boolean righty, Boolean toggleArm,Boolean noToggleArm) {
            String parameters = "";

            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 5; j++) {
                    parameters += " " + Coordinates[i, j];
                }
            }

            if (flip) {
                parameters += " flip";
            }
            else if (noFlip)
            {
                parameters += " noflip";
            }
            if (toggleHand)
            {
                parameters += " toggleHand";
            }
            else if (noToggleHand)
            {
                parameters += " noToggleHand";
            }
            if (up)
            {
                parameters += " up";
            }
            else if (down)
            {
                parameters += " down";
            }
            if (toggleElbow)
            {
                parameters += " toggleElbow";
            }
            else if(noToggleElbow)
            {
                parameters += " noToggleElbow";
            }
            if (lefty)
            {
                parameters += " lefty";
            }
            else if (righty)
            {
                parameters += " righty";
            }
            if (toggleArm)
            {
                parameters += " toggleArm";
            }
            else if (noToggleArm)
            {
                parameters += " noToggleArm";
            }

            return SendAndCheckReceive("MoveMinChangeRowWiseStatus", parameters);
        }

        public Boolean MovePTPJoints(int joint1, int joint2, int joint3, int joint4, int joint5, int joint6) {
            String parameters =  " " + joint1 + " " + joint2 + " " + joint3 + " " + joint4 + " " + joint5 + " " + joint6;
            return SendAndCheckReceive("MovePTPJoints",parameters);
        }

        public Boolean MovePTPJoints(float[] joints)
        {
            String parameters="";
            for (int i = 0; i < joints.Length; i++) {
                parameters += " " + joints[i];
            }
            return SendAndReceive("MovePTPJoints", parameters)!=null;
        }

        public Boolean MoveRTHomRowWise(float[,] Coordinates) {
            String parameters="";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    parameters += " " + Coordinates[i, j];
                }
            }
            return SendAndCheckReceive("MoveRTHomRowWise", parameters);
        }
 
        public double[][] GetPositionHomRowWise() {
            double[][] pos = new double[4][];
            pos[0] = new double[4];
            pos[1] = new double[4];
            pos[2] = new double[4];
            pos[3] = new double[] { 0, 0, 0, 1};
            string [] sPos = SendAndReceive("GetPositionHomRowWise").Split(' ');
            for (int i = 0; i < sPos.Length; i++) {
                pos[i / 3][i % 4]= double.Parse(sPos[i].Replace('.',','));
            }
            
            return pos;
        }

        public float[] GetPositionJoints() {
            String[] sJoints = SendAndReceive("GetPositionJoints").Split(' ');
            float[] joints = new float[sJoints.Length];
            for (int i=0;i<sJoints.Length;i++) {
                joints[i] = float.Parse(sJoints[i]);
            }
            return joints;
        }
        public String GetStatus() {
            return SendAndReceive("GetStatus");
        }
    }
}
