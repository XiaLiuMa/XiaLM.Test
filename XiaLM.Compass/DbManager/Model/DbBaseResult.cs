using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaLM.Compass.DbManager.Model
{
    public class DbBaseResult
    {
        /// <summary>
        /// 操作成功个数
        /// </summary>
        public int SuccessNum { get; set; }
        /// <summary>
        /// 总操作个数
        /// </summary>
        public int TotalNum { get; set; }
    }
}
