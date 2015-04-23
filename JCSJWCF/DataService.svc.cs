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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class DataService : IDataService
    {
        //登陆的用户账号
        private TUser _user = null;
        
        /// <summary>
        /// 编码账号登陆
        /// </summary>
        /// <param name="dlm"></param>
        /// <param name="mm"></param>
        /// <param name="tzm"></param>
        public TUser BMZHLogin(string dlm, string mm, string tzm)
        {
            //验证账号密码
            OPT db = new OPT();
            TUser u = db.GetUser(dlm, mm);
            if (u == null)
            {
                throw new FaultException("用户名或密码不正确");
            }
            else
            {
                //验证机器码
                if (u.jiqima != tzm)
                {
                    throw new FaultException("此帐号不允许在该电脑上登录");
                }
                else
                {
                    //验证角色
                    if (u.juese != (byte)CONSTS.USER_XTJS.编码员)
                    {
                        throw new FaultException("此帐号不允许在该系统登录");
                    }

                    //将用户放入Session
                    _user = u;
                }
            }

            return u;
        }

        /// <summary>
        /// 编码系统账号修改密码
        /// </summary>
        /// <param name="om">旧密码</param>
        /// <param name="nm">新密码</param>
        public void BMZHEditPsw(string om,string nm)
        {
            //检查是否已登录
            if (_user == null)
            {
                throw new FaultException("未登录");
            }
            else
            {
                //验证旧密码
                OPT db = new OPT();
                if (db.GetUser(_user.dengluming, om) == null)
                {
                    throw new FaultException("旧密码不正确");
                }
                else
                {
                    db.UpdateUserPsw(_user.id, nm);
                }
            }
        }
    }
}
