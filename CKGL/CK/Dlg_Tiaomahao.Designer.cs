using System.Windows.Forms;
namespace CKGL.CK
{
    partial class Dlg_Tiaomahao
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
            this.txb_tmhs = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txb_tmhs
            // 
            this.txb_tmhs.Location = new System.Drawing.Point(12, 12);
            this.txb_tmhs.Multiline = true;
            this.txb_tmhs.Name = "txb_tmhs";
            this.txb_tmhs.Size = new System.Drawing.Size(312, 283);
            this.txb_tmhs.TabIndex = 13;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(249, 301);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 14;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // Dlg_Tiaomahao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 339);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txb_tmhs);
            this.Name = "Dlg_Tiaomahao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输入条码号，一行一个";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txb_tmhs;
        private Button btn_ok;
    }
}