using MyFormControls;
namespace FDXS
{
    partial class Dlg_KucunXZ
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
            this.txb_tmh = new MyFormControls.MyTextBox();
            this.txb_sl = new MyFormControls.MyTextBox();
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
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "条码号";
            this.label1.Type = MyFormControls.MyControlType.Standard;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(201, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "数量";
            this.label3.Type = MyFormControls.MyControlType.Standard;
            // 
            // txb_tmh
            // 
            this.txb_tmh.BackColor = System.Drawing.Color.Black;
            this.txb_tmh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_tmh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_tmh.ForeColor = System.Drawing.Color.White;
            this.txb_tmh.Location = new System.Drawing.Point(95, 12);
            this.txb_tmh.Name = "txb_tmh";
            this.txb_tmh.Size = new System.Drawing.Size(100, 26);
            this.txb_tmh.TabIndex = 4;
            this.txb_tmh.Type = MyFormControls.MyControlType.Standard;
            // 
            // txb_sl
            // 
            this.txb_sl.BackColor = System.Drawing.Color.Black;
            this.txb_sl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_sl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_sl.ForeColor = System.Drawing.Color.White;
            this.txb_sl.Location = new System.Drawing.Point(252, 12);
            this.txb_sl.Name = "txb_sl";
            this.txb_sl.Size = new System.Drawing.Size(100, 26);
            this.txb_sl.TabIndex = 6;
            this.txb_sl.Type = MyFormControls.MyControlType.Standard;
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.Black;
            this.btn_ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Location = new System.Drawing.Point(252, 85);
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
            this.btn_cancel.Location = new System.Drawing.Point(146, 85);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 26);
            this.btn_cancel.TabIndex = 9;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.Type = MyFormControls.MyControlType.Standard;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Dlg_KucunXZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 132);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txb_sl);
            this.Controls.Add(this.txb_tmh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_KucunXZ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "库存修正";
            this.Load += new System.EventHandler(this.Dlg_Zhuce_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyLabel label1;
        private MyLabel label3;
        private MyTextBox txb_tmh;
        private MyTextBox txb_sl;
        private MyButton btn_ok;
        private MyButton btn_cancel;
    }
}