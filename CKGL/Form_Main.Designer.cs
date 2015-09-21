namespace CKGL
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
            this.重置扫描枪ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_xtsz = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_xtzc = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_version = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_xgmm = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_churuku = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_kcyl = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_kcgl = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_tmyl = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_cxlj = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // mn_main
            // 
            this.mn_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.mn_main_churuku,
            this.mn_main_kcyl,
            this.mn_main_kcgl,
            this.mn_main_tmyl,
            this.mn_main_cxlj});
            this.mn_main.Location = new System.Drawing.Point(0, 0);
            this.mn_main.Name = "mn_main";
            this.mn_main.Size = new System.Drawing.Size(1126, 25);
            this.mn_main.TabIndex = 0;
            this.mn_main.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重置扫描枪ToolStripMenuItem,
            this.mn_main_xtsz,
            this.mn_main_xtzc,
            this.mn_main_version,
            this.mn_main_xgmm});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 重置扫描枪ToolStripMenuItem
            // 
            this.重置扫描枪ToolStripMenuItem.Name = "重置扫描枪ToolStripMenuItem";
            this.重置扫描枪ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.重置扫描枪ToolStripMenuItem.Text = "重置扫描枪";
            // 
            // mn_main_xtsz
            // 
            this.mn_main_xtsz.Name = "mn_main_xtsz";
            this.mn_main_xtsz.Size = new System.Drawing.Size(152, 22);
            this.mn_main_xtsz.Text = "系统设置";
            this.mn_main_xtsz.Click += new System.EventHandler(this.mn_main_xtsz_Click);
            // 
            // mn_main_xtzc
            // 
            this.mn_main_xtzc.Name = "mn_main_xtzc";
            this.mn_main_xtzc.Size = new System.Drawing.Size(152, 22);
            this.mn_main_xtzc.Text = "系统注册";
            this.mn_main_xtzc.Click += new System.EventHandler(this.mn_main_jcsj_zc_Click);
            // 
            // mn_main_version
            // 
            this.mn_main_version.Name = "mn_main_version";
            this.mn_main_version.Size = new System.Drawing.Size(152, 22);
            this.mn_main_version.Text = "版本";
            this.mn_main_version.Click += new System.EventHandler(this.mn_main_version_Click);
            // 
            // mn_main_xgmm
            // 
            this.mn_main_xgmm.Name = "mn_main_xgmm";
            this.mn_main_xgmm.Size = new System.Drawing.Size(152, 22);
            this.mn_main_xgmm.Text = "修改密码";
            this.mn_main_xgmm.Click += new System.EventHandler(this.mn_main_xgmm_Click);
            // 
            // mn_main_churuku
            // 
            this.mn_main_churuku.Name = "mn_main_churuku";
            this.mn_main_churuku.Size = new System.Drawing.Size(56, 21);
            this.mn_main_churuku.Text = "出入库";
            this.mn_main_churuku.Click += new System.EventHandler(this.mn_main_churuku_Click);
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
            // mn_main_tmyl
            // 
            this.mn_main_tmyl.Name = "mn_main_tmyl";
            this.mn_main_tmyl.Size = new System.Drawing.Size(68, 21);
            this.mn_main_tmyl.Text = "条码一览";
            this.mn_main_tmyl.Click += new System.EventHandler(this.mn_main_tmyl_Click);
            // 
            // mn_main_cxlj
            // 
            this.mn_main_cxlj.Name = "mn_main_cxlj";
            this.mn_main_cxlj.Size = new System.Drawing.Size(104, 21);
            this.mn_main_cxlj.Text = "重新连接服务器";
            this.mn_main_cxlj.Click += new System.EventHandler(this.mn_main_cxlj_Click);
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
            this.Text = "仓库管理";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.mn_main.ResumeLayout(false);
            this.mn_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mn_main;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重置扫描枪ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mn_main_xtsz;
        private System.Windows.Forms.ToolStripMenuItem mn_main_xtzc;
        private System.Windows.Forms.ToolStripMenuItem mn_main_churuku;
        private System.Windows.Forms.ToolStripMenuItem mn_main_kcyl;
        private System.Windows.Forms.ToolStripMenuItem mn_main_kcgl;
        private System.Windows.Forms.ToolStripMenuItem mn_main_tmyl;
        private System.Windows.Forms.ToolStripMenuItem mn_main_version;
        private System.Windows.Forms.ToolStripMenuItem mn_main_cxlj;
        private System.Windows.Forms.ToolStripMenuItem mn_main_xgmm;
    }
}

