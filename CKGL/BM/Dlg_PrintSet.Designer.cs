namespace CKGL.BM
{
    partial class Dlg_PrintSet
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
            this.txb_offset_left = new System.Windows.Forms.TextBox();
            this.txb_img = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_double = new System.Windows.Forms.CheckBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_logo = new System.Windows.Forms.Button();
            this.txb_width = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_height = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_interval = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_offset_top = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txb_offset_left
            // 
            this.txb_offset_left.Location = new System.Drawing.Point(71, 91);
            this.txb_offset_left.Name = "txb_offset_left";
            this.txb_offset_left.Size = new System.Drawing.Size(100, 21);
            this.txb_offset_left.TabIndex = 11;
            // 
            // txb_img
            // 
            this.txb_img.Location = new System.Drawing.Point(71, 6);
            this.txb_img.Name = "txb_img";
            this.txb_img.Size = new System.Drawing.Size(223, 21);
            this.txb_img.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "左偏移";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "Logo图片";
            // 
            // chk_double
            // 
            this.chk_double.AutoSize = true;
            this.chk_double.Location = new System.Drawing.Point(14, 63);
            this.chk_double.Name = "chk_double";
            this.chk_double.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_double.Size = new System.Drawing.Size(72, 16);
            this.chk_double.TabIndex = 13;
            this.chk_double.Text = "双排标签";
            this.chk_double.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(262, 129);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 16;
            this.btn_ok.Text = "保存";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_logo
            // 
            this.btn_logo.Location = new System.Drawing.Point(300, 4);
            this.btn_logo.Name = "btn_logo";
            this.btn_logo.Size = new System.Drawing.Size(37, 23);
            this.btn_logo.TabIndex = 17;
            this.btn_logo.Text = "打开";
            this.btn_logo.UseVisualStyleBackColor = true;
            this.btn_logo.Click += new System.EventHandler(this.btn_logo_Click);
            // 
            // txb_width
            // 
            this.txb_width.Location = new System.Drawing.Point(71, 33);
            this.txb_width.Name = "txb_width";
            this.txb_width.Size = new System.Drawing.Size(100, 21);
            this.txb_width.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "标签宽度";
            // 
            // txb_height
            // 
            this.txb_height.Location = new System.Drawing.Point(237, 36);
            this.txb_height.Name = "txb_height";
            this.txb_height.Size = new System.Drawing.Size(100, 21);
            this.txb_height.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "标签高度";
            // 
            // txb_interval
            // 
            this.txb_interval.Location = new System.Drawing.Point(237, 63);
            this.txb_interval.Name = "txb_interval";
            this.txb_interval.Size = new System.Drawing.Size(100, 21);
            this.txb_interval.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "两排标签之间的间距";
            // 
            // txb_offset_top
            // 
            this.txb_offset_top.Location = new System.Drawing.Point(237, 90);
            this.txb_offset_top.Name = "txb_offset_top";
            this.txb_offset_top.Size = new System.Drawing.Size(100, 21);
            this.txb_offset_top.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "顶偏移";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "*以上单位均为毫米(mm)";
            // 
            // Dlg_PrintSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 164);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txb_offset_top);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_interval);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_height);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_width);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_logo);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.chk_double);
            this.Controls.Add(this.txb_offset_left);
            this.Controls.Add(this.txb_img);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_PrintSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印设置";
            this.Load += new System.EventHandler(this.Dlg_PrintSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_offset_left;
        private System.Windows.Forms.TextBox txb_img;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_double;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_logo;
        private System.Windows.Forms.TextBox txb_width;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_height;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_interval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_offset_top;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}