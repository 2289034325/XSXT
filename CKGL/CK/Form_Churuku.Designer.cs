namespace CKGL.CK
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
            this.cmn_crk = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmn_crk_frombm = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_crk_daoru = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_crk_uplazy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_crk_xiugai = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_crk_qr = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_crk_qxqr = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.grid_crk = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label38 = new System.Windows.Forms.Label();
            this.cmb_jms = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dp_start = new System.Windows.Forms.DateTimePicker();
            this.dp_end = new System.Windows.Forms.DateTimePicker();
            this.btn_crk_cx = new System.Windows.Forms.Button();
            this.btn_crk_rk = new System.Windows.Forms.Button();
            this.grid_crkmx = new System.Windows.Forms.DataGridView();
            this.col_mx_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_tm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_ys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_sj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_zk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_dj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmn_crk_sb = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.撤销上报ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_crk_cxsb = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.col_crk_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_fx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_lyqx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_pcm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_jms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_zk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_je = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_qd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_czr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_djsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_xgsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crk_sbsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmn_crk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_crk)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_crkmx)).BeginInit();
            this.SuspendLayout();
            // 
            // cmn_crk
            // 
            this.cmn_crk.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmn_crk_xiugai,
            this.cmn_crk_qr,
            this.cmn_crk_qxqr,
            this.toolStripSeparator2,
            this.cmn_crk_frombm,
            this.cmn_crk_daoru,
            this.toolStripSeparator1,
            this.cmn_crk_sb,
            this.cmn_crk_cxsb,
            this.toolStripSeparator3,
            this.cmn_crk_uplazy});
            this.cmn_crk.Name = "cmn_crk";
            this.cmn_crk.Size = new System.Drawing.Size(161, 198);
            // 
            // cmn_crk_frombm
            // 
            this.cmn_crk_frombm.Name = "cmn_crk_frombm";
            this.cmn_crk_frombm.Size = new System.Drawing.Size(160, 22);
            this.cmn_crk_frombm.Text = "从编码窗口拉取";
            this.cmn_crk_frombm.Click += new System.EventHandler(this.cmn_crk_frombm_Click);
            // 
            // cmn_crk_daoru
            // 
            this.cmn_crk_daoru.Name = "cmn_crk_daoru";
            this.cmn_crk_daoru.Size = new System.Drawing.Size(160, 22);
            this.cmn_crk_daoru.Text = "输入多个条码";
            this.cmn_crk_daoru.Click += new System.EventHandler(this.cmn_crk_daoru_Click);
            // 
            // cmn_crk_uplazy
            // 
            this.cmn_crk_uplazy.Name = "cmn_crk_uplazy";
            this.cmn_crk_uplazy.Size = new System.Drawing.Size(160, 22);
            this.cmn_crk_uplazy.Text = "上传让分店下载";
            this.cmn_crk_uplazy.Click += new System.EventHandler(this.cmn_crk_uplazy_Click);
            // 
            // cmn_crk_xiugai
            // 
            this.cmn_crk_xiugai.Name = "cmn_crk_xiugai";
            this.cmn_crk_xiugai.Size = new System.Drawing.Size(160, 22);
            this.cmn_crk_xiugai.Text = "修改";
            this.cmn_crk_xiugai.Click += new System.EventHandler(this.cmn_crk_xiugai_Click);
            // 
            // cmn_crk_qr
            // 
            this.cmn_crk_qr.Name = "cmn_crk_qr";
            this.cmn_crk_qr.Size = new System.Drawing.Size(160, 22);
            this.cmn_crk_qr.Text = "确认数据";
            this.cmn_crk_qr.Click += new System.EventHandler(this.cmn_crk_qr_Click);
            // 
            // cmn_crk_qxqr
            // 
            this.cmn_crk_qxqr.Name = "cmn_crk_qxqr";
            this.cmn_crk_qxqr.Size = new System.Drawing.Size(160, 22);
            this.cmn_crk_qxqr.Text = "取消确认";
            this.cmn_crk_qxqr.Click += new System.EventHandler(this.cmn_crk_qxqr_Click);
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.grid_crk);
            this.splitContainer5.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.grid_crkmx);
            this.splitContainer5.Size = new System.Drawing.Size(1104, 490);
            this.splitContainer5.SplitterDistance = 186;
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
            this.col_crk_pcm,
            this.col_crk_jms,
            this.col_crk_sl,
            this.col_crk_zk,
            this.col_crk_je,
            this.col_crk_qd,
            this.col_crk_bz,
            this.col_crk_czr,
            this.col_crk_djsj,
            this.col_crk_xgsj,
            this.col_crk_sbsj});
            this.grid_crk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_crk.Location = new System.Drawing.Point(0, 29);
            this.grid_crk.MultiSelect = false;
            this.grid_crk.Name = "grid_crk";
            this.grid_crk.ReadOnly = true;
            this.grid_crk.RowHeadersVisible = false;
            this.grid_crk.RowTemplate.Height = 23;
            this.grid_crk.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_crk.Size = new System.Drawing.Size(1104, 157);
            this.grid_crk.TabIndex = 1;
            this.grid_crk.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grid_crk_CellBeginEdit);
            this.grid_crk.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grid_crk_CellValidating);
            this.grid_crk.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.grid_crk_RowStateChanged);
            this.grid_crk.SelectionChanged += new System.EventHandler(this.grid_crk_SelectionChanged);
            this.grid_crk.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_crk_UserDeletingRow);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label38);
            this.flowLayoutPanel1.Controls.Add(this.cmb_jms);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.dp_start);
            this.flowLayoutPanel1.Controls.Add(this.dp_end);
            this.flowLayoutPanel1.Controls.Add(this.btn_crk_cx);
            this.flowLayoutPanel1.Controls.Add(this.btn_crk_rk);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1104, 29);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label38
            // 
            this.label38.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(3, 8);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(41, 12);
            this.label38.TabIndex = 19;
            this.label38.Text = "加盟商";
            // 
            // cmb_jms
            // 
            this.cmb_jms.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmb_jms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_jms.FormattingEnabled = true;
            this.cmb_jms.Location = new System.Drawing.Point(50, 4);
            this.cmb_jms.Name = "cmb_jms";
            this.cmb_jms.Size = new System.Drawing.Size(77, 20);
            this.cmb_jms.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(133, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "登记日期";
            // 
            // dp_start
            // 
            this.dp_start.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dp_start.Location = new System.Drawing.Point(192, 4);
            this.dp_start.Name = "dp_start";
            this.dp_start.ShowCheckBox = true;
            this.dp_start.Size = new System.Drawing.Size(121, 21);
            this.dp_start.TabIndex = 24;
            // 
            // dp_end
            // 
            this.dp_end.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dp_end.Location = new System.Drawing.Point(319, 4);
            this.dp_end.Name = "dp_end";
            this.dp_end.ShowCheckBox = true;
            this.dp_end.Size = new System.Drawing.Size(121, 21);
            this.dp_end.TabIndex = 25;
            // 
            // btn_crk_cx
            // 
            this.btn_crk_cx.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_crk_cx.Location = new System.Drawing.Point(446, 3);
            this.btn_crk_cx.Name = "btn_crk_cx";
            this.btn_crk_cx.Size = new System.Drawing.Size(75, 23);
            this.btn_crk_cx.TabIndex = 6;
            this.btn_crk_cx.Text = "查询";
            this.btn_crk_cx.UseVisualStyleBackColor = true;
            this.btn_crk_cx.Click += new System.EventHandler(this.btn_crk_cx_Click);
            // 
            // btn_crk_rk
            // 
            this.btn_crk_rk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_crk_rk.Location = new System.Drawing.Point(527, 3);
            this.btn_crk_rk.Name = "btn_crk_rk";
            this.btn_crk_rk.Size = new System.Drawing.Size(75, 23);
            this.btn_crk_rk.TabIndex = 18;
            this.btn_crk_rk.Text = "增加记录";
            this.btn_crk_rk.UseVisualStyleBackColor = true;
            this.btn_crk_rk.Click += new System.EventHandler(this.btn_add_Click);
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
            this.col_mx_sj,
            this.col_mx_zk,
            this.col_mx_dj,
            this.col_mx_sl});
            this.grid_crkmx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_crkmx.Location = new System.Drawing.Point(0, 0);
            this.grid_crkmx.MultiSelect = false;
            this.grid_crkmx.Name = "grid_crkmx";
            this.grid_crkmx.RowTemplate.Height = 23;
            this.grid_crkmx.Size = new System.Drawing.Size(1104, 300);
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
            this.col_mx_id.Visible = false;
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
            // col_mx_sj
            // 
            this.col_mx_sj.HeaderText = "吊牌价";
            this.col_mx_sj.Name = "col_mx_sj";
            this.col_mx_sj.ReadOnly = true;
            // 
            // col_mx_zk
            // 
            this.col_mx_zk.HeaderText = "折扣";
            this.col_mx_zk.Name = "col_mx_zk";
            this.col_mx_zk.ReadOnly = true;
            // 
            // col_mx_dj
            // 
            this.col_mx_dj.HeaderText = "单价";
            this.col_mx_dj.Name = "col_mx_dj";
            // 
            // col_mx_sl
            // 
            this.col_mx_sl.HeaderText = "数量";
            this.col_mx_sl.Name = "col_mx_sl";
            // 
            // cmn_crk_sb
            // 
            this.cmn_crk_sb.Name = "cmn_crk_sb";
            this.cmn_crk_sb.Size = new System.Drawing.Size(160, 22);
            this.cmn_crk_sb.Text = "上报数据";
            this.cmn_crk_sb.Click += new System.EventHandler(this.cmn_crk_sb_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // 撤销上报ToolStripMenuItem
            // 
            this.撤销上报ToolStripMenuItem.Name = "撤销上报ToolStripMenuItem";
            this.撤销上报ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.撤销上报ToolStripMenuItem.Text = "撤销上报";
            // 
            // cmn_crk_cxsb
            // 
            this.cmn_crk_cxsb.Name = "cmn_crk_cxsb";
            this.cmn_crk_cxsb.Size = new System.Drawing.Size(160, 22);
            this.cmn_crk_cxsb.Text = "撤销上报";
            this.cmn_crk_cxsb.Click += new System.EventHandler(this.cmn_crk_cxsb_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // col_crk_id
            // 
            this.col_crk_id.HeaderText = "ID";
            this.col_crk_id.Name = "col_crk_id";
            this.col_crk_id.ReadOnly = true;
            this.col_crk_id.Visible = false;
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
            this.col_crk_lyqx.HeaderText = "来源去向";
            this.col_crk_lyqx.Name = "col_crk_lyqx";
            this.col_crk_lyqx.ReadOnly = true;
            this.col_crk_lyqx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // col_crk_pcm
            // 
            this.col_crk_pcm.HeaderText = "批次码";
            this.col_crk_pcm.Name = "col_crk_pcm";
            this.col_crk_pcm.ReadOnly = true;
            // 
            // col_crk_jms
            // 
            this.col_crk_jms.DataPropertyName = "id";
            this.col_crk_jms.HeaderText = "加盟商";
            this.col_crk_jms.Name = "col_crk_jms";
            this.col_crk_jms.ReadOnly = true;
            // 
            // col_crk_sl
            // 
            this.col_crk_sl.HeaderText = "数量";
            this.col_crk_sl.Name = "col_crk_sl";
            this.col_crk_sl.ReadOnly = true;
            // 
            // col_crk_zk
            // 
            this.col_crk_zk.HeaderText = "折扣";
            this.col_crk_zk.Name = "col_crk_zk";
            this.col_crk_zk.ReadOnly = true;
            // 
            // col_crk_je
            // 
            this.col_crk_je.HeaderText = "金额";
            this.col_crk_je.Name = "col_crk_je";
            this.col_crk_je.ReadOnly = true;
            // 
            // col_crk_qd
            // 
            this.col_crk_qd.HeaderText = "确认";
            this.col_crk_qd.Name = "col_crk_qd";
            this.col_crk_qd.ReadOnly = true;
            // 
            // col_crk_bz
            // 
            this.col_crk_bz.HeaderText = "备注";
            this.col_crk_bz.Name = "col_crk_bz";
            this.col_crk_bz.ReadOnly = true;
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
            // Form_Churuku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 490);
            this.Controls.Add(this.splitContainer5);
            this.Name = "Form_Churuku";
            this.Text = "仓库进出货";
            this.Load += new System.EventHandler(this.Form_Churuku_Load);
            this.cmn_crk.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_crk)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_crkmx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dp_end;
        private System.Windows.Forms.DateTimePicker dp_start;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button btn_crk_rk;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_crk_cx;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.DataGridView grid_crk;
        private System.Windows.Forms.DataGridView grid_crkmx;
        private System.Windows.Forms.ContextMenuStrip cmn_crk;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_daoru;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_uplazy;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_frombm;
        private System.Windows.Forms.ComboBox cmb_jms;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_xiugai;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_qr;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_qxqr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_tm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_ys;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_cm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_sj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_zk;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_dj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_sl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_sb;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_cxsb;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 撤销上报ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_fx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_lyqx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_pcm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_jms;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_zk;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_je;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_qd;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_bz;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_czr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_djsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_xgsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crk_sbsj;
    }
}