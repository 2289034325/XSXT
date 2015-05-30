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

namespace BIANMA
{
    public partial class Dlg_XiugaiMima : Form
    {
        public Dlg_XiugaiMima()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 系统注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string om = txb_om.Text;
            string nm = txb_nm.Text;

            try
            {
                JCSJWCF.BMZHEditPsw(om, nm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            MessageBox.Show("修改成功");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
