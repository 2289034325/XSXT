using DB_FD;
using DB_FD.Models;
using FDXS.Properties;
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

namespace FDXS
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

            if (string.IsNullOrEmpty(dlm))
            {
                MessageBox.Show("请输入用户名");
                return;
            }

            login(dlm, Tool.CommonFunc.MD5_16(mm));
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_Denglu_Load(object sender, EventArgs e)
        {
            string dlm = Settings.Default.AutoLoginDlm;
            string mm = Settings.Default.AutoLoginMm;

            //自动登陆
            if (!string.IsNullOrEmpty(dlm))
            {
                login(dlm, mm);
            }
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="dlm"></param>
        /// <param name="mm"></param>
        private void login(string dlm, string mm)
        {
            DBContext db = IDB.GetDB();

            TUser User = db.GetUser(dlm, mm);
            if (User != null)
            {
                if (User.zhuangtai == (byte)Tool.FD.DBCONSTS.USER_ZT.停用)
                {
                    MessageBox.Show("账号已被停用");
                    return;
                }
                else
                {
                    RuntimeInfo.LoginUser = User;
                    if (chk_auto.Checked)
                    {
                        Settings.Default.AutoLoginDlm = dlm;
                        Settings.Default.AutoLoginMm = mm;
                        Settings.Default.Save();
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("登录名密码错误");
            }
        }

        /// <summary>
        /// 设置配置文件
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
        private void btn_resetscan_Click(object sender, EventArgs e)
        {
            Settings.Default.ScanName = "";
            Settings.Default.Save();
            System.Windows.Forms.Application.Restart();
        }
    }
}
