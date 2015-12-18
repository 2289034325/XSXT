using CKGL.Properties;
using DB_CK;
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
    public partial class Dlg_Fendian : Form
    {
        private Dictionary<string, string> _fds;
        public Dlg_Fendian(Dictionary<string,string> fds)
        {
            InitializeComponent();
            _fds = fds;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (cmb_fd.SelectedValue == null)
            {
                MessageBox.Show("请选择一个分店");
                return;
            }
            if (string.IsNullOrEmpty(cmb_fd.SelectedValue.ToString()))
            {
                MessageBox.Show("请选择一个分店");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_Fendian_Load(object sender, EventArgs e)
        {
            Tool.CommonFunc.InitCombbox(cmb_fd, _fds);
        }
    }
}
