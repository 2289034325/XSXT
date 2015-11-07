namespace CKGL.CK
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_shangbao = new System.Windows.Forms.Button();
            this.cmb_leixing = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_sch = new System.Windows.Forms.Button();
            this.txb_kuanhao = new System.Windows.Forms.TextBox();
            this.txb_tiaoma = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.grid_kc = new System.Windows.Forms.DataGridView();
            this.col_tm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_kh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gyskh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_lx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_kc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_shangbao);
            this.panel6.Controls.Add(this.cmb_leixing);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.btn_sch);
            this.panel6.Controls.Add(this.txb_kuanhao);
            this.panel6.Controls.Add(this.txb_tiaoma);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Controls.Add(this.label17);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1013, 32);
            this.panel6.TabIndex = 8;
            // 
            // btn_shangbao
            // 
            this.btn_shangbao.Location = new System.Drawing.Point(498, 4);
            this.btn_shangbao.Name = "btn_shangbao";
            this.btn_shangbao.Size = new System.Drawing.Size(75, 23);
            this.btn_shangbao.TabIndex = 12;
            this.btn_shangbao.Text = "上报库存";
            this.btn_shangbao.UseVisualStyleBackColor = true;
            this.btn_shangbao.Click += new System.EventHandler(this.btn_shangbao_Click);
            // 
            // cmb_leixing
            // 
            this.cmb_leixing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_leixing.FormattingEnabled = true;
            this.cmb_leixing.Location = new System.Drawing.Point(334, 6);
            this.cmb_leixing.Name = "cmb_leixing";
            this.cmb_leixing.Size = new System.Drawing.Size(77, 20);
            this.cmb_leixing.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(299, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "类型";
            // 
            // btn_sch
            // 
            this.btn_sch.Location = new System.Drawing.Point(417, 3);
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
            // grid_kc
            // 
            this.grid_kc.AllowUserToAddRows = false;
            this.grid_kc.AllowUserToDeleteRows = false;
            this.grid_kc.AllowUserToResizeRows = false;
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
            this.grid_kc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_kc.Location = new System.Drawing.Point(0, 32);
            this.grid_kc.Name = "grid_kc";
            this.grid_kc.ReadOnly = true;
            this.grid_kc.RowHeadersVisible = false;
            this.grid_kc.RowTemplate.Height = 23;
            this.grid_kc.Size = new System.Drawing.Size(1013, 452);
            this.grid_kc.TabIndex = 11;
            // 
            // col_tm
            // 
            this.col_tm.HeaderText = "条码";
            this.col_tm.Name = "col_tm";
            this.col_tm.ReadOnly = true;
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
            // 
            // col_lx
            // 
            this.col_lx.HeaderText = "类型";
            this.col_lx.Name = "col_lx";
            this.col_lx.ReadOnly = true;
            // 
            // col_pm
            // 
            this.col_pm.HeaderText = "品名";
            this.col_pm.Name = "col_pm";
            this.col_pm.ReadOnly = true;
            // 
            // col_ys
            // 
            this.col_ys.HeaderText = "颜色";
            this.col_ys.Name = "col_ys";
            this.col_ys.ReadOnly = true;
            // 
            // col_cm
            // 
            this.col_cm.HeaderText = "尺码";
            this.col_cm.Name = "col_cm";
            this.col_cm.ReadOnly = true;
            // 
            // col_sj
            // 
            this.col_sj.HeaderText = "售价";
            this.col_sj.Name = "col_sj";
            this.col_sj.ReadOnly = true;
            // 
            // col_sl
            // 
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
            this.Controls.Add(this.panel6);
            this.Name = "Form_KucunYilan";
            this.Text = "库存一览";
            this.Load += new System.EventHandler(this.Form_KucunYilan_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_kc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_sch;
        private System.Windows.Forms.TextBox txb_kuanhao;
        private System.Windows.Forms.TextBox txb_tiaoma;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView grid_kc;
        private System.Windows.Forms.ComboBox cmb_leixing;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_kh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gyskh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_lx;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ys;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sl;
        private System.Windows.Forms.Button btn_shangbao;
    }
}