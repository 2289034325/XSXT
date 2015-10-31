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
            this.btn_sbkc.Location = new System.Drawing.Point(492, 3);
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
            this.btn_sch.Location = new System.Drawing.Point(598, 3);
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
            this.grid_kc.Location = new System.Drawing.Point(0, 30);
            this.grid_kc.Name = "grid_kc";
            this.grid_kc.ReadOnly = true;
            this.grid_kc.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_kc.RowHeadersVisible = false;
            this.grid_kc.RowTemplate.Height = 23;
            this.grid_kc.Size = new System.Drawing.Size(1013, 454);
            this.grid_kc.TabIndex = 11;
            this.grid_kc.Type = MyFormControls.MyControlType.Standard;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label17);
            this.flowLayoutPanel1.Controls.Add(this.txb_tiaoma);
            this.flowLayoutPanel1.Controls.Add(this.label16);
            this.flowLayoutPanel1.Controls.Add(this.txb_kuanhao);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.cmb_leixing);
            this.flowLayoutPanel1.Controls.Add(this.btn_sbkc);
            this.flowLayoutPanel1.Controls.Add(this.btn_sch);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1013, 30);
            this.flowLayoutPanel1.TabIndex = 12;
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
            this.ClientSize = new System.Drawing.Size(1013, 484);
            this.Controls.Add(this.grid_kc);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form_KucunYilan";
            this.Text = "库存一览";
            this.Load += new System.EventHandler(this.Form_KucunYilan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_kc)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

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