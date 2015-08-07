using DB_JCSJ;
using DB_JCSJ.Models;
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
    [MyExceptionBehavior(typeof(MyGlobalExceptionHandler))]
    public class ValidService : IValidService
    {
        //动态密码
        //private string _DTMM = null;

        //public ValidService()
        //{
        //    _DTMM = Tool.CommonFunc.GetRandomNum(6);
        //}

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

                    TUser nu = db.InsertUser(u);

                    //插入用户 仓库 关系表
                    TUser_Cangku uc = new TUser_Cangku 
                    {
                        yonghuid = nu.id,
                        cangkuid = ckid
                    };

                    db.InsertUser_Cangku(uc);
                }
                else
                {
                    db.UpdateUserJQM(u.id,tzm);
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

                    TUser nu = db.InsertUser(u);

                    //插入账号，分店关系表
                    TUser_Fendian uf = new TUser_Fendian 
                    {
                        yonghuid = nu.id,
                        fendianid = fdid
                    };

                    db.InsertUser_Fendian(uf);
                }
                else
                {
                    db.UpdateUserJQM(u.id,tzm);
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
            string bm = System.Web.HttpContext.Current.Application["DTMM"].ToString();
             
            if (mm == bm)
            {
                //重新生成动态密码
                System.Web.HttpContext.Current.Application["DTMM"] = Tool.CommonFunc.GetRandomNum(6);
                return true;
            }

            return false;
        }   
    }
}
