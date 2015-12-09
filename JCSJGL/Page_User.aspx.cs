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
                DBContext db = new DBContext();
                div_sch_xtyh.Visible = false;

                //初始化下拉框
                Dictionary<string, string> jss = new Dictionary<string, string>();
                TFendian[] fs = null;
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    div_sch_xtyh.Visible = true;

                    TJiamengshang[] jmss = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmss, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("", ""));

                    TPinpaishang[] ppss = db.GetPinpaishangs(null);
                    Tool.CommonFunc.InitDropDownList(cmb_pps, ppss, "mingcheng", "id");
                    cmb_pps.Items.Insert(0, new ListItem("", ""));

                    //角色
                    jss.Add(((byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员).ToString(), Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员.ToString());
                    jss.Add(((byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理).ToString(), Tool.JCSJ.DBCONSTS.USER_XTJS.总经理.ToString());
                    
                    //分店下拉框
                    fs = db.GetFendiansAsItems(null);
                }
                else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员 ||
                         _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商经理)
                {
                    //隐藏搜索条件
                    div_sch_pps.Visible = false;
                    div_sch_jms.Visible = false;
                    grid_yonghu.Columns[0].Visible = false;
                    grid_yonghu.Columns[1].Visible = false;

                    jss.Add(((byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员).ToString(), Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员.ToString());
                    jss.Add(((byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商经理).ToString(), Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商经理.ToString());
                    jss.Add(((byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商编码).ToString(), Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商编码.ToString());
                    
                    //加载用户
                    loadUsers();
                }
                else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商管理员 ||
                         _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商经理)
                {
                    //隐藏搜索条件
                    div_sch_pps.Visible = false;
                    div_sch_jms.Visible = false;
                    grid_yonghu.Columns[0].Visible = false;
                    grid_yonghu.Columns[1].Visible = false;

                    jss.Add(((byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商管理员).ToString(), Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商管理员.ToString());
                    jss.Add(((byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商经理).ToString(), Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商经理.ToString());
                    
                    //加载用户
                    loadUsers();
                }

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
            TUser[] us = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (chk_xtyh.Checked)
                {
                    //系统用户
                    us = db.GetUsersOfSys();
                }
                else
                {
                    if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                    {
                        //加盟商用户
                        us = db.GetUsersByJmsid(int.Parse(cmb_jms.SelectedValue));
                    }
                    else if (!string.IsNullOrEmpty(cmb_pps.SelectedValue))
                    {
                        //品牌商用户
                        us = db.GetUsersByPpsid(int.Parse(cmb_pps.SelectedValue));
                    }
                    else
                    {
                        throw new MyException("加盟商或者品牌商必须选择一个", null);
                    }
                }
            }
            else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商经理)
            {
                us = db.GetUsersByJmsid(_LoginUser.jmsid.Value);
            }
            else
            {
                us = db.GetUsersByPpsid(_LoginUser.ppsid.Value); 
            }

            var dus = us.Select(r => new
            {
                id = r.id,
                pinpaishang = r.TPinpaishang == null ? "" : r.TPinpaishang.mingcheng,
                jiamengshang = r.TJiamengshang == null ? "" : r.TJiamengshang.mingcheng,
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
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.修改, _LoginUser);

            TUser nu = getEditInfo();
            nu.id = int.Parse(hid_id.Value);
            nu.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            TUser ou = db.GetUserById(nu.id);

            //不能修改自己的角色
            if (nu.id == _LoginUser.id)
            {
                if (nu.juese != _LoginUser.juese)
                {
                    throw new MyException("不能修改自己的角色", null);
                }

                if (nu.zhuangtai == (byte)Tool.JCSJ.DBCONSTS.USER_ZT.停用)
                {
                    throw new MyException("不能将自己的账号停用", null);
                }
            }

            //不允许在界面直接将权限提升为这两个角色
            if (nu.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                nu.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!(ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理))
                {
                    throw new MyException("不允许将用户提升到该角色权限", null);
                }
            }            
            else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员)
            {
                if (ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    throw new MyException("非法操作，无法修改该账户信息", null);
                }
                //不允许修改其他品牌商的账号信息
                if (ou.ppsid != _LoginUser.ppsid)
                {
                    throw new MyException("非法操作，无法修改该账户信息", null);
                }
            }
            else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商管理员)
            {
                if (ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                                   ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    throw new MyException("非法操作，无法修改该账户信息", null);
                }
                //不允许修改其他加盟商的账号信息
                if (_LoginUser.jmsid != null && ou.jmsid != _LoginUser.jmsid)
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

            DBContext db = new DBContext();

            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员)
            {
                if (nu.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                nu.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    throw new MyException("非法操作，无法增加", null);
                }

                nu.ppsid = _LoginUser.ppsid;

                int cc = db.GetUserCountPps(nu.ppsid.Value);
                if (cc >= _LoginUser.TPinpaishang.zhanghaoshu)
                {
                    throw new MyException("拥有的账号数已到上限，如需增加更多账号请联系系统管理员", null);
                }
            }
            else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商管理员)
            {
                if (nu.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                nu.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    throw new MyException("非法操作，无法增加", null);
                }

                nu.jmsid = _LoginUser.jmsid;

                int cc = db.GetUserCountJms(nu.jmsid.Value);
                if (cc >= _LoginUser.TJiamengshang.zhanghaoshu)
                {
                    throw new MyException("拥有的账号数已到上限，如需增加更多账号请联系系统管理员", null);
                }
            }

            db.InsertUser(nu);

            loadUsers();
        }

        /// <summary>
        /// 查询账户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sch_Click(object sender, EventArgs e)
        {
            loadUsers();
        }

        protected void grid_yonghu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                return;
            }

            DBContext db = new DBContext();
            int index = Convert.ToInt32(e.CommandArgument);
            int id = int.Parse(grid_yonghu.DataKeys[index].Value.ToString());
            if (e.CommandName == "DEL")
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
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员)
                {
                    if (ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        ou.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                    {
                        throw new MyException("非法操作，无法删除该用户", null);
                    }
                    if (ou.ppsid != _LoginUser.ppsid)
                    {
                        throw new MyException("非法操作，无法删除该用户", null);
                    }
                }
                else if(_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商管理员)
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
    }
}