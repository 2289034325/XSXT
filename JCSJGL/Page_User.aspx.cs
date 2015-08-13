using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JCSJGL
{
    public partial class Page_User : MyPage
    {
        public Page_User()
        {
            _PageName = PageName.用户管理;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                //初始化下拉框
                Dictionary<string, byte> jss = Tool.CommonFunc.GetDicFromEnum(typeof(Tool.JCSJ.DBCONSTS.USER_XTJS));
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    jss.Remove(Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员.ToString());
                }
                else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理)
                {
                    jss.Remove(Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员.ToString());
                    jss.Remove(Tool.JCSJ.DBCONSTS.USER_XTJS.总经理.ToString());
                }
                //jss.Add()
                Tool.CommonFunc.InitDropDownList(cmb_js, jss);
                Tool.CommonFunc.InitDropDownList(cmb_zt, typeof(Tool.JCSJ.DBCONSTS.USER_ZT));

                //加载用户
                loadUsers();

            }
            else
            {
                string opt = hid_opt.Value;
                if (opt == "DELETE")
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
            //权限检查
            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            DBContext db = new DBContext();
            TUser ou = db.GetUserById(id);
            //除了系统管理员，其他人不能删除别人的用户
            if (ou.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法删除该用户");
            }
            if (_LoginUser.id == id)
            {
                throw new MyException("不能删除自己");
            }
            if (ou.juese > _LoginUser.juese)
            {
                throw new MyException("不能删除比自己权限高的角色");
            }

            db.DeleteUser(id);

            loadUsers();
        }

        /// <summary>
        /// 加载所属的加盟商的系统用户
        /// </summary>
        private void loadUsers()
        {   
            DBContext db = new DBContext();
            TUser[] us;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                //系统管理员可看到所有的账号
                us = db.GetAllUsers();
            }
            else
            {
                //非系统管理员只能看到本加盟商的账号
                us = db.GetUsersByJmsId(_LoginUser.jmsid);
            }

            var dus = us.Select(r => new
            {
                id = r.id,
                dengluming = r.dengluming,
                yonghuming = r.yonghuming,
                juese = r.juese,
                juese_view = ((Tool.JCSJ.DBCONSTS.USER_XTJS)r.juese).ToString(),
                zhuangtai = r.zhuangtai,
                zhuangtai_view = ((Tool.JCSJ.DBCONSTS.USER_ZT)r.zhuangtai).ToString(),
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
            DBContext db = new DBContext();
            TUser ou = db.GetUserById(id);
            //角色值越小，权限越高
            if (ou.juese < _LoginUser.juese)
            {
                throw new MyException("不能修改权限比自己高的角色");
            }

            string dlm = txb_dlm.Text.Trim();
            string yhm = txb_yhm.Text.Trim();
            string mm = Tool.CommonFunc.MD5_16(txb_mm.Text);
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
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            byte js = byte.Parse(cmb_js.SelectedValue);
            //确保不能新建比自己权限高的账户
            if (js < _LoginUser.juese)
            {
                throw new MyException("无法增加比自己权限高的账户");
            }

            string dlm = txb_dlm.Text.Trim();
            string mm = Tool.CommonFunc.MD5_16(txb_mm.Text);
            string yhm = txb_yhm.Text.Trim();
            byte zt = byte.Parse(cmb_zt.SelectedValue);
            string bz = txb_bz.Text.Trim();

            TUser u = new TUser
            {
                jmsid = _LoginUser.jmsid,
                dengluming = dlm,
                mima = mm,
                jiqima = "",
                yonghuming = yhm,
                juese = js,
                zhuangtai = zt,
                beizhu = bz,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now
            };
            DBContext db = new DBContext();
            TUser[] us = db.GetUsersByJmsId(_LoginUser.jmsid);
            if (us.Count() >= _LoginUser.TJiamengshang.zhanghaoshu)
            {
                throw new MyException("拥有的账号数已到上限，如需增加更多账号请联系系统管理员");
            }
            db.InsertUser(u);

            loadUsers();
        }
    }
}