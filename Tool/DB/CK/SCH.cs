using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DB.CK
{
    public partial class DBContext
    {
        private Entities _db;
        public DBContext()
        {
            _db = new Entities();
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
        /// 搜索出入库记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public TChuruku[] GetChurukus(int? id, DateTime start, DateTime end)
        {
            TChuruku[] cs = null;
            if (id == null)
            {
                DateTime dend = end.AddDays(1);
                cs = _db.TChuruku.Include("TChurukuMX").Include("TUser").Where(r => r.charushijian >= start && r.charushijian < dend).ToArray();
            }
            else
            {
                cs = _db.TChuruku.Include("TChurukuMX").Include("TUser").Where(r => r.id == id.Value).ToArray();
            }

            return cs;
        }

        /// <summary>
        /// 根据ID取得出入库记录信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TChuruku GetChurukuById(int id)
        {
            return _db.TChuruku.SingleOrDefault(r => r.id == id);
        }

        /// <summary>
        /// 取得某个出入库记录的详细信息
        /// </summary>
        /// <param name="crkid"></param>
        /// <returns></returns>
        public TChurukuMX[] GetChurukuMxsByCrkId(int crkid)
        {
            return _db.TChurukuMX.Include("TTiaoma").Where(r => r.churukuid == crkid).ToArray();
        }

        /// <summary>
        /// 取得当前库存信息
        /// </summary>
        /// <returns></returns>
        public Dictionary<TTiaoma, int> GetKucunView(string tmh, string kh, string lx)
        {
            var ks = from k in _db.VKucun
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
            return ks.ToDictionary(k => k.t, v => v.shuliang.Value);
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
    }
}
