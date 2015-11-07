namespace CKGL.CK
{
    partial class Dlg_Zhuce
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
            this.txb_ckid = new System.Windows.Forms.TextBox();
            this.txb_zcm = new System.Windows.Forms.TextBox();
            this.txb_ckm = new System.Windows.Forms.TextBox();
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
            this.label1.Text = "仓库ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "验证码";
            // 
            // txb_ckid
            // 
            this.txb_ckid.Location = new System.Drawing.Point(59, 22);
            this.txb_ckid.Name = "txb_ckid";
            this.txb_ckid.Size = new System.Drawing.Size(100, 21);
            this.txb_ckid.TabIndex = 4;
            // 
            // txb_zcm
            // 
            this.txb_zcm.Location = new System.Drawing.Point(59, 78);
            this.txb_zcm.Name = "txb_zcm";
            this.txb_zcm.Size = new System.Drawing.Size(100, 21);
            this.txb_zcm.TabIndex = 5;
            // 
            // txb_ckm
            // 
            this.txb_ckm.Location = new System.Drawing.Point(200, 22);
            this.txb_ckm.Name = "txb_ckm";
            this.txb_ckm.Size = new System.Drawing.Size(100, 21);
            this.txb_ckm.TabIndex = 6;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(225, 78);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 8;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // Dlg_Zhuce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 131);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txb_ckm);
            this.Controls.Add(this.txb_zcm);
            this.Controls.Add(this.txb_ckid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_Zhuce";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册";
            this.Load += new System.EventHandler(this.Dlg_Zhuce_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_ckid;
        private System.Windows.Forms.TextBox txb_zcm;
        private System.Windows.Forms.TextBox txb_ckm;
        private System.Windows.Forms.Button btn_ok;
    }
}