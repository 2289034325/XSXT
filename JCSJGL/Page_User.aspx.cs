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
                Dictionary<string, byte> jss = new Dictionary<string, byte>();

                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
                {
                    jss = Tool.CommonFunc.GetDicFromEnum(typeof(Tool.JCSJ.DBCONSTS.USER_XTJS));
                }
                else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员)
                {
                    jss.Add(Tool.JCSJ.DBCONSTS.USER_XTJS.管理员.ToString(), (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员);
                    jss.Add(Tool.JCSJ.DBCONSTS.USER_XTJS.经理.ToString(), (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理);
                    jss.Add(Tool.JCSJ.DBCONSTS.USER_XTJS.编码.ToString(), (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码);
                }

                Tool.CommonFunc.InitDropDownList(cmb_js, jss);
                Tool.CommonFunc.InitDropDownList(cmb_zt, typeof(Tool.JCSJ.DBCONSTS.USER_ZT));

                //加载用户
                loadUsers();

            }
            //else
            //{
            //    string opt = hid_opt.Value;
            //    if (opt == "DELETE")
            //    {
            //        //操作后清除操作标志
            //        hid_opt.Value = "";

            //        int id = int.Parse(hid_id.Value);
            //        deleteUser(id);
            //    }
            //}
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        //private void deleteUser(int id)
        //{
        //    //权限检查
        //    Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

        //    DBContext db = new DBContext();
        //    TUser ou = db.GetUserById(id);
        //    //不能删除别人的用户
        //    if (_LoginUser.id == id)
        //    {
        //        throw new MyException("不能删除自己");
        //    }
        //    if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
        //    {

        //    }
        //    else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员)
        //    {
        //        if (ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
        //            ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
        //        {
        //            throw new MyException("非法操作，无法删除该用户");
        //        }
        //        if (ou.jmsid != _LoginUser.jmsid)
        //        {
        //            throw new MyException("非法操作，无法删除该用户");
        //        }
        //    }
        //    else
        //    {
        //        throw new MyException("非法操作，无法删除该用户");
        //    }

        //    db.DeleteUser(id);

        //    loadUsers();
        //}

        /// <summary>
        /// 加载所属的加盟商的系统用户
        /// </summary>
        private void loadUsers()
        {   
            DBContext db = new DBContext();
            TUser[] us;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                //系统管理员可看到所有的账号
                us = db.GetAllUsers();
                grid_yonghu.Columns[1].Visible = true;
                //grid_yonghu.Columns.Insert(1, new BoundField()
                //{
                //    HeaderText = "加盟商",
                //    DataField = "jiamengshang"
                //});
            }
            else
            {
                grid_yonghu.Columns[1].Visible = false;
                //非系统管理员只能看到本加盟商的账号
                us = db.GetUsers(_LoginUser.jmsid);
            }

            var dus = us.Select(r => new
            {
                id = r.id,
                jiamengshang = r.TJiamengshang.mingcheng,
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
            TUser nu = getEditInfo();
            nu.id = int.Parse(hid_id.Value);
            nu.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            TUser ou = db.GetUserById(nu.id);

            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {

            }
            else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员)
            {
                if (ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    throw new MyException("非法操作，无法修改该账户信息");
                }
                if (ou.jmsid != _LoginUser.jmsid)
                {
                    throw new MyException("非法操作，无法修改该账户信息");
                }
            }
            else
            {
                throw new MyException("非法操作，无法修改该账户信息");
            }

            db.UpdateUserInfo(nu);

            loadUsers();
        }

        private TUser getEditInfo()
        {
            string dlm = txb_dlm.Text.Trim();
            string yhm = txb_yhm.Text.Trim();
            string mm = Tool.CommonFunc.MD5_16(txb_mm.Text);
            byte js = byte.Parse(cmb_js.SelectedValue);
            byte zt = byte.Parse(cmb_zt.SelectedValue);
            string bz = txb_bz.Text.Trim();

            if (!Enum.IsDefined(typeof(Tool.JCSJ.DBCONSTS.USER_XTJS), js))
            {
                throw new MyException("非法操作，请刷新页面重新执行");
            }

            return new TUser
            {
                dengluming = dlm,
                yonghuming = yhm,
                mima = mm,
                juese = js,
                zhuangtai = zt,
                beizhu = bz
            };
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            TUser nu = getEditInfo();
            nu.jmsid = _LoginUser.jmsid;
            nu.jiqima = "";
            nu.charushijian = DateTime.Now;
            nu.xiugaishijian = DateTime.Now;

            //确保不能新建比自己权限高的账户
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {

            }
            else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员)
            {
                if (nu.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    nu.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    throw new MyException("非法操作，无法增加");
                }
            }
            else
            {
                throw new MyException("非法操作，无法增加");
            }

            DBContext db = new DBContext();
            int cc = db.GetUserCount(_LoginUser.jmsid);
            if (cc >= _LoginUser.TJiamengshang.zhanghaoshu)
            {
                throw new MyException("拥有的账号数已到上限，如需增加更多账号请联系系统管理员");
            }

            db.InsertUser(nu);

            loadUsers();
        }

        /// <summary>
        /// 删除一个账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_yonghu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //权限检查
            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            int id = int.Parse(grid_yonghu.DataKeys[e.RowIndex].Value.ToString());

            DBContext db = new DBContext();
            TUser ou = db.GetUserById(id);
            //不能删除别人的用户
            if (_LoginUser.id == id)
            {
                throw new MyException("不能删除自己");
            }
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {

            }
            else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员)
            {
                if (ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    throw new MyException("非法操作，无法删除该用户");
                }
                if (ou.jmsid != _LoginUser.jmsid)
                {
                    throw new MyException("非法操作，无法删除该用户");
                }
            }

            db.DeleteUser(id);

            loadUsers();
        }
    }
}