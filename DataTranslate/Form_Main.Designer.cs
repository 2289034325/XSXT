namespace DataTranslate
{
    partial class Form_Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.txb_jcsj = new System.Windows.Forms.TextBox();
            this.txb_fd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_tm = new System.Windows.Forms.Button();
            this.btn_xs = new System.Windows.Forms.Button();
            this.btn_xz = new System.Windows.Forms.Button();
            this.btn_kc = new System.Windows.Forms.Button();
            this.btn_fdzb = new System.Windows.Forms.Button();
            this.btn_jcsjzb = new System.Windows.Forms.Button();
            this.txb_kcid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "JCSJ用户ID";
            // 
            // txb_jcsj
            // 
            this.txb_jcsj.Location = new System.Drawing.Point(93, 9);
            this.txb_jcsj.Name = "txb_jcsj";
            this.txb_jcsj.Size = new System.Drawing.Size(100, 21);
            this.txb_jcsj.TabIndex = 1;
            // 
            // txb_fd
            // 
            this.txb_fd.Location = new System.Drawing.Point(559, 9);
            this.txb_fd.Name = "txb_fd";
            this.txb_fd.Size = new System.Drawing.Size(100, 21);
            this.txb_fd.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(489, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "FD用户ID";
            // 
            // btn_tm
            // 
            this.btn_tm.Location = new System.Drawing.Point(137, 173);
            this.btn_tm.Name = "btn_tm";
            this.btn_tm.Size = new System.Drawing.Size(75, 23);
            this.btn_tm.TabIndex = 4;
            this.btn_tm.Text = "条码信息";
            this.btn_tm.UseVisualStyleBackColor = true;
            this.btn_tm.Click += new System.EventHandler(this.btn_tm_Click);
            // 
            // btn_xs
            // 
            this.btn_xs.Location = new System.Drawing.Point(345, 173);
            this.btn_xs.Name = "btn_xs";
            this.btn_xs.Size = new System.Drawing.Size(75, 23);
            this.btn_xs.TabIndex = 5;
            this.btn_xs.Text = "销售";
            this.btn_xs.UseVisualStyleBackColor = true;
            this.btn_xs.Click += new System.EventHandler(this.btn_xs_Click);
            // 
            // btn_xz
            // 
            this.btn_xz.Location = new System.Drawing.Point(437, 173);
            this.btn_xz.Name = "btn_xz";
            this.btn_xz.Size = new System.Drawing.Size(92, 23);
            this.btn_xz.TabIndex = 6;
            this.btn_xz.Text = "进货数量修正";
            this.btn_xz.UseVisualStyleBackColor = true;
            this.btn_xz.Click += new System.EventHandler(this.btn_xz_Click);
            // 
            // btn_kc
            // 
            this.btn_kc.Location = new System.Drawing.Point(243, 173);
            this.btn_kc.Name = "btn_kc";
            this.btn_kc.Size = new System.Drawing.Size(75, 23);
            this.btn_kc.TabIndex = 7;
            this.btn_kc.Text = "库存";
            this.btn_kc.UseVisualStyleBackColor = true;
            this.btn_kc.Click += new System.EventHandler(this.btn_kc_Click);
            // 
            // btn_fdzb
            // 
            this.btn_fdzb.Location = new System.Drawing.Point(345, 89);
            this.btn_fdzb.Name = "btn_fdzb";
            this.btn_fdzb.Size = new System.Drawing.Size(75, 23);
            this.btn_fdzb.TabIndex = 8;
            this.btn_fdzb.Text = "FD准备";
            this.btn_fdzb.UseVisualStyleBackColor = true;
            this.btn_fdzb.Click += new System.EventHandler(this.btn_fdzb_Click);
            // 
            // btn_jcsjzb
            // 
            this.btn_jcsjzb.Location = new System.Drawing.Point(137, 89);
            this.btn_jcsjzb.Name = "btn_jcsjzb";
            this.btn_jcsjzb.Size = new System.Drawing.Size(75, 23);
            this.btn_jcsjzb.TabIndex = 9;
            this.btn_jcsjzb.Text = "JCSJ准备";
            this.btn_jcsjzb.UseVisualStyleBackColor = true;
            this.btn_jcsjzb.Click += new System.EventHandler(this.btn_jcsjzb_Click);
            // 
            // txb_kcid
            // 
            this.txb_kcid.Location = new System.Drawing.Point(559, 36);
            this.txb_kcid.Name = "txb_kcid";
            this.txb_kcid.Size = new System.Drawing.Size(100, 21);
            this.txb_kcid.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(489, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "庫存ID";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 256);
            this.Controls.Add(this.txb_kcid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_jcsjzb);
            this.Controls.Add(this.btn_fdzb);
            this.Controls.Add(this.btn_kc);
            this.Controls.Add(this.btn_xz);
            this.Controls.Add(this.btn_xs);
            this.Controls.Add(this.btn_tm);
            this.Controls.Add(this.txb_fd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_jcsj);
            this.Controls.Add(this.label1);
            this.Name = "Form_Main";
            this.Text = "Form_Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_jcsj;
        private System.Windows.Forms.TextBox txb_fd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_tm;
        private System.Windows.Forms.Button btn_xs;
        private System.Windows.Forms.Button btn_xz;
        private System.Windows.Forms.Button btn_kc;
        private System.Windows.Forms.Button btn_fdzb;
        private System.Windows.Forms.Button btn_jcsjzb;
        private System.Windows.Forms.TextBox txb_kcid;
        private System.Windows.Forms.Label label3;
    }
}