namespace CKGL.BM
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
            this.chk_autoLogin = new System.Windows.Forms.CheckBox();
            this.btn_bangding = new System.Windows.Forms.Button();
            this.txb_yzm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txb_mm
            // 
            this.txb_mm.Location = new System.Drawing.Point(212, 6);
            this.txb_mm.Name = "txb_mm";
            this.txb_mm.PasswordChar = '*';
            this.txb_mm.Size = new System.Drawing.Size(100, 21);
            this.txb_mm.TabIndex = 11;
            this.txb_mm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_mm_KeyDown);
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
            this.btn_ok.Location = new System.Drawing.Point(237, 48);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // chk_autoLogin
            // 
            this.chk_autoLogin.AutoSize = true;
            this.chk_autoLogin.Location = new System.Drawing.Point(59, 48);
            this.chk_autoLogin.Name = "chk_autoLogin";
            this.chk_autoLogin.Size = new System.Drawing.Size(72, 16);
            this.chk_autoLogin.TabIndex = 13;
            this.chk_autoLogin.Text = "自动登录";
            this.chk_autoLogin.UseVisualStyleBackColor = true;
            // 
            // btn_bangding
            // 
            this.btn_bangding.Location = new System.Drawing.Point(237, 130);
            this.btn_bangding.Name = "btn_bangding";
            this.btn_bangding.Size = new System.Drawing.Size(75, 23);
            this.btn_bangding.TabIndex = 16;
            this.btn_bangding.Text = "机器绑定";
            this.btn_bangding.UseVisualStyleBackColor = true;
            this.btn_bangding.Click += new System.EventHandler(this.btn_bangding_Click);
            // 
            // txb_yzm
            // 
            this.txb_yzm.Location = new System.Drawing.Point(59, 128);
            this.txb_yzm.Name = "txb_yzm";
            this.txb_yzm.Size = new System.Drawing.Size(100, 21);
            this.txb_yzm.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "验证码";
            // 
            // Dlg_Denglu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 86);
            this.Controls.Add(this.btn_bangding);
            this.Controls.Add(this.txb_yzm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chk_autoLogin);
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
        private System.Windows.Forms.CheckBox chk_autoLogin;
        private System.Windows.Forms.Button btn_bangding;
        private System.Windows.Forms.TextBox txb_yzm;
        private System.Windows.Forms.Label label3;
    }
}