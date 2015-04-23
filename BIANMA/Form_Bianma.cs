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

namespace BIANMA
{
    public partial class Form_Bianma : Form
    {
        private JCSJData.DataServiceClient _dc;

        private TUser _u;

        public Form_Bianma()
        {
            InitializeComponent();
            _dc = new JCSJData.DataServiceClient();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Bianma_Load(object sender, EventArgs e)
        {
            //if (_u == null)
            //{
            //    Dlg_Denglu dl = new Dlg_Denglu(_dc);
            //    if (dl.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //    {
            //        this.Close();
            //    }
            //}
        }

        /// <summary>
        /// 修改账号密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_xgmm_Click(object sender, EventArgs e)
        {
            //检查是否已登录
            if (_u == null)
            {
                Dlg_Denglu dl = new Dlg_Denglu(_dc);
                if (dl.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _u = dl.User;
                }
            }
            else
            {
                Dlg_XiugaiMima dx = new Dlg_XiugaiMima(_dc);
                dx.ShowDialog();
            }
        }

        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_zhuce_Click(object sender, EventArgs e)
        {
            Dlg_Zhuce dz = new Dlg_Zhuce();
            dz.ShowDialog();
        }
    }
}
