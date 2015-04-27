namespace BIANMA
{
    partial class Dlg_Kuanhao
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_kh = new System.Windows.Forms.TextBox();
            this.txb_bz = new System.Windows.Forms.TextBox();
            this.btn_edit = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grid_kh = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_lx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xgsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmb_lx = new System.Windows.Forms.ComboBox();
            this.cmb_xb = new System.Windows.Forms.ComboBox();
            this.txb_pm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
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
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "款号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "性别";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "备注";
            // 
            // txb_kh
            // 
            this.txb_kh.Location = new System.Drawing.Point(59, 13);
            this.txb_kh.Name = "txb_kh";
            this.txb_kh.Size = new System.Drawing.Size(100, 21);
            this.txb_kh.TabIndex = 4;
            // 
            // txb_bz
            // 
            this.txb_bz.Location = new System.Drawing.Point(59, 83);
            this.txb_bz.Name = "txb_bz";
            this.txb_bz.Size = new System.Drawing.Size(562, 21);
            this.txb_bz.TabIndex = 5;
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(717, 83);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 8;
            this.btn_edit.Text = "修改";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
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
            this.splitContainer1.Panel2.Controls.Add(this.cmb_lx);
            this.splitContainer1.Panel2.Controls.Add(this.cmb_xb);
            this.splitContainer1.Panel2.Controls.Add(this.txb_pm);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.btn_refresh);
            this.splitContainer1.Panel2.Controls.Add(this.btn_add);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.btn_edit);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txb_bz);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.txb_kh);
            this.splitContainer1.Size = new System.Drawing.Size(804, 347);
            this.splitContainer1.SplitterDistance = 227;
            this.splitContainer1.TabIndex = 9;
            // 
            // grid_kh
            // 
            this.grid_kh.AllowUserToAddRows = false;
            this.grid_kh.AllowUserToResizeRows = false;
            this.grid_kh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_kh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
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
            this.grid_kh.Size = new System.Drawing.Size(804, 227);
            this.grid_kh.TabIndex = 10;
            this.grid_kh.SelectionChanged += new System.EventHandler(this.grid_kh_SelectionChanged);
            this.grid_kh.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_kh_UserDeletingRow);
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "id";
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_kh
            // 
            this.col_kh.DataPropertyName = "款号";
            this.col_kh.HeaderText = "款号";
            this.col_kh.Name = "col_kh";
            this.col_kh.ReadOnly = true;
            // 
            // col_xb
            // 
            this.col_xb.DataPropertyName = "xingbie";
            this.col_xb.HeaderText = "性别";
            this.col_xb.Name = "col_xb";
            this.col_xb.ReadOnly = true;
            // 
            // col_lx
            // 
            this.col_lx.DataPropertyName = "leixing";
            this.col_lx.HeaderText = "类型";
            this.col_lx.Name = "col_lx";
            this.col_lx.ReadOnly = true;
            // 
            // col_pm
            // 
            this.col_pm.DataPropertyName = "pinming";
            this.col_pm.HeaderText = "品名";
            this.col_pm.Name = "col_pm";
            this.col_pm.ReadOnly = true;
            // 
            // col_bz
            // 
            this.col_bz.DataPropertyName = "beizhu";
            this.col_bz.HeaderText = "备注";
            this.col_bz.Name = "col_bz";
            this.col_bz.ReadOnly = true;
            // 
            // col_crsj
            // 
            this.col_crsj.DataPropertyName = "charushijian";
            this.col_crsj.HeaderText = "插入时间";
            this.col_crsj.Name = "col_crsj";
            this.col_crsj.ReadOnly = true;
            // 
            // col_xgsj
            // 
            this.col_xgsj.DataPropertyName = "修改时间";
            this.col_xgsj.HeaderText = "修改时间";
            this.col_xgsj.Name = "col_xgsj";
            this.col_xgsj.ReadOnly = true;
            // 
            // cmb_lx
            // 
            this.cmb_lx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_lx.FormattingEnabled = true;
            this.cmb_lx.Location = new System.Drawing.Point(356, 16);
            this.cmb_lx.Name = "cmb_lx";
            this.cmb_lx.Size = new System.Drawing.Size(90, 20);
            this.cmb_lx.TabIndex = 18;
            // 
            // cmb_xb
            // 
            this.cmb_xb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xb.FormattingEnabled = true;
            this.cmb_xb.Location = new System.Drawing.Point(200, 13);
            this.cmb_xb.Name = "cmb_xb";
            this.cmb_xb.Size = new System.Drawing.Size(90, 20);
            this.cmb_xb.TabIndex = 17;
            // 
            // txb_pm
            // 
            this.txb_pm.Location = new System.Drawing.Point(521, 16);
            this.txb_pm.Name = "txb_pm";
            this.txb_pm.Size = new System.Drawing.Size(100, 21);
            this.txb_pm.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(474, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "品名";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(717, 18);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_refresh.TabIndex = 14;
            this.btn_refresh.Text = "刷新";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(717, 51);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 13;
            this.btn_add.Text = "增加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "类型";
            // 
            // Dlg_Kuanhao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 347);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_Kuanhao";
            this.Text = "款号信息";
            this.Load += new System.EventHandler(this.Dlg_Kuanhao_Load);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_kh;
        private System.Windows.Forms.TextBox txb_bz;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView grid_kh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox txb_pm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_lx;
        private System.Windows.Forms.ComboBox cmb_xb;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xb;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_lx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bz;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xgsj;
    }
}