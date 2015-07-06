using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
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

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_Load(object sender, EventArgs e)
        {
            //登陆检查
            if (LoginInfo.User == null)
            {
                Dlg_Denglu df = new Dlg_Denglu();
                if (df.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    Application.Exit();
                }
            }

            //显示编码页面
            mni_bianma_Click(null, null);
        }

        private void mni_fenlei_Click(object sender, EventArgs e)
        {
            Form_Fenlei fm = (Form_Fenlei)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_Fenlei)));
            if (fm == null)
            {
                fm = new Form_Fenlei();
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


        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_setting_Click(object sender, EventArgs e)
        {
            Dlg_AppSettings dl = new Dlg_AppSettings();
            dl.ShowDialog();
        }

        /// <summary>
        /// 查看版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_banben_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString());
        }

        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_zhuce_Click(object sender, EventArgs e)
        {
            Dlg_Zhuce dz = new Dlg_Zhuce();
            dz.ShowDialog();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_xgmm_Click(object sender, EventArgs e)
        {
            if (LoginInfo.User == null)
            {
                MessageBox.Show("未登录");
                return;
            }

            Dlg_XiugaiMima dx = new Dlg_XiugaiMima();
            dx.ShowDialog();
        }

        /// <summary>
        /// 账号和机器绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_zhbd_Click(object sender, EventArgs e)
        {
            Dlg_Bangding db = new Dlg_Bangding();
            db.ShowDialog();
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_denglu_Click(object sender, EventArgs e)
        {
            if (LoginInfo.User != null)
            {
                MessageBox.Show("已登录");
                return;
            }

            Dlg_Denglu dl = new Dlg_Denglu();
            if (dl.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
