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
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;
using Tool;

namespace JCSJWCF
{
    [MyExceptionBehavior(typeof(MyGlobalExceptionHandler))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class DataService : IDataService
    {
        //登陆的用户账号
        private TUser _LoginUser = null;
        private TFendian _LoginFendian = null;
        private TCangku _LoginCangku = null;
        
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
                    throw new FaultException("此帐号不允许在该电脑上登录，请绑定该帐号到本电脑");
                }
                else
                {
                    //验证角色
                    if (u.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.编码员)
                    {
                        throw new FaultException("此帐号不是编码账号，不能登陆");
                    }

                    //将用户放入Session
                    _LoginUser = u;
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
                throw new FaultException("错误的仓库ID，请重新注册系统");
            }

            //验证机器码
            TUser u = db.GetUserByDlm(Tool.JCSJ.DBCONSTS.USER_DLM_PRE_CK + ckid);
            if (u == null)
            {
                throw new FaultException("该仓库未注册，请先注册系统");
            }
            else
            {
                //检查机器码是否相符
                if (u.jiqima != tzm)
                {
                    throw new FaultException("禁止在该电脑登与中央系统通信，请先注册系统");
                }
            }

            //取账号对应的仓库信息
            _LoginCangku = db.GetUserCangkuByUserId(u.id).TCangku;
            _LoginUser = u;
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
                throw new FaultException("错误的分店ID，请先注册系统");
            }

            //验证机器码
            TUser u = db.GetUserByDlm(Tool.JCSJ.DBCONSTS.USER_DLM_PRE_FD + fdid);
            if (u == null)
            {
                throw new FaultException("该分店未注册，请先注册系统");
            }
            else
            {
                //检查机器码是否相符
                if (u.jiqima != tzm)
                {
                    throw new FaultException("禁止在该电脑登与中央系统通信，请先注册系统");
                }
            }

            //取得分店信息
            _LoginUser = u;
            _LoginFendian = db.GetUserFendianByUserid(u.id).TFendian;
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
            TUser ou = db.GetUser(_LoginUser.dengluming, om);
            if ( ou == null)
            {
                throw new FaultException("旧密码不正确");
            }
            else
            {
                if (ou.jmsid != _LoginUser.jmsid)
                {
                    throw new FaultException("非法操作，无法修改该账号密码");
                }

                db.UpdateUserPsw(_LoginUser.id, nm);
            }
        }

        /// <summary>
        /// 按条件取得条码信息
        /// </summary>
        /// <param name="Jmsid">加盟商ID</param>
        /// <param name="Kuanhao"></param>
        /// <param name="Tiaoma"></param>
        /// <param name="Start">条码插入时间</param>
        /// <param name="End">条码插入时间</param>
        /// <returns></returns>
        public TTiaoma[] GetTiaomasByCond(int Jmsid, string Kuanhao, string Tiaoma, DateTime? Start, DateTime? End)
        {
            DBContext db = new DBContext();
            int recordCount = 0;
            int dataLimit = int.Parse(ConfigurationManager.AppSettings["Get_Data_Limit"]);

            TTiaoma[] ts = db.GetTiaomasByCond(Jmsid,null, Kuanhao, Tiaoma, Start, End,dataLimit,0,out recordCount);
            if (recordCount > dataLimit)
            {
                throw new FaultException("数据太多，请缩小时间区域");
            }

            //去除循环引用
            foreach (TTiaoma t in ts)
            {
                t.TKuanhao.TTiaomas.Clear();
                t.TKuanhao.TJiamengshang = null;
                t.TGongyingshang.TTiaomas.Clear();
                t.TGongyingshang.TUser = null;
            }
            return ts;
        }

        /// <summary>
        /// 取得供应商一览
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public TGongyingshang[] GetGongyingshangsByJmsid(int JmsId)
        {
            DBContext db = new DBContext();
            TGongyingshang[] gs = db.GetGongyingshangsByJmsId(JmsId);

            //去除循环引用
            //foreach (TGongyingshang g in gs)
            //{
            //    g.TJiamengshang = null;   
            //}

            return gs;
        }

        /// <summary>
        /// 取得款号一览
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public TKuanhao[] GetKuanhaosByJmsId(int JmsId)
        {
            DBContext db = new DBContext();
            TKuanhao[] ks = db.GetKuanhaosByJmsId(JmsId);

            return ks;
        }

        /// <summary>
        /// 增加一个款号
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public TKuanhao InsertKuanhao(TKuanhao k)
        {
            DBContext db = new DBContext();
            int cc = db.GetKuanhaoCountByJmsId(_LoginUser.jmsid);
            if (cc >= _LoginUser.TJiamengshang.kuanhaoshu)
            {
                throw new FaultException("拥有的款号数已到上限，如要增加更多款号请联系系统管理员");
            }
            k.caozuorenid = _LoginUser.id;
            k.jmsid = _LoginUser.jmsid;
            k.charushijian = DateTime.Now;
            k.xiugaishijian = DateTime.Now;

            return db.InsertKuanhao(k);
        }

        public void EditKuanhao(TKuanhao k)
        {
            DBContext db = new DBContext();
            TKuanhao ok = db.GetKuanhaoById(k.id);
            if (ok.caozuorenid != _LoginUser.id)
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
            DBContext db = new DBContext();
            TKuanhao k = db.GetKuanhaoById(id);

            if (k.caozuorenid != _LoginUser.id)
            {
                throw new FaultException("不允许删除其他用户的款号");
            }

            db.DeleteKuanhao(id); 
        }

        /// <summary>
        /// 根据款号名称取得款号信息
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        public TKuanhao GetKuanhaoByMc(string kh)
        {
            DBContext db = new DBContext();
            TKuanhao k = db.GetKuanhaoByMcWithJmsId(kh, _LoginUser.jmsid);
            if (k != null)
            {
                //去除循环引用    
                foreach (TTiaoma t in k.TTiaomas)
                {
                    t.TKuanhao = null;
                }
            }

            return k;
        }

        /// <summary>
        /// 根据款号名称取得条码信息
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        public TTiaoma[] GetTiaomasByKuanhaoMc(string kh)
        {
            DBContext db = new DBContext();
            TTiaoma[] ts = db.GetTiaomasByKuanhaoMcWithJmsId(kh, _LoginUser.jmsid);

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
                if (db.GetKuanhaoByMcWithJmsId(k,_LoginUser.jmsid) != null)
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
                if (db.GetTiaomaByTiaomahaoWithJmsId(t,_LoginUser.jmsid) != null)
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
                k.caozuorenid = _LoginUser.id;
                k.jmsid = _LoginUser.jmsid;
                k.charushijian = DateTime.Now;
                k.xiugaishijian = DateTime.Now;
            }

            DBContext db = new DBContext();
            int cc = db.GetKuanhaoCountByJmsId(_LoginUser.jmsid);
            if (cc + ks.Count() > _LoginUser.TJiamengshang.kuanhaoshu)
            {
                throw new FaultException("拥有的款号数已到上限，如要增加更多款号请联系系统管理员");
            }
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
                t.caozuorenid = _LoginUser.id;
                t.charushijian = DateTime.Now;
                t.xiugaishijian = DateTime.Now;
            }
            int[] khids = ts.Select(r => r.kuanhaoid).ToArray();
            
            DBContext db = new DBContext();
            //检查确保，不能保存成别的加盟商的条码
            int[] jmsids = db.GetJiamengshangIdsByKhIds(khids);
            if (jmsids.Any(r=>r != _LoginUser.jmsid))
            {
                throw new FaultException("非法操作，无法保存条码");
            }
            int cc = db.GetTiaomaCountByJmsid(_LoginUser.jmsid);
            if (cc + ts.Count() > _LoginUser.TJiamengshang.tiaomashu)
            {
                throw new FaultException("拥有的条码数已到上限，如要增加更多条码请联系系统管理员");
            }
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
            if (ot.TKuanhao.jmsid != _LoginUser.jmsid)
            {
                throw new FaultException("非法操作，无法修改该条码信息");
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
        //public TTiaoma[] GetTiaomasByUpdTime(DateTime upt_start,DateTime upt_end)
        //{
        //    TTiaoma[] tms;
        //    DBContext db = new DBContext();

        //    int dataLimit = int.Parse(ConfigurationManager.AppSettings["Get_Data_Limit"]);
        //    int recordCount = 0;            
        //    //加载条码信息
        //    tms = db.GetTiaomasByCond(_LoginUser.jmsid, null, null, null, upt_start, upt_end, dataLimit, 0, out recordCount);
        //    if (recordCount > dataLimit)
        //    {
        //        throw new FaultException("数据太多，请缩小时间区间");
        //    }

        //    //去除循环引用
        //    foreach (TTiaoma tm in tms)
        //    {
        //        tm.TUser = null;
        //        tm.TKuanhao.TTiaomas.Clear();
        //        tm.TKuanhao.TJiamengshang= null;
        //        tm.TGongyingshang.TTiaomas.Clear();    
        //        tm.TGongyingshang.TUser = null;
        //    }
            
        //    return tms;
        //}

        /// <summary>
        /// 取得一组条码号的所有条码信息
        /// </summary>
        /// <param name="tmhs">条码号数组</param>
        /// <returns></returns>
        public TTiaoma[] GetTiaomasByTiaomahaos(string[] tmhs)
        {
            int dataLimit = int.Parse(ConfigurationManager.AppSettings["Get_Data_Limit"]);
            if (tmhs.Count() > dataLimit)
            {
                throw new FaultException("数据太多，请减少请求的条码数量");
            }

            DBContext db = new DBContext();
            TTiaoma[] ts = db.GetTiaomasByTiaomahaosWithJmsId(tmhs, _LoginUser.jmsid);
            //去除循环引用
            foreach (TTiaoma t in ts)
            {
                t.TKuanhao.TTiaomas.Clear();
                t.TGongyingshang.TTiaomas.Clear();
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

            THuiyuan oh = db.GetHuiyuanByShoujihaoWithJmsId(h.shoujihao, _LoginUser.jmsid);
            if (oh != null)
            {
                throw new Exception("该手机号已经注册会员");
            }

            h.fendianid = _LoginFendian.id;
            h.caozuorenid = _LoginUser.id;
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

            return db.GetHuiyuanByShoujihaoWithJmsId(sjh, _LoginUser.jmsid);
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
            h.xiugaishijian = DateTime.Now;
            //检查是否可以修改
            DBContext db = new DBContext();
            THuiyuan oh = db.GetHuiyuanById(h.id);
            if (oh.TFendian.jmsid != _LoginUser.jmsid)
            {
                throw new FaultException("非法操作，无法修改该会员信息");
            }

            db.UpdateHuiyuan_FendianOPT(h);
        }

        /// <summary>
        /// 取得会员积分折扣记录
        /// </summary>
        /// <returns></returns>
        //public THuiyuanZK[] GetHuiyuanZhekous()
        //{
        //    DBContext db = new DBContext();

        //    return db.GetHuiyuanZKs();
        //}

        /// <summary>
        /// 上报销售记录
        /// </summary>
        /// <param name="xss"></param>
        public void ShangbaoXiaoshou(TXiaoshou[] xss)
        {            
            DBContext db = new DBContext();
            int cc = db.GetXiaoshouCountByJmsId(_LoginUser.jmsid);
            if (cc + xss.Count() > _LoginUser.TJiamengshang.xsjilushu)
            {
                throw new FaultException("上传的销售记录数已到上限，如要上传更多销售记录请联系系统管理员");
            }
            foreach (TXiaoshou xs in xss)
            {
                xs.fendianid = _LoginFendian.id;
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
            int cc = db.GetFDKucunCountByJmsId(_LoginUser.jmsid);
            if (cc + fks.Count() > _LoginUser.TJiamengshang.kcjilushu)
            {
                throw new FaultException("上传的库存记录数已到上限，如要上传更多库存记录请联系系统管理员");
            }
            TFendianKucun fk = new TFendianKucun 
            {
                fendianid = _LoginFendian.id,
                shangbaoshijian = DateTime.Now
            };
            foreach (TFendianKucunMX kmx in fks)            
            {
                fk.TFendianKucunMXes.Add(kmx);
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
                jc.fendianid = _LoginFendian.id;
                jc.shangbaoshijian = DateTime.Now;
            }

            DBContext db = new DBContext();
            int cc = db.GetFDJinchuhuoCountByJmsId(_LoginUser.jmsid);
            if (cc + fjcs.Count() > _LoginUser.TJiamengshang.jchjilushu)
            {
                throw new FaultException("上传的进出货记录数已到上限，如要上传更多进出货记录请联系系统管理员");
            }
            db.InsertFendianJinchuhuo(_LoginFendian.id, fjcs);
        }

        /// <summary>
        /// 上报仓库库存
        /// </summary>
        /// <param name="cks"></param>
        public void ShangbaoKucun_CK(TCangkuKucunMX[] cks)
        {
            DBContext db = new DBContext();
            int cc = db.GetCKKucunCountByJmsId(_LoginUser.jmsid);
            if (cc + cks.Count() > _LoginUser.TJiamengshang.kcjilushu)
            {
                throw new FaultException("上传的库存记录数已到上限，如要上传更多库存记录请联系系统管理员");
            }
            TCangkuKucun ck = new TCangkuKucun 
            {
                cangkuid = _LoginCangku.id,
                shangbaoshijian = DateTime.Now
            };
            foreach (TCangkuKucunMX cmx in cks)
            {
                ck.TCangkuKucunMXes.Add(cmx);
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
                jc.cangkuid = _LoginCangku.id;
                jc.shangbaoshijian = DateTime.Now;
            }

            DBContext db = new DBContext();
            int cc = db.GetCKJinchuhuoCountByJmsId(_LoginUser.jmsid);
            if (cc + cjcs.Count() > _LoginUser.TJiamengshang.jchjilushu)
            {
                throw new FaultException("上传的进出货记录数已到上限，如要上传更多进出货记录请联系系统管理员");
            }
            db.InsertCangkuJinchuhuo(_LoginCangku.id, cjcs);
        }

        /// <summary>
        /// 上传仓库的发货数据，让分店直接下载，不用扫描
        /// </summary>
        /// <param name="fhs"></param>
        public void CangkufahuoFendian(int oid, int fdid)
        {
            //检测是否已经存在
            DBContext db = new DBContext();
            TCangkuJinchuhuo jc = db.GetCKJinchuhuo(_LoginCangku.id, oid);
            if (jc == null)
            {
                throw new FaultException("请先上报进出货记录");
            }
            else
            {
                TCangkuFahuoFendian ff = db.GetCangkuFahuoFendian(jc.id, fdid);
                if (ff != null)
                {
                    throw new FaultException("请不要重复上传");
                }
                else
                {
                    db.InsertCangkuFahuoFendian(new TCangkuFahuoFendian
                    {
                        ckjinchuid = jc.id,
                        fendianid = fdid,
                        scshijian = DateTime.Now,
                        xzshijian = null
                    });
                }
            }
        }

        /// <summary>
        /// 取得所有分店信息
        /// </summary>
        /// <returns></returns>
        public TFendian[] GetFendians()
        {
            DBContext db = new DBContext();
            TFendian[] fds = db.GetFendiansAsItemsByJmsId(_LoginUser.jmsid);

            foreach (TFendian f in fds)
            {
                f.TUser = null;
            }

            return fds;
        }

        /// <summary>
        /// 分店直接从中央系统下载进货的明细数据
        /// </summary>
        /// <returns></returns>
        public TCangkuJinchuhuo[] XiazaiJinhuoShuju()
        {
            DBContext db = new DBContext();
            TCangkuFahuoFendian[] fhs = db.GetFDJinhuoshuju(_LoginFendian.id);
            //更新下载时间
            db.UpdateCangkuFahuoFendianXzsj(fhs.Select(r => r.id).ToArray());           

            TCangkuJinchuhuo[] jchs = fhs.Select(r=>r.TCangkuJinchuhuo).ToArray();

            //去除循环引用
            foreach (var f in jchs)
            {
                f.TCangkuFahuoFendians = null;
                foreach (var mx in f.TCangkuJinchuhuoMXes)
                {
                    mx.TCangkuJinchuhuo = null;
                }
            }
            return jchs;
        }
    }
}
