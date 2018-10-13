using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmClient.Model
{
    public class UploadFaceInfo
    {
        /// <summary>
        /// 类型("black":黑名单，"white":白名单)
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 人员编号
        /// </summary>
        public string serialnumber { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string idnumber { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string filename { get; set; }
        /// <summary>
        /// 图像二进制文件流(base64编码)
        /// </summary>
        public string imagebytes { get; set; }
    }
}
