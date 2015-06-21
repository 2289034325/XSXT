namespace CKGL
{
    partial class Dlg_Fendian
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
            this.btn_ok = new System.Windows.Forms.Button();
            this.cmb_fd = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(173, 22);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 8;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // cmb_fd
            // 
            this.cmb_fd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_fd.FormattingEnabled = true;
            this.cmb_fd.Location = new System.Drawing.Point(12, 24);
            this.cmb_fd.Name = "cmb_fd";
            this.cmb_fd.Size = new System.Drawing.Size(121, 20);
            this.cmb_fd.TabIndex = 9;
            // 
            // Dlg_Fendian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 64);
            this.Controls.Add(this.cmb_fd);
            this.Controls.Add(this.btn_ok);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_Fendian";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择分店";
            this.Load += new System.EventHandler(this.Dlg_Fendian_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        public System.Windows.Forms.ComboBox cmb_fd;
    }
}