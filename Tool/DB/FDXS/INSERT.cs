using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DB.FDXS
{
    public partial class DBContext
    {
        /// <summary>
        /// 插入一组条码
        /// </summary>
        /// <param name="tms"></param>
        public void InsertTiaomas(TTiaoma[] tms)
        {
            _db.TTiaoma.AddRange(tms);

            _db.SaveChanges();
        }

        /// <summary>
        /// 插入一个出入库记录
        /// </summary>
        /// <param name="c"></param>
        public TJinchuhuo InsertJinchuhuo(TJinchuhuo c)
        {
            TJinchuhuo nc = _db.TJinchuhuo.Add(c);
            _db.SaveChanges();

            nc.TUser = _db.TUser.Single(r => r.id == nc.caozuorenid);

            return nc;
        }

        /// <summary>
        /// 插入一组出入库明细
        /// </summary>
        /// <param name="mxs"></param>
        public void InsertJinchuMxs(TJinchuMX[] mxs)
        {
            _db.TJinchuMX.AddRange(mxs);

            _db.SaveChanges();
        }

        /// <summary>
        /// 插入一个盘点记录
        /// </summary>
        /// <param name="pd"></param>
        /// <returns></returns>
        public TPandian InsertPandian(TPandian pd)
        {
            TPandian npd = _db.TPandian.Add(pd);
            npd.TTiaoma = _db.TTiaoma.Single(r => r.id == npd.tiaomaid);

            _db.SaveChanges();

            return npd;
        }

        /// <summary>
        /// 插入一个库存修正记录
        /// </summary>
        /// <param name="xz"></param>
        /// <returns></returns>
        public TKucunXZ InsertKucunXZ(TKucunXZ xz)
        {
            TKucunXZ nxz = _db.TKucunXZ.Add(xz);
            _db.SaveChanges();

            nxz.TTiaoma = _db.TTiaoma.Single(r => r.id == nxz.tiaomaid);
            nxz.TUser = _db.TUser.Single(r => r.id == nxz.caozuorenid);

            return nxz;
        }

    }
}
