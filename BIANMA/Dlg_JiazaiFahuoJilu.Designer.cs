namespace BIANMA
{
    partial class Dlg_JiazaiFahuoJilu
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
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.dp_start = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_pp = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "品牌";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(246, 88);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 8;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // dp_start
            // 
            this.dp_start.Location = new System.Drawing.Point(216, 35);
            this.dp_start.Name = "dp_start";
            this.dp_start.Size = new System.Drawing.Size(105, 21);
            this.dp_start.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "发货日期";
            // 
            // cmb_pp
            // 
            this.cmb_pp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_pp.FormattingEnabled = true;
            this.cmb_pp.Location = new System.Drawing.Point(46, 35);
            this.cmb_pp.Name = "cmb_pp";
            this.cmb_pp.Size = new System.Drawing.Size(105, 20);
            this.cmb_pp.TabIndex = 14;
            // 
            // Dlg_JiazaiFahuoJilu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 133);
            this.Controls.Add(this.cmb_pp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dp_start);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_JiazaiFahuoJilu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "从供应商发货记录加载条码信息";
            this.Load += new System.EventHandler(this.Dlg_JiazaiFahuoJilu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dp_start;
        private System.Windows.Forms.ComboBox cmb_pp;
    }
}