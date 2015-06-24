using DB_FD;
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
    public partial class Dlg_UserEdit : Form
    {
        public TUser User;

        public Dlg_UserEdit(TUser u)
        {
            InitializeComponent();
            User = u;
        }


        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string dlm = txb_dlm.Text.Trim();
            string mm = txb_mm.Text.Trim();
            byte js = byte.Parse(cmb_js.SelectedValue.ToString());
            string yhm = txb_yhm.Text.Trim();
            string bz = txb_bz.Text.Trim();
            byte zt = byte.Parse(cmb_zt.SelectedValue.ToString());

            DBContext db = IDB.GetDB();
            if (User == null)
            {
                User = new TUser
                {
                    dengluming = dlm,
                    mima = Tool.CommonFunc.MD5_16(mm),
                    juese = js,
                    yonghuming = yhm,
                    beizhu = bz,
                    zhuangtai = (byte)Tool.FD.DBCONSTS.USER_ZT.可用,
                    charushijian = DateTime.Now,
                    xiuggaishijian = DateTime.Now
                };

                User = db.InsertUser(User);
            }
            else
            {
                User.dengluming = dlm;
                //User.mima = mm;
                User.juese = js;
                User.yonghuming = yhm;
                User.beizhu = bz;
                User.zhuangtai = zt;
                User.xiuggaishijian = DateTime.Now;

                db.UpdateUser(User);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_UserEdit_Load(object sender, EventArgs e)
        {
            //角色下拉框
            Tool.CommonFunc.InitCombbox(cmb_js, typeof(Tool.FD.DBCONSTS.USER_XTJS));
            DataTable dt = (DataTable)cmb_js.DataSource;
            //去掉系统管理员的角色
            dt.Rows.RemoveAt(0);

            //状态下拉框
            Tool.CommonFunc.InitCombbox(cmb_zt, typeof(Tool.FD.DBCONSTS.USER_ZT));

            if (User == null)
            {
                cmb_js.SelectedIndex = 1;
                cmb_zt.SelectedIndex = 0;
            }
            else
            {
                txb_dlm.Text = User.dengluming;
                txb_mm.Text = User.mima;
                txb_yhm.Text = User.yonghuming;
                cmb_js.SelectedValue = User.juese;
                cmb_zt.SelectedValue = User.zhuangtai;
                txb_bz.Text = User.beizhu;
            }
        }
    }
}
