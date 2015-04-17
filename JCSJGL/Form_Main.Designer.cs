namespace JCSJGL
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
            this.mn_top = new System.Windows.Forms.MenuStrip();
            this.系统用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.会员信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.款号信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.条码信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.供应商信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分店信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.仓库信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // mn_top
            // 
            this.mn_top.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统用户ToolStripMenuItem,
            this.会员信息ToolStripMenuItem,
            this.款号信息ToolStripMenuItem,
            this.条码信息ToolStripMenuItem,
            this.供应商信息ToolStripMenuItem,
            this.分店信息ToolStripMenuItem,
            this.仓库信息ToolStripMenuItem});
            this.mn_top.Location = new System.Drawing.Point(0, 0);
            this.mn_top.Name = "mn_top";
            this.mn_top.Size = new System.Drawing.Size(1053, 25);
            this.mn_top.TabIndex = 0;
            this.mn_top.Text = "menuStrip1";
            // 
            // 系统用户ToolStripMenuItem
            // 
            this.系统用户ToolStripMenuItem.Name = "系统用户ToolStripMenuItem";
            this.系统用户ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.系统用户ToolStripMenuItem.Text = "系统用户";
            // 
            // 会员信息ToolStripMenuItem
            // 
            this.会员信息ToolStripMenuItem.Name = "会员信息ToolStripMenuItem";
            this.会员信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.会员信息ToolStripMenuItem.Text = "会员信息";
            // 
            // 款号信息ToolStripMenuItem
            // 
            this.款号信息ToolStripMenuItem.Name = "款号信息ToolStripMenuItem";
            this.款号信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.款号信息ToolStripMenuItem.Text = "款号信息";
            // 
            // 条码信息ToolStripMenuItem
            // 
            this.条码信息ToolStripMenuItem.Name = "条码信息ToolStripMenuItem";
            this.条码信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.条码信息ToolStripMenuItem.Text = "条码信息";
            // 
            // 供应商信息ToolStripMenuItem
            // 
            this.供应商信息ToolStripMenuItem.Name = "供应商信息ToolStripMenuItem";
            this.供应商信息ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.供应商信息ToolStripMenuItem.Text = "供应商信息";
            // 
            // 分店信息ToolStripMenuItem
            // 
            this.分店信息ToolStripMenuItem.Name = "分店信息ToolStripMenuItem";
            this.分店信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.分店信息ToolStripMenuItem.Text = "分店信息";
            // 
            // 仓库信息ToolStripMenuItem
            // 
            this.仓库信息ToolStripMenuItem.Name = "仓库信息ToolStripMenuItem";
            this.仓库信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.仓库信息ToolStripMenuItem.Text = "仓库信息";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 395);
            this.Controls.Add(this.mn_top);
            this.MainMenuStrip = this.mn_top;
            this.Name = "Form_Main";
            this.Text = "基础数据管理";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.mn_top.ResumeLayout(false);
            this.mn_top.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mn_top;
        private System.Windows.Forms.ToolStripMenuItem 系统用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 会员信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 款号信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 条码信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 供应商信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分店信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 仓库信息ToolStripMenuItem;
    }
}

