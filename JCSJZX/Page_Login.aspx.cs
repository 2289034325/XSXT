using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JCSJZX
{
    public partial class Page_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //取得用户输入的登录名和密码
                string dlm = Request["txb_dlm"].Trim();
                string mm = Request["txb_mm"];                

                //去数据库验证
                Tool.DB.JCSJ.OPT db = new Tool.DB.JCSJ.OPT();
                Tool.DB.JCSJ.TUser user = db.ValidateLogin(dlm, Tool.CommonFunc.MD5_16(mm));
                
                //如果验证通过，将用户信息保存到Session
                if (user != null)
                {
                    //保存到session
                    Session["USER"] = user;
                    //转向商品信息页面
                    Response.Redirect("~/Page_Tiaomaxinxi.aspx", true);
                }
            }
        }
    }
}