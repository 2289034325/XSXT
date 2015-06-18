using DB_JCSJ;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;
using Tool;

namespace JCSJWCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class DataService : IDataService
    {
        //登陆的用户账号
        private TUser _user = null;
        private TFendian _fendian = null;
        private TCangku _cangku = null;
        
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
                    if (u.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码员)
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
            TUser u = db.GetUserByDlm(Tool.JCSJ.DBCONSTS.USER_DLM_PRE_CK + ckid);
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

            //取账号对应的仓库信息
            _cangku = db.GetUserCangkuByUserId(u.id).TCangku;
            _user = u;
        }

        /// <summary>
        /// 分店系统登陆
        /// </summary>
        /// <param name="fdid">分店ID</param>
        /// <param name="tzm"></param>
        public void FDZHLogin(int fdid, string tzm)
        {
            //验证Id是否存在
            DBContext db = new DBContext();
            TFendian fd = db.GetFendianById(fdid);
            if (fd == null)
            {
                throw new FaultException("错误的分店ID");
            }

            //验证机器码
            TUser u = db.GetUserByDlm(Tool.JCSJ.DBCONSTS.USER_DLM_PRE_FD + fdid);
            if (u == null)
            {
                throw new FaultException("该分店未注册，请先注册");
            }
            else
            {
                //检查机器码是否相符
                if (u.jiqima != tzm)
                {
                    throw new FaultException("禁止在该设备登陆中心系统");
                }
            }

            //取得分店信息
            _user = u;
            _fendian = db.GetUserFendianByUserid(u.id).TFendian;
        }

        /// <summary>
        /// 编码系统账号修改密码
        /// </summary>
        /// <param name="om">旧密码</param>
        /// <param name="nm">新密码</param>
        public void BMZHEditPsw(string om, string nm)
        {
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
        /// 按条件取得条码信息
        /// TODO:此服务可以放到报表中心
        /// 用户先从报表中心去取条码信息
        /// 报表中心如果没有该条码，再从基础数据取
        /// 这样即可以横向拓展报表服务器的个数，缓解基础数据服务的压力
        /// </summary>
        /// <param name="Userid">操作人ID</param>
        /// <param name="Kuanhao"></param>
        /// <param name="Tiaoma"></param>
        /// <param name="Start">条码插入时间</param>
        /// <param name="End">条码插入时间</param>
        /// <returns></returns>
        public TTiaoma[] GetTiaomas(int Userid, string Kuanhao, string Tiaoma, DateTime? Start, DateTime? End)
        {
            DBContext db = new DBContext();
            int recordCount = 0;
            int dataLimit = int.Parse(ConfigurationManager.AppSettings["Get_Data_Limit"]);

            TTiaoma[] ts = db.GetTiaomasByCond(Userid,null, Kuanhao, Tiaoma, Start, End,dataLimit,0,out recordCount);
            if (recordCount > dataLimit)
            {
                throw new FaultException("数据太多，请缩小时间区域");
            }

            //去除循环引用
            foreach (TTiaoma t in ts)
            {
                t.TKuanhao.TTiaoma.Clear();
                t.TUser.TTiaoma.Clear();
                t.TUser.TKuanhao.Clear();
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
        public TTiaoma[] GetTiaomasByUpdTime(DateTime upt_start,DateTime upt_end)
        {
            TTiaoma[] tms;
            DBContext db = new DBContext();

            int dataLimit = int.Parse(ConfigurationManager.AppSettings["Get_Data_Limit"]);
            int recordCount = 0;            
            //加载条码信息
            tms = db.GetTiaomasByCond(null, null, null, null, upt_start, upt_end, dataLimit, 0, out recordCount);
            if (recordCount > dataLimit)
            {
                throw new FaultException("数据太多，请缩小时间区间");
            }

            //去除循环引用
            foreach (TTiaoma tm in tms)
            {
                tm.TUser = null;
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

        /// <summary>
        /// 注册会员
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public THuiyuan HuiyuanZhuce(THuiyuan h)
        {
            DBContext db = new DBContext();

            h.fendianid = _fendian.id;
            h.caozuorenid = _user.id;
            h.jifen = 0;
            h.jfjsshijian = DateTime.Now;
            h.charushijian = DateTime.Now;
            h.xiugaishijian = DateTime.Now;

            THuiyuan nh = db.InsertHuiyuan(h);
            
            return nh;
        }

        /// <summary>
        /// 根据手机号取得会员信息
        /// </summary>
        /// <param name="sjh"></param>
        /// <returns></returns>
        public THuiyuan GetHuiyuanByShoujihao(string sjh)
        {
            DBContext db = new DBContext();

            return db.GetHuiyuanByShoujihao(sjh);
        }

        /// <summary>
        /// 根据会员ID取得会员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public THuiyuan GetHuiyuanById(int id)
        {
            DBContext db = new DBContext();
            return db.GetHuiyuanById(id);
        }

        /// <summary>
        /// 更新会员信息
        /// </summary>
        /// <param name="h"></param>
        public void UpdateHuiyuan(THuiyuan h)
        {
            //检查是否可以修改
            DBContext db = new DBContext();
            THuiyuan oh = db.GetHuiyuanById(h.id);
            if (oh.caozuorenid != _user.id)
            {
                throw new FaultException("不允许修改其他分店的会员信息");
            }

            db.UpdateHuiyuan_FendianOPT(h);
        }

        /// <summary>
        /// 取得会员积分折扣记录
        /// </summary>
        /// <returns></returns>
        public THuiyuanZK[] GetHuiyuanZhekous()
        {
            DBContext db = new DBContext();

            return db.GetHuiyuanZKs();
        }

        /// <summary>
        /// 上报销售记录
        /// </summary>
        /// <param name="xss"></param>
        public void ShangbaoXiaoshou(TXiaoshou[] xss)
        {
            DBContext db = new DBContext();
            foreach (TXiaoshou xs in xss)
            {
                xs.fendianid = _fendian.id;
                xs.shangbaoshijian = DateTime.Now;
            }

            db.InsertXiaoshous(xss);
        }

        /// <summary>
        /// 上报库存
        /// </summary>
        /// <param name="fks"></param>
        public void ShangbaoKucun_FD(TFendianKucunMX[] fks)
        {
            DBContext db = new DBContext();
            TFendianKucun fk = new TFendianKucun 
            {
                fendianid = _fendian.id,
                shangbaoshijian = DateTime.Now
            };
            foreach (TFendianKucunMX kmx in fks)            
            {
                fk.TFendianKucunMX.Add(kmx);
            }

            db.InsertFendianKucun(fk);
        }

        /// <summary>
        /// 上报进出货记录
        /// </summary>
        /// <param name="fjcs"></param>
        public void ShangbaoJinchuhuo_FD(TFendianJinchuhuo[] fjcs)
        {
            foreach (TFendianJinchuhuo jc in fjcs)
            {
                jc.fendianid = _fendian.id;
                jc.shangbaoshijian = DateTime.Now;
            }

            DBContext db = new DBContext();
            db.InsertFendianJinchuhuo(_fendian.id, fjcs);
        }

        /// <summary>
        /// 上报仓库库存
        /// </summary>
        /// <param name="cks"></param>
        public void ShangbaoKucun_CK(TCangkuKucunMX[] cks)
        {
            DBContext db = new DBContext();
            TCangkuKucun ck = new TCangkuKucun 
            {
                cangkuid = _cangku.id,
                shangbaoshijian = DateTime.Now
            };
            foreach (TCangkuKucunMX cmx in cks)
            {
                ck.TCangkuKucunMX.Add(cmx);
            }

            db.InsertCangkuKucun(ck);
        }

        /// <summary>
        /// 上报仓库进出货记录
        /// </summary>
        /// <param name="cjcs"></param>
        public void ShangbaoJinchuhuo_CK(TCangkuJinchuhuo[] cjcs)
        {
            foreach (TCangkuJinchuhuo jc in cjcs)
            {
                jc.cangkuid = _cangku.id;
                jc.shangbaoshijian = DateTime.Now;
            }

            DBContext db = new DBContext();
            db.InsertCangkuJinchuhuo(_cangku.id, cjcs);
        }
    }
}
