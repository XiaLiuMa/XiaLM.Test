using Loxi.Core.Tcp.Codecs;
using Loxi.Core.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;


/*

* ==============================================================================
  * CLR 版本：      4.0.30319.42000
  * 类 名 称：      AlgorithmCodecBuilder
  * 命名空间：      AlgorithmSever
  * 文 件 名：      AlgorithmCodecBuilder
  * 创建时间：      2018/7/27 15:12:06
  * 作    者：      XLM
  * 修改时间：
  * 修 改 人：
  * 说    明：      算法编解码器
* ==============================================================================
*/
namespace AlgorithmSever
{
    /// <summary>
    /// 算法编解码器
    /// </summary>
    public class AlgorithmBuilder : ICodecBuilder
    {
        private ICodecDecoding decoding = new AlgorithmDecoding();
        private ICodecEncoding encoding = new AlgorithmEncoding();
        public ICodecDecoding DecodingBuilder => decoding;

        public ICodecEncoding EncodingBuilder => encoding;

        public ICodecBuilder Clone()
        {
            return new AlgorithmBuilder();
        }
    }

    public class AlgorithmDecoding : ICodecDecoding
    {
        List<byte> _list = new List<byte>();
        List<byte> _datas = new List<byte>();
        private byte _head = 0xEF;
        private byte _end = 0xFF;
        private int _len = 0;
        private byte code = 0x00;
        public void Decoding(TcpBuffer playload, DataAnalysisResults callback)
        {
            _list.AddRange(playload.Datas);
            while (true)
            {
                if (_list.Count <= 0) break;
                if (_datas.Count == 0)
                {
                    byte head = _list[0];
                    if (head == this._head)
                    {
                        if (_list.Count <= 6) break;
                        if (code == 0x00)
                        {
                            code = _list[1];
                        }
                        int len = BitConverter.ToInt32(_list.Skip(2).Take(4).Reverse().ToArray(), 0);
                        if (len <= 0)
                        {
                            _list.RemoveAt(0);
                            continue;
                        }
                        if (this._len == 0)
                        {
                            _len = len;
                        }
                        int d = _list.Count - (_len + 6);
                        int num = 0;
                        if (d >= 0)
                        {
                            num = _len;
                        }
                        else
                        {
                            num = _list.Count - 6;
                        }
                        if (num != 0)
                        {
                            _datas.AddRange(_list.Skip(6).Take(num));
                            _list.RemoveRange(0, 6 + _datas.Count);
                        }
                    }
                    else
                    {
                        _list.RemoveAt(0);
                    }
                }
                else
                {

                    int d = this._len - _datas.Count;
                    if (d > 0)
                    {
                        if (_list.Count >= d)
                        {
                            _datas.AddRange(_list.Take(d).ToArray());
                            _list.RemoveRange(0, d);
                        }
                        else
                        {
                            _datas.AddRange(_list);
                            _list.RemoveRange(0, _list.Count);
                        }
                    }
                    else
                    {
                        if (_list.Count > 0)
                        {
                            if (_list[0] != this._end)
                            {
                                _list.RemoveAt(0);
                                continue;
                            }
                        }
                        if (_list.Count < 2) break;
                        int crc = _datas.BccVerifica(0, _len);
                        if (crc == _list[1])
                        {
                            _datas.Insert(0, code);
                            callback?.Invoke(new TcpBuffer(_datas.ToArray(), 0, _datas.Count));
                        }
                        _list.RemoveRange(0, 2);
                        _len = 0;
                        code = 0x00;
                        _datas.Clear();
                    }
                }
            }
        }
    }
    public class AlgorithmEncoding : ICodecEncoding
    {
        public TcpBuffer Encoding(TcpBuffer buffer)
        {
            if (buffer.Count < 2) return null;
            byte code = buffer.Datas[0];
            List<byte> list = new List<byte>();
            list.AddRange(buffer.Datas);
            list.RemoveAt(0);
            byte crc = list.BccVerifica(0, list.Count);
            list.Add(0xFF);
            list.Add(crc);
            list.Insert(0, 0xEF);
            list.Insert(1, code);
            list.InsertRange(2, BitConverter.GetBytes(buffer.Count - 1).Reverse().ToArray());
            var data = list.ToArray();
            return new TcpBuffer(data, 0, data.Length);
        }
    }
}
