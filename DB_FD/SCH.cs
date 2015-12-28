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
        public TTiaoma GetTiaomaById(int id)
        {
            return _db.TTiaomas.Single(r => r.id == id);
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
        public TJinchuhuo[] GetJinchuhuos(string tm, DateTime? fsrq_start, DateTime? fsrq_end)
        {
            var jcs = _db.TJinchuhuos.Include(r => r.TJinchuMXes).
                Include(r => r.TJinchuMXes.Select(xr => xr.TTiaoma)).Include(r => r.TUser).AsQueryable();
            if (!string.IsNullOrEmpty(tm))
            {
                jcs = jcs.Where(r => r.TJinchuMXes.Any(xr => xr.TTiaoma.tiaoma == tm));
            }
            if (fsrq_start != null)
            {
                jcs = jcs.Where(r => r.charushijian >= fsrq_start);
            }
            if (fsrq_end != null)
            {
                jcs = jcs.Where(r => r.charushijian < fsrq_end);
            }

            return jcs.ToArray();
        }

        public TJinchuhuo GetJinchuhuoByPcm(string pcm)
        {
            return _db.TJinchuhuos.SingleOrDefault(r => r.picima == pcm);
        }
        

        /// <summary>
        /// 根据ID取得进出货记录信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TJinchuhuo GetJinchuhuoById(int id)
        {
            return _db.TJinchuhuos.Include(r=>r.TJinchuMXes).Include(r=>r.TUser).SingleOrDefault(r => r.id == id);
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
                Where(r => r.shangbaoshijian == null && r.queding == true && r.TJinchuMXes.Any()).ToArray();
        }

        /// <summary>
        /// 查询库存信息
        /// </summary>
        /// <param name="tmh">条码号</param>
        /// <param name="kh">款号</param>
        /// <param name="lx">类型</param>
        /// <param name="sl_start">库存数量范围</param>
        /// <param name="sl_end">库存数量范围</param>
        /// <param name="jhrq_start">进货日期</param>
        /// <param name="jhrq_end">进货日期</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="recordCount">命中的记录数</param>
        /// <param name="schKucun">命中的库存数量</param>
        /// <param name="schJinjia">命中的成本总价</param>
        /// <param name="schShoujia">命中的售价总价</param>
        /// <returns></returns>
        public Dictionary<TTiaoma, short> GetKucunView(string tmh, string kh, byte? lx,
            short?sl_start,short?sl_end,DateTime? jhrq_start,DateTime? jhrq_end, int? pageSize,int?pageIndex,
            out int recordCount,out int schKucun,out decimal schJinjia,out decimal schShoujia)
        {
            var ks = from k in _db.VKucuns
                     join t in _db.TTiaomas
                     on k.id equals t.id
                     select new
                     {
                         t,
                         k.shuliang,
                         k.jinhuoriqi
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
            if (jhrq_start != null)
            {
                ks = ks.Where(r => r.jinhuoriqi >= jhrq_start);
            }
            if (jhrq_end != null)
            {
                ks = ks.Where(r => r.jinhuoriqi <= jhrq_end);
            }

            schKucun = ks.Sum(r => (int?)r.shuliang)??0;
            schJinjia = ks.Sum(r => (short?)r.shuliang * r.t.jinjia)??0;
            schShoujia = ks.Sum(r => (short?)r.shuliang * r.t.shoujia)??0;

            recordCount = ks.Count();
            if (pageSize != null && pageIndex != null)
            {
                ks = ks.OrderBy(r => r.t.tiaoma).Skip(pageSize.Value * pageIndex.Value).Take(pageSize.Value);
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
        public TXiaoshou[] GetXiaoshousByCond(string tmh, string kh, DateTime? start, DateTime? end, int? pageSize, int? pageIndex,
            out int recordCount)
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

            recordCount = xss.Count();

            if (pageSize != null)
            {
                xss = xss.OrderByDescending(r => r.id).Skip(pageSize.Value * pageIndex.Value).Take(pageSize.Value);
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

        /// <summary>
        /// 取得当前数据库版本
        /// </summary>
        /// <returns></returns>
        public int GetDbVersion()
        {
            return _db.TVersions.Max(r => r.banben);
        }


        /// <summary>
        /// 查询库存总计
        /// </summary>
        /// <param name="zongshu">库存总数</param>
        /// <param name="chengben">库存成本</param>
        /// <param name="shoujia">库存售价</param>
        public void GetKucunZongji(out int zongshu, out decimal chengben, out decimal shoujia)
        {
            var ks = from k in _db.VKucuns
                     join t in _db.TTiaomas
                     on k.id equals t.id
                     select new
                     {
                         t,
                         k.shuliang
                     };

            zongshu = ks.Sum(r => (int?)r.shuliang)??0;
            chengben = ks.Sum(r => (short?)r.shuliang * r.t.jinjia)??0;
            shoujia = ks.Sum(r => (short?)r.shuliang * r.t.shoujia)??0;
        }
    }
}
