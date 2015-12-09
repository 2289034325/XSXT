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
        /// 删除一个出入库记录
        /// </summary>
        /// <param name="id"></param>
        public void DeleteChuruku(int id)
        {
            TChuruku c = _db.TChurukus.Single(r => r.id == id);

            _db.TChurukus.Remove(c);

            _db.SaveChanges();
        }

        /// <summary>
        /// 删除一个出入库明细记录
        /// </summary>
        /// <param name="id"></param>
        public void DeleteChurukuMx(int id)
        {
            TChurukuMX c = _db.TChurukuMXes.Single(r => r.id == id);

            _db.TChurukuMXes.Remove(c);

            _db.SaveChanges();
        }

        public void DeleteJiamengshang(int id)
        {
            TJiamengshang j = _db.TJiamengshangs.Single(r => r.id == id);

            _db.TJiamengshangs.Remove(j);

            _db.SaveChanges();
        }
    }
}
