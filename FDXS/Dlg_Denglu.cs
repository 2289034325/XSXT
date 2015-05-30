﻿using DB_FD;
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

            try
            {
                DBContext db = new DBContext();
                TUser User = db.GetUser(dlm,  Tool.CommonFunc.MD5_16(mm));
                if (User != null)
                {
                    if (User.zhuangtai == (byte)Tool.FD.DBCONSTS.USER_ZT.停用)
                    {
                        MessageBox.Show("账号已被停用");
                        return;
                    }
                    else
                    {
                        LoginInfo.User = User;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("登录名密码错误");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
