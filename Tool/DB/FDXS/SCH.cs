using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DB.FDXS
{
    public partial class DBContext
    {
        private FDXSEntities _db;
        public DBContext()
        {
            _db = new FDXSEntities();
            //此项会引起entity无法序列化的错误
            _db.Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// 取得一组ID的条码信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public TTiaoma[] GetTiaomasByIds(int[] ids)
        {
            return _db.TTiaoma.Where(r => ids.Contains(r.id)).ToArray();
        }

        /// <summary>
        /// 根据一组条码号取得条码信息
        /// </summary>
        /// <param name="tmhs"></param>
        /// <returns></returns>
        public TTiaoma[] GetTiaomasByTmhs(string[] tmhs)
        {
            return _db.TTiaoma.Where(r => tmhs.Contains(r.tiaoma)).ToArray();
        }
        public TTiaoma GetTiaomaByTmh(string tmh)
        {
            return _db.TTiaoma.SingleOrDefault(r => r.tiaoma == tmh);
        }       

        /// <summary>
        /// 根据登录名和密码取得用户信息
        /// </summary>
        /// <param name="dlm"></param>
        /// <param name="mm"></param>
        /// <returns></returns>
        public TUser GetUser(string dlm, string mm)
        {
            TUser u = _db.TUser.SingleOrDefault(r => r.dengluming == dlm && r.mima == mm);

            return u;
        }

        /// <summary>
        /// 搜索进出货记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public TJinchuhuo[] GetJinchuhuos(int? id, DateTime start, DateTime end)
        {
            TJinchuhuo[] cs = null;
            if (id == null)
            {
                DateTime dend = end.AddDays(1);
                cs = _db.TJinchuhuo.Include("TJinchuMX").Include("TUser").Where(r => r.charushijian >= start && r.charushijian < dend).ToArray();
            }
            else
            {
                cs = _db.TJinchuhuo.Include("TJinchuMX").Include("TUser").Where(r => r.id == id.Value).ToArray();
            }

            return cs;
        }

        /// <summary>
        /// 根据ID取得进出货记录信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TJinchuhuo GetJinchuhuoById(int id)
        {
            return _db.TJinchuhuo.SingleOrDefault(r => r.id == id);
        }

        /// <summary>
        /// 取得某个进出货记录的详细信息
        /// </summary>
        /// <param name="crkid"></param>
        /// <returns></returns>
        public TJinchuMX[] GetJinchuhuoMxsByJchId(int jcid)
        {
            return _db.TJinchuMX.Include("TTiaoma").Where(r => r.jinchuid == jcid).ToArray();
        }

        /// <summary>
        /// 取得当前库存信息
        /// </summary>
        /// <returns></returns>
        public Dictionary<TTiaoma, short> GetKucunView(string tmh, string kh, string lx)
        {
            var ks = from k in _db.VFKucun
                     join t in _db.TTiaoma
                     on k.id equals t.id
                     select new
                     {
                         t,
                         k.shuliang
                     };
            if (!string.IsNullOrEmpty(tmh))
            {
                ks = ks.Where(r => r.t.tiaoma == tmh);
            }
            if (!string.IsNullOrEmpty(kh))
            {
                ks = ks.Where(r => r.t.kuanhao == kh);
            }
            if (!string.IsNullOrEmpty(lx))
            {
                byte blx = byte.Parse(lx);
                ks = ks.Where(r => r.t.leixing == blx);
            }
            return ks.ToDictionary(k => k.t, v => (short)v.shuliang.Value);

            //return new Dictionary<TTiaoma, int>();
        }

        /// <summary>
        /// 根据查询条件查询条码
        /// </summary>
        /// <param name="tmh"></param>
        /// <param name="kh"></param>
        /// <param name="lx"></param>
        /// <returns></returns>
        public TTiaoma[] GetTiaomasByCond(string tmh, string kh, string lx)
        {
            var tms = _db.TTiaoma.AsQueryable();
            if (!string.IsNullOrEmpty(tmh))
            {
                tms = tms.Where(r => r.tiaoma == tmh);
            }
            if (!string.IsNullOrEmpty(kh))
            {
                tms = tms.Where(r => r.kuanhao == kh);
            }
            if (!string.IsNullOrEmpty(lx))
            {
                byte blx = byte.Parse(lx);
                tms = tms.Where(r => r.leixing == blx);
            }

            return tms.ToArray();
        }

        /// <summary>
        /// 根据条码id取得一个盘点记录
        /// </summary>
        /// <param name="tmid"></param>
        /// <returns></returns>
        public TPandian GetPandianByTmId(int tmid)
        {
            return _db.TPandian.Include("TTiaoma").SingleOrDefault(r => r.tiaomaid == tmid);
        }

        /// <summary>
        /// 取得所有盘点数据
        /// </summary>
        /// <returns></returns>
        public TPandian[] GetPandians()
        {
            return _db.TPandian.Include("TTiaoma").ToArray();
        }

        /// <summary>
        /// 取得所有库存修正信息
        /// </summary>
        /// <returns></returns>
        public TKucunXZ[] GetKucunXZs()
        {
            return _db.TKucunXZ.Include("TTiaoma").Include("TUser").ToArray();
        }

        /// <summary>
        /// 根据ID取得修正记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TKucunXZ GetKucunXZById(int id)
        {
            return _db.TKucunXZ.Single(r => r.id == id);
        }
    }
}
