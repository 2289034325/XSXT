namespace FDXS
{
    partial class Form_KucunGuanli
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
            this.tb_gl = new System.Windows.Forms.TabControl();
            this.tbp_pd = new System.Windows.Forms.TabPage();
            this.grid_pd = new System.Windows.Forms.DataGridView();
            this.col_pd_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pd_tmid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pd_tm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pd_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pd_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pd_ys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pd_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pd_pdsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pd_kcsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pd_sj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_pd_hd = new System.Windows.Forms.Button();
            this.btn_pd_qk = new System.Windows.Forms.Button();
            this.tbp_xz = new System.Windows.Forms.TabPage();
            this.grid_xz = new System.Windows.Forms.DataGridView();
            this.col_xz_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_tm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_ys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_czr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_crsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xz_xgsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button19 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btn_xz_zj = new System.Windows.Forms.Button();
            this.btn_xz_cx = new System.Windows.Forms.Button();
            this.tb_gl.SuspendLayout();
            this.tbp_pd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_pd)).BeginInit();
            this.panel7.SuspendLayout();
            this.tbp_xz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_xz)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_gl
            // 
            this.tb_gl.Controls.Add(this.tbp_pd);
            this.tb_gl.Controls.Add(this.tbp_xz);
            this.tb_gl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_gl.Location = new System.Drawing.Point(0, 0);
            this.tb_gl.Name = "tb_gl";
            this.tb_gl.SelectedIndex = 0;
            this.tb_gl.Size = new System.Drawing.Size(1091, 541);
            this.tb_gl.TabIndex = 3;
            // 
            // tbp_pd
            // 
            this.tbp_pd.Controls.Add(this.grid_pd);
            this.tbp_pd.Controls.Add(this.panel7);
            this.tbp_pd.Location = new System.Drawing.Point(4, 22);
            this.tbp_pd.Name = "tbp_pd";
            this.tbp_pd.Size = new System.Drawing.Size(1083, 515);
            this.tbp_pd.TabIndex = 14;
            this.tbp_pd.Text = "库存盘点";
            this.tbp_pd.UseVisualStyleBackColor = true;
            // 
            // grid_pd
            // 
            this.grid_pd.AllowUserToAddRows = false;
            this.grid_pd.AllowUserToResizeRows = false;
            this.grid_pd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_pd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_pd_id,
            this.col_pd_tmid,
            this.col_pd_tm,
            this.col_pd_kh,
            this.col_pd_pm,
            this.col_pd_ys,
            this.col_pd_cm,
            this.col_pd_pdsl,
            this.col_pd_kcsl,
            this.col_pd_sj});
            this.grid_pd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_pd.Location = new System.Drawing.Point(0, 32);
            this.grid_pd.MultiSelect = false;
            this.grid_pd.Name = "grid_pd";
            this.grid_pd.ReadOnly = true;
            this.grid_pd.RowHeadersVisible = false;
            this.grid_pd.RowTemplate.Height = 23;
            this.grid_pd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_pd.Size = new System.Drawing.Size(1083, 483);
            this.grid_pd.TabIndex = 11;
            this.grid_pd.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.grid_pd_UserDeletedRow);
            this.grid_pd.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_pd_UserDeletingRow);
            this.grid_pd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_pd_KeyDown);
            // 
            // col_pd_id
            // 
            this.col_pd_id.HeaderText = "ID";
            this.col_pd_id.Name = "col_pd_id";
            this.col_pd_id.ReadOnly = true;
            this.col_pd_id.Visible = false;
            // 
            // col_pd_tmid
            // 
            this.col_pd_tmid.HeaderText = "条码ID";
            this.col_pd_tmid.Name = "col_pd_tmid";
            this.col_pd_tmid.ReadOnly = true;
            this.col_pd_tmid.Visible = false;
            // 
            // col_pd_tm
            // 
            this.col_pd_tm.HeaderText = "条码";
            this.col_pd_tm.Name = "col_pd_tm";
            this.col_pd_tm.ReadOnly = true;
            // 
            // col_pd_kh
            // 
            this.col_pd_kh.HeaderText = "款号";
            this.col_pd_kh.Name = "col_pd_kh";
            this.col_pd_kh.ReadOnly = true;
            // 
            // col_pd_pm
            // 
            this.col_pd_pm.HeaderText = "品名";
            this.col_pd_pm.Name = "col_pd_pm";
            this.col_pd_pm.ReadOnly = true;
            // 
            // col_pd_ys
            // 
            this.col_pd_ys.HeaderText = "颜色";
            this.col_pd_ys.Name = "col_pd_ys";
            this.col_pd_ys.ReadOnly = true;
            // 
            // col_pd_cm
            // 
            this.col_pd_cm.HeaderText = "尺码";
            this.col_pd_cm.Name = "col_pd_cm";
            this.col_pd_cm.ReadOnly = true;
            // 
            // col_pd_pdsl
            // 
            this.col_pd_pdsl.HeaderText = "盘点数量";
            this.col_pd_pdsl.Name = "col_pd_pdsl";
            this.col_pd_pdsl.ReadOnly = true;
            // 
            // col_pd_kcsl
            // 
            this.col_pd_kcsl.HeaderText = "库存数量";
            this.col_pd_kcsl.Name = "col_pd_kcsl";
            this.col_pd_kcsl.ReadOnly = true;
            // 
            // col_pd_sj
            // 
            this.col_pd_sj.HeaderText = "盘点时间";
            this.col_pd_sj.Name = "col_pd_sj";
            this.col_pd_sj.ReadOnly = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btn_pd_hd);
            this.panel7.Controls.Add(this.btn_pd_qk);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1083, 32);
            this.panel7.TabIndex = 12;
            // 
            // btn_pd_hd
            // 
            this.btn_pd_hd.Location = new System.Drawing.Point(84, 6);
            this.btn_pd_hd.Name = "btn_pd_hd";
            this.btn_pd_hd.Size = new System.Drawing.Size(75, 23);
            this.btn_pd_hd.TabIndex = 7;
            this.btn_pd_hd.Text = "核对";
            this.btn_pd_hd.UseVisualStyleBackColor = true;
            this.btn_pd_hd.Click += new System.EventHandler(this.btn_pd_hd_Click);
            // 
            // btn_pd_qk
            // 
            this.btn_pd_qk.Location = new System.Drawing.Point(3, 6);
            this.btn_pd_qk.Name = "btn_pd_qk";
            this.btn_pd_qk.Size = new System.Drawing.Size(75, 23);
            this.btn_pd_qk.TabIndex = 6;
            this.btn_pd_qk.Text = "清空";
            this.btn_pd_qk.UseVisualStyleBackColor = true;
            this.btn_pd_qk.Click += new System.EventHandler(this.btn_pd_qk_Click);
            // 
            // tbp_xz
            // 
            this.tbp_xz.Controls.Add(this.grid_xz);
            this.tbp_xz.Controls.Add(this.panel9);
            this.tbp_xz.Controls.Add(this.panel10);
            this.tbp_xz.Location = new System.Drawing.Point(4, 22);
            this.tbp_xz.Name = "tbp_xz";
            this.tbp_xz.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_xz.Size = new System.Drawing.Size(1083, 515);
            this.tbp_xz.TabIndex = 3;
            this.tbp_xz.Text = "库存修正";
            this.tbp_xz.UseVisualStyleBackColor = true;
            // 
            // grid_xz
            // 
            this.grid_xz.AllowUserToAddRows = false;
            this.grid_xz.AllowUserToResizeRows = false;
            this.grid_xz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_xz.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_xz_id,
            this.col_xz_tm,
            this.col_xz_kh,
            this.col_xz_pm,
            this.col_xz_ys,
            this.col_xz_cm,
            this.col_xz_sl,
            this.col_xz_czr,
            this.col_xz_crsj,
            this.col_xz_xgsj});
            this.grid_xz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_xz.Location = new System.Drawing.Point(3, 35);
            this.grid_xz.MultiSelect = false;
            this.grid_xz.Name = "grid_xz";
            this.grid_xz.RowHeadersVisible = false;
            this.grid_xz.RowTemplate.Height = 23;
            this.grid_xz.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_xz.Size = new System.Drawing.Size(1077, 448);
            this.grid_xz.TabIndex = 12;
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
            // col_xz_tm
            // 
            this.col_xz_tm.HeaderText = "条码";
            this.col_xz_tm.Name = "col_xz_tm";
            this.col_xz_tm.ReadOnly = true;
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
            // 
            // col_xz_ys
            // 
            this.col_xz_ys.HeaderText = "颜色";
            this.col_xz_ys.Name = "col_xz_ys";
            this.col_xz_ys.ReadOnly = true;
            // 
            // col_xz_cm
            // 
            this.col_xz_cm.HeaderText = "尺码";
            this.col_xz_cm.Name = "col_xz_cm";
            this.col_xz_cm.ReadOnly = true;
            // 
            // col_xz_sl
            // 
            this.col_xz_sl.HeaderText = "数量";
            this.col_xz_sl.Name = "col_xz_sl";
            // 
            // col_xz_czr
            // 
            this.col_xz_czr.HeaderText = "操作人";
            this.col_xz_czr.Name = "col_xz_czr";
            this.col_xz_czr.ReadOnly = true;
            // 
            // col_xz_crsj
            // 
            this.col_xz_crsj.HeaderText = "插入时间";
            this.col_xz_crsj.Name = "col_xz_crsj";
            this.col_xz_crsj.ReadOnly = true;
            // 
            // col_xz_xgsj
            // 
            this.col_xz_xgsj.HeaderText = "修改时间";
            this.col_xz_xgsj.Name = "col_xz_xgsj";
            this.col_xz_xgsj.ReadOnly = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.button19);
            this.panel9.Controls.Add(this.button30);
            this.panel9.Controls.Add(this.button31);
            this.panel9.Controls.Add(this.button32);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(3, 483);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1077, 29);
            this.panel9.TabIndex = 11;
            // 
            // button19
            // 
            this.button19.Dock = System.Windows.Forms.DockStyle.Right;
            this.button19.Location = new System.Drawing.Point(807, 0);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(75, 29);
            this.button19.TabIndex = 6;
            this.button19.Text = "总件数";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button30
            // 
            this.button30.Dock = System.Windows.Forms.DockStyle.Right;
            this.button30.Location = new System.Drawing.Point(882, 0);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(75, 29);
            this.button30.TabIndex = 3;
            this.button30.Text = "1/200";
            this.button30.UseVisualStyleBackColor = true;
            // 
            // button31
            // 
            this.button31.Dock = System.Windows.Forms.DockStyle.Right;
            this.button31.Location = new System.Drawing.Point(957, 0);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(60, 29);
            this.button31.TabIndex = 2;
            this.button31.Text = "下一页";
            this.button31.UseVisualStyleBackColor = true;
            // 
            // button32
            // 
            this.button32.Dock = System.Windows.Forms.DockStyle.Right;
            this.button32.Location = new System.Drawing.Point(1017, 0);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(60, 29);
            this.button32.TabIndex = 1;
            this.button32.Text = "上一页";
            this.button32.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btn_xz_zj);
            this.panel10.Controls.Add(this.btn_xz_cx);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(3, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1077, 32);
            this.panel10.TabIndex = 10;
            // 
            // btn_xz_zj
            // 
            this.btn_xz_zj.Location = new System.Drawing.Point(86, 3);
            this.btn_xz_zj.Name = "btn_xz_zj";
            this.btn_xz_zj.Size = new System.Drawing.Size(75, 23);
            this.btn_xz_zj.TabIndex = 7;
            this.btn_xz_zj.Text = "增加";
            this.btn_xz_zj.UseVisualStyleBackColor = true;
            this.btn_xz_zj.Click += new System.EventHandler(this.btn_xz_zj_Click);
            // 
            // btn_xz_cx
            // 
            this.btn_xz_cx.Location = new System.Drawing.Point(5, 3);
            this.btn_xz_cx.Name = "btn_xz_cx";
            this.btn_xz_cx.Size = new System.Drawing.Size(75, 23);
            this.btn_xz_cx.TabIndex = 6;
            this.btn_xz_cx.Text = "查询";
            this.btn_xz_cx.UseVisualStyleBackColor = true;
            this.btn_xz_cx.Click += new System.EventHandler(this.btn_xz_cx_Click);
            // 
            // Form_KucunGuanli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 541);
            this.Controls.Add(this.tb_gl);
            this.Name = "Form_KucunGuanli";
            this.Text = "库存管理";
            this.Load += new System.EventHandler(this.Form_KucunGuanli_Load);
            this.tb_gl.ResumeLayout(false);
            this.tbp_pd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_pd)).EndInit();
            this.panel7.ResumeLayout(false);
            this.tbp_xz.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_xz)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tb_gl;
        private System.Windows.Forms.TabPage tbp_pd;
        private System.Windows.Forms.DataGridView grid_pd;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btn_pd_hd;
        private System.Windows.Forms.Button btn_pd_qk;
        private System.Windows.Forms.TabPage tbp_xz;
        private System.Windows.Forms.DataGridView grid_xz;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btn_xz_zj;
        private System.Windows.Forms.Button btn_xz_cx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pd_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pd_tmid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pd_tm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pd_kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pd_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pd_ys;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pd_cm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pd_pdsl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pd_kcsl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pd_sj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_tm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_ys;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_cm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_czr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_crsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xz_xgsj;
    }
}