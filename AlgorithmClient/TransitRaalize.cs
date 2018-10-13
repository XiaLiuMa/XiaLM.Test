using System;
using System.Text;
using System.Threading.Tasks;
using TcpAlgorithmClient;


/*

* ==============================================================================
  * CLR 版本：      4.0.30319.42000
  * 类 名 称：      FaceClientRaalize
  * 命名空间：      Maxvision.FaceClient
  * 文 件 名：      FaceClientRaalize
  * 创建时间：      2018/7/21 18:02:43
  * 作    者：      XLM
  * 修改时间：
  * 修 改 人：
  * 说    明：      FaceClient程序TCP通信的解析器
* ==============================================================================
*/
namespace AlgorithmClient
{
    /// <summary>
    /// FaceClient程序TCP通信的解析器
    /// </summary>
    public class TransitRaalize
    {
        private static TransitRaalize instance;
        private readonly static object objLock = new object();
        public static TransitRaalize GetInstance()
        {
            if (instance == null)
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new TransitRaalize();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// 处理机器人端的消息
        /// </summary>
        /// <param name="code">功能码</param>
        /// <param name="bytes">正文</param>
        public async void DealRobotMsg(byte code, byte[] bytes)
        {
            await Task.Factory.StartNew(() =>
            {
                //bas64编码
                string base64txt = Convert.ToBase64String(bytes);
                byte[] base64Bytes = Encoding.UTF8.GetBytes(base64txt);
                AlgorithmClientControl.GetInstance().SendMsg(code, base64Bytes);
            });
        }

        /// <summary>
        /// 处理算法端消息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="bytes"></param>
        public async void DealAlgorithmMsg(byte code, byte[] bytes)
        {
            await Task.Factory.StartNew(() =>
            {
                //bas64解码
                string unBase64txt = Encoding.UTF8.GetString(bytes);
                byte[] unBase64Bytes = Convert.FromBase64String(unBase64txt);
                RobotClientControl.GetInstance().ReceiveMsg(code, unBase64Bytes);
            });
        }
    }
}
