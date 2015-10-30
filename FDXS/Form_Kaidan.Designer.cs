using MyFormControls;
using System.Windows.Forms;
namespace FDXS
{
    partial class Form_Kaidan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new MyFormControls.MyPanel();
            this.grid_kaidan = new MyFormControls.MyGrid();
            this.col_tmid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_zk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ml = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_yingshou = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new MyFormControls.MyPanel();
            this.label2 = new MyFormControls.MyLabel();
            this.lbl_zongjia = new MyFormControls.MyLabel();
            this.label1 = new MyFormControls.MyLabel();
            this.btn_ok = new MyFormControls.MyButton();
            this.lbl_zhaoling = new MyFormControls.MyLabel();
            this.txb_shishou = new MyFormControls.MyTextBox();
            this.label14 = new MyFormControls.MyLabel();
            this.panel2 = new MyFormControls.MyPanel();
            this.myPanel1 = new MyFormControls.MyPanel();
            this.label6 = new MyFormControls.MyLabel();
            this.lbl_hyxm = new MyFormControls.MyLabel();
            this.txb_sjh = new MyFormControls.MyTextBox();
            this.label7 = new MyFormControls.MyLabel();
            this.label12 = new MyFormControls.MyLabel();
            this.lbl_hyjf = new MyFormControls.MyLabel();
            this.btn_zchy = new MyFormControls.MyButton();
            this.btn_wutiaoma = new MyFormControls.MyButton();
            this.cmb_xsy = new MyFormControls.MyComboBox();
            this.label4 = new MyFormControls.MyLabel();
            this.dp_xssj = new MyFormControls.MyDateTimePicker();
            this.label5 = new MyFormControls.MyLabel();
            this.txb_tiaoma = new MyFormControls.MyTextBox();
            this.label3 = new MyFormControls.MyLabel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_kaidan)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.myPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.grid_kaidan);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1066, 150);
            this.panel3.TabIndex = 4;
            // 
            // grid_kaidan
            // 
            this.grid_kaidan.AllowUserToAddRows = false;
            this.grid_kaidan.AllowUserToResizeRows = false;
            this.grid_kaidan.BackgroundColor = System.Drawing.Color.Black;
            this.grid_kaidan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_kaidan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_kaidan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_kaidan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_kaidan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_tmid,
            this.col_tm,
            this.col_kh,
            this.col_pm,
            this.col_ys,
            this.col_cm,
            this.col_sl,
            this.col_jj,
            this.col_sj,
            this.col_zk,
            this.col_ml,
            this.col_yingshou,
            this.col_bz});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_kaidan.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_kaidan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_kaidan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grid_kaidan.EnableHeadersVisualStyles = false;
            this.grid_kaidan.Location = new System.Drawing.Point(0, 0);
            this.grid_kaidan.MultiSelect = false;
            this.grid_kaidan.Name = "grid_kaidan";
            this.grid_kaidan.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grid_kaidan.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_kaidan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grid_kaidan.RowTemplate.Height = 40;
            this.grid_kaidan.Size = new System.Drawing.Size(1066, 150);
            this.grid_kaidan.TabIndex = 0;
            this.grid_kaidan.Type = MyFormControls.MyControlType.Standard;
            this.grid_kaidan.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grid_kaidan_CellBeginEdit);
            this.grid_kaidan.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_kaidan_CellValueChanged);
            this.grid_kaidan.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_kaidan_RowsAdded);
            this.grid_kaidan.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.grid_kaidan_UserDeletedRow);
            // 
            // col_tmid
            // 
            this.col_tmid.DataPropertyName = "id";
            this.col_tmid.HeaderText = "条码ID";
            this.col_tmid.Name = "col_tmid";
            this.col_tmid.Visible = false;
            // 
            // col_tm
            // 
            this.col_tm.DataPropertyName = "tiaoma";
            this.col_tm.FillWeight = 820.812F;
            this.col_tm.HeaderText = "条码";
            this.col_tm.Name = "col_tm";
            this.col_tm.ReadOnly = true;
            this.col_tm.Width = 115;
            // 
            // col_kh
            // 
            this.col_kh.DataPropertyName = "kuanhao";
            this.col_kh.FillWeight = 27.91878F;
            this.col_kh.HeaderText = "款号";
            this.col_kh.Name = "col_kh";
            this.col_kh.ReadOnly = true;
            // 
            // col_pm
            // 
            this.col_pm.DataPropertyName = "pinming";
            this.col_pm.FillWeight = 27.91878F;
            this.col_pm.HeaderText = "品名";
            this.col_pm.Name = "col_pm";
            this.col_pm.ReadOnly = true;
            this.col_pm.Width = 120;
            // 
            // col_ys
            // 
            this.col_ys.DataPropertyName = "yanse";
            this.col_ys.FillWeight = 27.91878F;
            this.col_ys.HeaderText = "颜色";
            this.col_ys.Name = "col_ys";
            this.col_ys.ReadOnly = true;
            this.col_ys.Width = 80;
            // 
            // col_cm
            // 
            this.col_cm.DataPropertyName = "chima";
            this.col_cm.FillWeight = 27.91878F;
            this.col_cm.HeaderText = "尺码";
            this.col_cm.Name = "col_cm";
            this.col_cm.ReadOnly = true;
            this.col_cm.Width = 80;
            // 
            // col_sl
            // 
            this.col_sl.DataPropertyName = "shuliang";
            this.col_sl.FillWeight = 27.91878F;
            this.col_sl.HeaderText = "数量";
            this.col_sl.Name = "col_sl";
            this.col_sl.Width = 80;
            // 
            // col_jj
            // 
            this.col_jj.HeaderText = "进价";
            this.col_jj.Name = "col_jj";
            this.col_jj.Visible = false;
            this.col_jj.Width = 80;
            // 
            // col_sj
            // 
            this.col_sj.DataPropertyName = "danjia";
            this.col_sj.FillWeight = 27.91878F;
            this.col_sj.HeaderText = "单价";
            this.col_sj.Name = "col_sj";
            this.col_sj.ReadOnly = true;
            this.col_sj.Width = 80;
            // 
            // col_zk
            // 
            this.col_zk.DataPropertyName = "zhekou";
            this.col_zk.FillWeight = 27.91878F;
            this.col_zk.HeaderText = "折扣";
            this.col_zk.Name = "col_zk";
            this.col_zk.Width = 80;
            // 
            // col_ml
            // 
            this.col_ml.DataPropertyName = "moling";
            this.col_ml.FillWeight = 27.91878F;
            this.col_ml.HeaderText = "抹零";
            this.col_ml.Name = "col_ml";
            this.col_ml.Width = 80;
            // 
            // col_yingshou
            // 
            this.col_yingshou.DataPropertyName = "yingshou";
            this.col_yingshou.FillWeight = 27.91878F;
            this.col_yingshou.HeaderText = "应收";
            this.col_yingshou.Name = "col_yingshou";
            this.col_yingshou.Width = 80;
            // 
            // col_bz
            // 
            this.col_bz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_bz.FillWeight = 27.91878F;
            this.col_bz.HeaderText = "备注";
            this.col_bz.Name = "col_bz";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_zongjia);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_ok);
            this.panel1.Controls.Add(this.lbl_zhaoling);
            this.panel1.Controls.Add(this.txb_shishou);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 223);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1066, 244);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(461, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "找零￥";
            this.label2.Type = MyFormControls.MyControlType.Standard;
            // 
            // lbl_zongjia
            // 
            this.lbl_zongjia.AutoSize = true;
            this.lbl_zongjia.BackColor = System.Drawing.Color.Black;
            this.lbl_zongjia.Font = new System.Drawing.Font("宋体", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_zongjia.ForeColor = System.Drawing.Color.White;
            this.lbl_zongjia.Location = new System.Drawing.Point(4, 87);
            this.lbl_zongjia.Name = "lbl_zongjia";
            this.lbl_zongjia.Size = new System.Drawing.Size(196, 80);
            this.lbl_zongjia.TabIndex = 6;
            this.lbl_zongjia.Text = "总价";
            this.lbl_zongjia.Type = MyFormControls.MyControlType.Special;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(280, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "实收";
            this.label1.Type = MyFormControls.MyControlType.Standard;
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.Black;
            this.btn_ok.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Location = new System.Drawing.Point(814, 0);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(252, 244);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "确定";
            this.btn_ok.Type = MyFormControls.MyControlType.Special;
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // lbl_zhaoling
            // 
            this.lbl_zhaoling.AutoSize = true;
            this.lbl_zhaoling.BackColor = System.Drawing.Color.Black;
            this.lbl_zhaoling.Font = new System.Drawing.Font("宋体", 60F, System.Drawing.FontStyle.Bold);
            this.lbl_zhaoling.ForeColor = System.Drawing.Color.White;
            this.lbl_zhaoling.Location = new System.Drawing.Point(416, 87);
            this.lbl_zhaoling.Name = "lbl_zhaoling";
            this.lbl_zhaoling.Size = new System.Drawing.Size(196, 80);
            this.lbl_zhaoling.TabIndex = 3;
            this.lbl_zhaoling.Text = "找零";
            this.lbl_zhaoling.Type = MyFormControls.MyControlType.Special;
            // 
            // txb_shishou
            // 
            this.txb_shishou.BackColor = System.Drawing.Color.Black;
            this.txb_shishou.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_shishou.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_shishou.ForeColor = System.Drawing.Color.White;
            this.txb_shishou.Location = new System.Drawing.Point(255, 48);
            this.txb_shishou.Name = "txb_shishou";
            this.txb_shishou.Size = new System.Drawing.Size(100, 26);
            this.txb_shishou.TabIndex = 1;
            this.txb_shishou.Type = MyFormControls.MyControlType.Standard;
            this.txb_shishou.TextChanged += new System.EventHandler(this.txb_shishou_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(62, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "总价￥";
            this.label14.Type = MyFormControls.MyControlType.Standard;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.myPanel1);
            this.panel2.Controls.Add(this.btn_wutiaoma);
            this.panel2.Controls.Add(this.cmb_xsy);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dp_xssj);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txb_tiaoma);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1066, 73);
            this.panel2.TabIndex = 2;
            // 
            // myPanel1
            // 
            this.myPanel1.BackColor = System.Drawing.Color.Black;
            this.myPanel1.Controls.Add(this.label6);
            this.myPanel1.Controls.Add(this.lbl_hyxm);
            this.myPanel1.Controls.Add(this.txb_sjh);
            this.myPanel1.Controls.Add(this.label7);
            this.myPanel1.Controls.Add(this.label12);
            this.myPanel1.Controls.Add(this.lbl_hyjf);
            this.myPanel1.Controls.Add(this.btn_zchy);
            this.myPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.myPanel1.Location = new System.Drawing.Point(685, 0);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(381, 73);
            this.myPanel1.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(20, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "手机号码";
            this.label6.Type = MyFormControls.MyControlType.Standard;
            // 
            // lbl_hyxm
            // 
            this.lbl_hyxm.AutoSize = true;
            this.lbl_hyxm.BackColor = System.Drawing.Color.Black;
            this.lbl_hyxm.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_hyxm.ForeColor = System.Drawing.Color.White;
            this.lbl_hyxm.Location = new System.Drawing.Point(115, 39);
            this.lbl_hyxm.Name = "lbl_hyxm";
            this.lbl_hyxm.Size = new System.Drawing.Size(51, 20);
            this.lbl_hyxm.TabIndex = 19;
            this.lbl_hyxm.Text = "姓名";
            this.lbl_hyxm.Type = MyFormControls.MyControlType.Standard;
            // 
            // txb_sjh
            // 
            this.txb_sjh.BackColor = System.Drawing.Color.Black;
            this.txb_sjh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_sjh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_sjh.ForeColor = System.Drawing.Color.White;
            this.txb_sjh.Location = new System.Drawing.Point(119, 3);
            this.txb_sjh.Name = "txb_sjh";
            this.txb_sjh.Size = new System.Drawing.Size(100, 26);
            this.txb_sjh.TabIndex = 10;
            this.txb_sjh.Type = MyFormControls.MyControlType.Standard;
            this.txb_sjh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_sjh_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(219, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "积分：";
            this.label7.Type = MyFormControls.MyControlType.Standard;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(20, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 20);
            this.label12.TabIndex = 18;
            this.label12.Text = "姓名：";
            this.label12.Type = MyFormControls.MyControlType.Standard;
            // 
            // lbl_hyjf
            // 
            this.lbl_hyjf.AutoSize = true;
            this.lbl_hyjf.BackColor = System.Drawing.Color.Black;
            this.lbl_hyjf.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_hyjf.ForeColor = System.Drawing.Color.White;
            this.lbl_hyjf.Location = new System.Drawing.Point(297, 39);
            this.lbl_hyjf.Name = "lbl_hyjf";
            this.lbl_hyjf.Size = new System.Drawing.Size(51, 20);
            this.lbl_hyjf.TabIndex = 13;
            this.lbl_hyjf.Text = "积分";
            this.lbl_hyjf.Type = MyFormControls.MyControlType.Standard;
            // 
            // btn_zchy
            // 
            this.btn_zchy.BackColor = System.Drawing.Color.Black;
            this.btn_zchy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_zchy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_zchy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_zchy.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_zchy.ForeColor = System.Drawing.Color.White;
            this.btn_zchy.Location = new System.Drawing.Point(278, 3);
            this.btn_zchy.Name = "btn_zchy";
            this.btn_zchy.Size = new System.Drawing.Size(100, 26);
            this.btn_zchy.TabIndex = 14;
            this.btn_zchy.Text = "注册会员";
            this.btn_zchy.Type = MyFormControls.MyControlType.Standard;
            this.btn_zchy.UseVisualStyleBackColor = true;
            this.btn_zchy.Click += new System.EventHandler(this.btn_zchy_Click);
            // 
            // btn_wutiaoma
            // 
            this.btn_wutiaoma.BackColor = System.Drawing.Color.Black;
            this.btn_wutiaoma.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_wutiaoma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_wutiaoma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_wutiaoma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_wutiaoma.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_wutiaoma.ForeColor = System.Drawing.Color.White;
            this.btn_wutiaoma.Location = new System.Drawing.Point(217, 3);
            this.btn_wutiaoma.Name = "btn_wutiaoma";
            this.btn_wutiaoma.Size = new System.Drawing.Size(100, 26);
            this.btn_wutiaoma.TabIndex = 25;
            this.btn_wutiaoma.Text = "无条码";
            this.btn_wutiaoma.Type = MyFormControls.MyControlType.Standard;
            this.btn_wutiaoma.UseVisualStyleBackColor = true;
            this.btn_wutiaoma.Click += new System.EventHandler(this.btn_wutiaoma_Click);
            // 
            // cmb_xsy
            // 
            this.cmb_xsy.BackColor = System.Drawing.Color.Black;
            this.cmb_xsy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_xsy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_xsy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_xsy.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.cmb_xsy.ForeColor = System.Drawing.Color.White;
            this.cmb_xsy.FormattingEnabled = true;
            this.cmb_xsy.HighlightBackColor = System.Drawing.Color.White;
            this.cmb_xsy.HighlightForeColor = System.Drawing.Color.Black;
            this.cmb_xsy.Location = new System.Drawing.Point(417, 3);
            this.cmb_xsy.Name = "cmb_xsy";
            this.cmb_xsy.Size = new System.Drawing.Size(100, 27);
            this.cmb_xsy.TabIndex = 18;
            this.cmb_xsy.Type = MyFormControls.MyControlType.Standard;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(318, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "销售人员";
            this.label4.Type = MyFormControls.MyControlType.Standard;
            // 
            // dp_xssj
            // 
            this.dp_xssj.BackColor = System.Drawing.Color.Black;
            this.dp_xssj.CalendarFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.dp_xssj.CalendarForeColor = System.Drawing.Color.Black;
            this.dp_xssj.CalendarMonthBackground = System.Drawing.Color.Black;
            this.dp_xssj.CalendarTitleBackColor = System.Drawing.Color.Black;
            this.dp_xssj.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dp_xssj.CalendarTrailingForeColor = System.Drawing.Color.Black;
            this.dp_xssj.Checked = false;
            this.dp_xssj.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dp_xssj.Font = new System.Drawing.Font("宋体", 12F);
            this.dp_xssj.ForeColor = System.Drawing.Color.White;
            this.dp_xssj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp_xssj.Location = new System.Drawing.Point(102, 35);
            this.dp_xssj.Name = "dp_xssj";
            this.dp_xssj.ShowCheckBox = true;
            this.dp_xssj.Size = new System.Drawing.Size(215, 26);
            this.dp_xssj.TabIndex = 13;
            this.dp_xssj.Type = MyFormControls.MyControlType.Standard;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "销售时间";
            this.label5.Type = MyFormControls.MyControlType.Standard;
            // 
            // txb_tiaoma
            // 
            this.txb_tiaoma.BackColor = System.Drawing.Color.Black;
            this.txb_tiaoma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_tiaoma.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_tiaoma.ForeColor = System.Drawing.Color.White;
            this.txb_tiaoma.Location = new System.Drawing.Point(102, 3);
            this.txb_tiaoma.Name = "txb_tiaoma";
            this.txb_tiaoma.Size = new System.Drawing.Size(100, 26);
            this.txb_tiaoma.TabIndex = 8;
            this.txb_tiaoma.Type = MyFormControls.MyControlType.Standard;
            this.txb_tiaoma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_tiaoma_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "输入条码";
            this.label3.Type = MyFormControls.MyControlType.Standard;
            // 
            // Form_Kaidan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 467);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.Name = "Form_Kaidan";
            this.Text = "开单";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dlg_xiaoshou_FormClosing);
            this.Load += new System.EventHandler(this.Dlg_xiaoshou_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_kaidan)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.myPanel1.ResumeLayout(false);
            this.myPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyGrid grid_kaidan;
        private MyPanel panel1;
        private MyLabel lbl_zhaoling;
        private MyTextBox txb_shishou;
        private MyLabel label14;
        private MyButton btn_ok;
        private MyLabel label1;
        private MyLabel lbl_zongjia;
        private MyTextBox txb_tiaoma;
        private MyPanel panel2;
        private MyLabel label3;
        private MyLabel label2;
        private MyLabel label5;
        private MyDateTimePicker dp_xssj;
        private MyLabel lbl_hyjf;
        private MyLabel label7;
        private MyTextBox txb_sjh;
        private MyLabel label6;
        private MyButton btn_zchy;
        private MyLabel label4;
        private MyComboBox cmb_xsy;
        private MyLabel lbl_hyxm;
        private MyLabel label12;
        private MyButton btn_wutiaoma;
        private MyPanel panel3;
        private MyPanel myPanel1;
        private DataGridViewTextBoxColumn col_tmid;
        private DataGridViewTextBoxColumn col_tm;
        private DataGridViewTextBoxColumn col_kh;
        private DataGridViewTextBoxColumn col_pm;
        private DataGridViewTextBoxColumn col_ys;
        private DataGridViewTextBoxColumn col_cm;
        private DataGridViewTextBoxColumn col_sl;
        private DataGridViewTextBoxColumn col_jj;
        private DataGridViewTextBoxColumn col_sj;
        private DataGridViewTextBoxColumn col_zk;
        private DataGridViewTextBoxColumn col_ml;
        private DataGridViewTextBoxColumn col_yingshou;
        private DataGridViewTextBoxColumn col_bz;
    }
}