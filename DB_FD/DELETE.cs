using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_FD
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

        /// <summary>
        /// 删除所有盘点记录
        /// </summary>
        public void DeletePandianAll()
        {
            var pds = _db.TPandian;
            _db.TPandian.RemoveRange(pds);

            _db.SaveChanges();
        }
        public void DeletePandianById(int id)
        {
            TPandian p = _db.TPandian.Single(r => r.id == id);
            _db.TPandian.Remove(p);

            _db.SaveChanges();
        }

        /// <summary>
        /// 删除一个库存修正记录
        /// </summary>
        /// <param name="id"></param>
        public void DeleteKucunXZ(int id)
        {
            TKucunXZ k = _db.TKucunXZ.Single(r => r.id == id);

            _db.TKucunXZ.Remove(k);

            _db.SaveChanges();
        }

        /// <summary>
        /// 删除所有会员折扣记录
        /// </summary>
        public void DeleteHuiyuanZK()
        {
            var zks = _db.THuiyuanZK;
            _db.THuiyuanZK.RemoveRange(zks);

            _db.SaveChanges();
        }

        /// <summary>
        /// 删除一个系统用户
        /// </summary>
        /// <param name="id"></param>
        public void DeleteUser(int id)
        {
            var u = _db.TUser.Single(r => r.id == id);
            _db.TUser.Remove(u);

            _db.SaveChanges();
        }
    }
}
