using CrjConsultation.AIUI.Model;
using System;
using System.Net.Http;
using System.Web;
using XiaLM.Tool450.source.common;

namespace CrjConsultation.AIUI
{
    /// <summary>
    /// 讯飞webAPI
    /// </summary>
    public class XFwebApi
    {
        public string appId { get; set; }   //应用id
        public string iatKey { get; set; }  //在线识别服务密钥
        public string ttsKey { get; set; }  //在线合成服务密钥
        private static readonly object lockObj = new object();
        private static XFwebApi xfwebApi;
        public XFwebApi()
        {
            appId = "5adf1293";
            iatKey = "27ba5964488a5847192d2fa9ac638943";
            ttsKey = "621f7af6891b44f0e0bb395967efb9ef";
        }
        public static XFwebApi GetInstance()
        {
            if (xfwebApi == null)
            {
                lock (lockObj)
                {
                    if (xfwebApi == null)
                    {
                        xfwebApi = new XFwebApi();
                    }
                }
            }
            return xfwebApi;
        }

        /// <summary>
        /// 讯飞WebAPI语音识别
        /// </summary>
        /// <param name="bArray"></param>
        /// <returns></returns>
        public IatInfo XunFeiIAT(byte[] bytes)
        {
            IatInfo iatInfo = new IatInfo();
            string requestURL = "http://api.xfyun.cn/v1/service/v1/iat";
            HttpClient http = new HttpClient();
            try
            {
                IatParam iatParam = new IatParam
                {
                    engine_type = "sms16k",
                    aue = "raw"
                };
                var iatJson = Base64Helper.ToBase64(SerializeHelper.SerializeObjectToJson(iatParam));
                var curTime = EncryptHelper.Get1970ToNowSeconds().ToString();
                var checkSum = EncryptHelper.Md5Encryp(iatKey + curTime + iatJson);
                var content = new StringContent("audio=" + HttpUtility.UrlEncode(Base64Helper.ToBase64(bytes))); //数据
                content.Headers.Add("X-Appid", appId);
                content.Headers.Add("X-CurTime", curTime);
                content.Headers.Add("X-Param", iatJson);
                content.Headers.Add("X-CheckSum", checkSum);
                content.Headers.ContentType.MediaType = "application/x-www-form-urlencoded";
                using (var response = http.PostAsync(requestURL, content).Result)
                {
                    response.EnsureSuccessStatusCode();
                    string responseStr = response.Content.ReadAsStringAsync().Result;
                    var iatResult = Newtonsoft.Json.JsonConvert.DeserializeObject<IatResult>(responseStr);
                    iatInfo.Sid = iatResult.sid;
                    iatInfo.CnDesc = Analysis(iatResult.code);
                    iatInfo.EnDesc = iatResult.desc;
                    iatInfo.Data = iatResult.data;
                    return iatInfo;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }
            return null;
        }

        /// <summary>
        /// 讯飞WebAPI语音合成
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public byte[] XunFeiTTS(string txt)
        {
            string requestURL = "http://api.xfyun.cn/v1/service/v1/tts";
            HttpClient http = new HttpClient();
            try
            {
                TtsParam ttsParam = new TtsParam
                {
                    auf = "audio/L16;rate=16000",
                    aue = "raw",
                    voice_name = "xiaoyan",
                    speed = "50",
                    volume = "50",
                    pitch = "50",
                    engine_type = "intp65",
                    text_type = "text"
                };
                var ttsJson = Base64Helper.ToBase64(SerializeHelper.SerializeObjectToJson(ttsParam));
                var curTime = EncryptHelper.Get1970ToNowSeconds().ToString();
                var checkSum = EncryptHelper.Md5Encryp(ttsKey + curTime + ttsJson);
                var content = new StringContent("text=" + HttpUtility.UrlEncode(txt));
                content.Headers.Add("X-CurTime", curTime);
                content.Headers.Add("X-Param", ttsJson);
                content.Headers.Add("X-Appid", appId);
                content.Headers.Add("X-CheckSum", checkSum);
                content.Headers.Add("X-Real-Ip", "127.0.0.1");
                content.Headers.ContentType.MediaType = "application/x-www-form-urlencoded";
                using (var response = http.PostAsync(requestURL, content).Result)
                {
                    if (response.Content.Headers.ContentType.MediaType.Equals("audio/mpeg"))
                    {
                        //合成成功
                        response.EnsureSuccessStatusCode();
                        return response.Content.ReadAsByteArrayAsync().Result;
                    }
                    else
                    {
                        //合成失败
                        var str = response.Content.ReadAsStringAsync().Result;
                        var result = SerializeHelper.SerializeJsonToObject<IatResult>(str);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        /// <summary>
        /// 解析错误码
        /// </summary>
        /// <param name="eCode"></param>
        /// <returns></returns>
        private string Analysis(string eCode)
        {
            string result = string.Empty;
            if (eCode.Equals("0"))
                result = "成功";
            if (eCode.Equals("10105"))
                result = "没有权限";
            if (eCode.Equals("10106"))
                result = "无效参数";
            if (eCode.Equals("10107"))
                result = "非法参数值";

            return result;
        }
    }
    
    /// <summary>
    /// 语音识别参数
    /// </summary>
    public class IatParam
    {
        public string engine_type { get; set; } //识别引擎，可选值：sms16k（16k采样率普通话音频）、sms8k（8k采样率普通话音频）等
        public string aue { get; set; } //音频编码，可选值：raw（未压缩的pcm或wav格式）、speex（speex格式）、speex-wb（宽频speex格式）
        public string speex_size { get; set; } //speex音频帧率【非必需】
        public string scene { get; set; } //情景模式（main）【非必需】
        public string vad_eos { get; set; } //后端点检测（单位：ms），默认1800【非必需】
    }
    
    /// <summary>
    /// 语音合成参数
    /// </summary>
    public class TtsParam
    {
        public string auf { get; set; } //音频采样率，可选值：audio/L8;rate=8000，audio/L16;rate=16000
        public string aue { get; set; } //音频编码，可选值：raw（未压缩的pcm或wav格式），lame（mp3格式）
        public string voice_name { get; set; }  //发音人
        public string speed { get; set; }   //语速，可选值：[0-100]，默认为50
        public string volume { get; set; }  //音量，可选值：[0-100]，默认为50
        public string pitch { get; set; }   //音高，可选值：[0-100]，默认为50
        public string engine_type { get; set; } //合成类型,可选值:aisound(普通效果),intp65(中文),intp65_en(英文),mtts(小语种,需配合小语种发音人使用),x(优化效果),默认为inpt65
        public string text_type { get; set; }   //文本类型，可选值：text（普通格式文本），默认为text
    }

    /// <summary>
    /// 语音识别结果
    /// </summary>
    public class IatResult
    {
        public string code { get; set; }    //结果码(具体见错误码)
        public string data { get; set; }    //语音识别后文本结果
        public string desc { get; set; }    //描述
        public string sid { get; set; } //描述
    }


}
