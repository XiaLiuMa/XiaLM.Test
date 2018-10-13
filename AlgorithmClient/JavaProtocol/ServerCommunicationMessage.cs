using Loxi.Core.Tcp.Client;
using Loxi.Core.Tcp.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmClient.JavaProtocol
{
    public class ServerCommunicationMessage : IAsyncTcpClientMessage
    {
        public async Task OnServerConnected(AsyncTcpClient client)
        {
            ServerCommunicationRealize.GetInitialize().OnServerConnected();
        }

        public async Task OnServerDataReceived(AsyncTcpClient client, byte[] data, int offset, int count)
        {
            ServerCommunicationRealize.GetInitialize().Received(data);
        }

        public async Task OnServerDisconnected(AsyncTcpClient client)
        {
            ServerCommunicationRealize.GetInitialize().OnServerDisconnected();
            ServerCommunicationInitialize.GetInitialize().RestConn();
        }

        public async Task OnServerError(string msg, Exception ex)
        {
            ServerCommunicationRealize.GetInitialize().OnServerError(ex);
        }
    }
}
