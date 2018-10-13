namespace CrjConsultation
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butSuper = new System.Windows.Forms.Button();
            this.butIndex = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 223);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.butSuper);
            this.panel2.Controls.Add(this.butIndex);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 223);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 38);
            this.panel2.TabIndex = 2;
            // 
            // butSuper
            // 
            this.butSuper.Location = new System.Drawing.Point(197, 7);
            this.butSuper.Name = "butSuper";
            this.butSuper.Size = new System.Drawing.Size(75, 23);
            this.butSuper.TabIndex = 1;
            this.butSuper.Text = "上一级";
            this.butSuper.UseVisualStyleBackColor = true;
            this.butSuper.Click += new System.EventHandler(this.butSuper_Click);
            // 
            // butIndex
            // 
            this.butIndex.Location = new System.Drawing.Point(12, 6);
            this.butIndex.Name = "butIndex";
            this.butIndex.Size = new System.Drawing.Size(75, 23);
            this.butIndex.TabIndex = 0;
            this.butIndex.Text = "首页";
            this.butIndex.UseVisualStyleBackColor = true;
            this.butIndex.Click += new System.EventHandler(this.butIndex_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butSuper;
        private System.Windows.Forms.Button butIndex;
    }
}

