using DB_JCSJ.Models;
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
            /// 插入一个新用户
            /// </summary>
            /// <param name="u"></param>
            public TUser InsertUser(TUser u)
            {
                TUser nu = _db.TUsers.Add(u);

                _db.SaveChanges();

                return nu;
            }

            /// <summary>
            /// 增加一个分店
            /// </summary>
            /// <param name="t"></param>
            public void InsertFendian(TFendian t)
            {
                _db.TFendians.Add(t);

                _db.SaveChanges();
            }


            /// <summary>
            /// 增加一个仓库
            /// </summary>
            /// <param name="t"></param>
            public void InsertCangku(TCangku t)
            {
                _db.TCangkus.Add(t);

                _db.SaveChanges();
            }

            /// <summary>
            /// 增加一个会员
            /// </summary>
            /// <param name="h"></param>
            public THuiyuan InsertHuiyuan(THuiyuan h)
            {
               THuiyuan nh = _db.THuiyuans.Add(h);

                _db.SaveChanges();

                return nh;
            }

            /// <summary>
            /// 增加一个供应商
            /// </summary>
            /// <param name="g"></param>
            public TGongyingshang InsertGongyingshang(TGongyingshang g)
            {
                TGongyingshang ng = _db.TGongyingshangs.Add(g);

                _db.SaveChanges();

                return ng;
            }

            /// <summary>
            /// 增加一个款号
            /// </summary>
            /// <param name="k"></param>
            public TKuanhao InsertKuanhao(TKuanhao k)
            {
               TKuanhao nk = _db.TKuanhaos.Add(k);

                _db.SaveChanges();

                return nk;
            }
            /// <summary>
            /// 增加一组款号
            /// </summary>
            /// <param name="k"></param>
            /// <returns></returns>
            public TKuanhao[] InsertKuanhao(TKuanhao[] ks)
            {
                TKuanhao[] nks = _db.TKuanhaos.AddRange(ks).ToArray();

                _db.SaveChanges();

                return nks;
            }

            /// <summary>
            /// 增加一个条码信息
            /// </summary>
            /// <param name="t"></param>
            public void InsertTiaoma(TTiaoma t)
            {
                _db.TTiaomas.Add(t);

                _db.SaveChanges();
            }
            /// <summary>
            /// 增加一组条码信息
            /// </summary>
            /// <param name="ts"></param>
            /// <returns></returns>
            public TTiaoma[] InsertTiaoma(TTiaoma[] ts)
            {
                TTiaoma[] nts = _db.TTiaomas.AddRange(ts).ToArray();

                _db.SaveChanges();

                return nts;
            }            

            /// <summary>
            /// 增加一个会员积分折扣规则
            /// </summary>
            /// <param name="z"></param>
            public void InsertHuiyuanZK(THuiyuanZK z)
            {
                _db.THuiyuanZKs.Add(z);

                _db.SaveChanges();
            }

            /// <summary>
            /// 分店系统注册后，关联上分店ID
            /// </summary>
            /// <param name="uf"></param>
            public void InsertUser_Fendian(TUser_Fendian uf)
            {
                _db.TUser_Fendian.Add(uf);

                _db.SaveChanges();
            }
            public void InsertUser_Cangku(TUser_Cangku uc)
            {
                _db.TUser_Cangku.Add(uc);

                _db.SaveChanges();
            }

            /// <summary>
            /// 插入分店上报的销售记录
            /// </summary>
            /// <param name="xss"></param>
            public void InsertXiaoshous(TXiaoshou[] xss)
            {
                var jfs = xss.Where(r => r.huiyuanid != null).Select(r => new { r.huiyuanid, r.jine }).GroupBy(r => r.huiyuanid).Select(r => new
                {
                    hid = r.Key.Value,
                    jf = r.Sum(gr => gr.jine)
                }).ToDictionary(k => k.hid, v => v.jf);

                _db.TXiaoshous.AddRange(xss);

                //更新会员积分
                int[] hids = jfs.Select(r => r.Key).ToArray();
                var hys = _db.THuiyuans.Where(r => hids.Contains(r.id));
                foreach (var h in hys)
                {
                    h.jifen += jfs[h.id];
                    h.jfjsshijian = DateTime.Now;
                }

                _db.SaveChanges();
            }

            /// <summary>
            /// 更新分店库存
            /// </summary>
            /// <param name="fks"></param>
            public void InsertFendianKucun(TFendianKucun fk)
            {
                _db.TFendianKucuns.Add(fk);
                _db.SaveChanges();
            }

            /// <summary>
            /// 更新仓库库存
            /// </summary>
            /// <param name="ckid"></param>
            /// <param name="cks"></param>
            public void InsertCangkuKucun(TCangkuKucun ck)
            {
                _db.TCangkuKucuns.Add(ck);
                _db.SaveChanges();
            }

            /// <summary>
            /// 插入分店进出货记录
            /// </summary>
            /// <param name="fdid"></param>
            /// <param name="fjcs"></param>
            public void InsertFendianJinchuhuo(int fdid, TFendianJinchuhuo[] fjcs)
            {
                _db.TFendianJinchuhuos.AddRange(fjcs);
                
                //明细信息已经自动插入，不许执行下面步骤
                //foreach (TFendianJinchuhuo jc in fjcs)
                //{
                //    _db.TFendianJinchuhuoMX.AddRange(jc.TFendianJinchuhuoMX);
                //}

                _db.SaveChanges();
            }
            /// <summary>
            /// 插入仓库进出货记录
            /// </summary>
            /// <param name="ckid"></param>
            /// <param name="cjcs"></param>
            public void InsertCangkuJinchuhuo(int ckid, TCangkuJinchuhuo[] cjcs)
            {
                _db.TCangkuJinchuhuos.AddRange(cjcs);

                _db.SaveChanges();
            }

            /// <summary>
            /// 插入仓库发货数据，让分店直接下载
            /// </summary>
            /// <param name="fh"></param>
            public void InsertCangkuFahuoFendian(TCangkuFahuoFendian ff)
            {
                _db.TCangkuFahuoFendians.Add(ff);

                _db.SaveChanges();
            }
            
        }
    }

