namespace DBBackTool
{
    partial class Form_Main
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txb_dbserver = new System.Windows.Forms.TextBox();
            this.txb_dbname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_dbpsw = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_dbuid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_aliendpoint = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_localpath = new System.Windows.Forms.TextBox();
            this.txb_alikey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_aliid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tp_qdsj = new System.Windows.Forms.DateTimePicker();
            this.lbl_status = new System.Windows.Forms.Label();
            this.txb_ftppsw = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txb_ftpuid = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txb_ftpurl = new System.Windows.Forms.TextBox();
            this.chk_ali = new System.Windows.Forms.CheckBox();
            this.chk_ftp = new System.Windows.Forms.CheckBox();
            this.txb_alibucket = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_aliPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mni_baocun = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_ceshi = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_tzrw = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_qdrw = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库地址";
            // 
            // txb_dbserver
            // 
            this.txb_dbserver.Location = new System.Drawing.Point(83, 40);
            this.txb_dbserver.Name = "txb_dbserver";
            this.txb_dbserver.Size = new System.Drawing.Size(100, 21);
            this.txb_dbserver.TabIndex = 1;
            // 
            // txb_dbname
            // 
            this.txb_dbname.Location = new System.Drawing.Point(83, 67);
            this.txb_dbname.Name = "txb_dbname";
            this.txb_dbname.Size = new System.Drawing.Size(100, 21);
            this.txb_dbname.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据库名";
            // 
            // txb_dbpsw
            // 
            this.txb_dbpsw.Location = new System.Drawing.Point(83, 121);
            this.txb_dbpsw.Name = "txb_dbpsw";
            this.txb_dbpsw.PasswordChar = '*';
            this.txb_dbpsw.Size = new System.Drawing.Size(100, 21);
            this.txb_dbpsw.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "密码";
            // 
            // txb_dbuid
            // 
            this.txb_dbuid.Location = new System.Drawing.Point(83, 94);
            this.txb_dbuid.Name = "txb_dbuid";
            this.txb_dbuid.Size = new System.Drawing.Size(100, 21);
            this.txb_dbuid.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "用户名";
            // 
            // txb_aliendpoint
            // 
            this.txb_aliendpoint.Location = new System.Drawing.Point(303, 94);
            this.txb_aliendpoint.Name = "txb_aliendpoint";
            this.txb_aliendpoint.Size = new System.Drawing.Size(155, 21);
            this.txb_aliendpoint.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "EndPoint";
            // 
            // txb_localpath
            // 
            this.txb_localpath.Location = new System.Drawing.Point(83, 148);
            this.txb_localpath.Name = "txb_localpath";
            this.txb_localpath.Size = new System.Drawing.Size(100, 21);
            this.txb_localpath.TabIndex = 13;
            // 
            // txb_alikey
            // 
            this.txb_alikey.Location = new System.Drawing.Point(303, 67);
            this.txb_alikey.Name = "txb_alikey";
            this.txb_alikey.PasswordChar = '*';
            this.txb_alikey.Size = new System.Drawing.Size(155, 21);
            this.txb_alikey.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(238, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "AccessKey";
            // 
            // txb_aliid
            // 
            this.txb_aliid.Location = new System.Drawing.Point(303, 40);
            this.txb_aliid.Name = "txb_aliid";
            this.txb_aliid.Size = new System.Drawing.Size(155, 21);
            this.txb_aliid.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "每天";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(166, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "执行备份";
            // 
            // tp_qdsj
            // 
            this.tp_qdsj.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.tp_qdsj.Location = new System.Drawing.Point(83, 175);
            this.tp_qdsj.Name = "tp_qdsj";
            this.tp_qdsj.ShowUpDown = true;
            this.tp_qdsj.Size = new System.Drawing.Size(77, 21);
            this.tp_qdsj.TabIndex = 22;
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Font = new System.Drawing.Font("宋体", 9F);
            this.lbl_status.Location = new System.Drawing.Point(12, 231);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(53, 12);
            this.lbl_status.TabIndex = 25;
            this.lbl_status.Text = "任务信息";
            // 
            // txb_ftppsw
            // 
            this.txb_ftppsw.Location = new System.Drawing.Point(536, 94);
            this.txb_ftppsw.Name = "txb_ftppsw";
            this.txb_ftppsw.PasswordChar = '*';
            this.txb_ftppsw.Size = new System.Drawing.Size(155, 21);
            this.txb_ftppsw.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(477, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "密码";
            // 
            // txb_ftpuid
            // 
            this.txb_ftpuid.Location = new System.Drawing.Point(536, 67);
            this.txb_ftpuid.Name = "txb_ftpuid";
            this.txb_ftpuid.Size = new System.Drawing.Size(155, 21);
            this.txb_ftpuid.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(471, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 28;
            this.label12.Text = "用户名";
            // 
            // txb_ftpurl
            // 
            this.txb_ftpurl.Location = new System.Drawing.Point(536, 40);
            this.txb_ftpurl.Name = "txb_ftpurl";
            this.txb_ftpurl.Size = new System.Drawing.Size(155, 21);
            this.txb_ftpurl.TabIndex = 27;
            // 
            // chk_ali
            // 
            this.chk_ali.AutoSize = true;
            this.chk_ali.Location = new System.Drawing.Point(189, 39);
            this.chk_ali.Name = "chk_ali";
            this.chk_ali.Size = new System.Drawing.Size(108, 16);
            this.chk_ali.TabIndex = 32;
            this.chk_ali.Text = "阿里云AccessId";
            this.chk_ali.UseVisualStyleBackColor = true;
            // 
            // chk_ftp
            // 
            this.chk_ftp.AutoSize = true;
            this.chk_ftp.Location = new System.Drawing.Point(464, 39);
            this.chk_ftp.Name = "chk_ftp";
            this.chk_ftp.Size = new System.Drawing.Size(66, 16);
            this.chk_ftp.TabIndex = 33;
            this.chk_ftp.Text = "FTP地址";
            this.chk_ftp.UseVisualStyleBackColor = true;
            // 
            // txb_alibucket
            // 
            this.txb_alibucket.Location = new System.Drawing.Point(303, 122);
            this.txb_alibucket.Name = "txb_alibucket";
            this.txb_alibucket.Size = new System.Drawing.Size(155, 21);
            this.txb_alibucket.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 37;
            this.label6.Text = "BukectName";
            // 
            // txb_aliPath
            // 
            this.txb_aliPath.Location = new System.Drawing.Point(303, 149);
            this.txb_aliPath.Name = "txb_aliPath";
            this.txb_aliPath.Size = new System.Drawing.Size(155, 21);
            this.txb_aliPath.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(268, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 39;
            this.label8.Text = "Path";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 151);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 41;
            this.label13.Text = "本地路径";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mni_baocun,
            this.mni_ceshi,
            this.mni_tzrw,
            this.mni_qdrw});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(707, 25);
            this.menuStrip1.TabIndex = 42;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mni_baocun
            // 
            this.mni_baocun.Name = "mni_baocun";
            this.mni_baocun.Size = new System.Drawing.Size(68, 21);
            this.mni_baocun.Text = "保存修改";
            this.mni_baocun.Click += new System.EventHandler(this.mni_baocun_Click);
            // 
            // mni_ceshi
            // 
            this.mni_ceshi.Name = "mni_ceshi";
            this.mni_ceshi.Size = new System.Drawing.Size(44, 21);
            this.mni_ceshi.Text = "测试";
            this.mni_ceshi.Click += new System.EventHandler(this.mni_ceshi_Click);
            // 
            // mni_tzrw
            // 
            this.mni_tzrw.Name = "mni_tzrw";
            this.mni_tzrw.Size = new System.Drawing.Size(68, 21);
            this.mni_tzrw.Text = "停止任务";
            this.mni_tzrw.Click += new System.EventHandler(this.mni_tzrw_Click);
            // 
            // mni_qdrw
            // 
            this.mni_qdrw.Name = "mni_qdrw";
            this.mni_qdrw.Size = new System.Drawing.Size(104, 21);
            this.mni_qdrw.Text = "更新或启动任务";
            this.mni_qdrw.Click += new System.EventHandler(this.mni_qdrw_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 295);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txb_aliPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txb_alibucket);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chk_ftp);
            this.Controls.Add(this.chk_ali);
            this.Controls.Add(this.txb_ftppsw);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txb_ftpuid);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txb_ftpurl);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tp_qdsj);
            this.Controls.Add(this.txb_aliendpoint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_localpath);
            this.Controls.Add(this.txb_alikey);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txb_aliid);
            this.Controls.Add(this.txb_dbuid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_dbpsw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txb_dbname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_dbserver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Main";
            this.Text = "数据库备份工具";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_dbserver;
        private System.Windows.Forms.TextBox txb_dbname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_dbpsw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_dbuid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_aliendpoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_localpath;
        private System.Windows.Forms.TextBox txb_alikey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txb_aliid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker tp_qdsj;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.TextBox txb_ftppsw;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txb_ftpuid;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txb_ftpurl;
        private System.Windows.Forms.CheckBox chk_ali;
        private System.Windows.Forms.CheckBox chk_ftp;
        private System.Windows.Forms.TextBox txb_alibucket;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_aliPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mni_baocun;
        private System.Windows.Forms.ToolStripMenuItem mni_ceshi;
        private System.Windows.Forms.ToolStripMenuItem mni_tzrw;
        private System.Windows.Forms.ToolStripMenuItem mni_qdrw;
    }
}

