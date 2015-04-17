using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool.DB;

namespace JCSJZX
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            TUser user = (TUser)Session["USER"];
            //检测是否登陆
            if (user == null)
            {
                Response.Redirect("~/Page_Login.aspx");
            }
            else
            {
                //权限检查
                //User页面，只有管理员可以进
                if (Request.RawUrl == "/Page_Users.aspx")
                {
                    if (user.juese != (byte)CONSTS.XTJS.系统管理员)
                    {
                        Response.End();
                    }
                }
                //其他页面，只有管理员和总经理可以进入
                else
                {
                    if (user.juese != (byte)CONSTS.XTJS.系统管理员 && user.juese != (byte)CONSTS.XTJS.总经理)
                    {
                        Response.End();
                    }
                }
            }
        }
    }
}