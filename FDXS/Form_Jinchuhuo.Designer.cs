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
            this.cmn_crk_daoru = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_crk_cxsb = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.grid_jch = new MyFormControls.MyGrid();
            this.grid_jcmx = new MyFormControls.MyGrid();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label38 = new MyFormControls.MyLabel();
            this.txb_id = new MyFormControls.MyTextBox();
            this.label9 = new MyFormControls.MyLabel();
            this.dp_start = new MyFormControls.MyDateTimePicker();
            this.dp_end = new MyFormControls.MyDateTimePicker();
            this.btn_cx = new MyFormControls.MyButton();
            this.btn_jh = new MyFormControls.MyButton();
            this.btn_ch = new MyFormControls.MyButton();
            this.btn_shangbao = new MyFormControls.MyButton();
            this.btn_xzjinhuo = new MyFormControls.MyButton();
            this.col_jc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_fx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_lyqx = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_jc_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_jj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_sj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_czr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_djsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_xgsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jc_sbsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_tm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_ys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_jj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mx_sj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmn_crk_mail = new System.Windows.Forms.ToolStripMenuItem();
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
            this.cmn_crk_daoru,
            this.cmn_crk_cxsb,
            this.cmn_crk_mail});
            this.cmn_crk.Name = "cmn_crk";
            this.cmn_crk.Size = new System.Drawing.Size(153, 92);
            // 
            // cmn_crk_daoru
            // 
            this.cmn_crk_daoru.Name = "cmn_crk_daoru";
            this.cmn_crk_daoru.Size = new System.Drawing.Size(152, 22);
            this.cmn_crk_daoru.Text = "批量输入";
            this.cmn_crk_daoru.Click += new System.EventHandler(this.cmn_crk_daoru_Click);
            // 
            // cmn_crk_cxsb
            // 
            this.cmn_crk_cxsb.Name = "cmn_crk_cxsb";
            this.cmn_crk_cxsb.Size = new System.Drawing.Size(152, 22);
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
            this.splitContainer5.Size = new System.Drawing.Size(1082, 460);
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
            this.col_jc_sl,
            this.col_jc_jj,
            this.col_jc_sj,
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
            this.grid_jch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grid_jch.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_jch.RowHeadersVisible = false;
            this.grid_jch.RowTemplate.Height = 23;
            this.grid_jch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_jch.Size = new System.Drawing.Size(1082, 174);
            this.grid_jch.TabIndex = 1;
            this.grid_jch.Type = MyFormControls.MyControlType.Standard;
            this.grid_jch.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grid_crk_CellBeginEdit);
            this.grid_jch.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grid_crk_CellValidating);
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
            this.col_mx_jj,
            this.col_mx_sj});
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
            this.grid_jcmx.Size = new System.Drawing.Size(1082, 282);
            this.grid_jcmx.TabIndex = 4;
            this.grid_jcmx.Type = MyFormControls.MyControlType.Standard;
            this.grid_jcmx.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grid_crkmx_CellBeginEdit);
            this.grid_jcmx.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grid_crkmx_CellValidating);
            this.grid_jcmx.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_crkmx_CellValueChanged);
            this.grid_jcmx.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_crkmx_UserDeletingRow);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label38);
            this.flowLayoutPanel1.Controls.Add(this.txb_id);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.dp_start);
            this.flowLayoutPanel1.Controls.Add(this.dp_end);
            this.flowLayoutPanel1.Controls.Add(this.btn_cx);
            this.flowLayoutPanel1.Controls.Add(this.btn_jh);
            this.flowLayoutPanel1.Controls.Add(this.btn_ch);
            this.flowLayoutPanel1.Controls.Add(this.btn_shangbao);
            this.flowLayoutPanel1.Controls.Add(this.btn_xzjinhuo);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1082, 30);
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
            this.label38.Size = new System.Drawing.Size(31, 20);
            this.label38.TabIndex = 19;
            this.label38.Text = "ID";
            this.label38.Type = MyFormControls.MyControlType.Standard;
            // 
            // txb_id
            // 
            this.txb_id.BackColor = System.Drawing.Color.Black;
            this.txb_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_id.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_id.ForeColor = System.Drawing.Color.White;
            this.txb_id.Location = new System.Drawing.Point(40, 3);
            this.txb_id.Name = "txb_id";
            this.txb_id.Size = new System.Drawing.Size(100, 26);
            this.txb_id.TabIndex = 20;
            this.txb_id.Type = MyFormControls.MyControlType.Standard;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(146, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "登记日期";
            this.label9.Type = MyFormControls.MyControlType.Standard;
            // 
            // dp_start
            // 
            this.dp_start.Font = new System.Drawing.Font("宋体", 12F);
            this.dp_start.Location = new System.Drawing.Point(245, 3);
            this.dp_start.Name = "dp_start";
            this.dp_start.Size = new System.Drawing.Size(133, 26);
            this.dp_start.TabIndex = 24;
            this.dp_start.Type = MyFormControls.MyControlType.Special;
            // 
            // dp_end
            // 
            this.dp_end.Font = new System.Drawing.Font("宋体", 12F);
            this.dp_end.Location = new System.Drawing.Point(384, 3);
            this.dp_end.Name = "dp_end";
            this.dp_end.Size = new System.Drawing.Size(131, 26);
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
            this.btn_cx.Location = new System.Drawing.Point(521, 3);
            this.btn_cx.Name = "btn_cx";
            this.btn_cx.Size = new System.Drawing.Size(100, 26);
            this.btn_cx.TabIndex = 6;
            this.btn_cx.Text = "查询";
            this.btn_cx.Type = MyFormControls.MyControlType.Standard;
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
            this.btn_jh.Location = new System.Drawing.Point(627, 3);
            this.btn_jh.Name = "btn_jh";
            this.btn_jh.Size = new System.Drawing.Size(60, 26);
            this.btn_jh.TabIndex = 18;
            this.btn_jh.Text = "进货";
            this.btn_jh.Type = MyFormControls.MyControlType.Special;
            this.btn_jh.UseVisualStyleBackColor = false;
            this.btn_jh.Click += new System.EventHandler(this.btn_jh_Click);
            // 
            // btn_ch
            // 
            this.btn_ch.BackColor = System.Drawing.Color.Black;
            this.btn_ch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_ch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_ch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_ch.ForeColor = System.Drawing.Color.White;
            this.btn_ch.Location = new System.Drawing.Point(693, 3);
            this.btn_ch.Name = "btn_ch";
            this.btn_ch.Size = new System.Drawing.Size(60, 26);
            this.btn_ch.TabIndex = 23;
            this.btn_ch.Text = "出货";
            this.btn_ch.Type = MyFormControls.MyControlType.Special;
            this.btn_ch.UseVisualStyleBackColor = false;
            this.btn_ch.Click += new System.EventHandler(this.btn_ch_Click);
            // 
            // btn_shangbao
            // 
            this.btn_shangbao.BackColor = System.Drawing.Color.Black;
            this.btn_shangbao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_shangbao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_shangbao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_shangbao.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_shangbao.ForeColor = System.Drawing.Color.White;
            this.btn_shangbao.Location = new System.Drawing.Point(759, 3);
            this.btn_shangbao.Name = "btn_shangbao";
            this.btn_shangbao.Size = new System.Drawing.Size(100, 26);
            this.btn_shangbao.TabIndex = 26;
            this.btn_shangbao.Text = "上报进出货数据";
            this.btn_shangbao.Type = MyFormControls.MyControlType.Standard;
            this.btn_shangbao.UseVisualStyleBackColor = false;
            this.btn_shangbao.Click += new System.EventHandler(this.btn_shangbao_Click);
            // 
            // btn_xzjinhuo
            // 
            this.btn_xzjinhuo.BackColor = System.Drawing.Color.Black;
            this.btn_xzjinhuo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_xzjinhuo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_xzjinhuo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xzjinhuo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_xzjinhuo.ForeColor = System.Drawing.Color.White;
            this.btn_xzjinhuo.Location = new System.Drawing.Point(865, 3);
            this.btn_xzjinhuo.Name = "btn_xzjinhuo";
            this.btn_xzjinhuo.Size = new System.Drawing.Size(100, 26);
            this.btn_xzjinhuo.TabIndex = 27;
            this.btn_xzjinhuo.Text = "下载进货数据";
            this.btn_xzjinhuo.Type = MyFormControls.MyControlType.Standard;
            this.btn_xzjinhuo.UseVisualStyleBackColor = false;
            this.btn_xzjinhuo.Click += new System.EventHandler(this.btn_xzjinhuo_Click);
            // 
            // col_jc_id
            // 
            this.col_jc_id.DataPropertyName = "id";
            this.col_jc_id.HeaderText = "ID";
            this.col_jc_id.Name = "col_jc_id";
            this.col_jc_id.ReadOnly = true;
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
            this.col_jc_lyqx.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.col_jc_lyqx.HeaderText = "来源去向";
            this.col_jc_lyqx.Name = "col_jc_lyqx";
            this.col_jc_lyqx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_jc_lyqx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_jc_lyqx.Width = 120;
            // 
            // col_jc_sl
            // 
            this.col_jc_sl.HeaderText = "数量";
            this.col_jc_sl.Name = "col_jc_sl";
            this.col_jc_sl.ReadOnly = true;
            this.col_jc_sl.Width = 80;
            // 
            // col_jc_jj
            // 
            this.col_jc_jj.HeaderText = "进价";
            this.col_jc_jj.Name = "col_jc_jj";
            this.col_jc_jj.ReadOnly = true;
            this.col_jc_jj.Width = 80;
            // 
            // col_jc_sj
            // 
            this.col_jc_sj.HeaderText = "售价";
            this.col_jc_sj.Name = "col_jc_sj";
            this.col_jc_sj.ReadOnly = true;
            this.col_jc_sj.Width = 80;
            // 
            // col_jc_bz
            // 
            this.col_jc_bz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_jc_bz.HeaderText = "备注";
            this.col_jc_bz.Name = "col_jc_bz";
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
            // col_mx_id
            // 
            this.col_mx_id.HeaderText = "ID";
            this.col_mx_id.Name = "col_mx_id";
            this.col_mx_id.ReadOnly = true;
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
            // col_mx_jj
            // 
            this.col_mx_jj.HeaderText = "进价";
            this.col_mx_jj.Name = "col_mx_jj";
            this.col_mx_jj.ReadOnly = true;
            // 
            // col_mx_sj
            // 
            this.col_mx_sj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_mx_sj.HeaderText = "售价";
            this.col_mx_sj.Name = "col_mx_sj";
            this.col_mx_sj.ReadOnly = true;
            // 
            // cmn_crk_mail
            // 
            this.cmn_crk_mail.Name = "cmn_crk_mail";
            this.cmn_crk_mail.Size = new System.Drawing.Size(152, 22);
            this.cmn_crk_mail.Text = "发送到邮箱";
            this.cmn_crk_mail.Click += new System.EventHandler(this.cmn_crk_mail_Click);
            // 
            // Form_Jinchuhuo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 490);
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
        private MyButton btn_ch;
        private MyTextBox txb_id;
        private MyLabel label38;
        private MyButton btn_jh;
        private MyLabel label9;
        private MyButton btn_cx;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private MyGrid grid_jch;
        private MyGrid grid_jcmx;
        private System.Windows.Forms.ContextMenuStrip cmn_crk;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_daoru;
        private MyButton btn_shangbao;
        private MyButton btn_xzjinhuo;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_cxsb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem cmn_crk_mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_fx;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_jc_lyqx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_jj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_sj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_bz;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_czr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_djsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_xgsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jc_sbsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_tm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_ys;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_cm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_jj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mx_sj;
    }
}