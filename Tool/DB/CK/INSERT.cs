using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DB.CK
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
        public TChuruku InsertChuruku(TChuruku c)
        {
            TChuruku nc = _db.TChuruku.Add(c);
            _db.SaveChanges();

            nc.TUser = _db.TUser.Single(r => r.id == nc.caozuorenid);

            return nc;
        }

        /// <summary>
        /// 插入一组出入库明细
        /// </summary>
        /// <param name="mxs"></param>
        public void InsertChurukuMxs(TChurukuMX[] mxs)
        {
            _db.TChurukuMX.AddRange(mxs);

            _db.SaveChanges();
        }

    }
}
