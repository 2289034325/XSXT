using CKGL.Properties;
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

namespace CKGL
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
            string sckid = txb_ckid.Text.Trim();
            int ckid;
            if (!int.TryParse(sckid, out ckid))
            {
                MessageBox.Show("仓库ID必须是整数");
                return;
            }
            string ckm = txb_ckm.Text.Trim();
            string zcm = txb_zcm.Text.Trim();
            string jqm = Tool.CommonFunc.GetJQM();

            try
            {
                JCSJWCF.CKZHZhuce(ckid, ckm,Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()), zcm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册失败\r\n" + ex.Message);
                return;
            }

            //把仓库ID，库名，写入本地配置文件
            Settings.Default.CKID = ckid;
            Settings.Default.CKMC = ckm;
            Settings.Default.Save();

            MessageBox.Show("注册成功");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_Zhuce_Load(object sender, EventArgs e)
        {
            txb_ckid.Text = Settings.Default.CKID.ToString();
            txb_ckm.Text = Settings.Default.CKMC;
        }

        
    }
}
