namespace FDXS
{
    partial class Dlg_HuiyuanEdit
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
            this.txb_xm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.txb_sjh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dp_sr = new System.Windows.Forms.DateTimePicker();
            this.cmb_xb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txb_xm
            // 
            this.txb_xm.Location = new System.Drawing.Point(59, 6);
            this.txb_xm.Name = "txb_xm";
            this.txb_xm.Size = new System.Drawing.Size(100, 21);
            this.txb_xm.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "性别";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "姓名";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(250, 107);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txb_sjh
            // 
            this.txb_sjh.Location = new System.Drawing.Point(225, 6);
            this.txb_sjh.Name = "txb_sjh";
            this.txb_sjh.Size = new System.Drawing.Size(100, 21);
            this.txb_sjh.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "手机号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "生日";
            // 
            // dp_sr
            // 
            this.dp_sr.Location = new System.Drawing.Point(225, 36);
            this.dp_sr.Name = "dp_sr";
            this.dp_sr.Size = new System.Drawing.Size(100, 21);
            this.dp_sr.TabIndex = 21;
            // 
            // cmb_xb
            // 
            this.cmb_xb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xb.FormattingEnabled = true;
            this.cmb_xb.Location = new System.Drawing.Point(59, 39);
            this.cmb_xb.Name = "cmb_xb";
            this.cmb_xb.Size = new System.Drawing.Size(100, 20);
            this.cmb_xb.TabIndex = 22;
            // 
            // Dlg_HuiyuanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 145);
            this.Controls.Add(this.cmb_xb);
            this.Controls.Add(this.dp_sr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_sjh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txb_xm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_HuiyuanEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员信息";
            this.Load += new System.EventHandler(this.Dlg_HuiyuanEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_xm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox txb_sjh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dp_sr;
        private System.Windows.Forms.ComboBox cmb_xb;
    }
}