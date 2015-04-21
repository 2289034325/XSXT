namespace JCSJGL
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
            this.grid_user = new System.Windows.Forms.DataGridView();
            this.col_user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_user_dengluming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_user_yonghuming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_user_juese = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_user_zhuangtai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_user_beizhu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_user_charushijian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_user_xiugaishijian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_user)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_user
            // 
            this.grid_user.AllowUserToAddRows = false;
            this.grid_user.AllowUserToResizeRows = false;
            this.grid_user.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grid_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_user.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_user_id,
            this.col_user_dengluming,
            this.col_user_yonghuming,
            this.col_user_juese,
            this.col_user_zhuangtai,
            this.col_user_beizhu,
            this.col_user_charushijian,
            this.col_user_xiugaishijian});
            this.grid_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_user.Location = new System.Drawing.Point(0, 0);
            this.grid_user.MultiSelect = false;
            this.grid_user.Name = "grid_user";
            this.grid_user.RowHeadersVisible = false;
            this.grid_user.RowTemplate.Height = 23;
            this.grid_user.Size = new System.Drawing.Size(1017, 460);
            this.grid_user.TabIndex = 0;
            // 
            // col_user_id
            // 
            this.col_user_id.DataPropertyName = "id";
            this.col_user_id.HeaderText = "ID";
            this.col_user_id.Name = "col_user_id";
            this.col_user_id.Width = 42;
            // 
            // col_user_dengluming
            // 
            this.col_user_dengluming.DataPropertyName = "dengluming";
            this.col_user_dengluming.HeaderText = "登录名";
            this.col_user_dengluming.Name = "col_user_dengluming";
            this.col_user_dengluming.Width = 66;
            // 
            // col_user_yonghuming
            // 
            this.col_user_yonghuming.DataPropertyName = "yonghuming";
            this.col_user_yonghuming.HeaderText = "用户名";
            this.col_user_yonghuming.Name = "col_user_yonghuming";
            this.col_user_yonghuming.Width = 66;
            // 
            // col_user_juese
            // 
            this.col_user_juese.DataPropertyName = "juese";
            this.col_user_juese.HeaderText = "角色";
            this.col_user_juese.Name = "col_user_juese";
            this.col_user_juese.Width = 54;
            // 
            // col_user_zhuangtai
            // 
            this.col_user_zhuangtai.DataPropertyName = "zhuangtai";
            this.col_user_zhuangtai.HeaderText = "状态";
            this.col_user_zhuangtai.Name = "col_user_zhuangtai";
            this.col_user_zhuangtai.Width = 54;
            // 
            // col_user_beizhu
            // 
            this.col_user_beizhu.DataPropertyName = "beizhu";
            this.col_user_beizhu.HeaderText = "备注";
            this.col_user_beizhu.Name = "col_user_beizhu";
            this.col_user_beizhu.Width = 54;
            // 
            // col_user_charushijian
            // 
            this.col_user_charushijian.DataPropertyName = "charushijian";
            this.col_user_charushijian.HeaderText = "插入时间";
            this.col_user_charushijian.Name = "col_user_charushijian";
            this.col_user_charushijian.Width = 78;
            // 
            // col_user_xiugaishijian
            // 
            this.col_user_xiugaishijian.DataPropertyName = "xiugaishijian";
            this.col_user_xiugaishijian.HeaderText = "修改时间";
            this.col_user_xiugaishijian.Name = "col_user_xiugaishijian";
            this.col_user_xiugaishijian.Width = 78;
            // 
            // Form_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 460);
            this.Controls.Add(this.grid_user);
            this.KeyPreview = true;
            this.Name = "Form_User";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.Form_User_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_User_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grid_user)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user_dengluming;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user_yonghuming;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user_juese;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user_zhuangtai;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user_beizhu;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user_charushijian;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_user_xiugaishijian;
    }
}