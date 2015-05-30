using FDXS.Properties;
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
    public partial class Dlg_Zhuce : Form
    {
        public Dlg_Zhuce()
        {
            InitializeComponent();
        }


        /// <summary>
        /// opt = true 系统注册
        /// false 账号绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string sckid = txb_fdid.Text.Trim();
            int ckid;
            if (!int.TryParse(sckid, out ckid))
            {
                MessageBox.Show("分店ID必须是整数");
                return;
            }
            string ckm = txb_fdm.Text.Trim();
            string zcm = txb_zcm.Text.Trim();
            string jqm = Tool.CommonFunc.GetJQM();

            try
            {
                JCSJWCF.FDZHZhuce(ckid, ckm, Tool.CommonFunc.MD5_16(jqm), zcm);

                //把仓库ID，库名，写入本地配置文件
                Settings.Default.FDID = ckid;
                Settings.Default.FDMC = ckm;
                Settings.Default.Save();
                
                MessageBox.Show("注册成功");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册失败\r\n"+ex.Message);
                return;
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

        
    }
}
