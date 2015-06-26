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
            Dlg_Progress dp = new Dlg_Progress();
            btn_ok_Click_sync(dp);
            dp.ShowDialog();            
        }

        private async void btn_ok_Click_sync(Dlg_Progress dp)
        {
            await Task.Run(() => 
            {
                string sfdid = txb_fdid.Text.Trim();
                int fdid;
                if (!int.TryParse(sfdid, out fdid))
                {
                    dp.lbl_msg.Text = "分店ID必须是整数";
                    return;
                }
                string fdm = txb_fdm.Text.Trim();
                string zcm = txb_zcm.Text.Trim();
                string jqm = Tool.CommonFunc.GetJQM();

                try
                {
                    JCSJWCF.FDZHZhuce(fdid, fdm, Tool.CommonFunc.MD5_16(jqm), zcm);

                    //把仓库ID，库名，写入本地配置文件
                    Settings.Default.FDID = fdid;
                    Settings.Default.FDMC = fdm;
                    Settings.Default.Save();
                }
                catch (Exception ex)
                {
                    dp.lbl_msg.Text = "注册失败\r\n" + ex.Message;
                    return;
                }

                dp.lbl_msg.Text = "注册成功";
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            });

            dp.ControlBox = true;
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
