namespace FDXS
{
    partial class Form_JifenZhekou
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_gx = new System.Windows.Forms.Button();
            this.grid_zk = new System.Windows.Forms.DataGridView();
            this.col_jf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_zk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_zk)).BeginInit();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_gx);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(377, 32);
            this.panel6.TabIndex = 8;
            // 
            // btn_gx
            // 
            this.btn_gx.Location = new System.Drawing.Point(3, 3);
            this.btn_gx.Name = "btn_gx";
            this.btn_gx.Size = new System.Drawing.Size(75, 23);
            this.btn_gx.TabIndex = 6;
            this.btn_gx.Text = "更新";
            this.btn_gx.UseVisualStyleBackColor = true;
            this.btn_gx.Click += new System.EventHandler(this.btn_sch_Click);
            // 
            // grid_zk
            // 
            this.grid_zk.AllowUserToAddRows = false;
            this.grid_zk.AllowUserToDeleteRows = false;
            this.grid_zk.AllowUserToResizeRows = false;
            this.grid_zk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_zk.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_jf,
            this.col_zk});
            this.grid_zk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_zk.Location = new System.Drawing.Point(0, 32);
            this.grid_zk.Name = "grid_zk";
            this.grid_zk.ReadOnly = true;
            this.grid_zk.RowHeadersVisible = false;
            this.grid_zk.RowTemplate.Height = 23;
            this.grid_zk.Size = new System.Drawing.Size(377, 175);
            this.grid_zk.TabIndex = 11;
            // 
            // col_jf
            // 
            this.col_jf.HeaderText = "积分";
            this.col_jf.Name = "col_jf";
            this.col_jf.ReadOnly = true;
            // 
            // col_zk
            // 
            this.col_zk.HeaderText = "折扣";
            this.col_zk.Name = "col_zk";
            this.col_zk.ReadOnly = true;
            // 
            // Form_JifenZhekou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 207);
            this.Controls.Add(this.grid_zk);
            this.Controls.Add(this.panel6);
            this.Name = "Form_JifenZhekou";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "积分折扣";
            this.Load += new System.EventHandler(this.Form_KucunYilan_Load);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_zk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btn_gx;
        private System.Windows.Forms.DataGridView grid_zk;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jf;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_zk;
    }
}