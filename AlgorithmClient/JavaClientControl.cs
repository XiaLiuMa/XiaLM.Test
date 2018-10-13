using AlgorithmClient.JavaProtocol;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmClient
{
    public class JavaClientControl
    {
        /// <summary>
        /// 功能码：查询人脸
        /// </summary>
        private const short SELECTFACE = 0x05;
        /// <summary>
        /// 功能码：上传人脸
        /// </summary>
        private const short UPDATEFACE = 0x04;
        /// <summary>
        /// 功能码：删除人脸
        /// </summary>
        private const short DELETEFACE = 0x06;
        /// <summary>
        /// 功能码：清空人脸
        /// </summary>
        private const short CLEARFACE = 0x07;
        /// <summary>
        /// 功能码：人脸识别
        /// </summary>
        private const short IDENTIFYFACE = 0x03;
        /// <summary>
        /// 功能码：区域检测
        /// </summary>
        private const short REGIONDETECTION = 0x20;
        /// <summary>
        /// 功能码：上传行人配置
        /// </summary>
        private const short UPLOADCONFIG = 0x21;

        private readonly static object objLock = new object();
        private static JavaClientControl instance;

        public static JavaClientControl GetInstance()
        {
            if (instance == null)
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new JavaClientControl();
                    }
                }
            }
            return instance;
        }

        public JavaClientControl()
        {
            ServerCommunicationRealize.GetInitialize().DataReceived += JavaClientControl_DataReceived;
        }

        public void ConnectServer(string ip, string port)
        {
            ServerCommunicationInitialize.GetInitialize().Init(ip, int.Parse(port));
        }

        private void JavaClientControl_DataReceived(short code, byte[] bytes)
        {
            try
            {
                WriteLogRealize.GetInstance().WriteTo_rTxtJavaCode(false, code, bytes);
                switch (code)
                {
                    case SELECTFACE: //查询人脸名单
                        var str01 = Encoding.UTF8.GetString(bytes);
                        byte byte01 = (byte) int.Parse(str01);
                        byte selectCode = 0x05;
                        RobotClientControl.GetInstance().SendMsg(selectCode, new byte[] { byte01 });
                        ////模拟数据返回
                        //List<SelectFaceInfo> tempList = new List<SelectFaceInfo>()
                        //{
                        //    new SelectFaceInfo()
                        //    {
                        //        type = "white",
                        //        filename = "123.jpg",
                        //        idnumber = "10011",
                        //        index = 1,
                        //        name = "张山",
                        //        serialnumber = "1",
                        //        sex = "男",
                        //        toal = 2
                        //    },
                        //    new SelectFaceInfo()
                        //    {
                        //        type = "black",
                        //        filename = "234.jpg",
                        //        idnumber = "10021",
                        //        index = 2,
                        //        name = "李四",
                        //        serialnumber = "2",
                        //        sex = "男",
                        //        toal = 2
                        //    }
                        //};
                        //string jsonStr1 = UtilityJson.SerializeObject(tempList);
                        //byte[] bytes1 = Encoding.UTF8.GetBytes(jsonStr1);
                        //SendDataToJava(SELECTFACE, bytes1).Employ();
                        break;
                    case UPDATEFACE: //上传人脸名单
                        byte updateCode = 0x04;
                        RobotClientControl.GetInstance().SendMsg(updateCode, bytes);
                        //模拟数据返回
                        //SendDataToJava(UPDATEFACE, Encoding.UTF8.GetBytes("0x1F")).Employ();
                        break;
                    case DELETEFACE: //删除人脸名单
                        byte deleteCode = 0x06;
                        //var str02 = Encoding.UTF8.GetString(bytes);
                        //byte byte02 = (byte)int.Parse(str02);
                        RobotClientControl.GetInstance().SendMsg(deleteCode, bytes);
                        //模拟数据返回
                        //SendDataToJava(DELETEFACE, Encoding.UTF8.GetBytes("0x1F")).Employ();
                        break;
                    case CLEARFACE: //清空人脸名单
                        byte clearCode = 0x07;
                        RobotClientControl.GetInstance().SendMsg(clearCode, bytes);
                        //模拟数据返回
                        //SendDataToJava(CLEARFACE, Encoding.UTF8.GetBytes("0x1F")).Employ();
                        break;
                    case IDENTIFYFACE: //人脸识别
                        byte identifyCode = 0x03;
                        RobotClientControl.GetInstance().SendMsg(identifyCode, bytes);
                        //模拟数据返回
                        //SendDataToJava(IDENTIFYFACE, Encoding.UTF8.GetBytes("0x1F")).Employ();
                        //short tempshort1 = 0x08;    //报警
                        //string filename = @"C:\Users\Administrator\Desktop\20180811113140.jpg";
                        //byte[] tempBytes = File.ReadAllBytes(filename);
                        ////bas64编码
                        //string base64txt = Convert.ToBase64String(tempBytes);
                        //AlarmFaceInfo alarmFaceInfo = new AlarmFaceInfo()
                        //{
                        //    name = "夏六马",
                        //    robotnumber = 1,
                        //    serialnumber = "1",
                        //    type = "white",
                        //    imagebytes = base64txt
                        //};
                        //string jsonStr2 = UtilityJson.SerializeObject(alarmFaceInfo);
                        //byte[] bytes2 = Encoding.UTF8.GetBytes(jsonStr2);
                        //SendDataToJava(tempshort1, bytes2).Employ();
                        break;
                    case REGIONDETECTION: //区域监测
                        byte detectionCode = 0x20;
                        RobotClientControl.GetInstance().SendMsg(detectionCode, bytes);
                        break;
                    case UPLOADCONFIG: //上传人脸名单
                        byte uploadconfigCode = 0x21;
                        RobotClientControl.GetInstance().SendMsg(uploadconfigCode, bytes);
                        break;
                }
            }
            catch (Exception ex)
            {
                WriteLogRealize.GetInstance().WriteTo_rTxtLog("解析Java数据异常：" + ex.ToString());
            }
        }


        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="code">功能码</param>
        /// <param name="bs">正文</param>
        /// <returns></returns>
        public async Task SendDataToJava(short code, byte[] bs)
        {
            WriteLogRealize.GetInstance().WriteTo_rTxtJavaCode(true, code, bs);
            await ServerCommunicationRealize.GetInitialize().Send(code, bs);
        }
    }
}
