namespace CKGL.CK
{
    partial class Form_Jiamengshang
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
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_sch = new System.Windows.Forms.Button();
            this.grid_jms = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_mc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_lxr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_jms)).BeginInit();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_update);
            this.panel6.Controls.Add(this.btn_sch);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1013, 32);
            this.panel6.TabIndex = 8;
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(93, 7);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 12;
            this.btn_update.Text = "更新";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_shangbao_Click);
            // 
            // btn_sch
            // 
            this.btn_sch.Location = new System.Drawing.Point(12, 6);
            this.btn_sch.Name = "btn_sch";
            this.btn_sch.Size = new System.Drawing.Size(75, 23);
            this.btn_sch.TabIndex = 6;
            this.btn_sch.Text = "查询";
            this.btn_sch.UseVisualStyleBackColor = true;
            this.btn_sch.Click += new System.EventHandler(this.btn_sch_Click);
            // 
            // grid_jms
            // 
            this.grid_jms.AllowUserToAddRows = false;
            this.grid_jms.AllowUserToResizeRows = false;
            this.grid_jms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_jms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_mc,
            this.col_dm,
            this.col_dz,
            this.col_lxr,
            this.col_dh});
            this.grid_jms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_jms.Location = new System.Drawing.Point(0, 32);
            this.grid_jms.Name = "grid_jms";
            this.grid_jms.ReadOnly = true;
            this.grid_jms.RowTemplate.Height = 23;
            this.grid_jms.Size = new System.Drawing.Size(1013, 452);
            this.grid_jms.TabIndex = 11;
            this.grid_jms.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_jms_UserDeletingRow);
            // 
            // col_id
            // 
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            // 
            // col_mc
            // 
            this.col_mc.HeaderText = "名称";
            this.col_mc.Name = "col_mc";
            this.col_mc.ReadOnly = true;
            // 
            // col_dm
            // 
            this.col_dm.HeaderText = "代码";
            this.col_dm.Name = "col_dm";
            this.col_dm.ReadOnly = true;
            // 
            // col_dz
            // 
            this.col_dz.HeaderText = "地址";
            this.col_dz.Name = "col_dz";
            this.col_dz.ReadOnly = true;
            // 
            // col_lxr
            // 
            this.col_lxr.HeaderText = "联系人";
            this.col_lxr.Name = "col_lxr";
            this.col_lxr.ReadOnly = true;
            // 
            // col_dh
            // 
            this.col_dh.HeaderText = "电话";
            this.col_dh.Name = "col_dh";
            this.col_dh.ReadOnly = true;
            // 
            // Form_Jiamengshang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 484);
            this.Controls.Add(this.grid_jms);
            this.Controls.Add(this.panel6);
            this.Name = "Form_Jiamengshang";
            this.Text = "库存一览";
            this.Load += new System.EventHandler(this.Form_KucunYilan_Load);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_jms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btn_sch;
        private System.Windows.Forms.DataGridView grid_jms;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dz;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_lxr;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dh;
    }
}