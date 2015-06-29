using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_JCSJ
{
        public partial class DBContext
        {
            private JCSJEntities _db;
            public DBContext()
            {
                _db = new JCSJEntities();
                //此项会引起entity无法序列化的错误
                _db.Configuration.ProxyCreationEnabled = false;
            }

            /// <summary>
            /// 登陆验证
            /// </summary>
            /// <param name="dlm">用户名</param>
            /// <param name="mmd5">md5加密后的密码</param>
            /// <returns></returns>
            public TUser GetUser(string dlm, string mmd5)
            {
                return _db.TUser.SingleOrDefault(r => r.dengluming == dlm && r.mima == mmd5);
            }
            /// <summary>
            /// 根据登陆名取得用户
            /// </summary>
            /// <param name="dlm"></param>
            /// <returns></returns>
            public TUser GetUserByDlm(string dlm)
            {
                return _db.TUser.SingleOrDefault(r => r.dengluming == dlm);
            }

            /// <summary>
            /// 取得所有系统用户
            /// </summary>
            /// <param name="ExeptAdmin">是否包含系统管理员</param>
            /// <returns></returns>
            public TUser[] GetUsersExcept(byte js)
            {
                var Users = _db.TUser.Where(r => r.juese != js);

                return Users.ToArray();
            }

            /// <summary>
            /// 取得所有分店信息
            /// </summary>
            /// <returns></returns>
            public TFendian[] GetFendians()
            {
                var Fendians = _db.TFendian.Include("TUser");

                return Fendians.ToArray();
            }
            public TFendian GetFendianByIdMc(int id, string mc)
            {
                return _db.TFendian.SingleOrDefault(r => r.id == id && r.dianming == mc);
            }
            public TFendian GetFendianById(int id)
            {
                return _db.TFendian.SingleOrDefault(r => r.id == id);
            }

            /// <summary>
            /// 取得所有仓库信息
            /// </summary>
            /// <returns></returns>
            public TCangku[] GetCangkus()
            {
                var Cangkus = _db.TCangku.Include("TUser");

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
                return _db.TCangku.SingleOrDefault(r => r.id == id && r.mingcheng == mc);
            }
            public TCangku GetCangkuById(int id)
            {
                return _db.TCangku.SingleOrDefault(r => r.id == id);
            }

            /// <summary>
            /// 取得所有会员信息
            /// </summary>
            /// <returns></returns>
            public THuiyuan[] GetHuiyuans()
            {
                var Huiyuans = _db.THuiyuan.Include("Tuser").Include("TFendian");

                return Huiyuans.ToArray();
            }

            /// <summary>
            /// 取得所有供应商信息
            /// </summary>
            /// <returns></returns>
            public TGongyingshang[] GetGongyingshangs()
            {
                var Gongys = _db.TGongyingshang.Include("TUser");

                return Gongys.ToArray();
            }
            /// <summary>
            /// 取得某个用户编辑的所有供应商信息
            /// </summary>
            /// <returns></returns>
            public TGongyingshang[] GetGongyingshangsByUserId(int UserId)
            {
                var Gongys = _db.TGongyingshang.Where(r => r.caozuorenid == UserId);

                return Gongys.ToArray();
            }
            public TGongyingshang GetGongyingshangById(int id)
            {
                return _db.TGongyingshang.SingleOrDefault(r => r.id == id);
            }

            /// <summary>
            /// 取得所有款号信息
            /// </summary>
            /// <returns></returns>
            public TKuanhao[] GetKuanhaosByCond(byte? lx, string kh, string pm, int pageSize, int pageIndex, out int recordCount)
            {
                var Kuanhaos = _db.TKuanhao.Include("TUser").AsQueryable();
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
                return _db.TKuanhao.SingleOrDefault(r => r.kuanhao == kh);
            }
            public TKuanhao GetKuanhaoById(int id)
            {
                return _db.TKuanhao.SingleOrDefault(r => r.id == id);
            }

            /// <summary>
            /// 取得某个用户编辑的所有款号信息
            /// </summary>
            /// <param name="UserId"></param>
            /// <returns></returns>
            public TKuanhao[] GetKuanhaosByUserId(int UserId)
            {
                var ks = _db.TKuanhao.Where(r => r.caozuorenid == UserId);

                return ks.ToArray();
            }

            /// <summary>
            /// 取得指定个数的条码信息
            /// </summary>
            /// <returns></returns>
            public TTiaoma[] GetTiaomasByCond(int? userid,byte? lx, string kh, string tmh,DateTime? xgsj_start,DateTime? xgsj_end, int pageSize, int pageIndex, out int recordCount)
            {
                var tms = _db.TTiaoma.Include("TUser").Include("TKuanhao").AsQueryable();
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
                var Tiaomas = _db.TTiaoma.Where(r=>r.TKuanhao.kuanhao == kh);

                return Tiaomas.ToArray();
            }

            /// <summary>
            /// 根据条码号取得条码信息
            /// </summary>
            /// <param name="t"></param>
            /// <returns></returns>
            public TTiaoma GetTiaomaByTiaomahao(string t)
            {
                return _db.TTiaoma.SingleOrDefault(r => r.tiaoma == t);
            }
            public TTiaoma[] GetTiaomasByTiaomahaos(string[] tmhs)
            {
                return _db.TTiaoma.Include("TKuanhao").Where(r => tmhs.Contains(r.tiaoma)).ToArray();
            }


            /// <summary>
            /// 取得账号对应的分店ID
            /// </summary>
            /// <param name="userid"></param>
            /// <returns></returns>
            public TUser_Fendian GetUserFendianByUserid(int userid)
            {
                return _db.TUser_Fendian.Include("TFendian").Single(r => r.yonghuid == userid);
            }
            public TUser_Cangku GetUserCangkuByUserId(int userid)
            {
                return _db.TUser_Cangku.Include("TCangku").Single(r => r.yonghuid == userid);
            }

            /// <summary>
            /// 根据手机号取得会员信息
            /// </summary>
            /// <param name="sjh"></param>
            /// <returns></returns>
            public THuiyuan GetHuiyuanByShoujihao(string sjh)
            {
                return _db.THuiyuan.SingleOrDefault(r => r.shoujihao == sjh);
            }
            public THuiyuan GetHuiyuanById(int id)
            {
                return _db.THuiyuan.Single(r => r.id == id);
            }

            /// <summary>
            /// 取会员积分折扣规则
            /// </summary>
            /// <returns></returns>
            public THuiyuanZK[] GetHuiyuanZKs()
            {
                return _db.THuiyuanZK.ToArray();
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
                var xss = _db.TXiaoshou.Include("TTiaoma").Include("TTiaoma.TKuanhao").
                    Include("TFendian").Include("THuiyuan").AsQueryable();
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
                var jcs = _db.TFendianJinchuhuo.Include("TFendian").Include("TFendianJinchuhuoMX").AsQueryable();
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
                return _db.TFendianJinchuhuoMX.Include("TTiaoma").Include("TTiaoma.TKuanhao").Where(r => r.jinchuhuoid == jcid).ToArray();
            }

            /// <summary>
            /// 取得仓库进出货记录
            /// </summary>
            /// <param name="ckid">仓库ID</param>
            /// <param name="oid">仓库系统的本地ID</param>
            /// <returns></returns>
            public TCangkuJinchuhuo GetCKJinchuhuo(int ckid, int oid)
            {
                return _db.TCangkuJinchuhuo.SingleOrDefault(r => r.cangkuid == ckid && r.oid == oid);
            }
            /// <summary>
            /// 取得仓库发货给某分店的数据
            /// </summary>
            /// <param name="jcid">仓库进出货记录ID</param>
            /// <param name="fdid">分店ID</param>
            /// <returns></returns>
            public TCangkuFahuoFendian GetCangkuFahuoFendian(int jcid, int fdid)
            {
                return _db.TCangkuFahuoFendian.SingleOrDefault(r => r.ckjinchuid == jcid && r.fendianid == fdid);
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
                var kcs = _db.TFendianKucun.Include("TFendian").Include("TFendianKucunMX").Include("TFendianKucunMX.TTiaoma").AsQueryable();
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
                return _db.TFendianKucunMX.Include("TTiaoma").Include("TTiaoma.TKuanhao").Where(r => r.kucunid == kcid).ToArray();
            }

            /// <summary>
            /// 取得某个分店的进货数据
            /// </summary>
            /// <param name="fdid"></param>
            /// <returns></returns>
            public TCangkuFahuoFendian[] GetFDJinhuoshuju(int fdid)
            {
                return _db.TCangkuFahuoFendian.Include("TCangkuJinchuhuo").Include("TCangkuJinchuhuo.TCangkuJinchuhuoMX").
                    Where(r => r.fendianid == fdid && r.xzshijian == null).ToArray();
            }
        }
 
}