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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string dlm = txb_dlm.Value.Trim();
                string mm = txb_mm.Value;
                doLogin(dlm, mm);
            }
            else
            {
                //string uid = Request["uid"];
                //string psw = Request["psw"];

                //if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(psw))
                //{
                //    doLogin(uid, psw);
                //}

                string desPage = Request["despage"];
                if (!string.IsNullOrEmpty(desPage))
                {
                    string isAuto = getCookie("AUTOLOGIN", "AUTO");
                    string uid = getCookie("AUTOLOGIN", "UID");
                    string psw = getCookie("AUTOLOGIN", "PSW");
                    if (isAuto == "True")
                    {
                        doLogin(uid, psw);
                    }
                }
                else
                {
                    //退出登陆
                    Session["USER"] = null;
                    setCookie(false);
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
                setCookie(false);
                //Response.Redirect("Page_Error.aspx?ErrorMsg=用户名或密码不正确");
                throw new MyException("用户名或密码不正确");
            }
            else
            {
                if (u.zhuangtai == (byte)Tool.JCSJ.DBCONSTS.USER_ZT.停用)
                {
                    setCookie(false);
                    //Response.Redirect("Page_Error.aspx?ErrorMsg=该账号已经被停用");
                    throw new MyException("该账号已经被停用");
                }
                else
                {
                    Session["USER"] = u;
                    string page = Request["despage"];
                    if (string.IsNullOrEmpty(page))
                    {
                        page = "Page_Tiaoma.aspx";
                    }
                    //写cookie
                    if (chk_auto.Checked)
                    {
                        setCookie(true);
                    }
                    Response.Redirect(page);
                }
            }
        }

        /// <summary>
        /// 写cookie
        /// </summary>
        /// <param name="isAuto">是否自动登陆</param>
        private void setCookie(bool isAuto)
        {
            HttpCookie cookie = new HttpCookie("AUTOLOGIN");
            DateTime dt = DateTime.Now;
            //过期时间为30天
            TimeSpan ts = new TimeSpan(30, 0, 0, 0, 0);
            cookie.Expires = dt.Add(ts);
            cookie.Values.Add("AUTO", chk_auto.Checked.ToString());
            cookie.Values.Add("UID", txb_dlm.Value.Trim());
            cookie.Values.Add("PSW", txb_mm.Value);
            Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 取cookie
        /// </summary>
        /// <param name="cName">cookie名</param>
        /// <param name="kName">键名</param>
        /// <returns></returns>
        private string getCookie(string cName, string kName)
        {
            string ret = null;
            if (Request.Cookies[cName] != null)
            {
                ret = Request.Cookies[cName][kName];
            }
            return ret;
        }
    }
}