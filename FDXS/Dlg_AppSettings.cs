using DB_FD;
using FDXS.Properties;
using MyFormControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace FDXS
{
    public partial class Dlg_AppSettings : MyForm
    {
        public Dlg_AppSettings()
        {
            InitializeComponent();
            base.InitializeComponent();
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string dbserver = txb_dbserver.Text.Trim();
            string dbname = txb_dbname.Text.Trim();
            string dbuser = txb_dbuser.Text.Trim();
            string dbpsw = txb_dbpsw.Text;
            string validadd = txb_validadd.Text.Trim();
            string dataadd = txb_dataadd.Text.Trim();
            string dbPath = txb_dbPath.Text.Trim();
            string bkPath = txb_bakPath.Text.Trim();
            string mailServer = txb_mailServer.Text.Trim();
            string mailPortS = txb_mailPort.Text.Trim();
            string mailUser = txb_mailUser.Text.Trim();
            string mailPsw = txb_mailPsw.Text.Trim();            

            if (string.IsNullOrEmpty(dbname) || string.IsNullOrEmpty(dbuser) ||
                string.IsNullOrEmpty(dbpsw) || string.IsNullOrEmpty(validadd) ||
                string.IsNullOrEmpty(dbPath) || string.IsNullOrEmpty(bkPath) ||
                string.IsNullOrEmpty(dbserver) || string.IsNullOrEmpty(dataadd)||
                string.IsNullOrEmpty(mailServer) || string.IsNullOrEmpty(mailPortS) ||
                string.IsNullOrEmpty(mailUser) || string.IsNullOrEmpty(mailPsw))
            {
                MessageBox.Show("不能输入空白");
                return;
            }

            int mailPort = 0;
            if(!int.TryParse(mailPortS,out mailPort))
            {
                MessageBox.Show("邮件端口必须是整数");
                return;
            }

            //路径必须以\结尾
            if (!dbPath.EndsWith("\\") || !bkPath.EndsWith("\\"))
            {
                MessageBox.Show("路径必须以斜杠[\\]结尾");
                return;
            }

            if (!Directory.Exists(dbPath))
            {
                MessageBox.Show("数据库路径不存在");
                return;
            }

            if (!Directory.Exists(bkPath))
            {
                MessageBox.Show("数据库备份路径不存在");
                return;
            }

            //限制销售数据上报频率，减小服务器压力
            if (dp_xsinterval.Value.TimeOfDay.TotalMinutes < 10 && dp_xsinterval.Value.TimeOfDay.TotalMinutes != 0)
            {
                MessageBox.Show("销售数据的上报最小间隔为10分钟");
                return;
            }

            Settings.Default.DBSERVER = dbserver;
            Settings.Default.DBName = dbname;
            Settings.Default.DBUSER = dbuser;
            Settings.Default.DBPSW = dbpsw;
            Settings.Default.WCFValidADD = validadd;
            Settings.Default.WCFDataADD = dataadd;
            Settings.Default.DayTaskTime = dp_daytasktime.Value.TimeOfDay;
            Settings.Default.XsTaskInterval = dp_xsinterval.Value.TimeOfDay;
            Settings.Default.DBPath = dbPath;
            Settings.Default.DBbakPath = bkPath;
            Settings.Default.MailServer = mailServer;
            Settings.Default.MailPort = mailPort;
            Settings.Default.MailUser = mailUser;
            Settings.Default.MailPsw = mailPsw;

            Settings.Default.Save();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_AppSettings_Load(object sender, EventArgs e)
        {
            txb_dbserver.Text = Settings.Default.DBSERVER;
            txb_dbname.Text = Settings.Default.DBName;
            txb_dbuser.Text = Settings.Default.DBUSER;
            txb_dbpsw.Text = Settings.Default.DBPSW;
            txb_validadd.Text = Settings.Default.WCFValidADD;
            txb_dataadd.Text = Settings.Default.WCFDataADD.ToString();
            dp_daytasktime.Value = Convert.ToDateTime(DateTime.Now.Date + Settings.Default.DayTaskTime);
            dp_xsinterval.Value = Convert.ToDateTime(DateTime.Now.Date + Settings.Default.XsTaskInterval);
            txb_dbPath.Text = Settings.Default.DBPath;
            txb_bakPath.Text = Settings.Default.DBbakPath;
            txb_mailServer.Text = Settings.Default.MailServer;
            txb_mailPort.Text = Settings.Default.MailPort.ToString();
            txb_mailUser.Text = Settings.Default.MailUser;
            txb_mailPsw.Text = Settings.Default.MailPsw;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
