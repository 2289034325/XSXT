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
            /// 删除用户
            /// </summary>
            /// <param name="id"></param>
            public void DeleteUser(int id)
            {
                TUser u = _db.TUser.Single(r => r.id == id);

                _db.TUser.Remove(u);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除分店
            /// </summary>
            /// <param name="id"></param>
            public void DeleteFendian(int id)
            {
                TFendian f = _db.TFendian.Single(r => r.id == id);

                _db.TFendian.Remove(f);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除仓库
            /// </summary>
            /// <param name="id"></param>
            public void DeleteCangku(int id)
            {
                TCangku f = _db.TCangku.Single(r => r.id == id);

                _db.TCangku.Remove(f);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除会员
            /// </summary>
            /// <param name="id"></param>
            public void DeleteHuiyuan(int id)
            {
                THuiyuan h = _db.THuiyuan.Single(r => r.id == id);

                _db.THuiyuan.Remove(h);

                _db.SaveChanges();
            }
            public void DeleteHuiyuanZK(int id)
            {
                THuiyuanZK z = _db.THuiyuanZK.Single(r => r.id == id);

                _db.THuiyuanZK.Remove(z);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除供应商
            /// </summary>
            /// <param name="id"></param>
            public void DeleteGongyingshang(int id)
            {
                TGongyingshang g = _db.TGongyingshang.Single(r => r.id == id);

                _db.TGongyingshang.Remove(g);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除款号信息
            /// </summary>
            /// <param name="id"></param>
            public void DeleteKuanhao(int id)
            {
                TKuanhao k = _db.TKuanhao.Single(r => r.id == id);

                _db.TKuanhao.Remove(k);

                _db.SaveChanges();
            }

            /// <summary>
            /// 删除条码信息
            /// </summary>
            /// <param name="id"></param>
            public void DeleteTiaoma(int id)
            {
                TTiaoma t = _db.TTiaoma.Single(r => r.id == id);

                _db.TTiaoma.Remove(t);

                _db.SaveChanges();
            }
        }
    }

