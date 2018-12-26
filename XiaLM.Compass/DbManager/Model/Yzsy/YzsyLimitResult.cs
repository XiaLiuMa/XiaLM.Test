using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaLM.Compass.DbManager.TbModel;

namespace XiaLM.Compass.DbManager.Model.Yzsy
{
    public class YzsyLimitResult
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public int totalCount { get; set; }
        
        /// <summary>
        /// 数据列表
        /// </summary>
        public List<Tb_YZSY> dataList { get; set; }
    }
}
