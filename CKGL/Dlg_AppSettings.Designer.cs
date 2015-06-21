namespace CKGL
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
            this.SuspendLayout();
            // 
            // txb_dbuser
            // 
            this.txb_dbuser.Location = new System.Drawing.Point(89, 33);
            this.txb_dbuser.Name = "txb_dbuser";
            this.txb_dbuser.Size = new System.Drawing.Size(100, 21);
            this.txb_dbuser.TabIndex = 11;
            // 
            // txb_dbname
            // 
            this.txb_dbname.Location = new System.Drawing.Point(89, 6);
            this.txb_dbname.Name = "txb_dbname";
            this.txb_dbname.Size = new System.Drawing.Size(100, 21);
            this.txb_dbname.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "DBUser";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "DBName";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(177, 141);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txb_dbpsw
            // 
            this.txb_dbpsw.Location = new System.Drawing.Point(89, 60);
            this.txb_dbpsw.Name = "txb_dbpsw";
            this.txb_dbpsw.PasswordChar = '*';
            this.txb_dbpsw.Size = new System.Drawing.Size(100, 21);
            this.txb_dbpsw.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "DBPsw";
            // 
            // txb_validadd
            // 
            this.txb_validadd.Location = new System.Drawing.Point(89, 87);
            this.txb_validadd.Name = "txb_validadd";
            this.txb_validadd.Size = new System.Drawing.Size(163, 21);
            this.txb_validadd.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "WCFValidADD";
            // 
            // txb_dataadd
            // 
            this.txb_dataadd.Location = new System.Drawing.Point(89, 114);
            this.txb_dataadd.Name = "txb_dataadd";
            this.txb_dataadd.Size = new System.Drawing.Size(163, 21);
            this.txb_dataadd.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "WCFDataADD";
            // 
            // Dlg_AppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 169);
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
    }
}