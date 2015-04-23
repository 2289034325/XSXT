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
            this.mn_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // mn_main
            // 
            this.mn_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.mn_main.ResumeLayout(false);
            this.mn_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mn_main;
        private System.Windows.Forms.ToolStripMenuItem mni_bianma;
        private System.Windows.Forms.ToolStripMenuItem mni_fenlei;
    }
}