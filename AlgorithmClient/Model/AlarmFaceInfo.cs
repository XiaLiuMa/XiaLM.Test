using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmClient.Model
{
    /// <summary>
    /// 人脸报警信息
    /// </summary>
    public class AlarmFaceInfo
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 人员名字
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 机器人编号
        /// </summary>
        public int robotnumber { get; set; }
        /// <summary>
        /// 报警人员编号
        /// </summary>
        public string serialnumber { get; set; }
        /// <summary>
        /// 图像二进制文件流
        /// </summary>
        public string imagebytes { get; set; }
    }
}
