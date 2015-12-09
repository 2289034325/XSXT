using DB_FD;
using DB_FD.Models;
using FDXS.Properties;
using MyFormControls;
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

namespace FDXS
{
    public partial class Dlg_Picima : MyForm
    {
        public string Pcm;
        public Dlg_Picima()
        {
            InitializeComponent();
            base.InitializeComponent();
            Pcm = "";
        }


        /// <summary>
        /// 增加一个修正
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Pcm = txb_pcm.Text.Trim();
           
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        
    }
}
