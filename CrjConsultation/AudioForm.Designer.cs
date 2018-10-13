namespace CrjConsultation
{
    partial class AudioForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.but_StartRecord = new System.Windows.Forms.Button();
            this.but_StopRecord = new System.Windows.Forms.Button();
            this.but_Identify = new System.Windows.Forms.Button();
            this.but_AutoAudio = new System.Windows.Forms.Button();
            this.text_Result = new System.Windows.Forms.TextBox();
            this.text_AutoResult = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.text_Txt = new System.Windows.Forms.TextBox();
            this.but_Synthetic = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.text_AutoResult);
            this.panel1.Controls.Add(this.text_Result);
            this.panel1.Controls.Add(this.but_AutoAudio);
            this.panel1.Controls.Add(this.but_Identify);
            this.panel1.Controls.Add(this.but_StartRecord);
            this.panel1.Controls.Add(this.but_StopRecord);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 99);
            this.panel1.TabIndex = 0;
            // 
            // but_StartRecord
            // 
            this.but_StartRecord.Location = new System.Drawing.Point(11, 18);
            this.but_StartRecord.Name = "but_StartRecord";
            this.but_StartRecord.Size = new System.Drawing.Size(65, 23);
            this.but_StartRecord.TabIndex = 1;
            this.but_StartRecord.Text = "开始录音";
            this.but_StartRecord.UseVisualStyleBackColor = true;
            this.but_StartRecord.Click += new System.EventHandler(this.but_StartRecord_Click);
            // 
            // but_StopRecord
            // 
            this.but_StopRecord.Location = new System.Drawing.Point(82, 18);
            this.but_StopRecord.Name = "but_StopRecord";
            this.but_StopRecord.Size = new System.Drawing.Size(62, 23);
            this.but_StopRecord.TabIndex = 2;
            this.but_StopRecord.Text = "停止录音";
            this.but_StopRecord.UseVisualStyleBackColor = true;
            this.but_StopRecord.Click += new System.EventHandler(this.but_StopRecord_Click);
            // 
            // but_Identify
            // 
            this.but_Identify.Location = new System.Drawing.Point(150, 18);
            this.but_Identify.Name = "but_Identify";
            this.but_Identify.Size = new System.Drawing.Size(98, 23);
            this.but_Identify.TabIndex = 3;
            this.but_Identify.Text = "识别+播放";
            this.but_Identify.UseVisualStyleBackColor = true;
            this.but_Identify.Click += new System.EventHandler(this.but_Identify_Click);
            // 
            // but_AutoAudio
            // 
            this.but_AutoAudio.Location = new System.Drawing.Point(11, 58);
            this.but_AutoAudio.Name = "but_AutoAudio";
            this.but_AutoAudio.Size = new System.Drawing.Size(237, 23);
            this.but_AutoAudio.TabIndex = 4;
            this.but_AutoAudio.Text = "自动录音+自动识别+自动播放";
            this.but_AutoAudio.UseVisualStyleBackColor = true;
            this.but_AutoAudio.Click += new System.EventHandler(this.but_AutoAudio_Click);
            // 
            // text_Result
            // 
            this.text_Result.Location = new System.Drawing.Point(254, 20);
            this.text_Result.Name = "text_Result";
            this.text_Result.ReadOnly = true;
            this.text_Result.Size = new System.Drawing.Size(241, 21);
            this.text_Result.TabIndex = 5;
            // 
            // text_AutoResult
            // 
            this.text_AutoResult.Location = new System.Drawing.Point(254, 60);
            this.text_AutoResult.Name = "text_AutoResult";
            this.text_AutoResult.ReadOnly = true;
            this.text_AutoResult.Size = new System.Drawing.Size(241, 21);
            this.text_AutoResult.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.but_Synthetic);
            this.panel2.Controls.Add(this.text_Txt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(508, 56);
            this.panel2.TabIndex = 1;
            // 
            // text_Txt
            // 
            this.text_Txt.Location = new System.Drawing.Point(11, 17);
            this.text_Txt.Name = "text_Txt";
            this.text_Txt.Size = new System.Drawing.Size(323, 21);
            this.text_Txt.TabIndex = 6;
            // 
            // but_Synthetic
            // 
            this.but_Synthetic.Location = new System.Drawing.Point(340, 15);
            this.but_Synthetic.Name = "but_Synthetic";
            this.but_Synthetic.Size = new System.Drawing.Size(155, 23);
            this.but_Synthetic.TabIndex = 7;
            this.but_Synthetic.Text = "合成+播放";
            this.but_Synthetic.UseVisualStyleBackColor = true;
            this.but_Synthetic.Click += new System.EventHandler(this.but_Synthetic_Click);
            // 
            // AudioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 155);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AudioForm";
            this.Text = "AudioForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button but_StartRecord;
        private System.Windows.Forms.Button but_StopRecord;
        private System.Windows.Forms.Button but_Identify;
        private System.Windows.Forms.Button but_AutoAudio;
        private System.Windows.Forms.TextBox text_Result;
        private System.Windows.Forms.TextBox text_AutoResult;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox text_Txt;
        private System.Windows.Forms.Button but_Synthetic;
    }
}