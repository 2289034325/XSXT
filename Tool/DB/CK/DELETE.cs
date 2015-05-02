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
        /// 删除一个出入库记录
        /// </summary>
        /// <param name="id"></param>
        public void DeleteChuruku(int id)
        {
            TChuruku c = _db.TChuruku.Single(r => r.id == id);

            _db.TChuruku.Remove(c);

            _db.SaveChanges();
        }

        /// <summary>
        /// 删除一个出入库明细记录
        /// </summary>
        /// <param name="id"></param>
        public void DeleteChurukuMx(int id)
        {
            TChurukuMX c = _db.TChurukuMX.Single(r => r.id == id);

            _db.TChurukuMX.Remove(c);

            _db.SaveChanges();
        }
    }
}
