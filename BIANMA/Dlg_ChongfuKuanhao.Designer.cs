namespace BIANMA
{
    partial class Dlg_ChongfuKuanhao
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
            this.txb_jkh = new System.Windows.Forms.TextBox();
            this.btn_syjkh = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grid_kh = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_xkh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_jkhcmm = new System.Windows.Forms.Button();
            this.btn_xkhcmm = new System.Windows.Forms.Button();
            this.col_xj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_lx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xgsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_kh)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "方案1";
            // 
            // txb_jkh
            // 
            this.txb_jkh.Location = new System.Drawing.Point(249, 12);
            this.txb_jkh.Name = "txb_jkh";
            this.txb_jkh.Size = new System.Drawing.Size(100, 21);
            this.txb_jkh.TabIndex = 4;
            // 
            // btn_syjkh
            // 
            this.btn_syjkh.Location = new System.Drawing.Point(53, 68);
            this.btn_syjkh.Name = "btn_syjkh";
            this.btn_syjkh.Size = new System.Drawing.Size(190, 23);
            this.btn_syjkh.TabIndex = 8;
            this.btn_syjkh.Text = "使用旧款号";
            this.btn_syjkh.UseVisualStyleBackColor = true;
            this.btn_syjkh.Click += new System.EventHandler(this.btn_syjkh_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grid_kh);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txb_xkh);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.btn_jkhcmm);
            this.splitContainer1.Panel2.Controls.Add(this.btn_xkhcmm);
            this.splitContainer1.Panel2.Controls.Add(this.btn_syjkh);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txb_jkh);
            this.splitContainer1.Size = new System.Drawing.Size(620, 214);
            this.splitContainer1.SplitterDistance = 108;
            this.splitContainer1.TabIndex = 9;
            // 
            // grid_kh
            // 
            this.grid_kh.AllowUserToAddRows = false;
            this.grid_kh.AllowUserToResizeRows = false;
            this.grid_kh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grid_kh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_kh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_xj,
            this.col_kh,
            this.col_xb,
            this.col_lx,
            this.col_pm,
            this.col_bz,
            this.col_crsj,
            this.col_xgsj});
            this.grid_kh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_kh.Location = new System.Drawing.Point(0, 0);
            this.grid_kh.MultiSelect = false;
            this.grid_kh.Name = "grid_kh";
            this.grid_kh.ReadOnly = true;
            this.grid_kh.RowHeadersVisible = false;
            this.grid_kh.RowTemplate.Height = 23;
            this.grid_kh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_kh.Size = new System.Drawing.Size(620, 108);
            this.grid_kh.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "方案3";
            // 
            // txb_xkh
            // 
            this.txb_xkh.Location = new System.Drawing.Point(249, 41);
            this.txb_xkh.Name = "txb_xkh";
            this.txb_xkh.Size = new System.Drawing.Size(100, 21);
            this.txb_xkh.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "方案2";
            // 
            // btn_jkhcmm
            // 
            this.btn_jkhcmm.Location = new System.Drawing.Point(53, 10);
            this.btn_jkhcmm.Name = "btn_jkhcmm";
            this.btn_jkhcmm.Size = new System.Drawing.Size(190, 23);
            this.btn_jkhcmm.TabIndex = 14;
            this.btn_jkhcmm.Text = "将旧款号重新命名为";
            this.btn_jkhcmm.UseVisualStyleBackColor = true;
            this.btn_jkhcmm.Click += new System.EventHandler(this.btn_jkhcmm_Click);
            // 
            // btn_xkhcmm
            // 
            this.btn_xkhcmm.Location = new System.Drawing.Point(53, 39);
            this.btn_xkhcmm.Name = "btn_xkhcmm";
            this.btn_xkhcmm.Size = new System.Drawing.Size(190, 23);
            this.btn_xkhcmm.TabIndex = 13;
            this.btn_xkhcmm.Text = "将新款号重新命名为";
            this.btn_xkhcmm.UseVisualStyleBackColor = true;
            this.btn_xkhcmm.Click += new System.EventHandler(this.btn_xkhcmm_Click);
            // 
            // col_xj
            // 
            this.col_xj.HeaderText = "新/旧";
            this.col_xj.Name = "col_xj";
            this.col_xj.ReadOnly = true;
            this.col_xj.Width = 60;
            // 
            // col_kh
            // 
            this.col_kh.DataPropertyName = "款号";
            this.col_kh.HeaderText = "款号";
            this.col_kh.Name = "col_kh";
            this.col_kh.ReadOnly = true;
            this.col_kh.Width = 54;
            // 
            // col_xb
            // 
            this.col_xb.DataPropertyName = "xingbie";
            this.col_xb.HeaderText = "性别";
            this.col_xb.Name = "col_xb";
            this.col_xb.ReadOnly = true;
            this.col_xb.Width = 54;
            // 
            // col_lx
            // 
            this.col_lx.DataPropertyName = "leixing";
            this.col_lx.HeaderText = "类型";
            this.col_lx.Name = "col_lx";
            this.col_lx.ReadOnly = true;
            this.col_lx.Width = 54;
            // 
            // col_pm
            // 
            this.col_pm.DataPropertyName = "pinming";
            this.col_pm.HeaderText = "品名";
            this.col_pm.Name = "col_pm";
            this.col_pm.ReadOnly = true;
            this.col_pm.Width = 54;
            // 
            // col_bz
            // 
            this.col_bz.DataPropertyName = "beizhu";
            this.col_bz.HeaderText = "备注";
            this.col_bz.Name = "col_bz";
            this.col_bz.ReadOnly = true;
            this.col_bz.Width = 54;
            // 
            // col_crsj
            // 
            this.col_crsj.DataPropertyName = "charushijian";
            this.col_crsj.HeaderText = "插入时间";
            this.col_crsj.Name = "col_crsj";
            this.col_crsj.ReadOnly = true;
            this.col_crsj.Width = 78;
            // 
            // col_xgsj
            // 
            this.col_xgsj.DataPropertyName = "修改时间";
            this.col_xgsj.HeaderText = "修改时间";
            this.col_xgsj.Name = "col_xgsj";
            this.col_xgsj.ReadOnly = true;
            this.col_xgsj.Width = 78;
            // 
            // Dlg_ChongfuKuanhao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 214);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_ChongfuKuanhao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "重复款号信息";
            this.Load += new System.EventHandler(this.Dlg_ChongfuKuanhao_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_kh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_jkh;
        private System.Windows.Forms.Button btn_syjkh;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView grid_kh;
        private System.Windows.Forms.Button btn_jkhcmm;
        private System.Windows.Forms.Button btn_xkhcmm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txb_xkh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xb;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_lx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bz;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xgsj;
    }
}