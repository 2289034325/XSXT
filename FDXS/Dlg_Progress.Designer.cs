namespace FDXS
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
            this.lbl_msg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_msg.Location = new System.Drawing.Point(0, 0);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(474, 118);
            this.lbl_msg.TabIndex = 1;
            this.lbl_msg.Text = "adfadfafdasdfasdfasdfasdfasdfasdfaraba4f5646a153df13ad4f56a4fd65a4d56f431346546a4" +
    "64a1s641df531a4s3df143as1df3sdf";
            // 
            // pgb
            // 
            this.pgb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgb.Location = new System.Drawing.Point(0, 95);
            this.pgb.Name = "pgb";
            this.pgb.Size = new System.Drawing.Size(474, 23);
            this.pgb.TabIndex = 2;
            // 
            // Dlg_Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 118);
            this.Controls.Add(this.pgb);
            this.Controls.Add(this.lbl_msg);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_Progress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "处理进度";
            this.Load += new System.EventHandler(this.Dlg_Progress_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbl_msg;
        public System.Windows.Forms.ProgressBar pgb;

    }
}