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
        protected void Page_Init(object sender, EventArgs e)
        {
            //登陆验证
            TUser u = (TUser)Session["USER"];
            if (u == null)
            {
                Response.Redirect("Login.aspx?" + "despage=" + Request.Url.AbsoluteUri);
            }
        }

        protected void mn_main_Load(object sender, EventArgs e)
        {
            TUser u = (TUser)Session["USER"];

            //隐藏部分菜单
            if (!(u.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 || u.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理))
            {
                List<MenuItem> hmi = new List<MenuItem>(); ;
                foreach (MenuItem mi in div_mn_main.Items)
                {
                    if (mi.Text.Contains("加盟商信息") || mi.Text.Contains("注册码"))
                    {
                        hmi.Add(mi);
                    }
                }

                foreach(MenuItem mi in hmi)
                {
                    div_mn_main.Items.Remove(mi);
                }
            }
        }
    }
}