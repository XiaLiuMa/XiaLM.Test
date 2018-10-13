using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*

* ==============================================================================
  * CLR 版本：      4.0.30319.42000
  * 类 名 称：      ByteUtil
  * 命名空间：      AlgorithmSever
  * 文 件 名：      ByteUtil
  * 创建时间：      2018/7/27 16:53:33
  * 作    者：      XLM
  * 修改时间：
  * 修 改 人：
  * 说    明：      单字节循环异或校验
* ==============================================================================
*/
namespace AlgorithmSever
{
    public static class ByteUtil
    {
        /// <summary>
        /// 单字节循环异或校验
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte BccVerifica(this IEnumerable<byte> bytes, int startIndex, int length)
        {
            return Bcc(bytes.Skip(startIndex).Take(length));
        }

        private static T Bcc<T>(IEnumerable<T> source)
            where T : struct
        {
            Int32 res = source.Select(p => Convert.ToInt32(p)).Aggregate((a, b) => a ^ b);
            return (T)Convert.ChangeType(res, typeof(T));
        }

        public static IEnumerable<byte> int2CustomBytes(Int32 num, Int32 div)
        {
            if (num < 100)
            {
                yield return (byte)num;
                yield break;
            }
            yield return (byte)(num / div);

            var list = int2CustomBytes(num % div, div / 100);

            foreach (var item in list)
            {
                yield return item;
            }
        }


        public static Int32 CustomBytes2int(byte[] bytes)
        {
            string str = String.Join("", bytes);

            return Convert.ToInt32(str);
        }

    }
}
