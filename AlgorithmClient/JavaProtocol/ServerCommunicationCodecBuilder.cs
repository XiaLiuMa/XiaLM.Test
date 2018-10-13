using Loxi.Core.Tcp;
using Loxi.Core.Tcp.Codecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmClient.JavaProtocol
{
    //头（2个字节）+长度（4个字节）+协议号（2个字节）+内容+尾部（2个字节）
    //头：2字节，头字节：0x22,0xBB
    //头：2字节，头字节：0x77,0xBB

    public class ServerCommunicationCodecBuilder : ICodecBuilder
    {
        private ICodecDecoding decoding = new ServerCommunicationCodecDecoding();
        private ICodecEncoding encoding = new ServerCommunicationCodecEncoding();
        public ICodecDecoding DecodingBuilder => decoding;

        public ICodecEncoding EncodingBuilder => encoding;

        public ICodecBuilder Clone()
        {
            return new ServerCommunicationCodecBuilder();
        }
    }
    public class ServerCommunicationCodecDecoding : ICodecDecoding
    {
        List<byte> list = new List<byte>();
        private byte[] _head = new byte[] { 0x22, 0xBB };
        private byte[] _tail = new byte[] { 0x77, 0xBB };
        public void Decoding(TcpBuffer playload, DataAnalysisResults callback)
        {
            list.AddRange(playload.Datas);
            while (true)
            {
                if (list.Count <= 0) break;
                if (list.Count < 2) break;
                var head = list.Take(2).ToArray();
                if (!CheckShortArray(head, this._head))
                {
                    list.RemoveAt(0);
                    continue;
                }
                if (list.Count >= 8)
                {
                    var len = BitConverter.ToInt32(list.Skip(2).Take(4).Reverse().ToArray(), 0);
                    var code = list.Skip(6).Take(2).Reverse().ToArray();
                    if (list.Count < len + 10) break;
                    var tail = list.Skip(len + 8).Take(2).ToArray();
                    if (!CheckShortArray(tail, this._tail))
                    {
                        list.RemoveAt(0);
                        continue;
                    }
                    var data = list.Skip(8).Take(len).ToList();
                    data.InsertRange(0, code);
                    list.RemoveRange(0,len+10);
                    callback?.Invoke(new TcpBuffer(data.ToArray(), 0, data.Count));
                }
                else break;
            }
        }
        /// <summary>
        /// 判断字节数组是否相等
        /// </summary>
        /// <param name="bs1"></param>
        /// <param name="bs2"></param>
        /// <returns></returns>
        private bool CheckShortArray(byte[] bs1, byte[] bs2)
        {
            short temp1 = BitConverter.ToInt16(bs1.Reverse().ToArray(), 0);
            short temp2 = BitConverter.ToInt16(bs2.Reverse().ToArray(), 0);
            if (temp1 == temp2) return true;
            return false;
        }
    }

    public class ServerCommunicationCodecEncoding : ICodecEncoding
    {
        public TcpBuffer Encoding(TcpBuffer buffer)
        {
            var code = buffer.Datas.Take(2).Reverse();
            List<byte> list = new List<byte>();
            list.AddRange(new byte[] { 0x22, 0xBB });//添加头
            var data = buffer.Datas.Skip(2).ToList();//内容
            list.AddRange(BitConverter.GetBytes(data.Count).Reverse());//长度
            list.AddRange(code);//协议号
            list.AddRange(data);
            list.AddRange(new byte[] { 0x77, 0xBB });
            return new TcpBuffer(list.ToArray(), 0, list.Count);
        }
    }
}
