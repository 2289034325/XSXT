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
                TUser ou = _db.TUser.Single(r => r.id == u.id);

                ou.dengluming = u.dengluming;
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
                TUser ou = _db.TUser.Single(r => r.id == id);

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
                TUser ou = _db.TUser.Single(r => r.id == id);

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
                TFendian of = _db.TFendian.Single(r => r.id == f.id);
                of.fzxingbie = f.fzxingbie;
                of.fzleixing = f.fzleixing;
                of.dianming = f.dianming;
                of.mianji = f.mianji;
                of.keliuliang = f.keliuliang;
                of.dangci = f.dangci;
                of.dpxingzhi = f.dpxingzhi;
                of.zhuanrangfei = f.zhuanrangfei;
                of.yuezu = f.yuezu;
                of.dizhi = f.dizhi;
                of.lianxiren = f.lianxiren;
                of.dianhua = f.dianhua;
                of.kaidianriqi = f.kaidianriqi;
                of.zhuangtai = f.zhuangtai;
                of.beizhu = f.beizhu;
                of.xiugaishijian = f.xiugaishijian;

                _db.SaveChanges();
            }

            /// <summary>
            /// 更新仓库信息
            /// </summary>
            /// <param name="c"></param>
            public void UpdateCangku(TCangku c)
            {
                TCangku of = _db.TCangku.Single(r => r.id == c.id);

                of.mingcheng = c.mingcheng;
                of.dizhi = c.dizhi;
                of.lianxiren = c.lianxiren;
                of.dianhua = c.dianhua;
                of.beizhu = c.beizhu;
                of.xiugaishijian = c.xiugaishijian;

                _db.SaveChanges();
            }

            /// <summary>
            /// 修改会员信息
            /// </summary>
            /// <param name="h"></param>
            public void UpdateHuiyuan(THuiyuan h)
            {
                THuiyuan oh = _db.THuiyuan.Single(r => r.id == h.id);

                //oh.fendianid = h.fendianid;
                oh.shoujihao = h.shoujihao;
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
                THuiyuan oh = _db.THuiyuan.Single(r => r.id == h.id);

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
                TGongyingshang og = _db.TGongyingshang.Single(r => r.id == g.id);

                og.jiancheng = g.jiancheng;
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
                TKuanhao ok = _db.TKuanhao.Single(r => r.id == k.id);

                ok.kuanhao = k.kuanhao;
                ok.leixing = k.leixing;
                ok.xingbie = k.xingbie;
                ok.pinming = k.pinming;
                ok.beizhu = k.beizhu;
                ok.xiugaishijian = k.xiugaishijian;
                //该款号所有的条码信息也标为被修改
                foreach (TTiaoma t in ok.TTiaoma)
                {
                    t.xiugaishijian = k.xiugaishijian;
                }

                _db.SaveChanges();
            }

            /// <summary>
            /// 修改条码信息
            /// </summary>
            /// <param name="t"></param>
            public void UpdateTiaoma(TTiaoma t)
            {
                TTiaoma ot = _db.TTiaoma.Single(r => r.id == t.id);

                //条码号，不允许编辑
                ot.yanse = t.yanse;
                ot.chima = t.chima;
                ot.jinjia = t.jinjia;
                ot.shoujia = t.shoujia;
                ot.kuanhaoid = t.kuanhaoid;
                ot.gysid = t.gysid;
                ot.gyskuanhao = t.gyskuanhao;
                ot.xiugaishijian = t.xiugaishijian;

                _db.SaveChanges();
            }

            /// <summary>
            /// 下载进货数据后，更新其下载时间
            /// </summary>
            /// <param name="jcids"></param>
            public void UpdateCangkuFahuoFendianXzsj(int[] ids)
            {
                var ds = _db.TCangkuFahuoFendian.Where(r => ids.Contains(r.id));
                foreach (var d in ds)
                {
                    d.xzshijian = DateTime.Now;
                }

                _db.SaveChanges();
            }
        }
    }
