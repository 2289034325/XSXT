namespace BIANMA
{
    partial class Dlg_Gongyingshang
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
            this.txb_mc = new System.Windows.Forms.TextBox();
            this.txb_bz = new System.Windows.Forms.TextBox();
            this.txb_lxr = new System.Windows.Forms.TextBox();
            this.btn_edit = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grid_gys = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_lxr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xgsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.txb_dz = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txb_dh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_gys)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "联系人";
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
            // txb_mc
            // 
            this.txb_mc.Location = new System.Drawing.Point(59, 13);
            this.txb_mc.Name = "txb_mc";
            this.txb_mc.Size = new System.Drawing.Size(100, 21);
            this.txb_mc.TabIndex = 4;
            // 
            // txb_bz
            // 
            this.txb_bz.Location = new System.Drawing.Point(59, 83);
            this.txb_bz.Name = "txb_bz";
            this.txb_bz.Size = new System.Drawing.Size(409, 21);
            this.txb_bz.TabIndex = 5;
            // 
            // txb_lxr
            // 
            this.txb_lxr.Location = new System.Drawing.Point(212, 13);
            this.txb_lxr.Name = "txb_lxr";
            this.txb_lxr.Size = new System.Drawing.Size(100, 21);
            this.txb_lxr.TabIndex = 7;
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
            this.splitContainer1.Panel1.Controls.Add(this.grid_gys);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_refresh);
            this.splitContainer1.Panel2.Controls.Add(this.btn_add);
            this.splitContainer1.Panel2.Controls.Add(this.txb_dz);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.txb_dh);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.txb_lxr);
            this.splitContainer1.Panel2.Controls.Add(this.btn_edit);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txb_bz);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.txb_mc);
            this.splitContainer1.Size = new System.Drawing.Size(804, 347);
            this.splitContainer1.SplitterDistance = 227;
            this.splitContainer1.TabIndex = 9;
            // 
            // grid_gys
            // 
            this.grid_gys.AllowUserToAddRows = false;
            this.grid_gys.AllowUserToResizeRows = false;
            this.grid_gys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_gys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_mc,
            this.col_lxr,
            this.col_dh,
            this.col_dz,
            this.col_bz,
            this.col_crsj,
            this.col_xgsj});
            this.grid_gys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_gys.Location = new System.Drawing.Point(0, 0);
            this.grid_gys.MultiSelect = false;
            this.grid_gys.Name = "grid_gys";
            this.grid_gys.ReadOnly = true;
            this.grid_gys.RowHeadersVisible = false;
            this.grid_gys.RowTemplate.Height = 23;
            this.grid_gys.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_gys.Size = new System.Drawing.Size(804, 227);
            this.grid_gys.TabIndex = 10;
            this.grid_gys.SelectionChanged += new System.EventHandler(this.grid_gys_SelectionChanged);
            this.grid_gys.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_gys_UserDeletingRow);
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "id";
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_mc
            // 
            this.col_mc.DataPropertyName = "mingcheng";
            this.col_mc.HeaderText = "名称";
            this.col_mc.Name = "col_mc";
            this.col_mc.ReadOnly = true;
            // 
            // col_lxr
            // 
            this.col_lxr.DataPropertyName = "lianxiren";
            this.col_lxr.HeaderText = "联系人";
            this.col_lxr.Name = "col_lxr";
            this.col_lxr.ReadOnly = true;
            // 
            // col_dh
            // 
            this.col_dh.DataPropertyName = "电话";
            this.col_dh.HeaderText = "电话";
            this.col_dh.Name = "col_dh";
            this.col_dh.ReadOnly = true;
            // 
            // col_dz
            // 
            this.col_dz.DataPropertyName = "dizhi";
            this.col_dz.HeaderText = "地址";
            this.col_dz.Name = "col_dz";
            this.col_dz.ReadOnly = true;
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
            // txb_dz
            // 
            this.txb_dz.Location = new System.Drawing.Point(59, 51);
            this.txb_dz.Name = "txb_dz";
            this.txb_dz.Size = new System.Drawing.Size(409, 21);
            this.txb_dz.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "地址";
            // 
            // txb_dh
            // 
            this.txb_dh.Location = new System.Drawing.Point(368, 16);
            this.txb_dh.Name = "txb_dh";
            this.txb_dh.Size = new System.Drawing.Size(100, 21);
            this.txb_dh.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "电话";
            // 
            // Dlg_Gongyingshang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 347);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_Gongyingshang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "供应商信息";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_gys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_mc;
        private System.Windows.Forms.TextBox txb_bz;
        private System.Windows.Forms.TextBox txb_lxr;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView grid_gys;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox txb_dz;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txb_dh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_lxr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dz;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bz;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xgsj;
    }
}