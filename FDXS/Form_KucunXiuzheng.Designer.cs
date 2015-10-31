using MyFormControls;
namespace FDXS
{
    partial class Form_KucunXiuzheng
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
            this.grid_xz = new MyFormControls.MyGrid();
            this.col_xz_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_tmid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_tm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_ys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_czr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_crsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_xgsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_xz_zj = new MyFormControls.MyButton();
            this.btn_xz_cx = new MyFormControls.MyButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grid_xz)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_xz
            // 
            this.grid_xz.AllowUserToAddRows = false;
            this.grid_xz.AllowUserToResizeRows = false;
            this.grid_xz.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_xz.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_xz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_xz.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_xz_id,
            this.col_xz_tmid,
            this.col_xz_tm,
            this.col_xz_kh,
            this.col_xz_pm,
            this.col_xz_ys,
            this.col_xz_cm,
            this.col_xz_sl,
            this.col_xz_czr,
            this.col_xz_crsj,
            this.col_xz_xgsj});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_xz.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_xz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_xz.EnableHeadersVisualStyles = false;
            this.grid_xz.Location = new System.Drawing.Point(0, 30);
            this.grid_xz.MultiSelect = false;
            this.grid_xz.Name = "grid_xz";
            this.grid_xz.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_xz.RowTemplate.Height = 23;
            this.grid_xz.Size = new System.Drawing.Size(1091, 511);
            this.grid_xz.TabIndex = 12;
            this.grid_xz.Type = MyFormControls.MyControlType.Standard;
            this.grid_xz.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grid_xz_CellValidating);
            this.grid_xz.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_xz_CellValueChanged);
            this.grid_xz.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.grid_xz_UserDeletedRow);
            this.grid_xz.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_xz_UserDeletingRow);
            // 
            // col_xz_id
            // 
            this.col_xz_id.HeaderText = "ID";
            this.col_xz_id.Name = "col_xz_id";
            this.col_xz_id.ReadOnly = true;
            this.col_xz_id.Visible = false;
            // 
            // col_xz_tmid
            // 
            this.col_xz_tmid.HeaderText = "条码ID";
            this.col_xz_tmid.Name = "col_xz_tmid";
            this.col_xz_tmid.Visible = false;
            // 
            // col_xz_tm
            // 
            this.col_xz_tm.HeaderText = "条码";
            this.col_xz_tm.Name = "col_xz_tm";
            this.col_xz_tm.ReadOnly = true;
            this.col_xz_tm.Width = 140;
            // 
            // col_xz_kh
            // 
            this.col_xz_kh.HeaderText = "款号";
            this.col_xz_kh.Name = "col_xz_kh";
            this.col_xz_kh.ReadOnly = true;
            // 
            // col_xz_pm
            // 
            this.col_xz_pm.HeaderText = "品名";
            this.col_xz_pm.Name = "col_xz_pm";
            this.col_xz_pm.ReadOnly = true;
            this.col_xz_pm.Width = 120;
            // 
            // col_xz_ys
            // 
            this.col_xz_ys.HeaderText = "颜色";
            this.col_xz_ys.Name = "col_xz_ys";
            this.col_xz_ys.ReadOnly = true;
            this.col_xz_ys.Width = 80;
            // 
            // col_xz_cm
            // 
            this.col_xz_cm.HeaderText = "尺码";
            this.col_xz_cm.Name = "col_xz_cm";
            this.col_xz_cm.ReadOnly = true;
            this.col_xz_cm.Width = 80;
            // 
            // col_xz_sl
            // 
            this.col_xz_sl.HeaderText = "数量";
            this.col_xz_sl.Name = "col_xz_sl";
            this.col_xz_sl.Width = 80;
            // 
            // col_xz_czr
            // 
            this.col_xz_czr.HeaderText = "操作人";
            this.col_xz_czr.Name = "col_xz_czr";
            this.col_xz_czr.ReadOnly = true;
            this.col_xz_czr.Width = 110;
            // 
            // col_xz_crsj
            // 
            this.col_xz_crsj.HeaderText = "插入时间";
            this.col_xz_crsj.Name = "col_xz_crsj";
            this.col_xz_crsj.ReadOnly = true;
            this.col_xz_crsj.Width = 120;
            // 
            // col_xz_xgsj
            // 
            this.col_xz_xgsj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_xz_xgsj.HeaderText = "修改时间";
            this.col_xz_xgsj.Name = "col_xz_xgsj";
            this.col_xz_xgsj.ReadOnly = true;
            // 
            // btn_xz_zj
            // 
            this.btn_xz_zj.BackColor = System.Drawing.Color.Black;
            this.btn_xz_zj.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_xz_zj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_xz_zj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xz_zj.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_xz_zj.ForeColor = System.Drawing.Color.White;
            this.btn_xz_zj.Location = new System.Drawing.Point(3, 3);
            this.btn_xz_zj.Name = "btn_xz_zj";
            this.btn_xz_zj.Size = new System.Drawing.Size(100, 26);
            this.btn_xz_zj.TabIndex = 7;
            this.btn_xz_zj.Text = "增加";
            this.btn_xz_zj.Type = MyFormControls.MyControlType.Standard;
            this.btn_xz_zj.UseVisualStyleBackColor = false;
            this.btn_xz_zj.Click += new System.EventHandler(this.btn_xz_zj_Click);
            // 
            // btn_xz_cx
            // 
            this.btn_xz_cx.BackColor = System.Drawing.Color.Black;
            this.btn_xz_cx.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_xz_cx.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_xz_cx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xz_cx.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_xz_cx.ForeColor = System.Drawing.Color.White;
            this.btn_xz_cx.Location = new System.Drawing.Point(109, 3);
            this.btn_xz_cx.Name = "btn_xz_cx";
            this.btn_xz_cx.Size = new System.Drawing.Size(100, 26);
            this.btn_xz_cx.TabIndex = 6;
            this.btn_xz_cx.Text = "查询";
            this.btn_xz_cx.Type = MyFormControls.MyControlType.Standard;
            this.btn_xz_cx.UseVisualStyleBackColor = false;
            this.btn_xz_cx.Click += new System.EventHandler(this.btn_xz_cx_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_xz_zj);
            this.flowLayoutPanel1.Controls.Add(this.btn_xz_cx);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1091, 30);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // Form_KucunXiuzheng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 541);
            this.Controls.Add(this.grid_xz);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form_KucunXiuzheng";
            this.Text = "库存修正";
            this.Load += new System.EventHandler(this.Form_KucunGuanli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_xz)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MyGrid grid_xz;
        private MyButton btn_xz_zj;
        private MyButton btn_xz_cx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_tmid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_tm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_ys;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_cm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_czr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_crsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_xgsj;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}