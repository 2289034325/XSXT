using MyFormControls;
namespace FDXS
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
            this.txb_dlm = new MyFormControls.MyTextBox();
            this.label2 = new MyFormControls.MyLabel();
            this.label1 = new MyFormControls.MyLabel();
            this.btn_ok = new MyFormControls.MyButton();
            this.txb_mm = new MyFormControls.MyTextBox();
            this.label4 = new MyFormControls.MyLabel();
            this.label6 = new MyFormControls.MyLabel();
            this.cmb_js = new MyFormControls.MyComboBox();
            this.txb_yhm = new MyFormControls.MyTextBox();
            this.txb_bz = new MyFormControls.MyTextBox();
            this.label3 = new MyFormControls.MyLabel();
            this.cmb_zt = new MyFormControls.MyComboBox();
            this.label5 = new MyFormControls.MyLabel();
            this.btn_cancel = new MyFormControls.MyButton();
            this.SuspendLayout();
            // 
            // txb_dlm
            // 
            this.txb_dlm.BackColor = System.Drawing.Color.Black;
            this.txb_dlm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_dlm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_dlm.ForeColor = System.Drawing.Color.White;
            this.txb_dlm.Location = new System.Drawing.Point(90, 10);
            this.txb_dlm.Name = "txb_dlm";
            this.txb_dlm.Size = new System.Drawing.Size(100, 26);
            this.txb_dlm.TabIndex = 10;
            this.txb_dlm.Type = MyFormControls.MyControlType.Standard;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "角色";
            this.label2.Type = MyFormControls.MyControlType.Standard;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "登录名";
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
            this.btn_ok.Location = new System.Drawing.Point(286, 159);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(100, 26);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "确定";
            this.btn_ok.Type = MyFormControls.MyControlType.Standard;
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txb_mm
            // 
            this.txb_mm.BackColor = System.Drawing.Color.Black;
            this.txb_mm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_mm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_mm.ForeColor = System.Drawing.Color.White;
            this.txb_mm.Location = new System.Drawing.Point(283, 10);
            this.txb_mm.Name = "txb_mm";
            this.txb_mm.PasswordChar = '*';
            this.txb_mm.Size = new System.Drawing.Size(100, 26);
            this.txb_mm.TabIndex = 17;
            this.txb_mm.Type = MyFormControls.MyControlType.Standard;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(209, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "密码";
            this.label4.Type = MyFormControls.MyControlType.Standard;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(209, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "用户名";
            this.label6.Type = MyFormControls.MyControlType.Standard;
            // 
            // cmb_js
            // 
            this.cmb_js.BackColor = System.Drawing.Color.Black;
            this.cmb_js.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_js.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_js.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.cmb_js.ForeColor = System.Drawing.Color.White;
            this.cmb_js.FormattingEnabled = true;
            this.cmb_js.HighlightBackColor = System.Drawing.Color.White;
            this.cmb_js.HighlightForeColor = System.Drawing.Color.Black;
            this.cmb_js.Location = new System.Drawing.Point(90, 43);
            this.cmb_js.Name = "cmb_js";
            this.cmb_js.Size = new System.Drawing.Size(100, 27);
            this.cmb_js.TabIndex = 22;
            this.cmb_js.Type = MyFormControls.MyControlType.Standard;
            // 
            // txb_yhm
            // 
            this.txb_yhm.BackColor = System.Drawing.Color.Black;
            this.txb_yhm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_yhm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_yhm.ForeColor = System.Drawing.Color.White;
            this.txb_yhm.Location = new System.Drawing.Point(283, 43);
            this.txb_yhm.Name = "txb_yhm";
            this.txb_yhm.Size = new System.Drawing.Size(100, 26);
            this.txb_yhm.TabIndex = 23;
            this.txb_yhm.Type = MyFormControls.MyControlType.Standard;
            // 
            // txb_bz
            // 
            this.txb_bz.BackColor = System.Drawing.Color.Black;
            this.txb_bz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_bz.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_bz.ForeColor = System.Drawing.Color.White;
            this.txb_bz.Location = new System.Drawing.Point(90, 108);
            this.txb_bz.Name = "txb_bz";
            this.txb_bz.Size = new System.Drawing.Size(293, 26);
            this.txb_bz.TabIndex = 25;
            this.txb_bz.Type = MyFormControls.MyControlType.Special;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "备注";
            this.label3.Type = MyFormControls.MyControlType.Standard;
            // 
            // cmb_zt
            // 
            this.cmb_zt.BackColor = System.Drawing.Color.Black;
            this.cmb_zt.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_zt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_zt.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.cmb_zt.ForeColor = System.Drawing.Color.White;
            this.cmb_zt.FormattingEnabled = true;
            this.cmb_zt.HighlightBackColor = System.Drawing.Color.White;
            this.cmb_zt.HighlightForeColor = System.Drawing.Color.Black;
            this.cmb_zt.Location = new System.Drawing.Point(90, 75);
            this.cmb_zt.Name = "cmb_zt";
            this.cmb_zt.Size = new System.Drawing.Size(100, 27);
            this.cmb_zt.TabIndex = 27;
            this.cmb_zt.Type = MyFormControls.MyControlType.Standard;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "状态";
            this.label5.Type = MyFormControls.MyControlType.Standard;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Black;
            this.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(180, 159);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 26);
            this.btn_cancel.TabIndex = 28;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.Type = MyFormControls.MyControlType.Standard;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Dlg_UserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 204);
            this.Controls.Add(this.btn_cancel);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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

        private MyTextBox txb_dlm;
        private MyLabel label2;
        private MyLabel label1;
        private MyButton btn_ok;
        private MyTextBox txb_mm;
        private MyLabel label4;
        private MyLabel label6;
        private MyComboBox cmb_js;
        private MyTextBox txb_yhm;
        private MyTextBox txb_bz;
        private MyLabel label3;
        private MyComboBox cmb_zt;
        private MyLabel label5;
        private MyButton btn_cancel;
    }
}