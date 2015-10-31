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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.mn_main = new System.Windows.Forms.MenuStrip();
            this.mn_main_info = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_cover = new MyFormControls.MyPanel();
            this.myPanel1 = new MyFormControls.MyPanel();
            this.myPanel2 = new MyFormControls.MyPanel();
            this.mn_main_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_set = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_xtsz = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_xtzc = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_cxljfwq = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_czsmq = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_dbbkup = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_editpsw = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_userchange = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_version = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_xtyh = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_jch = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_kcgl = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_kcyl = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_kcxz = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_kcpd = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_kd = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_xs = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_tiaoma = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_baobiao = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_hyyl = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_closewindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_tuichu = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_logo = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main.SuspendLayout();
            this.pnl_cover.SuspendLayout();
            this.myPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mn_main
            // 
            this.mn_main.BackColor = System.Drawing.Color.White;
            this.mn_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_main_menu,
            this.mn_main_logo,
            this.mn_main_info});
            this.mn_main.Location = new System.Drawing.Point(0, 0);
            this.mn_main.Name = "mn_main";
            this.mn_main.Padding = new System.Windows.Forms.Padding(0);
            this.mn_main.Size = new System.Drawing.Size(1020, 92);
            this.mn_main.TabIndex = 0;
            this.mn_main.Text = "menuStrip1";
            // 
            // mn_main_info
            // 
            this.mn_main_info.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mn_main_info.AutoSize = false;
            this.mn_main_info.BackColor = System.Drawing.Color.Black;
            this.mn_main_info.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.mn_main_info.ForeColor = System.Drawing.Color.White;
            this.mn_main_info.Name = "mn_main_info";
            this.mn_main_info.Size = new System.Drawing.Size(350, 92);
            this.mn_main_info.Text = "    ";
            // 
            // pnl_cover
            // 
            this.pnl_cover.BackColor = System.Drawing.Color.Black;
            this.pnl_cover.Controls.Add(this.myPanel1);
            this.pnl_cover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_cover.Location = new System.Drawing.Point(0, 92);
            this.pnl_cover.Name = "pnl_cover";
            this.pnl_cover.Size = new System.Drawing.Size(1020, 475);
            this.pnl_cover.TabIndex = 2;
            // 
            // myPanel1
            // 
            this.myPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.myPanel1.BackColor = System.Drawing.Color.Black;
            this.myPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("myPanel1.BackgroundImage")));
            this.myPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myPanel1.Controls.Add(this.myPanel2);
            this.myPanel1.Location = new System.Drawing.Point(35, 12);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(937, 451);
            this.myPanel1.TabIndex = 0;
            // 
            // myPanel2
            // 
            this.myPanel2.BackColor = System.Drawing.Color.Black;
            this.myPanel2.BackgroundImage = global::FDXS.Properties.Resources.mzd_name_white;
            this.myPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.myPanel2.Location = new System.Drawing.Point(765, 356);
            this.myPanel2.Name = "myPanel2";
            this.myPanel2.Size = new System.Drawing.Size(147, 59);
            this.myPanel2.TabIndex = 0;
            // 
            // mn_main_menu
            // 
            this.mn_main_menu.BackColor = System.Drawing.Color.Black;
            this.mn_main_menu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mn_main_menu.BackgroundImage")));
            this.mn_main_menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mn_main_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_main_set,
            this.mn_main_xtyh,
            this.mn_main_jch,
            this.mn_main_kcgl,
            this.mn_main_kd,
            this.mn_main_xs,
            this.mn_main_tiaoma,
            this.mn_main_baobiao,
            this.mn_main_hyyl,
            this.mn_main_closewindow,
            this.mn_main_tuichu});
            this.mn_main_menu.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.mn_main_menu.Name = "mn_main_menu";
            this.mn_main_menu.Size = new System.Drawing.Size(75, 92);
            this.mn_main_menu.Text = "      ";
            this.mn_main_menu.MouseEnter += new System.EventHandler(this.mn_main_menu_MouseEnter);
            this.mn_main_menu.MouseLeave += new System.EventHandler(this.mn_main_menu_MouseLeave);
            // 
            // mn_main_set
            // 
            this.mn_main_set.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_main_xtsz,
            this.mn_main_xtzc,
            this.mn_main_cxljfwq,
            this.mn_main_czsmq,
            this.mn_main_dbbkup,
            this.mn_main_editpsw,
            this.mn_main_userchange,
            this.mn_main_version});
            this.mn_main_set.Name = "mn_main_set";
            this.mn_main_set.Size = new System.Drawing.Size(198, 40);
            this.mn_main_set.Text = "系统设置";
            // 
            // mn_main_xtsz
            // 
            this.mn_main_xtsz.Name = "mn_main_xtsz";
            this.mn_main_xtsz.Size = new System.Drawing.Size(279, 40);
            this.mn_main_xtsz.Text = "系统设置";
            this.mn_main_xtsz.Click += new System.EventHandler(this.mn_main_xtsz_Click);
            // 
            // mn_main_xtzc
            // 
            this.mn_main_xtzc.Name = "mn_main_xtzc";
            this.mn_main_xtzc.Size = new System.Drawing.Size(279, 40);
            this.mn_main_xtzc.Text = "系统注册";
            this.mn_main_xtzc.Click += new System.EventHandler(this.mn_main_xtzc_Click);
            // 
            // mn_main_cxljfwq
            // 
            this.mn_main_cxljfwq.Name = "mn_main_cxljfwq";
            this.mn_main_cxljfwq.Size = new System.Drawing.Size(279, 40);
            this.mn_main_cxljfwq.Text = "重新连接服务器";
            this.mn_main_cxljfwq.Click += new System.EventHandler(this.mn_main_cxljfwq_Click);
            // 
            // mn_main_czsmq
            // 
            this.mn_main_czsmq.Name = "mn_main_czsmq";
            this.mn_main_czsmq.Size = new System.Drawing.Size(279, 40);
            this.mn_main_czsmq.Text = "重置扫描枪";
            this.mn_main_czsmq.Click += new System.EventHandler(this.mn_main_czsmq_Click);
            // 
            // mn_main_dbbkup
            // 
            this.mn_main_dbbkup.Name = "mn_main_dbbkup";
            this.mn_main_dbbkup.Size = new System.Drawing.Size(279, 40);
            this.mn_main_dbbkup.Text = "数据库备份";
            this.mn_main_dbbkup.Click += new System.EventHandler(this.mn_main_dbbkup_Click);
            // 
            // mn_main_editpsw
            // 
            this.mn_main_editpsw.Name = "mn_main_editpsw";
            this.mn_main_editpsw.Size = new System.Drawing.Size(279, 40);
            this.mn_main_editpsw.Text = "修改密码";
            this.mn_main_editpsw.Click += new System.EventHandler(this.mn_main_editpsw_Click);
            // 
            // mn_main_userchange
            // 
            this.mn_main_userchange.Name = "mn_main_userchange";
            this.mn_main_userchange.Size = new System.Drawing.Size(279, 40);
            this.mn_main_userchange.Text = "更换用户";
            this.mn_main_userchange.Click += new System.EventHandler(this.mn_main_userchange_Click);
            // 
            // mn_main_version
            // 
            this.mn_main_version.Name = "mn_main_version";
            this.mn_main_version.Size = new System.Drawing.Size(279, 40);
            this.mn_main_version.Text = "版本";
            this.mn_main_version.Click += new System.EventHandler(this.mn_main_version_Click);
            // 
            // mn_main_xtyh
            // 
            this.mn_main_xtyh.Name = "mn_main_xtyh";
            this.mn_main_xtyh.Size = new System.Drawing.Size(198, 40);
            this.mn_main_xtyh.Text = "用户管理";
            this.mn_main_xtyh.Click += new System.EventHandler(this.mn_main_xtyh_Click);
            // 
            // mn_main_jch
            // 
            this.mn_main_jch.Name = "mn_main_jch";
            this.mn_main_jch.Size = new System.Drawing.Size(198, 40);
            this.mn_main_jch.Text = "进货出货";
            this.mn_main_jch.Click += new System.EventHandler(this.mn_main_jch_Click);
            // 
            // mn_main_kcgl
            // 
            this.mn_main_kcgl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_main_kcyl,
            this.mn_main_kcxz,
            this.mn_main_kcpd});
            this.mn_main_kcgl.Name = "mn_main_kcgl";
            this.mn_main_kcgl.Size = new System.Drawing.Size(198, 40);
            this.mn_main_kcgl.Text = "库存管理";
            // 
            // mn_main_kcyl
            // 
            this.mn_main_kcyl.Name = "mn_main_kcyl";
            this.mn_main_kcyl.Size = new System.Drawing.Size(198, 40);
            this.mn_main_kcyl.Text = "库存一览";
            this.mn_main_kcyl.Click += new System.EventHandler(this.mn_main_kcyl_Click);
            // 
            // mn_main_kcxz
            // 
            this.mn_main_kcxz.Name = "mn_main_kcxz";
            this.mn_main_kcxz.Size = new System.Drawing.Size(198, 40);
            this.mn_main_kcxz.Text = "库存修正";
            this.mn_main_kcxz.Click += new System.EventHandler(this.mn_main_kcxz_Click);
            // 
            // mn_main_kcpd
            // 
            this.mn_main_kcpd.Name = "mn_main_kcpd";
            this.mn_main_kcpd.Size = new System.Drawing.Size(198, 40);
            this.mn_main_kcpd.Text = "库存盘点";
            this.mn_main_kcpd.Click += new System.EventHandler(this.mn_main_kcpd_Click);
            // 
            // mn_main_kd
            // 
            this.mn_main_kd.Name = "mn_main_kd";
            this.mn_main_kd.Size = new System.Drawing.Size(198, 40);
            this.mn_main_kd.Text = "销售开单";
            this.mn_main_kd.Click += new System.EventHandler(this.mn_main_kd_Click);
            // 
            // mn_main_xs
            // 
            this.mn_main_xs.Name = "mn_main_xs";
            this.mn_main_xs.Size = new System.Drawing.Size(198, 40);
            this.mn_main_xs.Text = "销售记录";
            this.mn_main_xs.Click += new System.EventHandler(this.mn_main_xs_Click);
            // 
            // mn_main_tiaoma
            // 
            this.mn_main_tiaoma.Name = "mn_main_tiaoma";
            this.mn_main_tiaoma.Size = new System.Drawing.Size(198, 40);
            this.mn_main_tiaoma.Text = "条码信息";
            this.mn_main_tiaoma.Click += new System.EventHandler(this.mn_main_tiaoma_Click);
            // 
            // mn_main_baobiao
            // 
            this.mn_main_baobiao.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.mn_main_baobiao.Name = "mn_main_baobiao";
            this.mn_main_baobiao.Size = new System.Drawing.Size(198, 40);
            this.mn_main_baobiao.Text = "统计图表";
            this.mn_main_baobiao.Click += new System.EventHandler(this.mn_main_baobiao_Click);
            // 
            // mn_main_hyyl
            // 
            this.mn_main_hyyl.Name = "mn_main_hyyl";
            this.mn_main_hyyl.Size = new System.Drawing.Size(198, 40);
            this.mn_main_hyyl.Text = "会员一览";
            this.mn_main_hyyl.Click += new System.EventHandler(this.mn_main_hyyl_Click);
            // 
            // mn_main_closewindow
            // 
            this.mn_main_closewindow.Name = "mn_main_closewindow";
            this.mn_main_closewindow.Size = new System.Drawing.Size(198, 40);
            this.mn_main_closewindow.Text = "关闭窗口";
            this.mn_main_closewindow.Click += new System.EventHandler(this.mn_main_closewindow_Click);
            // 
            // mn_main_tuichu
            // 
            this.mn_main_tuichu.Name = "mn_main_tuichu";
            this.mn_main_tuichu.Size = new System.Drawing.Size(198, 40);
            this.mn_main_tuichu.Text = "退出系统";
            this.mn_main_tuichu.Click += new System.EventHandler(this.mn_main_tuichu_Click);
            // 
            // mn_main_logo
            // 
            this.mn_main_logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mn_main_logo.BackgroundImage")));
            this.mn_main_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mn_main_logo.Enabled = false;
            this.mn_main_logo.Font = new System.Drawing.Font("微软雅黑", 50F);
            this.mn_main_logo.Name = "mn_main_logo";
            this.mn_main_logo.Size = new System.Drawing.Size(570, 92);
            this.mn_main_logo.Text = "                          ";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1020, 567);
            this.Controls.Add(this.pnl_cover);
            this.Controls.Add(this.mn_main);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mn_main;
            this.Name = "Form_Main";
            this.Text = "分店销售系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.MdiChildActivate += new System.EventHandler(this.Form_Main_MdiChildActivate);
            this.mn_main.ResumeLayout(false);
            this.mn_main.PerformLayout();
            this.pnl_cover.ResumeLayout(false);
            this.myPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mn_main;
        private System.Windows.Forms.ToolStripMenuItem mn_main_set;
        private System.Windows.Forms.ToolStripMenuItem mn_main_xtzc;
        private System.Windows.Forms.ToolStripMenuItem mn_main_czsmq;
        private System.Windows.Forms.ToolStripMenuItem mn_main_jch;
        private System.Windows.Forms.ToolStripMenuItem mn_main_kcgl;
        private System.Windows.Forms.ToolStripMenuItem mn_main_xtyh;
        private System.Windows.Forms.ToolStripMenuItem mn_main_baobiao;
        private System.Windows.Forms.ToolStripMenuItem mn_main_tiaoma;
        private System.Windows.Forms.ToolStripMenuItem mn_main_xs;
        private System.Windows.Forms.ToolStripMenuItem mn_main_version;
        private System.Windows.Forms.ToolStripMenuItem mn_main_editpsw;
        private System.Windows.Forms.ToolStripMenuItem mn_main_userchange;
        private System.Windows.Forms.ToolStripMenuItem mn_main_xtsz;
        private System.Windows.Forms.ToolStripMenuItem mn_main_kd;
        private System.Windows.Forms.ToolStripMenuItem mn_main_hyyl;
        private System.Windows.Forms.ToolStripMenuItem mn_main_cxljfwq;
        private System.Windows.Forms.ToolStripMenuItem mn_main_dbbkup;
        private System.Windows.Forms.ToolStripMenuItem mn_main_tuichu;
        private System.Windows.Forms.ToolStripMenuItem mn_main_menu;
        private System.Windows.Forms.ToolStripMenuItem mn_main_logo;
        private System.Windows.Forms.ToolStripMenuItem mn_main_info;
        private MyFormControls.MyPanel pnl_cover;
        private System.Windows.Forms.ToolStripMenuItem mn_main_kcyl;
        private System.Windows.Forms.ToolStripMenuItem mn_main_kcxz;
        private System.Windows.Forms.ToolStripMenuItem mn_main_kcpd;
        private System.Windows.Forms.ToolStripMenuItem mn_main_closewindow;
        private MyFormControls.MyPanel myPanel1;
        private MyFormControls.MyPanel myPanel2;
    }
}

