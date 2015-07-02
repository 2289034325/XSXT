using BIANMA.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace BIANMA
{
    public partial class Dlg_AppSettings : Form
    {
        public Dlg_AppSettings()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string validadd = txb_validadd.Text.Trim();
            string dataadd = txb_dataadd.Text.Trim();

            if (string.IsNullOrEmpty(validadd) ||                string.IsNullOrEmpty(dataadd))
            {
                MessageBox.Show("不能输入空白");
                return;
            }

            Settings.Default.WCF_VALIDADD = validadd;
            Settings.Default.WCF_DATAADD = dataadd;

            Settings.Default.Save();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_AppSettings_Load(object sender, EventArgs e)
        {
            txb_validadd.Text = Settings.Default.WCF_VALIDADD;
            txb_dataadd.Text = Settings.Default.WCF_DATAADD.ToString();
        }
    }
}
