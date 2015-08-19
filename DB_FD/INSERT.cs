using DB_FD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DB_FD
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
        public TJinchuhuo InsertJinchuhuo(TJinchuhuo c)
        {
            TJinchuhuo nc = _db.TJinchuhuos.Add(c);
            _db.SaveChanges();

            return nc;
        }
        public TJinchuhuo[] InsertJinchuhuos(TJinchuhuo[] js)
        {
           TJinchuhuo[] njs = _db.TJinchuhuos.AddRange(js).ToArray();

            _db.SaveChanges();

            return njs;
        }

        /// <summary>
        /// 插入一组出入库明细
        /// </summary>
        /// <param name="mxs"></param>
        public void InsertJinchuMxs(TJinchuMX[] mxs)
        {
            _db.TJinchuMXes.AddRange(mxs);

            _db.SaveChanges();
        }
        public void InsertUpdateJinchuMxs(TJinchuMX[] insert, TJinchuMX[] update)
        {
            foreach (TJinchuMX u in update)
            {
                var ou = _db.TJinchuMXes.Single(r => r.jinchuid == u.jinchuid && r.tiaomaid == u.tiaomaid);
                ou.shuliang += u.shuliang;
            }

            _db.TJinchuMXes.AddRange(insert);

            _db.SaveChanges();
        }

        /// <summary>
        /// 插入一个盘点记录
        /// </summary>
        /// <param name="pd"></param>
        /// <returns></returns>
        public TPandian InsertPandian(TPandian pd)
        {
            TPandian npd = _db.TPandians.Add(pd);
            npd.TTiaoma = _db.TTiaomas.Single(r => r.id == npd.tiaomaid);

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
            TKucunXZ nxz = _db.TKucunXZs.Add(xz);
            _db.SaveChanges();

            nxz.TTiaoma = _db.TTiaomas.Single(r => r.id == nxz.tiaomaid);
            nxz.TUser = _db.TUsers.Single(r => r.id == nxz.caozuorenid);

            return nxz;
        }

        /// <summary>
        /// 插入一批销售记录
        /// </summary>
        /// <param name="xss"></param>
        /// <returns></returns>
        public TXiaoshou[] InsertXiaoshous(TXiaoshou[] xss)
        {
            TXiaoshou[] nxss = _db.TXiaoshous.AddRange(xss).ToArray();
            _db.SaveChanges();
            int[] ids = nxss.Select(r => r.id).ToArray();
            TXiaoshou[] nx = _db.TXiaoshous.Include(r=>r.TTiaoma).Where(r => ids.Contains(r.id)).ToArray();

            return nx;
        }

        /// <summary>
        /// 插入一个会员
        /// </summary>
        /// <param name="h"></param>
        public void InsertHuiyuan(THuiyuan h)
        {
            _db.THuiyuans.Add(h);

            _db.SaveChanges();
        }

        /// <summary>
        /// 插入会员折扣信息
        /// </summary>
        /// <param name="zks"></param>
        public void InsertHuiyuanZKs(THuiyuanZK[] zks)
        {
            _db.THuiyuanZKs.AddRange(zks);

            _db.SaveChanges();
        }

        /// <summary>
        /// 新增一个系统用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public TUser InsertUser(TUser user)
        {
            TUser nu = _db.TUsers.Add(user);

            _db.SaveChanges();

            return nu;
        }
    }
}
