﻿using System;
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
            DBContext db = new DBContext();
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
        /// 仓库系统登陆
        /// </summary>
        /// <param name="ckid">仓库ID</param>
        /// <param name="tzm">机器码的MD5值</param>
        /// <returns></returns>
        public void CKZHLogin(int ckid, string tzm)
        {
            //验证Id是否存在
            DBContext db = new DBContext();
            TCangku ck = db.GetCangkuById(ckid);
            if (ck == null)
            {
                throw new FaultException("错误的仓库ID");
            }

            //验证机器码
            TUser u = db.GetUserByDlm(DBCONSTS.USER_DLM_PRE_CK + ckid);
            if (u == null)
            {
                throw new FaultException("该仓库未注册，请先注册");
            }
            else
            {
                //检查机器码是否相符
                if (u.jiqima != tzm)
                {
                    throw new FaultException("禁止在该设备登陆中心系统");
                }
            }

            _user = u;
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
            DBContext db = new DBContext();
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

            DBContext db = new DBContext();
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

            DBContext db = new DBContext();
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

            DBContext db = new DBContext();
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

            DBContext db = new DBContext();
            k.caozuorenid = _user.id;
            k.charushijian = DateTime.Now;
            k.xiugaishijian = DateTime.Now;

            return db.InsertKuanhao(k);
        }

        public void EditKuanhao(TKuanhao k)
        {
            //检查是否已登录
            //checkLogin();

            DBContext db = new DBContext();
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
            
            DBContext db = new DBContext();
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

            DBContext db = new DBContext(); 
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

            DBContext db = new DBContext();
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

            DBContext db = new DBContext();
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

            DBContext db = new DBContext();
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
            DBContext db = new DBContext();
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
            DBContext db = new DBContext();
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
            DBContext db = new DBContext();
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

            DBContext db = new DBContext();
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

            DBContext db = new DBContext();
            TTiaoma[] nts = db.InsertTiaoma(ts);

            return nts;
        }

        /// <summary>
        /// 修改条码信息
        /// </summary>
        /// <param name="t"></param>
        public void EditTiaoma(TTiaoma t)
        {
            DBContext db = new DBContext();
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

        /// <summary>
        /// 取得最新插入和修改的条码
        /// </summary>
        /// <returns></returns>
        public TTiaoma[] GetTiaomasByUpdTime()
        {
            TTiaoma[] tms;
            DBContext db = new DBContext();
            //取得该用户上次下载的时间
            TXiazaijilu j = db.GetXiazaijilu(_user.id, DBCONSTS.XIAZAI_TIAOMA);
            DateTime t = DateTime.Now;
            if (j == null)
            {
                //加载所有条码信息
                tms = db.GetTiaomas();                
                db.InsertXiazaijilu(new TXiazaijilu {yonghuid = _user.id, neirong = DBCONSTS.XIAZAI_TIAOMA,xiazaishijian = t });
            }
            else
            {
                //加载修改时间在此时间之后的条码信息
                tms = db.GetTiaomasByUpdTime(j.xiazaishijian);
                //更新下载时间
                db.UpdateXiazaijilu(new TXiazaijilu { id = j.id, xiazaishijian = t });
            }

            //去除循环引用
            foreach (TTiaoma tm in tms)
            {
                tm.TUser.TTiaoma.Clear();
                tm.TUser.TKuanhao = null;
                tm.TKuanhao.TTiaoma.Clear();
                tm.TKuanhao.TUser = null;
            }

            return tms;
        }

        /// <summary>
        /// 取得一组条码号的所有条码信息
        /// </summary>
        /// <param name="tmhs">条码号数组</param>
        /// <returns></returns>
        public TTiaoma[] GetTiaomasByTiaomahaos(string[] tmhs)
        {
            DBContext db = new DBContext();
            TTiaoma[] ts = db.GetTiaomasByTiaomahaos(tmhs);
            //去除循环引用
            foreach (TTiaoma t in ts)
            {
                t.TKuanhao.TTiaoma.Clear();
            }

            return ts;
        }
    }
}
