using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XiaLM.Compass.DbManager.Manament;
using XiaLM.Compass.DbManager.Model.Yzsy;
using XiaLM.Compass.DbManager.TbModel;

namespace XiaLM.Compass.View
{
    public partial class YzsySelect : Form
    {
        public YzsySelect()
        {
            InitializeComponent();
        }

        private void YzsyManager_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
            this.comboBox3.SelectedIndex = 0;
            this.comboBox1.SelectedIndexChanged += ComboBoxZ_SelectedIndexChanged;
            this.comboBox2.SelectedIndexChanged += ComboBoxZ_SelectedIndexChanged;
            this.comboBox3.SelectedIndexChanged += ComboBoxZ_SelectedIndexChanged;
        }

        private void ComboBoxZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectParam selectParam = new SelectParam()
            {
                MDirection = this.comboBox1.SelectedItem.ToString(),
                WDirection = this.comboBox2.SelectedItem.ToString(),
                CDirection = this.comboBox3.SelectedItem.ToString(),
            };
            Tb_YZSY obj = YzsyManament.GetInstance().SelectYzsy(selectParam) as Tb_YZSY;
            if (obj != null)
            {
                this.textBox1.Text = obj.DescribeZ;
                this.textBox2.Text = obj.DescribeF;
            }
            else
            {
                this.textBox1.Text = string.Empty;
                this.textBox2.Text = string.Empty;
            }
        }

    }
}
