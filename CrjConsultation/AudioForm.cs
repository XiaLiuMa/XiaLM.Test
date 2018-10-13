using CrjConsultation.AIUI;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CrjConsultation
{
    public partial class AudioForm : Form
    {
        public AudioForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 开始录音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_StartRecord_Click(object sender, EventArgs e)
        {
            Naudio.GetInstance().StartRecord();
        }

        /// <summary>
        /// 停止录音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_StopRecord_Click(object sender, EventArgs e)
        {
            Naudio.GetInstance().StopRecord();
        }

        /// <summary>
        /// 识别+播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Identify_Click(object sender, EventArgs e)
        {
            var filePath = @"C:\Users\Administrator\Desktop\T02.wav";
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                var bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                this.text_Result.Text = XFwebApi.GetInstance().XunFeiIAT(bytes).Data;
                Naudio.GetInstance().PlayAsBytes(bytes);
            }    
        }

        /// <summary>
        /// 自动录音+自动识别+自动播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_AutoAudio_Click(object sender, EventArgs e)
        {
            Naudio.GetInstance().StartRecord();
            Thread.Sleep(10*1000);
            Naudio.GetInstance().StopRecord();
            FileStream fs = new FileStream(@"C:\Users\Administrator\Desktop\T02.wav",FileMode.Open);
            var bytes = new byte[fs.Length];
            fs.Read(bytes, 0, (int)fs.Length);
            this.text_AutoResult.Text = XFwebApi.GetInstance().XunFeiIAT(bytes).Data;
            Naudio.GetInstance().PlayAsBytes(bytes);
        }

        /// <summary>
        /// 合成+播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Synthetic_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.text_Txt.Text))
            {
                var bytes = XFwebApi.GetInstance().XunFeiTTS(this.text_Txt.Text);
                Naudio.GetInstance().PlayAsBytes(bytes);
            }
        }
    }
}
