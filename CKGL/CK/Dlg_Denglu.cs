using CKGL.Properties;
using DB_CK;
using DB_CK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace CKGL.CK
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
            DBContext db = IDB.GetDB();
            //检查数据库版本
            try
            {
                db.InitializeDatabase(RuntimeInfo.DbVersion);
            }
            catch (Exception ex)
            {
                Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                MessageBox.Show("数据库初始化失败");
                //Application.Exit();
                return;
            }        

            string dlm = txb_dlm.Text.Trim();
            string mm = txb_mm.Text;

            TUser user = db.GetUser(dlm, Tool.CommonFunc.MD5_16(mm));
            if (user != null)
            {
                if (user.zhuangtai == (byte)Tool.CK.DBCONSTS.USER_ZT.停用)
                {
                    MessageBox.Show("账号已被停用");
                    return;
                }
                else
                {
                    RuntimeInfo.LoginUser_CK = user;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("登录名密码错误");
            }
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_setting_Click(object sender, EventArgs e)
        {
            Dlg_AppSettings dl = new Dlg_AppSettings();
            dl.ShowDialog();
        }

        /// <summary>
        /// 回车登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_mm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_ok_Click(null, null);
            }
        }

        /// <summary>
        /// 重置扫描枪
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_resetScan_Click(object sender, EventArgs e)
        {
            Settings.Default.ScanName = "";
            Settings.Default.Save();
            System.Windows.Forms.Application.Restart();
        }
    }
}
