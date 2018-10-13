using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmClient.Model
{
    public class DeleteFaceInfo
    {
        /// <summary>
        /// 类型("black":黑名单，"white":白名单)
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 人员编号
        /// </summary>
        public string serialnumber { get; set; }
    }
}
