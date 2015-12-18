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
    public partial class Main : System.Web.UI.MasterPage
    {
        public string LoginUser
        {
            get {
                TUser u = (TUser)Session["USER"];
                if (u == null)
                    return "";
                else return u.yonghuming;
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            //登陆验证
            TUser u = (TUser)Session["USER"];
            if (u == null)
            {
                Response.Redirect("Login.aspx?" + "despage=" + Request.Url.AbsoluteUri);
            }
            else
            {
                //根据登录用户的角色不同，显示不同的菜单
                if (u.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 || u.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    mn_admin.Visible = true;
                    mn_jms.Visible = false;
                    mn_pps.Visible = false;
                }
                else if (u.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员 || u.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商经理 ||
                    u.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商编码)
                {
                    mn_admin.Visible = false;
                    mn_pps.Visible = true;
                    mn_jms.Visible = false;
                }
                else
                {
                    mn_admin.Visible = false;
                    mn_pps.Visible = false;
                    mn_jms.Visible = true;
                }
            }
        }

        //protected void mn_Load(object sender, EventArgs e)
        //{
        //    TUser u = (TUser)Session["USER"];
        //    Menu mn = (Menu)sender;

        //    //隐藏部分菜单
        //    if (!(u.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 || u.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理))
        //    {
        //        List<MenuItem> hmi = new List<MenuItem>();
        //        foreach (MenuItem mi in mn.Items)
        //        {
        //            if (mi.Text.Contains("加盟商信息") || mi.Text.Contains("注册码"))
        //            {
        //                hmi.Add(mi);
        //            }
        //        }

        //        foreach(MenuItem mi in hmi)
        //        {
        //            mn.Items.Remove(mi);
        //        }
        //    }

        //    //如果没有下级子加盟商，不显示发货退货页面
        //    if (!(u.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 || u.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理))
        //    {
        //        DBContext db = new DBContext();
        //        TJiamengshang jms = db.GetJiamengshangById(u.jmsid);
        //        if (jms.zjmsshu <= 0)
        //        {
        //            List<MenuItem> hmi = new List<MenuItem>(); ;
        //            foreach (MenuItem mi in mn.Items)
        //            {
        //                if (mi.Text.Contains("发货退货"))
        //                {
        //                    hmi.Add(mi);
        //                }
        //            }

        //            foreach (MenuItem mi in hmi)
        //            {
        //                mn.Items.Remove(mi);
        //            }
        //        }
        //    }
        //}
    }
}