namespace FDXS
{
    partial class Dlg_Denglu
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
            this.txb_mm = new System.Windows.Forms.TextBox();
            this.txb_dlm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.chk_auto = new System.Windows.Forms.CheckBox();
            this.btn_setting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txb_mm
            // 
            this.txb_mm.Location = new System.Drawing.Point(212, 6);
            this.txb_mm.Name = "txb_mm";
            this.txb_mm.PasswordChar = '*';
            this.txb_mm.Size = new System.Drawing.Size(100, 21);
            this.txb_mm.TabIndex = 11;
            // 
            // txb_dlm
            // 
            this.txb_dlm.Location = new System.Drawing.Point(59, 6);
            this.txb_dlm.Name = "txb_dlm";
            this.txb_dlm.Size = new System.Drawing.Size(100, 21);
            this.txb_dlm.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "登录名";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(237, 44);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // chk_auto
            // 
            this.chk_auto.AutoSize = true;
            this.chk_auto.Location = new System.Drawing.Point(59, 48);
            this.chk_auto.Name = "chk_auto";
            this.chk_auto.Size = new System.Drawing.Size(72, 16);
            this.chk_auto.TabIndex = 13;
            this.chk_auto.Text = "自动登陆";
            this.chk_auto.UseVisualStyleBackColor = true;
            // 
            // btn_setting
            // 
            this.btn_setting.Location = new System.Drawing.Point(237, 102);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(75, 23);
            this.btn_setting.TabIndex = 14;
            this.btn_setting.Text = "设置";
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // Dlg_Denglu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 128);
            this.Controls.Add(this.btn_setting);
            this.Controls.Add(this.chk_auto);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txb_mm);
            this.Controls.Add(this.txb_dlm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_Denglu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登陆";
            this.Load += new System.EventHandler(this.Dlg_Denglu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_mm;
        private System.Windows.Forms.TextBox txb_dlm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.CheckBox chk_auto;
        private System.Windows.Forms.Button btn_setting;
    }
}