﻿namespace FDXS
{
    partial class Dlg_AppSettings
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
            this.txb_dbuser = new System.Windows.Forms.TextBox();
            this.txb_dbname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.txb_dbpsw = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_validadd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_dataadd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dp_daytasktime = new System.Windows.Forms.DateTimePicker();
            this.dp_xsinterval = new System.Windows.Forms.DateTimePicker();
            this.txb_dbserver = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txb_dbPath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txb_bakPath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txb_dbuser
            // 
            this.txb_dbuser.Location = new System.Drawing.Point(89, 39);
            this.txb_dbuser.Name = "txb_dbuser";
            this.txb_dbuser.Size = new System.Drawing.Size(163, 21);
            this.txb_dbuser.TabIndex = 11;
            // 
            // txb_dbname
            // 
            this.txb_dbname.Location = new System.Drawing.Point(335, 12);
            this.txb_dbname.Name = "txb_dbname";
            this.txb_dbname.Size = new System.Drawing.Size(163, 21);
            this.txb_dbname.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "DBUser";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "DBName";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(423, 199);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txb_dbpsw
            // 
            this.txb_dbpsw.Location = new System.Drawing.Point(335, 39);
            this.txb_dbpsw.Name = "txb_dbpsw";
            this.txb_dbpsw.PasswordChar = '*';
            this.txb_dbpsw.Size = new System.Drawing.Size(163, 21);
            this.txb_dbpsw.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "DBPsw";
            // 
            // txb_validadd
            // 
            this.txb_validadd.Location = new System.Drawing.Point(89, 93);
            this.txb_validadd.Name = "txb_validadd";
            this.txb_validadd.Size = new System.Drawing.Size(409, 21);
            this.txb_validadd.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "WCFValidADD";
            // 
            // txb_dataadd
            // 
            this.txb_dataadd.Location = new System.Drawing.Point(89, 120);
            this.txb_dataadd.Name = "txb_dataadd";
            this.txb_dataadd.Size = new System.Drawing.Size(409, 21);
            this.txb_dataadd.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "WCFDataADD";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "每日任务执行时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(258, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "销售数据上报间隔";
            // 
            // dp_daytasktime
            // 
            this.dp_daytasktime.CustomFormat = "HH:mm:ss";
            this.dp_daytasktime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp_daytasktime.Location = new System.Drawing.Point(119, 158);
            this.dp_daytasktime.Name = "dp_daytasktime";
            this.dp_daytasktime.Size = new System.Drawing.Size(133, 21);
            this.dp_daytasktime.TabIndex = 21;
            // 
            // dp_xsinterval
            // 
            this.dp_xsinterval.CustomFormat = "HH:mm:ss";
            this.dp_xsinterval.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp_xsinterval.Location = new System.Drawing.Point(365, 158);
            this.dp_xsinterval.Name = "dp_xsinterval";
            this.dp_xsinterval.Size = new System.Drawing.Size(133, 21);
            this.dp_xsinterval.TabIndex = 22;
            // 
            // txb_dbserver
            // 
            this.txb_dbserver.Location = new System.Drawing.Point(89, 12);
            this.txb_dbserver.Name = "txb_dbserver";
            this.txb_dbserver.Size = new System.Drawing.Size(163, 21);
            this.txb_dbserver.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 23;
            this.label8.Text = "DBServer";
            // 
            // txb_dbPath
            // 
            this.txb_dbPath.Location = new System.Drawing.Point(89, 66);
            this.txb_dbPath.Name = "txb_dbPath";
            this.txb_dbPath.Size = new System.Drawing.Size(163, 21);
            this.txb_dbPath.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "DBPath";
            // 
            // txb_bakPath
            // 
            this.txb_bakPath.Location = new System.Drawing.Point(335, 66);
            this.txb_bakPath.Name = "txb_bakPath";
            this.txb_bakPath.Size = new System.Drawing.Size(163, 21);
            this.txb_bakPath.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(258, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "BkPath";
            // 
            // Dlg_AppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 241);
            this.Controls.Add(this.txb_bakPath);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txb_dbPath);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txb_dbserver);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dp_xsinterval);
            this.Controls.Add(this.dp_daytasktime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_dataadd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_validadd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_dbpsw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txb_dbuser);
            this.Controls.Add(this.txb_dbname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_AppSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "程序设置";
            this.Load += new System.EventHandler(this.Dlg_AppSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_dbuser;
        private System.Windows.Forms.TextBox txb_dbname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox txb_dbpsw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_validadd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_dataadd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dp_daytasktime;
        private System.Windows.Forms.DateTimePicker dp_xsinterval;
        private System.Windows.Forms.TextBox txb_dbserver;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txb_dbPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txb_bakPath;
        private System.Windows.Forms.Label label10;
    }
}