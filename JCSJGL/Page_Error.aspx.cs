using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JCSJG
{
    public partial class Page_Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //显示错误信息
            lbl_errorMsg.Text = Request["ErrorMsg"];
        }
    }
}