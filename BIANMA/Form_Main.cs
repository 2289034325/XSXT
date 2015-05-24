using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIANMA
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 打开编码窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_bianma_Click(object sender, EventArgs e)
        {
            Form_Bianma fm = (Form_Bianma)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_Bianma)));
            if (fm == null)
            {
                fm = new Form_Bianma();
                fm.MdiParent = this;
                fm.WindowState = FormWindowState.Maximized;
                fm.Show();
            }
            else
            {
                fm.WindowState = FormWindowState.Maximized;
                fm.Activate();
            }
        }
    }
}
