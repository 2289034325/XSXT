namespace FDXS
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
            this.mn_main = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_xtzc = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_xtsz = new System.Windows.Forms.ToolStripMenuItem();
            this.设置默认折扣ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_czsmq = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_version = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_folder = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_editpsw = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_userchange = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_jch = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_kcyl = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_kcgl = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_xs = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_xtyh = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_tiaoma = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_baobiao = new System.Windows.Forms.ToolStripMenuItem();
            this.会员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_hyyl = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_jfzk = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_kd = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // mn_main
            // 
            this.mn_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.mn_main_jch,
            this.mn_main_kcyl,
            this.mn_main_kcgl,
            this.mn_main_kd,
            this.mn_main_xs,
            this.mn_main_xtyh,
            this.mn_main_tiaoma,
            this.mn_main_baobiao,
            this.会员ToolStripMenuItem});
            this.mn_main.Location = new System.Drawing.Point(0, 0);
            this.mn_main.Name = "mn_main";
            this.mn_main.Size = new System.Drawing.Size(1126, 25);
            this.mn_main.TabIndex = 0;
            this.mn_main.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_main_xtzc,
            this.mn_main_xtsz,
            this.设置默认折扣ToolStripMenuItem,
            this.mn_main_czsmq,
            this.mn_main_version,
            this.mn_main_folder,
            this.mn_main_editpsw,
            this.mn_main_userchange});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // mn_main_xtzc
            // 
            this.mn_main_xtzc.Name = "mn_main_xtzc";
            this.mn_main_xtzc.Size = new System.Drawing.Size(148, 22);
            this.mn_main_xtzc.Text = "系统注册";
            this.mn_main_xtzc.Click += new System.EventHandler(this.mn_main_xtzc_Click);
            // 
            // mn_main_xtsz
            // 
            this.mn_main_xtsz.Name = "mn_main_xtsz";
            this.mn_main_xtsz.Size = new System.Drawing.Size(148, 22);
            this.mn_main_xtsz.Text = "系统设置";
            this.mn_main_xtsz.Click += new System.EventHandler(this.mn_main_xtsz_Click);
            // 
            // 设置默认折扣ToolStripMenuItem
            // 
            this.设置默认折扣ToolStripMenuItem.Name = "设置默认折扣ToolStripMenuItem";
            this.设置默认折扣ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.设置默认折扣ToolStripMenuItem.Text = "设置默认折扣";
            // 
            // mn_main_czsmq
            // 
            this.mn_main_czsmq.Name = "mn_main_czsmq";
            this.mn_main_czsmq.Size = new System.Drawing.Size(148, 22);
            this.mn_main_czsmq.Text = "重置扫描枪";
            this.mn_main_czsmq.Click += new System.EventHandler(this.mn_main_czsmq_Click);
            // 
            // mn_main_version
            // 
            this.mn_main_version.Name = "mn_main_version";
            this.mn_main_version.Size = new System.Drawing.Size(148, 22);
            this.mn_main_version.Text = "版本";
            this.mn_main_version.Click += new System.EventHandler(this.mn_main_version_Click);
            // 
            // mn_main_folder
            // 
            this.mn_main_folder.Name = "mn_main_folder";
            this.mn_main_folder.Size = new System.Drawing.Size(148, 22);
            this.mn_main_folder.Text = "文件夹";
            this.mn_main_folder.Click += new System.EventHandler(this.mn_main_folder_Click);
            // 
            // mn_main_editpsw
            // 
            this.mn_main_editpsw.Name = "mn_main_editpsw";
            this.mn_main_editpsw.Size = new System.Drawing.Size(148, 22);
            this.mn_main_editpsw.Text = "修改密码";
            this.mn_main_editpsw.Click += new System.EventHandler(this.mn_main_editpsw_Click);
            // 
            // mn_main_userchange
            // 
            this.mn_main_userchange.Name = "mn_main_userchange";
            this.mn_main_userchange.Size = new System.Drawing.Size(148, 22);
            this.mn_main_userchange.Text = "更换用户";
            this.mn_main_userchange.Click += new System.EventHandler(this.mn_main_userchange_Click);
            // 
            // mn_main_jch
            // 
            this.mn_main_jch.Name = "mn_main_jch";
            this.mn_main_jch.Size = new System.Drawing.Size(56, 21);
            this.mn_main_jch.Text = "进出货";
            this.mn_main_jch.Click += new System.EventHandler(this.mn_main_jch_Click);
            // 
            // mn_main_kcyl
            // 
            this.mn_main_kcyl.Name = "mn_main_kcyl";
            this.mn_main_kcyl.Size = new System.Drawing.Size(68, 21);
            this.mn_main_kcyl.Text = "库存一览";
            this.mn_main_kcyl.Click += new System.EventHandler(this.mn_main_kcyl_Click);
            // 
            // mn_main_kcgl
            // 
            this.mn_main_kcgl.Name = "mn_main_kcgl";
            this.mn_main_kcgl.Size = new System.Drawing.Size(68, 21);
            this.mn_main_kcgl.Text = "库存管理";
            this.mn_main_kcgl.Click += new System.EventHandler(this.mn_main_kcgl_Click);
            // 
            // mn_main_xs
            // 
            this.mn_main_xs.Name = "mn_main_xs";
            this.mn_main_xs.Size = new System.Drawing.Size(68, 21);
            this.mn_main_xs.Text = "销售记录";
            this.mn_main_xs.Click += new System.EventHandler(this.mn_main_xs_Click);
            // 
            // mn_main_xtyh
            // 
            this.mn_main_xtyh.Name = "mn_main_xtyh";
            this.mn_main_xtyh.Size = new System.Drawing.Size(68, 21);
            this.mn_main_xtyh.Text = "系统用户";
            this.mn_main_xtyh.Click += new System.EventHandler(this.mn_main_xtyh_Click);
            // 
            // mn_main_tiaoma
            // 
            this.mn_main_tiaoma.Name = "mn_main_tiaoma";
            this.mn_main_tiaoma.Size = new System.Drawing.Size(68, 21);
            this.mn_main_tiaoma.Text = "条码信息";
            this.mn_main_tiaoma.Click += new System.EventHandler(this.mn_main_tiaoma_Click);
            // 
            // mn_main_baobiao
            // 
            this.mn_main_baobiao.Name = "mn_main_baobiao";
            this.mn_main_baobiao.Size = new System.Drawing.Size(44, 21);
            this.mn_main_baobiao.Text = "报表";
            this.mn_main_baobiao.Click += new System.EventHandler(this.mn_main_baobiao_Click);
            // 
            // 会员ToolStripMenuItem
            // 
            this.会员ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_main_hyyl,
            this.mn_main_jfzk});
            this.会员ToolStripMenuItem.Name = "会员ToolStripMenuItem";
            this.会员ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.会员ToolStripMenuItem.Text = "会员";
            // 
            // mn_main_hyyl
            // 
            this.mn_main_hyyl.Name = "mn_main_hyyl";
            this.mn_main_hyyl.Size = new System.Drawing.Size(124, 22);
            this.mn_main_hyyl.Text = "会员一览";
            this.mn_main_hyyl.Click += new System.EventHandler(this.mn_main_hyyl_Click);
            // 
            // mn_main_jfzk
            // 
            this.mn_main_jfzk.Name = "mn_main_jfzk";
            this.mn_main_jfzk.Size = new System.Drawing.Size(124, 22);
            this.mn_main_jfzk.Text = "积分折扣";
            this.mn_main_jfzk.Click += new System.EventHandler(this.mn_main_jfzk_Click);
            // 
            // mn_main_kd
            // 
            this.mn_main_kd.Name = "mn_main_kd";
            this.mn_main_kd.Size = new System.Drawing.Size(44, 21);
            this.mn_main_kd.Text = "开单";
            this.mn_main_kd.Click += new System.EventHandler(this.mn_main_kd_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 485);
            this.Controls.Add(this.mn_main);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mn_main;
            this.Name = "Form_Main";
            this.Text = "分店销售系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.mn_main.ResumeLayout(false);
            this.mn_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mn_main;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mn_main_xtzc;
        private System.Windows.Forms.ToolStripMenuItem 设置默认折扣ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mn_main_czsmq;
        private System.Windows.Forms.ToolStripMenuItem mn_main_jch;
        private System.Windows.Forms.ToolStripMenuItem mn_main_kcyl;
        private System.Windows.Forms.ToolStripMenuItem mn_main_kcgl;
        private System.Windows.Forms.ToolStripMenuItem mn_main_xtyh;
        private System.Windows.Forms.ToolStripMenuItem mn_main_baobiao;
        private System.Windows.Forms.ToolStripMenuItem mn_main_tiaoma;
        private System.Windows.Forms.ToolStripMenuItem mn_main_xs;
        private System.Windows.Forms.ToolStripMenuItem 会员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mn_main_hyyl;
        private System.Windows.Forms.ToolStripMenuItem mn_main_jfzk;
        private System.Windows.Forms.ToolStripMenuItem mn_main_version;
        private System.Windows.Forms.ToolStripMenuItem mn_main_folder;
        private System.Windows.Forms.ToolStripMenuItem mn_main_editpsw;
        private System.Windows.Forms.ToolStripMenuItem mn_main_userchange;
        private System.Windows.Forms.ToolStripMenuItem mn_main_xtsz;
        private System.Windows.Forms.ToolStripMenuItem mn_main_kd;
    }
}

