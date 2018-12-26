using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaLM.Compass.DbManager.Model
{
    public class BaseLimitParam
    {
        /// <summary>
        /// 每页条数
        /// </summary>
        public int limit { get; set; }
        /// <summary>
        /// 起始条
        /// </summary>
        public int offset { get; set; }
    }
}
