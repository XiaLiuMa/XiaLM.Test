using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XiaLM.Compass.DbManager.Manament;
using XiaLM.Compass.DbManager.Model;
using XiaLM.Compass.DbManager.Model.Yzsy;
using XiaLM.Compass.DbManager.TbModel;

namespace XiaLM.Compass.View
{
    public partial class YzsyManager : Form
    {
        private int currentIndex = 0; //当前页第一条的索引
        private int totalNum = 0;   //总共多少页

        public YzsyManager()
        {
            InitializeComponent();
        }

        private void YzsyManager_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
            this.comboBox3.SelectedIndex = 0;
            this.comboBox4.SelectedIndex = 0;
            this.comboBox1.SelectedIndexChanged += ComboBoxZ_SelectedIndexChanged;
            this.comboBox2.SelectedIndexChanged += ComboBoxZ_SelectedIndexChanged;
            this.comboBox3.SelectedIndexChanged += ComboBoxZ_SelectedIndexChanged;
            this.comboBox4.SelectedIndexChanged += ComboBox4_SelectedIndexChanged;
            RefreshYzsyList(Convert.ToInt32(this.comboBox4.SelectedItem.ToString()), 0);
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

        /// <summary>
        /// 分页个数修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshYzsyList(Convert.ToInt32(this.comboBox4.SelectedItem.ToString()), currentIndex);
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string desStr1 = this.textBox1.Text.Trim();
            if (string.IsNullOrEmpty(desStr1))
            {
                MessageBox.Show("插入失败，textBox1为空！");
                return;
            }
            string desStr2 = this.textBox2.Text.Trim();
            if (string.IsNullOrEmpty(desStr1))
            {
                MessageBox.Show("插入失败，textBox2为空！");
                return;
            }

            ImportParam importZ = new ImportParam()
            {
                MDirection = this.comboBox1.SelectedItem.ToString(),
                WDirection = this.comboBox2.SelectedItem.ToString(),
                DescribeZ = desStr1,
                CDirection = this.comboBox3.SelectedItem.ToString(),
                DescribeF = desStr2
            };
            bool flag = YzsyManament.GetInstance().ImportYzsy(importZ);

            MessageBox.Show($"插入结果：{flag}！");
            RefreshYzsyList(Convert.ToInt32(this.comboBox4.SelectedItem.ToString()), currentIndex);
        }

        /// <summary>
        /// 分页查询，刷新列表
        /// </summary>
        /// <param name="_limit">一页多少条</param>
        /// <param name="_offset">从第几条开始查</param>
        private void RefreshYzsyList(int _limit, int _offset)
        {
            var obj = YzsyManament.GetInstance().SelectYzsysLimit(new BaseLimitParam() { limit = _limit, offset = _offset }) as YzsyLimitResult;
            if (obj != null)
            {
                //首先先声明一个DataSet对象和一个DataTable对象      
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("_Id");//这些列名就是返回的DataSet的列名，可以随意添加
                dt.Columns.Add("_MDirection");
                dt.Columns.Add("_WDirection");
                dt.Columns.Add("_DescribeZ");
                dt.Columns.Add("_CDirection");
                dt.Columns.Add("_DescribeF");
                dt.Columns.Add("_Update");
                dt.Columns.Add("_Delete");

                foreach (var item in obj.dataList)
                {
                    DataRow dr = dt.NewRow();//首先新增一行，然后对其进行赋值
                    dr["_Id"] = item.Id;
                    dr["_MDirection"] = item.MDirection;
                    dr["_WDirection"] = item.WDirection;
                    dr["_DescribeZ"] = item.DescribeZ;
                    dr["_CDirection"] = item.CDirection;
                    dr["_DescribeF"] = item.DescribeF;
                    dr["_Update"] = "修改";
                    dr["_Delete"] = "删除";
                    dt.Rows.Add(dr);//这里一定要add进去
                }
                ds.Tables.Add(dt);//这里也不能忘记


                this.dataGridView.AutoGenerateColumns = false;
                this.dataGridView.DataSource = ds.Tables[0];
                this.dataGridView.Columns["_Id"].DataPropertyName = ds.Tables[0].Columns["_Id"].ToString();
                this.dataGridView.Columns["_MDirection"].DataPropertyName = ds.Tables[0].Columns["_MDirection"].ToString();
                this.dataGridView.Columns["_WDirection"].DataPropertyName = ds.Tables[0].Columns["_WDirection"].ToString();
                this.dataGridView.Columns["_DescribeZ"].DataPropertyName = ds.Tables[0].Columns["_DescribeZ"].ToString();
                this.dataGridView.Columns["_CDirection"].DataPropertyName = ds.Tables[0].Columns["_CDirection"].ToString();
                this.dataGridView.Columns["_DescribeF"].DataPropertyName = ds.Tables[0].Columns["_DescribeF"].ToString();
                this.dataGridView.Columns["_Update"].DataPropertyName = ds.Tables[0].Columns["_Update"].ToString();
                this.dataGridView.Columns["_Delete"].DataPropertyName = ds.Tables[0].Columns["_Delete"].ToString();

                int currentNum = (int)((_offset / _limit) + 1);
                currentIndex = _offset;
                totalNum = ((obj.totalCount % _limit) == 0) ? (int)(obj.totalCount / _limit) : (int)(obj.totalCount / _limit) + 1;

                this.textBox3.Text = currentNum.ToString();    //当前是多少页
                this.label14.Text = (_offset + 1).ToString();    //起始条数
                this.label16.Text = ((_offset + _limit) < obj.totalCount) ? (_offset + _limit).ToString() : obj.totalCount.ToString();    //结束条数
                this.label9.Text = totalNum.ToString();     //共计多少页
                this.label12.Text = obj.totalCount.ToString();    //共计多少条

                if (totalNum == 1)
                {
                    this.button2.Enabled = false;
                    this.button3.Enabled = false;
                    this.button4.Enabled = false;
                    this.button5.Enabled = false;
                }
                else
                {
                    if (currentNum == 1)
                    {
                        this.button2.Enabled = false;
                        this.button3.Enabled = false;
                        this.button4.Enabled = true;
                        this.button5.Enabled = true;
                    }
                    else if (currentNum > 1 && currentNum < totalNum)
                    {
                        this.button2.Enabled = true;
                        this.button3.Enabled = true;
                        this.button4.Enabled = true;
                        this.button5.Enabled = true;
                    }
                    else if (currentNum == totalNum)
                    {
                        this.button2.Enabled = true;
                        this.button3.Enabled = true;
                        this.button4.Enabled = false;
                        this.button5.Enabled = false;
                    }
                }
            }
            else
            {
                this.dataGridView.DataSource = null;
                this.textBox3.Text = "0";
                this.label14.Text = "0";
                this.label16.Text = "0";
                this.label9.Text = "0";
                this.label12.Text = "0";

                this.button2.Enabled = false;
                this.button3.Enabled = false;
                this.button4.Enabled = false;
                this.button5.Enabled = false;
            }
        }

        /// <summary>
        /// 数据区点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string action = dataGridView.Columns[e.ColumnIndex].Name; //操作类型
            var cells = dataGridView.Rows[e.RowIndex].Cells;    //当前行所有列的数据
            if (action.Equals("_Update"))
            {
                if (MessageBox.Show("确定修改这行数据吗?", "修改提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Tb_YZSY yZSY = new Tb_YZSY()
                    {
                        Id = Convert.ToInt32(cells["_Id"].Value),
                        MDirection = Convert.ToString(cells["_MDirection"].Value),
                        WDirection = Convert.ToString(cells["_WDirection"].Value),
                        DescribeZ = Convert.ToString(cells["_DescribeZ"].Value),
                        CDirection = Convert.ToString(cells["_CDirection"].Value),
                        DescribeF = Convert.ToString(cells["_DescribeF"].Value),
                    };
                    List<Tb_YZSY> yZSies = new List<Tb_YZSY>();
                    yZSies.Add(yZSY);
                    DbBaseResult baseResult = YzsyManament.GetInstance().UpdateYzsys(yZSies) as DbBaseResult;
                    if (baseResult == null)
                    {
                        MessageBox.Show("修改失败！");
                    }
                    else
                    {
                        MessageBox.Show($"修改结果：成功{baseResult.SuccessNum}个，总共{baseResult.TotalNum}个！");
                        RefreshYzsyList(Convert.ToInt32(this.comboBox4.SelectedItem.ToString()), currentIndex);
                    }
                }
            }
            if (action.Equals("_Delete"))
            {
                if (MessageBox.Show("确定删除这行数据吗?", "删除提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var _id = cells["_Id"].Value;
                    string[] idArray = new string[] { $"{_id}" };
                    DbBaseResult baseResult = YzsyManament.GetInstance().DeleteYzsys(idArray) as DbBaseResult;
                    if (baseResult == null)
                    {
                        MessageBox.Show("删除失败！");
                    }
                    else
                    {
                        MessageBox.Show($"删除结果：成功{baseResult.SuccessNum}个，总共{baseResult.TotalNum}个！");
                        RefreshYzsyList(Convert.ToInt32(this.comboBox4.SelectedItem.ToString()), currentIndex);
                    }
                }
            }
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            RefreshYzsyList(Convert.ToInt32(this.comboBox4.SelectedItem.ToString()), 0);
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            int startNum = currentIndex - Convert.ToInt32(this.comboBox4.SelectedItem.ToString());
            RefreshYzsyList(Convert.ToInt32(this.comboBox4.SelectedItem.ToString()), startNum);
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            int startNum = currentIndex + Convert.ToInt32(this.comboBox4.SelectedItem.ToString());
            RefreshYzsyList(Convert.ToInt32(this.comboBox4.SelectedItem.ToString()), startNum);
        }

        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            int startNum = (totalNum - 1) * Convert.ToInt32(this.comboBox4.SelectedItem.ToString());
            RefreshYzsyList(Convert.ToInt32(this.comboBox4.SelectedItem.ToString()), startNum);
        }

        /// <summary>
        /// 文件导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            //判断用户是否正确的选择了文件
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择文件的后缀名
                string extension = Path.GetExtension(fileDialog.FileName);
                //声明允许的后缀名
                string[] str = new string[] { ".txt" };
                if (!((IList)str).Contains(extension))
                {
                    MessageBox.Show("仅能上传txt格式的文件！");
                }
                else
                {
                    var lines = File.ReadAllLines(fileDialog.FileName).ToList();
                    while (lines.Count > 0)
                    {
                        for (int i = 1; i < 9; i++)
                        {
                            string str1 = lines[0];
                            ImportParam importZ = new ImportParam()
                            {
                                MDirection = str1.Substring(0, 1),
                                WDirection = str1.Substring(2, 1),
                                DescribeZ = str1.Substring(5, str1.Length - 5),
                                CDirection = lines[i].Substring(0, 1),
                                DescribeF = lines[i].Substring(3, lines[i].Length - 3)
                            };
                            YzsyManament.GetInstance().ImportYzsy(importZ);
                        }
                        lines.RemoveRange(0, 9);
                    }
                    RefreshYzsyList(Convert.ToInt32(this.comboBox4.SelectedItem.ToString()), 0);
                }
            }
        }

        /// <summary>
        /// 删除当前页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 清空所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定清空所有数据吗?", "清空提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                bool flag = YzsyManament.GetInstance().ClearYzsys();
                MessageBox.Show($"清空结果：{flag}");
                RefreshYzsyList(Convert.ToInt32(this.comboBox4.SelectedItem.ToString()), 0);
            }
        }
    }
}
