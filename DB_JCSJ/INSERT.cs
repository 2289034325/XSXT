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
        }
    }

