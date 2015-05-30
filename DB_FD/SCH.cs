using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_FD
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
        public TUser GetUserById(int id)
        {
            return _db.TUser.Single(r => r.id == id);
        }
        /// <summary>
        /// 取所有系统用户，不包含系统管理员
        /// </summary>
        /// <returns></returns>
        public TUser[] GetUsersExceptAdmin(byte excepJS)
        {
            return _db.TUser.Where(r => r.juese != excepJS).ToArray();
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
        /// 取得所有未上报的进出货数据
        /// </summary>
        /// <returns></returns>
        public TJinchuhuo[] GetJinchuhuosWeishangbao()
        {
            return _db.TJinchuhuo.Include("TJinchuMX").
                //未上报，且有明细数据
                Where(r => r.shangbaoshijian == null && r.TJinchuMX.Any()).ToArray();
        }

        /// <summary>
        /// 取得当前库存信息
        /// </summary>
        /// <returns></returns>
        public Dictionary<TTiaoma, short> GetKucunView(string tmh, string kh, string lx)
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
            return ks.ToDictionary(k => k.t, v => (short)v.shuliang.Value);
        }
        /// <summary>
        /// 查出所有的库存信息
        /// </summary>
        /// <returns></returns>
        public VKucun[] GetKucuns()
        {
            return _db.VKucun.ToArray();
        }
        /// <summary>
        /// 查询一批条码的库存
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public VKucun[] GetKucunsByTiaomaIds(int[] ids)
        {
            return _db.VKucun.Where(r => ids.Contains(r.id)).ToArray();
        }
        public VKucun GetKucunByTiaomaId(int id)
        {
            return _db.VKucun.Single(r => r.id == id);
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

        /// <summary>
        /// 取得系统中指定角色的用户
        /// </summary>
        /// <param name="jss"></param>
        /// <returns></returns>
        public TUser[] GetUsersByJss(byte[] jss)
        {
            List<byte> ljss = jss.ToList();
            return _db.TUser.Where(r => ljss.Contains(r.juese)).ToArray();
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
            var xss = _db.TXiaoshou.Include("TTiaoma").Include("TUser").AsQueryable();
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
                DateTime dend = end.Value.AddDays(1);
                xss = xss.Where(r => r.xiaoshoushijian < dend);
            }

            return xss.ToArray();
        }
        public TXiaoshou GetXiaoshouById(int id)
        {
            return _db.TXiaoshou.Single(r => r.id == id);
        }
        /// <summary>
        /// 取未上报的销售信息
        /// </summary>
        /// <returns></returns>
        public TXiaoshou[] GetXiaoshousWeishangbao()
        {
            return _db.TXiaoshou.Include("TUser").Where(r => r.shangbaoshijian == null).ToArray();
        }


        /// <summary>
        /// 根据手机号查询会员信息
        /// </summary>
        /// <param name="sjh"></param>
        /// <returns></returns>
        public THuiyuan GetHuiyuanByShoujihao(string sjh)
        {
            return _db.THuiyuan.SingleOrDefault(r => r.shoujihao == sjh);
        }

        /// <summary>
        /// 取会员积分折扣表
        /// </summary>
        /// <returns></returns>
        public THuiyuanZK[] GetHuiyuanZKs()
        {
            return _db.THuiyuanZK.ToArray();
        }

        /// <summary>
        /// 根据ID取得会员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public THuiyuan GetHuiyuanById(int id)
        {
            return _db.THuiyuan.Single(r => r.id == id);
        }

        /// <summary>
        /// 根据条件查询会员信息
        /// </summary>
        /// <param name="sjh"></param>
        /// <returns></returns>
        public THuiyuan[] GetHuiyuanByCond(string sjh)
        {
            var hys = _db.THuiyuan.AsQueryable();
            if (string.IsNullOrEmpty(sjh))
            {
                hys = hys.Where(r => r.shoujihao == sjh);
            }

            return hys.ToArray();
        }
    }
}
