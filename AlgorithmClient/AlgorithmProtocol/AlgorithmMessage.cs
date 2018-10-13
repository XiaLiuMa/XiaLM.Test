using Loxi.Core.Tcp.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmClient.AlgorithmProtocol
{
    public abstract class AbsAlgorithmMessage : IAsyncTcpClientMessage
    {
        public async Task OnServerConnected(AsyncTcpClient client)
        {
            await OnServerConnected();
        }

        public async Task OnServerDataReceived(AsyncTcpClient client, byte[] data, int offset, int count)
        {
            if (data == null) return;
            if (data.Length < 2) return;
            await this.OnMessage(data[0], data.Skip(1).Take(data.Length - 1).ToArray());
        }

        public async Task OnServerDisconnected(AsyncTcpClient client)
        {
            await OnServerDisconnected();
        }

        public async Task OnServerError(string msg, Exception ex)
        {

        }
        public abstract Task OnMessage(byte code, byte[] bs);
        public virtual async Task OnServerConnected()
        {
        }

        public virtual async Task OnServerDisconnected()
        {

        }

    }
}
