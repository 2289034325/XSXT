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
        /// 删除一个进出货记录
        /// </summary>
        /// <param name="id"></param>
        public void DeleteJinchuhuo(int id)
        {
            TJinchuhuo c = _db.TJinchuhuo.Single(r => r.id == id);

            _db.TJinchuhuo.Remove(c);

            _db.SaveChanges();
        }

        /// <summary>
        /// 删除一个进出货明细记录
        /// </summary>
        /// <param name="id"></param>
        public void DeleteJinchuMx(int id)
        {
            TJinchuMX c = _db.TJinchuMX.Single(r => r.id == id);

            _db.TJinchuMX.Remove(c);

            _db.SaveChanges();
        }
    }
}
