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
                TUser nu = _db.TUser.Add(u);

                _db.SaveChanges();

                return nu;
            }

            /// <summary>
            /// 增加一个分店
            /// </summary>
            /// <param name="t"></param>
            public void InsertFendian(TFendian t)
            {
                _db.TFendian.Add(t);

                _db.SaveChanges();
            }


            /// <summary>
            /// 增加一个仓库
            /// </summary>
            /// <param name="t"></param>
            public void InsertCangku(TCangku t)
            {
                _db.TCangku.Add(t);

                _db.SaveChanges();
            }

            /// <summary>
            /// 增加一个会员
            /// </summary>
            /// <param name="h"></param>
            public THuiyuan InsertHuiyuan(THuiyuan h)
            {
               THuiyuan nh = _db.THuiyuan.Add(h);

                _db.SaveChanges();

                return nh;
            }

            /// <summary>
            /// 增加一个供应商
            /// </summary>
            /// <param name="g"></param>
            public TGongyingshang InsertGongyingshang(TGongyingshang g)
            {
                TGongyingshang ng = _db.TGongyingshang.Add(g);

                _db.SaveChanges();

                return ng;
            }

            /// <summary>
            /// 增加一个款号
            /// </summary>
            /// <param name="k"></param>
            public TKuanhao InsertKuanhao(TKuanhao k)
            {
               TKuanhao nk = _db.TKuanhao.Add(k);

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
                TKuanhao[] nks = _db.TKuanhao.AddRange(ks).ToArray();

                _db.SaveChanges();

                return nks;
            }

            /// <summary>
            /// 增加一个条码信息
            /// </summary>
            /// <param name="t"></param>
            public void InsertTiaoma(TTiaoma t)
            {
                _db.TTiaoma.Add(t);

                _db.SaveChanges();
            }
            /// <summary>
            /// 增加一组条码信息
            /// </summary>
            /// <param name="ts"></param>
            /// <returns></returns>
            public TTiaoma[] InsertTiaoma(TTiaoma[] ts)
            {
                TTiaoma[] nts = _db.TTiaoma.AddRange(ts).ToArray();

                _db.SaveChanges();

                return nts;
            }

            /// <summary>
            /// 增加一个下载记录
            /// </summary>
            /// <param name="x"></param>
            public void InsertXiazaijilu(TXiazaijilu x)
            {
                _db.TXiazaijilu.Add(x);

                _db.SaveChanges();
            }

            /// <summary>
            /// 增加一个会员积分折扣规则
            /// </summary>
            /// <param name="z"></param>
            public void InsertHuiyuanZK(THuiyuanZK z)
            {
                _db.THuiyuanZK.Add(z);

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
                _db.TXiaoshou.AddRange(xss);

                _db.SaveChanges();
            }

            /// <summary>
            /// 更新分店库存
            /// </summary>
            /// <param name="fks"></param>
            public void InsertFendianKucun(int fdid, TFendianKucun[] fks)
            {
                //先删除旧数据
                var oks = _db.Database.ExecuteSqlCommand("DELETE FROM TFendianKucun WHERE fendianid = " + fdid);

                //插入旧数据
                _db.TFendianKucun.AddRange(fks);

                _db.SaveChanges();
            }

            /// <summary>
            /// 插入分店进出货记录
            /// </summary>
            /// <param name="fdid"></param>
            /// <param name="fjcs"></param>
            public void InsertFendianJinchuhuo(int fdid, TFendianJinchuhuo[] fjcs)
            {
                _db.TFendianJinchuhuo.AddRange(fjcs);
                foreach (TFendianJinchuhuo jc in fjcs)
                {
                    _db.TFendianJinchuhuoMX.AddRange(jc.TFendianJinchuhuoMX);
                }

                _db.SaveChanges();
            }
            
        }
    }

