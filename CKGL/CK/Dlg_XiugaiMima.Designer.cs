namespace CKGL.CK
{
    partial class Dlg_XiugaiMima
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_jmm = new System.Windows.Forms.TextBox();
            this.txb_xmm2 = new System.Windows.Forms.TextBox();
            this.txb_xmm1 = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "旧密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "新密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "新密码";
            // 
            // txb_jmm
            // 
            this.txb_jmm.Location = new System.Drawing.Point(59, 22);
            this.txb_jmm.Name = "txb_jmm";
            this.txb_jmm.PasswordChar = '*';
            this.txb_jmm.Size = new System.Drawing.Size(100, 21);
            this.txb_jmm.TabIndex = 4;
            // 
            // txb_xmm2
            // 
            this.txb_xmm2.Location = new System.Drawing.Point(59, 78);
            this.txb_xmm2.Name = "txb_xmm2";
            this.txb_xmm2.PasswordChar = '*';
            this.txb_xmm2.Size = new System.Drawing.Size(100, 21);
            this.txb_xmm2.TabIndex = 5;
            // 
            // txb_xmm1
            // 
            this.txb_xmm1.Location = new System.Drawing.Point(59, 51);
            this.txb_xmm1.Name = "txb_xmm1";
            this.txb_xmm1.PasswordChar = '*';
            this.txb_xmm1.Size = new System.Drawing.Size(100, 21);
            this.txb_xmm1.TabIndex = 6;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(84, 117);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 8;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // Dlg_MimaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 152);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txb_xmm1);
            this.Controls.Add(this.txb_xmm2);
            this.Controls.Add(this.txb_jmm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_MimaEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.Dlg_Zhuce_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_jmm;
        private System.Windows.Forms.TextBox txb_xmm2;
        private System.Windows.Forms.TextBox txb_xmm1;
        private System.Windows.Forms.Button btn_ok;
    }
}