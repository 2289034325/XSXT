using MyFormControls;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmn_crk = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmn_crk_xg = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_crk_queren = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_crk_queren_quxiao = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmn_crk_daoru = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmn_crk_sbsj = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_crk_cxsb = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.grid_jch = new MyFormControls.MyGrid();
            this.grid_jcmx = new MyFormControls.MyGrid();
            this.col_mx_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_tm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_ys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_dj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label38 = new MyFormControls.MyLabel();
            this.txb_tm = new MyFormControls.MyTextBox();
            this.label9 = new MyFormControls.MyLabel();
            this.dp_start = new MyFormControls.MyDateTimePicker();
            this.dp_end = new MyFormControls.MyDateTimePicker();
            this.btn_cx = new MyFormControls.MyButton();
            this.btn_jh = new MyFormControls.MyButton();
            this.btn_xzjinhuo = new MyFormControls.MyButton();
            this.col_jc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_fx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_lyqx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_pcm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_je = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_qr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_czr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_djsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_xgsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_sbsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmn_crk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_jch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_jcmx)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmn_crk
            // 
            this.cmn_crk.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmn_crk_xg,
            this.cmn_crk_queren,
            this.cmn_crk_queren_quxiao,
            this.toolStripSeparator1,
            this.cmn_crk_daoru,
            this.toolStripSeparator2,
            this.cmn_crk_sbsj,
            this.cmn_crk_cxsb});
            this.cmn_crk.Name = "cmn_crk";
            this.cmn_crk.Size = new System.Drawing.Size(137, 148);
            // 
            // cmn_crk_xg
            // 
            this.cmn_crk_xg.Name = "cmn_crk_xg";
            this.cmn_crk_xg.Size = new System.Drawing.Size(136, 22);
            this.cmn_crk_xg.Text = "修改";
            this.cmn_crk_xg.Click += new System.EventHandler(this.cmn_crk_xg_Click);
            // 
            // cmn_crk_queren
            // 
            this.cmn_crk_queren.Name = "cmn_crk_queren";
            this.cmn_crk_queren.Size = new System.Drawing.Size(136, 22);
            this.cmn_crk_queren.Text = "进出货确认";
            this.cmn_crk_queren.Click += new System.EventHandler(this.cmn_crk_queren_Click);
            // 
            // cmn_crk_queren_quxiao
            // 
            this.cmn_crk_queren_quxiao.Name = "cmn_crk_queren_quxiao";
            this.cmn_crk_queren_quxiao.Size = new System.Drawing.Size(136, 22);
            this.cmn_crk_queren_quxiao.Text = "取消确认";
            this.cmn_crk_queren_quxiao.Click += new System.EventHandler(this.cmn_crk_queren_quxiao_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // cmn_crk_daoru
            // 
            this.cmn_crk_daoru.Name = "cmn_crk_daoru";
            this.cmn_crk_daoru.Size = new System.Drawing.Size(136, 22);
            this.cmn_crk_daoru.Text = "输入条码";
            this.cmn_crk_daoru.Click += new System.EventHandler(this.cmn_crk_daoru_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(133, 6);
            // 
            // cmn_crk_sbsj
            // 
            this.cmn_crk_sbsj.Name = "cmn_crk_sbsj";
            this.cmn_crk_sbsj.Size = new System.Drawing.Size(136, 22);
            this.cmn_crk_sbsj.Text = "上报数据";
            this.cmn_crk_sbsj.Click += new System.EventHandler(this.cmn_crk_sbsj_Click);
            // 
            // cmn_crk_cxsb
            // 
            this.cmn_crk_cxsb.Name = "cmn_crk_cxsb";
            this.cmn_crk_cxsb.Size = new System.Drawing.Size(136, 22);
            this.cmn_crk_cxsb.Text = "撤销上报";
            this.cmn_crk_cxsb.Click += new System.EventHandler(this.cmn_crk_cxsb_Click);
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 30);
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
            this.splitContainer5.Size = new System.Drawing.Size(1153, 460);
            this.splitContainer5.SplitterDistance = 174;
            this.splitContainer5.TabIndex = 6;
            // 
            // grid_jch
            // 
            this.grid_jch.AllowUserToAddRows = false;
            this.grid_jch.AllowUserToResizeRows = false;
            this.grid_jch.BackgroundColor = System.Drawing.Color.Black;
            this.grid_jch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_jch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_jch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_jch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_jch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_jc_id,
            this.col_jc_fx,
            this.col_jc_lyqx,
            this.col_jc_pcm,
            this.col_jc_sl,
            this.col_jc_je,
            this.col_jc_qr,
            this.col_jc_bz,
            this.col_jc_czr,
            this.col_jc_djsj,
            this.col_jc_xgsj,
            this.col_jc_sbsj});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_jch.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_jch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_jch.EnableHeadersVisualStyles = false;
            this.grid_jch.Location = new System.Drawing.Point(0, 0);
            this.grid_jch.MultiSelect = false;
            this.grid_jch.Name = "grid_jch";
            this.grid_jch.ReadOnly = true;
            this.grid_jch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grid_jch.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_jch.RowHeadersVisible = false;
            this.grid_jch.RowTemplate.Height = 23;
            this.grid_jch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_jch.Size = new System.Drawing.Size(1153, 174);
            this.grid_jch.TabIndex = 1;
            this.grid_jch.Type = MyFormControls.MyControlType.Standard;
            this.grid_jch.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_crk_CellValueChanged);
            this.grid_jch.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.grid_crk_RowStateChanged);
            this.grid_jch.SelectionChanged += new System.EventHandler(this.grid_crk_SelectionChanged);
            this.grid_jch.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_crk_UserDeletingRow);
            // 
            // grid_jcmx
            // 
            this.grid_jcmx.AllowUserToAddRows = false;
            this.grid_jcmx.AllowUserToResizeRows = false;
            this.grid_jcmx.BackgroundColor = System.Drawing.Color.Black;
            this.grid_jcmx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_jcmx.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_jcmx.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grid_jcmx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_jcmx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_mx_id,
            this.col_mx_tm,
            this.col_mx_kh,
            this.col_mx_pm,
            this.col_mx_ys,
            this.col_mx_cm,
            this.col_mx_sl,
            this.col_mx_dj});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_jcmx.DefaultCellStyle = dataGridViewCellStyle5;
            this.grid_jcmx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_jcmx.EnableHeadersVisualStyles = false;
            this.grid_jcmx.Location = new System.Drawing.Point(0, 0);
            this.grid_jcmx.MultiSelect = false;
            this.grid_jcmx.Name = "grid_jcmx";
            this.grid_jcmx.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grid_jcmx.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grid_jcmx.RowTemplate.Height = 23;
            this.grid_jcmx.Size = new System.Drawing.Size(1153, 282);
            this.grid_jcmx.TabIndex = 4;
            this.grid_jcmx.Type = MyFormControls.MyControlType.Standard;
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
            this.col_mx_id.Visible = false;
            this.col_mx_id.Width = 80;
            // 
            // col_mx_tm
            // 
            this.col_mx_tm.HeaderText = "条码";
            this.col_mx_tm.Name = "col_mx_tm";
            this.col_mx_tm.ReadOnly = true;
            this.col_mx_tm.Width = 120;
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
            this.col_mx_pm.Width = 120;
            // 
            // col_mx_ys
            // 
            this.col_mx_ys.HeaderText = "颜色";
            this.col_mx_ys.Name = "col_mx_ys";
            this.col_mx_ys.ReadOnly = true;
            this.col_mx_ys.Width = 80;
            // 
            // col_mx_cm
            // 
            this.col_mx_cm.HeaderText = "尺码";
            this.col_mx_cm.Name = "col_mx_cm";
            this.col_mx_cm.ReadOnly = true;
            this.col_mx_cm.Width = 80;
            // 
            // col_mx_sl
            // 
            this.col_mx_sl.HeaderText = "数量";
            this.col_mx_sl.Name = "col_mx_sl";
            this.col_mx_sl.Width = 80;
            // 
            // col_mx_dj
            // 
            this.col_mx_dj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_mx_dj.HeaderText = "单价";
            this.col_mx_dj.Name = "col_mx_dj";
            this.col_mx_dj.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label38);
            this.flowLayoutPanel1.Controls.Add(this.txb_tm);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.dp_start);
            this.flowLayoutPanel1.Controls.Add(this.dp_end);
            this.flowLayoutPanel1.Controls.Add(this.btn_cx);
            this.flowLayoutPanel1.Controls.Add(this.btn_jh);
            this.flowLayoutPanel1.Controls.Add(this.btn_xzjinhuo);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1153, 30);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label38
            // 
            this.label38.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Black;
            this.label38.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label38.ForeColor = System.Drawing.Color.White;
            this.label38.Location = new System.Drawing.Point(3, 6);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(51, 20);
            this.label38.TabIndex = 19;
            this.label38.Text = "条码";
            this.label38.Type = MyFormControls.MyControlType.Standard;
            // 
            // txb_tm
            // 
            this.txb_tm.BackColor = System.Drawing.Color.Black;
            this.txb_tm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_tm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_tm.ForeColor = System.Drawing.Color.White;
            this.txb_tm.Location = new System.Drawing.Point(60, 3);
            this.txb_tm.Name = "txb_tm";
            this.txb_tm.Size = new System.Drawing.Size(100, 26);
            this.txb_tm.TabIndex = 20;
            this.txb_tm.Type = MyFormControls.MyControlType.Standard;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(166, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "登记日期";
            this.label9.Type = MyFormControls.MyControlType.Standard;
            // 
            // dp_start
            // 
            this.dp_start.Font = new System.Drawing.Font("宋体", 12F);
            this.dp_start.Location = new System.Drawing.Point(265, 3);
            this.dp_start.Name = "dp_start";
            this.dp_start.ShowCheckBox = true;
            this.dp_start.Size = new System.Drawing.Size(155, 26);
            this.dp_start.TabIndex = 24;
            this.dp_start.Type = MyFormControls.MyControlType.Special;
            // 
            // dp_end
            // 
            this.dp_end.Font = new System.Drawing.Font("宋体", 12F);
            this.dp_end.Location = new System.Drawing.Point(426, 3);
            this.dp_end.Name = "dp_end";
            this.dp_end.ShowCheckBox = true;
            this.dp_end.Size = new System.Drawing.Size(155, 26);
            this.dp_end.TabIndex = 25;
            this.dp_end.Type = MyFormControls.MyControlType.Special;
            // 
            // btn_cx
            // 
            this.btn_cx.BackColor = System.Drawing.Color.Black;
            this.btn_cx.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_cx.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_cx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cx.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_cx.ForeColor = System.Drawing.Color.White;
            this.btn_cx.Location = new System.Drawing.Point(587, 3);
            this.btn_cx.Name = "btn_cx";
            this.btn_cx.Size = new System.Drawing.Size(60, 26);
            this.btn_cx.TabIndex = 6;
            this.btn_cx.Text = "查询";
            this.btn_cx.Type = MyFormControls.MyControlType.Special;
            this.btn_cx.UseVisualStyleBackColor = false;
            this.btn_cx.Click += new System.EventHandler(this.btn_cx_Click);
            // 
            // btn_jh
            // 
            this.btn_jh.BackColor = System.Drawing.Color.Black;
            this.btn_jh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_jh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_jh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_jh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_jh.ForeColor = System.Drawing.Color.White;
            this.btn_jh.Location = new System.Drawing.Point(653, 3);
            this.btn_jh.Name = "btn_jh";
            this.btn_jh.Size = new System.Drawing.Size(71, 26);
            this.btn_jh.TabIndex = 18;
            this.btn_jh.Text = "进出货";
            this.btn_jh.Type = MyFormControls.MyControlType.Special;
            this.btn_jh.UseVisualStyleBackColor = false;
            this.btn_jh.Click += new System.EventHandler(this.btn_jh_Click);
            // 
            // btn_xzjinhuo
            // 
            this.btn_xzjinhuo.BackColor = System.Drawing.Color.Black;
            this.btn_xzjinhuo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_xzjinhuo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_xzjinhuo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xzjinhuo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_xzjinhuo.ForeColor = System.Drawing.Color.White;
            this.btn_xzjinhuo.Location = new System.Drawing.Point(730, 3);
            this.btn_xzjinhuo.Name = "btn_xzjinhuo";
            this.btn_xzjinhuo.Size = new System.Drawing.Size(140, 26);
            this.btn_xzjinhuo.TabIndex = 27;
            this.btn_xzjinhuo.Text = "下载进货数据";
            this.btn_xzjinhuo.Type = MyFormControls.MyControlType.Special;
            this.btn_xzjinhuo.UseVisualStyleBackColor = false;
            this.btn_xzjinhuo.Click += new System.EventHandler(this.btn_xzjinhuo_Click);
            // 
            // col_jc_id
            // 
            this.col_jc_id.DataPropertyName = "id";
            this.col_jc_id.HeaderText = "ID";
            this.col_jc_id.Name = "col_jc_id";
            this.col_jc_id.ReadOnly = true;
            this.col_jc_id.Visible = false;
            this.col_jc_id.Width = 80;
            // 
            // col_jc_fx
            // 
            this.col_jc_fx.HeaderText = "方向";
            this.col_jc_fx.Name = "col_jc_fx";
            this.col_jc_fx.ReadOnly = true;
            this.col_jc_fx.Width = 80;
            // 
            // col_jc_lyqx
            // 
            this.col_jc_lyqx.HeaderText = "来源去向";
            this.col_jc_lyqx.Name = "col_jc_lyqx";
            this.col_jc_lyqx.ReadOnly = true;
            this.col_jc_lyqx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_jc_lyqx.Width = 120;
            // 
            // col_jc_pcm
            // 
            this.col_jc_pcm.HeaderText = "批次码";
            this.col_jc_pcm.Name = "col_jc_pcm";
            this.col_jc_pcm.ReadOnly = true;
            // 
            // col_jc_sl
            // 
            this.col_jc_sl.HeaderText = "数量";
            this.col_jc_sl.Name = "col_jc_sl";
            this.col_jc_sl.ReadOnly = true;
            this.col_jc_sl.Width = 80;
            // 
            // col_jc_je
            // 
            this.col_jc_je.HeaderText = "金额";
            this.col_jc_je.Name = "col_jc_je";
            this.col_jc_je.ReadOnly = true;
            this.col_jc_je.Width = 80;
            // 
            // col_jc_qr
            // 
            this.col_jc_qr.HeaderText = "确认";
            this.col_jc_qr.Name = "col_jc_qr";
            this.col_jc_qr.ReadOnly = true;
            this.col_jc_qr.Width = 80;
            // 
            // col_jc_bz
            // 
            this.col_jc_bz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_jc_bz.HeaderText = "备注";
            this.col_jc_bz.Name = "col_jc_bz";
            this.col_jc_bz.ReadOnly = true;
            // 
            // col_jc_czr
            // 
            this.col_jc_czr.HeaderText = "操作人";
            this.col_jc_czr.Name = "col_jc_czr";
            this.col_jc_czr.ReadOnly = true;
            this.col_jc_czr.Width = 110;
            // 
            // col_jc_djsj
            // 
            this.col_jc_djsj.HeaderText = "登记时间";
            this.col_jc_djsj.Name = "col_jc_djsj";
            this.col_jc_djsj.ReadOnly = true;
            this.col_jc_djsj.Width = 120;
            // 
            // col_jc_xgsj
            // 
            this.col_jc_xgsj.HeaderText = "修改时间";
            this.col_jc_xgsj.Name = "col_jc_xgsj";
            this.col_jc_xgsj.ReadOnly = true;
            this.col_jc_xgsj.Width = 120;
            // 
            // col_jc_sbsj
            // 
            this.col_jc_sbsj.HeaderText = "上报时间";
            this.col_jc_sbsj.Name = "col_jc_sbsj";
            this.col_jc_sbsj.ReadOnly = true;
            this.col_jc_sbsj.Width = 120;
            // 
            // Form_Jinchuhuo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 490);
            this.Controls.Add(this.splitContainer5);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form_Jinchuhuo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "进出货";
            this.Load += new System.EventHandler(this.Form_Jinchuhuo_Load);
            this.cmn_crk.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_jch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_jcmx)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyDateTimePicker dp_end;
        private MyDateTimePicker dp_start;
        private MyTextBox txb_tm;
        private MyLabel label38;
        private MyButton btn_jh;
        private MyLabel label9;
        private MyButton btn_cx;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private MyGrid grid_jch;
        private MyGrid grid_jcmx;
        private System.Windows.Forms.ContextMenuStrip cmn_crk;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_daoru;
        private MyButton btn_xzjinhuo;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_cxsb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_queren;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_queren_quxiao;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_tm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_ys;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_cm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_dj;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_xg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_sbsj;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_fx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_lyqx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_pcm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_je;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_qr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_bz;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_czr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_djsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_xgsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_sbsj;
    }
}