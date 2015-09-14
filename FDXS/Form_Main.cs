using DB_FD;
using FDXS.Properties;
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

namespace FDXS
{
    public partial class Form_Main: Form
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
                fm = new Form_Jinchuhuo();
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

            //登陆检查
            if (RuntimeInfo.LoginUser == null)
            {
                Dlg_Denglu df = new Dlg_Denglu();
                if (df.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    Application.Exit();
                    return;
                }
            }

            this.Text += "【当前登陆：" + RuntimeInfo.LoginUser.yonghuming + "】";

            //启动任务
            MyTask.DayTask();
            MyTask.Tasks();
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
        /// 销售窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_xs_Click(object sender, EventArgs e)
        {

            Form_Xiaoshou fm = (Form_Xiaoshou)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_Xiaoshou)));
            if (fm == null)
            {
                fm = new Form_Xiaoshou();
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
        /// 会员一览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_hyyl_Click(object sender, EventArgs e)
        {
            Form_Huiyuan fm = (Form_Huiyuan)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_Huiyuan)));
            if (fm == null)
            {
                fm = new Form_Huiyuan();
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
        /// 积分折扣规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_jfzk_Click(object sender, EventArgs e)
        {
            Form_JifenZhekou fm = (Form_JifenZhekou)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_JifenZhekou)));
            if (fm == null)
            {
                fm = new Form_JifenZhekou();
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
        /// 系统用户管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_xtyh_Click(object sender, EventArgs e)
        {
            //店长和系统管理员才有权限
            if (!(RuntimeInfo.LoginUser.juese == (byte)Tool.FD.DBCONSTS.USER_XTJS.店长 ||
                RuntimeInfo.LoginUser.juese == (byte)Tool.FD.DBCONSTS.USER_XTJS.系统管理员))
            {
                MessageBox.Show("没有权限");
                return;
            }

            Form_User fm = (Form_User)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_User)));
            if (fm == null)
            {
                fm = new Form_User();
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
        /// 重置扫描枪
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_czsmq_Click(object sender, EventArgs e)
        {
            Settings.Default.ScanName = "";
            Settings.Default.Save();
            System.Windows.Forms.Application.Restart();
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
        /// 打开所在文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_folder_Click(object sender, EventArgs e)
        {
            if (RuntimeInfo.LoginUser.juese == (byte)Tool.FD.DBCONSTS.USER_XTJS.系统管理员)
            {
                string path = System.Environment.CurrentDirectory;
                System.Diagnostics.Process.Start("explorer.exe", path);
            }
            else
            {
                MessageBox.Show("没有权限");
                return;
            }
        }

        /// <summary>
        /// 修改当前用户的密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_editpsw_Click(object sender, EventArgs e)
        {
            Dlg_MimaEdit dg = new Dlg_MimaEdit();
            dg.ShowDialog();
        }

        /// <summary>
        /// 更改登陆用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_userchange_Click(object sender, EventArgs e)
        {
            //清除配置记录，并关闭当前进程
            Settings.Default.AutoLoginDlm = "";
            Settings.Default.AutoLoginMm = "";
            Settings.Default.Save();

            Application.Restart();
        }

        /// <summary>
        /// 报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_baobiao_Click(object sender, EventArgs e)
        {
            Form_Tubiao fm = (Form_Tubiao)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_Tubiao)));
            if (fm == null)
            {
                fm = new Form_Tubiao();
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
        /// 系统设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_xtsz_Click(object sender, EventArgs e)
        {
            Dlg_AppSettings dl = new Dlg_AppSettings();
            dl.ShowDialog();
        }


        /// <summary>
        /// 开单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_kd_Click(object sender, EventArgs e)
        {
            Form_Kaidan fm = (Form_Kaidan)this.MdiChildren.SingleOrDefault(r => r.GetType().Equals(typeof(Form_Kaidan)));
            if (fm == null)
            {
                fm = new Form_Kaidan();
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
        /// 重新连接服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_cxljfwq_Click(object sender, EventArgs e)
        {
            new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
            {
                try
                {
                    ShowMsg("正在连接", false);

                    JCSJWCF.Reconnect();

                    ShowMsg("连接成功", false);
                }
                catch (Exception ex)
                {
                    Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                    ShowMsg("连接失败\r\n" + ex.Message, true);
                }
            }, false).Start();
        }

        /// <summary>
        /// 手动备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mn_main_dbbkup_Click(object sender, EventArgs e)
        {
            DBTool dt = new DBTool(IDB.GetConn());

            FolderBrowserDialog sfd = new FolderBrowserDialog();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = Settings.Default.FDID + "-" + Settings.Default.FDMC + "-" + Settings.Default.DBName + "-"
                    + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
                dt.BackUp(sfd.SelectedPath + "\\" + fileName);
            }

            MessageBox.Show("备份成功");
        }
    }
}
