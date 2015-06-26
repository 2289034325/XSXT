using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FDXS
{
    public partial class Dlg_Progress : Form
    {
        public Dlg_Progress()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_Progress_Load(object sender, EventArgs e)
        {
            lbl_msg.Text = "";
            pgb.Maximum = 100;
            pgb.Value = 0;
            ControlBox = false;
        }
    }
}
