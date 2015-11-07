using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace CKGL.CK
{
    public partial class Dlg_Tiaomahao : MyForm
    {
        public string[] TMHs 
        {
            get 
            {
                return txb_tmhs.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
        public Dlg_Tiaomahao()
        {
            InitializeComponent();
        }

        public override void OnScan(string tm)
        {
            txb_tmhs.AppendText(tm + Environment.NewLine);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string tmhs = txb_tmhs.Text.Trim();
            if (string.IsNullOrEmpty(tmhs) || string.IsNullOrWhiteSpace(tmhs))
            {
                MessageBox.Show("请输入条码号");
                return;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
