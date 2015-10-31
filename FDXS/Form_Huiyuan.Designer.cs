using MyFormControls;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_sch = new MyFormControls.MyButton();
            this.txb_sjh = new MyFormControls.MyTextBox();
            this.label17 = new MyFormControls.MyLabel();
            this.grid_hy = new MyFormControls.MyGrid();
            this.cmn_hy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmn_hy_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_hy_shangchuan = new System.Windows.Forms.ToolStripMenuItem();
            this.cmn_hy_xiazai = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sjh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jfsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_hy)).BeginInit();
            this.cmn_hy.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_sch
            // 
            this.btn_sch.BackColor = System.Drawing.Color.Black;
            this.btn_sch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_sch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_sch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_sch.ForeColor = System.Drawing.Color.White;
            this.btn_sch.Location = new System.Drawing.Point(222, 3);
            this.btn_sch.Name = "btn_sch";
            this.btn_sch.Size = new System.Drawing.Size(100, 26);
            this.btn_sch.TabIndex = 6;
            this.btn_sch.Text = "查询";
            this.btn_sch.Type = MyFormControls.MyControlType.Standard;
            this.btn_sch.UseVisualStyleBackColor = false;
            this.btn_sch.Click += new System.EventHandler(this.btn_sch_Click);
            // 
            // txb_sjh
            // 
            this.txb_sjh.BackColor = System.Drawing.Color.Black;
            this.txb_sjh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_sjh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_sjh.ForeColor = System.Drawing.Color.White;
            this.txb_sjh.Location = new System.Drawing.Point(81, 3);
            this.txb_sjh.Name = "txb_sjh";
            this.txb_sjh.Size = new System.Drawing.Size(135, 26);
            this.txb_sjh.TabIndex = 3;
            this.txb_sjh.Type = MyFormControls.MyControlType.Standard;
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
            this.label17.Size = new System.Drawing.Size(72, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "手机号";
            this.label17.Type = MyFormControls.MyControlType.Standard;
            // 
            // grid_hy
            // 
            this.grid_hy.AllowUserToAddRows = false;
            this.grid_hy.AllowUserToDeleteRows = false;
            this.grid_hy.AllowUserToResizeRows = false;
            this.grid_hy.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_hy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_hy.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_hy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_hy.EnableHeadersVisualStyles = false;
            this.grid_hy.Location = new System.Drawing.Point(0, 30);
            this.grid_hy.Name = "grid_hy";
            this.grid_hy.ReadOnly = true;
            this.grid_hy.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_hy.RowHeadersVisible = false;
            this.grid_hy.RowTemplate.Height = 23;
            this.grid_hy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_hy.Size = new System.Drawing.Size(1013, 454);
            this.grid_hy.TabIndex = 11;
            this.grid_hy.Type = MyFormControls.MyControlType.Standard;
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label17);
            this.flowLayoutPanel1.Controls.Add(this.txb_sjh);
            this.flowLayoutPanel1.Controls.Add(this.btn_sch);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1013, 30);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Width = 50;
            // 
            // col_sjh
            // 
            this.col_sjh.HeaderText = "手机号";
            this.col_sjh.Name = "col_sjh";
            this.col_sjh.ReadOnly = true;
            this.col_sjh.Width = 150;
            // 
            // col_xm
            // 
            this.col_xm.HeaderText = "姓名";
            this.col_xm.Name = "col_xm";
            this.col_xm.ReadOnly = true;
            this.col_xm.Width = 150;
            // 
            // col_xb
            // 
            this.col_xb.HeaderText = "性别";
            this.col_xb.Name = "col_xb";
            this.col_xb.ReadOnly = true;
            this.col_xb.Width = 80;
            // 
            // col_nl
            // 
            this.col_nl.HeaderText = "年龄";
            this.col_nl.Name = "col_nl";
            this.col_nl.ReadOnly = true;
            this.col_nl.Width = 80;
            // 
            // col_jf
            // 
            this.col_jf.HeaderText = "积分";
            this.col_jf.Name = "col_jf";
            this.col_jf.ReadOnly = true;
            // 
            // col_jfsj
            // 
            this.col_jfsj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_jfsj.HeaderText = "积分计算时间";
            this.col_jfsj.Name = "col_jfsj";
            this.col_jfsj.ReadOnly = true;
            // 
            // Form_Huiyuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 484);
            this.Controls.Add(this.grid_hy);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form_Huiyuan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会员";
            this.Load += new System.EventHandler(this.Form_KucunYilan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_hy)).EndInit();
            this.cmn_hy.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyButton btn_sch;
        private MyTextBox txb_sjh;
        private MyLabel label17;
        private MyGrid grid_hy;
        private System.Windows.Forms.ContextMenuStrip cmn_hy;
        private System.Windows.Forms.ToolStripMenuItem cmn_hy_xiazai;
        private System.Windows.Forms.ToolStripMenuItem cmn_hy_edit;
        private System.Windows.Forms.ToolStripMenuItem cmn_hy_shangchuan;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sjh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xb;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jf;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jfsj;
    }
}