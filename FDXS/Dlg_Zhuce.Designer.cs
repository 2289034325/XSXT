using MyFormControls;
namespace FDXS
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
            this.label1 = new MyFormControls.MyLabel();
            this.label3 = new MyFormControls.MyLabel();
            this.label4 = new MyFormControls.MyLabel();
            this.txb_fdid = new MyFormControls.MyTextBox();
            this.txb_zcm = new MyFormControls.MyTextBox();
            this.txb_fdm = new MyFormControls.MyTextBox();
            this.btn_ok = new MyFormControls.MyButton();
            this.btn_cancel = new MyFormControls.MyButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "分店ID";
            this.label1.Type = MyFormControls.MyControlType.Standard;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(196, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "名称";
            this.label3.Type = MyFormControls.MyControlType.Standard;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "验证码";
            this.label4.Type = MyFormControls.MyControlType.Standard;
            // 
            // txb_fdid
            // 
            this.txb_fdid.BackColor = System.Drawing.Color.Black;
            this.txb_fdid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_fdid.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_fdid.ForeColor = System.Drawing.Color.White;
            this.txb_fdid.Location = new System.Drawing.Point(90, 19);
            this.txb_fdid.Name = "txb_fdid";
            this.txb_fdid.Size = new System.Drawing.Size(100, 26);
            this.txb_fdid.TabIndex = 4;
            this.txb_fdid.Type = MyFormControls.MyControlType.Standard;
            // 
            // txb_zcm
            // 
            this.txb_zcm.BackColor = System.Drawing.Color.Black;
            this.txb_zcm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_zcm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_zcm.ForeColor = System.Drawing.Color.White;
            this.txb_zcm.Location = new System.Drawing.Point(90, 65);
            this.txb_zcm.Name = "txb_zcm";
            this.txb_zcm.Size = new System.Drawing.Size(263, 26);
            this.txb_zcm.TabIndex = 5;
            this.txb_zcm.Type = MyFormControls.MyControlType.Special;
            // 
            // txb_fdm
            // 
            this.txb_fdm.BackColor = System.Drawing.Color.Black;
            this.txb_fdm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_fdm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_fdm.ForeColor = System.Drawing.Color.White;
            this.txb_fdm.Location = new System.Drawing.Point(253, 19);
            this.txb_fdm.Name = "txb_fdm";
            this.txb_fdm.Size = new System.Drawing.Size(100, 26);
            this.txb_fdm.TabIndex = 6;
            this.txb_fdm.Type = MyFormControls.MyControlType.Standard;
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.Black;
            this.btn_ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Location = new System.Drawing.Point(253, 110);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(100, 26);
            this.btn_ok.TabIndex = 8;
            this.btn_ok.Text = "确定";
            this.btn_ok.Type = MyFormControls.MyControlType.Standard;
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Black;
            this.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(147, 110);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 26);
            this.btn_cancel.TabIndex = 9;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.Type = MyFormControls.MyControlType.Standard;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Dlg_Zhuce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 153);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txb_fdm);
            this.Controls.Add(this.txb_zcm);
            this.Controls.Add(this.txb_fdid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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

        private MyLabel label1;
        private MyLabel label3;
        private MyLabel label4;
        private MyTextBox txb_fdid;
        private MyTextBox txb_zcm;
        private MyTextBox txb_fdm;
        private MyButton btn_ok;
        private MyButton btn_cancel;
    }
}