using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrjConsultation.Model
{
    /// <summary>
    /// 层级节点对象
    /// </summary>
    public class Qnode
    {
        /// <summary>
        /// 当前界面显示问题提示语
        /// (也就是父级问题对象中的提示语)
        /// </summary>
        public string TSY { get; set; }
        /// <summary>
        /// //问题坐标列表
        /// </summary>
        public List<Qpoint> Qpoints { get; set; }
    }

    /// <summary>
    /// 问题坐标
    /// </summary>
    public class Qpoint
    {
        /// <summary>
        /// Y轴(第几行)
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// X轴(第几列)
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// X轴跨度(距离下一个表格的横向坐标)
        /// </summary>
        public int Xspan { get; set; }
        /// <summary>
        /// 问题描述
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 提示语
        /// </summary>
        public string TSY { get; set; }
        /// <summary>
        /// 当前分支是否结束
        /// </summary>
        public bool IsEnd { get; set; }
    }
}
