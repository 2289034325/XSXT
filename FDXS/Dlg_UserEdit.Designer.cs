﻿namespace FDXS
{
    partial class Dlg_UserEdit
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
            this.txb_dlm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.txb_mm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_js = new System.Windows.Forms.ComboBox();
            this.txb_yhm = new System.Windows.Forms.TextBox();
            this.txb_bz = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_zt = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "角色";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "登录名";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(250, 105);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txb_mm
            // 
            this.txb_mm.Location = new System.Drawing.Point(225, 6);
            this.txb_mm.Name = "txb_mm";
            this.txb_mm.PasswordChar = '*';
            this.txb_mm.Size = new System.Drawing.Size(100, 21);
            this.txb_mm.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "用户名";
            // 
            // cmb_js
            // 
            this.cmb_js.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_js.FormattingEnabled = true;
            this.cmb_js.Location = new System.Drawing.Point(59, 39);
            this.cmb_js.Name = "cmb_js";
            this.cmb_js.Size = new System.Drawing.Size(100, 20);
            this.cmb_js.TabIndex = 22;
            // 
            // txb_yhm
            // 
            this.txb_yhm.Location = new System.Drawing.Point(225, 39);
            this.txb_yhm.Name = "txb_yhm";
            this.txb_yhm.Size = new System.Drawing.Size(100, 21);
            this.txb_yhm.TabIndex = 23;
            // 
            // txb_bz
            // 
            this.txb_bz.Location = new System.Drawing.Point(59, 73);
            this.txb_bz.Name = "txb_bz";
            this.txb_bz.Size = new System.Drawing.Size(266, 21);
            this.txb_bz.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "备注";
            // 
            // cmb_zt
            // 
            this.cmb_zt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_zt.FormattingEnabled = true;
            this.cmb_zt.Location = new System.Drawing.Point(59, 107);
            this.cmb_zt.Name = "cmb_zt";
            this.cmb_zt.Size = new System.Drawing.Size(100, 20);
            this.cmb_zt.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "状态";
            // 
            // Dlg_UserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 145);
            this.Controls.Add(this.cmb_zt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_bz);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txb_yhm);
            this.Controls.Add(this.cmb_js);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_mm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txb_dlm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_UserEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统用户信息";
            this.Load += new System.EventHandler(this.Dlg_UserEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_dlm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox txb_mm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_js;
        private System.Windows.Forms.TextBox txb_yhm;
        private System.Windows.Forms.TextBox txb_bz;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_zt;
        private System.Windows.Forms.Label label5;
    }
}