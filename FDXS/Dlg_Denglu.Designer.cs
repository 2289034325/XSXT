using MyFormControls;
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
            this.txb_mm = new MyFormControls.MyTextBox();
            this.txb_dlm = new MyFormControls.MyTextBox();
            this.btn_ok = new MyFormControls.MyButton();
            this.chk_auto = new System.Windows.Forms.CheckBox();
            this.btn_setting = new MyFormControls.MyButton();
            this.btn_resetscan = new MyFormControls.MyButton();
            this.btn_cancel = new MyFormControls.MyButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txb_mm
            // 
            this.txb_mm.BackColor = System.Drawing.Color.Black;
            this.txb_mm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_mm.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Bold);
            this.txb_mm.ForeColor = System.Drawing.Color.White;
            this.txb_mm.Location = new System.Drawing.Point(63, 67);
            this.txb_mm.Name = "txb_mm";
            this.txb_mm.PasswordChar = '*';
            this.txb_mm.Size = new System.Drawing.Size(363, 53);
            this.txb_mm.TabIndex = 11;
            this.txb_mm.Type = MyFormControls.MyControlType.Special;
            this.txb_mm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_mm_KeyDown);
            // 
            // txb_dlm
            // 
            this.txb_dlm.BackColor = System.Drawing.Color.Black;
            this.txb_dlm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_dlm.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Bold);
            this.txb_dlm.ForeColor = System.Drawing.Color.White;
            this.txb_dlm.Location = new System.Drawing.Point(63, 8);
            this.txb_dlm.Name = "txb_dlm";
            this.txb_dlm.Size = new System.Drawing.Size(363, 53);
            this.txb_dlm.TabIndex = 10;
            this.txb_dlm.Type = MyFormControls.MyControlType.Special;
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.Black;
            this.btn_ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Location = new System.Drawing.Point(326, 202);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(100, 26);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "确定";
            this.btn_ok.Type = MyFormControls.MyControlType.Standard;
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // chk_auto
            // 
            this.chk_auto.AutoSize = true;
            this.chk_auto.ForeColor = System.Drawing.Color.White;
            this.chk_auto.Location = new System.Drawing.Point(63, 126);
            this.chk_auto.Name = "chk_auto";
            this.chk_auto.Size = new System.Drawing.Size(72, 16);
            this.chk_auto.TabIndex = 13;
            this.chk_auto.Text = "自动登陆";
            this.chk_auto.UseVisualStyleBackColor = true;
            // 
            // btn_setting
            // 
            this.btn_setting.BackColor = System.Drawing.Color.Black;
            this.btn_setting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_setting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_setting.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_setting.ForeColor = System.Drawing.Color.White;
            this.btn_setting.Location = new System.Drawing.Point(326, 126);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(100, 26);
            this.btn_setting.TabIndex = 14;
            this.btn_setting.Text = "设置";
            this.btn_setting.Type = MyFormControls.MyControlType.Standard;
            this.btn_setting.UseVisualStyleBackColor = false;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // btn_resetscan
            // 
            this.btn_resetscan.BackColor = System.Drawing.Color.Black;
            this.btn_resetscan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_resetscan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_resetscan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_resetscan.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_resetscan.ForeColor = System.Drawing.Color.White;
            this.btn_resetscan.Location = new System.Drawing.Point(220, 126);
            this.btn_resetscan.Name = "btn_resetscan";
            this.btn_resetscan.Size = new System.Drawing.Size(100, 26);
            this.btn_resetscan.TabIndex = 15;
            this.btn_resetscan.Text = "重置扫描枪";
            this.btn_resetscan.Type = MyFormControls.MyControlType.Standard;
            this.btn_resetscan.UseVisualStyleBackColor = false;
            this.btn_resetscan.Click += new System.EventHandler(this.btn_resetscan_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Black;
            this.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(220, 202);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 26);
            this.btn_cancel.TabIndex = 16;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.Type = MyFormControls.MyControlType.Standard;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::FDXS.Properties.Resources.user_white;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(45, 45);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::FDXS.Properties.Resources.password_white;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Location = new System.Drawing.Point(12, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(45, 45);
            this.panel2.TabIndex = 18;
            // 
            // Dlg_Denglu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 245);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_resetscan);
            this.Controls.Add(this.btn_setting);
            this.Controls.Add(this.chk_auto);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txb_mm);
            this.Controls.Add(this.txb_dlm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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

        private MyTextBox txb_mm;
        private MyTextBox txb_dlm;
        private MyButton btn_ok;
        private System.Windows.Forms.CheckBox chk_auto;
        private MyButton btn_setting;
        private MyButton btn_resetscan;
        private MyButton btn_cancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}