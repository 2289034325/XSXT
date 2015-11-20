using MyFormControls;
using System.Windows.Forms;
namespace FDXS
{
    partial class Form_KucunYilan
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
            this.btn_sbkc = new MyFormControls.MyButton();
            this.cmb_leixing = new MyFormControls.MyComboBox();
            this.label8 = new MyFormControls.MyLabel();
            this.btn_sch = new MyFormControls.MyButton();
            this.txb_kuanhao = new MyFormControls.MyTextBox();
            this.txb_tiaoma = new MyFormControls.MyTextBox();
            this.label16 = new MyFormControls.MyLabel();
            this.label17 = new MyFormControls.MyLabel();
            this.grid_kc = new MyFormControls.MyGrid();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new MyFormControls.MyLabel();
            this.dp_start = new MyFormControls.MyDateTimePicker();
            this.dp_end = new MyFormControls.MyDateTimePicker();
            this.chk_0 = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_next = new MyFormControls.MyButton();
            this.lbl_page = new MyFormControls.MyLabel();
            this.btn_prev = new MyFormControls.MyButton();
            this.lbl_zongji = new MyFormControls.MyLabel();
            this.btn_zongji = new MyFormControls.MyButton();
            this.col_tm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gyskh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_lx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_kc)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_sbkc
            // 
            this.btn_sbkc.BackColor = System.Drawing.Color.Black;
            this.btn_sbkc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_sbkc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_sbkc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sbkc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_sbkc.ForeColor = System.Drawing.Color.White;
            this.btn_sbkc.Location = new System.Drawing.Point(3, 36);
            this.btn_sbkc.Name = "btn_sbkc";
            this.btn_sbkc.Size = new System.Drawing.Size(100, 26);
            this.btn_sbkc.TabIndex = 12;
            this.btn_sbkc.Text = "上报库存";
            this.btn_sbkc.Type = MyFormControls.MyControlType.Standard;
            this.btn_sbkc.UseVisualStyleBackColor = true;
            this.btn_sbkc.Click += new System.EventHandler(this.btn_sbkc_Click);
            // 
            // cmb_leixing
            // 
            this.cmb_leixing.BackColor = System.Drawing.Color.Black;
            this.cmb_leixing.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_leixing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_leixing.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.cmb_leixing.ForeColor = System.Drawing.Color.White;
            this.cmb_leixing.FormattingEnabled = true;
            this.cmb_leixing.HighlightBackColor = System.Drawing.Color.White;
            this.cmb_leixing.HighlightForeColor = System.Drawing.Color.Black;
            this.cmb_leixing.Location = new System.Drawing.Point(386, 3);
            this.cmb_leixing.Name = "cmb_leixing";
            this.cmb_leixing.Size = new System.Drawing.Size(100, 27);
            this.cmb_leixing.TabIndex = 11;
            this.cmb_leixing.Type = MyFormControls.MyControlType.Standard;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(329, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "类型";
            this.label8.Type = MyFormControls.MyControlType.Standard;
            // 
            // btn_sch
            // 
            this.btn_sch.BackColor = System.Drawing.Color.Black;
            this.btn_sch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_sch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_sch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_sch.ForeColor = System.Drawing.Color.White;
            this.btn_sch.Location = new System.Drawing.Point(109, 36);
            this.btn_sch.Name = "btn_sch";
            this.btn_sch.Size = new System.Drawing.Size(100, 26);
            this.btn_sch.TabIndex = 6;
            this.btn_sch.Text = "查询";
            this.btn_sch.Type = MyFormControls.MyControlType.Standard;
            this.btn_sch.UseVisualStyleBackColor = true;
            this.btn_sch.Click += new System.EventHandler(this.btn_sch_Click);
            // 
            // txb_kuanhao
            // 
            this.txb_kuanhao.BackColor = System.Drawing.Color.Black;
            this.txb_kuanhao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_kuanhao.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_kuanhao.ForeColor = System.Drawing.Color.White;
            this.txb_kuanhao.Location = new System.Drawing.Point(223, 3);
            this.txb_kuanhao.Name = "txb_kuanhao";
            this.txb_kuanhao.Size = new System.Drawing.Size(100, 26);
            this.txb_kuanhao.TabIndex = 4;
            this.txb_kuanhao.Type = MyFormControls.MyControlType.Standard;
            // 
            // txb_tiaoma
            // 
            this.txb_tiaoma.BackColor = System.Drawing.Color.Black;
            this.txb_tiaoma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_tiaoma.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_tiaoma.ForeColor = System.Drawing.Color.White;
            this.txb_tiaoma.Location = new System.Drawing.Point(60, 3);
            this.txb_tiaoma.Name = "txb_tiaoma";
            this.txb_tiaoma.Size = new System.Drawing.Size(100, 26);
            this.txb_tiaoma.TabIndex = 3;
            this.txb_tiaoma.Type = MyFormControls.MyControlType.Standard;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(166, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 20);
            this.label16.TabIndex = 1;
            this.label16.Text = "款号";
            this.label16.Type = MyFormControls.MyControlType.Standard;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Black;
            this.label17.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(3, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "条码";
            this.label17.Type = MyFormControls.MyControlType.Standard;
            // 
            // grid_kc
            // 
            this.grid_kc.AllowUserToAddRows = false;
            this.grid_kc.AllowUserToDeleteRows = false;
            this.grid_kc.AllowUserToResizeRows = false;
            this.grid_kc.BackgroundColor = System.Drawing.Color.Black;
            this.grid_kc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_kc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_kc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_kc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_kc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_tm,
            this.col_kh,
            this.col_gyskh,
            this.col_lx,
            this.col_pm,
            this.col_ys,
            this.col_cm,
            this.col_sj,
            this.col_sl});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_kc.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_kc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_kc.EnableHeadersVisualStyles = false;
            this.grid_kc.Location = new System.Drawing.Point(0, 65);
            this.grid_kc.Name = "grid_kc";
            this.grid_kc.ReadOnly = true;
            this.grid_kc.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_kc.RowHeadersVisible = false;
            this.grid_kc.RowTemplate.Height = 23;
            this.grid_kc.Size = new System.Drawing.Size(1076, 389);
            this.grid_kc.TabIndex = 11;
            this.grid_kc.Type = MyFormControls.MyControlType.Standard;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.label17);
            this.flowLayoutPanel1.Controls.Add(this.txb_tiaoma);
            this.flowLayoutPanel1.Controls.Add(this.label16);
            this.flowLayoutPanel1.Controls.Add(this.txb_kuanhao);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.cmb_leixing);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.dp_start);
            this.flowLayoutPanel1.Controls.Add(this.dp_end);
            this.flowLayoutPanel1.Controls.Add(this.chk_0);
            this.flowLayoutPanel1.Controls.Add(this.btn_sbkc);
            this.flowLayoutPanel1.Controls.Add(this.btn_sch);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1076, 65);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(492, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 29;
            this.label9.Text = "进货日期";
            this.label9.Type = MyFormControls.MyControlType.Standard;
            // 
            // dp_start
            // 
            this.dp_start.Checked = false;
            this.dp_start.Font = new System.Drawing.Font("宋体", 12F);
            this.dp_start.Location = new System.Drawing.Point(591, 3);
            this.dp_start.Name = "dp_start";
            this.dp_start.ShowCheckBox = true;
            this.dp_start.Size = new System.Drawing.Size(155, 26);
            this.dp_start.TabIndex = 30;
            this.dp_start.Type = MyFormControls.MyControlType.Special;
            // 
            // dp_end
            // 
            this.dp_end.Checked = false;
            this.dp_end.Font = new System.Drawing.Font("宋体", 12F);
            this.dp_end.Location = new System.Drawing.Point(752, 3);
            this.dp_end.Name = "dp_end";
            this.dp_end.ShowCheckBox = true;
            this.dp_end.Size = new System.Drawing.Size(155, 26);
            this.dp_end.TabIndex = 31;
            this.dp_end.Type = MyFormControls.MyControlType.Special;
            // 
            // chk_0
            // 
            this.chk_0.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk_0.AutoSize = true;
            this.chk_0.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_0.ForeColor = System.Drawing.Color.White;
            this.chk_0.Location = new System.Drawing.Point(913, 6);
            this.chk_0.Name = "chk_0";
            this.chk_0.Size = new System.Drawing.Size(87, 20);
            this.chk_0.TabIndex = 18;
            this.chk_0.Text = "不显示0";
            this.chk_0.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btn_next);
            this.flowLayoutPanel2.Controls.Add(this.lbl_page);
            this.flowLayoutPanel2.Controls.Add(this.btn_prev);
            this.flowLayoutPanel2.Controls.Add(this.lbl_zongji);
            this.flowLayoutPanel2.Controls.Add(this.btn_zongji);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 454);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1076, 30);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // btn_next
            // 
            this.btn_next.BackColor = System.Drawing.Color.Black;
            this.btn_next.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_next.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_next.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_next.ForeColor = System.Drawing.Color.White;
            this.btn_next.Location = new System.Drawing.Point(973, 3);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(100, 26);
            this.btn_next.TabIndex = 12;
            this.btn_next.Text = "下一页";
            this.btn_next.Type = MyFormControls.MyControlType.Standard;
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // lbl_page
            // 
            this.lbl_page.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_page.AutoSize = true;
            this.lbl_page.BackColor = System.Drawing.Color.Black;
            this.lbl_page.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_page.ForeColor = System.Drawing.Color.White;
            this.lbl_page.Location = new System.Drawing.Point(914, 6);
            this.lbl_page.Name = "lbl_page";
            this.lbl_page.Size = new System.Drawing.Size(53, 20);
            this.lbl_page.TabIndex = 0;
            this.lbl_page.Text = "1/10";
            this.lbl_page.Type = MyFormControls.MyControlType.Standard;
            // 
            // btn_prev
            // 
            this.btn_prev.BackColor = System.Drawing.Color.Black;
            this.btn_prev.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_prev.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_prev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_prev.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_prev.ForeColor = System.Drawing.Color.White;
            this.btn_prev.Location = new System.Drawing.Point(808, 3);
            this.btn_prev.Name = "btn_prev";
            this.btn_prev.Size = new System.Drawing.Size(100, 26);
            this.btn_prev.TabIndex = 6;
            this.btn_prev.Text = "上一页";
            this.btn_prev.Type = MyFormControls.MyControlType.Standard;
            this.btn_prev.UseVisualStyleBackColor = true;
            this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);
            // 
            // lbl_zongji
            // 
            this.lbl_zongji.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_zongji.AutoSize = true;
            this.lbl_zongji.BackColor = System.Drawing.Color.Black;
            this.lbl_zongji.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_zongji.ForeColor = System.Drawing.Color.White;
            this.lbl_zongji.Location = new System.Drawing.Point(751, 6);
            this.lbl_zongji.Name = "lbl_zongji";
            this.lbl_zongji.Size = new System.Drawing.Size(51, 20);
            this.lbl_zongji.TabIndex = 13;
            this.lbl_zongji.Text = "总计";
            this.lbl_zongji.Type = MyFormControls.MyControlType.Standard;
            // 
            // btn_zongji
            // 
            this.btn_zongji.BackColor = System.Drawing.Color.Black;
            this.btn_zongji.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_zongji.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_zongji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_zongji.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_zongji.ForeColor = System.Drawing.Color.White;
            this.btn_zongji.Location = new System.Drawing.Point(645, 3);
            this.btn_zongji.Name = "btn_zongji";
            this.btn_zongji.Size = new System.Drawing.Size(100, 26);
            this.btn_zongji.TabIndex = 13;
            this.btn_zongji.Text = "刷新总库存";
            this.btn_zongji.Type = MyFormControls.MyControlType.Standard;
            this.btn_zongji.UseVisualStyleBackColor = true;
            this.btn_zongji.Click += new System.EventHandler(this.btn_zongji_Click);
            // 
            // col_tm
            // 
            this.col_tm.HeaderText = "条码";
            this.col_tm.Name = "col_tm";
            this.col_tm.ReadOnly = true;
            this.col_tm.Width = 130;
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
            this.col_gyskh.Width = 140;
            // 
            // col_lx
            // 
            this.col_lx.HeaderText = "类型";
            this.col_lx.Name = "col_lx";
            this.col_lx.ReadOnly = true;
            this.col_lx.Width = 80;
            // 
            // col_pm
            // 
            this.col_pm.HeaderText = "品名";
            this.col_pm.Name = "col_pm";
            this.col_pm.ReadOnly = true;
            this.col_pm.Width = 120;
            // 
            // col_ys
            // 
            this.col_ys.HeaderText = "颜色";
            this.col_ys.Name = "col_ys";
            this.col_ys.ReadOnly = true;
            this.col_ys.Width = 80;
            // 
            // col_cm
            // 
            this.col_cm.HeaderText = "尺码";
            this.col_cm.Name = "col_cm";
            this.col_cm.ReadOnly = true;
            this.col_cm.Width = 80;
            // 
            // col_sj
            // 
            this.col_sj.HeaderText = "售价";
            this.col_sj.Name = "col_sj";
            this.col_sj.ReadOnly = true;
            this.col_sj.Width = 80;
            // 
            // col_sl
            // 
            this.col_sl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_sl.HeaderText = "数量";
            this.col_sl.Name = "col_sl";
            this.col_sl.ReadOnly = true;
            // 
            // Form_KucunYilan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 484);
            this.Controls.Add(this.grid_kc);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form_KucunYilan";
            this.Text = "库存一览";
            this.Load += new System.EventHandler(this.Form_KucunYilan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_kc)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyLabel label8;
        private MyButton btn_sch;
        private MyTextBox txb_kuanhao;
        private MyTextBox txb_tiaoma;
        private MyLabel label16;
        private MyLabel label17;
        private MyGrid grid_kc;
        private MyComboBox cmb_leixing;
        private MyButton btn_sbkc;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private MyButton btn_next;
        private MyLabel lbl_page;
        private MyButton btn_prev;
        private MyButton btn_zongji;
        private MyLabel lbl_zongji;
        private CheckBox chk_0;
        private MyLabel label9;
        private MyDateTimePicker dp_start;
        private MyDateTimePicker dp_end;
        private DataGridViewTextBoxColumn col_tm;
        private DataGridViewTextBoxColumn col_kh;
        private DataGridViewTextBoxColumn col_gyskh;
        private DataGridViewTextBoxColumn col_lx;
        private DataGridViewTextBoxColumn col_pm;
        private DataGridViewTextBoxColumn col_ys;
        private DataGridViewTextBoxColumn col_cm;
        private DataGridViewTextBoxColumn col_sj;
        private DataGridViewTextBoxColumn col_sl;
    }
}