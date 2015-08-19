namespace FDXS
{
    partial class Dlg_Wutiaoma
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_pm = new System.Windows.Forms.TextBox();
            this.txb_cm = new System.Windows.Forms.TextBox();
            this.txb_ys = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.txb_jj = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_sj = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "品名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "颜色";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(306, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "尺码";
            // 
            // txb_pm
            // 
            this.txb_pm.Location = new System.Drawing.Point(59, 22);
            this.txb_pm.Name = "txb_pm";
            this.txb_pm.Size = new System.Drawing.Size(100, 21);
            this.txb_pm.TabIndex = 4;
            // 
            // txb_cm
            // 
            this.txb_cm.Location = new System.Drawing.Point(353, 20);
            this.txb_cm.Name = "txb_cm";
            this.txb_cm.Size = new System.Drawing.Size(100, 21);
            this.txb_cm.TabIndex = 5;
            // 
            // txb_ys
            // 
            this.txb_ys.Location = new System.Drawing.Point(200, 22);
            this.txb_ys.Name = "txb_ys";
            this.txb_ys.Size = new System.Drawing.Size(100, 21);
            this.txb_ys.TabIndex = 6;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(353, 52);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(100, 23);
            this.btn_ok.TabIndex = 8;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txb_jj
            // 
            this.txb_jj.Location = new System.Drawing.Point(59, 49);
            this.txb_jj.Name = "txb_jj";
            this.txb_jj.Size = new System.Drawing.Size(100, 21);
            this.txb_jj.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "进价";
            // 
            // txb_sj
            // 
            this.txb_sj.Location = new System.Drawing.Point(200, 49);
            this.txb_sj.Name = "txb_sj";
            this.txb_sj.Size = new System.Drawing.Size(100, 21);
            this.txb_sj.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(165, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "售价";
            // 
            // Dlg_Wutiaoma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 96);
            this.Controls.Add(this.txb_sj);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txb_jj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txb_ys);
            this.Controls.Add(this.txb_cm);
            this.Controls.Add(this.txb_pm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_Wutiaoma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "无条码商品";
            this.Load += new System.EventHandler(this.Dlg_Zhuce_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_pm;
        private System.Windows.Forms.TextBox txb_cm;
        private System.Windows.Forms.TextBox txb_ys;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox txb_jj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_sj;
        private System.Windows.Forms.Label label5;
    }
}