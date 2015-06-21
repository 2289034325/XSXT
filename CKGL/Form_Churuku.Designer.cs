namespace CKGL
{
    partial class Form_Churuku
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_shangbao = new System.Windows.Forms.Button();
            this.dp_end = new System.Windows.Forms.DateTimePicker();
            this.dp_start = new System.Windows.Forms.DateTimePicker();
            this.btn_crk_ck = new System.Windows.Forms.Button();
            this.txb_id = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.btn_crk_rk = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_crk_cx = new System.Windows.Forms.Button();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.grid_crk = new System.Windows.Forms.DataGridView();
            this.col_crk_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_fx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_lyqx = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_crk_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_czr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_djsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_xgsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_sbsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_crkmx = new System.Windows.Forms.DataGridView();
            this.col_mx_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_tm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_ys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_sj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmn_crk = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmn_crk_daoru = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_crk_uplazy = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_crk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_crkmx)).BeginInit();
            this.cmn_crk.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_shangbao);
            this.panel1.Controls.Add(this.dp_end);
            this.panel1.Controls.Add(this.dp_start);
            this.panel1.Controls.Add(this.btn_crk_ck);
            this.panel1.Controls.Add(this.txb_id);
            this.panel1.Controls.Add(this.label38);
            this.panel1.Controls.Add(this.btn_crk_rk);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btn_crk_cx);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 32);
            this.panel1.TabIndex = 3;
            // 
            // btn_shangbao
            // 
            this.btn_shangbao.Location = new System.Drawing.Point(612, 3);
            this.btn_shangbao.Name = "btn_shangbao";
            this.btn_shangbao.Size = new System.Drawing.Size(75, 23);
            this.btn_shangbao.TabIndex = 26;
            this.btn_shangbao.Text = "上报数据";
            this.btn_shangbao.UseVisualStyleBackColor = true;
            this.btn_shangbao.Click += new System.EventHandler(this.btn_shangbao_Click);
            // 
            // dp_end
            // 
            this.dp_end.Location = new System.Drawing.Point(241, 4);
            this.dp_end.Name = "dp_end";
            this.dp_end.Size = new System.Drawing.Size(102, 21);
            this.dp_end.TabIndex = 25;
            // 
            // dp_start
            // 
            this.dp_start.Location = new System.Drawing.Point(133, 4);
            this.dp_start.Name = "dp_start";
            this.dp_start.Size = new System.Drawing.Size(102, 21);
            this.dp_start.TabIndex = 24;
            // 
            // btn_crk_ck
            // 
            this.btn_crk_ck.Location = new System.Drawing.Point(531, 3);
            this.btn_crk_ck.Name = "btn_crk_ck";
            this.btn_crk_ck.Size = new System.Drawing.Size(75, 23);
            this.btn_crk_ck.TabIndex = 23;
            this.btn_crk_ck.Text = "出库";
            this.btn_crk_ck.UseVisualStyleBackColor = true;
            this.btn_crk_ck.Click += new System.EventHandler(this.btn_crk_ck_Click);
            // 
            // txb_id
            // 
            this.txb_id.Location = new System.Drawing.Point(28, 4);
            this.txb_id.Name = "txb_id";
            this.txb_id.Size = new System.Drawing.Size(40, 21);
            this.txb_id.TabIndex = 20;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(5, 7);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(17, 12);
            this.label38.TabIndex = 19;
            this.label38.Text = "ID";
            // 
            // btn_crk_rk
            // 
            this.btn_crk_rk.Location = new System.Drawing.Point(450, 3);
            this.btn_crk_rk.Name = "btn_crk_rk";
            this.btn_crk_rk.Size = new System.Drawing.Size(75, 23);
            this.btn_crk_rk.TabIndex = 18;
            this.btn_crk_rk.Text = "入库";
            this.btn_crk_rk.UseVisualStyleBackColor = true;
            this.btn_crk_rk.Click += new System.EventHandler(this.btn_crk_rk_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(74, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "登记日期";
            // 
            // btn_crk_cx
            // 
            this.btn_crk_cx.Location = new System.Drawing.Point(369, 3);
            this.btn_crk_cx.Name = "btn_crk_cx";
            this.btn_crk_cx.Size = new System.Drawing.Size(75, 23);
            this.btn_crk_cx.TabIndex = 6;
            this.btn_crk_cx.Text = "查询";
            this.btn_crk_cx.UseVisualStyleBackColor = true;
            this.btn_crk_cx.Click += new System.EventHandler(this.btn_crk_cx_Click);
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 32);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.grid_crk);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.grid_crkmx);
            this.splitContainer5.Size = new System.Drawing.Size(1015, 458);
            this.splitContainer5.SplitterDistance = 174;
            this.splitContainer5.TabIndex = 6;
            // 
            // grid_crk
            // 
            this.grid_crk.AllowUserToAddRows = false;
            this.grid_crk.AllowUserToResizeRows = false;
            this.grid_crk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_crk.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_crk_id,
            this.col_crk_fx,
            this.col_crk_lyqx,
            this.col_crk_sl,
            this.col_crk_bz,
            this.col_crk_czr,
            this.col_crk_djsj,
            this.col_crk_xgsj,
            this.col_crk_sbsj});
            this.grid_crk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_crk.Location = new System.Drawing.Point(0, 0);
            this.grid_crk.MultiSelect = false;
            this.grid_crk.Name = "grid_crk";
            this.grid_crk.RowHeadersVisible = false;
            this.grid_crk.RowTemplate.Height = 23;
            this.grid_crk.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_crk.Size = new System.Drawing.Size(1015, 174);
            this.grid_crk.TabIndex = 1;
            this.grid_crk.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grid_crk_CellBeginEdit);
            this.grid_crk.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grid_crk_CellValidating);
            this.grid_crk.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_crk_CellValueChanged);
            this.grid_crk.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.grid_crk_RowStateChanged);
            this.grid_crk.SelectionChanged += new System.EventHandler(this.grid_crk_SelectionChanged);
            this.grid_crk.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_crk_UserDeletingRow);
            // 
            // col_crk_id
            // 
            this.col_crk_id.DataPropertyName = "id";
            this.col_crk_id.HeaderText = "ID";
            this.col_crk_id.Name = "col_crk_id";
            this.col_crk_id.ReadOnly = true;
            // 
            // col_crk_fx
            // 
            this.col_crk_fx.HeaderText = "方向";
            this.col_crk_fx.Name = "col_crk_fx";
            this.col_crk_fx.ReadOnly = true;
            this.col_crk_fx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // col_crk_lyqx
            // 
            this.col_crk_lyqx.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.col_crk_lyqx.HeaderText = "来源去向";
            this.col_crk_lyqx.Name = "col_crk_lyqx";
            this.col_crk_lyqx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_crk_lyqx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_crk_sl
            // 
            this.col_crk_sl.HeaderText = "数量";
            this.col_crk_sl.Name = "col_crk_sl";
            this.col_crk_sl.ReadOnly = true;
            // 
            // col_crk_bz
            // 
            this.col_crk_bz.HeaderText = "备注";
            this.col_crk_bz.Name = "col_crk_bz";
            // 
            // col_crk_czr
            // 
            this.col_crk_czr.HeaderText = "操作人";
            this.col_crk_czr.Name = "col_crk_czr";
            this.col_crk_czr.ReadOnly = true;
            // 
            // col_crk_djsj
            // 
            this.col_crk_djsj.HeaderText = "登记时间";
            this.col_crk_djsj.Name = "col_crk_djsj";
            this.col_crk_djsj.ReadOnly = true;
            // 
            // col_crk_xgsj
            // 
            this.col_crk_xgsj.HeaderText = "修改时间";
            this.col_crk_xgsj.Name = "col_crk_xgsj";
            this.col_crk_xgsj.ReadOnly = true;
            // 
            // col_crk_sbsj
            // 
            this.col_crk_sbsj.HeaderText = "上报时间";
            this.col_crk_sbsj.Name = "col_crk_sbsj";
            this.col_crk_sbsj.ReadOnly = true;
            // 
            // grid_crkmx
            // 
            this.grid_crkmx.AllowUserToAddRows = false;
            this.grid_crkmx.AllowUserToResizeRows = false;
            this.grid_crkmx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_crkmx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_mx_id,
            this.col_mx_tm,
            this.col_mx_kh,
            this.col_mx_pm,
            this.col_mx_ys,
            this.col_mx_cm,
            this.col_mx_sl,
            this.col_mx_sj});
            this.grid_crkmx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_crkmx.Location = new System.Drawing.Point(0, 0);
            this.grid_crkmx.MultiSelect = false;
            this.grid_crkmx.Name = "grid_crkmx";
            this.grid_crkmx.RowHeadersVisible = false;
            this.grid_crkmx.RowTemplate.Height = 23;
            this.grid_crkmx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_crkmx.Size = new System.Drawing.Size(1015, 280);
            this.grid_crkmx.TabIndex = 4;
            this.grid_crkmx.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grid_crkmx_CellBeginEdit);
            this.grid_crkmx.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grid_crkmx_CellValidating);
            this.grid_crkmx.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_crkmx_CellValueChanged);
            this.grid_crkmx.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_crkmx_UserDeletingRow);
            // 
            // col_mx_id
            // 
            this.col_mx_id.HeaderText = "ID";
            this.col_mx_id.Name = "col_mx_id";
            this.col_mx_id.ReadOnly = true;
            // 
            // col_mx_tm
            // 
            this.col_mx_tm.HeaderText = "条码";
            this.col_mx_tm.Name = "col_mx_tm";
            this.col_mx_tm.ReadOnly = true;
            // 
            // col_mx_kh
            // 
            this.col_mx_kh.HeaderText = "款号";
            this.col_mx_kh.Name = "col_mx_kh";
            this.col_mx_kh.ReadOnly = true;
            // 
            // col_mx_pm
            // 
            this.col_mx_pm.HeaderText = "品名";
            this.col_mx_pm.Name = "col_mx_pm";
            this.col_mx_pm.ReadOnly = true;
            // 
            // col_mx_ys
            // 
            this.col_mx_ys.HeaderText = "颜色";
            this.col_mx_ys.Name = "col_mx_ys";
            this.col_mx_ys.ReadOnly = true;
            // 
            // col_mx_cm
            // 
            this.col_mx_cm.HeaderText = "尺码";
            this.col_mx_cm.Name = "col_mx_cm";
            this.col_mx_cm.ReadOnly = true;
            // 
            // col_mx_sl
            // 
            this.col_mx_sl.HeaderText = "数量";
            this.col_mx_sl.Name = "col_mx_sl";
            // 
            // col_mx_sj
            // 
            this.col_mx_sj.HeaderText = "售价";
            this.col_mx_sj.Name = "col_mx_sj";
            this.col_mx_sj.ReadOnly = true;
            // 
            // cmn_crk
            // 
            this.cmn_crk.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmn_crk_daoru,
            this.cmn_crk_uplazy});
            this.cmn_crk.Name = "cmn_crk";
            this.cmn_crk.Size = new System.Drawing.Size(161, 48);
            // 
            // cmn_crk_daoru
            // 
            this.cmn_crk_daoru.Name = "cmn_crk_daoru";
            this.cmn_crk_daoru.Size = new System.Drawing.Size(160, 22);
            this.cmn_crk_daoru.Text = "从文件导入";
            this.cmn_crk_daoru.Click += new System.EventHandler(this.cmn_crk_daoru_Click);
            // 
            // cmn_crk_uplazy
            // 
            this.cmn_crk_uplazy.Name = "cmn_crk_uplazy";
            this.cmn_crk_uplazy.Size = new System.Drawing.Size(160, 22);
            this.cmn_crk_uplazy.Text = "上传让分店下载";
            this.cmn_crk_uplazy.Click += new System.EventHandler(this.cmn_crk_uplazy_Click);
            // 
            // Form_Churuku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 490);
            this.Controls.Add(this.splitContainer5);
            this.Controls.Add(this.panel1);
            this.Name = "Form_Churuku";
            this.Text = "出入库";
            this.Load += new System.EventHandler(this.Form_Churuku_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_crk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_crkmx)).EndInit();
            this.cmn_crk.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dp_end;
        private System.Windows.Forms.DateTimePicker dp_start;
        private System.Windows.Forms.Button btn_crk_ck;
        private System.Windows.Forms.TextBox txb_id;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button btn_crk_rk;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_crk_cx;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.DataGridView grid_crk;
        private System.Windows.Forms.DataGridView grid_crkmx;
        private System.Windows.Forms.ContextMenuStrip cmn_crk;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_daoru;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_tm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_ys;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_cm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_sj;
        private System.Windows.Forms.Button btn_shangbao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_fx;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_crk_lyqx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_bz;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_czr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_djsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_xgsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_sbsj;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_uplazy;
    }
}