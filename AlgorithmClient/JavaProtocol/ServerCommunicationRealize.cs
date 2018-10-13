using AlgorithmClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XiaLM.Tool450.source.common;

namespace AlgorithmClient.JavaProtocol
{
    /// <summary>
    /// 服务端数据通讯
    /// </summary>
    public class ServerCommunicationRealize
    {
        private bool IsConnected = false;
        private static readonly object lockObj = new object();
        private static ServerCommunicationRealize initialize;
        public static ServerCommunicationRealize GetInitialize()
        {
            if (initialize == null)
            {
                lock (lockObj)
                {
                    if (initialize == null)
                    {
                        initialize = new ServerCommunicationRealize();
                    }
                }
            }
            return initialize;
        }

        public event Action<short, byte[]> DataReceived;
        public event Action ServerConnected;
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="code"></param>
        /// <param name="bs"></param>
        /// <returns></returns>
        public async Task Send(short code, byte[] bs)
        {
            List<byte> list = new List<byte>();
            list.AddRange(BitConverter.GetBytes(code));
            list.AddRange(bs);
            await ServerCommunicationInitialize.GetInitialize().Send(list.ToArray());
        }
        public void Received(byte[] bs) {
            if (bs == null || bs.Length <= 0) return;
            var code = BitConverter.ToInt16(bs.Take(2).ToArray(),0);
            var data = bs.Skip(2).ToArray();
            DataReceived?.Invoke(code,data);
        }

        public void OnServerConnected()
        {
            IsConnected = true;
            ServerConnected?.Invoke();
            StartHeartBeat();
        }

        public void OnServerDisconnected()
        {
            IsConnected = false;
        }

        /// <summary>
        /// 启动算法TCP客户端心跳
        /// </summary>
        private void StartHeartBeat()
        {
            Task.Factory.StartNew(() =>
            {
                WriteLogRealize.GetInstance().WriteTo_rTxtLog("Java服务器连接成功！");
                while (IsConnected)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(3));
                    short heart = 0x01;
                    JavaHeartInfo javaHeartInfo = new JavaHeartInfo()
                    {
                        deviceId = "2933642251331350",
                        taskId = "1",
                        chargeState = 50,
                        updateTime = "20180811"
                    };
                    string jsonStr = SerializeHelper.SerializeObjectToJson(javaHeartInfo);
                    byte[] bytes = Encoding.UTF8.GetBytes(jsonStr);
                    JavaClientControl.GetInstance().SendDataToJava(heart, bytes).Wait();
                }
            });
        }

        public void OnServerError(Exception ex)
        {

        }
    }
}
