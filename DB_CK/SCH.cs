using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DB_CK.Models;

namespace DB_CK
{
    public partial class DBContext
    {
        /// <summary>
        /// 取得一组ID的条码信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public TTiaoma[] GetTiaomasByIds(int[] ids)
        {
            return _db.TTiaomas.Where(r => ids.Contains(r.id)).ToArray();
        }

        /// <summary>
        /// 根据一组条码号取得条码信息
        /// </summary>
        /// <param name="tmhs"></param>
        /// <returns></returns>
        public TTiaoma[] GetTiaomasByTmhs(string[] tmhs)
        {
            return _db.TTiaomas.Where(r => tmhs.Contains(r.tiaoma)).ToArray();
        }
        public TTiaoma GetTiaomaByTmh(string tmh)
        {
            return _db.TTiaomas.SingleOrDefault(r => r.tiaoma == tmh);
        }

        /// <summary>
        /// 根据登录名和密码取得用户信息
        /// </summary>
        /// <param name="dlm"></param>
        /// <param name="mm"></param>
        /// <returns></returns>
        public TUser GetUser(string dlm, string mm)
        {
            TUser u = _db.TUsers.SingleOrDefault(r => r.dengluming == dlm && r.mima == mm);

            return u;
        }
        public TUser GetUserById(int id)
        {
            return _db.TUsers.Single(r => r.id == id);
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
                cs = _db.TChurukus.Include(r=>r.TChurukuMXes).Include(r=>r.TUser).Where(r => r.charushijian >= start && r.charushijian < dend).ToArray();
            }
            else
            {
                cs = _db.TChurukus.Include(r=>r.TChurukuMXes).Include(r=>r.TUser).Where(r => r.id == id.Value).ToArray();
            }

            return cs;
        }

        /// <summary>
        /// 取得所有未上报的数据
        /// </summary>
        /// <returns></returns>
        public TChuruku[] GetChurukuWeishangbao()
        {
            return _db.TChurukus.Include(r=>r.TChurukuMXes).Where(r => r.shangbaoshijian == null && r.TChurukuMXes.Any()).ToArray();
        }

        /// <summary>
        /// 根据ID取得出入库记录信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TChuruku GetChurukuById(int id)
        {
            return _db.TChurukus.Include(r=>r.TChurukuMXes).SingleOrDefault(r => r.id == id);
        }

        /// <summary>
        /// 取得某个出入库记录的详细信息
        /// </summary>
        /// <param name="crkid"></param>
        /// <returns></returns>
        public TChurukuMX[] GetChurukuMxsByCrkId(int crkid)
        {
            return _db.TChurukuMXes.Include(r=>r.TTiaoma).Where(r => r.churukuid == crkid).ToArray();
        }
        public TChurukuMX GetChurukuMxByCrkIdTmid(int crkid, int tmid)
        {
            return _db.TChurukuMXes.SingleOrDefault(r => r.churukuid == crkid && r.tiaomaid == tmid);
        }

        /// <summary>
        /// 取得当前库存信息
        /// </summary>
        /// <returns></returns>
        public Dictionary<TTiaoma, short> GetKucunView(string tmh, string kh, string lx)
        {
            var ks = from k in _db.VKucuns
                     join t in _db.TTiaomas
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
            return ks.ToDictionary(k => k.t, v => v.shuliang);
        }

        /// <summary>
        /// 取得指定数量的库存信息
        /// </summary>
        /// <param name="sl_start"></param>
        /// <param name="sl_end"></param>
        /// <returns></returns>
        public VKucun[] GetKucunsByCond(short? sl_start, short? sl_end)
        {
            var ks = _db.VKucuns.AsQueryable();
            if (sl_start != null)
            {
                ks = ks.Where(r => r.shuliang >= sl_start.Value);
            }
            if (sl_end != null)
            {
                ks = ks.Where(r => r.shuliang <= sl_end.Value);
            }

            return ks.ToArray();
        }
        public VKucun GetKucunByTmid(int tmid)
        {
            return _db.VKucuns.Single(r => r.id == tmid);
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
            var tms = _db.TTiaomas.AsQueryable();
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
        /// 取得当前数据库版本
        /// </summary>
        /// <returns></returns>
        public int GetDbVersion()
        {
            return _db.TVersions.Max(r => r.banben);
        }
    }
}
