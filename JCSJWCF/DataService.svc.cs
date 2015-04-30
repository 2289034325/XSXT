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
                    if (u.juese != (byte)DBCONSTS.USER_XTJS.编码员)
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
        public void BMZHEditPsw(string om, string nm)
        {
            //检查是否已登录
            //checkLogin();

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

        /// <summary>
        /// 检查用户是否已经登录
        /// </summary>
        //private void checkLogin()
        //{
        //    if (_user == null)
        //    {
        //        throw new FaultException("未登录");
        //    }
        //}


        /// <summary>
        /// 按条件取得条码信息
        /// </summary>
        /// <param name="Userid">操作人ID</param>
        /// <param name="Kuanhao"></param>
        /// <param name="Tiaoma"></param>
        /// <param name="Start">条码插入时间</param>
        /// <param name="End">条码插入时间</param>
        /// <returns></returns>
        public TTiaoma[] GetTiaomas(int Userid, string Kuanhao, string Tiaoma, DateTime Start, DateTime End)
        {
            //检查是否已登录
            //checkLogin();

            OPT db = new OPT();
            TTiaoma[] ts = db.GetTiaomas(Userid, Kuanhao, Tiaoma, Start, End);
            foreach (TTiaoma t in ts)
            {
                t.TKuanhao.TTiaoma.Clear();
            }
            return ts;
        }

        /// <summary>
        /// 取得某用户编辑的供应商一览
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public TGongyingshang[] GetGongyingshangsByUserId(int UserId)
        {
            //检查是否已登录
            //checkLogin();

            OPT db = new OPT();
            TGongyingshang[] gs = db.GetGongyingshangsByUserId(UserId);

            return gs;
        }

        /// <summary>
        /// 取得某用户编辑的款号一览
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public TKuanhao[] GetKuanhaosByUserId(int UserId)
        {
            //检查是否已登录
            //checkLogin();

            OPT db = new OPT();
            TKuanhao[] ks = db.GetKuanhaosByUserId(UserId);

            return ks;
        }

        /// <summary>
        /// 增加一个款号
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public TKuanhao InsertKuanhao(TKuanhao k)
        {
            //检查是否已登录
            //checkLogin();

            OPT db = new OPT();
            k.caozuorenid = _user.id;
            k.charushijian = DateTime.Now;
            k.xiugaishijian = DateTime.Now;

            return db.InsertKuanhao(k);
        }

        public void EditKuanhao(TKuanhao k)
        {
            //检查是否已登录
            //checkLogin();

            OPT db = new OPT();
            TKuanhao ok = db.GetKuanhaoById(k.id);
            if (ok.caozuorenid != _user.id)
            {
                throw new FaultException("不允许修改其他用户的款号");
            }
            k.xiugaishijian = DateTime.Now;

            db.UpdateKuanhao(k); 
        }

        /// <summary>
        /// 删除一个款号
        /// </summary>
        /// <param name="id"></param>
        public void DeleteKuanhao(int id)
        {
            //检查是否已登录
            //checkLogin();
            
            OPT db = new OPT();
            TKuanhao k = db.GetKuanhaoById(id);

            if (k.caozuorenid != _user.id)
            {
                throw new FaultException("不允许删除其他用户的款号");
            }

            db.DeleteKuanhao(id); 
        }


        /// <summary>
        /// 增加一个供应商
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public TGongyingshang InsertGongyingshang(TGongyingshang g)
        {
            //检查是否已登录
            //checkLogin();

            OPT db = new OPT(); 
            g.caozuorenid = _user.id;
            g.charushijian = DateTime.Now;
            g.xiugaishijian = DateTime.Now;

            return db.InsertGongyingshang(g);

        }
        /// <summary>
        /// 修改供应商信息
        /// </summary>
        /// <param name="g"></param>
        public void EditGongyingshang(TGongyingshang g)
        {
            //检查是否已登录
            //checkLogin();

            OPT db = new OPT();
            TGongyingshang og = db.GetGongyingshangById(g.id);
            if (og.caozuorenid != _user.id)
            {
                throw new FaultException("不允许修改其他用户的供应商信息");
            }
            g.xiugaishijian = DateTime.Now;

            db.UpdateGongyingshang(g); 
        }
        /// <summary>
        /// 删除一个供应商
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGongyingshang(int id)
        {
            //检查是否已登录
            //checkLogin();

            OPT db = new OPT();
            TGongyingshang g = db.GetGongyingshangById(id);

            if (g.caozuorenid != _user.id)
            {
                throw new FaultException("不允许删除其他用户的供应商信息");
            }

            db.DeleteGongyingshang(id); 
        }

        /// <summary>
        /// 根据款号名称取得款号信息
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        public TKuanhao GetKuanhaoByMc(string kh)
        {
            //检查是否已登录
            //checkLogin();

            OPT db = new OPT();
            TKuanhao k = db.GetKuanhaoByMc(kh);
            if (k != null)
            {
                //去除循环引用    
                foreach (TTiaoma t in k.TTiaoma)
                {
                    t.TKuanhao = null;
                }
            }

            return k;
        }

        /// <summary>
        /// 根据款号名称取得所有条码信息
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        public TTiaoma[] GetTiaomasByKuanhaoMc(string kh)
        {
            OPT db = new OPT();
            TTiaoma[] ts = db.GetTiaomasByKuanhaoMc(kh);

            return ts;
        }


        /// <summary>
        /// 检查是否有重复的款号
        /// </summary>
        /// <param name="khs"></param>
        /// <returns></returns>
        public string[] CheckKuanhaosChongfu(string[] khs)
        {
            OPT db = new OPT();
            List<string> eKhs = new List<string>();
            foreach (string k in khs)
            {
                if (db.GetKuanhaoByMc(k) != null)
                {
                    eKhs.Add(k);
                }
            }

            return eKhs.ToArray();
        }

        /// <summary>
        /// 检查条码是否有重复
        /// </summary>
        /// <param name="tms"></param>
        /// <returns></returns>
        public string[] CheckTiaomaChongfu(string[] tms)
        {
            OPT db = new OPT();
            List<string> eTms = new List<string>();
            foreach (string t in tms)
            {
                if (db.GetTiaomaByTiaomahao(t) != null)
                {
                    eTms.Add(t);
                }
            }

            return eTms.ToArray();
        }

        /// <summary>
        /// 保存一组款号
        /// </summary>
        /// <param name="ks"></param>
        /// <returns></returns>
        public TKuanhao[] SaveKuanhaos(TKuanhao[] ks)
        {
            foreach (TKuanhao k in ks)
            {
                k.caozuorenid = _user.id;
                k.charushijian = DateTime.Now;
                k.xiugaishijian = DateTime.Now;
            }

            OPT db = new OPT();
            TKuanhao[] nks = db.InsertKuanhao(ks);

            return nks;
        }

        /// <summary>
        /// 保存一组条码
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public TTiaoma[] SaveTiaomas(TTiaoma[] ts)
        {
            foreach (TTiaoma t in ts)
            {
                t.caozuorenid = _user.id;
                t.charushijian = DateTime.Now;
                t.xiugaishijian = DateTime.Now;
            }

            OPT db = new OPT();
            TTiaoma[] nts = db.InsertTiaoma(ts);

            return nts;
        }

        /// <summary>
        /// 修改条码信息
        /// </summary>
        /// <param name="t"></param>
        public void EditTiaoma(TTiaoma t)
        {
            OPT db = new OPT();
            TTiaoma ot = db.GetTiaomaByTiaomahao(t.tiaoma);
            if (ot.caozuorenid != _user.id)
            {
                throw new FaultException("不允许修改其他用户的条码信息");
            }
            else
            {
                t.xiugaishijian = DateTime.Now;
                db.UpdateTiaoma(t);
            }
        }
    }
}
