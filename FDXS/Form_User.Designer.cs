namespace FDXS
{
    partial class Form_User
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
            this.grid_user = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dlm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_yhm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_js = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_zt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xgsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmn_yh = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmn_yh_pass = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txb_mm = new System.Windows.Forms.TextBox();
            this.btn_editpass = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_user)).BeginInit();
            this.cmn_yh.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_user
            // 
            this.grid_user.AllowUserToAddRows = false;
            this.grid_user.AllowUserToResizeRows = false;
            this.grid_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_user.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_dlm,
            this.col_yhm,
            this.col_js,
            this.col_bz,
            this.col_zt,
            this.col_crsj,
            this.col_xgsj});
            this.grid_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_user.Location = new System.Drawing.Point(0, 38);
            this.grid_user.Name = "grid_user";
            this.grid_user.ReadOnly = true;
            this.grid_user.RowHeadersVisible = false;
            this.grid_user.RowTemplate.Height = 23;
            this.grid_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_user.Size = new System.Drawing.Size(1013, 446);
            this.grid_user.TabIndex = 11;
            this.grid_user.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_user_UserDeletingRow);
            // 
            // col_id
            // 
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            // 
            // col_dlm
            // 
            this.col_dlm.HeaderText = "登录名";
            this.col_dlm.Name = "col_dlm";
            this.col_dlm.ReadOnly = true;
            // 
            // col_yhm
            // 
            this.col_yhm.HeaderText = "用户名";
            this.col_yhm.Name = "col_yhm";
            this.col_yhm.ReadOnly = true;
            // 
            // col_js
            // 
            this.col_js.HeaderText = "角色";
            this.col_js.Name = "col_js";
            this.col_js.ReadOnly = true;
            // 
            // col_bz
            // 
            this.col_bz.HeaderText = "备注";
            this.col_bz.Name = "col_bz";
            this.col_bz.ReadOnly = true;
            // 
            // col_zt
            // 
            this.col_zt.HeaderText = "状态";
            this.col_zt.Name = "col_zt";
            this.col_zt.ReadOnly = true;
            // 
            // col_crsj
            // 
            this.col_crsj.HeaderText = "插入时间";
            this.col_crsj.Name = "col_crsj";
            this.col_crsj.ReadOnly = true;
            // 
            // col_xgsj
            // 
            this.col_xgsj.HeaderText = "修改时间";
            this.col_xgsj.Name = "col_xgsj";
            this.col_xgsj.ReadOnly = true;
            // 
            // cmn_yh
            // 
            this.cmn_yh.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmn_yh_pass});
            this.cmn_yh.Name = "cmn_hy";
            this.cmn_yh.Size = new System.Drawing.Size(125, 26);
            // 
            // cmn_yh_pass
            // 
            this.cmn_yh_pass.Name = "cmn_yh_pass";
            this.cmn_yh_pass.Size = new System.Drawing.Size(124, 22);
            this.cmn_yh_pass.Text = "修改密码";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txb_mm);
            this.panel1.Controls.Add(this.btn_editpass);
            this.panel1.Controls.Add(this.btn_edit);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 38);
            this.panel1.TabIndex = 12;
            // 
            // txb_mm
            // 
            this.txb_mm.Location = new System.Drawing.Point(255, 11);
            this.txb_mm.Name = "txb_mm";
            this.txb_mm.PasswordChar = '*';
            this.txb_mm.Size = new System.Drawing.Size(100, 21);
            this.txb_mm.TabIndex = 5;
            // 
            // btn_editpass
            // 
            this.btn_editpass.Location = new System.Drawing.Point(174, 9);
            this.btn_editpass.Name = "btn_editpass";
            this.btn_editpass.Size = new System.Drawing.Size(75, 23);
            this.btn_editpass.TabIndex = 4;
            this.btn_editpass.Text = "更改密码";
            this.btn_editpass.UseVisualStyleBackColor = true;
            this.btn_editpass.Click += new System.EventHandler(this.btn_editpass_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(93, 9);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 3;
            this.btn_edit.Text = "修改信息";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(12, 9);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "增加新用户";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // Form_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 484);
            this.Controls.Add(this.grid_user);
            this.Controls.Add(this.panel1);
            this.Name = "Form_User";
            this.Text = "系统用户";
            this.Load += new System.EventHandler(this.Form_KucunYilan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_user)).EndInit();
            this.cmn_yh.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid_user;
        private System.Windows.Forms.ContextMenuStrip cmn_yh;
        private System.Windows.Forms.ToolStripMenuItem cmn_yh_pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dlm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_yhm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_js;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bz;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_zt;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xgsj;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_editpass;
        private System.Windows.Forms.TextBox txb_mm;
    }
}