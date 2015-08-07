using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DB_JCSJ
{
        public partial class DBContext
        {          
            /// <summary>
            /// 登陆验证
            /// </summary>
            /// <param name="dlm">用户名</param>
            /// <param name="mmd5">md5加密后的密码</param>
            /// <returns></returns>
            public TUser GetUser(string dlm, string mmd5)
            {
                return _db.TUsers.SingleOrDefault(r => r.dengluming == dlm && r.mima == mmd5);
            }
            /// <summary>
            /// 根据登陆名取得用户
            /// </summary>
            /// <param name="dlm"></param>
            /// <returns></returns>
            public TUser GetUserByDlm(string dlm)
            {
                return _db.TUsers.SingleOrDefault(r => r.dengluming == dlm);
            }

            /// <summary>
            /// 取得所有系统用户
            /// </summary>
            /// <param name="ExeptAdmin">是否包含系统管理员</param>
            /// <returns></returns>
            public TUser[] GetUsersExcept(byte js)
            {
                var Users = _db.TUsers.Where(r => r.juese != js);

                return Users.ToArray();
            }

            /// <summary>
            /// 取得所有分店信息
            /// </summary>
            /// <returns></returns>
            public TFendian[] GetFendians()
            {
                var Fendians = _db.TFendians.Include(r=>r.TUser);

                return Fendians.ToArray();
            }
            public TFendian GetFendianByIdMc(int id, string mc)
            {
                return _db.TFendians.SingleOrDefault(r => r.id == id && r.dianming == mc);
            }
            public TFendian GetFendianById(int id)
            {
                return _db.TFendians.SingleOrDefault(r => r.id == id);
            }

            /// <summary>
            /// 取得所有仓库信息
            /// </summary>
            /// <returns></returns>
            public TCangku[] GetCangkus()
            {
                var Cangkus = _db.TCangkus.Include(r => r.TUser);

                return Cangkus.ToArray();
            }
            /// <summary>
            /// 根据id和名称取得仓库信息
            /// </summary>
            /// <param name="id"></param>
            /// <param name="mc"></param>
            /// <returns></returns>
            public TCangku GetCangkuByIdMc(int id, string mc)
            {
                return _db.TCangkus.SingleOrDefault(r => r.id == id && r.mingcheng == mc);
            }
            public TCangku GetCangkuById(int id)
            {
                return _db.TCangkus.SingleOrDefault(r => r.id == id);
            }

            /// <summary>
            /// 取得所有会员信息
            /// </summary>
            /// <returns></returns>
            public THuiyuan[] GetHuiyuans()
            {
                var Huiyuans = _db.THuiyuans.Include(r => r.TUser).Include(r=>r.TFendian);

                return Huiyuans.ToArray();
            }

            /// <summary>
            /// 取得所有供应商信息
            /// </summary>
            /// <returns></returns>
            public TGongyingshang[] GetGongyingshangs()
            {
                var Gongys = _db.TGongyingshangs.Include(r => r.TUser);

                return Gongys.ToArray();
            }
            /// <summary>
            /// 取得某个用户编辑的所有供应商信息
            /// </summary>
            /// <returns></returns>
            public TGongyingshang[] GetGongyingshangsByUserId(int UserId)
            {
                var Gongys = _db.TGongyingshangs.Where(r => r.caozuorenid == UserId);

                return Gongys.ToArray();
            }
            public TGongyingshang GetGongyingshangById(int id)
            {
                return _db.TGongyingshangs.SingleOrDefault(r => r.id == id);
            }

            /// <summary>
            /// 取得所有款号信息
            /// </summary>
            /// <returns></returns>
            public TKuanhao[] GetKuanhaosByCond(byte? lx, string kh, string pm, int pageSize, int pageIndex, out int recordCount)
            {
                var Kuanhaos = _db.TKuanhaos.Include(r => r.TUser).AsQueryable();
                if (lx != null)
                {
                    Kuanhaos = Kuanhaos.Where(r => r.leixing == lx.Value);
                }
                if (!string.IsNullOrEmpty(kh))
                {
                    Kuanhaos = Kuanhaos.Where(r => r.kuanhao == kh);
                }
                if (!string.IsNullOrEmpty(pm))
                {
                    Kuanhaos = Kuanhaos.Where(r => r.pinming == pm);
                }

                recordCount = Kuanhaos.Count();
                Kuanhaos = Kuanhaos.OrderByDescending(r => r.xiugaishijian).Skip(pageSize * pageIndex);

                return Kuanhaos.ToArray();
            }

            /// <summary>
            /// 根据款号名称取得款号信息
            /// </summary>
            /// <param name="kh"></param>
            /// <returns></returns>
            public TKuanhao GetKuanhaoByMc(string kh)
            {
                return _db.TKuanhaos.SingleOrDefault(r => r.kuanhao == kh);
            }
            public TKuanhao GetKuanhaoById(int id)
            {
                return _db.TKuanhaos.SingleOrDefault(r => r.id == id);
            }

            /// <summary>
            /// 取得某个用户编辑的所有款号信息
            /// </summary>
            /// <param name="UserId"></param>
            /// <returns></returns>
            public TKuanhao[] GetKuanhaosByUserId(int UserId)
            {
                var ks = _db.TKuanhaos.Where(r => r.caozuorenid == UserId);

                return ks.ToArray();
            }

            /// <summary>
            /// 取得指定个数的条码信息
            /// </summary>
            /// <returns></returns>
            public TTiaoma[] GetTiaomasByCond(int? userid,byte? lx, string kh, string tmh,DateTime? xgsj_start,DateTime? xgsj_end, int pageSize, int pageIndex, out int recordCount)
            {
                var tms = _db.TTiaomas.Include(r => r.TUser).Include(r=>r.TKuanhao).Include(r=>r.TGongyingshang).AsQueryable();
                if (lx != null)
                {
                    tms = tms.Where(r => r.TKuanhao.leixing == lx.Value);
                }
                if (!string.IsNullOrEmpty(kh))
                {
                    tms = tms.Where(r => r.TKuanhao.kuanhao == kh);
                }
                if (!string.IsNullOrEmpty(tmh))
                {
                    tms = tms.Where(r => r.tiaoma == tmh);
                }
                if (xgsj_start != null)
                {
                    xgsj_start = xgsj_start.Value.Date;
                    tms = tms.Where(r => r.xiugaishijian >= xgsj_start.Value);
                }
                if (xgsj_end != null)
                {
                    xgsj_end = xgsj_end.Value.Date.AddDays(1);
                    tms = tms.Where(r => r.xiugaishijian < xgsj_end.Value);
                }
                if (userid != null)
                {
                    tms = tms.Where(r => r.caozuorenid == userid.Value);
                }

                recordCount = tms.Count();
                tms = tms.OrderByDescending(r => r.xiugaishijian).Skip(pageSize * pageIndex);

                return tms.ToArray();
            }

            /// <summary>
            /// 根据款号取得所有的条码信息
            /// </summary>
            /// <param name="kh">款号名称</param>
            /// <returns></returns>
            public TTiaoma[] GetTiaomasByKuanhaoMc(string kh)
            {
                var Tiaomas = _db.TTiaomas.Where(r=>r.TKuanhao.kuanhao == kh);

                return Tiaomas.ToArray();
            }

            /// <summary>
            /// 根据条码号取得条码信息
            /// </summary>
            /// <param name="t"></param>
            /// <returns></returns>
            public TTiaoma GetTiaomaByTiaomahao(string t)
            {
                return _db.TTiaomas.SingleOrDefault(r => r.tiaoma == t);
            }
            public TTiaoma[] GetTiaomasByTiaomahaos(string[] tmhs)
            {
                return _db.TTiaomas.Include(r => r.TKuanhao).Include(r => r.TGongyingshang).Where(r => tmhs.Contains(r.tiaoma)).ToArray();
            }


            /// <summary>
            /// 取得账号对应的分店ID
            /// </summary>
            /// <param name="userid"></param>
            /// <returns></returns>
            public TUser_Fendian GetUserFendianByUserid(int userid)
            {
                return _db.TUser_Fendian.Include(r => r.TFendian).Single(r => r.yonghuid == userid);
            }
            public TUser_Cangku GetUserCangkuByUserId(int userid)
            {
                return _db.TUser_Cangku.Include(r => r.TCangku).Single(r => r.yonghuid == userid);
            }

            /// <summary>
            /// 根据手机号取得会员信息
            /// </summary>
            /// <param name="sjh"></param>
            /// <returns></returns>
            public THuiyuan GetHuiyuanByShoujihao(string sjh)
            {
                return _db.THuiyuans.SingleOrDefault(r => r.shoujihao == sjh);
            }
            public THuiyuan GetHuiyuanById(int id)
            {
                return _db.THuiyuans.Single(r => r.id == id);
            }

            /// <summary>
            /// 取会员积分折扣规则
            /// </summary>
            /// <returns></returns>
            public THuiyuanZK[] GetHuiyuanZKs()
            {
                return _db.THuiyuanZKs.ToArray();
            }

            /// <summary>
            /// 按条件查询销售记录
            /// </summary>
            /// <param name="fdid">分店ID</param>
            /// <param name="xsrq_start">销售日期起始</param>
            /// <param name="xsrq_end">销售日期截止</param>
            /// <param name="sbrq_start">数据上报日期开始</param>
            /// <param name="sbrq_end">数据上报日期截止</param>
            /// <param name="pageSize">页大小，如果不想分页，传入null</param>
            /// <param name="pageIndex">取第几页数据，如果不想分页，传入null</param>
            /// <param name="recordCount">符合条件的数据量</param>
            /// <returns></returns>
            public TXiaoshou[] GetXiaoshousByCond(int? fdid, DateTime? xsrq_start, DateTime? xsrq_end, DateTime? sbrq_start, DateTime? sbrq_end, int? pageSize, int? pageIndex,out int recordCount)
            {
                var xss = _db.TXiaoshous.Include(r => r.TTiaoma).Include(r => r.TTiaoma.TKuanhao).
                    Include(r => r.TFendian).Include(r => r.THuiyuan).AsQueryable();
                if (fdid != null)
                {
                    xss = xss.Where(r => r.fendianid == fdid);
                }
                if (xsrq_start != null)
                {
                    xss = xss.Where(r => r.xiaoshoushijian >= xsrq_start);
                }
                if (xsrq_end != null)
                {
                    xsrq_end = xsrq_end.Value.AddDays(1);
                    xss = xss.Where(r => r.xiaoshoushijian <= xsrq_end);
                }
                if (sbrq_start != null)
                {
                    xss = xss.Where(r => r.shangbaoshijian >= sbrq_start);
                }
                if (sbrq_end != null)
                {
                    sbrq_end = sbrq_end.Value.AddDays(1);
                    xss = xss.Where(r => r.shangbaoshijian <= sbrq_end);
                }
                recordCount = xss.Count();
                if (pageSize != null)
                {
                    xss = xss.OrderByDescending(r => r.shangbaoshijian).Skip(pageSize.Value * pageIndex.Value);
                }
                return xss.ToArray();
            }

            /// <summary>
            /// 查询分店进出货数据
            /// </summary>
            /// <param name="fdid"></param>
            /// <param name="fsrq_start"></param>
            /// <param name="fsrq_end"></param>
            /// <param name="sbrq_start"></param>
            /// <param name="sbrq_end"></param>
            /// <param name="pageSize"></param>
            /// <param name="pageIndex"></param>
            /// <param name="recordCount"></param>
            /// <returns></returns>
            public TFendianJinchuhuo[] GetFDJinchuhuoByCond(int? fdid, DateTime? fsrq_start, DateTime? fsrq_end, DateTime? sbrq_start, DateTime? sbrq_end, int pageSize, int pageIndex, out int recordCount)
            {
                var jcs = _db.TFendianJinchuhuos.Include(r => r.TFendian).Include(r => r.TFendianJinchuhuoMXes).AsQueryable();
                if (fdid != null)
                {
                    jcs = jcs.Where(r => r.fendianid == fdid);
                }
                if (fsrq_start != null)
                {
                    jcs = jcs.Where(r => r.fashengshijian >= fsrq_start);
                }
                if (fsrq_end != null)
                {
                    fsrq_end = fsrq_end.Value.AddDays(1);
                    jcs = jcs.Where(r => r.fashengshijian <= fsrq_end);
                }
                if (sbrq_start != null)
                {
                    jcs = jcs.Where(r => r.shangbaoshijian >= sbrq_start);
                }
                if (sbrq_end != null)
                {
                    sbrq_end = sbrq_end.Value.AddDays(1);
                    jcs = jcs.Where(r => r.shangbaoshijian <= sbrq_end);
                }
                recordCount = jcs.Count();
                jcs = jcs.OrderByDescending(r => r.shangbaoshijian).Skip(pageSize * pageIndex);

                return jcs.ToArray();
            }

            /// <summary>
            /// 取得进出货的详细清单
            /// </summary>
            /// <param name="jcid">进出货记录ID</param>
            /// <returns></returns>
            public TFendianJinchuhuoMX[] GetFDJinchuhuoMXsByJcId(int jcid)
            {
                return _db.TFendianJinchuhuoMXes.Include(r => r.TTiaoma).Include(r => r.TTiaoma.TKuanhao).Where(r => r.jinchuhuoid == jcid).ToArray();
            }

            /// <summary>
            /// 取得仓库进出货记录
            /// </summary>
            /// <param name="ckid">仓库ID</param>
            /// <param name="oid">仓库系统的本地ID</param>
            /// <returns></returns>
            public TCangkuJinchuhuo GetCKJinchuhuo(int ckid, int oid)
            {
                return _db.TCangkuJinchuhuos.SingleOrDefault(r => r.cangkuid == ckid && r.oid == oid);
            }
            /// <summary>
            /// 取得仓库发货给某分店的数据
            /// </summary>
            /// <param name="jcid">仓库进出货记录ID</param>
            /// <param name="fdid">分店ID</param>
            /// <returns></returns>
            public TCangkuFahuoFendian GetCangkuFahuoFendian(int jcid, int fdid)
            {
                return _db.TCangkuFahuoFendians.SingleOrDefault(r => r.ckjinchuid == jcid && r.fendianid == fdid);
            }

            /// <summary>
            /// 取得某分店的库存记录
            /// </summary>
            /// <param name="fdid"></param>
            /// <param name="pageSize"></param>
            /// <param name="pageIndex"></param>
            /// <returns></returns>
            public TFendianKucun[] GetFDKucunByCond(int? fdid, int pageSize, int pageIndex, out int recordCount)
            {
                var kcs = _db.TFendianKucuns.Include(r => r.TFendian).Include(r => r.TFendianKucunMXes).Include(r=>r.TFendianKucunMXes.Select(rx=>rx.TTiaoma)).AsQueryable();
                if (fdid != null)
                {
                    kcs = kcs.Where(r => r.fendianid == fdid);
                }

                recordCount = kcs.Count();
                kcs = kcs.OrderByDescending(r => r.shangbaoshijian).Skip(pageSize * pageIndex);

                return kcs.ToArray(); 
            }

            /// <summary>
            /// 取得某库存记录的明细清单
            /// </summary>
            /// <param name="jcid"></param>
            /// <returns></returns>
            public TFendianKucunMX[] GetFDKucunMXsByKcId(int kcid)
            {
                return _db.TFendianKucunMXes.Include(r=>r.TTiaoma).Include(r=>r.TTiaoma.TKuanhao).Where(r => r.kucunid == kcid).ToArray();
            }

            /// <summary>
            /// 取得某个分店的进货数据
            /// </summary>
            /// <param name="fdid"></param>v
            /// <returns></returns>
            public TCangkuFahuoFendian[] GetFDJinhuoshuju(int fdid)
            {
                return _db.TCangkuFahuoFendians.Include(r=>r.TCangkuJinchuhuo).Include(r=>r.TCangkuJinchuhuo.TCangkuJinchuhuoMXes).
                    Where(r => r.fendianid == fdid && r.xzshijian == null).ToArray();
            }
        }
 
}