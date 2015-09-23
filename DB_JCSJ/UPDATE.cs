﻿using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_JCSJ
    {
        public partial class DBContext
        {
            /// <summary>
            /// 修改系统用户信息
            /// </summary>
            /// <param name="u"></param>
            public void UpdateUserInfo(TUser u)
            {
                TUser ou = _db.TUsers.Single(r => r.id == u.id);

                ou.dengluming = u.dengluming;
                if (!string.IsNullOrEmpty(u.mima))
                {
                    ou.mima = u.mima;
                }
                ou.yonghuming = u.yonghuming;
                ou.juese = u.juese;
                ou.zhuangtai = u.zhuangtai;
                ou.beizhu = u.beizhu;
                ou.xiugaishijian = u.xiugaishijian;

                _db.SaveChanges();
            }

            /// <summary>
            /// 修改用户密码
            /// </summary>
            /// <param name="id"></param>
            /// <param name="psw"></param>
            public void UpdateUserPsw(int id, string psw)
            {
                TUser ou = _db.TUsers.Single(r => r.id == id);

                ou.mima = psw;

                ou.xiugaishijian = DateTime.Now;

                _db.SaveChanges();
            }

            /// <summary>
            /// 修改用户绑定的机器码
            /// </summary>
            /// <param name="id"></param>
            /// <param name="jqm"></param>
            public void UpdateUserJQM(int id, string jqm)
            {
                TUser ou = _db.TUsers.Single(r => r.id == id);

                ou.jiqima = jqm;

                ou.xiugaishijian = DateTime.Now;

                _db.SaveChanges();
            }

            /// <summary>
            /// 修改分店信息
            /// </summary>
            /// <param name="f"></param>
            public void UpdateFendian(TFendian f)
            {
                TFendian of = _db.TFendians.Single(r => r.id == f.id);
                of.fzxingbie = f.fzxingbie;
                of.fzleixing = f.fzleixing;
                of.dianming = f.dianming;
                of.ppid = f.ppid;
                of.mianji = f.mianji;
                of.keliuliang = f.keliuliang;
                of.dangci = f.dangci;
                of.dpxingzhi = f.dpxingzhi;
                of.zhuanrangfei = f.zhuanrangfei;
                of.yuezu = f.yuezu;
                of.diquid = f.diquid;
                of.dizhi = f.dizhi;
                of.lianxiren = f.lianxiren;
                of.dianhua = f.dianhua;
                of.kaidianriqi = f.kaidianriqi;
                of.zhuangtai = f.zhuangtai;
                of.beizhu = f.beizhu;
                of.xiugaishijian = f.xiugaishijian;

                _db.SaveChanges();
            }
            public void UpdateFendianJQM(int id, string jqm)
            {
                TFendian of = _db.TFendians.Single(r => r.id == id);

                of.jiqima = jqm;

                _db.SaveChanges();
            }

            /// <summary>
            /// 更新仓库信息
            /// </summary>
            /// <param name="c"></param>
            public void UpdateCangku(TCangku c)
            {
                TCangku of = _db.TCangkus.Single(r => r.id == c.id);

                of.mingcheng = c.mingcheng;
                of.dizhi = c.dizhi;
                of.lianxiren = c.lianxiren;
                of.dianhua = c.dianhua;
                of.beizhu = c.beizhu;
                of.xiugaishijian = c.xiugaishijian;

                _db.SaveChanges();
            }
            public void UpdateCangkuJQM(int id,string jqm)
            {
                TCangku oc = _db.TCangkus.Single(r => r.id == id);

                oc.jiqima = jqm;

                _db.SaveChanges();
            }

            /// <summary>
            /// 修改会员信息，此方法不修改手机号
            /// </summary>
            /// <param name="h"></param>
            public void UpdateHuiyuan(THuiyuan h)
            {
                THuiyuan oh = _db.THuiyuans.Single(r => r.id == h.id);

                //分店由注册的时候定，不需要被修改
                //oh.fendianid = h.fendianid;
                //oh.shoujihao = h.shoujihao;
                oh.xingming = h.xingming;
                oh.xingbie = h.xingbie;
                oh.shengri = h.shengri;
                oh.beizhu = h.beizhu;
                oh.xiugaishijian = h.xiugaishijian;

                _db.SaveChanges();
            }
            /// <summary>
            /// 分店客户端修改会员信息
            /// </summary>
            /// <param name="h"></param>
            public void UpdateHuiyuan_FendianOPT(THuiyuan h)
            {
                THuiyuan oh = _db.THuiyuans.Single(r => r.id == h.id);

                oh.shoujihao = h.shoujihao;
                oh.xingming = h.xingming;
                oh.xingbie = h.xingbie;
                oh.shengri = h.shengri;
                oh.xiugaishijian = h.xiugaishijian;

                _db.SaveChanges();

            }

            /// <summary>
            /// 修改供应商信息
            /// </summary>
            /// <param name="g"></param>
            public void UpdateGongyingshang(TGongyingshang g)
            {
                TGongyingshang og = _db.TGongyingshangs.Single(r => r.id == g.id);

                og.mingcheng = g.mingcheng;
                og.lianxiren = g.lianxiren;
                og.dianhua = g.dianhua;
                og.dizhi = g.dizhi;
                og.beizhu = g.beizhu;
                og.xiugaishijian = g.xiugaishijian;

                _db.SaveChanges();
            }

            /// <summary>
            /// 修改款号信息
            /// </summary>
            /// <param name="k"></param>
            public void UpdateKuanhao(TKuanhao k)
            {
                TKuanhao ok = _db.TKuanhaos.Single(r => r.id == k.id);

                ok.kuanhao = k.kuanhao;
                ok.leixing = k.leixing;
                ok.xingbie = k.xingbie;
                ok.pinming = k.pinming;
                ok.beizhu = k.beizhu;
                ok.xiugaishijian = k.xiugaishijian;
                //该款号所有的条码信息也标为被修改
                foreach (TTiaoma t in ok.TTiaomas)
                {
                    t.xiugaishijian = k.xiugaishijian;
                }

                _db.SaveChanges();
            }
            /// <summary>
            /// 修改款号名称
            /// </summary>
            /// <param name="id"></param>
            /// <param name="kh"></param>
            public void UpdateKuanhaoMc(int id, string kh)
            {
                TKuanhao ok = _db.TKuanhaos.Single(r => r.id == id);
                ok.kuanhao = kh;
                ok.xiugaishijian = DateTime.Now;

                _db.SaveChanges();
            }

            /// <summary>
            /// 修改条码信息
            /// </summary>
            /// <param name="t"></param>
            public void UpdateTiaoma(TTiaoma t)
            {
                TTiaoma ot = _db.TTiaomas.Single(r => r.id == t.id);

                //条码号，不允许编辑
                ot.yanse = t.yanse;
                ot.chima = t.chima;
                ot.jinjia = t.jinjia;
                ot.shoujia = t.shoujia;
                //所属款号，不允许修改
                //ot.kuanhaoid = t.kuanhaoid;
                ot.gysid = t.gysid;
                ot.gyskuanhao = t.gyskuanhao;
                ot.xiugaishijian = t.xiugaishijian;

                _db.SaveChanges();
            }

            /// <summary>
            /// 修改一个条码的条码号
            /// </summary>
            /// <param name="id"></param>
            /// <param name="tmh"></param>
            public void UpdateTiaomaTmh(int id, string tmh)
            {
                TTiaoma ot = _db.TTiaomas.Single(r => r.id == id);
                ot.tiaoma = tmh;
                ot.xiugaishijian = DateTime.Now;

                _db.SaveChanges();
            }

            /// <summary>
            /// 下载进货数据后，更新其下载时间
            /// </summary>
            /// <param name="jcids"></param>
            public void UpdateCangkuFahuoFendianXzsj(int[] jcids)
            {
                var ds = _db.TCangkuFahuoFendians.Where(r => jcids.Contains(r.ckjinchuid));
                foreach (var d in ds)
                {
                    d.xzshijian = DateTime.Now;
                }

                _db.SaveChanges();
            }

            /// <summary>
            /// 更新加盟商信息
            /// </summary>
            /// <param name="j"></param>
            public void UpdateJiamengshang(TJiamengshang j)
            {
                var oj = _db.TJiamengshangs.Single(r => r.id == j.id);

                oj.mingcheng = j.mingcheng;
                oj.zhuceshouji = j.zhuceshouji;
                oj.zhuceyouxiang = j.zhuceyouxiang;
                oj.diquid = j.diquid;
                oj.dizhi = j.dizhi;
                oj.lianxiren = j.lianxiren;
                oj.dianhua = j.dianhua;
                oj.beizhu = j.beizhu;

                oj.fjmsshu = j.fjmsshu;
                oj.zjmsshu = j.zjmsshu;
                oj.zhanghaoshu = j.zhanghaoshu;
                oj.kuanhaoshu = j.kuanhaoshu;
                oj.tiaomashu = j.tiaomashu;
                oj.huiyuanshu = j.huiyuanshu;
                oj.fendianshu = j.fendianshu;
                oj.cangkushu = j.cangkushu;
                oj.gongyingshangshu = j.gongyingshangshu;
                oj.xsjilushu = j.xsjilushu;
                oj.jchjilushu = j.jchjilushu;
                oj.kcjilushu = j.kcjilushu;
                oj.shoucifufei = j.shoucifufei;
                oj.xufeidanjia = j.xufeidanjia;
                oj.jiezhiriqi = j.jiezhiriqi;
                oj.xiugaishijian = j.xiugaishijian;

                _db.SaveChanges();
            }
            /// <summary>
            /// 用户修改自己的相关信息
            /// </summary>
            /// <param name="j"></param>
            public void UpdateJiamengshangWodexinxi(TJiamengshang j)
            {
                var oj = _db.TJiamengshangs.Single(r => r.id == j.id);

                oj.zhuceshouji = j.zhuceshouji;
                oj.zhuceyouxiang = j.zhuceyouxiang;
                oj.diquid = j.diquid;
                oj.dizhi = j.dizhi;
                oj.lianxiren = j.lianxiren;
                oj.dianhua = j.dianhua;
                oj.xiugaishijian = j.xiugaishijian;

                _db.SaveChanges();
            }

            /// <summary>
            /// 修改加盟商的动态验证码
            /// </summary>
            /// <param name="id"></param>
            /// <param name="yzm"></param>
            public void UpdateJiamengshangDtyzm(int id, string yzm)
            {
                TJiamengshang oj = _db.TJiamengshangs.Single(r => r.id == id);

                oj.dtyzm = yzm;

                _db.SaveChanges();
            }

            /// <summary>
            /// 修改地区名称
            /// </summary>
            /// <param name="id"></param>
            /// <param name="mc"></param>
            public void UpdateDiqu(int id, string mc)
            {
                TDiqu od = _db.TDiqus.Single(r => r.id == id);

                od.mingcheng = mc;
                od.lsmingcheng += "-" + mc;
                od.xiugaishijian = DateTime.Now;

                _db.SaveChanges();
            }

            /// <summary>
            /// 加盟请求审核后，更新审核结果
            /// </summary>
            /// <param name="id"></param>
            /// <param name="jieguo"></param>
            public void UpdateJiamengGXSQShenhe(int id, byte jieguo)
            {
                TJiamengshangGXSQ os = _db.TJiamengshangGXSQs.Single(r => r.id == id);

                os.jieguo = jieguo;

                _db.SaveChanges();
            }

            /// <summary>
            /// 修改下级加盟商的名称，便于辨识
            /// </summary>
            /// <param name="g"></param>
            public void UpdateJiamengGXBeizhu(TJiamengshangGX g)
            {
                TJiamengshangGX og = _db.TJiamengshangGXes.Single(r => r.id == g.id);

                og.bzmingcheng = g.bzmingcheng;
                og.beizhu = g.beizhu;

                _db.SaveChanges();
            }

            /// <summary>
            /// 加盟商进退货数据
            /// </summary>
            /// <param name="j"></param>
            public void UpdateJiamengshangJintuihuo(TJiamengshangJintuihuo j)
            {
                TJiamengshangJintuihuo oj = _db.TJiamengshangJintuihuos.Single(r => r.id == j.id);

                oj.zhekou = j.zhekou;
                oj.beizhu = j.beizhu;
                oj.xiugaishijian = j.xiugaishijian;

                _db.SaveChanges();
            }
            /// <summary>
            /// 进退货明细
            /// </summary>
            /// <param name="m"></param>
            public void UpdateJiamengshangJintuihuoMX(TJiamengshangJintuihuoMX m)
            {
                TJiamengshangJintuihuoMX oj = _db.TJiamengshangJintuihuoMXes.Single(r => r.id == m.id);

                oj.tiaomaid = m.tiaomaid;
                oj.jinhuojia = m.jinhuojia;

                _db.SaveChanges();
            }
        }
    }
