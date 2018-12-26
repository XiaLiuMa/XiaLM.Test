using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaLM.Compass.DbManager.TbModel
{
    public class Tb_YZSY
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }
        public string MDirection { get; set; }
        public string WDirection { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string DescribeZ { get; set; }
        public string CDirection { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string DescribeF { get; set; }
    }
}
