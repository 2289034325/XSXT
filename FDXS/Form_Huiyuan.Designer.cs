namespace FDXS
{
    partial class Form_Huiyuan
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
            this.components = new System.ComponentModel.Container();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_sch = new System.Windows.Forms.Button();
            this.txb_sjh = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.grid_hy = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sjh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jfsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmn_hy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmn_hy_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_hy_shangchuan = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_hy_xiazai = new System.Windows.Forms.ToolStripMenuItem();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_hy)).BeginInit();
            this.cmn_hy.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_sch);
            this.panel6.Controls.Add(this.txb_sjh);
            this.panel6.Controls.Add(this.label17);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1013, 32);
            this.panel6.TabIndex = 8;
            // 
            // btn_sch
            // 
            this.btn_sch.Location = new System.Drawing.Point(193, 3);
            this.btn_sch.Name = "btn_sch";
            this.btn_sch.Size = new System.Drawing.Size(75, 23);
            this.btn_sch.TabIndex = 6;
            this.btn_sch.Text = "查询";
            this.btn_sch.UseVisualStyleBackColor = true;
            this.btn_sch.Click += new System.EventHandler(this.btn_sch_Click);
            // 
            // txb_sjh
            // 
            this.txb_sjh.Location = new System.Drawing.Point(52, 5);
            this.txb_sjh.Name = "txb_sjh";
            this.txb_sjh.Size = new System.Drawing.Size(135, 21);
            this.txb_sjh.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "手机号";
            // 
            // grid_hy
            // 
            this.grid_hy.AllowUserToAddRows = false;
            this.grid_hy.AllowUserToDeleteRows = false;
            this.grid_hy.AllowUserToResizeRows = false;
            this.grid_hy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_hy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_sjh,
            this.col_xm,
            this.col_xb,
            this.col_nl,
            this.col_jf,
            this.col_jfsj});
            this.grid_hy.ContextMenuStrip = this.cmn_hy;
            this.grid_hy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_hy.Location = new System.Drawing.Point(0, 32);
            this.grid_hy.Name = "grid_hy";
            this.grid_hy.ReadOnly = true;
            this.grid_hy.RowHeadersVisible = false;
            this.grid_hy.RowTemplate.Height = 23;
            this.grid_hy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_hy.Size = new System.Drawing.Size(1013, 452);
            this.grid_hy.TabIndex = 11;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            // 
            // col_sjh
            // 
            this.col_sjh.HeaderText = "手机号";
            this.col_sjh.Name = "col_sjh";
            this.col_sjh.ReadOnly = true;
            // 
            // col_xm
            // 
            this.col_xm.HeaderText = "姓名";
            this.col_xm.Name = "col_xm";
            this.col_xm.ReadOnly = true;
            // 
            // col_xb
            // 
            this.col_xb.HeaderText = "性别";
            this.col_xb.Name = "col_xb";
            this.col_xb.ReadOnly = true;
            // 
            // col_nl
            // 
            this.col_nl.HeaderText = "年龄";
            this.col_nl.Name = "col_nl";
            this.col_nl.ReadOnly = true;
            // 
            // col_jf
            // 
            this.col_jf.HeaderText = "积分";
            this.col_jf.Name = "col_jf";
            this.col_jf.ReadOnly = true;
            // 
            // col_jfsj
            // 
            this.col_jfsj.HeaderText = "积分计算时间";
            this.col_jfsj.Name = "col_jfsj";
            this.col_jfsj.ReadOnly = true;
            // 
            // cmn_hy
            // 
            this.cmn_hy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmn_hy_edit,
            this.cmn_hy_shangchuan,
            this.cmn_hy_xiazai});
            this.cmn_hy.Name = "cmn_hy";
            this.cmn_hy.Size = new System.Drawing.Size(149, 70);
            // 
            // cmn_hy_edit
            // 
            this.cmn_hy_edit.Name = "cmn_hy_edit";
            this.cmn_hy_edit.Size = new System.Drawing.Size(148, 22);
            this.cmn_hy_edit.Text = "修改";
            this.cmn_hy_edit.Click += new System.EventHandler(this.cmn_hy_edit_Click);
            // 
            // cmn_hy_shangchuan
            // 
            this.cmn_hy_shangchuan.Name = "cmn_hy_shangchuan";
            this.cmn_hy_shangchuan.Size = new System.Drawing.Size(148, 22);
            this.cmn_hy_shangchuan.Text = "上传会员信息";
            this.cmn_hy_shangchuan.Click += new System.EventHandler(this.cmn_hy_shangchuan_Click);
            // 
            // cmn_hy_xiazai
            // 
            this.cmn_hy_xiazai.Name = "cmn_hy_xiazai";
            this.cmn_hy_xiazai.Size = new System.Drawing.Size(148, 22);
            this.cmn_hy_xiazai.Text = "下载会员信息";
            this.cmn_hy_xiazai.Click += new System.EventHandler(this.cmn_hy_gxxx_Click);
            // 
            // Form_Huiyuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 484);
            this.Controls.Add(this.grid_hy);
            this.Controls.Add(this.panel6);
            this.Name = "Form_Huiyuan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员";
            this.Load += new System.EventHandler(this.Form_KucunYilan_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_hy)).EndInit();
            this.cmn_hy.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btn_sch;
        private System.Windows.Forms.TextBox txb_sjh;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView grid_hy;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sjh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xb;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jf;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jfsj;
        private System.Windows.Forms.ContextMenuStrip cmn_hy;
        private System.Windows.Forms.ToolStripMenuItem cmn_hy_xiazai;
        private System.Windows.Forms.ToolStripMenuItem cmn_hy_edit;
        private System.Windows.Forms.ToolStripMenuItem cmn_hy_shangchuan;
    }
}