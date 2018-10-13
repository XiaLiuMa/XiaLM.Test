using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrjConsultation.AIUI.Model
{
    /// <summary>
    /// 语音识别结果【对外提供的语音识别结果信息】
    /// </summary>
    public class IatInfo
    {
        public string Sid { get; set; } //会话Id
        public string Data { get; set; }    //语音识别后文本结果
        public string CnDesc { get; set; }    //中文描述
        public string EnDesc { get; set; }    //英文描述
    }
}
