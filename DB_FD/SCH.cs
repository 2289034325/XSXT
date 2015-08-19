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
        public TTiaoma[] GetTiaomaByTmhEndsWith(string tmh)
        {
            return _db.TTiaomas.Where(r => r.tiaoma.EndsWith(tmh)).ToArray();
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
        /// 取所有系统用户，不包含系统管理员
        /// </summary>
        /// <returns></returns>
        public TUser[] GetUsersExceptAdmin(byte excepJS)
        {
            return _db.TUsers.Where(r => r.juese != excepJS).ToArray();
        }
        public TUser[] GetUsers()
        {
            return _db.TUsers.ToArray();
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
                cs = _db.TJinchuhuos.Include(r=>r.TJinchuMXes).Include(r=>r.TUser).Where(r => r.charushijian >= start && r.charushijian < dend).ToArray();                
            }
            else
            {
                cs = _db.TJinchuhuos.Include(r=>r.TJinchuMXes).Include(r=>r.TUser).Where(r => r.id == id.Value).ToArray();
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
            return _db.TJinchuhuos.Include(r=>r.TJinchuMXes).SingleOrDefault(r => r.id == id);
        }

        /// <summary>
        /// 取得某个进出货记录的详细信息
        /// </summary>
        /// <param name="crkid"></param>
        /// <returns></returns>
        public TJinchuMX[] GetJinchuhuoMxsByJchId(int jcid)
        {
            return _db.TJinchuMXes.Include(r=>r.TTiaoma).Where(r => r.jinchuid == jcid).ToArray();
        }

        /// <summary>
        /// 取得所有未上报的进出货数据
        /// </summary>
        /// <returns></returns>
        public TJinchuhuo[] GetJinchuhuosWeishangbao()
        {
            return _db.TJinchuhuos.Include(r=>r.TJinchuMXes).
                //未上报，且有明细数据
                Where(r => r.shangbaoshijian == null && r.TJinchuMXes.Any()).ToArray();
        }

        /// <summary>
        /// 取得当前库存信息
        /// </summary>
        /// <returns></returns>
        public Dictionary<TTiaoma, short> GetKucunView(string tmh, string kh, byte? lx,short?sl_start,short?sl_end)
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
                ks = ks.Where(r => r.t.kuanhao == kh || r.t.gyskuanhao == kh);
            }
            if (lx != null)
            {
                ks = ks.Where(r => r.t.leixing == lx);
            }
            if (sl_start != null)
            {
                ks = ks.Where(r => r.shuliang >= sl_start.Value);
            }
            if (sl_end != null)
            {
                ks = ks.Where(r => r.shuliang <= sl_end.Value);
            }
            return ks.ToDictionary(k => k.t, v => (short)v.shuliang);
        }
        /// <summary>
        /// 查出所有的库存信息
        /// </summary>
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
        /// <summary>
        /// 查询一批条码的库存
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public VKucun[] GetKucunsByTiaomaIds(int[] ids)
        {
            return _db.VKucuns.Where(r => ids.Contains(r.id)).ToArray();
        }
        public VKucun GetKucunByTiaomaId(int id)
        {
            return _db.VKucuns.Single(r => r.id == id);
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
        /// 根据条码id取得一个盘点记录
        /// </summary>
        /// <param name="tmid"></param>
        /// <returns></returns>
        public TPandian GetPandianByTmId(int tmid)
        {
            return _db.TPandians.Include(r=>r.TTiaoma).SingleOrDefault(r => r.tiaomaid == tmid);
        }

        /// <summary>
        /// 取得所有盘点数据
        /// </summary>
        /// <returns></returns>
        public TPandian[] GetPandians()
        {
            return _db.TPandians.Include(r => r.TTiaoma).ToArray();
        }

        /// <summary>
        /// 取得所有库存修正信息
        /// </summary>
        /// <returns></returns>
        public TKucunXZ[] GetKucunXZs()
        {
            return _db.TKucunXZs.Include(r => r.TTiaoma).Include(r=>r.TUser).ToArray();
        }

        /// <summary>
        /// 根据ID取得修正记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TKucunXZ GetKucunXZById(int id)
        {
            return _db.TKucunXZs.Single(r => r.id == id);
        }

        /// <summary>
        /// 取得系统中指定角色的用户
        /// </summary>
        /// <param name="jss"></param>
        /// <returns></returns>
        public TUser[] GetUsersByJss(byte[] jss)
        {
            List<byte> ljss = jss.ToList();
            return _db.TUsers.Where(r => ljss.Contains(r.juese)).ToArray();
        }

        /// <summary>
        /// 根据查询条件查询销售记录
        /// </summary>
        /// <param name="tmh"></param>
        /// <param name="kh"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public TXiaoshou[] GetXiaoshousByCond(string tmh, string kh, DateTime? start, DateTime? end)
        {
            var xss = _db.TXiaoshous.Include(r => r.TUser).Include(r => r.THuiyuan).Include(r => r.TTiaoma).AsQueryable();
            if (!string.IsNullOrEmpty(tmh))
            {
                xss = xss.Where(r => r.TTiaoma.tiaoma == tmh);
            }
            if (!string.IsNullOrEmpty(kh))
            {
                xss = xss.Where(r => r.TTiaoma.kuanhao == kh);
            }
            if (start != null)
            {
                xss = xss.Where(r => r.xiaoshoushijian >= start);
            }
            if (end != null)
            {
                xss = xss.Where(r => r.xiaoshoushijian < end);
            }

            return xss.ToArray();
        }
        public TXiaoshou GetXiaoshouById(int id)
        {
            return _db.TXiaoshous.Single(r => r.id == id);
        }
        /// <summary>
        /// 取未上报的销售信息
        /// </summary>
        /// <returns></returns>
        public TXiaoshou[] GetXiaoshousWeishangbao()
        {
            return _db.TXiaoshous.Include(r=>r.TUser).Where(r => r.shangbaoshijian == null).ToArray();
        }


        /// <summary>
        /// 根据手机号查询会员信息
        /// </summary>
        /// <param name="sjh"></param>
        /// <returns></returns>
        public THuiyuan GetHuiyuanByShoujihao(string sjh)
        {
            return _db.THuiyuans.SingleOrDefault(r => r.shoujihao == sjh);
        }

        /// <summary>
        /// 取会员积分折扣表
        /// </summary>
        /// <returns></returns>
        public THuiyuanZK[] GetHuiyuanZKs()
        {
            return _db.THuiyuanZKs.ToArray();
        }

        /// <summary>
        /// 根据ID取得会员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public THuiyuan GetHuiyuanById(int id)
        {
            return _db.THuiyuans.Single(r => r.id == id);
        }

        /// <summary>
        /// 根据条件查询会员信息
        /// </summary>
        /// <param name="sjh"></param>
        /// <returns></returns>
        public THuiyuan[] GetHuiyuanByCond(string sjh)
        {
            var hys = _db.THuiyuans.AsQueryable();
            if (!string.IsNullOrEmpty(sjh))
            {
                hys = hys.Where(r => r.shoujihao == sjh);
            }

            return hys.ToArray();
        }


        /// <summary>
        /// 取得某个进出货明细记录
        /// </summary>
        /// <param name="jcid"></param>
        /// <param name="tmid"></param>
        /// <returns></returns>
        public TJinchuMX GetJinchuhuoMX(int jcid, int tmid)
        {
            return _db.TJinchuMXes.SingleOrDefault(r => r.jinchuid == jcid && r.tiaomaid == tmid);
        }
        /// <summary>
        /// 取得某个进出货明细记录
        /// </summary>
        /// <param name="mxid">明细记录ID</param>
        /// <returns></returns>
        public TJinchuMX GetJinchuhuoMXById(int mxid)
        {
            return _db.TJinchuMXes.Include(r=>r.TJinchuhuo).Single(r => r.id == mxid);
        }
    }
}
