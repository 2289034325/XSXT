using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JCSJGL
{
    public partial class Page_Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception ex = (Exception)Application["Error"];
            if (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            //显示错误信息
            if (ex is MyException)
            {
                lbl_errorMsg.Text = ex.Message;
            }
            else
            {
                lbl_errorMsg.Text = "系统发生未知错误";
            }
        }
    }
}