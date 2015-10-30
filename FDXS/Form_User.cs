using DB_FD;
using DB_FD.Models;
using FDXS.Properties;
using MyFormControls;
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
    public partial class Form_User : MyForm
    {
        public Form_User()
        {
            InitializeComponent();
        }       

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KucunYilan_Load(object sender, EventArgs e)
        {
            //加载所有系统用户
            DBContext db = IDB.GetDB();
            TUser[] us = null;
            if (RuntimeInfo.LoginUser.juese == (byte)Tool.FD.DBCONSTS.USER_XTJS.系统管理员)
            {
                us = db.GetUsers();
            }
            else if (RuntimeInfo.LoginUser.juese == (byte)Tool.FD.DBCONSTS.USER_XTJS.店长)
            {
                us = db.GetUsersExceptAdmin((byte)Tool.FD.DBCONSTS.USER_XTJS.系统管理员);
            }
            else
            {
                throw new MyException("没有权限", null);
            }

            foreach (TUser u in us)
            {
                addUserToGrid(u);   
            }
        }

        /// <summary>
        /// 增加一个用户到grid
        /// </summary>
        /// <param name="u"></param>
        private void addUserToGrid(TUser u)
        {
            grid_user.Rows.Insert(0,new object[] 
                {
                    u.id,
                    u.dengluming,
                    u.yonghuming,
                    (Tool.FD.DBCONSTS.USER_XTJS)u.juese,
                    u.beizhu,
                    (Tool.FD.DBCONSTS.USER_ZT)u.zhuangtai,
                    u.charushijian,
                    u.xiuggaishijian
                });
        }

        /// <summary>
        /// 增加一个新用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            Dlg_UserEdit du = new Dlg_UserEdit(null);
            if (du.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                addUserToGrid(du.User);
            }
        }

        /// <summary>
        /// 删除一个用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_user_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = (int)e.Row.Cells[col_id.Name].Value;
            DBContext db = IDB.GetDB();
            db.DeleteUser(id);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (grid_user.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选中要修改的一行");
                return;
            }

            int id = (int)grid_user.SelectedRows[0].Cells[col_id.Name].Value;
            DBContext db = IDB.GetDB();
            TUser u = db.GetUserById(id);

            Dlg_UserEdit du = new Dlg_UserEdit(u);
            if (du.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                grid_user.SelectedRows[0].SetValues(new object[]
                {
                    du.User.id,
                    du.User.dengluming,
                    du.User.yonghuming,
                    (Tool.FD.DBCONSTS.USER_XTJS)du.User.juese,
                    du.User.beizhu,
                    (Tool.FD.DBCONSTS.USER_ZT)du.User.zhuangtai,
                    du.User.charushijian,
                    du.User.xiuggaishijian
                });
            }
        }
    }
}
