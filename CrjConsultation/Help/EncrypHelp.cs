using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CrjConsultation.Help
{
    /// <summary>
    /// 加密帮助类
    /// </summary>
    public class EncrypHelp
    {
        /// <summary>
        /// 将字符串Base64编码加密成字符串
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string ToBase64(string txt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(txt);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 将字节数组Base64编码加密成字符串
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string ToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// MD5码加密字符串(32位小写)
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string Md5Encryp(string txt)
        {
            string result = string.Empty;
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(txt));
            for (int i = 0; i < bytes.Length; i++)
            {
                result += bytes[i].ToString("x2");//每个元素进行十六进制转换然后拼接成s字符串
            }
            return result;
        }

        /// <summary>
        /// 获取 utc 1970-1-1到现在的秒数
        /// </summary>
        /// <returns></returns>
        public static long Get1970ToNowSeconds()
        {
            return (DateTime.UtcNow.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }

        /// <summary>
        /// 获取 utc 1970-1-1到现在的毫秒数
        /// </summary>
        /// <returns></returns>
        public static long Get1970ToNowMilliseconds()
        {
            return (DateTime.UtcNow.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        }
    }
}
