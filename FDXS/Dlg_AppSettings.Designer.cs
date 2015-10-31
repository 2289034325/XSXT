using MyFormControls;
namespace FDXS
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
            this.txb_bakPath = new MyFormControls.MyTextBox();
            this.label10 = new MyFormControls.MyLabel();
            this.txb_dbPath = new MyFormControls.MyTextBox();
            this.label9 = new MyFormControls.MyLabel();
            this.txb_dbserver = new MyFormControls.MyTextBox();
            this.label8 = new MyFormControls.MyLabel();
            this.dp_xsinterval = new MyFormControls.MyDateTimePicker();
            this.dp_daytasktime = new MyFormControls.MyDateTimePicker();
            this.label7 = new MyFormControls.MyLabel();
            this.label6 = new MyFormControls.MyLabel();
            this.txb_dataadd = new MyFormControls.MyTextBox();
            this.label5 = new MyFormControls.MyLabel();
            this.txb_validadd = new MyFormControls.MyTextBox();
            this.label4 = new MyFormControls.MyLabel();
            this.txb_dbpsw = new MyFormControls.MyTextBox();
            this.label3 = new MyFormControls.MyLabel();
            this.btn_ok = new MyFormControls.MyButton();
            this.txb_dbuser = new MyFormControls.MyTextBox();
            this.txb_dbname = new MyFormControls.MyTextBox();
            this.label2 = new MyFormControls.MyLabel();
            this.label1 = new MyFormControls.MyLabel();
            this.btn_cancel = new MyFormControls.MyButton();
            this.SuspendLayout();
            // 
            // txb_bakPath
            // 
            this.txb_bakPath.BackColor = System.Drawing.Color.Black;
            this.txb_bakPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_bakPath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_bakPath.ForeColor = System.Drawing.Color.White;
            this.txb_bakPath.Location = new System.Drawing.Point(399, 70);
            this.txb_bakPath.Name = "txb_bakPath";
            this.txb_bakPath.Size = new System.Drawing.Size(165, 26);
            this.txb_bakPath.TabIndex = 28;
            this.txb_bakPath.Type = MyFormControls.MyControlType.Special;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(322, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "BkPath";
            this.label10.Type = MyFormControls.MyControlType.Standard;
            // 
            // txb_dbPath
            // 
            this.txb_dbPath.BackColor = System.Drawing.Color.Black;
            this.txb_dbPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_dbPath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_dbPath.ForeColor = System.Drawing.Color.White;
            this.txb_dbPath.Location = new System.Drawing.Point(153, 70);
            this.txb_dbPath.Name = "txb_dbPath";
            this.txb_dbPath.Size = new System.Drawing.Size(163, 26);
            this.txb_dbPath.TabIndex = 26;
            this.txb_dbPath.Type = MyFormControls.MyControlType.Special;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "DBPath";
            this.label9.Type = MyFormControls.MyControlType.Standard;
            // 
            // txb_dbserver
            // 
            this.txb_dbserver.BackColor = System.Drawing.Color.Black;
            this.txb_dbserver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_dbserver.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_dbserver.ForeColor = System.Drawing.Color.White;
            this.txb_dbserver.Location = new System.Drawing.Point(153, 6);
            this.txb_dbserver.Name = "txb_dbserver";
            this.txb_dbserver.Size = new System.Drawing.Size(163, 26);
            this.txb_dbserver.TabIndex = 24;
            this.txb_dbserver.Type = MyFormControls.MyControlType.Special;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "DBServer";
            this.label8.Type = MyFormControls.MyControlType.Standard;
            // 
            // dp_xsinterval
            // 
            this.dp_xsinterval.CustomFormat = "HH:mm:ss";
            this.dp_xsinterval.Font = new System.Drawing.Font("宋体", 12F);
            this.dp_xsinterval.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp_xsinterval.Location = new System.Drawing.Point(195, 198);
            this.dp_xsinterval.Name = "dp_xsinterval";
            this.dp_xsinterval.Size = new System.Drawing.Size(104, 26);
            this.dp_xsinterval.TabIndex = 22;
            this.dp_xsinterval.Type = MyFormControls.MyControlType.Special;
            // 
            // dp_daytasktime
            // 
            this.dp_daytasktime.CustomFormat = "HH:mm:ss";
            this.dp_daytasktime.Font = new System.Drawing.Font("宋体", 12F);
            this.dp_daytasktime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp_daytasktime.Location = new System.Drawing.Point(195, 166);
            this.dp_daytasktime.Name = "dp_daytasktime";
            this.dp_daytasktime.Size = new System.Drawing.Size(104, 26);
            this.dp_daytasktime.TabIndex = 21;
            this.dp_daytasktime.Type = MyFormControls.MyControlType.Special;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "销售数据上报间隔";
            this.label7.Type = MyFormControls.MyControlType.Standard;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "每日任务执行时间";
            this.label6.Type = MyFormControls.MyControlType.Standard;
            // 
            // txb_dataadd
            // 
            this.txb_dataadd.BackColor = System.Drawing.Color.Black;
            this.txb_dataadd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_dataadd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_dataadd.ForeColor = System.Drawing.Color.White;
            this.txb_dataadd.Location = new System.Drawing.Point(153, 134);
            this.txb_dataadd.Name = "txb_dataadd";
            this.txb_dataadd.Size = new System.Drawing.Size(411, 26);
            this.txb_dataadd.TabIndex = 18;
            this.txb_dataadd.Type = MyFormControls.MyControlType.Special;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "WCFDataADD";
            this.label5.Type = MyFormControls.MyControlType.Standard;
            // 
            // txb_validadd
            // 
            this.txb_validadd.BackColor = System.Drawing.Color.Black;
            this.txb_validadd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_validadd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_validadd.ForeColor = System.Drawing.Color.White;
            this.txb_validadd.Location = new System.Drawing.Point(153, 102);
            this.txb_validadd.Name = "txb_validadd";
            this.txb_validadd.Size = new System.Drawing.Size(411, 26);
            this.txb_validadd.TabIndex = 16;
            this.txb_validadd.Type = MyFormControls.MyControlType.Special;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "WCFValidADD";
            this.label4.Type = MyFormControls.MyControlType.Standard;
            // 
            // txb_dbpsw
            // 
            this.txb_dbpsw.BackColor = System.Drawing.Color.Black;
            this.txb_dbpsw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_dbpsw.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_dbpsw.ForeColor = System.Drawing.Color.White;
            this.txb_dbpsw.Location = new System.Drawing.Point(399, 38);
            this.txb_dbpsw.Name = "txb_dbpsw";
            this.txb_dbpsw.PasswordChar = '*';
            this.txb_dbpsw.Size = new System.Drawing.Size(165, 26);
            this.txb_dbpsw.TabIndex = 14;
            this.txb_dbpsw.Type = MyFormControls.MyControlType.Special;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(322, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "DBPsw";
            this.label3.Type = MyFormControls.MyControlType.Standard;
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.Black;
            this.btn_ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Location = new System.Drawing.Point(464, 198);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(100, 26);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "确定";
            this.btn_ok.Type = MyFormControls.MyControlType.Standard;
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txb_dbuser
            // 
            this.txb_dbuser.BackColor = System.Drawing.Color.Black;
            this.txb_dbuser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_dbuser.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_dbuser.ForeColor = System.Drawing.Color.White;
            this.txb_dbuser.Location = new System.Drawing.Point(153, 38);
            this.txb_dbuser.Name = "txb_dbuser";
            this.txb_dbuser.Size = new System.Drawing.Size(163, 26);
            this.txb_dbuser.TabIndex = 11;
            this.txb_dbuser.Type = MyFormControls.MyControlType.Special;
            // 
            // txb_dbname
            // 
            this.txb_dbname.BackColor = System.Drawing.Color.Black;
            this.txb_dbname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_dbname.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_dbname.ForeColor = System.Drawing.Color.White;
            this.txb_dbname.Location = new System.Drawing.Point(399, 6);
            this.txb_dbname.Name = "txb_dbname";
            this.txb_dbname.Size = new System.Drawing.Size(165, 26);
            this.txb_dbname.TabIndex = 10;
            this.txb_dbname.Type = MyFormControls.MyControlType.Special;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "DBUser";
            this.label2.Type = MyFormControls.MyControlType.Standard;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(322, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "DBName";
            this.label1.Type = MyFormControls.MyControlType.Standard;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Black;
            this.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(358, 198);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 26);
            this.btn_cancel.TabIndex = 29;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.Type = MyFormControls.MyControlType.Standard;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Dlg_AppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(576, 231);
            this.Controls.Add(this.btn_cancel);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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

        private MyTextBox txb_dbuser;
        private MyTextBox txb_dbname;
        private MyLabel label2;
        private MyLabel label1;
        private MyButton btn_ok;
        private MyTextBox txb_dbpsw;
        private MyLabel label3;
        private MyTextBox txb_validadd;
        private MyLabel label4;
        private MyTextBox txb_dataadd;
        private MyLabel label5;
        private MyLabel label6;
        private MyLabel label7;
        private MyDateTimePicker dp_daytasktime;
        private MyDateTimePicker dp_xsinterval;
        private MyTextBox txb_dbserver;
        private MyLabel label8;
        private MyTextBox txb_dbPath;
        private MyLabel label9;
        private MyTextBox txb_bakPath;
        private MyLabel label10;
        private MyButton btn_cancel;
    }
}