﻿using CKGL.Properties;
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

namespace CKGL
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
            //初始化数据库
            DBContext.InitializeDatabase(IDB.GetConn());            

            string dlm = txb_dlm.Text.Trim();
            string mm = txb_mm.Text;

            DBContext db = IDB.GetDB();
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
                    LoginInfo.User = user;
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
    }
}
