using DB_FD.Models;
using FDXS.Properties;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FDXS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {         
            //处理未捕获的异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Control.CheckForIllegalCrossThreadCalls = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Main());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception is Tool.MyException || e.Exception is FaultException)
            {
                MessageBox.Show(e.Exception.Message, "一般错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (e.Exception.InnerException != null)
                {
                    Tool.CommonFunc.LogEx(Settings.Default.LogFile, e.Exception.InnerException);
                }
            }
            else
            {
                MessageBox.Show("发生未知的系统错误", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tool.CommonFunc.LogEx(Settings.Default.LogFile, e.Exception);
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("发生未知的系统错误", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Tool.CommonFunc.LogEx(Settings.Default.LogFile, (Exception)e.ExceptionObject);
        }
    }
}
