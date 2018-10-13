using CrjConsultation.Model;
using System.Windows.Forms;

namespace CrjConsultation.UserControl
{
    /// <summary>
    /// 用户问题按钮
    /// </summary>
    public class QButton: Button
    {
        public Qpoint QPoint { get; set; } //按钮绑定用户数据
    }
}
