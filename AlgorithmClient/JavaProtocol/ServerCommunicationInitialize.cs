using Loxi.Core.Tcp.Client;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AlgorithmClient.JavaProtocol
{
    public class ServerCommunicationInitialize
    {
        private AsyncTcpClient tcpClient;
        private string _ip = "127.0.0.1";
        private int _port = 0;
        private static readonly object lockObj = new object();
        private static ServerCommunicationInitialize initialize;
        public static ServerCommunicationInitialize GetInitialize()
        {
            if (initialize == null)
            {
                lock (lockObj)
                {
                    if (initialize == null)
                    {
                        initialize = new ServerCommunicationInitialize();
                    }
                }
            }
            return initialize;
        }
        public ServerCommunicationInitialize()
        {
        }

        public void Init(string ip, int port)
        {
            try
            {
                _ip = ip;
                _port = port;
                tcpClient = new AsyncTcpClient(new IPEndPoint(IPAddress.Parse(_ip), _port), new ServerCommunicationMessage(), new ServerCommunicationCodecBuilder());
                tcpClient?.Connect().Wait();
                
            }
            catch (Exception ex)
            {
            }
        }
        public void RestConn()
        {
            Init(_ip, _port);
        }

        public async Task Send(byte[] bs)
        {
            await tcpClient?.SendAsync(bs);
        }
    }
}
