﻿namespace CKGL.BM
{
    partial class Form_Bianma
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mn_main = new System.Windows.Forms.MenuStrip();
            this.mni_khxx = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_addxkh = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_addsm = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_bzbm = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_jiazai = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_jiazai_fuwuqi = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_jiazai_bendi = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_jiazai_wenjian = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_jiazai_fhjl = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_saveServer = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_saveLoacal = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_shuaxin = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_biaoqian = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_dyall = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_dysel = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_szlg = new System.Windows.Forms.ToolStripMenuItem();
            this.grid_all = new System.Windows.Forms.DataGridView();
            this.col_all_tmidex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_all_khidex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_all_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_all_khxj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_all_xb = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_all_lx = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_all_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_all_tm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_all_tmxj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_all_gys = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_all_gyskh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_all_ys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_all_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_all_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_all_jj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_all_sj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_all_crsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_all_xgsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmn_all = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmn_all_saveTm = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_all_zsjk = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_all_cfkh = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_all_cftm = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_szgys = new System.Windows.Forms.Button();
            this.cmb_gys = new System.Windows.Forms.ComboBox();
            this.btn_jssj = new System.Windows.Forms.Button();
            this.txb_sjxs = new System.Windows.Forms.TextBox();
            this.mni_logout = new System.Windows.Forms.ToolStripMenuItem();
            this.mn_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_all)).BeginInit();
            this.cmn_all.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mn_main
            // 
            this.mn_main.AllowMerge = false;
            this.mn_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mni_khxx,
            this.mni_addxkh,
            this.mni_addsm,
            this.mni_bzbm,
            this.mni_jiazai,
            this.保存ToolStripMenuItem,
            this.mni_shuaxin,
            this.mni_biaoqian,
            this.mni_logout});
            this.mn_main.Location = new System.Drawing.Point(0, 0);
            this.mn_main.Name = "mn_main";
            this.mn_main.Size = new System.Drawing.Size(1170, 25);
            this.mn_main.TabIndex = 10;
            this.mn_main.Text = "menuStrip1";
            // 
            // mni_khxx
            // 
            this.mni_khxx.Name = "mni_khxx";
            this.mni_khxx.Size = new System.Drawing.Size(68, 21);
            this.mni_khxx.Text = "款号信息";
            this.mni_khxx.Click += new System.EventHandler(this.mni_khxx_Click);
            // 
            // mni_addxkh
            // 
            this.mni_addxkh.Name = "mni_addxkh";
            this.mni_addxkh.Size = new System.Drawing.Size(80, 21);
            this.mni_addxkh.Text = "增加新款号";
            this.mni_addxkh.Click += new System.EventHandler(this.mni_addkh_Click);
            // 
            // mni_addsm
            // 
            this.mni_addsm.Name = "mni_addsm";
            this.mni_addsm.Size = new System.Drawing.Size(80, 21);
            this.mni_addsm.Text = "增加新色码";
            this.mni_addsm.Click += new System.EventHandler(this.mni_addsm_Click);
            // 
            // mni_bzbm
            // 
            this.mni_bzbm.Name = "mni_bzbm";
            this.mni_bzbm.Size = new System.Drawing.Size(68, 21);
            this.mni_bzbm.Text = "标准编码";
            this.mni_bzbm.Click += new System.EventHandler(this.mni_bzbm_Click);
            // 
            // mni_jiazai
            // 
            this.mni_jiazai.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mni_jiazai_fuwuqi,
            this.mni_jiazai_bendi,
            this.mni_jiazai_wenjian,
            this.mni_jiazai_fhjl});
            this.mni_jiazai.Name = "mni_jiazai";
            this.mni_jiazai.Size = new System.Drawing.Size(92, 21);
            this.mni_jiazai.Text = "加载条码信息";
            // 
            // mni_jiazai_fuwuqi
            // 
            this.mni_jiazai_fuwuqi.Name = "mni_jiazai_fuwuqi";
            this.mni_jiazai_fuwuqi.Size = new System.Drawing.Size(196, 22);
            this.mni_jiazai_fuwuqi.Text = "从服务器加载已有条码";
            this.mni_jiazai_fuwuqi.Click += new System.EventHandler(this.mni_jiazai_Click);
            // 
            // mni_jiazai_bendi
            // 
            this.mni_jiazai_bendi.Name = "mni_jiazai_bendi";
            this.mni_jiazai_bendi.Size = new System.Drawing.Size(196, 22);
            this.mni_jiazai_bendi.Text = "从本地XML加载";
            this.mni_jiazai_bendi.Click += new System.EventHandler(this.mni_jiazai_bendi_Click);
            // 
            // mni_jiazai_wenjian
            // 
            this.mni_jiazai_wenjian.Name = "mni_jiazai_wenjian";
            this.mni_jiazai_wenjian.Size = new System.Drawing.Size(196, 22);
            this.mni_jiazai_wenjian.Text = "从CSV文件加载";
            this.mni_jiazai_wenjian.Click += new System.EventHandler(this.mni_jiazai_wenjian_Click);
            // 
            // mni_jiazai_fhjl
            // 
            this.mni_jiazai_fhjl.Name = "mni_jiazai_fhjl";
            this.mni_jiazai_fhjl.Size = new System.Drawing.Size(196, 22);
            this.mni_jiazai_fhjl.Text = "从供应商发货记录加载";
            this.mni_jiazai_fhjl.Click += new System.EventHandler(this.mni_jiazai_fhjl_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mni_saveServer,
            this.mni_saveLoacal});
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // mni_saveServer
            // 
            this.mni_saveServer.Name = "mni_saveServer";
            this.mni_saveServer.Size = new System.Drawing.Size(152, 22);
            this.mni_saveServer.Text = "保存到服务器";
            this.mni_saveServer.Click += new System.EventHandler(this.mni_saveServer_Click);
            // 
            // mni_saveLoacal
            // 
            this.mni_saveLoacal.Name = "mni_saveLoacal";
            this.mni_saveLoacal.Size = new System.Drawing.Size(152, 22);
            this.mni_saveLoacal.Text = "保存到本地";
            this.mni_saveLoacal.Click += new System.EventHandler(this.mni_saveLoacal_Click);
            // 
            // mni_shuaxin
            // 
            this.mni_shuaxin.Name = "mni_shuaxin";
            this.mni_shuaxin.Size = new System.Drawing.Size(68, 21);
            this.mni_shuaxin.Text = "刷新表格";
            this.mni_shuaxin.Click += new System.EventHandler(this.cmi_shuaxin_Click);
            // 
            // mni_biaoqian
            // 
            this.mni_biaoqian.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mni_dyall,
            this.mni_dysel,
            this.mni_szlg});
            this.mni_biaoqian.Name = "mni_biaoqian";
            this.mni_biaoqian.Size = new System.Drawing.Size(44, 21);
            this.mni_biaoqian.Text = "打印";
            // 
            // mni_dyall
            // 
            this.mni_dyall.Name = "mni_dyall";
            this.mni_dyall.Size = new System.Drawing.Size(152, 22);
            this.mni_dyall.Text = "打印所有行";
            this.mni_dyall.Click += new System.EventHandler(this.mni_dyall_Click);
            // 
            // mni_dysel
            // 
            this.mni_dysel.Name = "mni_dysel";
            this.mni_dysel.Size = new System.Drawing.Size(152, 22);
            this.mni_dysel.Text = "打印选中的行";
            this.mni_dysel.Click += new System.EventHandler(this.mni_dysel_Click);
            // 
            // mni_szlg
            // 
            this.mni_szlg.Name = "mni_szlg";
            this.mni_szlg.Size = new System.Drawing.Size(152, 22);
            this.mni_szlg.Text = "设置标签logo";
            this.mni_szlg.Click += new System.EventHandler(this.mni_szlg_Click);
            // 
            // grid_all
            // 
            this.grid_all.AllowUserToAddRows = false;
            this.grid_all.AllowUserToResizeRows = false;
            this.grid_all.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_all.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_all_tmidex,
            this.col_all_khidex,
            this.col_all_kh,
            this.col_all_khxj,
            this.col_all_xb,
            this.col_all_lx,
            this.col_all_pm,
            this.col_all_tm,
            this.col_all_tmxj,
            this.col_all_gys,
            this.col_all_gyskh,
            this.col_all_ys,
            this.col_all_cm,
            this.col_all_sl,
            this.col_all_jj,
            this.col_all_sj,
            this.col_all_crsj,
            this.col_all_xgsj});
            this.grid_all.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_all.Location = new System.Drawing.Point(0, 60);
            this.grid_all.Name = "grid_all";
            this.grid_all.RowTemplate.Height = 23;
            this.grid_all.Size = new System.Drawing.Size(1170, 466);
            this.grid_all.TabIndex = 9;
            this.grid_all.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grid_all_CellBeginEdit);
            this.grid_all.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_all_CellEndEdit);
            this.grid_all.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_all_CellMouseDown);
            this.grid_all.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grid_all_CellValidating);
            this.grid_all.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_all_CellValueChanged);
            this.grid_all.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grid_all_RowPostPaint);
            this.grid_all.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.grid_all_RowStateChanged);
            this.grid_all.SelectionChanged += new System.EventHandler(this.grid_all_SelectionChanged);
            this.grid_all.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.grid_all_UserDeletedRow);
            this.grid_all.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_all_UserDeletingRow);
            this.grid_all.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_all_KeyDown);
            // 
            // col_all_tmidex
            // 
            this.col_all_tmidex.HeaderText = "TMIDEX";
            this.col_all_tmidex.Name = "col_all_tmidex";
            this.col_all_tmidex.Visible = false;
            // 
            // col_all_khidex
            // 
            this.col_all_khidex.HeaderText = "KHIDEX";
            this.col_all_khidex.Name = "col_all_khidex";
            this.col_all_khidex.Visible = false;
            // 
            // col_all_kh
            // 
            this.col_all_kh.DataPropertyName = "kuanhao";
            this.col_all_kh.HeaderText = "款号";
            this.col_all_kh.Name = "col_all_kh";
            this.col_all_kh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_all_khxj
            // 
            this.col_all_khxj.HeaderText = "新/旧款";
            this.col_all_khxj.Name = "col_all_khxj";
            this.col_all_khxj.ReadOnly = true;
            this.col_all_khxj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_all_xb
            // 
            this.col_all_xb.DataPropertyName = "xingbie";
            this.col_all_xb.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.col_all_xb.HeaderText = "性别";
            this.col_all_xb.Name = "col_all_xb";
            this.col_all_xb.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // col_all_lx
            // 
            this.col_all_lx.DataPropertyName = "leixing";
            this.col_all_lx.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.col_all_lx.HeaderText = "类型";
            this.col_all_lx.Name = "col_all_lx";
            this.col_all_lx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // col_all_pm
            // 
            this.col_all_pm.DataPropertyName = "pinming";
            this.col_all_pm.HeaderText = "品名";
            this.col_all_pm.Name = "col_all_pm";
            this.col_all_pm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_all_tm
            // 
            this.col_all_tm.DataPropertyName = "tiaoma";
            this.col_all_tm.HeaderText = "条码";
            this.col_all_tm.Name = "col_all_tm";
            this.col_all_tm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_all_tmxj
            // 
            this.col_all_tmxj.HeaderText = "新/旧条码";
            this.col_all_tmxj.Name = "col_all_tmxj";
            this.col_all_tmxj.ReadOnly = true;
            this.col_all_tmxj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_all_gys
            // 
            this.col_all_gys.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.col_all_gys.HeaderText = "供应商";
            this.col_all_gys.Name = "col_all_gys";
            this.col_all_gys.ReadOnly = true;
            this.col_all_gys.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // col_all_gyskh
            // 
            this.col_all_gyskh.DataPropertyName = "gyskuanhao";
            this.col_all_gyskh.HeaderText = "供应商款号";
            this.col_all_gyskh.Name = "col_all_gyskh";
            this.col_all_gyskh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_all_ys
            // 
            this.col_all_ys.DataPropertyName = "yanse";
            this.col_all_ys.HeaderText = "颜色";
            this.col_all_ys.Name = "col_all_ys";
            this.col_all_ys.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_all_cm
            // 
            this.col_all_cm.DataPropertyName = "chima";
            this.col_all_cm.HeaderText = "尺码";
            this.col_all_cm.Name = "col_all_cm";
            this.col_all_cm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_all_sl
            // 
            this.col_all_sl.HeaderText = "数量";
            this.col_all_sl.Name = "col_all_sl";
            this.col_all_sl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_all_jj
            // 
            this.col_all_jj.DataPropertyName = "jinjia";
            this.col_all_jj.HeaderText = "进价";
            this.col_all_jj.Name = "col_all_jj";
            this.col_all_jj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_all_sj
            // 
            this.col_all_sj.DataPropertyName = "shoujia";
            this.col_all_sj.HeaderText = "吊牌价";
            this.col_all_sj.Name = "col_all_sj";
            this.col_all_sj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_all_crsj
            // 
            this.col_all_crsj.DataPropertyName = "charushijian";
            this.col_all_crsj.HeaderText = "插入时间";
            this.col_all_crsj.Name = "col_all_crsj";
            this.col_all_crsj.ReadOnly = true;
            this.col_all_crsj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_all_xgsj
            // 
            this.col_all_xgsj.DataPropertyName = "xiugaishijian";
            this.col_all_xgsj.HeaderText = "修改时间";
            this.col_all_xgsj.Name = "col_all_xgsj";
            this.col_all_xgsj.ReadOnly = true;
            this.col_all_xgsj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cmn_all
            // 
            this.cmn_all.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmn_all_saveTm,
            this.cmn_all_zsjk,
            this.cmn_all_cfkh,
            this.cmn_all_cftm});
            this.cmn_all.Name = "cmn_all";
            this.cmn_all.Size = new System.Drawing.Size(185, 92);
            // 
            // cmn_all_saveTm
            // 
            this.cmn_all_saveTm.Name = "cmn_all_saveTm";
            this.cmn_all_saveTm.Size = new System.Drawing.Size(184, 22);
            this.cmn_all_saveTm.Text = "保存条码修改";
            this.cmn_all_saveTm.Click += new System.EventHandler(this.cmn_all_saveTm_Click);
            // 
            // cmn_all_zsjk
            // 
            this.cmn_all_zsjk.Name = "cmn_all_zsjk";
            this.cmn_all_zsjk.Size = new System.Drawing.Size(184, 22);
            this.cmn_all_zsjk.Text = "这是旧款";
            this.cmn_all_zsjk.Click += new System.EventHandler(this.cmn_all_zsjk_Click);
            // 
            // cmn_all_cfkh
            // 
            this.cmn_all_cfkh.Name = "cmn_all_cfkh";
            this.cmn_all_cfkh.Size = new System.Drawing.Size(184, 22);
            this.cmn_all_cfkh.Text = "查看重复的款号信息";
            this.cmn_all_cfkh.Click += new System.EventHandler(this.cmn_all_cfkh_Click);
            // 
            // cmn_all_cftm
            // 
            this.cmn_all_cftm.Name = "cmn_all_cftm";
            this.cmn_all_cftm.Size = new System.Drawing.Size(184, 22);
            this.cmn_all_cftm.Text = "查看重复的条码信息";
            this.cmn_all_cftm.Click += new System.EventHandler(this.cmn_all_cftm_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_szgys);
            this.panel1.Controls.Add(this.cmb_gys);
            this.panel1.Controls.Add(this.btn_jssj);
            this.panel1.Controls.Add(this.txb_sjxs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1170, 35);
            this.panel1.TabIndex = 11;
            // 
            // btn_szgys
            // 
            this.btn_szgys.Location = new System.Drawing.Point(326, 6);
            this.btn_szgys.Name = "btn_szgys";
            this.btn_szgys.Size = new System.Drawing.Size(75, 23);
            this.btn_szgys.TabIndex = 3;
            this.btn_szgys.Text = "设置供应商";
            this.btn_szgys.UseVisualStyleBackColor = true;
            this.btn_szgys.Click += new System.EventHandler(this.btn_szgys_Click);
            // 
            // cmb_gys
            // 
            this.cmb_gys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_gys.FormattingEnabled = true;
            this.cmb_gys.Location = new System.Drawing.Point(199, 8);
            this.cmb_gys.Name = "cmb_gys";
            this.cmb_gys.Size = new System.Drawing.Size(121, 20);
            this.cmb_gys.TabIndex = 2;
            // 
            // btn_jssj
            // 
            this.btn_jssj.Location = new System.Drawing.Point(118, 6);
            this.btn_jssj.Name = "btn_jssj";
            this.btn_jssj.Size = new System.Drawing.Size(75, 23);
            this.btn_jssj.TabIndex = 1;
            this.btn_jssj.Text = "计算售价";
            this.btn_jssj.UseVisualStyleBackColor = true;
            this.btn_jssj.Click += new System.EventHandler(this.btn_jssj_Click);
            // 
            // txb_sjxs
            // 
            this.txb_sjxs.Location = new System.Drawing.Point(12, 7);
            this.txb_sjxs.Name = "txb_sjxs";
            this.txb_sjxs.Size = new System.Drawing.Size(100, 21);
            this.txb_sjxs.TabIndex = 0;
            // 
            // mni_logout
            // 
            this.mni_logout.Name = "mni_logout";
            this.mni_logout.Size = new System.Drawing.Size(68, 21);
            this.mni_logout.Text = "退出登录";
            this.mni_logout.Click += new System.EventHandler(this.mni_logout_Click);
            // 
            // Form_Bianma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 526);
            this.Controls.Add(this.grid_all);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mn_main);
            this.KeyPreview = true;
            this.Name = "Form_Bianma";
            this.Text = "商品编码";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Bianma_FormClosing);
            this.Load += new System.EventHandler(this.Form_Bianma_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Bianma_KeyDown);
            this.mn_main.ResumeLayout(false);
            this.mn_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_all)).EndInit();
            this.cmn_all.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mn_main;
        private System.Windows.Forms.ToolStripMenuItem mni_khxx;
        private System.Windows.Forms.ToolStripMenuItem mni_addxkh;
        private System.Windows.Forms.ToolStripMenuItem mni_addsm;
        private System.Windows.Forms.ToolStripMenuItem mni_jiazai;
        private System.Windows.Forms.DataGridView grid_all;
        private System.Windows.Forms.ContextMenuStrip cmn_all;
        private System.Windows.Forms.ToolStripMenuItem mni_bzbm;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mni_saveServer;
        private System.Windows.Forms.ToolStripMenuItem mni_saveLoacal;
        private System.Windows.Forms.ToolStripMenuItem mni_jiazai_fuwuqi;
        private System.Windows.Forms.ToolStripMenuItem mni_jiazai_bendi;
        private System.Windows.Forms.ToolStripMenuItem cmn_all_saveTm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_jssj;
        private System.Windows.Forms.TextBox txb_sjxs;
        private System.Windows.Forms.Button btn_szgys;
        private System.Windows.Forms.ComboBox cmb_gys;
        private System.Windows.Forms.ToolStripMenuItem mni_jiazai_wenjian;
        private System.Windows.Forms.ToolStripMenuItem mni_jiazai_fhjl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_all_tmidex;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_all_khidex;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_all_kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_all_khxj;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_all_xb;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_all_lx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_all_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_all_tm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_all_tmxj;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_all_gys;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_all_gyskh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_all_ys;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_all_cm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_all_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_all_jj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_all_sj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_all_crsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_all_xgsj;
        private System.Windows.Forms.ToolStripMenuItem cmn_all_zsjk;
        private System.Windows.Forms.ToolStripMenuItem cmn_all_cfkh;
        private System.Windows.Forms.ToolStripMenuItem cmn_all_cftm;
        private System.Windows.Forms.ToolStripMenuItem mni_shuaxin;
        private System.Windows.Forms.ToolStripMenuItem mni_biaoqian;
        private System.Windows.Forms.ToolStripMenuItem mni_dyall;
        private System.Windows.Forms.ToolStripMenuItem mni_dysel;
        private System.Windows.Forms.ToolStripMenuItem mni_szlg;
        private System.Windows.Forms.ToolStripMenuItem mni_logout;
    }
}
