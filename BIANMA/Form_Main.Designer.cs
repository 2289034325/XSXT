namespace BIANMA
{
    partial class Form_Main
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
            this.mn_main = new System.Windows.Forms.MenuStrip();
            this.mni_bianma = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_fenlei = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_banben = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_zhuce = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_denglu = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_zhbd = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_xgmm = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main_setting = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // mn_main
            // 
            this.mn_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.mni_bianma,
            this.mni_fenlei});
            this.mn_main.Location = new System.Drawing.Point(0, 0);
            this.mn_main.Name = "mn_main";
            this.mn_main.Size = new System.Drawing.Size(810, 25);
            this.mn_main.TabIndex = 0;
            this.mn_main.Text = "menuStrip1";
            // 
            // mni_bianma
            // 
            this.mni_bianma.Name = "mni_bianma";
            this.mni_bianma.Size = new System.Drawing.Size(44, 21);
            this.mni_bianma.Text = "编码";
            this.mni_bianma.Click += new System.EventHandler(this.mni_bianma_Click);
            // 
            // mni_fenlei
            // 
            this.mni_fenlei.Name = "mni_fenlei";
            this.mni_fenlei.Size = new System.Drawing.Size(44, 21);
            this.mni_fenlei.Text = "分类";
            this.mni_fenlei.Click += new System.EventHandler(this.mni_fenlei_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mn_main_setting,
            this.mn_main_banben,
            this.mn_main_zhuce,
            this.mn_main_xgmm,
            this.mn_main_zhbd,
            this.mn_main_denglu});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // mn_main_banben
            // 
            this.mn_main_banben.Name = "mn_main_banben";
            this.mn_main_banben.Size = new System.Drawing.Size(152, 22);
            this.mn_main_banben.Text = "版本";
            this.mn_main_banben.Click += new System.EventHandler(this.mn_main_banben_Click);
            // 
            // mn_main_zhuce
            // 
            this.mn_main_zhuce.Name = "mn_main_zhuce";
            this.mn_main_zhuce.Size = new System.Drawing.Size(152, 22);
            this.mn_main_zhuce.Text = "注册";
            this.mn_main_zhuce.Click += new System.EventHandler(this.mn_main_zhuce_Click);
            // 
            // mn_main_denglu
            // 
            this.mn_main_denglu.Name = "mn_main_denglu";
            this.mn_main_denglu.Size = new System.Drawing.Size(152, 22);
            this.mn_main_denglu.Text = "登陆";
            this.mn_main_denglu.Click += new System.EventHandler(this.mn_main_denglu_Click);
            // 
            // mn_main_zhbd
            // 
            this.mn_main_zhbd.Name = "mn_main_zhbd";
            this.mn_main_zhbd.Size = new System.Drawing.Size(152, 22);
            this.mn_main_zhbd.Text = "账号绑定";
            this.mn_main_zhbd.Click += new System.EventHandler(this.mn_main_zhbd_Click);
            // 
            // mn_main_xgmm
            // 
            this.mn_main_xgmm.Name = "mn_main_xgmm";
            this.mn_main_xgmm.Size = new System.Drawing.Size(152, 22);
            this.mn_main_xgmm.Text = "修改密码";
            this.mn_main_xgmm.Click += new System.EventHandler(this.mn_main_xgmm_Click);
            // 
            // mn_main_setting
            // 
            this.mn_main_setting.Name = "mn_main_setting";
            this.mn_main_setting.Size = new System.Drawing.Size(152, 22);
            this.mn_main_setting.Text = "设置";
            this.mn_main_setting.Click += new System.EventHandler(this.mn_main_setting_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 438);
            this.Controls.Add(this.mn_main);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mn_main;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编码分类系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.mn_main.ResumeLayout(false);
            this.mn_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mn_main;
        private System.Windows.Forms.ToolStripMenuItem mni_bianma;
        private System.Windows.Forms.ToolStripMenuItem mni_fenlei;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mn_main_setting;
        private System.Windows.Forms.ToolStripMenuItem mn_main_banben;
        private System.Windows.Forms.ToolStripMenuItem mn_main_zhuce;
        private System.Windows.Forms.ToolStripMenuItem mn_main_xgmm;
        private System.Windows.Forms.ToolStripMenuItem mn_main_zhbd;
        private System.Windows.Forms.ToolStripMenuItem mn_main_denglu;
    }
}