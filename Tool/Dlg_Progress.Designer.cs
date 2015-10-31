using MyFormControls;
using System.Windows.Forms;
namespace Tool
{
    partial class Dlg_Progress
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
            this.lbl_msg = new MyFormControls.MyLabel();
            this.pgb = new MyFormControls.MyProgressBar();
            this.btn_close = new MyFormControls.MyButton();
            this.SuspendLayout();
            // 
            // lbl_msg
            // 
            this.lbl_msg.AutoSize = true;
            this.lbl_msg.BackColor = System.Drawing.Color.Black;
            this.lbl_msg.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_msg.ForeColor = System.Drawing.Color.White;
            this.lbl_msg.Location = new System.Drawing.Point(12, 9);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(177, 20);
            this.lbl_msg.TabIndex = 0;
            this.lbl_msg.Text = "正在处理，请稍等";
            this.lbl_msg.Type = MyFormControls.MyControlType.Standard;
            // 
            // pgb
            // 
            this.pgb.BackColor = System.Drawing.Color.White;
            this.pgb.ForeColor = System.Drawing.Color.White;
            this.pgb.Location = new System.Drawing.Point(12, 90);
            this.pgb.Name = "pgb";
            this.pgb.Size = new System.Drawing.Size(649, 23);
            this.pgb.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgb.TabIndex = 1;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackColor = System.Drawing.Color.Black;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(561, 119);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(100, 26);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "关闭";
            this.btn_close.Type = MyFormControls.MyControlType.Standard;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // Dlg_Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 148);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.pgb);
            this.Controls.Add(this.lbl_msg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dlg_Progress";
            this.Text = "处理进度";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dlg_Progress_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public MyLabel lbl_msg;
        public MyProgressBar pgb;
        public MyButton btn_close;

    }
}