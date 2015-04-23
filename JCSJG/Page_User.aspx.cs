using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool.DB.JCSJ;

namespace JCSJG
{
    public partial class Page_User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                //加载管理员以外的所有用户
                loadUsers();

                //初始化下拉框
                Tool.CommonFunc.InitCombbox(cmb_js, typeof(CONSTS.USER_XTJS));
                Tool.CommonFunc.InitCombbox(cmb_zt, typeof(CONSTS.USER_ZT));
            }
            else
            {
                string opt = hid_opt.Value;
                if (opt == "EDITPSW")
                {
                    int id = int.Parse(hid_id.Value);
                    string psw = txb_mm.Text;
                    editPsw(id, psw);
                }
                else if (opt == "DELETE")
                {
                    int id = int.Parse(hid_id.Value);
                    deleteUser(id);
                }

                //操作后清除操作标志
                hid_opt.Value = "";
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        private void deleteUser(int id)
        {
            OPT db = new OPT();
            db.DeleteUser(id);

            loadUsers();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="psw"></param>
        private void editPsw(int id, string psw)
        {
            OPT db = new OPT();
            db.UpdateUserPsw(id, Tool.CommonFunc.MD5_16(psw));
        }

        //加载管理员以外的所有用户
        private void loadUsers()
        {
            OPT db = new OPT();
            TUser[] us = db.GetAllUsers(true);
            var dus = us.Select(r => new
            {
                id = r.id,
                dengluming = r.dengluming,
                yonghuming = r.yonghuming,
                juese = r.juese,
                juese_view = ((CONSTS.USER_XTJS)r.juese).ToString(),
                zhuangtai = r.zhuangtai,
                zhuangtai_view = ((CONSTS.USER_ZT)r.zhuangtai).ToString(),
                beizhu = r.beizhu,
                charushijian = r.charushijian,
                xiugaishijian = r.xiugaishijian,
                editParams = r.id + ",'" + r.dengluming + "','" + r.yonghuming + "','" + r.juese + "','" + r.zhuangtai + "','" + r.beizhu + "'"
            });

            grid_yonghu.DataSource = Tool.CommonFunc.LINQToDataTable(dus);
            grid_yonghu.DataBind();
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_editxx_Click(object sender, EventArgs e)
        {
            int id = int.Parse(hid_id.Value);
            string dlm = txb_dlm.Text.Trim();
            string yhm = txb_yhm.Text.Trim();
            byte js = byte.Parse(cmb_js.SelectedValue);
            byte zt = byte.Parse(cmb_zt.SelectedValue);
            string bz = txb_bz.Text.Trim();

            TUser u = new TUser 
            {
                id = id,
                dengluming = dlm,
                yonghuming = yhm,
                juese = js,
                zhuangtai = zt,
                beizhu = bz,
                xiugaishijian = DateTime.Now
            };
            OPT db = new OPT();
            db.UpdateUserInfo(u);

            loadUsers();
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            string dlm = txb_dlm.Text.Trim();
            string mm = txb_mm.Text;
            string yhm = txb_yhm.Text.Trim();
            byte js = byte.Parse(cmb_js.SelectedValue);
            byte zt = byte.Parse(cmb_zt.SelectedValue);
            string bz = txb_bz.Text.Trim();

            TUser u = new TUser
            {
                dengluming = dlm,
                mima = Tool.CommonFunc.MD5_16(mm),
                jiqima = "",
                yonghuming = yhm,
                juese = js,
                zhuangtai = zt,
                beizhu = bz,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now
            };
            OPT db = new OPT();
            db.InsertUser(u);

            loadUsers();
        }
    }
}