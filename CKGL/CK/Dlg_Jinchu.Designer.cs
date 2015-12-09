namespace CKGL.CK
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
            this.cmb_jms = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_zk = new System.Windows.Forms.TextBox();
            this.txb_bz = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(321, 117);
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
            this.cmb_lyqx.SelectedIndexChanged += new System.EventHandler(this.cmb_lyqx_SelectedIndexChanged);
            // 
            // cmb_jms
            // 
            this.cmb_jms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_jms.FormattingEnabled = true;
            this.cmb_jms.Location = new System.Drawing.Point(76, 43);
            this.cmb_jms.Name = "cmb_jms";
            this.cmb_jms.Size = new System.Drawing.Size(121, 20);
            this.cmb_jms.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "加盟商";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(206, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "折扣";
            // 
            // txb_zk
            // 
            this.txb_zk.Location = new System.Drawing.Point(275, 41);
            this.txb_zk.Name = "txb_zk";
            this.txb_zk.Size = new System.Drawing.Size(121, 21);
            this.txb_zk.TabIndex = 20;
            // 
            // txb_bz
            // 
            this.txb_bz.Location = new System.Drawing.Point(76, 82);
            this.txb_bz.Name = "txb_bz";
            this.txb_bz.Size = new System.Drawing.Size(320, 21);
            this.txb_bz.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "备注";
            // 
            // Dlg_Jinchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 150);
            this.Controls.Add(this.txb_bz);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txb_zk);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_jms);
            this.Controls.Add(this.label5);
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
        public System.Windows.Forms.ComboBox cmb_jms;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_zk;
        private System.Windows.Forms.TextBox txb_bz;
        private System.Windows.Forms.Label label7;
    }
}