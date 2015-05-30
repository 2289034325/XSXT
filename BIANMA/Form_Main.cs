using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            if (LoginInfo.User == null)
            {
                MessageBox.Show("未登录");
                return;
            }

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
        /// 账号注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_zhuce_Click(object sender, EventArgs e)
        {
            Dlg_Zhuce dz = new Dlg_Zhuce();
            dz.ShowDialog();
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_denglu_Click(object sender, EventArgs e)
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
        
        /// <summary>
        /// 账号与机器绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_zhbd_Click(object sender, EventArgs e)
        {
            Dlg_Bangding db = new Dlg_Bangding();
            db.ShowDialog();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_xgmm_Click(object sender, EventArgs e)
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
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_Load(object sender, EventArgs e)
        {

        }

        private void mni_fenlei_Click(object sender, EventArgs e)
        {

        }
    }
}
