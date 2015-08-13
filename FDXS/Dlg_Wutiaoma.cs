using FDXS.Properties;
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
    public partial class Dlg_Wutiaoma : Form
    {
        public string pm;
        public string ys;
        public string cm;
        public decimal dj;

        public Dlg_Wutiaoma()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            //检查输入
            pm = txb_pm.Text.Trim();
            ys = txb_ys.Text.Trim();
            cm = txb_cm.Text.Trim();
            string sdj = txb_dj.Text.Trim();

            if(string.IsNullOrEmpty(pm)||string.IsNullOrEmpty(ys)||
                string.IsNullOrEmpty(cm)||string.IsNullOrEmpty(sdj))
            {
                MessageBox.Show("不能输入空白");
                return;
            }

            if (!decimal.TryParse(sdj, out dj))
            {
                MessageBox.Show("单价只能填写数字");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_Zhuce_Load(object sender, EventArgs e)
        {

        }        
    }
}
