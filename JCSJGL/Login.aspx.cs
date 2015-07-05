using DB_JCSJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JCSJGL
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string dlm = Request["txb_dlm"];
                string mm = Request["txb_mm"];
                doLogin(dlm,mm);
            }
            else
            {
                string uid = Request["uid"];
                string psw = Request["psw"];
                
                if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(psw))
                {
                    doLogin(uid, psw);
                }
            }
        }

        private void doLogin(string dlm, string mm)
        {
            string md5mm = Tool.CommonFunc.MD5_16(mm);

            DBContext db = new DBContext();
            TUser u = db.GetUser(dlm, md5mm);
            if (u == null)
            {
                Response.Redirect("Page_Error.aspx?ErrorMsg=用户名或密码不正确");
            }
            else
            {
                if (u.zhuangtai == (byte)Tool.JCSJ.DBCONSTS.USER_ZT.停用)
                {
                    Response.Redirect("Page_Error.aspx?ErrorMsg=该账号已经被停用");
                }
                else
                {
                    Session["USER"] = u;
                    string page = Request["despage"];
                    if (string.IsNullOrEmpty(page))
                    {
                        page = "Page_Tiaoma.aspx";
                    }
                    Response.Redirect(page);
                }
            }
        }
    }
}