using DBBackTool.Properties;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBBackTool
{
    public partial class Form_Main : Form
    {
        private string _taskname = "dbBackup";

        public Form_Main()
        {
            InitializeComponent();
        }

        private void showTaskStatus()
        {
            try
            {
                //显示当前任务状态
                using (TaskService ts = new TaskService())
                {
                    Microsoft.Win32.TaskScheduler.Task tk = ts.FindTask(_taskname);

                    if (tk == null)
                    {
                        lbl_status.Text = "  任务不存在。";
                    }
                    else
                    {
                        if (tk.Enabled)
                        {
                            lbl_status.Text = "  上次运行时间：" + tk.LastRunTime.ToString("yyyy-MM-dd HH:mm:ss") + ";下次运行时间：" + tk.NextRunTime.ToString("yyyy-MM-dd HH:mm:ss") + "。";
                        }
                        else
                        {
                            lbl_status.Text = "  任务未启动。";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_Load(object sender, EventArgs e)
        {
            txb_dbserver.Text = Settings.Default.DBServer;
            txb_dbname.Text = Settings.Default.DBName;
            txb_dbuid.Text = Settings.Default.DBUid;
            txb_dbpsw.Text = Settings.Default.DBPsw;


            txb_localpath.Text = Settings.Default.LocalPath;


            chk_ali.Checked = Settings.Default.ALI;
            txb_aliendpoint.Text = Settings.Default.AliEndpoint;
            txb_alibucket.Text = Settings.Default.AliBucketName;
            txb_aliid.Text = Settings.Default.AliKeyId;
            txb_alikey.Text = Settings.Default.AliKey;
            txb_aliPath.Text = Settings.Default.AliPath;

            tp_qdsj.Value = Convert.ToDateTime(DateTime.Now.Date + Settings.Default.TaskTime);

            showTaskStatus();
        }

        private void mni_ceshi_Click(object sender, EventArgs e)
        {
            try
            {
                DoBackUp.doBackUp();
                MessageBox.Show("执行完毕");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mni_baocun_Click(object sender, EventArgs e)
        {
            //DB
            Settings.Default.DBServer = txb_dbserver.Text.Trim();
            Settings.Default.DBName = txb_dbname.Text.Trim();
            Settings.Default.DBUid = txb_dbuid.Text.Trim();
            Settings.Default.DBPsw = txb_dbpsw.Text.Trim();

            //本地路径
            Settings.Default.LocalPath = txb_localpath.Text.Trim();

            //ALI
            Settings.Default.ALI = chk_ali.Checked;
            Settings.Default.AliEndpoint = txb_aliendpoint.Text.Trim();
            Settings.Default.AliBucketName = txb_alibucket.Text.Trim();
            Settings.Default.AliKeyId = txb_aliid.Text.Trim();
            Settings.Default.AliKey = txb_alikey.Text.Trim();
            Settings.Default.AliPath = txb_aliPath.Text.Trim();

            //任务时间
            Settings.Default.TaskTime = tp_qdsj.Value.TimeOfDay;

            Settings.Default.Save();
        }

        private void mni_tzrw_Click(object sender, EventArgs e)
        {
            try
            {
                TaskService ts = new TaskService();
                Microsoft.Win32.TaskScheduler.Task tk = ts.FindTask(_taskname);
                if (tk != null) tk.Enabled = false;

                //刷新任务状态
                showTaskStatus();
                MessageBox.Show("任务已停止！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void mni_qdrw_Click(object sender, EventArgs e)
        {
            try
            {
                TaskService ts = new TaskService();
                DailyTrigger dtr = new DailyTrigger();
                dtr.DaysInterval = 1;
                dtr.StartBoundary = DateTime.Today.AddHours(tp_qdsj.Value.Hour).AddMinutes(tp_qdsj.Value.Minute).AddSeconds(tp_qdsj.Value.Second);
                Microsoft.Win32.TaskScheduler.Action act = new ExecAction(System.Windows.Forms.Application.ExecutablePath, "1", null);
                //数据统计任务
                Microsoft.Win32.TaskScheduler.Task tk = ts.FindTask(_taskname);
                if (tk == null)
                {
                    ts.AddTask(_taskname, dtr, act);
                }
                else
                {
                    if (!tk.Enabled)
                    {
                        tk.Enabled = true;
                    }
                    tk.Definition.Actions[0] = act;
                    tk.Definition.Triggers[0] = dtr;
                    tk.RegisterChanges();
                }

                //刷新任务状态
                showTaskStatus();
                MessageBox.Show("任务已更新并启动。");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
    }
}
