using DB_FD.Models;
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
            TJinchuhuo c = _db.TJinchuhuos.Single(r => r.id == id);

            _db.TJinchuhuos.Remove(c);

            _db.SaveChanges();
        }

        /// <summary>
        /// 删除一个进出货明细记录
        /// </summary>
        /// <param name="id"></param>
        public void DeleteJinchuMx(int id)
        {
            TJinchuMX c = _db.TJinchuMXes.Single(r => r.id == id);

            _db.TJinchuMXes.Remove(c);

            _db.SaveChanges();
        }

        /// <summary>
        /// 删除所有盘点记录
        /// </summary>
        public void DeletePandianAll()
        {
            var pds = _db.TPandians;
            _db.TPandians.RemoveRange(pds);

            _db.SaveChanges();
        }
        public void DeletePandianById(int id)
        {
            TPandian p = _db.TPandians.Single(r => r.id == id);
            _db.TPandians.Remove(p);

            _db.SaveChanges();
        }

        /// <summary>
        /// 删除一个库存修正记录
        /// </summary>
        /// <param name="id"></param>
        public void DeleteKucunXZ(int id)
        {
            TKucunXZ k = _db.TKucunXZs.Single(r => r.id == id);

            _db.TKucunXZs.Remove(k);

            _db.SaveChanges();
        }

        /// <summary>
        /// 删除一个销售记录
        /// </summary>
        /// <param name="id"></param>
        public void DeleteXiaoshou(int id)
        {
            TXiaoshou x = _db.TXiaoshous.Single(r => r.id == id);

            _db.TXiaoshous.Remove(x);

            _db.SaveChanges();
        }

        /// <summary>
        /// 删除所有会员折扣记录
        /// </summary>
        public void DeleteHuiyuanZK()
        {
            var zks = _db.THuiyuanZKs;
            _db.THuiyuanZKs.RemoveRange(zks);

            _db.SaveChanges();
        }

        /// <summary>
        /// 删除一个系统用户
        /// </summary>
        /// <param name="id"></param>
        public void DeleteUser(int id)
        {
            var u = _db.TUsers.Single(r => r.id == id);
            _db.TUsers.Remove(u);

            _db.SaveChanges();
        }
    }
}
