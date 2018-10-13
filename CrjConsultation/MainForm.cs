using CrjConsultation.AIUI;
using CrjConsultation.Help;
using CrjConsultation.Model;
using CrjConsultation.UserControl;
using NAudio.Wave;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CrjConsultation
{
    public partial class MainForm : Form
    {
        public const int MAX_INT = 2147483647;  //常量int最大值减下标
        public ISheet sheet { get; set; }  //sheet处理接口
        public WaveFileWriter wfw { get; set; }    //音频文件写入类
        public bool autoRecord { get; set; } = false;  //播放完毕后是否自动录音
        private List<Qnode> listQnode { get; set; } //链表记录当前层级节点关系路径

        public MainForm()
        {
            InitializeComponent();
            IndexStepInit();
            Naudio.GetInstance().waveIn.RecordingStopped += WaveIn_RecordingStopped;
            Naudio.GetInstance().waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
            Naudio.GetInstance().PlayEnd += MainForm_PlayEnd;
        }

        /// <summary>
        /// 录音结束事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaveIn_RecordingStopped(object sender, NAudio.Wave.StoppedEventArgs e)
        {
            Naudio.GetInstance().wfw.Dispose();
            Naudio.GetInstance().wfw = null;
            var bytes = File.ReadAllBytes(Naudio.GetInstance().fileName);
            var txt = XFwebApi.GetInstance().XunFeiIAT(bytes).Data;
            DealIdentifyResult(txt);
        }

        /// <summary>
        /// 播放结束事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaveOut_PlaybackStopped(object sender, NAudio.Wave.StoppedEventArgs e)
        {
            //Naudio.GetInstance().StartRecord();
        }

        /// <summary>
        /// 自定义播放结束事件
        /// 自带的播放结束事件经常不会触发，自己写个事件
        /// </summary>
        private void MainForm_PlayEnd()
        {
            if (autoRecord)
            {
                Naudio.GetInstance().StartRecord();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowCells();
        }

        /// <summary>
        /// 首页初始化
        /// </summary>
        private void IndexStepInit()
        {
            IWorkbook workbook = null;
            var execlPath = @"C:\Users\Administrator\Desktop\出入境咨询服务.xlsx";
            using (FileStream fs = File.OpenRead(execlPath))
            {
                //判断文件格式:HSSF只能读取xls,XSSF只能读取xlsx格式的
                if (Path.GetExtension(fs.Name) == ".xls")
                {
                    workbook = new HSSFWorkbook(fs);
                }
                else if (Path.GetExtension(fs.Name) == ".xlsx")
                {
                    workbook = new XSSFWorkbook(fs);
                }
            }
            sheet = workbook.GetSheetAt(0);
            var indexQP = new Qpoint { Y = 0, X = 0, Xspan = MAX_INT }; //首页问题坐标
            var qpList = SearchSells(indexQP);  //首页问题列表
            listQnode = new List<Qnode> { new Qnode { TSY = "请选择出入境类型?", Qpoints = qpList } };
        }

        /// <summary>
        /// 返回首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butIndex_Click(object sender, EventArgs e)
        {
            listQnode.RemoveRange(1, listQnode.Count - 1);    //从下标为1的后面全部移除
            ShowCells();
        }

        /// <summary>
        /// 返回上一级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butSuper_Click(object sender, EventArgs e)
        {
            listQnode.Remove(listQnode.Last());   //先，移除最后一个节点。
            ShowCells();   //再，最后一个节点展示。
        }

        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClickEvent(object sender, EventArgs e)
        {
            QButton button = (QButton)sender; //当前被点击的按钮
            var qpList = SearchSells(button.QPoint);
            listQnode.Add(new Qnode { TSY = button.QPoint.TSY, Qpoints = qpList });
            ShowCells();
        }

        /// <summary>
        /// 根据坐标查询符合条件的单元格
        /// </summary>
        /// <param name="qpoint">问题坐标</param>
        private List<Qpoint> SearchSells(Qpoint qpoint)
        {
            List<Qpoint> tempList = new List<Qpoint>();
            //符合坐标要求的,所有单元格
            var cells = sheet.GetRow(qpoint.Y + 1).Cells.FindAll(
                p => (p.ColumnIndex >= qpoint.X && p.ColumnIndex < qpoint.Xspan) && !string.IsNullOrEmpty(p.StringCellValue));
            if (cells != null && cells.Count > 0)
            {
                for (int i = 0; i < cells.Count; i++)
                {
                    var tempSpan = qpoint.Xspan;   //X轴跨度
                    if (i + 1 < cells.Count)
                    {
                        tempSpan = cells[i + 1].ColumnIndex;
                    }
                    var strArray = cells[i].StringCellValue.Split('>'); //分割单元格中的文本
                    if (strArray != null && strArray.Length > 0)
                    {
                        if (strArray.Length < 2)
                        {
                            tempList.Add(new Qpoint
                            {
                                Y = cells[i].RowIndex,
                                X = cells[i].ColumnIndex,
                                Xspan = tempSpan,
                                Text = strArray[0],
                                TSY = string.Empty,
                                IsEnd = true
                            });
                        }
                        else
                        {
                            tempList.Add(new Qpoint
                            {
                                Y = cells[i].RowIndex,
                                X = cells[i].ColumnIndex,
                                Xspan = tempSpan,
                                Text = strArray[0],
                                TSY = strArray[1],
                                IsEnd = false
                            });
                        }
                    }
                }
            }
            return tempList;
        }

        /// <summary>
        /// 展示队列中最后一个节点
        /// </summary>
        public void ShowCells()
        {
            var qnode = listQnode.Last();
            this.panel1.Controls.Clear();//清除面板
            if (listQnode.Count > 1)
            {
                this.butIndex.Enabled = true;
                this.butSuper.Enabled = true;
            }
            else
            {
                this.butIndex.Enabled = false;
                this.butSuper.Enabled = false;
            }
            Label label = new Label();
            label.Location = new Point(100, 10);
            label.Text = qnode.TSY;
            this.panel1.Controls.Add(label);
            if (qnode.Qpoints != null && qnode.Qpoints.Count > 0)
            {
                int xLocation = 100;  //x轴位置
                int yLocation = 50;  //y轴位置
                int butNum = 0;
                foreach (Qpoint qpoint in qnode.Qpoints)
                {
                    QButton button = new QButton();
                    button.Location = new Point(xLocation, yLocation);
                    button.Text = qpoint.Text;
                    button.Click += ClickEvent;
                    button.QPoint = qpoint;
                    this.panel1.Controls.Add(button);
                    yLocation += 30;
                    butNum++;
                }
            }

            autoRecord = true;
            Naudio.GetInstance().PlayText(qnode.TSY);
        }

        /// <summary>
        /// 处理识别结果
        /// </summary>
        /// <param name="txt"></param>
        public void DealIdentifyResult(string txt)
        {
            string[] strsIndex = { "返回首页", "回到首页", "进入首页" };    //首页命令
            string[] strsPrevious = { "上一步", "后退", "返回上一步" };    //上一步命令
            if (((IList)strsIndex).Contains(txt))
            {
                this.butIndex.PerformClick();
            }
            else if (((IList)strsPrevious).Contains(txt))
            {
                this.butSuper.PerformClick();
            }
            else
            {
                var qpoint = SelectSimilarityObj(txt, listQnode.Last().Qpoints);
                if (qpoint != null)
                {
                    var qpList = SearchSells(qpoint);
                    listQnode.Add(new Qnode { TSY = qpoint.TSY, Qpoints = qpList });
                    ShowCells();
                }
                else
                {
                    autoRecord = false;
                    Naudio.GetInstance().PlayText("没找到'" + txt + "'，请尝试点击屏幕中的选项！");
                }
            }
        }

        /// <summary>
        /// 查找相似对象
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="qpList"></param>
        /// <returns></returns>
        public Qpoint SelectSimilarityObj(string txt, List<Qpoint> qpList)
        {
            if (qpList != null && qpList.Count > 0)
            {
                int max = -1;   //没有最大值的下标
                float[] rateArray = new float[qpList.Count];
                for (int i = 0; i < qpList.Count; i++)
                {
                    StringCompute stringcompute1 = new StringCompute();
                    stringcompute1.SpeedyCompute(txt, qpList[i].Text);
                    rateArray[i] = (float)stringcompute1.ComputeResult.Rate;
                }
                for (int j = 0; j < rateArray.Length; j++)
                {
                    if (rateArray[j] == rateArray.Max() && rateArray[j] > 0.6)
                    {
                        max = j;    //有最大值相似度，且最大相似度大于60%才算匹配成功
                    }
                }
                if (max >= 0)
                {
                    return qpList[max];
                }
            }
            return null;
        }

    }
}
