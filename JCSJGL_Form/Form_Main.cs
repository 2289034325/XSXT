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

namespace JCSJGL
{
    public partial class Form_Main : Form
    {
        private Tool.DB.JCSJ.TUser _user;
        public Service_GLClient WCF;

        public Form_Main()
        {
            InitializeComponent();

            _user = null;

            //连接数据中心
            WCF = new Service_GLClient();
        }

        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_Load(object sender, EventArgs e)
        {
            try
            {
                //检查是否已登陆
                if (_user == null)
                {
                    //打开登陆对话框
                    Dlg_Login lg = new Dlg_Login();
                    if (lg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        _user = lg.User;
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        /// <summary>
        /// 显示系统用户窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_itm_xtyh_Click(object sender, EventArgs e)
        {
            //检查权限
            if (_user.juese == (byte)Tool.DB.JCSJ.CONSTS.USER_XTJS.系统管理员)
            {
                Form_User fu = (Form_User)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_User)));
                if (fu == null)
                {
                    fu = new Form_User();
                    fu.MdiParent = this;
                    fu.Show();
 
                }
                else
                {
                    fu.Activate();
                }
            }
            else
            {
                MessageBox.Show("没有权限");
            }
        }
    }
}
