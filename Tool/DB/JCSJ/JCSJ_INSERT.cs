using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DB.JCSJ
{
    public partial class OPT
    {
        /// <summary>
        /// 插入一个新用户
        /// </summary>
        /// <param name="u"></param>
        public void InsertUser(TUser u)
        {
            _db.TUser.Add(u);

            _db.SaveChanges();
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
        public void InsertHuiyuan(THuiyuan h)
        {
            _db.THuiyuan.Add(h);

            _db.SaveChanges();
        }

        /// <summary>
        /// 增加一个供应商
        /// </summary>
        /// <param name="g"></param>
        public void InsertGongyingshang(TGongyingshang g)
        {
            _db.TGongyingshang.Add(g);

            _db.SaveChanges();
        }

        /// <summary>
        /// 增加一个款号
        /// </summary>
        /// <param name="k"></param>
        public void InsertKuanhao(TKuanhao k)
        {
            _db.TKuanhao.Add(k);

            _db.SaveChanges();
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
    }
}
