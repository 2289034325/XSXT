using BIANMA.Properties;
using DB_JCSJ;
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
    public partial class Dlg_Denglu : Form
    {
        public Dlg_Denglu()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string dlm = txb_dlm.Text.Trim();
            string mm = txb_mm.Text;

            new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
                {
                    try
                    {
                        RuntimeInfo.LoginUser = JCSJWCF.Login(dlm, mm);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                        ShowMsg(ex.Message, true);
                    }
                }, true).Start();
        }

        /// <summary>
        /// 设置wcf地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_set_Click(object sender, EventArgs e)
        {
            Dlg_AppSettings dl = new Dlg_AppSettings();
            dl.ShowDialog();
        }

        private void txb_mm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_ok_Click(null, null);
            }
        }
    }
}
