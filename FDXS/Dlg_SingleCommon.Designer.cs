using MyFormControls;
namespace FDXS
{
    partial class Dlg_SingleCommon
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
            this.txb_input = new MyFormControls.MyTextBox();
            this.btn_ok = new MyFormControls.MyButton();
            this.btn_cancel = new MyFormControls.MyButton();
            this.SuspendLayout();
            // 
            // txb_input
            // 
            this.txb_input.BackColor = System.Drawing.Color.Black;
            this.txb_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_input.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txb_input.ForeColor = System.Drawing.Color.White;
            this.txb_input.Location = new System.Drawing.Point(12, 12);
            this.txb_input.Name = "txb_input";
            this.txb_input.Size = new System.Drawing.Size(417, 26);
            this.txb_input.TabIndex = 10;
            this.txb_input.Type = MyFormControls.MyControlType.Special;
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.Black;
            this.btn_ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Location = new System.Drawing.Point(324, 78);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(100, 26);
            this.btn_ok.TabIndex = 12;
            this.btn_ok.Text = "确定";
            this.btn_ok.Type = MyFormControls.MyControlType.Standard;
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Black;
            this.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(218, 78);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 26);
            this.btn_cancel.TabIndex = 16;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.Type = MyFormControls.MyControlType.Standard;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Dlg_SingleCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 115);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txb_input);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_SingleCommon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登陆";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyButton btn_ok;
        private MyButton btn_cancel;
        public MyTextBox txb_input;
    }
}