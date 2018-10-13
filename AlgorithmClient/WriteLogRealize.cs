using AlgorithmClient.Model;
using System;
using System.Linq;
using System.Text;
using XiaLM.Tool450.source.common;

namespace AlgorithmClient
{
    public class WriteLogRealize
    {
        private static WriteLogRealize instance;
        private readonly static object objLock = new object();
        public static WriteLogRealize GetInstance()
        {
            if (instance == null)
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new WriteLogRealize();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private string ConvertByteToString(byte[] bytes)
        {
            try
            {
                return BitConverter.ToString(bytes, 0).Replace("-", string.Empty).ToLower();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 写入到算法心跳
        /// </summary>
        /// <param name="isOut">是否是发送出去的？还是接收？</param>
        /// <param name="code"></param>
        /// <param name="bytes"></param>
        public void WriteTo_rTxtHeart(bool isOut, byte code, byte[] msg)
        {
            var codeStr = ConvertByteToString(new byte[] { code });
            var msgStr = ConvertByteToString(msg);
            if (msgStr.Length >= 50)
            {
                msgStr = msgStr.Remove(51, msgStr.Length - 51) + "...";
            }
            if (isOut)
            {
                MainForm.GetInstance().Invoke(new Action(() =>
                {
                    MainForm.GetInstance().rTxtHeart.Text += string.Format("Send:[功能码：{0}，正文：{1}]\r\n", codeStr, msgStr);
                }));
            }
            else
            {
                MainForm.GetInstance().Invoke(new Action(() =>
                {
                    MainForm.GetInstance().rTxtHeart.Text += string.Format("Receive:[功能码：{0}，正文：{1}]\r\n", codeStr, msgStr);
                }));
            }
        }

        /// <summary>
        /// 写入到算法命令
        /// </summary>
        /// <param name="isOut">是否是发送出去的？还是接收？</param>
        /// <param name="code"></param>
        /// <param name="bytes"></param>
        public void WriteTo_rTxtCode(bool isOut, byte code, byte[] msg)
        {
            var codeStr = ConvertByteToString(new byte[] { code });
            var msgStr = ConvertByteToString(msg);
            if (msgStr.Length >= 50)
            {
                msgStr = msgStr.Remove(51, msgStr.Length - 51) + "...";
            }
            if (isOut)
            {
                MainForm.GetInstance().Invoke(new Action(() =>
                {
                    MainForm.GetInstance().rTxtCode.Text += string.Format("Send:[功能码：{0}，正文：{1}]\r\n", codeStr, msgStr);
                }));
            }
            else
            {
                MainForm.GetInstance().Invoke(new Action(() =>
                {
                    MainForm.GetInstance().rTxtCode.Text += string.Format("Receive:[功能码：{0}，正文：{1}]\r\n", codeStr, msgStr);
                }));
            }
        }

        /// <summary>
        /// 写入到算法偏移量
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        public void WriteTo_rTxtOffset(byte code, byte[] msg)
        {
            var codeStr = ConvertByteToString(new byte[] { code });
            var msgStr = ConvertByteToString(msg);
            if (msgStr.Length >= 50)
            {
                msgStr = msgStr.Remove(51, msgStr.Length - 51) + "...";
            }
            MainForm.GetInstance().Invoke(new Action(() =>
            {
                MainForm.GetInstance().rTxtOffset.Text += string.Format("Receive:[功能码：{0}，正文：{1}]\r\n", codeStr, msgStr);
            }));
        }

        /// <summary>
        /// 写入到算法日志
        /// </summary>
        /// <param name="msg"></param>
        public void WriteTo_rTxtLog(string msg)
        {
            MainForm.GetInstance().Invoke(new Action(() =>
            {
                MainForm.GetInstance().rTxtLog.Text += string.Format("[{0}]{1}\r\n", DateTime.Now.ToString(), msg);
            }));
        }

        /// <summary>
        /// 写入到查询框
        /// </summary>
        /// <param name="msg"></param>
        public void WriteTo_rTxtSelect(byte[] msg)
        {
            try
            {
                string josnStr = Encoding.UTF8.GetString(msg);
                TempSelectFaceInfo tempObj = SerializeHelper.SerializeJsonToObject<TempSelectFaceInfo>(josnStr);
                MainForm.GetInstance().Invoke(new Action(() =>
                {
                    if (tempObj == null)
                    {
                        MainForm.GetInstance().faceList.Clear();
                        MainForm.GetInstance().rTxtSelect.Text = "白名单：0个\r\n黑名单：0个\r\n";
                        return;
                    }
                    MainForm.GetInstance().faceList = tempObj.Item;
                    if (tempObj.Item == null || tempObj.Item.Count <= 0) return;
                    var writeSum = tempObj.Item.Where(p => p.type.Equals("white")).Count();
                    var blackSum = tempObj.Item.Where(p => p.type.Equals("black")).Count();
                    MainForm.GetInstance().rTxtSelect.Text = string.Format("白名单：{0}个\r\n黑名单：{1}个\r\n", writeSum, blackSum);
                }));
            }
            catch (Exception ex)
            {
                WriteTo_rTxtLog("解析查询数据异常：" + ex.ToString());
            }
        }

        /// <summary>
        /// 写入到算法命令
        /// </summary>
        /// <param name="isOut">是否是发送出去的？还是接收？</param>
        /// <param name="code"></param>
        /// <param name="bytes"></param>
        public void WriteTo_rTxtJavaCode(bool isOut, short code, byte[] msg)
        {
            var codeStr = ConvertByteToString(BitConverter.GetBytes(code));
            var msgStr = ConvertByteToString(msg);
            if (msgStr.Length >= 50)
            {
                msgStr = msgStr.Remove(51, msgStr.Length - 51) + "...";
            }
            if (isOut)
            {
                MainForm.GetInstance().Invoke(new Action(() =>
                {
                    MainForm.GetInstance().rTextJavaCode.Text += string.Format("Send:[功能码：{0}，正文：{1}]\r\n", codeStr, msgStr);
                }));
            }
            else
            {
                MainForm.GetInstance().Invoke(new Action(() =>
                {
                    MainForm.GetInstance().rTextJavaCode.Text += string.Format("Receive:[功能码：{0}，正文：{1}]\r\n", codeStr, msgStr);
                }));
            }
        }
    }
}
