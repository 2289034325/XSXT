using DB_JCSJ;
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
            //string uid = Request["uid"];
            //string psw = Request["psw"];
            //string pms = "";
            //if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(psw))
            //{
            //    pms = "uid=" + uid + "&psw=" + psw + "&";
            //}
            if (u == null)
            {
                Response.Redirect("Login.aspx?" + "despage=" + Request.Url.AbsoluteUri);
                //Response.Redirect("Login.aspx");
            }
            //权限检查
            else
            {
                //用户界面只有系统管理员有权限
                if (Request.Url.Segments.Last() == "Page_User.aspx")
                {
                    if (u.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
                    {
                        //Response.Redirect("Page_Error.aspx?ErrorMsg=没有权限");
                        throw new MyException("没有权限");
                    }
                }
                //其他页面只有系统管理员和总经理有权限
                else
                {
                    if (u.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 && 
                        u.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                    {
                        //Response.Redirect("Page_Error.aspx?ErrorMsg=没有权限");
                        throw new MyException("没有权限");
                    }
                }
            }

        }
    }
}