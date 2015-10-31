using MyFormControls;
namespace FDXS
{
    partial class Dlg_ScanSet
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
            this.label1 = new MyFormControls.MyLabel();
            this.myTextBox1 = new MyFormControls.MyTextBox();
            this.myLabel1 = new MyFormControls.MyLabel();
            this.myLabel2 = new MyFormControls.MyLabel();
            this.btn_cancel = new MyFormControls.MyButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(513, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "本窗口用于校验扫描枪，如果设置成功窗口会自动关闭";
            this.label1.Type = MyFormControls.MyControlType.Standard;
            // 
            // myTextBox1
            // 
            this.myTextBox1.BackColor = System.Drawing.Color.Black;
            this.myTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.myTextBox1.ForeColor = System.Drawing.Color.White;
            this.myTextBox1.Location = new System.Drawing.Point(26, 112);
            this.myTextBox1.Name = "myTextBox1";
            this.myTextBox1.Size = new System.Drawing.Size(551, 26);
            this.myTextBox1.TabIndex = 1;
            this.myTextBox1.Type = MyFormControls.MyControlType.Special;
            // 
            // myLabel1
            // 
            this.myLabel1.AutoSize = true;
            this.myLabel1.BackColor = System.Drawing.Color.Black;
            this.myLabel1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.myLabel1.ForeColor = System.Drawing.Color.White;
            this.myLabel1.Location = new System.Drawing.Point(104, 40);
            this.myLabel1.Name = "myLabel1";
            this.myLabel1.Size = new System.Drawing.Size(366, 20);
            this.myLabel1.TabIndex = 2;
            this.myLabel1.Text = "请将鼠标的光标放到下面的文本框当中";
            this.myLabel1.Type = MyFormControls.MyControlType.Standard;
            // 
            // myLabel2
            // 
            this.myLabel2.AutoSize = true;
            this.myLabel2.BackColor = System.Drawing.Color.Black;
            this.myLabel2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.myLabel2.ForeColor = System.Drawing.Color.White;
            this.myLabel2.Location = new System.Drawing.Point(22, 73);
            this.myLabel2.Name = "myLabel2";
            this.myLabel2.Size = new System.Drawing.Size(555, 20);
            this.myLabel2.TabIndex = 3;
            this.myLabel2.Text = "当看到光标在文本框里闪动的时候，用扫描枪扫描任意条码";
            this.myLabel2.Type = MyFormControls.MyControlType.Standard;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Black;
            this.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(477, 158);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 26);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.Type = MyFormControls.MyControlType.Standard;
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Dlg_ScanSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 196);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.myLabel2);
            this.Controls.Add(this.myLabel1);
            this.Controls.Add(this.myTextBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_ScanSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "扫描枪校准";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyLabel label1;
        private MyTextBox myTextBox1;
        private MyLabel myLabel1;
        private MyLabel myLabel2;
        private MyButton btn_cancel;

    }
}