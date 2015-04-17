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
        private Service_GLClient _wcf;

        public Form_Main()
        {
            InitializeComponent();

            _user = null;

            //建立WCF连接
            _wcf = new Service_GLClient();
        }

        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_Load(object sender, EventArgs e)
        {
            //检查是否已登陆
            if (_user == null)
            {
                //打开登陆对话框
                Dlg_Login lg = new Dlg_Login(_wcf);
                if (lg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _user = lg.User;
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}
