using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

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
                //隐藏搜索条件
                div_sch_jms.Visible = false;
                div_edit_jms.Visible = false;
                DBContext db = new DBContext();

                //初始化下拉框
                Dictionary<string, string> jss = new Dictionary<string, string>();
                TFendian[] fs = null;
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    //显示搜索
                    div_sch_jms.Visible = true;
                    div_edit_jms.Visible = true;

                    TJiamengshang[] jmss = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_jms_edit, jmss, "mingcheng", "id");
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmss, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商",""));

                    jss = Tool.CommonFunc.GetDicFromEnum(typeof(Tool.JCSJ.DBCONSTS.USER_XTJS));

                    //分店下拉框
                    fs = db.GetFendiansAsItems(null);
                }
                else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                         _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理)
                {
                    jss.Add(((byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员).ToString(),Tool.JCSJ.DBCONSTS.USER_XTJS.管理员.ToString());
                    jss.Add(((byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理).ToString(),Tool.JCSJ.DBCONSTS.USER_XTJS.经理.ToString());
                    jss.Add(((byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码).ToString(), Tool.JCSJ.DBCONSTS.USER_XTJS.编码.ToString());
                    jss.Add(((byte)Tool.JCSJ.DBCONSTS.USER_XTJS.店长).ToString(), Tool.JCSJ.DBCONSTS.USER_XTJS.店长.ToString());

                    //分店下拉框
                    fs = db.GetFendiansAsItems(_LoginUser.jmsid);

                    //加载用户
                    loadUsers();
                }

                Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
                Tool.CommonFunc.InitDropDownList(cmb_js, jss);
                Tool.CommonFunc.InitDropDownList(cmb_zt, typeof(Tool.JCSJ.DBCONSTS.USER_ZT));
            }            
        }

       

        /// <summary>
        /// 加载所属的加盟商的系统用户
        /// </summary>
        private void loadUsers()
        {   
            DBContext db = new DBContext();
            int? jmsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    jmsid = int.Parse(cmb_jms.SelectedValue);
                }
                grid_yonghu.Columns[0].Visible = true;
            }
            else
            {
                grid_yonghu.Columns[0].Visible = false;
                jmsid = _LoginUser.jmsid;
            }

            TUser[] us = db.GetUsers(jmsid);
            //排除其中的系统管理员和总经理账号
            if (!(_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理))
            {
                us = us.Where(r => r.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 &&
                    r.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理).ToArray();
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
            Authenticate.CheckOperation(_PageName, PageOpt.修改, _LoginUser);

            TUser nu = getEditInfo();
            nu.id = int.Parse(hid_id.Value);
            nu.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            TUser ou = db.GetUserById(nu.id);
            if (!(ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理))
            {
                //不允许在界面直接将权限提升为这两个角色
                if (nu.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    nu.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    throw new MyException("不允许将其他角色提升到该权限", null);
                }
            }

            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {

            }
            else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员)
            {
                if (ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    throw new MyException("非法操作，无法修改该账户信息", null);
                }
                if (ou.jmsid != _LoginUser.jmsid)
                {
                    throw new MyException("非法操作，无法修改该账户信息", null);
                }
            }
            else
            {
                throw new MyException("非法操作，无法修改该账户信息", null);
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
                throw new MyException("非法操作，请刷新页面重新执行", null);
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
            nu.jiqima = "";
            nu.charushijian = DateTime.Now;
            nu.xiugaishijian = DateTime.Now;


            //确保不能新建比自己权限高的账户
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                nu.jmsid = int.Parse(cmb_jms_edit.SelectedValue);
                //可以添加这两个高权限账号，但是这两个账号必须跟自己属于同一个加盟商
                if (nu.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    nu.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    if (nu.jmsid != _LoginUser.jmsid)
                    {
                        throw new MyException("不允许给其他加盟商增加该类型账户", null);
                    }
                }         
            }
            else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员)
            {
                if (nu.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                nu.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    throw new MyException("非法操作，无法增加", null);
                }
                nu.jmsid = _LoginUser.jmsid;
            }
            else
            {
                throw new MyException("非法操作，无法增加", null);
            }

            DBContext db = new DBContext();
            int cc = db.GetUserCount(_LoginUser.jmsid);
            if (cc >= _LoginUser.TJiamengshang.zhanghaoshu)
            {
                throw new MyException("拥有的账号数已到上限，如需增加更多账号请联系系统管理员", null);
            }

            db.InsertUser(nu);

            loadUsers();
        }

        /// <summary>
        /// 删除一个账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void grid_yonghu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    //权限检查
        //    Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

        //    int id = int.Parse(grid_yonghu.DataKeys[e.RowIndex].Value.ToString());

        //    DBContext db = new DBContext();
        //    TUser ou = db.GetUserById(id);
        //    //不能删除别人的用户
        //    if (_LoginUser.id == id)
        //    {
        //        throw new MyException("不能删除自己", null);
        //    }
        //    if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
        //    {

        //    }
        //    else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员)
        //    {
        //        if (ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
        //            ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
        //        {
        //            throw new MyException("非法操作，无法删除该用户", null);
        //        }
        //        if (ou.jmsid != _LoginUser.jmsid)
        //        {
        //            throw new MyException("非法操作，无法删除该用户", null);
        //        }
        //    }

        //    db.DeleteUser(id);

        //    loadUsers();
        //}

        /// <summary>
        /// 查询账户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sch_Click(object sender, EventArgs e)
        {
            loadUsers();
        }

        /// <summary>
        /// 给店长角色增加一个管辖的分店
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_fdsel_ok_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            int uid = int.Parse(hid_id.Value);
            int fid = int.Parse(cmb_fd.SelectedValue);

            DBContext db = new DBContext();
            TUser u = db.GetUserById(uid);
            TFendian f = db.GetFendianById(fid);
            if (u.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.店长)
            {
                throw new MyException("只能给店长增加管辖的分店", null);
            }
            if (u.jmsid != f.jmsid)
            {
                throw new MyException("用户和分店不属于同一个加盟商，无法增加", null);
            }

            TUserFendian uf = db.GetUserFendiansByUidFdid(uid, fid);
            if (uf == null)
            {
                TUserFendian nuf = new TUserFendian 
                {
                    userid = uid,
                    fendianid = fid
                };

                db.InsertUserFendian(nuf);

                //重新加载数据
                loadFendians(uid);
            }
        }

        protected void grid_ufs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DEL")
            {
                Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

                int index = Convert.ToInt32(e.CommandArgument);
                int id = int.Parse(grid_ufs.DataKeys[index].Value.ToString());
                DBContext db = new DBContext();
                TUserFendian oj = db.GetUserFendiansById(id);
                TUser ou = db.GetUserById(oj.userid);
                if (ou.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
                {
                    throw new MyException("非法操作，无法删除", null);
                }
                db.DeleteUserFendian(id);

                //重新加载数据
                loadFendians(int.Parse(hid_id.Value));
            }
        }

        protected void grid_yonghu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DBContext db = new DBContext();
            int index = Convert.ToInt32(e.CommandArgument);
            int id = int.Parse(grid_yonghu.DataKeys[index].Value.ToString());
            if (e.CommandName == "FDS")
            {
                //为了给用户分店表删除一行后，加载数据用
                hid_id.Value = id.ToString();

                //加载分店
                loadFendians(id);
            }
            else if (e.CommandName == "DEL")
            {
                //权限检查
                Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);
                TUser ou = db.GetUserById(id);
                //不能删除别人的用户
                if (_LoginUser.id == id)
                {
                    throw new MyException("不能删除自己", null);
                }
                //不能删除高权限的账号
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员)
                {
                    if (ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                    {
                        throw new MyException("非法操作，无法删除该用户", null);
                    }
                    if (ou.jmsid != _LoginUser.jmsid)
                    {
                        throw new MyException("非法操作，无法删除该用户", null);
                    }
                }

                db.DeleteUser(id);

                loadUsers();
            }
        }

        /// <summary>
        /// 加载某用户管辖下的所有分店
        /// </summary>
        /// <param name="id"></param>
        private void loadFendians(int id)
        {
            DBContext db = new DBContext();
            TUserFendian[] ufs = db.GetUserFendiansByUserId(id);
            var data = ufs.Select(r => new
            {
                id = r.id,
                dianming = r.TFendian.dianming
            });

            grid_ufs.DataSource = Tool.CommonFunc.LINQToDataTable(data);
            grid_ufs.DataBind();
        }
    }
}