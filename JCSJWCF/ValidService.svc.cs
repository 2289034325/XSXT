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
using Tool.DB.JCSJ;

namespace JCSJWCF
{
    public class ValidService : IValidService
    {
        //登陆的用户账号
        private TUser _user = null;

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
            if (!Tool.CommonFunc.ValidateDTMM(zcm))
            {
                throw new MyException("动态密码错误");
            }
            else
            {
                TUser u = new TUser();
                //生成新用户
                u.dengluming = dlm;
                u.yonghuming = xm;
                u.mima = mm;
                u.jiqima = tzm;
                u.juese = (byte)CONSTS.USER_XTJS.编码员;
                u.zhuangtai = (byte)CONSTS.USER_ZT.可用;
                u.beizhu = "";
                u.charushijian = DateTime.Now;
                u.xiugaishijian = DateTime.Now;

                OPT db = new OPT();
                TUser nu = db.InsertUser(u);
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
            OPT db = new OPT();
            TUser u = db.GetUser(dlm, mm);
            if (u == null)
            {
                throw new MyException("用户名或密码不正确");
            }
            else
            {
                //验证注册码
                if (!Tool.CommonFunc.ValidateDTMM(zcm))
                {
                    throw new MyException("注册码不正确");
                }
                else
                {
                    //将机器特征码写入数据库
                    db.UpdateUserJQM(u.id, tzm);
                }
            }
        }

       
    }
}
