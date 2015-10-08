using CKGL.Properties;
using DB_CK;
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
using Tool;

namespace CKGL
{
    public partial class Form_Main : Form
    {

        public Form_Main()
        {
            InitializeComponent();

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
        /// <param name="tm"></param>
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
        /// 出入库窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_churuku_Click(object sender, EventArgs e)
        {
            Form_Churuku fm = (Form_Churuku)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_Churuku)));
            if (fm == null)
            {
                fm = new Form_Churuku();
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
            if (AppDomain.CurrentDomain.ActivationContext != null)
            {
                RuntimeInfo.ClientVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            else
            {
                RuntimeInfo.ClientVersion = new Version();
            }

            //登陆检查
            if (RuntimeInfo.LoginUser == null)
            {
                Dlg_Denglu df = new Dlg_Denglu();
                if (df.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// 查看版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_version_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString());
        }

        /// <summary>
        /// 设置系统参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_xtsz_Click(object sender, EventArgs e)
        {
            Dlg_AppSettings dl = new Dlg_AppSettings();
            dl.ShowDialog();
        }

        /// <summary>
        /// 重新连接服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_cxlj_Click(object sender, EventArgs e)
        {
            new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
                    {
                        try
                        {
                            JCSJWCF.Reconnect();
                            ShowMsg("连接成功", false);
                        }
                        catch (Exception ex)
                        {
                            Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                            ShowMsg(ex.Message, true);
                        }
                    }, false).Start();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_xgmm_Click(object sender, EventArgs e)
        {
            Dlg_XiugaiMima dl = new Dlg_XiugaiMima();
            if (dl.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show("修改成功");
            }
        }
    }
}
