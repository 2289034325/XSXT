namespace FDXS
{
    partial class Form_Jinchuhuo
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
            this.btn_ch = new System.Windows.Forms.Button();
            this.txb_id = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.btn_jh = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_cx = new System.Windows.Forms.Button();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.grid_jch = new System.Windows.Forms.DataGridView();
            this.col_jc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_fx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_lyqx = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_jc_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_czr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_djsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_xgsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_sbsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_jcmx = new System.Windows.Forms.DataGridView();
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_jch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_jcmx)).BeginInit();
            this.cmn_crk.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_shangbao);
            this.panel1.Controls.Add(this.dp_end);
            this.panel1.Controls.Add(this.dp_start);
            this.panel1.Controls.Add(this.btn_ch);
            this.panel1.Controls.Add(this.txb_id);
            this.panel1.Controls.Add(this.label38);
            this.panel1.Controls.Add(this.btn_jh);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btn_cx);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 32);
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
            // btn_ch
            // 
            this.btn_ch.Location = new System.Drawing.Point(531, 3);
            this.btn_ch.Name = "btn_ch";
            this.btn_ch.Size = new System.Drawing.Size(75, 23);
            this.btn_ch.TabIndex = 23;
            this.btn_ch.Text = "出货";
            this.btn_ch.UseVisualStyleBackColor = true;
            this.btn_ch.Click += new System.EventHandler(this.btn_ch_Click);
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
            // btn_jh
            // 
            this.btn_jh.Location = new System.Drawing.Point(450, 3);
            this.btn_jh.Name = "btn_jh";
            this.btn_jh.Size = new System.Drawing.Size(75, 23);
            this.btn_jh.TabIndex = 18;
            this.btn_jh.Text = "进货";
            this.btn_jh.UseVisualStyleBackColor = true;
            this.btn_jh.Click += new System.EventHandler(this.btn_jh_Click);
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
            // btn_cx
            // 
            this.btn_cx.Location = new System.Drawing.Point(369, 3);
            this.btn_cx.Name = "btn_cx";
            this.btn_cx.Size = new System.Drawing.Size(75, 23);
            this.btn_cx.TabIndex = 6;
            this.btn_cx.Text = "查询";
            this.btn_cx.UseVisualStyleBackColor = true;
            this.btn_cx.Click += new System.EventHandler(this.btn_cx_Click);
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
            this.splitContainer5.Panel1.Controls.Add(this.grid_jch);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.grid_jcmx);
            this.splitContainer5.Size = new System.Drawing.Size(905, 458);
            this.splitContainer5.SplitterDistance = 174;
            this.splitContainer5.TabIndex = 6;
            // 
            // grid_jch
            // 
            this.grid_jch.AllowUserToAddRows = false;
            this.grid_jch.AllowUserToResizeRows = false;
            this.grid_jch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_jch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_jc_id,
            this.col_jc_fx,
            this.col_jc_lyqx,
            this.col_jc_sl,
            this.col_jc_bz,
            this.col_jc_czr,
            this.col_jc_djsj,
            this.col_jc_xgsj,
            this.col_jc_sbsj});
            this.grid_jch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_jch.Location = new System.Drawing.Point(0, 0);
            this.grid_jch.MultiSelect = false;
            this.grid_jch.Name = "grid_jch";
            this.grid_jch.RowHeadersVisible = false;
            this.grid_jch.RowTemplate.Height = 23;
            this.grid_jch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_jch.Size = new System.Drawing.Size(905, 174);
            this.grid_jch.TabIndex = 1;
            this.grid_jch.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grid_crk_CellBeginEdit);
            this.grid_jch.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grid_crk_CellValidating);
            this.grid_jch.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_crk_CellValueChanged);
            this.grid_jch.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.grid_crk_RowStateChanged);
            this.grid_jch.SelectionChanged += new System.EventHandler(this.grid_crk_SelectionChanged);
            this.grid_jch.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_crk_UserDeletingRow);
            // 
            // col_jc_id
            // 
            this.col_jc_id.DataPropertyName = "id";
            this.col_jc_id.HeaderText = "ID";
            this.col_jc_id.Name = "col_jc_id";
            this.col_jc_id.ReadOnly = true;
            // 
            // col_jc_fx
            // 
            this.col_jc_fx.HeaderText = "方向";
            this.col_jc_fx.Name = "col_jc_fx";
            this.col_jc_fx.ReadOnly = true;
            // 
            // col_jc_lyqx
            // 
            this.col_jc_lyqx.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.col_jc_lyqx.HeaderText = "来源去向";
            this.col_jc_lyqx.Name = "col_jc_lyqx";
            this.col_jc_lyqx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_jc_lyqx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_jc_sl
            // 
            this.col_jc_sl.HeaderText = "数量";
            this.col_jc_sl.Name = "col_jc_sl";
            this.col_jc_sl.ReadOnly = true;
            // 
            // col_jc_bz
            // 
            this.col_jc_bz.HeaderText = "备注";
            this.col_jc_bz.Name = "col_jc_bz";
            // 
            // col_jc_czr
            // 
            this.col_jc_czr.HeaderText = "操作人";
            this.col_jc_czr.Name = "col_jc_czr";
            this.col_jc_czr.ReadOnly = true;
            // 
            // col_jc_djsj
            // 
            this.col_jc_djsj.HeaderText = "登记时间";
            this.col_jc_djsj.Name = "col_jc_djsj";
            this.col_jc_djsj.ReadOnly = true;
            // 
            // col_jc_xgsj
            // 
            this.col_jc_xgsj.HeaderText = "修改时间";
            this.col_jc_xgsj.Name = "col_jc_xgsj";
            this.col_jc_xgsj.ReadOnly = true;
            // 
            // col_jc_sbsj
            // 
            this.col_jc_sbsj.HeaderText = "上报时间";
            this.col_jc_sbsj.Name = "col_jc_sbsj";
            this.col_jc_sbsj.ReadOnly = true;
            // 
            // grid_jcmx
            // 
            this.grid_jcmx.AllowUserToAddRows = false;
            this.grid_jcmx.AllowUserToResizeRows = false;
            this.grid_jcmx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_jcmx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_mx_id,
            this.col_mx_tm,
            this.col_mx_kh,
            this.col_mx_pm,
            this.col_mx_ys,
            this.col_mx_cm,
            this.col_mx_sl,
            this.col_mx_sj});
            this.grid_jcmx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_jcmx.Location = new System.Drawing.Point(0, 0);
            this.grid_jcmx.MultiSelect = false;
            this.grid_jcmx.Name = "grid_jcmx";
            this.grid_jcmx.RowHeadersVisible = false;
            this.grid_jcmx.RowTemplate.Height = 23;
            this.grid_jcmx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_jcmx.Size = new System.Drawing.Size(905, 280);
            this.grid_jcmx.TabIndex = 4;
            this.grid_jcmx.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grid_crkmx_CellBeginEdit);
            this.grid_jcmx.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grid_crkmx_CellValidating);
            this.grid_jcmx.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_crkmx_CellValueChanged);
            this.grid_jcmx.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_crkmx_UserDeletingRow);
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
            this.cmn_crk_daoru});
            this.cmn_crk.Name = "cmn_crk";
            this.cmn_crk.Size = new System.Drawing.Size(137, 26);
            // 
            // cmn_crk_daoru
            // 
            this.cmn_crk_daoru.Name = "cmn_crk_daoru";
            this.cmn_crk_daoru.Size = new System.Drawing.Size(136, 22);
            this.cmn_crk_daoru.Text = "从文件导入";
            this.cmn_crk_daoru.Click += new System.EventHandler(this.cmn_crk_daoru_Click);
            // 
            // Form_Jinchuhuo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 490);
            this.Controls.Add(this.splitContainer5);
            this.Controls.Add(this.panel1);
            this.Name = "Form_Jinchuhuo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "进出货";
            this.Load += new System.EventHandler(this.Form_Jinchuhuo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_jch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_jcmx)).EndInit();
            this.cmn_crk.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dp_end;
        private System.Windows.Forms.DateTimePicker dp_start;
        private System.Windows.Forms.Button btn_ch;
        private System.Windows.Forms.TextBox txb_id;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button btn_jh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_cx;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.DataGridView grid_jch;
        private System.Windows.Forms.DataGridView grid_jcmx;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_fx;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_jc_lyqx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_bz;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_czr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_djsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_xgsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_sbsj;
    }
}