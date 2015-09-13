using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DB_JCSJ
    {
        public partial class DBContext
        {
            /// <summary>
            /// 删除用户
            /// </summary>
            /// <param name="id"></param>
            public void DeleteUser(int id)
            {
                TUser u = _db.TUsers.Single(r => r.id == id);

                //_db.TUser_Cangku.RemoveRange(u.TUser_Cangku);
                //_db.TUser_Fendian.RemoveRange(u.TUser_Fendian);
                _db.TUsers.Remove(u);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除分店
            /// </summary>
            /// <param name="id"></param>
            public void DeleteFendian(int id)
            {
                TFendian f = _db.TFendians.Single(r => r.id == id);

                _db.TFendians.Remove(f);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除仓库
            /// </summary>
            /// <param name="id"></param>
            public void DeleteCangku(int id)
            {
                TCangku f = _db.TCangkus.Single(r => r.id == id);

                _db.TCangkus.Remove(f);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除会员
            /// </summary>
            /// <param name="id"></param>
            public void DeleteHuiyuan(int id)
            {
                THuiyuan h = _db.THuiyuans.Single(r => r.id == id);

                _db.THuiyuans.Remove(h);

                _db.SaveChanges();
            }
            public void DeleteHuiyuanZK(int id)
            {
                THuiyuanZK z = _db.THuiyuanZKs.Single(r => r.id == id);

                _db.THuiyuanZKs.Remove(z);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除供应商
            /// </summary>
            /// <param name="id"></param>
            public void DeleteGongyingshang(int id)
            {
                TGongyingshang g = _db.TGongyingshangs.Single(r => r.id == id);

                _db.TGongyingshangs.Remove(g);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除款号信息
            /// </summary>
            /// <param name="id"></param>
            public void DeleteKuanhao(int id)
            {
                TKuanhao k = _db.TKuanhaos.Single(r => r.id == id);

                _db.TKuanhaos.Remove(k);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除条码信息
            /// </summary>
            /// <param name="id"></param>
            public void DeleteTiaoma(int id)
            {
                TTiaoma t = _db.TTiaomas.Single(r => r.id == id);

                _db.TTiaomas.Remove(t);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除一个加盟商信息
            /// </summary>
            /// <param name="id"></param>
            public void DeleteJiamengshang(int id)
            {
                TJiamengshang j = _db.TJiamengshangs.Single(r => r.id == id);

                _db.TJiamengshangs.Remove(j);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除一个分店历史库存记录
            /// </summary>
            /// <param name="id"></param>
            public void DeleteFDKucun(int id)
            {
                TFendianKucun ofk = _db.TFendianKucuns.Include(r=>r.TFendianKucunMXes).Single(r => r.id == id);

                _db.TFendianKucuns.Remove(ofk);

                _db.SaveChanges();
            }
            public void DeleteCKKucun(int id)
            {
                TCangkuKucun ofk = _db.TCangkuKucuns.Include(r=>r.TCangkuKucunMXes).Single(r => r.id == id);

                _db.TCangkuKucuns.Remove(ofk);

                _db.SaveChanges();
            }

            public void DeleteFDJinchuhuo(int id)
            {
                TFendianJinchuhuo oj = _db.TFendianJinchuhuos.Include(r=>r.TFendianJinchuhuoMXes).Single(r => r.id == id);

                _db.TFendianJinchuhuos.Remove(oj);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除一个销售记录并更新会员积分
            /// </summary>
            /// <param name="id"></param>
            public void DeleteXiaoshou(int id)
            {
                TXiaoshou ot = _db.TXiaoshous.Single(r => r.id == id);

                //更新会员积分
                if (ot.huiyuanid != null)
                {
                    THuiyuan hy = _db.THuiyuans.Single(r => r.id == ot.huiyuanid);
                    hy.jifen -= ot.jine;
                    hy.jfjsshijian = DateTime.Now;
                }

                _db.TXiaoshous.Remove(ot);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除一个地区编码
            /// </summary>
            /// <param name="id"></param>
            public void DeleteDiqu(int id)
            {
                TDiqu d = _db.TDiqus.Single(r => r.id == id);

                _db.TDiqus.Remove(d);

                _db.SaveChanges();
            }

            /// <summary>
            /// 审核通过后，自动删除请求记录
            /// </summary>
            /// <param name="id"></param>
            public void DeleteJiamengGXSQ(int id)
            {
                TJiamengshangGXSQ s = _db.TJiamengshangGXSQs.Single(r => r.id == id);

                _db.TJiamengshangGXSQs.Remove(s);

                _db.SaveChanges();
            }
            /// <summary>
            /// 某个加盟商退出了加盟
            /// </summary>
            /// <param name="id"></param>
            public void DeleteJiamengGX(int id)
            {
                TJiamengshangGX g = _db.TJiamengshangGXes.Single(r => r.id == id);

                _db.TJiamengshangGXes.Remove(g);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除一个原创品牌
            /// </summary>
            /// <param name="id"></param>
            public void DeleteJiamengshangPinpai(int id)
            {
                TPinpai p = _db.TPinpais.Single(r => r.id == id);

                _db.TPinpais.Remove(p);

                _db.SaveChanges();
            }

        }
    }

