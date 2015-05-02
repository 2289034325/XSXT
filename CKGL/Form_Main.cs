using CKGL.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool.DB.CK;

namespace CKGL
{
    public partial class Form_Main : Form
    {

        /// <summary>
        /// 当前登陆的用户
        /// </summary>
        private TUser _user;

        public Form_Main()
        {
            InitializeComponent();
            _user = null;
        }

        /// <summary>
        /// 基础数据中心账号注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_jcsj_zc_Click(object sender, EventArgs e)
        {
            Dlg_Zhuce dz = new Dlg_Zhuce();
            dz.ShowDialog();
        }

        /// <summary>
        /// 下载最新条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_xzzxtm_Click(object sender, EventArgs e)
        {
           
        }


        /// <summary>
        /// 下载指定条码的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_xzzdtm_Click(object sender, EventArgs e)
        {
           
        }


        

        /// <summary>
        /// 出入库窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_churuku_Click(object sender, EventArgs e)
        {
            Form_Churuku fm = (Form_Churuku)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_Churuku)));
            if (fm == null)
            {
                fm = new Form_Churuku(_user);
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
        /// 库存一览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_kcyl_Click(object sender, EventArgs e)
        {
            Form_KucunYilan fm = (Form_KucunYilan)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_KucunYilan)));
            if (fm == null)
            {
                fm = new Form_KucunYilan();
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
        /// 库存管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_kcgl_Click(object sender, EventArgs e)
        {
            Form_KucunGuanli fm = (Form_KucunGuanli)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_KucunGuanli)));
            if (fm == null)
            {
                fm = new Form_KucunGuanli();
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
        /// 用户管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_yhgl_Click(object sender, EventArgs e)
        {
            Form_Yonghu fm = (Form_Yonghu)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_Yonghu)));
            if (fm == null)
            {
                fm = new Form_Yonghu();
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
        /// 条码一览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_tmyl_Click(object sender, EventArgs e)
        {
            Form_Tiaomaxinxi fm = (Form_Tiaomaxinxi)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_Tiaomaxinxi)));
            if (fm == null)
            {
                fm = new Form_Tiaomaxinxi();
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
            _user = new TUser
            {
                id = 1,
                juese = 1,
                dengluming = "2",
                yonghuming = "2"
            };
            //登陆检查
            if (_user == null)
            {
                Dlg_Denglu df = new Dlg_Denglu();
                if (df.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _user = df.User;
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}
