using FDXS.Properties;
using MyFormControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace FDXS
{
    public partial class Dlg_Zhuce : MyForm
    {
        public Dlg_Zhuce()
        {
            InitializeComponent();
            base.InitializeComponent();
        }


        /// <summary>
        /// opt = true 系统注册
        /// false 账号绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            bool success = false;
            new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
            {
                try
                {
                    string sfdid = txb_fdid.Text.Trim();
                    int fdid;
                    if (!int.TryParse(sfdid, out fdid))
                    {
                        ShowMsg("分店ID必须是整数", true);
                        return;
                    }
                    string fdm = txb_fdm.Text.Trim();
                    string zcm = txb_zcm.Text.Trim();
                    string jqm = Tool.CommonFunc.GetJQM();

                    JCSJWCF.FDZHZhuce(fdid, fdm, Tool.CommonFunc.MD5_16(jqm), zcm);

                    //把仓库ID，库名，写入本地配置文件
                    Settings.Default.FDID = fdid;
                    Settings.Default.FDMC = fdm;
                    Settings.Default.Save();

                    success = true;
                    ShowMsg("注册成功", false);
                }
                catch (Exception ex)
                {
                    Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                    ShowMsg(ex.Message, true);
                }
            }, false).Start();

            if (success)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_Zhuce_Load(object sender, EventArgs e)
        {
            txb_fdid.Text = Settings.Default.FDID.ToString();
            txb_fdm.Text = Settings.Default.FDMC;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
