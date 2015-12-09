namespace FDXS
{
    partial class Dlg_Jinchu
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
            this.cmb_fx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_lyqx = new System.Windows.Forms.ComboBox();
            this.txb_bz = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(321, 83);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 8;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // cmb_fx
            // 
            this.cmb_fx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_fx.FormattingEnabled = true;
            this.cmb_fx.Location = new System.Drawing.Point(76, 6);
            this.cmb_fx.Name = "cmb_fx";
            this.cmb_fx.Size = new System.Drawing.Size(121, 20);
            this.cmb_fx.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "方向";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "来源去向";
            // 
            // cmb_lyqx
            // 
            this.cmb_lyqx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_lyqx.FormattingEnabled = true;
            this.cmb_lyqx.Location = new System.Drawing.Point(275, 6);
            this.cmb_lyqx.Name = "cmb_lyqx";
            this.cmb_lyqx.Size = new System.Drawing.Size(121, 20);
            this.cmb_lyqx.TabIndex = 12;
            // 
            // txb_bz
            // 
            this.txb_bz.Location = new System.Drawing.Point(76, 48);
            this.txb_bz.Name = "txb_bz";
            this.txb_bz.Size = new System.Drawing.Size(320, 21);
            this.txb_bz.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "备注";
            // 
            // Dlg_Jinchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 119);
            this.Controls.Add(this.txb_bz);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmb_lyqx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_fx);
            this.Controls.Add(this.btn_ok);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_Jinchu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "进出库选项";
            this.Load += new System.EventHandler(this.Dlg_Fendian_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        public System.Windows.Forms.ComboBox cmb_fx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cmb_lyqx;
        private System.Windows.Forms.TextBox txb_bz;
        private System.Windows.Forms.Label label7;
    }
}