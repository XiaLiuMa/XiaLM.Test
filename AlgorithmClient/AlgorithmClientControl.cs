using AlgorithmClient;
using AlgorithmClient.AlgorithmProtocol;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


/*

* ==============================================================================
  * CLR 版本：      4.0.30319.42000
  * 类 名 称：      AlgorithmClientControl
  * 命名空间：      Maxvision.FaceClient.AlgorithmClient
  * 文 件 名：      AlgorithmClientControl
  * 创建时间：      2018/7/21 11:05:17
  * 作    者：      XLM
  * 修改时间：
  * 修 改 人：
  * 说    明：      算法端TCP客户端
* ==============================================================================
*/
namespace TcpAlgorithmClient
{
    /// <summary>
    /// 算法端TCP客户端
    /// </summary>
    public class AlgorithmClientControl
    {
        /// <summary>
        /// 功能码：心跳
        /// </summary>
        private const byte CODE_HEARTBEAT = 0x01;
        /// <summary>
        /// 功能码：跟随坐标
        /// </summary>
        private const byte CODE_FACELOCATION = 0x09;
        /// <summary>
        /// 算法协议管理
        /// </summary>
        public AlgorithmManagement management;
        private readonly static object objLock = new object();
        private static AlgorithmClientControl instance;

        public static AlgorithmClientControl GetInstance()
        {
            if (instance == null)
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new AlgorithmClientControl();
                    }
                }
            }
            return instance;
        }

        public void ConnectServer(string ip, string port)
        {
            management = new AlgorithmManagement(ip, int.Parse(port), new ReceiveAlgorithmServerMessage());
            management.Start();
            StartHeartBeat();
        }

        /// <summary>
        /// 启动算法TCP客户端心跳
        /// </summary>
        public void StartHeartBeat()
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));  //预留1秒钟连接时间
                if(management.IsConn)
                    WriteLogRealize.GetInstance().WriteTo_rTxtLog("算法服务器连接成功！");
                while (management.IsConn)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    string base64txt = Convert.ToBase64String(new byte[] { CODE_HEARTBEAT });
                    SendMsg(CODE_HEARTBEAT, Encoding.UTF8.GetBytes(base64txt));
                    WriteLogRealize.GetInstance().WriteTo_rTxtHeart(true, CODE_HEARTBEAT, new byte[] { CODE_HEARTBEAT });
                }
            });
        }
        
        /// <summary>
        /// 发送数据到算法TCP服务端
        /// </summary>
        /// <param name="code"></param>
        /// <param name="data"></param>
        public void SendMsg(byte code, byte[] data)
        {
            try
            {
                management.Send(code, data);
            }
            catch (Exception ex)
            {

            }
        }
    }

    /// <summary>
    /// 接收算法服务器回复消息类
    /// </summary>
    public class ReceiveAlgorithmServerMessage : AbsAlgorithmMessage
    {
        private const byte CODE_HEARTBEAT = 0x01;
        public override async Task OnMessage(byte code, byte[] bs)
        {
            TransitRaalize.GetInstance().DealAlgorithmMsg(code, bs);
        }
        public override async Task OnServerDisconnected()
        {
            WriteLogRealize.GetInstance().WriteTo_rTxtLog("算法服务器中断连接！");
            AlgorithmClientControl.GetInstance().ConnectServer(MainForm.GetInstance().aIP, MainForm.GetInstance().aPort);
        }
    }
}
