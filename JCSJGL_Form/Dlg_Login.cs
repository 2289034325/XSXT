using JCSJGL.WCF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool.DB.JCSJ;

namespace JCSJGL
{
    public partial class Dlg_Login : Form
    {
        public TUser User;
        public Dlg_Login()
        {
            InitializeComponent();
            User = null;
        }

        /// <summary>
        /// 确定，调用WCF验证用户名和密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string dlm = txb_dlm.Text.Trim();
            string mm = txb_mm.Text;

            //调用WCF接口
            Form_Main fm = (Form_Main)this.Owner;
            User = fm.WCF.Login(dlm, Tool.CommonFunc.MD5_16(mm));

            if (User == null)
            {
                MessageBox.Show("登陆失败");
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
