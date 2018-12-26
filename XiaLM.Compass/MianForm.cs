using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XiaLM.Compass.View;

namespace XiaLM.Compass
{
    public partial class MianForm : Form
    {
        public MianForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体显示完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MianForm_Shown(object sender, EventArgs e)
        {
            //Display();
        }

        private void Display()
        {
            Graphics g = this.CreateGraphics();
            int width = this.ClientRectangle.Right;
            int height = this.ClientRectangle.Bottom;
            Rectangle rect1 = new Rectangle(300-50, 300-50, 100, 100);
            Rectangle rect2 = new Rectangle(0, 0, 600, 600);
            g.DrawEllipse(Pens.Red, rect1);
            g.DrawEllipse(Pens.Red, rect2);
        }

        /// <summary>
        /// 鼠标在控件上保持静止一段时间触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MianForm_MouseHover(object sender, EventArgs e)
        {
            //Point point = Control.MousePosition;
            //Graphics gra = this.CreateGraphics();
            //Font myFont = new Font("宋体", 15, FontStyle.Bold);
            //Brush bush = new SolidBrush(Color.Red);//填充的颜色
            //gra.DrawString($"{point.X},{point.Y}", myFont, bush, point.X, point.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new YzsyManager().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new YzsySelect().Show();
        }
    }
}
