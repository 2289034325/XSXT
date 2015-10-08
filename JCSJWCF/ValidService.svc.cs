using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        /// <summary>
        /// 编码系统注册
        /// </summary>
        /// <param name="dlm">登录名</param>
        /// <param name="mm">密码</param>
        /// <param name="xm">姓名</param>
        /// <param name="zcm">注册码</param>
        /// <param name="tzm">客户端机器特征码</param>
        /// <returns></returns>
        //public void BMZHZhuce(string dlm, string mm, string xm, string tzm, string zcm)
        //{
        //    //验证注册码
        //    if (!validateDTMM(zcm))
        //    {
        //        throw new MyException("注册码错误");
        //    }
        //    else
        //    {
        //        TUser u = new TUser();
        //        //生成新用户
        //        u.dengluming = dlm;
        //        u.yonghuming = xm;
        //        u.mima = mm;
        //        u.jiqima = tzm;
        //        u.juese = (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码;
        //        u.zhuangtai = (byte)Tool.JCSJ.DBCONSTS.USER_ZT.可用;
        //        u.beizhu = "";
        //        u.charushijian = DateTime.Now;
        //        u.xiugaishijian = DateTime.Now;

        //        DBContext db = new DBContext();
        //        TUser nu = db.InsertUser(u);
        //    }
        //}

        /// <summary>
        /// 仓库系统注册
        /// </summary>
        /// <param name="ckid">仓库id</param>
        /// <param name="ckmc">仓库名</param>
        /// <param name="tzm">机器特征码</param>
        /// <param name="zcm">注册码</param>
        public void CKZHZhuce(int ckid, string ckmc, string jqm, string zcm,string ver)
        {
            string Cver = ConfigurationManager.AppSettings["CKVersion"];
            if (Cver != ver)
            {
                throw new MyException("请升级客户端版本", null);
            }

            DBContext db = new DBContext();
            //检查仓库ID和仓库名称是否匹配
            TCangku tc = db.GetCangkuByIdMc(ckid, ckmc);
            if (tc == null)
            {
                throw new MyException("仓库ID和仓库名称不匹配", null);
            }
            else
            {
                if (!validateDTMM(tc.jmsid, zcm))
                {
                    throw new MyException("验证码错误", null);
                }
            }

            //更新机器码
            db.UpdateCangkuJQM(ckid, jqm);
        }

        /// <summary>
        /// 分店系统注册
        /// </summary>
        /// <param name="fdid">分店ID</param>
        /// <param name="fdmc">分店名</param>
        /// <param name="jqm">机器码</param>
        /// <param name="zcm">注册码</param>
        public void FDZHZhuce(int fdid, string fdmc, string jqm, string zcm,string ver)
        {
            string Cver = ConfigurationManager.AppSettings["FDVersion"];
            if (Cver != ver)
            {
                throw new MyException("请升级客户端版本", null);
            }

            DBContext db = new DBContext();
            //检查分店ID和分店名称是否匹配
            TFendian fd = db.GetFendianByIdMc(fdid, fdmc);
            if (fd == null)
            {
                throw new MyException("分店ID或店名错误", null);
            }
            else
            {
                if (!validateDTMM(fd.jmsid, zcm))
                {
                    throw new MyException("验证码错误", null);
                }
            }

            db.UpdateFendianJQM(fdid, jqm);
        }

        /// <summary>
        /// 编码系统账号绑定
        /// </summary>
        /// <param name="dlm">登录名</param>
        /// <param name="mm">密码</param>
        /// <param name="tzm">机器特征码</param>
        /// <param name="zcm">注册码</param>
        public void BMZHBangding(string dlm, string mm, string tzm, string zcm,string ver)
        {
            string Cver = ConfigurationManager.AppSettings["BMVersion"];
            if (Cver != ver)
            {
                throw new MyException("请升级客户端版本", null);
            }


            //验证账号密码
            DBContext db = new DBContext();
            TUser u = db.GetUser(dlm, mm);
            if (u == null)
            {
                throw new MyException("用户名或密码不正确", null);
            }
            else
            {
                //验证注册码
                if (!validateDTMM(u.jmsid,zcm))
                {
                    throw new MyException("验证码错误", null);
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
        private bool validateDTMM(int jmsid,string mm)
        {
            DBContext db = new DBContext();
            TJiamengshang j= db.GetJiamengshangById(jmsid);            
             
            if (mm == j.dtyzm)
            {
                //重新生成动态密码
                db.UpdateJiamengshangDtyzm(jmsid, Tool.CommonFunc.GetRandomNum(6));
                return true;
            }

            return false;
        }   
    }
}
