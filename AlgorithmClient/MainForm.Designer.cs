namespace AlgorithmClient
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
            this.butStopIdentify = new System.Windows.Forms.Button();
            this.butStartIdentify = new System.Windows.Forms.Button();
            this.butClearAll = new System.Windows.Forms.Button();
            this.butClearBlack = new System.Windows.Forms.Button();
            this.butClearWhite = new System.Windows.Forms.Button();
            this.butStopFollow = new System.Windows.Forms.Button();
            this.butStaFollow = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rTxtHeart = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rTxtCode = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rTxtOffset = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rTxtLog = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tBoxBlackNum = new System.Windows.Forms.TextBox();
            this.tBoxWhiteNum = new System.Windows.Forms.TextBox();
            this.butDeleteBlack = new System.Windows.Forms.Button();
            this.rTxtSelect = new System.Windows.Forms.RichTextBox();
            this.butDeleteWhite = new System.Windows.Forms.Button();
            this.butSelectAll = new System.Windows.Forms.Button();
            this.butSelectBlack = new System.Windows.Forms.Button();
            this.butSelectWhite = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.butUpdate = new System.Windows.Forms.Button();
            this.butCheckFile = new System.Windows.Forms.Button();
            this.tBoxFilename = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tBoxIdnumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tBoxName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tBoxSerialnumber = new System.Windows.Forms.TextBox();
            this.checkBoxSex = new System.Windows.Forms.CheckBox();
            this.checkBoxType = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.butClearCode = new System.Windows.Forms.Button();
            this.butClearHeart = new System.Windows.Forms.Button();
            this.butClearOffset = new System.Windows.Forms.Button();
            this.butClearLog = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.rTextJavaCode = new System.Windows.Forms.RichTextBox();
            this.butClearJavaCode = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.butStart = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.butUpConfig = new System.Windows.Forms.Button();
            this.butGetConfig = new System.Windows.Forms.Button();
            this.butStopDetection = new System.Windows.Forms.Button();
            this.butStartDetection = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.butStaBFollow = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.butStaBFollow);
            this.panel1.Controls.Add(this.butStopIdentify);
            this.panel1.Controls.Add(this.butStartIdentify);
            this.panel1.Controls.Add(this.butClearAll);
            this.panel1.Controls.Add(this.butClearBlack);
            this.panel1.Controls.Add(this.butClearWhite);
            this.panel1.Controls.Add(this.butStopFollow);
            this.panel1.Controls.Add(this.butStaFollow);
            this.panel1.Location = new System.Drawing.Point(266, 215);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 98);
            this.panel1.TabIndex = 0;
            // 
            // butStopIdentify
            // 
            this.butStopIdentify.Location = new System.Drawing.Point(177, 66);
            this.butStopIdentify.Name = "butStopIdentify";
            this.butStopIdentify.Size = new System.Drawing.Size(67, 23);
            this.butStopIdentify.TabIndex = 9;
            this.butStopIdentify.Text = "关闭人脸";
            this.butStopIdentify.UseVisualStyleBackColor = true;
            this.butStopIdentify.Click += new System.EventHandler(this.butStopIdentify_Click);
            // 
            // butStartIdentify
            // 
            this.butStartIdentify.Location = new System.Drawing.Point(3, 66);
            this.butStartIdentify.Name = "butStartIdentify";
            this.butStartIdentify.Size = new System.Drawing.Size(67, 23);
            this.butStartIdentify.TabIndex = 8;
            this.butStartIdentify.Text = "开启人脸";
            this.butStartIdentify.UseVisualStyleBackColor = true;
            this.butStartIdentify.Click += new System.EventHandler(this.butStartIdentify_Click);
            // 
            // butClearAll
            // 
            this.butClearAll.Location = new System.Drawing.Point(149, 37);
            this.butClearAll.Name = "butClearAll";
            this.butClearAll.Size = new System.Drawing.Size(95, 23);
            this.butClearAll.TabIndex = 7;
            this.butClearAll.Text = "清空全部名单";
            this.butClearAll.UseVisualStyleBackColor = true;
            this.butClearAll.Click += new System.EventHandler(this.butClearAll_Click);
            // 
            // butClearBlack
            // 
            this.butClearBlack.Location = new System.Drawing.Point(78, 37);
            this.butClearBlack.Name = "butClearBlack";
            this.butClearBlack.Size = new System.Drawing.Size(76, 23);
            this.butClearBlack.TabIndex = 6;
            this.butClearBlack.Text = "清空白名单";
            this.butClearBlack.UseVisualStyleBackColor = true;
            this.butClearBlack.Click += new System.EventHandler(this.butClearBlack_Click);
            // 
            // butClearWhite
            // 
            this.butClearWhite.Location = new System.Drawing.Point(3, 37);
            this.butClearWhite.Name = "butClearWhite";
            this.butClearWhite.Size = new System.Drawing.Size(76, 23);
            this.butClearWhite.TabIndex = 5;
            this.butClearWhite.Text = "清空黑名单";
            this.butClearWhite.UseVisualStyleBackColor = true;
            this.butClearWhite.Click += new System.EventHandler(this.butClearWhite_Click);
            // 
            // butStopFollow
            // 
            this.butStopFollow.Location = new System.Drawing.Point(177, 8);
            this.butStopFollow.Name = "butStopFollow";
            this.butStopFollow.Size = new System.Drawing.Size(67, 23);
            this.butStopFollow.TabIndex = 4;
            this.butStopFollow.Text = "关闭跟随";
            this.butStopFollow.UseVisualStyleBackColor = true;
            this.butStopFollow.Click += new System.EventHandler(this.butStopFollow_Click);
            // 
            // butStaFollow
            // 
            this.butStaFollow.Location = new System.Drawing.Point(3, 8);
            this.butStaFollow.Name = "butStaFollow";
            this.butStaFollow.Size = new System.Drawing.Size(76, 23);
            this.butStaFollow.TabIndex = 3;
            this.butStaFollow.Text = "启动W跟随";
            this.butStaFollow.UseVisualStyleBackColor = true;
            this.butStaFollow.Click += new System.EventHandler(this.butStaFollow_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rTxtHeart);
            this.panel2.Location = new System.Drawing.Point(8, 348);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(249, 282);
            this.panel2.TabIndex = 1;
            // 
            // rTxtHeart
            // 
            this.rTxtHeart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtHeart.Location = new System.Drawing.Point(0, 0);
            this.rTxtHeart.Name = "rTxtHeart";
            this.rTxtHeart.Size = new System.Drawing.Size(247, 280);
            this.rTxtHeart.TabIndex = 1;
            this.rTxtHeart.Text = "";
            this.rTxtHeart.TextChanged += new System.EventHandler(this.rTxtHeart_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "心跳";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rTxtCode);
            this.panel3.Location = new System.Drawing.Point(262, 348);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(253, 282);
            this.panel3.TabIndex = 2;
            // 
            // rTxtCode
            // 
            this.rTxtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtCode.Location = new System.Drawing.Point(0, 0);
            this.rTxtCode.Name = "rTxtCode";
            this.rTxtCode.Size = new System.Drawing.Size(251, 280);
            this.rTxtCode.TabIndex = 2;
            this.rTxtCode.Text = "";
            this.rTxtCode.TextChanged += new System.EventHandler(this.rTxtCode_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "命令码";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rTxtOffset);
            this.panel4.Location = new System.Drawing.Point(521, 348);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(249, 282);
            this.panel4.TabIndex = 3;
            // 
            // rTxtOffset
            // 
            this.rTxtOffset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtOffset.Location = new System.Drawing.Point(0, 0);
            this.rTxtOffset.Name = "rTxtOffset";
            this.rTxtOffset.Size = new System.Drawing.Size(247, 280);
            this.rTxtOffset.TabIndex = 2;
            this.rTxtOffset.Text = "";
            this.rTxtOffset.TextChanged += new System.EventHandler(this.rTxtOffset_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(577, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "人脸偏移量";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.rTxtLog);
            this.panel5.Location = new System.Drawing.Point(773, 29);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(243, 600);
            this.panel5.TabIndex = 4;
            // 
            // rTxtLog
            // 
            this.rTxtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtLog.Location = new System.Drawing.Point(0, 0);
            this.rTxtLog.Name = "rTxtLog";
            this.rTxtLog.Size = new System.Drawing.Size(241, 598);
            this.rTxtLog.TabIndex = 2;
            this.rTxtLog.Text = "";
            this.rTxtLog.TextChanged += new System.EventHandler(this.rTxtLog_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(854, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "调试日志";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.tBoxBlackNum);
            this.panel6.Controls.Add(this.tBoxWhiteNum);
            this.panel6.Controls.Add(this.butDeleteBlack);
            this.panel6.Controls.Add(this.rTxtSelect);
            this.panel6.Controls.Add(this.butDeleteWhite);
            this.panel6.Controls.Add(this.butSelectAll);
            this.panel6.Controls.Add(this.butSelectBlack);
            this.panel6.Controls.Add(this.butSelectWhite);
            this.panel6.Location = new System.Drawing.Point(7, 179);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(249, 134);
            this.panel6.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "删除的黑名单编号";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "删除的白名单编号";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tBoxBlackNum
            // 
            this.tBoxBlackNum.Location = new System.Drawing.Point(108, 109);
            this.tBoxBlackNum.Name = "tBoxBlackNum";
            this.tBoxBlackNum.Size = new System.Drawing.Size(54, 21);
            this.tBoxBlackNum.TabIndex = 11;
            this.tBoxBlackNum.Text = "1";
            // 
            // tBoxWhiteNum
            // 
            this.tBoxWhiteNum.Location = new System.Drawing.Point(108, 76);
            this.tBoxWhiteNum.Name = "tBoxWhiteNum";
            this.tBoxWhiteNum.Size = new System.Drawing.Size(54, 21);
            this.tBoxWhiteNum.TabIndex = 10;
            this.tBoxWhiteNum.Text = "1";
            // 
            // butDeleteBlack
            // 
            this.butDeleteBlack.Location = new System.Drawing.Point(168, 107);
            this.butDeleteBlack.Name = "butDeleteBlack";
            this.butDeleteBlack.Size = new System.Drawing.Size(76, 23);
            this.butDeleteBlack.TabIndex = 9;
            this.butDeleteBlack.Text = "删除黑名单";
            this.butDeleteBlack.UseVisualStyleBackColor = true;
            this.butDeleteBlack.Click += new System.EventHandler(this.butDeleteBlack_Click);
            // 
            // rTxtSelect
            // 
            this.rTxtSelect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTxtSelect.Location = new System.Drawing.Point(3, 33);
            this.rTxtSelect.Name = "rTxtSelect";
            this.rTxtSelect.Size = new System.Drawing.Size(241, 41);
            this.rTxtSelect.TabIndex = 8;
            this.rTxtSelect.Text = "";
            // 
            // butDeleteWhite
            // 
            this.butDeleteWhite.Location = new System.Drawing.Point(168, 78);
            this.butDeleteWhite.Name = "butDeleteWhite";
            this.butDeleteWhite.Size = new System.Drawing.Size(76, 23);
            this.butDeleteWhite.TabIndex = 7;
            this.butDeleteWhite.Text = "删除白名单";
            this.butDeleteWhite.UseVisualStyleBackColor = true;
            this.butDeleteWhite.Click += new System.EventHandler(this.butDeleteWhite_Click);
            // 
            // butSelectAll
            // 
            this.butSelectAll.Location = new System.Drawing.Point(149, 4);
            this.butSelectAll.Name = "butSelectAll";
            this.butSelectAll.Size = new System.Drawing.Size(95, 23);
            this.butSelectAll.TabIndex = 6;
            this.butSelectAll.Text = "查询全部名单";
            this.butSelectAll.UseVisualStyleBackColor = true;
            this.butSelectAll.Click += new System.EventHandler(this.butSelectAll_Click);
            // 
            // butSelectBlack
            // 
            this.butSelectBlack.Location = new System.Drawing.Point(76, 4);
            this.butSelectBlack.Name = "butSelectBlack";
            this.butSelectBlack.Size = new System.Drawing.Size(76, 23);
            this.butSelectBlack.TabIndex = 5;
            this.butSelectBlack.Text = "查询黑名单";
            this.butSelectBlack.UseVisualStyleBackColor = true;
            this.butSelectBlack.Click += new System.EventHandler(this.butSelectBlack_Click);
            // 
            // butSelectWhite
            // 
            this.butSelectWhite.Location = new System.Drawing.Point(3, 4);
            this.butSelectWhite.Name = "butSelectWhite";
            this.butSelectWhite.Size = new System.Drawing.Size(76, 23);
            this.butSelectWhite.TabIndex = 4;
            this.butSelectWhite.Text = "查询白名单";
            this.butSelectWhite.UseVisualStyleBackColor = true;
            this.butSelectWhite.Click += new System.EventHandler(this.butSelectWhite_Click);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.butUpdate);
            this.panel7.Controls.Add(this.butCheckFile);
            this.panel7.Controls.Add(this.tBoxFilename);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.tBoxIdnumber);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.tBoxName);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Controls.Add(this.tBoxSerialnumber);
            this.panel7.Controls.Add(this.checkBoxSex);
            this.panel7.Controls.Add(this.checkBoxType);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(522, 181);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(249, 132);
            this.panel7.TabIndex = 6;
            // 
            // butUpdate
            // 
            this.butUpdate.Location = new System.Drawing.Point(7, 106);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(238, 23);
            this.butUpdate.TabIndex = 19;
            this.butUpdate.Text = "上传人脸";
            this.butUpdate.UseVisualStyleBackColor = true;
            this.butUpdate.Click += new System.EventHandler(this.butUpdate_Click);
            // 
            // butCheckFile
            // 
            this.butCheckFile.Location = new System.Drawing.Point(178, 80);
            this.butCheckFile.Name = "butCheckFile";
            this.butCheckFile.Size = new System.Drawing.Size(67, 23);
            this.butCheckFile.TabIndex = 18;
            this.butCheckFile.Text = "选择文件";
            this.butCheckFile.UseVisualStyleBackColor = true;
            this.butCheckFile.Click += new System.EventHandler(this.butCheckFile_Click);
            // 
            // tBoxFilename
            // 
            this.tBoxFilename.Location = new System.Drawing.Point(57, 82);
            this.tBoxFilename.Name = "tBoxFilename";
            this.tBoxFilename.ReadOnly = true;
            this.tBoxFilename.Size = new System.Drawing.Size(115, 21);
            this.tBoxFilename.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "文件名";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tBoxIdnumber
            // 
            this.tBoxIdnumber.Location = new System.Drawing.Point(57, 53);
            this.tBoxIdnumber.Name = "tBoxIdnumber";
            this.tBoxIdnumber.Size = new System.Drawing.Size(188, 21);
            this.tBoxIdnumber.TabIndex = 15;
            this.tBoxIdnumber.Text = "1001123456";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "身份证";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tBoxName
            // 
            this.tBoxName.Location = new System.Drawing.Point(171, 25);
            this.tBoxName.Name = "tBoxName";
            this.tBoxName.Size = new System.Drawing.Size(74, 21);
            this.tBoxName.TabIndex = 13;
            this.tBoxName.Text = "张山";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(134, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "姓名";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tBoxSerialnumber
            // 
            this.tBoxSerialnumber.Location = new System.Drawing.Point(43, 25);
            this.tBoxSerialnumber.Name = "tBoxSerialnumber";
            this.tBoxSerialnumber.Size = new System.Drawing.Size(73, 21);
            this.tBoxSerialnumber.TabIndex = 11;
            this.tBoxSerialnumber.Text = "10011";
            // 
            // checkBoxSex
            // 
            this.checkBoxSex.AutoSize = true;
            this.checkBoxSex.Location = new System.Drawing.Point(158, 6);
            this.checkBoxSex.Name = "checkBoxSex";
            this.checkBoxSex.Size = new System.Drawing.Size(60, 16);
            this.checkBoxSex.TabIndex = 5;
            this.checkBoxSex.Text = "男性？";
            this.checkBoxSex.UseVisualStyleBackColor = true;
            // 
            // checkBoxType
            // 
            this.checkBoxType.AutoSize = true;
            this.checkBoxType.Location = new System.Drawing.Point(33, 6);
            this.checkBoxType.Name = "checkBoxType";
            this.checkBoxType.Size = new System.Drawing.Size(72, 16);
            this.checkBoxType.TabIndex = 4;
            this.checkBoxType.Text = "白名单？";
            this.checkBoxType.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "编号";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // butClearCode
            // 
            this.butClearCode.Location = new System.Drawing.Point(388, 317);
            this.butClearCode.Name = "butClearCode";
            this.butClearCode.Size = new System.Drawing.Size(67, 23);
            this.butClearCode.TabIndex = 10;
            this.butClearCode.Text = "清除";
            this.butClearCode.UseVisualStyleBackColor = true;
            this.butClearCode.Click += new System.EventHandler(this.butClearCode_Click);
            // 
            // butClearHeart
            // 
            this.butClearHeart.Location = new System.Drawing.Point(100, 319);
            this.butClearHeart.Name = "butClearHeart";
            this.butClearHeart.Size = new System.Drawing.Size(67, 23);
            this.butClearHeart.TabIndex = 11;
            this.butClearHeart.Text = "清除";
            this.butClearHeart.UseVisualStyleBackColor = true;
            this.butClearHeart.Click += new System.EventHandler(this.butClearHeart_Click);
            // 
            // butClearOffset
            // 
            this.butClearOffset.Location = new System.Drawing.Point(641, 319);
            this.butClearOffset.Name = "butClearOffset";
            this.butClearOffset.Size = new System.Drawing.Size(67, 23);
            this.butClearOffset.TabIndex = 12;
            this.butClearOffset.Text = "清除";
            this.butClearOffset.UseVisualStyleBackColor = true;
            this.butClearOffset.Click += new System.EventHandler(this.butClearOffset_Click);
            // 
            // butClearLog
            // 
            this.butClearLog.Location = new System.Drawing.Point(926, 3);
            this.butClearLog.Name = "butClearLog";
            this.butClearLog.Size = new System.Drawing.Size(67, 23);
            this.butClearLog.TabIndex = 13;
            this.butClearLog.Text = "清除";
            this.butClearLog.UseVisualStyleBackColor = true;
            this.butClearLog.Click += new System.EventHandler(this.butClearLog_Click);
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.rTextJavaCode);
            this.panel9.Location = new System.Drawing.Point(7, 27);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(508, 146);
            this.panel9.TabIndex = 17;
            // 
            // rTextJavaCode
            // 
            this.rTextJavaCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTextJavaCode.Location = new System.Drawing.Point(0, 0);
            this.rTextJavaCode.Name = "rTextJavaCode";
            this.rTextJavaCode.Size = new System.Drawing.Size(506, 144);
            this.rTextJavaCode.TabIndex = 1;
            this.rTextJavaCode.Text = "";
            this.rTextJavaCode.TextChanged += new System.EventHandler(this.rTextJavaCode_TextChanged);
            // 
            // butClearJavaCode
            // 
            this.butClearJavaCode.Location = new System.Drawing.Point(240, 3);
            this.butClearJavaCode.Name = "butClearJavaCode";
            this.butClearJavaCode.Size = new System.Drawing.Size(67, 23);
            this.butClearJavaCode.TabIndex = 19;
            this.butClearJavaCode.Text = "清除";
            this.butClearJavaCode.UseVisualStyleBackColor = true;
            this.butClearJavaCode.Click += new System.EventHandler(this.butClearJavaCode_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(169, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "JAVA命令码";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // butStart
            // 
            this.butStart.Location = new System.Drawing.Point(266, 179);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(248, 30);
            this.butStart.TabIndex = 20;
            this.butStart.Text = "启动TCP通信";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.butUpConfig);
            this.panel8.Controls.Add(this.butGetConfig);
            this.panel8.Controls.Add(this.butStopDetection);
            this.panel8.Controls.Add(this.butStartDetection);
            this.panel8.Location = new System.Drawing.Point(522, 30);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(246, 142);
            this.panel8.TabIndex = 21;
            // 
            // butUpConfig
            // 
            this.butUpConfig.Location = new System.Drawing.Point(3, 33);
            this.butUpConfig.Name = "butUpConfig";
            this.butUpConfig.Size = new System.Drawing.Size(238, 23);
            this.butUpConfig.TabIndex = 8;
            this.butUpConfig.Text = "上传配置";
            this.butUpConfig.UseVisualStyleBackColor = true;
            this.butUpConfig.Click += new System.EventHandler(this.butUpConfig_Click);
            // 
            // butGetConfig
            // 
            this.butGetConfig.Location = new System.Drawing.Point(165, 3);
            this.butGetConfig.Name = "butGetConfig";
            this.butGetConfig.Size = new System.Drawing.Size(76, 23);
            this.butGetConfig.TabIndex = 7;
            this.butGetConfig.Text = "获取配置";
            this.butGetConfig.UseVisualStyleBackColor = true;
            this.butGetConfig.Click += new System.EventHandler(this.butGetConfig_Click);
            // 
            // butStopDetection
            // 
            this.butStopDetection.Location = new System.Drawing.Point(84, 3);
            this.butStopDetection.Name = "butStopDetection";
            this.butStopDetection.Size = new System.Drawing.Size(76, 23);
            this.butStopDetection.TabIndex = 6;
            this.butStopDetection.Text = "关闭检测";
            this.butStopDetection.UseVisualStyleBackColor = true;
            this.butStopDetection.Click += new System.EventHandler(this.butStopDetection_Click);
            // 
            // butStartDetection
            // 
            this.butStartDetection.Location = new System.Drawing.Point(3, 3);
            this.butStartDetection.Name = "butStartDetection";
            this.butStartDetection.Size = new System.Drawing.Size(76, 23);
            this.butStartDetection.TabIndex = 5;
            this.butStartDetection.Text = "开启检测";
            this.butStartDetection.UseVisualStyleBackColor = true;
            this.butStartDetection.Click += new System.EventHandler(this.butStartDetection_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(615, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 22;
            this.label11.Text = "行人检测";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // butStaBFollow
            // 
            this.butStaBFollow.Location = new System.Drawing.Point(85, 8);
            this.butStaBFollow.Name = "butStaBFollow";
            this.butStaBFollow.Size = new System.Drawing.Size(86, 23);
            this.butStaBFollow.TabIndex = 10;
            this.butStaBFollow.Text = "启动B跟随";
            this.butStaBFollow.UseVisualStyleBackColor = true;
            this.butStaBFollow.Click += new System.EventHandler(this.butStaBFollow_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 633);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.butStart);
            this.Controls.Add(this.butClearJavaCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.butClearLog);
            this.Controls.Add(this.butClearOffset);
            this.Controls.Add(this.butClearHeart);
            this.Controls.Add(this.butClearCode);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "算法协议调试Client";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butStopFollow;
        private System.Windows.Forms.Button butStaFollow;
        public System.Windows.Forms.RichTextBox rTxtHeart;
        public System.Windows.Forms.RichTextBox rTxtCode;
        public System.Windows.Forms.RichTextBox rTxtOffset;
        public System.Windows.Forms.RichTextBox rTxtLog;
        private System.Windows.Forms.Button butClearWhite;
        private System.Windows.Forms.Button butClearBlack;
        private System.Windows.Forms.Button butClearAll;
        private System.Windows.Forms.Button butStopIdentify;
        private System.Windows.Forms.Button butStartIdentify;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button butSelectWhite;
        private System.Windows.Forms.Button butSelectAll;
        private System.Windows.Forms.Button butSelectBlack;
        private System.Windows.Forms.Button butDeleteWhite;
        private System.Windows.Forms.Button butDeleteBlack;
        private System.Windows.Forms.TextBox tBoxBlackNum;
        private System.Windows.Forms.TextBox tBoxWhiteNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.RichTextBox rTxtSelect;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxSex;
        private System.Windows.Forms.CheckBox checkBoxType;
        private System.Windows.Forms.TextBox tBoxName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tBoxSerialnumber;
        private System.Windows.Forms.TextBox tBoxIdnumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tBoxFilename;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button butCheckFile;
        private System.Windows.Forms.Button butUpdate;
        private System.Windows.Forms.Button butClearCode;
        private System.Windows.Forms.Button butClearHeart;
        private System.Windows.Forms.Button butClearOffset;
        private System.Windows.Forms.Button butClearLog;
        private System.Windows.Forms.Panel panel9;
        public System.Windows.Forms.RichTextBox rTextJavaCode;
        private System.Windows.Forms.Button butClearJavaCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button butStartDetection;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button butGetConfig;
        private System.Windows.Forms.Button butStopDetection;
        private System.Windows.Forms.Button butUpConfig;
        private System.Windows.Forms.Button butStaBFollow;
    }
}

