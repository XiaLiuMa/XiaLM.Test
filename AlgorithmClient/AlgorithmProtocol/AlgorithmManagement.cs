using Loxi.Core.Tcp.Client;
using Loxi.Core.Tcp.Codecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgorithmClient.AlgorithmProtocol
{
    /// <summary>
    /// 算法协议管理类
    /// </summary>
    public class AlgorithmManagement
    {
        private AsyncTcpClient tcpClient;
        private string _ip = "0.0.0.0";
        private int _port = 0;
        private AbsAlgorithmMessage _message;

        public AlgorithmManagement()
        {

        }

        public AlgorithmManagement(string ip, int port, AbsAlgorithmMessage message)
        {
            _ip = ip;
            _port = port;
            _message = message;
        }
        public void Start()
        {
            try
            {
                tcpClient = new AsyncTcpClient(new IPEndPoint(IPAddress.Parse(this._ip), this._port), _message, new AlgorithmCodecBuilder());
                tcpClient.Connect().Wait();
            }
            catch (Exception ex)
            {
            }
        }
        public bool IsConn { get { return tcpClient.State == Loxi.Core.Tcp.Mod.TcpConnectionStatus.Connected ? true : false; } }
        public void Close()
        {
            try
            {
                if (tcpClient.State == Loxi.Core.Tcp.Mod.TcpConnectionStatus.Connecting) return;
                tcpClient?.Shutdown();
                tcpClient?.Close();
                if (tcpClient.State == Loxi.Core.Tcp.Mod.TcpConnectionStatus.Closed)
                    Start();
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="code">功能码</param>
        /// <param name="data">数据</param>
        public void Send(byte code, byte[] data)
        {
            List<byte> list = new List<byte>();
            list.AddRange(data);
            list.Insert(0, code);
            tcpClient?.SendAsync(list.ToArray());
        }
    }
}
