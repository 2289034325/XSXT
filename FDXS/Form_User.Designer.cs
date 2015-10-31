using MyFormControls;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmn_yh = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmn_yh_pass = new System.Windows.Forms.ToolStripMenuItem();
            this.grid_user = new MyFormControls.MyGrid();
            this.btn_edit = new MyFormControls.MyButton();
            this.btn_add = new MyFormControls.MyButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dlm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_yhm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_js = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_zt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_crsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_xgsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmn_yh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_user)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            // grid_user
            // 
            this.grid_user.AllowUserToAddRows = false;
            this.grid_user.AllowUserToResizeRows = false;
            this.grid_user.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_user.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_user.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_user.EnableHeadersVisualStyles = false;
            this.grid_user.Location = new System.Drawing.Point(0, 30);
            this.grid_user.Name = "grid_user";
            this.grid_user.ReadOnly = true;
            this.grid_user.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_user.RowHeadersVisible = false;
            this.grid_user.RowTemplate.Height = 23;
            this.grid_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_user.Size = new System.Drawing.Size(1013, 454);
            this.grid_user.TabIndex = 11;
            this.grid_user.Type = MyFormControls.MyControlType.Standard;
            this.grid_user.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grid_user_UserDeletingRow);
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.Black;
            this.btn_edit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_edit.ForeColor = System.Drawing.Color.White;
            this.btn_edit.Location = new System.Drawing.Point(109, 3);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(100, 26);
            this.btn_edit.TabIndex = 3;
            this.btn_edit.Text = "修改信息";
            this.btn_edit.Type = MyFormControls.MyControlType.Standard;
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.Black;
            this.btn_add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(3, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(100, 26);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "增加新用户";
            this.btn_add.Type = MyFormControls.MyControlType.Standard;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_add);
            this.flowLayoutPanel1.Controls.Add(this.btn_edit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1013, 30);
            this.flowLayoutPanel1.TabIndex = 13;
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
            this.col_dlm.Width = 110;
            // 
            // col_yhm
            // 
            this.col_yhm.HeaderText = "用户名";
            this.col_yhm.Name = "col_yhm";
            this.col_yhm.ReadOnly = true;
            this.col_yhm.Width = 110;
            // 
            // col_js
            // 
            this.col_js.HeaderText = "角色";
            this.col_js.Name = "col_js";
            this.col_js.ReadOnly = true;
            // 
            // col_bz
            // 
            this.col_bz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
            this.col_crsj.Width = 130;
            // 
            // col_xgsj
            // 
            this.col_xgsj.HeaderText = "修改时间";
            this.col_xgsj.Name = "col_xgsj";
            this.col_xgsj.ReadOnly = true;
            this.col_xgsj.Width = 130;
            // 
            // Form_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1013, 484);
            this.Controls.Add(this.grid_user);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form_User";
            this.Text = "系统用户";
            this.Load += new System.EventHandler(this.Form_KucunYilan_Load);
            this.cmn_yh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_user)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MyGrid grid_user;
        private System.Windows.Forms.ContextMenuStrip cmn_yh;
        private System.Windows.Forms.ToolStripMenuItem cmn_yh_pass;
        private MyButton btn_add;
        private MyButton btn_edit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dlm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_yhm;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_js;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bz;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_zt;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_crsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_xgsj;
    }
}