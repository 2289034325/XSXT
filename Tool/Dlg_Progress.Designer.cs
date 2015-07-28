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
            this.lbl_msg = new System.Windows.Forms.Label();
            this.pgb = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lbl_msg
            // 
            this.lbl_msg.AutoSize = true;
            this.lbl_msg.Location = new System.Drawing.Point(12, 9);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(29, 12);
            this.lbl_msg.TabIndex = 0;
            this.lbl_msg.Text = "消息";
            // 
            // pgb
            // 
            this.pgb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgb.Location = new System.Drawing.Point(0, 80);
            this.pgb.Name = "pgb";
            this.pgb.Size = new System.Drawing.Size(379, 23);
            this.pgb.TabIndex = 1;
            // 
            // Dlg_Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 103);
            this.Controls.Add(this.pgb);
            this.Controls.Add(this.lbl_msg);
            this.Name = "Dlg_Progress";
            this.Text = "处理进度";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dlg_Progress_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbl_msg;
        public System.Windows.Forms.ProgressBar pgb;

    }
}