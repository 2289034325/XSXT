using BIANMA.Properties;
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

namespace BIANMA
{
    public partial class Dlg_Bangding : Form
    {
        public Dlg_Bangding()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 用户绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string dlm = txb_dlm.Text.Trim();
            string mm = txb_mm.Text;
            string zcm = txb_zcm.Text.Trim();
            string jqm = Tool.CommonFunc.GetJQM();

            if (string.IsNullOrEmpty(dlm) || string.IsNullOrEmpty(mm) || string.IsNullOrEmpty(zcm))
            {
                MessageBox.Show("不能留下空白");
                return;
            }

            new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
            {
                try
                {
                    JCSJWCF.BMZHBangding(dlm, mm, zcm);
                    ShowMsg("操作成功", false);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                catch (Exception ex)
                {
                    Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                    ShowMsg(ex.Message, true);
                }
            }, true).Start();
        }
    }
}
