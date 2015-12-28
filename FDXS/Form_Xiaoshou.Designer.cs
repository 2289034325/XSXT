using MyFormControls;
namespace FDXS
{
    partial class Form_Xiaoshou
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label17 = new MyFormControls.MyLabel();
            this.txb_tiaoma = new MyFormControls.MyTextBox();
            this.label16 = new MyFormControls.MyLabel();
            this.txb_kuanhao = new MyFormControls.MyTextBox();
            this.label9 = new MyFormControls.MyLabel();
            this.dp_start = new MyFormControls.MyDateTimePicker();
            this.dp_end = new MyFormControls.MyDateTimePicker();
            this.btn_sch = new MyFormControls.MyButton();
            this.btn_shangbao = new MyFormControls.MyButton();
            this.grid_xs = new MyFormControls.MyGrid();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gyskh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_zk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ml = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xsy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xssj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sbsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_beizhu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_next = new MyFormControls.MyButton();
            this.lbl_page = new MyFormControls.MyLabel();
            this.btn_prev = new MyFormControls.MyButton();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_xs)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label17);
            this.flowLayoutPanel1.Controls.Add(this.txb_tiaoma);
            this.flowLayoutPanel1.Controls.Add(this.label16);
            this.flowLayoutPanel1.Controls.Add(this.txb_kuanhao);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.dp_start);
            this.flowLayoutPanel1.Controls.Add(this.dp_end);
            this.flowLayoutPanel1.Controls.Add(this.btn_sch);
            this.flowLayoutPanel1.Controls.Add(this.btn_shangbao);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1110, 30);
            this.flowLayoutPanel1.TabIndex = 12;
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
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(329, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 26;
            this.label9.Text = "销售日期";
            this.label9.Type = MyFormControls.MyControlType.Standard;
            // 
            // dp_start
            // 
            this.dp_start.Font = new System.Drawing.Font("宋体", 12F);
            this.dp_start.Location = new System.Drawing.Point(428, 3);
            this.dp_start.Name = "dp_start";
            this.dp_start.ShowCheckBox = true;
            this.dp_start.Size = new System.Drawing.Size(155, 26);
            this.dp_start.TabIndex = 27;
            this.dp_start.Type = MyFormControls.MyControlType.Special;
            // 
            // dp_end
            // 
            this.dp_end.Font = new System.Drawing.Font("宋体", 12F);
            this.dp_end.Location = new System.Drawing.Point(589, 3);
            this.dp_end.Name = "dp_end";
            this.dp_end.ShowCheckBox = true;
            this.dp_end.Size = new System.Drawing.Size(155, 26);
            this.dp_end.TabIndex = 28;
            this.dp_end.Type = MyFormControls.MyControlType.Special;
            // 
            // btn_sch
            // 
            this.btn_sch.BackColor = System.Drawing.Color.Black;
            this.btn_sch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_sch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_sch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_sch.ForeColor = System.Drawing.Color.White;
            this.btn_sch.Location = new System.Drawing.Point(750, 3);
            this.btn_sch.Name = "btn_sch";
            this.btn_sch.Size = new System.Drawing.Size(100, 26);
            this.btn_sch.TabIndex = 6;
            this.btn_sch.Text = "查询";
            this.btn_sch.Type = MyFormControls.MyControlType.Standard;
            this.btn_sch.UseVisualStyleBackColor = false;
            this.btn_sch.Click += new System.EventHandler(this.btn_sch_Click);
            // 
            // btn_shangbao
            // 
            this.btn_shangbao.BackColor = System.Drawing.Color.Black;
            this.btn_shangbao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_shangbao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_shangbao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_shangbao.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_shangbao.ForeColor = System.Drawing.Color.White;
            this.btn_shangbao.Location = new System.Drawing.Point(856, 3);
            this.btn_shangbao.Name = "btn_shangbao";
            this.btn_shangbao.Size = new System.Drawing.Size(121, 26);
            this.btn_shangbao.TabIndex = 30;
            this.btn_shangbao.Text = "上报销售数据";
            this.btn_shangbao.Type = MyFormControls.MyControlType.Special;
            this.btn_shangbao.UseVisualStyleBackColor = false;
            this.btn_shangbao.Click += new System.EventHandler(this.btn_shangbao_Click);
            // 
            // grid_xs
            // 
            this.grid_xs.AllowUserToAddRows = false;
            this.grid_xs.AllowUserToResizeRows = false;
            this.grid_xs.BackgroundColor = System.Drawing.Color.Black;
            this.grid_xs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_xs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_xs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grid_xs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_xs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_tm,
            this.col_kh,
            this.col_gyskh,
            this.col_pm,
            this.col_ys,
            this.col_cm,
            this.col_sj,
            this.col_sl,
            this.col_zk,
            this.col_ml,
            this.col_jg,
            this.col_xsy,
            this.col_xssj,
            this.col_sbsj,
            this.col_beizhu});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_xs.DefaultCellStyle = dataGridViewCellStyle5;
            this.grid_xs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_xs.EnableHeadersVisualStyles = false;
            this.grid_xs.Location = new System.Drawing.Point(0, 30);
            this.grid_xs.Name = "grid_xs";
            this.grid_xs.ReadOnly = true;
            this.grid_xs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grid_xs.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grid_xs.RowTemplate.Height = 23;
            this.grid_xs.Size = new System.Drawing.Size(1110, 424);
            this.grid_xs.TabIndex = 11;
            this.grid_xs.Type = MyFormControls.MyControlType.Standard;
            this.grid_xs.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.grid_xs_UserDeletedRow);
            this.grid_xs.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_xs_UserDeletingRow);
            // 
            // col_id
            // 
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_tm
            // 
            this.col_tm.HeaderText = "条码";
            this.col_tm.Name = "col_tm";
            this.col_tm.ReadOnly = true;
            this.col_tm.Width = 140;
            // 
            // col_kh
            // 
            this.col_kh.HeaderText = "款号";
            this.col_kh.Name = "col_kh";
            this.col_kh.ReadOnly = true;
            this.col_kh.Width = 80;
            // 
            // col_gyskh
            // 
            this.col_gyskh.HeaderText = "供应商款号";
            this.col_gyskh.Name = "col_gyskh";
            this.col_gyskh.ReadOnly = true;
            this.col_gyskh.Width = 140;
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
            this.col_sj.HeaderText = "原价";
            this.col_sj.Name = "col_sj";
            this.col_sj.ReadOnly = true;
            this.col_sj.Width = 80;
            // 
            // col_sl
            // 
            this.col_sl.HeaderText = "数量";
            this.col_sl.Name = "col_sl";
            this.col_sl.ReadOnly = true;
            this.col_sl.Width = 80;
            // 
            // col_zk
            // 
            this.col_zk.HeaderText = "折扣";
            this.col_zk.Name = "col_zk";
            this.col_zk.ReadOnly = true;
            this.col_zk.Width = 80;
            // 
            // col_ml
            // 
            this.col_ml.HeaderText = "抹零";
            this.col_ml.Name = "col_ml";
            this.col_ml.ReadOnly = true;
            this.col_ml.Width = 80;
            // 
            // col_jg
            // 
            this.col_jg.HeaderText = "价格";
            this.col_jg.Name = "col_jg";
            this.col_jg.ReadOnly = true;
            this.col_jg.Width = 80;
            // 
            // col_xsy
            // 
            this.col_xsy.HeaderText = "销售员";
            this.col_xsy.Name = "col_xsy";
            this.col_xsy.ReadOnly = true;
            // 
            // col_xssj
            // 
            this.col_xssj.HeaderText = "销售时间";
            this.col_xssj.Name = "col_xssj";
            this.col_xssj.ReadOnly = true;
            this.col_xssj.Width = 120;
            // 
            // col_sbsj
            // 
            this.col_sbsj.HeaderText = "上报时间";
            this.col_sbsj.Name = "col_sbsj";
            this.col_sbsj.ReadOnly = true;
            this.col_sbsj.Width = 120;
            // 
            // col_beizhu
            // 
            this.col_beizhu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_beizhu.HeaderText = "备注";
            this.col_beizhu.Name = "col_beizhu";
            this.col_beizhu.ReadOnly = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btn_next);
            this.flowLayoutPanel2.Controls.Add(this.lbl_page);
            this.flowLayoutPanel2.Controls.Add(this.btn_prev);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 454);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1110, 30);
            this.flowLayoutPanel2.TabIndex = 14;
            // 
            // btn_next
            // 
            this.btn_next.BackColor = System.Drawing.Color.Black;
            this.btn_next.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_next.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_next.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_next.ForeColor = System.Drawing.Color.White;
            this.btn_next.Location = new System.Drawing.Point(1007, 3);
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
            this.lbl_page.Location = new System.Drawing.Point(948, 6);
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
            this.btn_prev.Location = new System.Drawing.Point(842, 3);
            this.btn_prev.Name = "btn_prev";
            this.btn_prev.Size = new System.Drawing.Size(100, 26);
            this.btn_prev.TabIndex = 6;
            this.btn_prev.Text = "上一页";
            this.btn_prev.Type = MyFormControls.MyControlType.Standard;
            this.btn_prev.UseVisualStyleBackColor = true;
            this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);
            // 
            // Form_Xiaoshou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 484);
            this.Controls.Add(this.grid_xs);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form_Xiaoshou";
            this.Text = "销售";
            this.Load += new System.EventHandler(this.Form_KucunYilan_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_xs)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyButton btn_sch;
        private MyTextBox txb_kuanhao;
        private MyTextBox txb_tiaoma;
        private MyLabel label16;
        private MyLabel label17;
        private MyGrid grid_xs;
        private MyDateTimePicker dp_end;
        private MyDateTimePicker dp_start;
        private MyLabel label9;
        private MyButton btn_shangbao;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gyskh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ys;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_zk;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ml;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jg;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xsy;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xssj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sbsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_beizhu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private MyButton btn_next;
        private MyLabel lbl_page;
        private MyButton btn_prev;
    }
}