using MyFormControls;
namespace FDXS
{
    partial class Form_Tiaomaxinxi
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
            this.grid_tm = new MyFormControls.MyGrid();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gyskh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_lx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gxsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dp_end = new MyFormControls.MyDateTimePicker();
            this.dp_start = new MyFormControls.MyDateTimePicker();
            this.cmb_lx = new MyFormControls.MyComboBox();
            this.btn_xzzdtm = new MyFormControls.MyButton();
            this.btn_xzzxtm = new MyFormControls.MyButton();
            this.label2 = new MyFormControls.MyLabel();
            this.btn_sch = new MyFormControls.MyButton();
            this.txb_kh = new MyFormControls.MyTextBox();
            this.txb_tm = new MyFormControls.MyTextBox();
            this.label4 = new MyFormControls.MyLabel();
            this.label5 = new MyFormControls.MyLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grid_tm)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_tm
            // 
            this.grid_tm.AllowUserToAddRows = false;
            this.grid_tm.AllowUserToDeleteRows = false;
            this.grid_tm.AllowUserToResizeRows = false;
            this.grid_tm.BackgroundColor = System.Drawing.Color.Black;
            this.grid_tm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_tm.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_tm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_tm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_tm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_tm,
            this.col_kh,
            this.col_gys,
            this.col_gyskh,
            this.col_lx,
            this.col_pm,
            this.col_ys,
            this.col_cm,
            this.col_sj,
            this.col_gxsj});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_tm.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_tm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_tm.EnableHeadersVisualStyles = false;
            this.grid_tm.Location = new System.Drawing.Point(0, 30);
            this.grid_tm.Name = "grid_tm";
            this.grid_tm.ReadOnly = true;
            this.grid_tm.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_tm.RowTemplate.Height = 23;
            this.grid_tm.Size = new System.Drawing.Size(1166, 468);
            this.grid_tm.TabIndex = 14;
            this.grid_tm.Type = MyFormControls.MyControlType.Standard;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
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
            // col_gys
            // 
            this.col_gys.HeaderText = "供应商";
            this.col_gys.Name = "col_gys";
            this.col_gys.ReadOnly = true;
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
            this.col_pm.Width = 80;
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
            // col_gxsj
            // 
            this.col_gxsj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_gxsj.HeaderText = "更新时间";
            this.col_gxsj.Name = "col_gxsj";
            this.col_gxsj.ReadOnly = true;
            // 
            // dp_end
            // 
            this.dp_end.Font = new System.Drawing.Font("宋体", 12F);
            this.dp_end.Location = new System.Drawing.Point(770, 3);
            this.dp_end.Name = "dp_end";
            this.dp_end.Size = new System.Drawing.Size(131, 26);
            this.dp_end.TabIndex = 30;
            this.dp_end.Type = MyFormControls.MyControlType.Special;
            // 
            // dp_start
            // 
            this.dp_start.Font = new System.Drawing.Font("宋体", 12F);
            this.dp_start.Location = new System.Drawing.Point(633, 3);
            this.dp_start.Name = "dp_start";
            this.dp_start.Size = new System.Drawing.Size(131, 26);
            this.dp_start.TabIndex = 29;
            this.dp_start.Type = MyFormControls.MyControlType.Special;
            // 
            // cmb_lx
            // 
            this.cmb_lx.BackColor = System.Drawing.Color.Black;
            this.cmb_lx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_lx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_lx.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.cmb_lx.ForeColor = System.Drawing.Color.White;
            this.cmb_lx.FormattingEnabled = true;
            this.cmb_lx.HighlightBackColor = System.Drawing.Color.White;
            this.cmb_lx.HighlightForeColor = System.Drawing.Color.Black;
            this.cmb_lx.Location = new System.Drawing.Point(353, 3);
            this.cmb_lx.Name = "cmb_lx";
            this.cmb_lx.Size = new System.Drawing.Size(100, 27);
            this.cmb_lx.TabIndex = 13;
            this.cmb_lx.Type = MyFormControls.MyControlType.Standard;
            // 
            // btn_xzzdtm
            // 
            this.btn_xzzdtm.BackColor = System.Drawing.Color.Black;
            this.btn_xzzdtm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_xzzdtm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_xzzdtm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xzzdtm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_xzzdtm.ForeColor = System.Drawing.Color.White;
            this.btn_xzzdtm.Location = new System.Drawing.Point(907, 3);
            this.btn_xzzdtm.Name = "btn_xzzdtm";
            this.btn_xzzdtm.Size = new System.Drawing.Size(128, 26);
            this.btn_xzzdtm.TabIndex = 12;
            this.btn_xzzdtm.Text = "下载指定条码";
            this.btn_xzzdtm.Type = MyFormControls.MyControlType.Special;
            this.btn_xzzdtm.UseVisualStyleBackColor = false;
            this.btn_xzzdtm.Click += new System.EventHandler(this.btn_xzzdtm_Click);
            // 
            // btn_xzzxtm
            // 
            this.btn_xzzxtm.BackColor = System.Drawing.Color.Black;
            this.btn_xzzxtm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_xzzxtm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_xzzxtm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xzzxtm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_xzzxtm.ForeColor = System.Drawing.Color.White;
            this.btn_xzzxtm.Location = new System.Drawing.Point(527, 3);
            this.btn_xzzxtm.Name = "btn_xzzxtm";
            this.btn_xzzxtm.Size = new System.Drawing.Size(100, 26);
            this.btn_xzzxtm.TabIndex = 11;
            this.btn_xzzxtm.Text = "下载条码";
            this.btn_xzzxtm.Type = MyFormControls.MyControlType.Standard;
            this.btn_xzzxtm.UseVisualStyleBackColor = false;
            this.btn_xzzxtm.Click += new System.EventHandler(this.btn_xzzxtm_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(296, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "类型";
            this.label2.Type = MyFormControls.MyControlType.Standard;
            // 
            // btn_sch
            // 
            this.btn_sch.BackColor = System.Drawing.Color.Black;
            this.btn_sch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_sch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_sch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_sch.ForeColor = System.Drawing.Color.White;
            this.btn_sch.Location = new System.Drawing.Point(459, 3);
            this.btn_sch.Name = "btn_sch";
            this.btn_sch.Size = new System.Drawing.Size(62, 26);
            this.btn_sch.TabIndex = 6;
            this.btn_sch.Text = "查询";
            this.btn_sch.Type = MyFormControls.MyControlType.Special;
            this.btn_sch.UseVisualStyleBackColor = false;
            this.btn_sch.Click += new System.EventHandler(this.btn_sch_Click);
            // 
            // txb_kh
            // 
            this.txb_kh.BackColor = System.Drawing.Color.Black;
            this.txb_kh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_kh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_kh.ForeColor = System.Drawing.Color.White;
            this.txb_kh.Location = new System.Drawing.Point(223, 3);
            this.txb_kh.Name = "txb_kh";
            this.txb_kh.Size = new System.Drawing.Size(67, 26);
            this.txb_kh.TabIndex = 4;
            this.txb_kh.Type = MyFormControls.MyControlType.Special;
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
            this.txb_tm.TabIndex = 3;
            this.txb_tm.Type = MyFormControls.MyControlType.Standard;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(166, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "款号";
            this.label4.Type = MyFormControls.MyControlType.Standard;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "条码";
            this.label5.Type = MyFormControls.MyControlType.Standard;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.txb_tm);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.txb_kh);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.cmb_lx);
            this.flowLayoutPanel1.Controls.Add(this.btn_sch);
            this.flowLayoutPanel1.Controls.Add(this.btn_xzzxtm);
            this.flowLayoutPanel1.Controls.Add(this.dp_start);
            this.flowLayoutPanel1.Controls.Add(this.dp_end);
            this.flowLayoutPanel1.Controls.Add(this.btn_xzzdtm);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1166, 30);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // Form_Tiaomaxinxi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 498);
            this.Controls.Add(this.grid_tm);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form_Tiaomaxinxi";
            this.Text = "条码信息";
            this.Load += new System.EventHandler(this.Form_Tiaomaxinxi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_tm)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyGrid grid_tm;
        private MyLabel label2;
        private MyButton btn_sch;
        private MyTextBox txb_kh;
        private MyTextBox txb_tm;
        private MyLabel label4;
        private MyLabel label5;
        private MyButton btn_xzzdtm;
        private MyButton btn_xzzxtm;
        private MyComboBox cmb_lx;
        private MyDateTimePicker dp_end;
        private MyDateTimePicker dp_start;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gys;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gyskh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_lx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ys;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gxsj;
    }
}