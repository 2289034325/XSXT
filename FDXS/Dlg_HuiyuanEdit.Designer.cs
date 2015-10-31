using MyFormControls;
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
            this.txb_xm = new MyFormControls.MyTextBox();
            this.label2 = new MyFormControls.MyLabel();
            this.label1 = new MyFormControls.MyLabel();
            this.btn_ok = new MyFormControls.MyButton();
            this.txb_sjh = new MyFormControls.MyTextBox();
            this.label4 = new MyFormControls.MyLabel();
            this.label6 = new MyFormControls.MyLabel();
            this.dp_sr = new MyFormControls.MyDateTimePicker();
            this.cmb_xb = new MyFormControls.MyComboBox();
            this.btn_cancel = new MyFormControls.MyButton();
            this.SuspendLayout();
            // 
            // txb_xm
            // 
            this.txb_xm.BackColor = System.Drawing.Color.Black;
            this.txb_xm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_xm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_xm.ForeColor = System.Drawing.Color.White;
            this.txb_xm.Location = new System.Drawing.Point(59, 12);
            this.txb_xm.Name = "txb_xm";
            this.txb_xm.Size = new System.Drawing.Size(100, 26);
            this.txb_xm.TabIndex = 10;
            this.txb_xm.Type = MyFormControls.MyControlType.Standard;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "性别";
            this.label2.Type = MyFormControls.MyControlType.Standard;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "姓名";
            this.label1.Type = MyFormControls.MyControlType.Standard;
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.Black;
            this.btn_ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Location = new System.Drawing.Point(306, 124);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(100, 26);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "确定";
            this.btn_ok.Type = MyFormControls.MyControlType.Standard;
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txb_sjh
            // 
            this.txb_sjh.BackColor = System.Drawing.Color.Black;
            this.txb_sjh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_sjh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_sjh.ForeColor = System.Drawing.Color.White;
            this.txb_sjh.Location = new System.Drawing.Point(256, 12);
            this.txb_sjh.Name = "txb_sjh";
            this.txb_sjh.Size = new System.Drawing.Size(150, 26);
            this.txb_sjh.TabIndex = 17;
            this.txb_sjh.Type = MyFormControls.MyControlType.Special;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(178, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "手机号";
            this.label4.Type = MyFormControls.MyControlType.Standard;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(178, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "生日";
            this.label6.Type = MyFormControls.MyControlType.Standard;
            // 
            // dp_sr
            // 
            this.dp_sr.Font = new System.Drawing.Font("宋体", 12F);
            this.dp_sr.Location = new System.Drawing.Point(256, 42);
            this.dp_sr.Name = "dp_sr";
            this.dp_sr.Size = new System.Drawing.Size(150, 26);
            this.dp_sr.TabIndex = 21;
            this.dp_sr.Type = MyFormControls.MyControlType.Special;
            // 
            // cmb_xb
            // 
            this.cmb_xb.BackColor = System.Drawing.Color.Black;
            this.cmb_xb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_xb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.cmb_xb.ForeColor = System.Drawing.Color.White;
            this.cmb_xb.FormattingEnabled = true;
            this.cmb_xb.HighlightBackColor = System.Drawing.Color.White;
            this.cmb_xb.HighlightForeColor = System.Drawing.Color.Black;
            this.cmb_xb.Location = new System.Drawing.Point(59, 45);
            this.cmb_xb.Name = "cmb_xb";
            this.cmb_xb.Size = new System.Drawing.Size(100, 27);
            this.cmb_xb.TabIndex = 22;
            this.cmb_xb.Type = MyFormControls.MyControlType.Standard;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Black;
            this.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(200, 124);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 26);
            this.btn_cancel.TabIndex = 23;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.Type = MyFormControls.MyControlType.Standard;
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Dlg_HuiyuanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 162);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.cmb_xb);
            this.Controls.Add(this.dp_sr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_sjh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txb_xm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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

        private MyTextBox txb_xm;
        private MyLabel label2;
        private MyLabel label1;
        private MyButton btn_ok;
        private MyTextBox txb_sjh;
        private MyLabel label4;
        private MyLabel label6;
        private MyDateTimePicker dp_sr;
        private MyComboBox cmb_xb;
        private MyButton btn_cancel;
    }
}