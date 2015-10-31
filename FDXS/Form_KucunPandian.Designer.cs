using MyFormControls;
namespace FDXS
{
    partial class Form_KucunPandian
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
            this.grid_pd = new MyFormControls.MyGrid();
            this.txb_tm = new MyFormControls.MyTextBox();
            this.btn_wfsm = new MyFormControls.MyButton();
            this.btn_pd_hd = new MyFormControls.MyButton();
            this.btn_pd_qk = new MyFormControls.MyButton();
            this.cmn = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmn_xzkc = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
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
            ((System.ComponentModel.ISupportInitialize)(this.grid_pd)).BeginInit();
            this.cmn.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_pd
            // 
            this.grid_pd.AllowUserToAddRows = false;
            this.grid_pd.AllowUserToResizeRows = false;
            this.grid_pd.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_pd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_pd.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_pd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_pd.EnableHeadersVisualStyles = false;
            this.grid_pd.Location = new System.Drawing.Point(0, 30);
            this.grid_pd.MultiSelect = false;
            this.grid_pd.Name = "grid_pd";
            this.grid_pd.ReadOnly = true;
            this.grid_pd.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_pd.RowTemplate.Height = 23;
            this.grid_pd.Size = new System.Drawing.Size(1091, 511);
            this.grid_pd.TabIndex = 11;
            this.grid_pd.Type = MyFormControls.MyControlType.Standard;
            this.grid_pd.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_pd_CellValueChanged);
            this.grid_pd.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.grid_pd_RowStateChanged);
            this.grid_pd.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.grid_pd_UserDeletedRow);
            this.grid_pd.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_pd_UserDeletingRow);
            this.grid_pd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_pd_KeyDown);
            // 
            // txb_tm
            // 
            this.txb_tm.BackColor = System.Drawing.Color.Black;
            this.txb_tm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_tm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_tm.ForeColor = System.Drawing.Color.White;
            this.txb_tm.Location = new System.Drawing.Point(215, 3);
            this.txb_tm.Name = "txb_tm";
            this.txb_tm.Size = new System.Drawing.Size(221, 26);
            this.txb_tm.TabIndex = 9;
            this.txb_tm.Type = MyFormControls.MyControlType.Special;
            // 
            // btn_wfsm
            // 
            this.btn_wfsm.BackColor = System.Drawing.Color.Black;
            this.btn_wfsm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_wfsm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_wfsm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_wfsm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_wfsm.ForeColor = System.Drawing.Color.White;
            this.btn_wfsm.Location = new System.Drawing.Point(442, 3);
            this.btn_wfsm.Name = "btn_wfsm";
            this.btn_wfsm.Size = new System.Drawing.Size(187, 26);
            this.btn_wfsm.TabIndex = 8;
            this.btn_wfsm.Text = "输入无法扫描的条码";
            this.btn_wfsm.Type = MyFormControls.MyControlType.Special;
            this.btn_wfsm.UseVisualStyleBackColor = true;
            this.btn_wfsm.Click += new System.EventHandler(this.btn_wfsm_Click);
            // 
            // btn_pd_hd
            // 
            this.btn_pd_hd.BackColor = System.Drawing.Color.Black;
            this.btn_pd_hd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_pd_hd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_pd_hd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pd_hd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_pd_hd.ForeColor = System.Drawing.Color.White;
            this.btn_pd_hd.Location = new System.Drawing.Point(3, 3);
            this.btn_pd_hd.Name = "btn_pd_hd";
            this.btn_pd_hd.Size = new System.Drawing.Size(100, 26);
            this.btn_pd_hd.TabIndex = 7;
            this.btn_pd_hd.Text = "核对";
            this.btn_pd_hd.Type = MyFormControls.MyControlType.Standard;
            this.btn_pd_hd.UseVisualStyleBackColor = true;
            this.btn_pd_hd.Click += new System.EventHandler(this.btn_pd_hd_Click);
            // 
            // btn_pd_qk
            // 
            this.btn_pd_qk.BackColor = System.Drawing.Color.Black;
            this.btn_pd_qk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_pd_qk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_pd_qk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pd_qk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_pd_qk.ForeColor = System.Drawing.Color.White;
            this.btn_pd_qk.Location = new System.Drawing.Point(109, 3);
            this.btn_pd_qk.Name = "btn_pd_qk";
            this.btn_pd_qk.Size = new System.Drawing.Size(100, 26);
            this.btn_pd_qk.TabIndex = 6;
            this.btn_pd_qk.Text = "清空";
            this.btn_pd_qk.Type = MyFormControls.MyControlType.Standard;
            this.btn_pd_qk.UseVisualStyleBackColor = true;
            this.btn_pd_qk.Click += new System.EventHandler(this.btn_pd_qk_Click);
            // 
            // cmn
            // 
            this.cmn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmn_xzkc});
            this.cmn.Name = "cmn";
            this.cmn.Size = new System.Drawing.Size(153, 48);
            // 
            // cmn_xzkc
            // 
            this.cmn_xzkc.Name = "cmn_xzkc";
            this.cmn_xzkc.Size = new System.Drawing.Size(152, 22);
            this.cmn_xzkc.Text = "修正库存";
            this.cmn_xzkc.Click += new System.EventHandler(this.cmn_xzkc_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_pd_hd);
            this.flowLayoutPanel1.Controls.Add(this.btn_pd_qk);
            this.flowLayoutPanel1.Controls.Add(this.txb_tm);
            this.flowLayoutPanel1.Controls.Add(this.btn_wfsm);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1091, 30);
            this.flowLayoutPanel1.TabIndex = 13;
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
            this.col_pd_tm.Width = 130;
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
            this.col_pd_pm.Width = 120;
            // 
            // col_pd_ys
            // 
            this.col_pd_ys.HeaderText = "颜色";
            this.col_pd_ys.Name = "col_pd_ys";
            this.col_pd_ys.ReadOnly = true;
            this.col_pd_ys.Width = 80;
            // 
            // col_pd_cm
            // 
            this.col_pd_cm.HeaderText = "尺码";
            this.col_pd_cm.Name = "col_pd_cm";
            this.col_pd_cm.ReadOnly = true;
            this.col_pd_cm.Width = 80;
            // 
            // col_pd_pdsl
            // 
            this.col_pd_pdsl.HeaderText = "盘点数量";
            this.col_pd_pdsl.Name = "col_pd_pdsl";
            this.col_pd_pdsl.ReadOnly = true;
            this.col_pd_pdsl.Width = 120;
            // 
            // col_pd_kcsl
            // 
            this.col_pd_kcsl.HeaderText = "库存数量";
            this.col_pd_kcsl.Name = "col_pd_kcsl";
            this.col_pd_kcsl.ReadOnly = true;
            this.col_pd_kcsl.Width = 120;
            // 
            // col_pd_sj
            // 
            this.col_pd_sj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_pd_sj.HeaderText = "盘点时间";
            this.col_pd_sj.Name = "col_pd_sj";
            this.col_pd_sj.ReadOnly = true;
            // 
            // Form_KucunPandian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 541);
            this.Controls.Add(this.grid_pd);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form_KucunPandian";
            this.Text = "库存盘点";
            this.Load += new System.EventHandler(this.Form_KucunGuanli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_pd)).EndInit();
            this.cmn.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyGrid grid_pd;
        private MyButton btn_pd_hd;
        private MyButton btn_pd_qk;
        private MyTextBox txb_tm;
        private MyButton btn_wfsm;
        private System.Windows.Forms.ContextMenuStrip cmn;
        private System.Windows.Forms.ToolStripMenuItem cmn_xzkc;
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}