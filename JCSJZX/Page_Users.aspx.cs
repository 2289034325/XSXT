using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JCSJZX
{
    public partial class Page_Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            { }
            else
            {
                //加载除了管理员的所有用户
                Tool.DB.JCSJ.OPT db = new Tool.DB.JCSJ.OPT();
                grid_users.DataSource = db.GetAllUsers(false);
            }
        }
    }
}