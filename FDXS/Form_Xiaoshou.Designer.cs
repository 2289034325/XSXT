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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid_xs = new System.Windows.Forms.DataGridView();
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_shangbao = new System.Windows.Forms.Button();
            this.dp_end = new System.Windows.Forms.DateTimePicker();
            this.dp_start = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_sch = new System.Windows.Forms.Button();
            this.txb_kuanhao = new System.Windows.Forms.TextBox();
            this.txb_tiaoma = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_xs)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_xs
            // 
            this.grid_xs.AllowUserToAddRows = false;
            this.grid_xs.AllowUserToResizeRows = false;
            this.grid_xs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_xs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            this.grid_xs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_xs.Location = new System.Drawing.Point(0, 32);
            this.grid_xs.Name = "grid_xs";
            this.grid_xs.ReadOnly = true;
            this.grid_xs.RowTemplate.Height = 23;
            this.grid_xs.Size = new System.Drawing.Size(1110, 452);
            this.grid_xs.TabIndex = 11;
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
            this.col_tm.Width = 54;
            // 
            // col_kh
            // 
            this.col_kh.HeaderText = "款号";
            this.col_kh.Name = "col_kh";
            this.col_kh.ReadOnly = true;
            this.col_kh.Width = 54;
            // 
            // col_gyskh
            // 
            this.col_gyskh.HeaderText = "供应商款号";
            this.col_gyskh.Name = "col_gyskh";
            this.col_gyskh.ReadOnly = true;
            this.col_gyskh.Width = 90;
            // 
            // col_pm
            // 
            this.col_pm.HeaderText = "品名";
            this.col_pm.Name = "col_pm";
            this.col_pm.ReadOnly = true;
            this.col_pm.Width = 54;
            // 
            // col_ys
            // 
            this.col_ys.HeaderText = "颜色";
            this.col_ys.Name = "col_ys";
            this.col_ys.ReadOnly = true;
            this.col_ys.Width = 54;
            // 
            // col_cm
            // 
            this.col_cm.HeaderText = "尺码";
            this.col_cm.Name = "col_cm";
            this.col_cm.ReadOnly = true;
            this.col_cm.Width = 54;
            // 
            // col_sj
            // 
            this.col_sj.HeaderText = "原价";
            this.col_sj.Name = "col_sj";
            this.col_sj.ReadOnly = true;
            this.col_sj.Width = 54;
            // 
            // col_sl
            // 
            this.col_sl.HeaderText = "数量";
            this.col_sl.Name = "col_sl";
            this.col_sl.ReadOnly = true;
            this.col_sl.Width = 54;
            // 
            // col_zk
            // 
            this.col_zk.HeaderText = "折扣";
            this.col_zk.Name = "col_zk";
            this.col_zk.ReadOnly = true;
            this.col_zk.Width = 54;
            // 
            // col_ml
            // 
            this.col_ml.HeaderText = "抹零";
            this.col_ml.Name = "col_ml";
            this.col_ml.ReadOnly = true;
            this.col_ml.Width = 54;
            // 
            // col_jg
            // 
            this.col_jg.HeaderText = "价格";
            this.col_jg.Name = "col_jg";
            this.col_jg.ReadOnly = true;
            this.col_jg.Width = 54;
            // 
            // col_xsy
            // 
            this.col_xsy.HeaderText = "销售员";
            this.col_xsy.Name = "col_xsy";
            this.col_xsy.ReadOnly = true;
            this.col_xsy.Width = 66;
            // 
            // col_xssj
            // 
            this.col_xssj.HeaderText = "销售时间";
            this.col_xssj.Name = "col_xssj";
            this.col_xssj.ReadOnly = true;
            this.col_xssj.Width = 78;
            // 
            // col_sbsj
            // 
            this.col_sbsj.HeaderText = "上报时间";
            this.col_sbsj.Name = "col_sbsj";
            this.col_sbsj.ReadOnly = true;
            this.col_sbsj.Width = 78;
            // 
            // col_beizhu
            // 
            this.col_beizhu.HeaderText = "备注";
            this.col_beizhu.Name = "col_beizhu";
            this.col_beizhu.ReadOnly = true;
            this.col_beizhu.Width = 54;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_shangbao);
            this.panel6.Controls.Add(this.dp_end);
            this.panel6.Controls.Add(this.dp_start);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.btn_sch);
            this.panel6.Controls.Add(this.txb_kuanhao);
            this.panel6.Controls.Add(this.txb_tiaoma);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Controls.Add(this.label17);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1110, 32);
            this.panel6.TabIndex = 8;
            // 
            // btn_shangbao
            // 
            this.btn_shangbao.Location = new System.Drawing.Point(774, 3);
            this.btn_shangbao.Name = "btn_shangbao";
            this.btn_shangbao.Size = new System.Drawing.Size(89, 23);
            this.btn_shangbao.TabIndex = 30;
            this.btn_shangbao.Text = "上报销售数据";
            this.btn_shangbao.UseVisualStyleBackColor = true;
            this.btn_shangbao.Click += new System.EventHandler(this.btn_shangbao_Click);
            // 
            // dp_end
            // 
            this.dp_end.Location = new System.Drawing.Point(484, 5);
            this.dp_end.Name = "dp_end";
            this.dp_end.ShowCheckBox = true;
            this.dp_end.Size = new System.Drawing.Size(122, 21);
            this.dp_end.TabIndex = 28;
            // 
            // dp_start
            // 
            this.dp_start.Location = new System.Drawing.Point(358, 5);
            this.dp_start.Name = "dp_start";
            this.dp_start.ShowCheckBox = true;
            this.dp_start.Size = new System.Drawing.Size(120, 21);
            this.dp_start.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(299, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 26;
            this.label9.Text = "销售日期";
            // 
            // btn_sch
            // 
            this.btn_sch.Location = new System.Drawing.Point(612, 3);
            this.btn_sch.Name = "btn_sch";
            this.btn_sch.Size = new System.Drawing.Size(75, 23);
            this.btn_sch.TabIndex = 6;
            this.btn_sch.Text = "查询";
            this.btn_sch.UseVisualStyleBackColor = true;
            this.btn_sch.Click += new System.EventHandler(this.btn_sch_Click);
            // 
            // txb_kuanhao
            // 
            this.txb_kuanhao.Location = new System.Drawing.Point(216, 5);
            this.txb_kuanhao.Name = "txb_kuanhao";
            this.txb_kuanhao.Size = new System.Drawing.Size(77, 21);
            this.txb_kuanhao.TabIndex = 4;
            // 
            // txb_tiaoma
            // 
            this.txb_tiaoma.Location = new System.Drawing.Point(40, 5);
            this.txb_tiaoma.Name = "txb_tiaoma";
            this.txb_tiaoma.Size = new System.Drawing.Size(135, 21);
            this.txb_tiaoma.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(181, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "款号";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "条码";
            // 
            // Form_Xiaoshou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 484);
            this.Controls.Add(this.grid_xs);
            this.Controls.Add(this.panel6);
            this.Name = "Form_Xiaoshou";
            this.Text = "销售";
            this.Load += new System.EventHandler(this.Form_KucunYilan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_xs)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btn_sch;
        private System.Windows.Forms.TextBox txb_kuanhao;
        private System.Windows.Forms.TextBox txb_tiaoma;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView grid_xs;
        private System.Windows.Forms.DateTimePicker dp_end;
        private System.Windows.Forms.DateTimePicker dp_start;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_shangbao;
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
    }
}