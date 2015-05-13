using DB_JCSJ;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;
using Tool;

namespace JCSJWCF
{
    public class ValidService : IValidService
    {
        /// <summary>
        /// 编码系统注册
        /// </summary>
        /// <param name="dlm">登录名</param>
        /// <param name="mm">密码</param>
        /// <param name="xm">姓名</param>
        /// <param name="zcm">注册码</param>
        /// <param name="tzm">客户端机器特征码</param>
        /// <returns></returns>
        public void BMZHZhuce(string dlm, string mm, string xm, string tzm, string zcm)
        {
            //验证注册码
            if (!validateDTMM(zcm))
            {
                throw new FaultException("注册码错误");
            }
            else
            {
                TUser u = new TUser();
                //生成新用户
                u.dengluming = dlm;
                u.yonghuming = xm;
                u.mima = mm;
                u.jiqima = tzm;
                u.juese = (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码员;
                u.zhuangtai = (byte)Tool.JCSJ.DBCONSTS.USER_ZT.可用;
                u.beizhu = "";
                u.charushijian = DateTime.Now;
                u.xiugaishijian = DateTime.Now;

                DBContext db = new DBContext();
                TUser nu = db.InsertUser(u);
            }
        }

        /// <summary>
        /// 仓库系统注册
        /// </summary>
        /// <param name="ckid">仓库id</param>
        /// <param name="ckmc">仓库名</param>
        /// <param name="tzm">机器特征码</param>
        /// <param name="zcm">注册码</param>
        public void CKZHZhuce(int ckid, string ckmc, string tzm, string zcm)
        {
            //验证注册码
            if (!validateDTMM(zcm))
            {
                throw new FaultException("注册码错误");
            }
            else
            {
                DBContext db = new DBContext();
                //检查仓库ID和仓库名称是否匹配
                if (db.GetCangkuByIdMc(ckid, ckmc) == null)
                {
                    throw new FaultException("仓库ID和仓库名称不匹配");
                }

                //检查账号是否已经存在
                TUser u = db.GetUserByDlm(Tool.JCSJ.DBCONSTS.USER_DLM_PRE_CK + ckid);
                if (u == null)
                {
                    u = new TUser();
                    //登陆名由一个前缀加上仓库ID组成
                    u.dengluming = Tool.JCSJ.DBCONSTS.USER_DLM_PRE_CK + ckid;
                    u.yonghuming = ckmc;
                    u.mima = Tool.CommonFunc.MD5_16(ckid.ToString());
                    u.jiqima = tzm;
                    u.juese = (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.仓库系统;
                    u.zhuangtai = (byte)Tool.JCSJ.DBCONSTS.USER_ZT.可用;
                    u.beizhu = "";
                    u.charushijian = DateTime.Now;
                    u.xiugaishijian = DateTime.Now;

                    db.InsertUser(u);
                }
                else
                {
                    u.jiqima = tzm;
                    u.xiugaishijian = DateTime.Now;

                    db.UpdateUserInfo(u);
                }
            }
        }

        /// <summary>
        /// 分店账号注册
        /// </summary>
        /// <param name="fdid">分店ID</param>
        /// <param name="fdmc">分店名</param>
        /// <param name="tzm">机器码</param>
        /// <param name="zcm">注册码</param>
        public void FDZHZhuce(int fdid, string fdmc, string tzm, string zcm)
        {
            //验证注册码
            if (!validateDTMM(zcm))
            {
                throw new FaultException("注册码错误");
            }
            else
            {
                DBContext db = new DBContext();
                //检查分店ID和分店名称是否匹配
                if (db.GetFendianByIdMc(fdid, fdmc) == null)
                {
                    throw new FaultException("分店ID和店名不匹配");
                }

                //检查账号是否已经存在
                TUser u = db.GetUserByDlm(Tool.JCSJ.DBCONSTS.USER_DLM_PRE_FD + fdid);
                if (u == null)
                {
                    u = new TUser();
                    //登陆名由一个前缀加上分店ID组成
                    u.dengluming = Tool.JCSJ.DBCONSTS.USER_DLM_PRE_FD + fdid;
                    u.yonghuming = fdmc;
                    u.mima = Tool.CommonFunc.MD5_16(fdid.ToString());
                    u.jiqima = tzm;
                    u.juese = (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.分店系统;
                    u.zhuangtai = (byte)Tool.JCSJ.DBCONSTS.USER_ZT.可用;
                    u.beizhu = "";
                    u.charushijian = DateTime.Now;
                    u.xiugaishijian = DateTime.Now;

                    db.InsertUser(u);
                }
                else
                {
                    u.jiqima = tzm;
                    u.xiugaishijian = DateTime.Now;

                    db.UpdateUserInfo(u);
                }
            }
        }

        /// <summary>
        /// 编码系统账号绑定
        /// </summary>
        /// <param name="dlm">登录名</param>
        /// <param name="mm">密码</param>
        /// <param name="tzm">机器特征码</param>
        /// <param name="zcm">注册码</param>
        public void BMZHBangding(string dlm, string mm, string tzm, string zcm)
        {
            //验证账号密码
            DBContext db = new DBContext();
            TUser u = db.GetUser(dlm, mm);
            if (u == null)
            {
                throw new FaultException("用户名或密码不正确");
            }
            else
            {
                //验证注册码
                if (!validateDTMM(zcm))
                {
                    throw new FaultException("注册码不正确");
                }
                else
                {
                    //将机器特征码写入数据库
                    db.UpdateUserJQM(u.id, tzm);
                }
            }
        }

        /// <summary>
        /// 验证动态密码
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        private bool validateDTMM(string mm)
        {
            string bm = getDTMM();
            if (mm == bm)
            {
                //重新生成动态密码
                string nm = makeNewDTMM();
                setNewDTMM(nm);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 生成新的动态密码
        /// </summary>
        /// <returns></returns>
        private string makeNewDTMM()
        {
            Random r = new Random();
            string nm = "";
            string[] sources = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            for (int i = 0; i < 5; i++)
            {
                nm += sources[r.Next(0, sources.Length - 1)];
            }

            return nm;
        }

        /// <summary>
        /// 将新动态密码保存入配置文件
        /// </summary>
        /// <param name="nm"></param>
        private void setNewDTMM(string nm)
        {
            XElement xe = XElement.Load(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Settings.xml"));
            XElement dmnode = xe.Elements().Single(r => r.Name == "DTMM");
            dmnode.Value = nm;

            xe.Save(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Settings.xml"));
        }

        /// <summary>
        /// 从配置文件取得动态密码
        /// </summary>
        /// <returns></returns>
        private string getDTMM()
        {
            XElement xe = XElement.Load(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Settings.xml"));
            XElement dmnode = xe.Elements().Single(r => r.Name == "DTMM");

            return dmnode.Value;
        }

       
    }
}
