using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

namespace JCSJGL
{
    public partial class Page_Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception ex = (Exception)Application["Error"];
            int i = 0;
            string msg = null;
            if (ex is MyException)
            {
                msg = ex.Message;
            }
            else if (ex is SqlException)
            {
                if (ex.Message.Contains("REFERENCE"))
                {
                    msg = "要删除的数据正在被其他数据引用，请先删除引用该数据的数据！";
                }
                else if (ex.Message.Contains("UNIQUE"))
                {
                    msg = "发现重复数据！";
                }
            }

            if (msg == null)
            {
                while (ex.InnerException != null)
                {
                    //防止无线循环
                    if (i > 5)
                    {
                        break;
                    }

                    ex = ex.InnerException;
                    if (ex is MyException)
                    {
                        msg = ex.Message;
                    }
                    else if (ex is SqlException)
                    {
                        if (ex.Message.Contains("REFERENCE"))
                        {
                            msg = "要删除的数据正在被其他数据引用，请先删除引用该数据的数据！";
                        }
                        else if (ex.Message.Contains("UNIQUE"))
                        {
                            msg = "发现重复数据！";
                        }
                    }

                    //防止无线循环
                    i++;
                }
            }

            if (msg == null)
            {
                msg = "发生未知的系统错误，请联系系统管理员";
            }

            lbl_errorMsg.Text = msg;
        }
    }
}