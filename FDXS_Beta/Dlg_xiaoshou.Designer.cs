namespace FDXS_Beta
{
    partial class Dlg_xiaoshou
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
            this.gdv_kaidan = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_printflg = new System.Windows.Forms.Label();
            this.lbl_zongjia = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_zhaoling = new System.Windows.Forms.Label();
            this.txb_shishou = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txb_tiaoma = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txb_zhekou = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_kaidan)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdv_kaidan
            // 
            this.gdv_kaidan.AllowUserToAddRows = false;
            this.gdv_kaidan.AllowUserToResizeRows = false;
            this.gdv_kaidan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gdv_kaidan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdv_kaidan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gdv_kaidan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdv_kaidan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gdv_kaidan.DefaultCellStyle = dataGridViewCellStyle2;
            this.gdv_kaidan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdv_kaidan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gdv_kaidan.Location = new System.Drawing.Point(0, 103);
            this.gdv_kaidan.Name = "gdv_kaidan";
            this.gdv_kaidan.RowHeadersVisible = false;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gdv_kaidan.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gdv_kaidan.RowTemplate.Height = 23;
            this.gdv_kaidan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdv_kaidan.Size = new System.Drawing.Size(1127, 131);
            this.gdv_kaidan.TabIndex = 0;
            this.gdv_kaidan.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdv_kaidan_CellEndEdit);
            this.gdv_kaidan.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gdv_kaidan_DataError);
            this.gdv_kaidan.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gdv_kaidan_UserDeletingRow);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            this.Column1.Width = 65;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "tiaoma";
            this.Column2.HeaderText = "条码";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "kuanhao";
            this.Column3.HeaderText = "款号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "pinming";
            this.Column4.HeaderText = "品名";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 60;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "yanse";
            this.Column5.HeaderText = "颜色";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 60;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "chima";
            this.Column6.HeaderText = "尺码";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 60;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "shuliang";
            this.Column7.HeaderText = "数量";
            this.Column7.Name = "Column7";
            this.Column7.Width = 60;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "danjia";
            this.Column8.HeaderText = "单价";
            this.Column8.Name = "Column8";
            this.Column8.Width = 60;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "zhekou";
            this.Column9.HeaderText = "折扣";
            this.Column9.Name = "Column9";
            this.Column9.Width = 60;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "moling";
            this.Column10.HeaderText = "抹零";
            this.Column10.Name = "Column10";
            this.Column10.Width = 60;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "yingshou";
            this.Column11.HeaderText = "应收";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 60;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_printflg);
            this.panel1.Controls.Add(this.lbl_zongjia);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lbl_zhaoling);
            this.panel1.Controls.Add(this.txb_shishou);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 234);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1127, 156);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(695, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 27);
            this.label2.TabIndex = 11;
            this.label2.Text = "找零";
            // 
            // lbl_printflg
            // 
            this.lbl_printflg.AutoSize = true;
            this.lbl_printflg.Location = new System.Drawing.Point(-2, 141);
            this.lbl_printflg.Name = "lbl_printflg";
            this.lbl_printflg.Size = new System.Drawing.Size(35, 12);
            this.lbl_printflg.TabIndex = 10;
            this.lbl_printflg.Text = "Print";
            // 
            // lbl_zongjia
            // 
            this.lbl_zongjia.AutoSize = true;
            this.lbl_zongjia.Font = new System.Drawing.Font("宋体", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_zongjia.ForeColor = System.Drawing.Color.Red;
            this.lbl_zongjia.Location = new System.Drawing.Point(-15, 35);
            this.lbl_zongjia.Name = "lbl_zongjia";
            this.lbl_zongjia.Size = new System.Drawing.Size(261, 107);
            this.lbl_zongjia.TabIndex = 6;
            this.lbl_zongjia.Text = "总价";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(411, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "实收";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(936, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 147);
            this.button1.TabIndex = 4;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_zhaoling
            // 
            this.lbl_zhaoling.AutoSize = true;
            this.lbl_zhaoling.Font = new System.Drawing.Font("宋体", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_zhaoling.ForeColor = System.Drawing.Color.Red;
            this.lbl_zhaoling.Location = new System.Drawing.Point(573, 35);
            this.lbl_zhaoling.Name = "lbl_zhaoling";
            this.lbl_zhaoling.Size = new System.Drawing.Size(261, 107);
            this.lbl_zhaoling.TabIndex = 3;
            this.lbl_zhaoling.Text = "找零";
            // 
            // txb_shishou
            // 
            this.txb_shishou.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_shishou.Location = new System.Drawing.Point(483, 73);
            this.txb_shishou.Name = "txb_shishou";
            this.txb_shishou.Size = new System.Drawing.Size(84, 30);
            this.txb_shishou.TabIndex = 1;
            this.txb_shishou.TextChanged += new System.EventHandler(this.txb_shishou_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(39, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 27);
            this.label14.TabIndex = 0;
            this.label14.Text = "总价￥";
            // 
            // txb_tiaoma
            // 
            this.txb_tiaoma.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_tiaoma.Location = new System.Drawing.Point(140, 36);
            this.txb_tiaoma.Name = "txb_tiaoma";
            this.txb_tiaoma.Size = new System.Drawing.Size(147, 30);
            this.txb_tiaoma.TabIndex = 8;
            this.txb_tiaoma.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_tiaoma_KeyPress);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txb_tiaoma);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.txb_zhekou);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1127, 103);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 27);
            this.label3.TabIndex = 9;
            this.label3.Text = "输入条码";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(535, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 96);
            this.button3.TabIndex = 7;
            this.button3.Text = "85折";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(399, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 96);
            this.button2.TabIndex = 6;
            this.button2.Text = "8折";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txb_zhekou
            // 
            this.txb_zhekou.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_zhekou.Location = new System.Drawing.Point(293, 36);
            this.txb_zhekou.Name = "txb_zhekou";
            this.txb_zhekou.Size = new System.Drawing.Size(100, 30);
            this.txb_zhekou.TabIndex = 5;
            this.txb_zhekou.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_zhekou_KeyPress);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(671, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 96);
            this.button4.TabIndex = 4;
            this.button4.Text = "自动抹零";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Dlg_xiaoshou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 390);
            this.Controls.Add(this.gdv_kaidan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_xiaoshou";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "开单";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dlg_xiaoshou_FormClosing);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Dlg_xiaoshou_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gdv_kaidan)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gdv_kaidan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_zhaoling;
        private System.Windows.Forms.TextBox txb_shishou;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_zongjia;
        private System.Windows.Forms.TextBox txb_tiaoma;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txb_zhekou;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_printflg;
        private System.Windows.Forms.Label label2;
    }
}