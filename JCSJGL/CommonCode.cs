using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JCSJGL
{
    public enum PageName
    {
        用户管理,
        分店信息,
        仓库信息,
        供应商信息,
        加盟商信息,
        款号信息,
        条码信息
    }
    public enum PageOpt
    {
        增加,
        修改,
        删除
    }

    public class MyPage : System.Web.UI.Page
    {
        protected PageName _PageName;
        protected TUser _LoginUser;

        /// <summary>
        /// 页面初始化时，检查访问权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            _LoginUser = (TUser)Session["USER"];
            Authenticate.CheckAccess(_PageName,_LoginUser);
        }
    }

    public class MyException:Exception
    {
        public MyException(string msg)
            : base(msg)
        {
 
        }
    }

    /// <summary>
    /// 权限检查
    /// </summary>
    public class Authenticate
    {
        public static void CheckAccess(PageName Page, DB_JCSJ.Models.TUser LoginUser)
        {
            if (Page == PageName.加盟商信息)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理))
                {
                    throw new MyException("没有权限");
                }
            }
            else if (Page == PageName.用户管理)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                {
                    throw new MyException("没有权限");
                }
            }
            else if (Page == PageName.分店信息)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                {
                    throw new MyException("没有权限");
                }
            }
            else if (Page == PageName.仓库信息)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                {
                    throw new MyException("没有权限");
                }
            }
            else if (Page == PageName.供应商信息)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                {
                    throw new MyException("没有权限");
                }
            }
            else if (Page == PageName.款号信息)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码员))
                {
                    throw new MyException("没有权限");
                }
            }
        }

        public static void CheckOperation(PageName Page, PageOpt OPT, DB_JCSJ.Models.TUser LoginUser)
        {
            if (Page == PageName.加盟商信息)
            {
                if (OPT == PageOpt.增加)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理))
                    {
                        throw new MyException("没有权限");
                    }
                }
                else if (OPT == PageOpt.修改)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理))
                    {
                        throw new MyException("没有权限");
                    }
                }
                else if (OPT == PageOpt.删除)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员))
                    {
                        throw new MyException("没有权限");
                    }

                }
            }
            else if (Page == PageName.用户管理)
            {
                if (OPT == PageOpt.增加)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 || 
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                    {
                        throw new MyException("没有权限");
                    }
                }
                else if (OPT == PageOpt.修改)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                    {
                        throw new MyException("没有权限");
                    }
                }
                else if (OPT == PageOpt.删除)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员))
                    {
                        throw new MyException("没有权限");
                    }

                }
            } 
            else if (Page == PageName.分店信息)
            {
                if (OPT == PageOpt.增加)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                    {
                        throw new MyException("没有权限");
                    }
                }
                else if (OPT == PageOpt.修改)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                    {
                        throw new MyException("没有权限");
                    }
                }
                else if (OPT == PageOpt.删除)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员))
                    {
                        throw new MyException("没有权限");
                    }

                }
            }
            else if (Page == PageName.仓库信息)
            {
                if (OPT == PageOpt.增加)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                    {
                        throw new MyException("没有权限");
                    }
                }
                else if (OPT == PageOpt.修改)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                    {
                        throw new MyException("没有权限");
                    }
                }
                else if (OPT == PageOpt.删除)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员))
                    {
                        throw new MyException("没有权限");
                    }

                }
            }
            else if (Page == PageName.供应商信息)
            {
                if (OPT == PageOpt.增加)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                    {
                        throw new MyException("没有权限");
                    }
                }
                else if (OPT == PageOpt.修改)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                    {
                        throw new MyException("没有权限");
                    }
                }
                else if (OPT == PageOpt.删除)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                    {
                        throw new MyException("没有权限");
                    }

                }
            }
            else if (Page == PageName.款号信息)
            {
                if (OPT == PageOpt.增加)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码员))
                    {
                        throw new MyException("没有权限");
                    }
                }
                else if (OPT == PageOpt.修改)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码员))
                    {
                        throw new MyException("没有权限");
                    }
                }
                else if (OPT == PageOpt.删除)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码员))
                    {
                        throw new MyException("没有权限");
                    }

                }
            }
        }
    }
}