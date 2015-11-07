using DB_CK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_CK
{
    public partial class DBContext
    {
        /// <summary>
        /// 插入一组条码
        /// </summary>
        /// <param name="tms"></param>
        public void InsertTiaomas(TTiaoma[] tms)
        {
            _db.TTiaomas.AddRange(tms);

            _db.SaveChanges();
        }

        /// <summary>
        /// 插入一个出入库记录
        /// </summary>
        /// <param name="c"></param>
        public TChuruku InsertChuruku(TChuruku c)
        {
            TChuruku nc = _db.TChurukus.Add(c);
            _db.SaveChanges();

            nc.TUser = _db.TUsers.Single(r => r.id == nc.caozuorenid);

            return nc;
        }

        /// <summary>
        /// 插入一组出入库明细
        /// </summary>
        /// <param name="mxs"></param>
        public void InsertChurukuMxs(TChurukuMX[] mxs)
        {
            _db.TChurukuMXes.AddRange(mxs);

            _db.SaveChanges();
        }

        public void InsertUpdateChurukuMxes(TChurukuMX[] insert, TChurukuMX[] update)
        {
            foreach (TChurukuMX u in update)
            {
                var ou = _db.TChurukuMXes.Single(r => r.churukuid == u.churukuid && r.tiaomaid == u.tiaomaid);
                ou.shuliang += u.shuliang;
            }

            _db.TChurukuMXes.AddRange(insert);

            _db.SaveChanges();
        }

    }
}
