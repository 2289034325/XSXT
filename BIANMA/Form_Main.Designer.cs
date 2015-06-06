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
            this.mni_zhuce = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_denglu = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_zhbd = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_xgmm = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_bianma = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_fenlei = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_version = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // mn_main
            // 
            this.mn_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mni_version,
            this.mni_zhuce,
            this.mni_denglu,
            this.mni_zhbd,
            this.mni_xgmm,
            this.mni_bianma,
            this.mni_fenlei});
            this.mn_main.Location = new System.Drawing.Point(0, 0);
            this.mn_main.Name = "mn_main";
            this.mn_main.Size = new System.Drawing.Size(810, 25);
            this.mn_main.TabIndex = 0;
            this.mn_main.Text = "menuStrip1";
            // 
            // mni_zhuce
            // 
            this.mni_zhuce.Name = "mni_zhuce";
            this.mni_zhuce.Size = new System.Drawing.Size(44, 21);
            this.mni_zhuce.Text = "注册";
            this.mni_zhuce.Click += new System.EventHandler(this.mni_zhuce_Click);
            // 
            // mni_denglu
            // 
            this.mni_denglu.Name = "mni_denglu";
            this.mni_denglu.Size = new System.Drawing.Size(44, 21);
            this.mni_denglu.Text = "登陆";
            this.mni_denglu.Click += new System.EventHandler(this.mni_denglu_Click);
            // 
            // mni_zhbd
            // 
            this.mni_zhbd.Name = "mni_zhbd";
            this.mni_zhbd.Size = new System.Drawing.Size(68, 21);
            this.mni_zhbd.Text = "账号绑定";
            this.mni_zhbd.Click += new System.EventHandler(this.mni_zhbd_Click);
            // 
            // mni_xgmm
            // 
            this.mni_xgmm.Name = "mni_xgmm";
            this.mni_xgmm.Size = new System.Drawing.Size(68, 21);
            this.mni_xgmm.Text = "修改密码";
            this.mni_xgmm.Click += new System.EventHandler(this.mni_xgmm_Click);
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
            // mni_version
            // 
            this.mni_version.Name = "mni_version";
            this.mni_version.Size = new System.Drawing.Size(44, 21);
            this.mni_version.Text = "版本";
            this.mni_version.Click += new System.EventHandler(this.mni_version_Click);
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
            this.Text = "编码分类系统";
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
        private System.Windows.Forms.ToolStripMenuItem mni_zhuce;
        private System.Windows.Forms.ToolStripMenuItem mni_zhbd;
        private System.Windows.Forms.ToolStripMenuItem mni_xgmm;
        private System.Windows.Forms.ToolStripMenuItem mni_denglu;
        private System.Windows.Forms.ToolStripMenuItem mni_version;
    }
}