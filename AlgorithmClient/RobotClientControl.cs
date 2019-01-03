using AlgorithmClient.Model;
using Newtonsoft.Json;
using System;
using System.Text;


/*

* ==============================================================================
  * CLR 版本：      4.0.30319.42000
  * 类 名 称：      RobotClientControl
  * 命名空间：      Maxvision.FaceClient.RobotClient
  * 文 件 名：      RobotClientControl
  * 创建时间：      2018/7/21 10:55:14
  * 作    者：      XLM
  * 修改时间：
  * 修 改 人：
  * 说    明：      机器人端客户端控制器
* ==============================================================================
*/
namespace AlgorithmClient
{
    /// <summary>
    /// 机器人端客户端控制器
    /// </summary>
    public class RobotClientControl
    {
        /// <summary>
        /// 功能码：心跳
        /// </summary>
        private const byte CODE_HEARTBEAT = 0x01;
        /// <summary>
        /// 功能码：跟随
        /// </summary>
        private const byte CODE_FOLLOW = 0x02;
        /// <summary>
        /// 功能码：人脸功能
        /// </summary>
        private const byte CODE_IDENTIFY = 0x03;
        /// <summary>
        /// 功能码：人脸上传
        /// </summary>
        private const byte CODE_UPDATE = 0x04;
        /// <summary>
        /// 功能码：查询名单
        /// </summary>
        private const byte CODE_SELECT = 0x05;
        /// <summary>
        /// 功能码：名单删除
        /// </summary>
        private const byte CODE_DELETE = 0x06;
        /// <summary>
        /// 功能码：清空名单
        /// </summary>
        private const byte CODE_CLEAR = 0x07;
        /// <summary>
        /// 功能码：报警
        /// </summary>
        private const byte CODE_ALARM = 0x08;
        /// <summary>
        /// 功能码：跟随坐标
        /// </summary>
        private const byte CODE_FACELOCATION = 0x09;
        /// <summary>
        /// 功能码：行人检测
        /// </summary>
        private const byte CODE_DETECTION = 0x20;
        /// <summary>
        /// 功能码：上传行人配置
        /// </summary>
        private const byte CODE_UPDATECONFIG = 0x21;
        /// <summary>
        /// 功能码：下发配置图片
        /// </summary>
        private const byte CODE_ISSUECONFIG = 0x22;
        /// <summary>
        /// 功能码：下发行人报警
        /// </summary>
        private const byte CODE_ISSUEALARM = 0x23;
        private readonly static object objLock = new object();
        private static RobotClientControl instance;
        public static RobotClientControl GetInstance()
        {
            if (instance == null)
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new RobotClientControl();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="code">功能码</param>
        /// <param name="data">正文数据</param>
        public void ReceiveMsg(byte code, byte[] data)
        {
            try
            {
                switch (code)
                {
                    case CODE_HEARTBEAT:
                        WriteLogRealize.GetInstance().WriteTo_rTxtHeart(false, code, data);
                        break;
                    case CODE_FACELOCATION:
                        WriteLogRealize.GetInstance().WriteTo_rTxtOffset(CODE_FACELOCATION, data);
                        break;
                    case CODE_DETECTION:    //行人检测
                        WriteLogRealize.GetInstance().WriteTo_rTxtCode(false, code, data);
                        var str1 = BitConverter.ToString(data, 0).Replace("-", string.Empty).ToLower();
                        byte[] bytes1 = Encoding.UTF8.GetBytes(str1);
                        JavaClientControl.GetInstance().SendDataToJava((short)code, bytes1).Employ();
                        break;
                    case CODE_UPDATECONFIG: //上传配置
                        WriteLogRealize.GetInstance().WriteTo_rTxtCode(false, code, data);
                        var str2 = BitConverter.ToString(data, 0).Replace("-", string.Empty).ToLower();
                        byte[] bytes2 = Encoding.UTF8.GetBytes(str2);
                        JavaClientControl.GetInstance().SendDataToJava((short)code, bytes2).Employ();
                        break;
                    case CODE_ISSUECONFIG: //下发配置图片
                        WriteLogRealize.GetInstance().WriteTo_rTxtCode(false, code, data);
                        JavaClientControl.GetInstance().SendDataToJava((short)code, data).Employ();
                        break;
                    case CODE_ISSUEALARM: //下发行人报警
                        var tempStr1 = Encoding.UTF8.GetString(data);
                        PedestriansAlarm obj1 = JsonConvert.DeserializeObject<PedestriansAlarm>(tempStr1);
                        if (obj1 != null)
                            WriteLogRealize.GetInstance().WriteTo_rTxtLog(string.Format("机器人{0}发现X1:{1},Y1:{2},X2:{3},Y2:{4}处，有人{5}",obj1.Robotnumber,obj1.X1,obj1.Y1,obj1.X2,obj1.Y2,obj1.type));
                        WriteLogRealize.GetInstance().WriteTo_rTxtCode(false, code, data);
                        JavaClientControl.GetInstance().SendDataToJava((short)code, data).Employ();
                        break;
                    case CODE_FOLLOW:   //跟随
                        WriteLogRealize.GetInstance().WriteTo_rTxtCode(false, code, data);
                        byte followFail = 0x6F;
                        if (data[0].Equals(followFail))
                        {
                            SendMsg(CODE_FOLLOW, new byte[] { 0x5E });
                        }
                        break;
                    case CODE_SELECT:
                        WriteLogRealize.GetInstance().WriteTo_rTxtSelect(data);
                        WriteLogRealize.GetInstance().WriteTo_rTxtCode(false, code, data);
                        JavaClientControl.GetInstance().SendDataToJava((short)code, data).Employ();
                        break;
                    case CODE_ALARM:
                        var tempStr = Encoding.UTF8.GetString(data);
                        AlarmFaceInfo obj = JsonConvert.DeserializeObject<AlarmFaceInfo>(tempStr);
                        if (obj != null)
                            WriteLogRealize.GetInstance().WriteTo_rTxtLog(string.Format("机器人{0}发现{1}名单，人员编号为{2}", obj.robotnumber, obj.type, obj.serialnumber));
                        WriteLogRealize.GetInstance().WriteTo_rTxtCode(false, code, data);
                        JavaClientControl.GetInstance().SendDataToJava((short)code, data).Employ();
                        break;
                    case CODE_IDENTIFY:
                        WriteLogRealize.GetInstance().WriteTo_rTxtCode(false, code, data);
                        var str3 = BitConverter.ToString(data, 0).Replace("-", string.Empty).ToLower();
                        byte[] bytes3 = Encoding.UTF8.GetBytes(str3);
                        JavaClientControl.GetInstance().SendDataToJava((short)code, bytes3).Employ();
                        break;
                    case CODE_UPDATE:
                        WriteLogRealize.GetInstance().WriteTo_rTxtCode(false, code, data);
                        var str4 = BitConverter.ToString(data, 0).Replace("-", string.Empty).ToLower();
                        byte[] bytes4 = Encoding.UTF8.GetBytes(str4);
                        JavaClientControl.GetInstance().SendDataToJava((short)code, bytes4).Employ();
                        break;
                    case CODE_DELETE:
                        WriteLogRealize.GetInstance().WriteTo_rTxtCode(false, code, data);
                        var str5 = BitConverter.ToString(data, 0).Replace("-", string.Empty).ToLower();
                        byte[] bytes5 = Encoding.UTF8.GetBytes(str5);
                        JavaClientControl.GetInstance().SendDataToJava((short)code, bytes5).Employ();
                        break;
                    case CODE_CLEAR:
                        WriteLogRealize.GetInstance().WriteTo_rTxtCode(false, code, data);
                        var str6 = BitConverter.ToString(data, 0).Replace("-", string.Empty).ToLower();
                        byte[] bytes6 = Encoding.UTF8.GetBytes(str6);
                        JavaClientControl.GetInstance().SendDataToJava((short)code, bytes6).Employ();
                        break;
                }
            }
            catch (Exception ex)
            {
                WriteLogRealize.GetInstance().WriteTo_rTxtLog("解析算法数据异常：" + ex.ToString());
            }
        }

        /// <summary>
        /// 发送TCP信息
        /// </summary>
        /// <param name="code">功能码</param>
        /// <param name="data">正文数据</param>
        public void SendMsg(byte code, byte[] data)
        {
            TransitRaalize.GetInstance().DealRobotMsg(code, data);
            WriteLogRealize.GetInstance().WriteTo_rTxtCode(true, code, data);
        }
    }
}
