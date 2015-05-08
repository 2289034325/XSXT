using FDXS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;
using Tool.DB.FDXS;

namespace FDXS
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

            //校准扫描枪
            if (string.IsNullOrEmpty(Settings.Default.ScanName))
            {
                Dlg_ScanSet ds = new Dlg_ScanSet();
                ds.ShowDialog();
            }

            RawInputAddIn _rad = new RawInputAddIn(Settings.Default.ScanName, Handle, HandleScan);
        }

        /// <summary>
        /// 处理扫描枪事件
        /// </summary>
        /// <param name="tm">条码号</param>
        private void HandleScan(string tm)
        {
            //通知当前子窗口
            MyForm f = (MyForm)this.ActiveMdiChild;

            if (f != null)
            {
                f.OnScan(tm);
            }
            else
            {
                MessageBox.Show(tm);
            }
        }



        /// <summary>
        /// 进出货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_jch_Click(object sender, EventArgs e)
        {
            Form_Jinchuhuo fm = (Form_Jinchuhuo)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_Jinchuhuo)));
            if (fm == null)
            {
                fm = new Form_Jinchuhuo(_user);
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
        /// 系统初始化
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

        /// <summary>
        /// 条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_tiaoma_Click(object sender, EventArgs e)
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
        /// 系统注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_xtzc_Click(object sender, EventArgs e)
        {
            Dlg_Zhuce dz = new Dlg_Zhuce();
            dz.ShowDialog();
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
                fm = new Form_KucunGuanli(_user);
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
        /// 销售窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_xs_Click(object sender, EventArgs e)
        {

            Form_Xiaoshou fm = (Form_Xiaoshou)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_Xiaoshou)));
            if (fm == null)
            {
                fm = new Form_Xiaoshou(_user);
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
    }
}
