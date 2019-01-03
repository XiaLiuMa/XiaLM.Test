using AlgorithmClient.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TcpAlgorithmClient;

namespace AlgorithmClient
{
    public partial class MainForm : Form
    {
        public string aIP = string.Empty;  //算法端ip
        public string aPort = string.Empty;    //算法端端口号
        public string jIP = string.Empty;  //java端ip
        public string jPort = string.Empty;    //java端端口号
        public List<SelectFaceInfo> faceList { get; set; }
        /// <summary>
        /// 功能码：跟随
        /// </summary>
        private const byte CODE_FOLLOW = 0x02;
        /// <summary>
        /// 功能码：人脸功能
        /// </summary>
        private const byte CODE_IDENTIFY = 0x03;
        /// <summary>
        /// 功能码：人脸上传
        /// </summary>
        private const byte CODE_UPDATE = 0x04;
        /// <summary>
        /// 功能码：查询名单
        /// </summary>
        private const byte CODE_SELECT = 0x05;
        /// <summary>
        /// 功能码：名单删除
        /// </summary>
        private const byte CODE_DELETE = 0x06;
        /// <summary>
        /// 功能码：清空名单
        /// </summary>
        private const byte CODE_CLEAR = 0x07;
        /// <summary>
        /// 功能码：行人检测
        /// </summary>
        private const byte CODE_DETECTION = 0x20;
        /// <summary>
        /// 功能码：上传行人配置
        /// </summary>
        private const byte CODE_UPDATECONFIG = 0x21;
        private readonly static object objLock = new object();
        private static MainForm instance;
        public static MainForm GetInstance()
        {
            if (instance == null)
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new MainForm();
                    }
                }
            }
            return instance;
        }
        public MainForm()
        {
            InitializeComponent();
            faceList = new List<SelectFaceInfo>();
        }

        private void butStart_Click(object sender, EventArgs e)
        {
            if (ConfigIni())
            {
                AlgorithmClientControl.GetInstance().ConnectServer(aIP, aPort);
                //JavaClientControl.GetInstance().ConnectServer(jIP, jPort);
            }
        }

        /// <summary>
        /// 连接算法服务器
        /// </summary>
        private bool ConfigIni()
        {
            try
            {
                using (FileStream fs = new FileStream("config.ini", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader read = new StreamReader(fs, Encoding.Default))
                    {
                        string strline;
                        while ((strline = read.ReadLine()) != null)
                        {
                            string[] strs = strline.Split('>');
                            if (strs == null || strs.Length < 3) continue;
                            if (strs[0].Equals("AlgorithmServer"))
                            {
                                this.aIP = strs[1];
                                this.aPort = strs[2];
                            }
                            if (strs[0].Equals("JavaServer"))
                            {
                                this.jIP = strs[1];
                                this.jPort = strs[2];
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 启动白名单跟随
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butStaFollow_Click(object sender, EventArgs e)
        {
            RobotClientControl.GetInstance().SendMsg(CODE_FOLLOW, new byte[] { 0x1E });
        }

        /// <summary>
        /// 启动黑名单跟随
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butStaBFollow_Click(object sender, EventArgs e)
        {
            RobotClientControl.GetInstance().SendMsg(CODE_FOLLOW, new byte[] { 0x7E });
        }

        /// <summary>
        /// 关闭跟随
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butStopFollow_Click(object sender, EventArgs e)
        {
            RobotClientControl.GetInstance().SendMsg(CODE_FOLLOW, new byte[] { 0x3E });
        }

        public void butSelectWhite_Click(object sender, EventArgs e)
        {
            RobotClientControl.GetInstance().SendMsg(CODE_SELECT, new byte[] { 0x2E });
        }
        
        public void butSelectBlack_Click(object sender, EventArgs e)
        {
            RobotClientControl.GetInstance().SendMsg(CODE_SELECT, new byte[] { 0x1E });
        }

        public void butSelectAll_Click(object sender, EventArgs e)
        {
            RobotClientControl.GetInstance().SendMsg(CODE_SELECT, new byte[] { 0x3E });
        }

        public void butClearWhite_Click(object sender, EventArgs e)
        {
            RobotClientControl.GetInstance().SendMsg(CODE_CLEAR, new byte[] { 0x1E });
        }

        public void butClearBlack_Click(object sender, EventArgs e)
        {
            RobotClientControl.GetInstance().SendMsg(CODE_CLEAR, new byte[] { 0x2E });
        }

        public void butClearAll_Click(object sender, EventArgs e)
        {
            RobotClientControl.GetInstance().SendMsg(CODE_CLEAR, new byte[] { 0x3E });
        }

        public void butStartIdentify_Click(object sender, EventArgs e)
        {
            RobotClientControl.GetInstance().SendMsg(CODE_IDENTIFY, new byte[] { 0x1E });
        }

        public void butStopIdentify_Click(object sender, EventArgs e)
        {
            RobotClientControl.GetInstance().SendMsg(CODE_IDENTIFY, new byte[] { 0x3E });
        }

        public void butDeleteWhite_Click(object sender, EventArgs e)
        {
            List<SelectFaceInfo> tempList = faceList.Where(p => p.type.Equals("white")).ToList();
            int num = int.Parse(this.tBoxWhiteNum.Text.Trim());
            if (num > tempList.Count - 1) return;
            DeleteFaceInfo deleteFaceInfo = new DeleteFaceInfo()
            {
                type = tempList[num].type,
                serialnumber = tempList[num].serialnumber
            };
            string jsonStr = JsonConvert.SerializeObject(deleteFaceInfo);
            byte[] bytes = Encoding.UTF8.GetBytes(jsonStr);
            RobotClientControl.GetInstance().SendMsg(CODE_DELETE, bytes);
        }

        public void butDeleteBlack_Click(object sender, EventArgs e)
        {
            List<SelectFaceInfo> tempList = faceList.Where(p => p.type.Equals("black")).ToList();
            int num = int.Parse(this.tBoxBlackNum.Text.Trim());
            if (num > tempList.Count - 1) return;
            DeleteFaceInfo deleteFaceInfo = new DeleteFaceInfo()
            {
                type = tempList[num].type,
                serialnumber = tempList[num].serialnumber
            };
            string jsonStr = JsonConvert.SerializeObject(deleteFaceInfo);
            byte[] bytes = Encoding.UTF8.GetBytes(jsonStr);
            RobotClientControl.GetInstance().SendMsg(CODE_DELETE, bytes);
        }

        private void butCheckFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                this.tBoxFilename.Text = fileDialog.FileName;
            }
        }

        public void butUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tBoxFilename.Text.Trim())) return;
            byte[] tempBytes;   //图片字节数组
            using (FileStream fs = new FileStream(this.tBoxFilename.Text.Trim(), FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    tempBytes = br.ReadBytes((int)fs.Length);
                }
            }
            //bas64编码
            string base64txt = Convert.ToBase64String(tempBytes);
            UploadFaceInfo uploadFaceInfo = new UploadFaceInfo()
            {
                type = this.checkBoxType.Checked ? "white" : "black",
                serialnumber = this.tBoxSerialnumber.Text.Trim(),
                name = this.tBoxName.Text.Trim(),
                sex = this.checkBoxSex.Checked ? "男" : "女",
                idnumber = this.tBoxIdnumber.Text.Trim(),
                filename = Path.GetFileName(this.tBoxFilename.Text.Trim()),
                imagebytes = base64txt
            };
            string jsonStr = JsonConvert.SerializeObject(uploadFaceInfo);
            byte[] bytes = Encoding.UTF8.GetBytes(jsonStr);
            RobotClientControl.GetInstance().SendMsg(CODE_UPDATE, bytes);
        }
        
        private void butStartDetection_Click(object sender, EventArgs e)
        {
            RobotClientControl.GetInstance().SendMsg(CODE_DETECTION, new byte[] { 0x1E });
        }

        private void butStopDetection_Click(object sender, EventArgs e)
        {
            RobotClientControl.GetInstance().SendMsg(CODE_DETECTION, new byte[] { 0x3E });
        }

        private void butGetConfig_Click(object sender, EventArgs e)
        {
            RobotClientControl.GetInstance().SendMsg(CODE_DETECTION, new byte[] { 0x5E });
        }

        private void butUpConfig_Click(object sender, EventArgs e)
        {
            PedestriansConfig pedestriansConfig = new PedestriansConfig()
            {
                type = 1,
                X1 = 100,
                Y1 = 100,
                X2 = 200,
                Y2 = 200
            };
            string jsonStr = JsonConvert.SerializeObject(pedestriansConfig);
            byte[] bytes = Encoding.UTF8.GetBytes(jsonStr);
            RobotClientControl.GetInstance().SendMsg(CODE_UPDATECONFIG, bytes);
        }

        private void butClearCode_Click(object sender, EventArgs e)
        {
            this.rTxtCode.Clear();
        }

        private void butClearHeart_Click(object sender, EventArgs e)
        {
            this.rTxtHeart.Clear();
        }

        private void butClearOffset_Click(object sender, EventArgs e)
        {
            this.rTxtOffset.Clear();
        }

        private void butClearLog_Click(object sender, EventArgs e)
        {
            this.rTxtLog.Clear();
        }
        
        private void butClearJavaCode_Click(object sender, EventArgs e)
        {
            this.rTextJavaCode.Clear();
        }

        private void rTxtHeart_TextChanged(object sender, EventArgs e)
        {
            if (this.rTxtHeart.Lines.Length >= 1000)
            {
                var tempStr = this.rTxtHeart.Lines.Last();
                var sumStart = this.rTxtHeart.Text.Length - tempStr.Length - 1;
                this.rTxtHeart.Text = this.rTxtHeart.Text.Remove(sumStart, tempStr.Length);
            }
        }

        private void rTxtCode_TextChanged(object sender, EventArgs e)
        {
            if (this.rTxtCode.Lines.Length >= 1000)
            {
                var tempStr = this.rTxtCode.Lines.Last();
                var sumStart = this.rTxtCode.Text.Length - tempStr.Length - 1;
                this.rTxtCode.Text = this.rTxtCode.Text.Remove(sumStart, tempStr.Length);
            }
        }

        private void rTxtOffset_TextChanged(object sender, EventArgs e)
        {
            if (this.rTxtHeart.Lines.Length >= 1000)
            {
                var tempStr = this.rTxtOffset.Lines.Last();
                var sumStart = this.rTxtOffset.Text.Length - tempStr.Length - 1;
                this.rTxtOffset.Text = this.rTxtOffset.Text.Remove(sumStart, tempStr.Length);
            }
        }

        private void rTxtLog_TextChanged(object sender, EventArgs e)
        {
            if (this.rTxtLog.Lines.Length >= 1000)
            {
                var tempStr = this.rTxtLog.Lines.Last();
                var sumStart = this.rTxtLog.Text.Length - tempStr.Length - 1;
                this.rTxtLog.Text = this.rTxtLog.Text.Remove(sumStart, tempStr.Length);
            }
        }

        private void rTextJavaCode_TextChanged(object sender, EventArgs e)
        {
            if (this.rTextJavaCode.Lines.Length >= 1000)
            {
                var tempStr = this.rTextJavaCode.Lines.Last();
                var sumStart = this.rTextJavaCode.Text.Length - tempStr.Length - 1;
                this.rTextJavaCode.Text = this.rTextJavaCode.Text.Remove(sumStart, tempStr.Length);
            }
        }

    }
}
