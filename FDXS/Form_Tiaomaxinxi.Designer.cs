namespace FDXS
{
    partial class Form_Tiaomaxinxi
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
            this.grid_tm = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gyskh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_lx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gxsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmb_lx = new System.Windows.Forms.ComboBox();
            this.btn_xzzdtm = new System.Windows.Forms.Button();
            this.btn_xzzxtm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_sch = new System.Windows.Forms.Button();
            this.txb_kh = new System.Windows.Forms.TextBox();
            this.txb_tm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dp_end = new System.Windows.Forms.DateTimePicker();
            this.dp_start = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.grid_tm)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_tm
            // 
            this.grid_tm.AllowUserToAddRows = false;
            this.grid_tm.AllowUserToDeleteRows = false;
            this.grid_tm.AllowUserToResizeRows = false;
            this.grid_tm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_tm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_tm,
            this.col_kh,
            this.col_gyskh,
            this.col_lx,
            this.col_pm,
            this.col_ys,
            this.col_cm,
            this.col_sj,
            this.col_gxsj});
            this.grid_tm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_tm.Location = new System.Drawing.Point(0, 32);
            this.grid_tm.MultiSelect = false;
            this.grid_tm.Name = "grid_tm";
            this.grid_tm.ReadOnly = true;
            this.grid_tm.RowHeadersVisible = false;
            this.grid_tm.RowTemplate.Height = 23;
            this.grid_tm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_tm.Size = new System.Drawing.Size(1005, 466);
            this.grid_tm.TabIndex = 14;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            // 
            // col_tm
            // 
            this.col_tm.HeaderText = "条码";
            this.col_tm.Name = "col_tm";
            this.col_tm.ReadOnly = true;
            // 
            // col_kh
            // 
            this.col_kh.HeaderText = "款号";
            this.col_kh.Name = "col_kh";
            this.col_kh.ReadOnly = true;
            // 
            // col_gyskh
            // 
            this.col_gyskh.HeaderText = "供应商款号";
            this.col_gyskh.Name = "col_gyskh";
            this.col_gyskh.ReadOnly = true;
            // 
            // col_lx
            // 
            this.col_lx.HeaderText = "类型";
            this.col_lx.Name = "col_lx";
            this.col_lx.ReadOnly = true;
            // 
            // col_pm
            // 
            this.col_pm.HeaderText = "品名";
            this.col_pm.Name = "col_pm";
            this.col_pm.ReadOnly = true;
            // 
            // col_ys
            // 
            this.col_ys.HeaderText = "颜色";
            this.col_ys.Name = "col_ys";
            this.col_ys.ReadOnly = true;
            // 
            // col_cm
            // 
            this.col_cm.HeaderText = "尺码";
            this.col_cm.Name = "col_cm";
            this.col_cm.ReadOnly = true;
            // 
            // col_sj
            // 
            this.col_sj.HeaderText = "售价";
            this.col_sj.Name = "col_sj";
            this.col_sj.ReadOnly = true;
            // 
            // col_gxsj
            // 
            this.col_gxsj.HeaderText = "更新时间";
            this.col_gxsj.Name = "col_gxsj";
            this.col_gxsj.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dp_end);
            this.panel3.Controls.Add(this.dp_start);
            this.panel3.Controls.Add(this.cmb_lx);
            this.panel3.Controls.Add(this.btn_xzzdtm);
            this.panel3.Controls.Add(this.btn_xzzxtm);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btn_sch);
            this.panel3.Controls.Add(this.txb_kh);
            this.panel3.Controls.Add(this.txb_tm);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1005, 32);
            this.panel3.TabIndex = 13;
            // 
            // cmb_lx
            // 
            this.cmb_lx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_lx.FormattingEnabled = true;
            this.cmb_lx.Location = new System.Drawing.Point(334, 5);
            this.cmb_lx.Name = "cmb_lx";
            this.cmb_lx.Size = new System.Drawing.Size(77, 20);
            this.cmb_lx.TabIndex = 13;
            // 
            // btn_xzzdtm
            // 
            this.btn_xzzdtm.Location = new System.Drawing.Point(906, 5);
            this.btn_xzzdtm.Name = "btn_xzzdtm";
            this.btn_xzzdtm.Size = new System.Drawing.Size(94, 23);
            this.btn_xzzdtm.TabIndex = 12;
            this.btn_xzzdtm.Text = "下载指定条码";
            this.btn_xzzdtm.UseVisualStyleBackColor = true;
            this.btn_xzzdtm.Click += new System.EventHandler(this.btn_xzzdtm_Click);
            // 
            // btn_xzzxtm
            // 
            this.btn_xzzxtm.Location = new System.Drawing.Point(575, 3);
            this.btn_xzzxtm.Name = "btn_xzzxtm";
            this.btn_xzzxtm.Size = new System.Drawing.Size(101, 23);
            this.btn_xzzxtm.TabIndex = 11;
            this.btn_xzzxtm.Text = "下载条码";
            this.btn_xzzxtm.UseVisualStyleBackColor = true;
            this.btn_xzzxtm.Click += new System.EventHandler(this.btn_xzzxtm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "类型";
            // 
            // btn_sch
            // 
            this.btn_sch.Location = new System.Drawing.Point(417, 3);
            this.btn_sch.Name = "btn_sch";
            this.btn_sch.Size = new System.Drawing.Size(75, 23);
            this.btn_sch.TabIndex = 6;
            this.btn_sch.Text = "查询";
            this.btn_sch.UseVisualStyleBackColor = true;
            this.btn_sch.Click += new System.EventHandler(this.btn_sch_Click);
            // 
            // txb_kh
            // 
            this.txb_kh.Location = new System.Drawing.Point(216, 5);
            this.txb_kh.Name = "txb_kh";
            this.txb_kh.Size = new System.Drawing.Size(77, 21);
            this.txb_kh.TabIndex = 4;
            // 
            // txb_tm
            // 
            this.txb_tm.Location = new System.Drawing.Point(40, 5);
            this.txb_tm.Name = "txb_tm";
            this.txb_tm.Size = new System.Drawing.Size(135, 21);
            this.txb_tm.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "款号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "条码";
            // 
            // dp_end
            // 
            this.dp_end.Location = new System.Drawing.Point(794, 6);
            this.dp_end.Name = "dp_end";
            this.dp_end.Size = new System.Drawing.Size(106, 21);
            this.dp_end.TabIndex = 30;
            // 
            // dp_start
            // 
            this.dp_start.Location = new System.Drawing.Point(682, 4);
            this.dp_start.Name = "dp_start";
            this.dp_start.Size = new System.Drawing.Size(106, 21);
            this.dp_start.TabIndex = 29;
            // 
            // Form_Tiaomaxinxi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 498);
            this.Controls.Add(this.grid_tm);
            this.Controls.Add(this.panel3);
            this.Name = "Form_Tiaomaxinxi";
            this.Text = "条码信息";
            this.Load += new System.EventHandler(this.Form_Tiaomaxinxi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_tm)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid_tm;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_sch;
        private System.Windows.Forms.TextBox txb_kh;
        private System.Windows.Forms.TextBox txb_tm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_xzzdtm;
        private System.Windows.Forms.Button btn_xzzxtm;
        private System.Windows.Forms.ComboBox cmb_lx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gyskh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_lx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ys;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gxsj;
        private System.Windows.Forms.DateTimePicker dp_end;
        private System.Windows.Forms.DateTimePicker dp_start;
    }
}