using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Tool;

namespace JCSJGL
{
    public enum PageName
    {
        地区编码,
        用户管理,
        分店信息,
        仓库信息,
        供应商信息,
        加盟商信息,
        加盟商关系,
        款号信息,
        条码信息,
        会员信息,
        销售数据,
        分店销售统计图,
        分店销售统计表,
        款号分析,
        分店进出货,
        分店进出货明细,
        分店库存,
        分店库存明细,
        仓库进出货,
        仓库进出货明细,
        仓库库存,
        仓库库存明细,
        加盟商发货退货,
        动态验证码,
        注册码,
        我的信息
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

    //public class MyException:Exception
    //{
    //    public MyException(string msg)
    //        : base(msg)
    //    {
 
    //    }
    //}

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
                    throw new MyException("没有权限",null);
                }
            }
            else if (Page == PageName.加盟商关系)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                {
                    throw new MyException("没有权限", null);
                }
            }
            else if (Page == PageName.用户管理)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                {
                    throw new MyException("没有权限",null);
                }
            }
            else if (Page == PageName.分店信息)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                {
                    throw new MyException("没有权限",null);
                }
            }
            else if (Page == PageName.仓库信息)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                {
                    throw new MyException("没有权限",null);
                }
            }
            else if (Page == PageName.供应商信息)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                {
                    throw new MyException("没有权限",null);
                }
            }
            else if (Page == PageName.款号信息)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码))
                {
                    throw new MyException("没有权限",null);
                }
            }
            else if (Page == PageName.条码信息)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码))
                {
                    throw new MyException("没有权限",null);
                }
            }
            else if (Page == PageName.会员信息)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                {
                    throw new MyException("没有权限",null);
                }
            }
            else if (Page == PageName.销售数据)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                {
                    throw new MyException("没有权限",null);
                }
            }
            else if (Page == PageName.分店进出货 || Page == PageName.分店进出货明细 ||
                     Page == PageName.分店库存 || Page == PageName.分店库存明细)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                {
                    throw new MyException("没有权限",null);
                }
            }
            else if (Page == PageName.仓库进出货 || Page == PageName.仓库进出货明细 ||
                     Page == PageName.仓库库存 || Page == PageName.仓库库存明细)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                {
                    throw new MyException("没有权限",null);
                }
            }
            else if (Page == PageName.分店销售统计表 || Page == PageName.分店销售统计图)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理 ))
                {
                    throw new MyException("没有权限",null);
                }
            }
            else if (Page == PageName.动态验证码)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                {
                    throw new MyException("没有权限",null);
                }
            }
            else if (Page == PageName.注册码)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理))
                {
                    throw new MyException("没有权限", null);
                }
            }
            else if (Page == PageName.地区编码)
            {
                if (LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
                {
                    throw new MyException("没有权限",null);
                }
            }
            else if (Page == PageName.我的信息)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                {
                    throw new MyException("没有权限", null);
                }
            }
            else if (Page == PageName.款号分析)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                {
                    throw new MyException("没有权限", null);
                }
            }
            else if (Page == PageName.加盟商发货退货)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                    LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.经理))
                {
                    throw new MyException("没有权限", null);
                }
            }
            else
            {
                throw new MyException("没有权限",null);
            }
        }

        public static void CheckOperation(PageName Page, PageOpt OPT, DB_JCSJ.Models.TUser LoginUser)
        {
            if (Page == PageName.加盟商信息)
            {
                if (OPT == PageOpt.增加)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员))
                    {
                        throw new MyException("没有权限",null);
                    }
                }
                else if (OPT == PageOpt.修改)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员))
                    {
                        throw new MyException("没有权限",null);
                    }
                }
                else if (OPT == PageOpt.删除)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员))
                    {
                        throw new MyException("没有权限",null);
                    }

                }
            }
            else if (Page == PageName.用户管理)
            {
                if (OPT == PageOpt.增加)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 || 
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                    {
                        throw new MyException("没有权限",null);
                    }
                }
                else if (OPT == PageOpt.修改)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                    {
                        throw new MyException("没有权限",null);
                    }
                }
                else if (OPT == PageOpt.删除)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                    {
                        throw new MyException("没有权限",null);
                    }

                }
            } 
            else if (Page == PageName.分店信息)
            {
                if (OPT == PageOpt.增加)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                    {
                        throw new MyException("没有权限",null);
                    }
                }
                else if (OPT == PageOpt.修改)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                    {
                        throw new MyException("没有权限",null);
                    }
                }
                else if (OPT == PageOpt.删除)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                    {
                        throw new MyException("没有权限",null);
                    }

                }
            }
            else if (Page == PageName.仓库信息)
            {
                if (OPT == PageOpt.增加)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                    {
                        throw new MyException("没有权限",null);
                    }
                }
                else if (OPT == PageOpt.修改)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                    {
                        throw new MyException("没有权限",null);
                    }
                }
                else if (OPT == PageOpt.删除)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                    {
                        throw new MyException("没有权限",null);
                    }

                }
            }
            else if (Page == PageName.供应商信息)
            {
                if (OPT == PageOpt.增加)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                    {
                        throw new MyException("没有权限",null);
                    }
                }
                else if (OPT == PageOpt.修改)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                    {
                        throw new MyException("没有权限",null);
                    }
                }
                else if (OPT == PageOpt.删除)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                    {
                        throw new MyException("没有权限",null);
                    }

                }
            }
            else if (Page == PageName.款号信息)
            {
                if (OPT == PageOpt.增加)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码))
                    {
                        throw new MyException("没有权限",null);
                    }
                }
                else if (OPT == PageOpt.修改)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码))
                    {
                        throw new MyException("没有权限",null);
                    }
                }
                else if (OPT == PageOpt.删除)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码))
                    {
                        throw new MyException("没有权限",null);
                    }

                }
            }
            else if (Page == PageName.条码信息)
            {
                if (OPT == PageOpt.增加)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码))
                    {
                        throw new MyException("没有权限",null);
                    }
                }
                else if (OPT == PageOpt.修改)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码))
                    {
                        throw new MyException("没有权限",null);
                    }
                }
                else if (OPT == PageOpt.删除)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码))
                    {
                        throw new MyException("没有权限",null);
                    }

                }
            }
            else if (Page == PageName.会员信息)
            {
                if (OPT == PageOpt.增加)
                {
                    //会员信息只能在分店注册
                    throw new MyException("没有权限",null);
                }
                else if (OPT == PageOpt.修改)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                    {
                        throw new MyException("没有权限",null);
                    }
                }
                else if (OPT == PageOpt.删除)
                {
                    //删除会员会导致分店数据库的会员信息变为垃圾数据
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员))
                    {
                        throw new MyException("没有权限",null);
                    }

                }
            }
            else if (Page == PageName.分店库存)
            {
                if (OPT == PageOpt.增加)
                {
                    throw new MyException("没有权限",null);
                }
                else if (OPT == PageOpt.修改)
                {
                        throw new MyException("没有权限",null);
                }
                else if (OPT == PageOpt.删除)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                    {
                        throw new MyException("没有权限",null);
                    }

                }
            }
            else if (Page == PageName.仓库库存)
            {
                if (OPT == PageOpt.增加)
                {
                    throw new MyException("没有权限",null);
                }
                else if (OPT == PageOpt.修改)
                {
                    throw new MyException("没有权限",null);
                }
                else if (OPT == PageOpt.删除)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                        LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                    {
                        throw new MyException("没有权限",null);
                    }
                }
            }
            else if (Page == PageName.我的信息)
            {
                if (OPT == PageOpt.修改)
                {
                    if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                         LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                    {
                        throw new MyException("没有权限", null);
                    }
                }
            }
            else if (Page == PageName.加盟商发货退货)
            {
                if (!(LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                     LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员))
                {
                    throw new MyException("没有权限", null);
                }
            }
        }

    }

    public class SysTool
    {
        public static string zcmFile = HttpContext.Current.Server.MapPath("~") + "\\App_Data\\ZCM.txt";
        public static List<string> loadZcms()
        {
            //从文本文件加载                
            StreamReader sr = new StreamReader(zcmFile);
            List<string> zcms = new List<string>();
            while (!sr.EndOfStream)
            {
                string zcm = sr.ReadLine();
                if (string.IsNullOrEmpty(zcm) || string.IsNullOrWhiteSpace(zcm))
                {
                    continue;
                }

                zcms.Add(zcm);
            }
            sr.Close();

            return zcms;
        }

        public static void addZcms(List<string> nzcms)
        {
            List<string> zcms = loadZcms();
            zcms.AddRange(nzcms);
            StreamWriter sw = new StreamWriter(zcmFile, false);
            string sms = zcms.Aggregate((a,b)=>{return a+"\r\n"+b;});
            sw.Write(sms);
            sw.Flush();
            sw.Close();
        }

        public static void delZcm(string zcm)
        {
            List<string> zcms = loadZcms();
            zcms.Remove(zcm);
            StreamWriter sw = new StreamWriter(zcmFile, false);
            string sms = zcms.Aggregate((a, b) => { return a + "\r\n" + b; });
            sw.Write(sms);
            sw.Flush();
            sw.Close();
        }
    }
}