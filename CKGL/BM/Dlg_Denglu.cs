using CKGL;
using CKGL.BM;
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

namespace CKGL.BM
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

            login(dlm, mm);
        }

        private void login(string dlm, string mm)
        {
            new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
            {
                try
                {
                    RuntimeInfo.LoginUser_BM = JCSJWCF.Login(dlm, mm);
                }
                catch (Exception ex)
                {
                    Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                    ShowMsg(ex.Message, true);
                }
            }, true).Start();

            if (RuntimeInfo.LoginUser_BM != null)
            {
                if (chk_autoLogin.Checked)
                {
                    Settings.Default.BMUser = dlm;
                    Settings.Default.BMPsw = mm;
                    Settings.Default.Save();
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        /// <summary>
        /// 设置wcf地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btn_set_Click(object sender, EventArgs e)
        //{
        //    Dlg_AppSettings dl = new Dlg_AppSettings();
        //    dl.ShowDialog();
        //}

        private void txb_mm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_ok_Click(null, null);
            }
        }

        private void Dlg_Denglu_Load(object sender, EventArgs e)
        {
            string dlm = Settings.Default.BMUser;
            string mm = Settings.Default.BMPsw;
            if (!string.IsNullOrEmpty(dlm))
            {
                login(dlm, mm);
            }
        }

        /// <summary>
        /// 绑定账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_bangding_Click(object sender, EventArgs e)
        {
            string dlm = txb_dlm.Text.Trim();
            string mm = txb_mm.Text;
            string zcm = txb_yzm.Text.Trim();
            string jqm = Tool.CommonFunc.GetJQM();

            if (string.IsNullOrEmpty(dlm) || string.IsNullOrEmpty(mm) || string.IsNullOrEmpty(zcm))
            {
                MessageBox.Show("不能留下空白");
                return;
            }

            bool bdok = false;
            new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
            {
                try
                {
                    ShowMsg("服务器通信中", false);
                    JCSJWCF.BMZHBangding(dlm, mm, zcm);
                    bdok = true;
                    ShowMsg("绑定成功", false);
                }
                catch (Exception ex)
                {
                    Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                    ShowMsg("绑定失败\r\n" + ex.Message, true);
                }
            }, true).Start();

            if (bdok)
            {
                login(dlm, mm);
            }
        }
    }
}
