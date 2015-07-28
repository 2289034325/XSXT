using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool
{
    public partial class Dlg_Progress : Form
    {
        public bool Runing;

        public Dlg_Progress()
        {
            InitializeComponent();
            Runing = false;
        }

        /// <summary>
        /// 处理当中，不允许关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_Progress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Runing)
            {
                e.Cancel = true;
            }
        }
    }
}
