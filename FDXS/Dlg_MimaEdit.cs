using DB_FD;
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
    public partial class Dlg_MimaEdit : Form
    {
        public Dlg_MimaEdit()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string jmm = txb_jmm.Text;
            string xmm1 = txb_xmm1.Text;
            string xmm2 = txb_xmm2.Text;

            //检测新密码是否正确
            DBContext db = new DBContext();
            TUser u = db.GetUserById(LoginInfo.User.id);
            if (Tool.CommonFunc.MD5_16(jmm) != u.mima)
            {
                MessageBox.Show("旧密码不正确");
                return;
            }

            //检测两个新密码是否一样
            if (!string.IsNullOrEmpty(xmm1))
            {
                MessageBox.Show("旧密码不正确");
                return;
            }
            if (xmm1 != xmm2)
            {
                MessageBox.Show("两次输入的新密码不一致");
                return;
            }

            db.UpdateUserPsw(LoginInfo.User.id, Tool.CommonFunc.MD5_16(xmm1));

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
