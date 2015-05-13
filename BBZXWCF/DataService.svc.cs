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

namespace BBZXWCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class DataService : IDataService
    {
        //登陆的用户账号
        //private TUser _user = null;       

        /// <summary>
        /// 仓库系统登陆
        /// </summary>
        /// <param name="ckid">仓库ID</param>
        /// <param name="tzm">机器码的MD5值</param>
        /// <returns></returns>
        public void CKZHLogin(int ckid, string tzm)
        {
            ////验证Id是否存在
            //DBContext db = new DBContext();
            //TCangku ck = db.GetCangkuById(ckid);
            //if (ck == null)
            //{
            //    throw new FaultException("错误的仓库ID");
            //}

            ////验证机器码
            //TUser u = db.GetUserByDlm(DBCONSTS.USER_DLM_PRE_CK + ckid);
            //if (u == null)
            //{
            //    throw new FaultException("该仓库未注册，请先注册");
            //}
            //else
            //{
            //    //检查机器码是否相符
            //    if (u.jiqima != tzm)
            //    {
            //        throw new FaultException("禁止在该设备登陆中心系统");
            //    }
            //}

            //_user = u;
        }

        /// <summary>
        /// 分店系统登陆
        /// </summary>
        /// <param name="fdid">分店ID</param>
        /// <param name="tzm"></param>
        public void FDZHLogin(int fdid, string tzm)
        {
            //验证Id是否存在
            //DBContext db = new DBContext();
            //TFendian fd = db.GetFendianById(fdid);
            //if (fd == null)
            //{
            //    throw new FaultException("错误的分店ID");
            //}

            ////验证机器码
            //TUser u = db.GetUserByDlm(DBCONSTS.USER_DLM_PRE_FD + fdid);
            //if (u == null)
            //{
            //    throw new FaultException("该分店未注册，请先注册");
            //}
            //else
            //{
            //    //检查机器码是否相符
            //    if (u.jiqima != tzm)
            //    {
            //        throw new FaultException("禁止在该设备登陆中心系统");
            //    }
            //}

            //_user = u;
        }
    }
}
