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

        private int _jmsid
        {
            get
            {
                if (_LoginUser != null)
                {
                    return _LoginUser.jmsid.Value;
                }
                else
                {
                    if (_LoginFendian != null)
                    {
                        return _LoginFendian.jmsid;
                    }
                    else 
                    {
                        throw new MyException("登录异常，请重新登录或者重新连接服务器", null);
                    }
                }
            }
        }

        private int _ppsid
        {
            get
            {
                if (_LoginUser != null)
                {
                    return _LoginUser.ppsid.Value;
                }
                else
                {
                    if (_LoginCangku != null)
                    {
                        return _LoginCangku.ppsid;
                    }
                    else
                    {
                        throw new MyException("登录异常，请重新登录或者重新连接服务器", null);
                    }
                }
            }
        }
        
        /// <summary>
        /// 编码账号登陆
        /// </summary>
        /// <param name="dlm"></param>
        /// <param name="mm"></param>
        /// <param name="tzm"></param>
        public TUser BMZHLogin(string dlm, string mm, string tzm,string ver)
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
                //验证机器码
                if (u.jiqima != tzm)
                {
                    throw new MyException("系统信息不正确，请绑定该帐号到本电脑", null);
                }
                else
                {
                    //验证角色
                    if (u.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商编码)
                    {
                        throw new MyException("此帐号不是编码账号，不能登陆", null);
                    }

                    //将用户放入Session
                    _LoginUser = u;
                }
            }

            //去除循环引用
            u.TPinpaishang.TUsers.Clear();

            return u;
        }

        /// <summary>
        /// 仓库系统登陆
        /// </summary>
        /// <param name="ckid">仓库ID</param>
        /// <param name="tzm">机器码的MD5值</param>
        /// <returns></returns>
        public void CKZHLogin(int ckid, string jqm,string ver)
        {
            string Cver = ConfigurationManager.AppSettings["CKVersion"];
            if (Cver != ver)
            {
                throw new MyException("请升级客户端版本", null);
            }

            //验证Id是否存在
            DBContext db = new DBContext();
            TCangku ck = null;
            try
            {
                ck = db.GetCangkuById(ckid);
            }
            catch
            { 
                throw new MyException("错误的仓库ID，请重新注册系统", null);
            }

            //检查机器码是否相符
            if (ck.jiqima != jqm)
            {
                throw new MyException("系统信息不正确，请重新注册系统", null);
            }

            _LoginCangku = ck;
        }

        /// <summary>
        /// 分店系统登陆
        /// </summary>
        /// <param name="fdid">分店ID</param>
        /// <param name="tzm"></param>
        public void FDZHLogin(int fdid, string jqm,string ver)
        {
            string Cver = ConfigurationManager.AppSettings["FDVersion"];
            if (Cver != ver)
            {
                throw new MyException("请升级客户端版本", null);
            }

            //验证Id是否存在
            DBContext db = new DBContext();
            TFendian fd = null;
            try
            {
                fd = db.GetFendianById(fdid);
            }
            catch
            {
                throw new MyException("错误的分店ID，请先注册系统", null);
            }

            //检查机器码是否相符
            if (fd.jiqima != jqm)
            {
                throw new MyException("系统信息不正确，请重新注册系统", null);
            }

            _LoginFendian = fd;
        }

        /// <summary>
        /// 编码系统账号修改密码
        /// </summary>
        /// <param name="om">旧密码</param>
        /// <param name="nm">新密码</param>
        //public void BMZHEditPsw(string om, string nm)
        //{
        //    //验证旧密码
        //    DBContext db = new DBContext();
        //    TUser ou = db.GetUser(_LoginUser.dengluming, om);
        //    if ( ou == null)
        //    {
        //        throw new MyException("旧密码不正确");
        //    }
        //    else
        //    {
        //        if (ou.jmsid != _jmsid)
        //        {
        //            throw new MyException("非法操作，无法修改该账号密码");
        //        }

        //        db.UpdateUserPsw(_LoginUser.id, nm);
        //    }
        //}

        /// <summary>
        /// 按条件取得条码信息
        /// </summary>
        /// <param name="Kuanhao"></param>
        /// <param name="Tiaoma"></param>
        /// <param name="Start">条码插入时间</param>
        /// <param name="End">条码插入时间</param>
        /// <returns></returns>
        public TTiaoma[] GetTiaomasByCond(string Kuanhao, string Tiaoma, DateTime? Start, DateTime? End)
        {
            DBContext db = new DBContext();
            int recordCount = 0;
            int dataLimit = int.Parse(ConfigurationManager.AppSettings["Get_Data_Limit"]);

            TTiaoma[] ts = db.GetTiaomasByCond(_ppsid, null, Kuanhao, Tiaoma, Start, End, dataLimit, 0, out recordCount);
            if (recordCount > dataLimit)
            {
                throw new MyException("数据太多，请缩小时间区域", null);
            }

            //去除循环引用
            foreach (TTiaoma t in ts)
            {
                t.TPinpaishang = null;
                t.TKuanhao.TTiaomas.Clear();
                t.TKuanhao.TPinpaishang = null;
                t.TGongyingshang.TTiaomas.Clear();
                t.TGongyingshang.TPinpaishang = null;                
            }
            return ts;
        }

        /// <summary>
        /// 取得供应商一览
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public TGongyingshang[] GetGongyingshangs()
        {
            DBContext db = new DBContext();
            TGongyingshang[] gs = db.GetGongyingshangsAsItems(_ppsid);
            
            return gs;
        }

        /// <summary>
        /// 取得款号一览
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public TKuanhao[] GetKuanhaosByCond(int pageSize, int pageIndex, out int recordCount)
        {
            DBContext db = new DBContext();
            TKuanhao[] ks = db.GetKuanhaosByCond(_jmsid, null, null, null, pageSize, pageIndex, out recordCount);
            //去除循环引用
            foreach (TKuanhao k in ks)
            {
                k.TPinpaishang = null;
            }

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
            string errMsg = "非法操作，请刷新页面重新执行";
            if (!Enum.IsDefined(typeof(Tool.JCSJ.DBCONSTS.KUANHAO_LX), k.leixing))
            {
                throw new MyException(errMsg, null);
            }
            if (!Enum.IsDefined(typeof(Tool.JCSJ.DBCONSTS.KUANHAO_XB), k.xingbie))
            {
                throw new MyException(errMsg, null);
            }

            int cc = db.GetKuanhaoCount(_jmsid);
            if (cc >= _LoginUser.TPinpaishang.kuanhaoshu)
            {
                throw new MyException("拥有的款号数已到上限，如要增加更多款号请联系系统管理员", null);
            }
            k.caozuorenid = _LoginUser.id;
            k.charushijian = DateTime.Now;
            k.xiugaishijian = DateTime.Now;

            TKuanhao[] oks = db.GetKuanhaosByMcPpsId(new string[]{k.kuanhao}, _ppsid);
            if (oks.Count() > 0)
            {
                throw new MyException("款号重复", null);
            }

            return db.InsertKuanhao(k);
        }

        public void EditKuanhao(TKuanhao k)
        {
            DBContext db = new DBContext();
            string errMsg = "非法操作，请刷新页面重新执行";
            if (!Enum.IsDefined(typeof(Tool.JCSJ.DBCONSTS.KUANHAO_LX), k.leixing))
            {
                throw new MyException(errMsg, null);
            }
            if (!Enum.IsDefined(typeof(Tool.JCSJ.DBCONSTS.KUANHAO_XB), k.xingbie))
            {
                throw new MyException(errMsg, null);
            }

            TKuanhao ok = db.GetKuanhaoById(k.id);
            if (ok.ppsid != _ppsid)
            {
                throw new MyException("非法操作，无法修改该款号信息", null);
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

            if (k.ppsid != _ppsid)
            {
                throw new MyException("非法操作，无法删除该款号", null);
            }

            db.DeleteKuanhao(id); 
        }

        /// <summary>
        /// 根据款号名称取得款号信息
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        //public TKuanhao GetKuanhaoByMc(string kh)
        //{
        //    DBContext db = new DBContext();
        //    TKuanhao[] ks = db.GetKuanhaosByMcJmsId(new string[]{kh}, _jmsid);
        //    if (ks.Count() >1)
        //    {
        //        throw new MyException("款号[" + kh + "]重复，属于多个品牌，无法加载其信息", null);
        //    }
        //    TKuanhao k = null;
        //    if (ks.Count() == 1)
        //    {
        //        k = ks[0];
        //    }

        //    return k;
        //}
        public TKuanhao[] GetKuanhaosByMcs(string[] khs)
        {
            int dataLimit = int.Parse(ConfigurationManager.AppSettings["Get_Data_Limit"]);
            if (khs.Count() > dataLimit)
            {
                throw new MyException("数据太多，请减少请求的条码数量", null);
            }

            DBContext db = new DBContext();
            TKuanhao[] ks = db.GetKuanhaosByMcPpsId(khs, _ppsid);

            return ks;
        }

        /// <summary>
        /// 检查是否有重复的款号
        /// </summary>
        /// <param name="khs"></param>
        /// <returns></returns>
        public string[] CheckKuanhaosChongfu(string[] khs)
        {
            DBContext db = new DBContext();
            return db.GetKuanhaoExistByMcWithPpsId(_ppsid, khs);
        }

        /// <summary>
        /// 检查条码是否有重复
        /// </summary>
        /// <param name="tms"></param>
        /// <returns></returns>
        public string[] CheckTiaomaChongfu(string[] tms)
        {
            DBContext db = new DBContext();
            TTiaoma[] etms = db.GetTiaomasByTiaomahaosWithPpsId(tms, _ppsid);
            foreach (TTiaoma tm in etms)
            {
                tm.TGongyingshang.TTiaomas.Clear();
            }

            return etms.Select(r=>r.tiaoma).ToArray();
        }

        /// <summary>
        /// 保存一组款号
        /// </summary>
        /// <param name="ks"></param>
        /// <returns></returns>
        public TKuanhao[] SaveKuanhaos(TKuanhao[] ks)
        {
            DBContext db = new DBContext();            
            foreach (TKuanhao k in ks)
            {
                k.ppsid = _ppsid;
                k.caozuorenid = _LoginUser.id;
                k.charushijian = DateTime.Now;
                k.xiugaishijian = DateTime.Now;

                if (!Enum.IsDefined(typeof(Tool.JCSJ.DBCONSTS.KUANHAO_LX), k.leixing))
                {
                    throw new MyException("非法操作，请刷新页面重新执行", null);
                }
                if (!Enum.IsDefined(typeof(Tool.JCSJ.DBCONSTS.KUANHAO_XB), k.xingbie))
                {
                    throw new MyException("非法操作，请刷新页面重新执行", null);
                }
            }

            int cc = db.GetKuanhaoCount(_ppsid);
            if (cc + ks.Count() > _LoginUser.TPinpaishang.kuanhaoshu)
            {
                throw new MyException("拥有的款号数已到上限，如要增加更多款号请联系系统管理员", null);
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
                t.ppsid = _ppsid;
                t.caozuorenid = _LoginUser.id;
                t.charushijian = DateTime.Now;
                t.xiugaishijian = DateTime.Now;
            }
            int[] khids = ts.Select(r => r.kuanhaoid).ToArray();
            
            DBContext db = new DBContext();
            //检查确保，不能保存成别的加盟商的条码
            int[] ppsids = db.GetPinpaishangIdsByKhIds(khids);
            if (ppsids.Any(r => r != _ppsid))
            {
                throw new MyException("非法操作，无法保存条码", null);
            }
            int cc = db.GetTiaomaCount(_ppsid);
            if (cc + ts.Count() > _LoginUser.TPinpaishang.tiaomashu)
            {
                throw new MyException("拥有的条码数已到上限，如要增加更多条码请联系系统管理员", null);
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
            TTiaoma ot = db.GetTiaomaById(t.id);
            if (ot.ppsid != _ppsid)
            {
                throw new MyException("非法操作，无法修改该条码信息", null);
            }
            else
            {
                t.xiugaishijian = DateTime.Now;
                db.UpdateTiaoma(t);
            }
        }

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
                throw new MyException("数据太多，请减少请求的条码数量", null);
            }

            DBContext db = new DBContext();
            TTiaoma[] ts = db.GetTiaomasByTiaomahaosWithPpsId(tmhs, _ppsid);
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
            int cc = db.GetHuiyuanCount(_jmsid);
            if (cc >= _LoginFendian.TJiamengshang.huiyuanshu)
            {
                throw new MyException("拥有的会员数已到上限，如要增加更多会员请联系系统管理员", null);
            }
            THuiyuan oh = db.GetHuiyuanByShoujihaoWithJmsId(h.shoujihao, _jmsid);
            if (oh != null)
            {
                throw new MyException("该手机号已经注册会员",null);
            }

            h.fendianid = _LoginFendian.id;
            //h.caozuorenid = _LoginUser.id;
            h.jmsid = _jmsid;
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

            return db.GetHuiyuanByShoujihaoWithJmsId(sjh, _jmsid);
        }

        /// <summary>
        /// 根据会员ID取得会员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public THuiyuan GetHuiyuanById(int id)
        {
            DBContext db = new DBContext();
            //去除循环引用
            THuiyuan h = db.GetHuiyuanById(id);
            h.TFendian.THuiyuans.Clear();

            return h;
        }

        /// <summary>
        /// 更新会员信息
        /// </summary>
        /// <param name="h"></param>
        public void UpdateHuiyuan(THuiyuan h)
        {
            h.xiugaishijian = DateTime.Now;
            string errMsg = "非法操作，请刷新页面重新执行";
            if (!Enum.IsDefined(typeof(Tool.JCSJ.DBCONSTS.HUIYUAN_XB), h.xingbie))
            {
                throw new MyException(errMsg, null);
            }

            //检查是否可以修改
            DBContext db = new DBContext();
            THuiyuan oh = db.GetHuiyuanById(h.id);
            if (oh.TFendian.jmsid != _jmsid)
            {
                throw new MyException("非法操作，无法修改该会员信息", null);
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
            int cc = db.GetXiaoshouCount(_jmsid);
            if (cc + xss.Count() > _LoginFendian.TJiamengshang.xsjilushu)
            {
                throw new MyException("上传的销售记录数已到上限，如要上传更多销售记录请联系系统管理员", null);
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
            int cc = db.GetFDKucunCount(_jmsid);
            if (cc + fks.Count() > _LoginFendian.TJiamengshang.kcjilushu)
            {
                throw new MyException("上传的库存记录数已到上限，如要上传更多库存记录请联系系统管理员", null);
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
            int cc = db.GetFDJinchuhuoCount(_jmsid);
            if (cc + fjcs.Count() > _LoginFendian.TJiamengshang.jchjilushu)
            {
                throw new MyException("上传的进出货记录数已到上限，如要上传更多进出货记录请联系系统管理员", null);
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
            int cc = db.GetCKKucunCount(_jmsid);
            if (cc + cks.Count() > _LoginCangku.TPinpaishang.kcjilushu)
            {
                throw new MyException("上传的库存记录数已到上限，如要上传更多库存记录请联系系统管理员", null);
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
        public string ShangbaoJinchuhuo_CK(TCangkuJinchuhuo cjcs)
        {
            DBContext db = new DBContext();

            //生成新的批次码
            string pcm = getNewPcm();
            //最多检测5次，如果重新生成5次都还是重复，报错
            for (int i = 0; i < 5; i++)
            {
                //检测批次码是否重复
                TCangkuJinchuhuo ojc = db.GetCKJinchuhuoByPcm(pcm);
                if (ojc != null)
                {
                    pcm = getNewPcm();
                }
                else
                {
                    break;
                }
            }

            cjcs.picima = pcm;
            cjcs.ckid = _LoginCangku.id;
            cjcs.shangbaoshijian = DateTime.Now;

            int cc = db.GetCKJinchuhuoCount(_ppsid);
            if (cc >= _LoginCangku.TPinpaishang.jchjilushu)
            {
                throw new MyException("上传的进出货记录数已到上限，如要上传更多进出货记录请联系系统管理员", null);
            }
            TCangkuJinchuhuo nc = db.InsertCangkuJinchuhuo(cjcs);

            return nc.picima;
        }

        private string getNewPcm()
        {
            string AB = Tool.CommonFunc.Year_month_to_AB(2015);
            string rNum = Tool.CommonFunc.GetRandomNum(6);
            string pcm = AB + rNum;

            return pcm;
        }

        /// <summary>
        /// 上传仓库的发货数据，让分店直接下载，不用扫描
        /// </summary>
        /// <param name="fhs"></param>
        public void CangkufahuoFendian(string pcm, int fdid)
        {
            //检测是否已经存在
            DBContext db = new DBContext();
            TCangkuJinchuhuo jc = db.GetCKJinchuhuoByPcm(pcm);
            if (jc == null)
            {
                throw new MyException("请先上报进出货记录", null);
            }
            else
            {
                TCangkufahuoFendian ff = db.GetCangkuFahuoFendianByJcId(jc.id);
                if (ff != null)
                {
                    throw new MyException("请不要重复上传", null);
                }
                else
                {
                    db.InsertCangkuFahuoFendian(new TCangkufahuoFendian
                    {
                        ckjinchuid = jc.id,
                        fendianid = fdid
                    });
                }
            }
        }

        /// <summary>
        /// 仓库系统发货时，取得指定加盟商的分店信息
        /// </summary>
        /// <returns></returns>
        public TFendian[] GetFendians(int jmsid)
        {
            DBContext db = new DBContext();
            TFendian[] fds = db.GetFendiansAsItems(jmsid);

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
            TCangkuJinchuhuo[] jchs = db.GetCKFahuoFendianByFdId(_LoginFendian.id);

            //去除循环引用
            foreach (var f in jchs)
            {
                foreach (var mx in f.TCangkuJinchuhuoMXes)
                {
                    mx.TCangkuJinchuhuo = null;
                    mx.TTiaoma.TKuanhao.TTiaomas.Clear();
                    mx.TTiaoma.TGongyingshang.TTiaomas.Clear();
                    mx.TTiaoma.TCangkuJinchuhuoMXes.Clear();                   
                }
            }
            return jchs;
        }
        public TCangkuJinchuhuo XiazaiJinhuoShuju(string pcm)
        {
            DBContext db = new DBContext();
            TCangkuJinchuhuo jch = db.GetCKJinchuhuoByPcm(pcm);

            if (jch == null)
            {
                throw new MyException("该批次码不存在", null);
            }

            //去除循环引用
            foreach (var mx in jch.TCangkuJinchuhuoMXes)
                {
                    mx.TCangkuJinchuhuo = null;
                    mx.TTiaoma.TKuanhao.TTiaomas.Clear();
                    mx.TTiaoma.TGongyingshang.TTiaomas.Clear();
                    mx.TTiaoma.TCangkuJinchuhuoMXes.Clear();
                }

            return jch;
        }
        /// <summary>
        /// 下载数据完成后，删除数据，以防重复下载
        /// </summary>
        /// <param name="ckjcids"></param>
        public void XiazaiJinhuoShujuFinish(int[] ckjcids)
        {
            DBContext db = new DBContext();
            //删除
            db.DeleteCangkufahuoFendian(ckjcids);   
        }

        /// <summary>
        /// 分店系统删除已上报的销售记录
        /// </summary>
        /// <param name="oid"></param>
        public void DeleteXiaoshoujilu(int oid)
        {
            DBContext db = new DBContext();
            TXiaoshou ox = db.GetXiaoshouByFdidOid(_LoginFendian.id, oid);
            //上报时间超过一天的不允许删除
            if ((DateTime.Now - ox.shangbaoshijian).TotalDays > 1)
            {
                throw new MyException("上报已经超过1天的数据不允许删除", null);
            }

            db.DeleteXiaoshou(ox.id);
        }
        public void DeleteJinchujilu_FD(int oid)
        {
            DBContext db = new DBContext();
            TFendianJinchuhuo oj = db.GetFDJinchuhuoByFdidOid(_LoginFendian.id,oid);
            //上报时间超过一天的不允许删除
            if ((DateTime.Now - oj.shangbaoshijian).TotalDays > 1)
            {
                throw new MyException("上报已经超过1天的数据不允许删除", null);
            }

            db.DeleteFDJinchuhuo(oj.id);
        }        

        /// <summary>
        /// 取当前用户所属加盟商的所有仓库
        /// </summary>
        /// <returns></returns>
        public TCangku[] GetCangkus()
        {
            DBContext db = new DBContext();
            TCangku[] cks = db.GetCangkus(_ppsid);
            //去除循环引用
            foreach (var ck in cks)
            {
                ck.TPinpaishang.TCangkus.Clear();
            }

            return cks;
        }

        /// <summary>
        /// 取当前用户所属加盟商的所有子加盟商
        /// </summary>
        /// <returns></returns>
        public TJiamengshang[] GetZiJiamengshangs()
        {
            DBContext db = new DBContext();
            TJiamengshang[] gxes = db.GetZiJiamengshangs(_ppsid);

            return gxes;
        }
        public TPinpaishang[] GetJMPinpais()
        {
            DBContext db = new DBContext();
            TPinpaishang[] pps = db.GetPinpaishangs(_jmsid);


            return pps;
        }

        /// <summary>
        /// 将某就款号的名称修改掉
        /// </summary>
        /// <param name="id"></param>
        /// <param name="kh"></param>
        public void XiugaiKuanhao(int id, string kh)
        {
            DBContext db = new DBContext();
            TKuanhao ok = db.GetKuanhaoById(id);
            if (ok.ppsid != _ppsid)
            {
                throw new MyException("非法操作，不允许修改其他用户的款号", null);
            }
            db.UpdateKuanhaoMc(id, kh);
        }

        public void UpdateTiaoma(TTiaoma t)
        {
            DBContext db = new DBContext();
            TTiaoma otm = db.GetTiaomaById(t.id);
            if (otm.ppsid != _ppsid)
            {
                throw new MyException("非法操作，不允许修改其他用户的条码", null);
            }

            db.UpdateTiaoma(t);
        }

        public TJiamengshang[] GetJiamengshangs()
        {
            DBContext db = new DBContext();
            TJiamengGX[] gxes = db.GetZiJiamengGXes(_LoginCangku.ppsid);
            foreach (TJiamengGX g in gxes)
            {
                //使用备注名称
                g.TJiamengshang.mingcheng = g.bzmingcheng;

                //去除循环引用
                g.TJiamengshang.TJiamengGXes.Clear();
            }

            return gxes.Select(r => r.TJiamengshang).ToArray();
        }

        /// <summary>
        /// 仓库系统撤销上报数据
        /// </summary>
        /// <param name="pcm"></param>
        public void DeleteJinchujilu_CK(string pcm)
        {
            DBContext db = new DBContext();
            TCangkuJinchuhuo oj = db.GetCKJinchuhuoByPcm(pcm);
            TCangku c = db.GetCangkuById(oj.ckid);
            if (c.ppsid != _LoginCangku.ppsid)
            {
                throw new MyException("非法操作", null);
            }

            //上报时间超过一天的不允许删除
            if ((DateTime.Now - oj.shangbaoshijian).TotalDays > 1)
            {
                throw new MyException("上报已经超过1天的数据不允许撤销", null);
            }

            db.DeleteCKJinchuhuo(oj.id);
        }
    }
}
