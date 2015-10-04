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
                return _db.TUsers.Include(r=>r.TJiamengshang).SingleOrDefault(r => r.dengluming == dlm && r.mima == mmd5);
            }
            /// <summary>
            /// 根据登陆名取得用户
            /// </summary>
            /// <param name="dlm"></param>
            /// <returns></returns>
            public TUser GetUserById(int id)
            {
                return _db.TUsers.SingleOrDefault(r => r.id == id);
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
            public TUser[] GetUsers(int? jmsid)
            {
                var us = _db.TUsers.Include(r => r.TJiamengshang).AsQueryable();
                if (jmsid != null)
                {
                    us = us.Where(r => r.jmsid == jmsid);
                }
                return us.OrderBy(r => r.jmsid).ToArray();
            }
            public int GetUserCount(int jmsid)
            {
                return _db.TUsers.Where(r => r.jmsid == jmsid).Count();
            }

            /// <summary>
            /// 取得分店一览信息
            /// </summary>
            /// <returns></returns>
            public TFendian[] GetFendians(int? jmsid)
            {
                var fs = _db.TFendians.Include(r => r.Jms).Include(r=>r.Pinpai).AsQueryable();
                if(jmsid !=null)
                {
                    fs = fs.Where(r=>r.jmsid == jmsid);
                }
                return fs.OrderBy(r => r.jmsid).ToArray();
            }
            public TFendian[] GetFendians(int[] ppids, int jmsid)
            {
                var fs = _db.TFendians.Include(r => r.Jms).Include(r => r.Pinpai).Where(r=>r.jmsid == jmsid).AsQueryable();
                if (ppids.Length != 0)
                {
                    fs = fs.Where(r => ppids.Contains(r.ppid));
                }
                return fs.OrderBy(r => r.jmsid).ToArray();
            }
            
            /// <summary>
            /// 取得分店信息，作为查询下拉框
            /// </summary>
            /// <param name="jmsid">分店所属的加盟商ID</param>
            /// <returns></returns>
            public TFendian[] GetFendiansAsItems(int? jmsid)
            {
                var fs = _db.TFendians.AsQueryable();
                if (jmsid != null)
                {
                    fs = fs.Where(r => r.jmsid == jmsid);
                }
                return fs.OrderBy(r => r.jmsid).ToArray();
            }
            /// <summary>
            /// 取得某个品牌的加盟分店（不含该品牌的直营店）
            /// </summary>
            /// <param name="ppid"></param>
            /// <returns></returns>
            public TFendian[] GetFendiansOfPinpaiAsItems(int ppid)
            {
                var fs = _db.TFendians.Where(r => r.jmsid != ppid && r.ppid == ppid);

                return fs.OrderBy(r => r.jmsid).ToArray();
            }
            public TFendian GetFendianByIdMc(int id, string mc)
            {
                return _db.TFendians.SingleOrDefault(r => r.id == id && r.dianming == mc);
            }
            public TFendian GetFendianById(int id)
            {
                return _db.TFendians.Include(r=>r.Jms).Single(r => r.id == id);
            }
            public int GetFendianCount(int jmsid)
            {
                return _db.TFendians.Where(r => r.jmsid == jmsid).Count();
            }

            /// <summary>
            /// 取得所有仓库信息
            /// </summary>
            /// <returns></returns>
            public TCangku[] GetCangkus(int? jmsid)
            {
                var cks = _db.TCangkus.Include(r => r.TJiamengshang).AsQueryable();
                if(jmsid != null)
                {
                    cks = cks.Where(r=>r.jmsid == jmsid);
                }

                return cks.OrderBy(r => r.jmsid).ToArray();
            }
            public TCangku[] GetCangkusAsItems(int? jmsid)
            {
                var cs = _db.TCangkus.AsQueryable();
                if (jmsid != null)
                {
                    cs = cs.Where(r => r.jmsid == jmsid);
                }

                return cs.OrderBy(r => r.jmsid).ToArray();
            }
            public int GetCangkusCount(int? jmsid)
            {
                return _db.TCangkus.Where(r => r.jmsid == jmsid).Count();
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
                return _db.TCangkus.Include(r=>r.TJiamengshang).Single(r => r.id == id);
            }

            /// <summary>
            /// 取得所有会员信息
            /// </summary>
            /// <returns></returns>
            public THuiyuan[] GetHuiyuans(int? jmsid)
            {
                var hs = _db.THuiyuans.Include(r=>r.TFendian).Include(r=>r.TJiamengshang).AsQueryable();
                if(jmsid != null)
                {
                    hs = hs.Where(r=>r.jmsid == jmsid);
                }

                return hs.OrderBy(r => r.jmsid).ToArray();
            }

            /// <summary>
            /// 取得所有供应商信息
            /// </summary>
            /// <returns></returns>
            public TGongyingshang[] GetGongyingshangs(int? jmsid)
            {
                var gs = _db.TGongyingshangs.Include(r => r.TJiamengshang).AsQueryable();
                if(jmsid != null)
                {
                    gs = gs.Where(r=>r.jmsid == jmsid);
                }
                return gs.OrderBy(r=>r.jmsid).ToArray();
            }
            public TGongyingshang[] GetGongyingshangsAsItems(int jmsid)
            {
                var gs = _db.TGongyingshangs.Where(r => r.jmsid == jmsid).AsQueryable();
                
                return gs.OrderBy(r => r.jmsid).ToArray();
            }
            public int GetGongyingshangCount(int? jmsid)
            {
                return _db.TGongyingshangs.Where(r => r.jmsid == jmsid).Count();
            }
            public TGongyingshang GetGongyingshangById(int id)
            {
                return _db.TGongyingshangs.SingleOrDefault(r => r.id == id);
            }

            /// <summary>
            /// 取得所有款号信息
            /// </summary>
            /// <returns></returns>
            public TKuanhao[] GetKuanhaosByCond(int? jmsid,byte? lx, string kh, string pm, int pageSize, int pageIndex, out int recordCount)
            {
                var Kuanhaos = _db.TKuanhaos.Include(r=>r.TJiamengshang).AsQueryable();
                if (jmsid != null)
                {
                    Kuanhaos = Kuanhaos.Where(r => r.jmsid == jmsid.Value);
                }
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
                Kuanhaos = Kuanhaos.OrderByDescending(r => r.xiugaishijian).Skip(pageSize * pageIndex).Take(pageSize);

                return Kuanhaos.ToArray();
            }

            /// <summary>
            /// 根据款号名称取得款号信息
            /// </summary>
            /// <param name="kh"></param>
            /// <returns></returns>
            public TKuanhao[] GetKuanhaosByMcJmsId(string[] khs,int jmsid)
            {
                return _db.TKuanhaos.Where(r => khs.Contains(r.kuanhao) && r.jmsid == jmsid).ToArray();
            }
            /// <summary>
            /// 检查给定的款号名称中，有多少是已经存在的
            /// </summary>
            /// <param name="khs"></param>
            /// <param name="jmsid"></param>
            /// <returns></returns>
            public string[] GetKuanhaoExistByMcWithJmsId(int jmsid,string[] khs)
            {
                return _db.TKuanhaos.Where(r => khs.Contains(r.kuanhao) && r.jmsid == jmsid).Select(r => r.kuanhao).ToArray();
            }
            public TKuanhao GetKuanhaoById(int id)
            {
                var k = _db.TKuanhaos.Single(r => r.id == id);
                return k;
            }
            //public TKuanhao[] GetKuanhaos(int jmsid)
            //{
            //    return _db.TKuanhaos.Where(r => r.jmsid == jmsid).ToArray();
            //}
            public int GetKuanhaoCount(int jmsid)
            {
                return _db.TKuanhaos.Where(r => r.jmsid == jmsid).Count();
            }

            /// <summary>
            /// 取得指定个数的条码信息
            /// </summary>
            /// <returns></returns>
            public TTiaoma[] GetTiaomasByCond(int? jmsid,byte? lx, string kh, string tmh,DateTime? xgsj_start,DateTime? xgsj_end, int pageSize, int pageIndex, out int recordCount)
            {
                var tms = _db.TTiaomas.Include(r => r.TJiamengshang).Include(r => r.TKuanhao).Include(r => r.TGongyingshang).AsQueryable();

                if (lx != null)
                {
                    tms = tms.Where(r => r.TKuanhao.leixing == lx.Value);
                }
                if (!string.IsNullOrEmpty(kh))
                {
                    tms = tms.Where(r => r.TKuanhao.kuanhao == kh || r.gyskuanhao == kh);
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
                if (jmsid != null)
                {
                    tms = tms.Where(r => r.jmsid == jmsid.Value);
                }

                recordCount = tms.Count();
                tms = tms.OrderByDescending(r => r.xiugaishijian).Skip(pageSize * pageIndex).Take(pageSize);

                return tms.ToArray();
            }

            public TTiaoma[] GetTiaomasByTiaomahaosWithJmsId(string[] tmhs, int jmsid)
            {
                var tms = _db.TTiaomas.Include(r=>r.TKuanhao).Include(r=>r.TGongyingshang).Where(r => tmhs.Contains(r.tiaoma) && r.jmsid == jmsid);

                return tms.ToArray();
            }
            public TTiaoma GetTiaomaByTiaomahaoWithJmsId(string tmh, int jmsid)
            {
                return _db.TTiaomas.SingleOrDefault(r => r.tiaoma == tmh && r.jmsid == jmsid);
            }
            //public TTiaoma[] GetTiaomasByTiaomahaos(string[] tmhs)
            //{
            //    return _db.TTiaomas.Where(r => tmhs.Contains(r.tiaoma)).ToArray();
            //} 
            public TTiaoma GetTiaomaById(int id)
            {
                return _db.TTiaomas.Include(r=>r.TKuanhao).Single(r => r.id == id);
            }
            public int GetTiaomaCount(int jmsid)
            {
                return _db.TTiaomas.Where(r => r.jmsid == jmsid).Count();
            }



            /// <summary>
            /// 取得账号对应的分店ID
            /// </summary>
            /// <param name="userid"></param>
            /// <returns></returns>
            //public TUser_Fendian GetUserFendianByUserid(int userid)
            //{
            //    return _db.TUser_Fendian.Include(r => r.TFendian).Single(r => r.yonghuid == userid);
            //}
            //public TUser_Cangku GetUserCangkuByUserId(int userid)
            //{
            //    return _db.TUser_Cangku.Include(r => r.TCangku).Single(r => r.yonghuid == userid);
            //}

            /// <summary>
            /// 根据手机号取得会员信息
            /// </summary>
            /// <param name="sjh"></param>
            /// <returns></returns>
            public THuiyuan GetHuiyuanByShoujihaoWithJmsId(string sjh,int jmsid)
            {
                return _db.THuiyuans.SingleOrDefault(r => r.shoujihao == sjh && r.jmsid == jmsid);
            }
            public THuiyuan GetHuiyuanById(int id)
            {
                return _db.THuiyuans.Include(r=>r.TFendian).Single(r => r.id == id);
            }
            public int GetHuiyuanCount(int jmsid)
            {
                return _db.THuiyuans.Where(r => r.jmsid == jmsid).Count();
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
            /// 按条件查询销售记录，包括自己的直营分店和加盟商的分店
            /// 产生的销售记录
            /// </summary>
            /// <param name="ppids">每个用户只能查询属于自己的品牌和加盟品牌的销售数据</param>
            /// <param name="jmsid">子加盟商ID，销售数据的分店必须属于该加盟商ID</param>
            /// <param name="fdid">分店ID</param>
            /// <param name="xsrq_start">销售日期起始</param>
            /// <param name="xsrq_end">销售日期截止</param>
            /// <param name="sbrq_start">数据上报日期开始</param>
            /// <param name="sbrq_end">数据上报日期截止</param>
            /// <param name="pageSize">页大小，如果不想分页，传入null</param>
            /// <param name="pageIndex">取第几页数据，如果不想分页，传入null</param>
            /// <param name="recordCount">符合条件的数据量</param>
            /// <returns></returns>
            public TXiaoshou[] GetXiaoshousByCond(int[] ppids,int[] jmsids, int? fdid,string kh,string tm, DateTime? xsrq_start, DateTime? xsrq_end, DateTime? sbrq_start, DateTime? sbrq_end, int? pageSize, int? pageIndex, out int recordCount)
            {
                var xss = _db.TXiaoshous.Include(r => r.TTiaoma).Include(r => r.TTiaoma.TKuanhao).
                    Include(r => r.TFendian).Include(r => r.THuiyuan).Include(r=>r.TFendian.Jms).AsQueryable();
                if (ppids.Length != 0)
                {
                    xss = xss.Where(r => ppids.Contains(r.TFendian.ppid));
                }
                if (jmsids.Length != 0)
                {
                    xss = xss.Where(r => jmsids.Contains(r.TFendian.jmsid));
                }
                if (fdid != null)
                {
                    xss = xss.Where(r => r.fendianid == fdid);
                }
                if (!string.IsNullOrEmpty(kh))
                {
                    xss = xss.Where(r => r.TTiaoma.TKuanhao.kuanhao == kh);
                }
                if (!string.IsNullOrEmpty(tm))
                {
                    xss = xss.Where(r => r.TTiaoma.tiaoma == tm);
                }
                if (xsrq_start != null)
                {
                    xss = xss.Where(r => r.xiaoshoushijian >= xsrq_start);
                }
                if (xsrq_end != null)
                {
                    xss = xss.Where(r => r.xiaoshoushijian < xsrq_end);
                }
                if (sbrq_start != null)
                {
                    xss = xss.Where(r => r.shangbaoshijian >= sbrq_start);
                }
                if (sbrq_end != null)
                {
                    xss = xss.Where(r => r.shangbaoshijian < sbrq_end);
                }
                recordCount = xss.Count();
                if (pageSize != null)
                {
                    xss = xss.OrderByDescending(r => r.shangbaoshijian).Skip(pageSize.Value * pageIndex.Value).Take(pageSize.Value);
                }

                return xss.ToArray();
            }
            public int GetXiaoshouCount(int jmsid)
            {
                return _db.TXiaoshous.Where(r => r.TFendian.jmsid == jmsid).Count();
            }
            public TXiaoshou GetXiaoshouByFdidOid(int fdid, int oid)
            {
                return _db.TXiaoshous.Single(r => r.fendianid == fdid && r.oid == oid);
            }
            /// <summary>
            /// 查询我自己的款号的销售数据
            /// </summary>
            /// <param name="jmsid"></param>
            /// <returns></returns>
            //public TXiaoshou[] GetXiaoshousOfMyKhs(int jmsid,DateTime? xsrq_start,DateTime? xsrq_end)
            //{
            //    var xss = _db.TXiaoshous.Include(r=>r.TTiaoma).Include(r=>r.TTiaoma.TKuanhao).Where(r => r.TTiaoma.TKuanhao.jmsid == jmsid).AsQueryable();
            //    if (xsrq_start != null)
            //    {
            //        xss = xss.Where(r => r.xiaoshoushijian >= xsrq_start.Value);
            //    }
            //    if (xsrq_end != null)
            //    {
            //        xss = xss.Where(r => r.xiaoshoushijian < xsrq_end.Value);
            //    }

            //    return xss.ToArray();
            //}
            
            /// <summary>
            /// 查询我加盟的款号的销售数据
            /// </summary>
            /// <param name="dlsids">有可能加盟了多个品牌</param>
            /// <param name="xsrq_start">销售起始日期</param>
            /// <param name="xsrq_end">截止日期</param>
            /// <returns></returns>
            //public TXiaoshou[] GetXiaoshousOfJmKhs(int[] dlsids,int jmsid, DateTime? xsrq_start, DateTime? xsrq_end)
            //{
            //    var xss = _db.TXiaoshous.Include(r => r.TTiaoma).Include(r => r.TTiaoma.TKuanhao).
            //        Where(r => dlsids.Contains(r.TTiaoma.TKuanhao.jmsid) && r.TFendian.jmsid == jmsid).AsQueryable();
            //    if (xsrq_start != null)
            //    {
            //        xss = xss.Where(r => r.xiaoshoushijian >= xsrq_start.Value);
            //    }
            //    if (xsrq_end != null)
            //    {
            //        xss = xss.Where(r => r.xiaoshoushijian < xsrq_end.Value);
            //    }

            //    return xss.ToArray();
            //}

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
            public TFendianJinchuhuo[] GetFDJinchuhuoByCond(int?jmsid,int? fdid, DateTime? fssj_start, DateTime? fssj_end, DateTime? sbsj_start, DateTime? sbsj_end, int pageSize, int pageIndex, out int recordCount)
            {
                var jcs = _db.TFendianJinchuhuos.Include(r => r.TFendian).Include(r => r.TFendianJinchuhuoMXes).
                    Include(r=>r.TFendian.Jms).AsQueryable();
                if (jmsid != null)
                {
                    jcs = jcs.Where(r => r.TFendian.jmsid == jmsid);
                }
                if (fdid != null)
                {
                    jcs = jcs.Where(r => r.fendianid == fdid);
                }
                if (fssj_start != null)
                {
                    jcs = jcs.Where(r => r.fashengshijian >= fssj_start);
                }
                if (fssj_end != null)
                {
                    jcs = jcs.Where(r => r.fashengshijian < fssj_end);
                }
                if (sbsj_start != null)
                {
                    jcs = jcs.Where(r => r.shangbaoshijian >= sbsj_start);
                }
                if (sbsj_end != null)
                {
                    jcs = jcs.Where(r => r.shangbaoshijian < sbsj_end);
                }
                recordCount = jcs.Count();
                jcs = jcs.OrderByDescending(r => r.shangbaoshijian).Skip(pageSize * pageIndex).Take(pageSize);

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
            public TFendianJinchuhuo GetFDJinchuhuoByJcId(int id)
            {
                return _db.TFendianJinchuhuos.Include(r=>r.TFendian).Single(r => r.id == id);
            }
            public TFendianJinchuhuo GetFDJinchuhuoByFdidOid(int fdid,int oid)
            {
                return _db.TFendianJinchuhuos.Single(r => r.fendianid == fdid && r.oid == oid);
            }

            /// <summary>
            /// 取得仓库进出货记录
            /// </summary>
            /// <param name="ckid">仓库ID</param>
            /// <param name="oid">仓库系统的本地ID</param>
            /// <returns></returns>
            public TCangkuJinchuhuo GetCKJinchuhuo(int ckid, int oid)
            {
                return _db.TCangkuJinchuhuos.SingleOrDefault(r => r.ckid == ckid && r.oid == oid);
            }
            public TCangkuJinchuhuo GetCKJinchuhuoById(int id)
            {
                return _db.TCangkuJinchuhuos.Include(r=>r.TCangku).Single(r => r.id == id);
            }
            public TCangkuJinchuhuoMX[] GetCKJinchuhuoMXsByJcId(int jcid)
            {
                return _db.TCangkuJinchuhuoMXes.Include(r => r.TTiaoma).Include(r => r.TTiaoma.TKuanhao).Where(r => r.jinchuhuoid == jcid).ToArray();
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
            public TCangkuFahuoFendian GetCangkuFahuoFendianByJcId(int jcid)
            {
                return _db.TCangkuFahuoFendians.SingleOrDefault(r => r.ckjinchuid == jcid);
            }

            /// <summary>
            /// 取得某分店的库存记录
            /// </summary>
            /// <param name="fdid"></param>
            /// <param name="pageSize"></param>
            /// <param name="pageIndex"></param>
            /// <returns></returns>
            public TFendianKucun[] GetFDKucunByCond(int[] ppids,int[] jmsids,int? fdid,bool latest)
            {
                var kcs = _db.TFendianKucuns.AsQueryable();
                if (ppids.Length != 0)
                {
                    kcs = kcs.Where(r => ppids.Contains(r.TFendian.ppid));
                }
                if (fdid != null)
                {
                    kcs = kcs.Where(r => r.fendianid == fdid);
                }
                if (jmsids.Length != 0)
                {
                    kcs = kcs.Where(r => jmsids.Contains(r.TFendian.jmsid));
                }
                //只取每个分店最新提交的库存记录
                if (latest)
                {
                    kcs = kcs.GroupBy(r => r.fendianid).Select(r => r.OrderByDescending(g => g.shangbaoshijian).FirstOrDefault());
                }

                kcs = kcs.Include(r => r.TFendian).Include(r => r.TFendianKucunMXes).Include(r=>r.TFendian.Jms).
                    Include(r => r.TFendianKucunMXes.Select(rx => rx.TTiaoma)).OrderByDescending(r => r.shangbaoshijian);

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
            public TFendianKucun GetFDKucunById(int id)
            {
                return _db.TFendianKucuns.Include(r=>r.TFendian).Single(r => r.id == id);
            }

            /// <summary>
            /// 取得某个分店的进货数据
            /// </summary>
            /// <param name="fdid"></param>v
            /// <returns></returns>
            public TCangkuFahuoFendian[] GetFDJinhuoshuju(int fdid)
            {
                return _db.TCangkuFahuoFendians.Include(r=>r.TCangkuJinchuhuo).Include(r=>r.TCangkuJinchuhuo.TCangkuJinchuhuoMXes).
                    Include(r=>r.TCangkuJinchuhuo.TCangkuJinchuhuoMXes.Select(xr=>xr.TTiaoma)).
                    Where(r => r.fendianid == fdid && r.xzshijian == null).ToArray();
            }
            /// <summary>
            /// 取所有加盟商信息
            /// </summary>
            /// <returns></returns>
            public TJiamengshang[] GetJiamengshangs()
            {
                return _db.TJiamengshangs.ToArray();
            }
            /// <summary>
            /// 取所有顶级加盟商
            /// </summary>
            /// <returns></returns>
            public TJiamengshang[] GetJiamengshangsOfDingji()
            {
                return _db.TJiamengshangs.Where(r => r.fjmsshu == 0).ToArray();
            }
            /// <summary>
            /// 取得一组款号的加盟商ID
            /// </summary>
            /// <param name="khids"></param>
            /// <returns></returns>
            public int[] GetJiamengshangIdsByKhIds(int[] khids)
            {
                return _db.TKuanhaos.Where(r => khids.Contains(r.id)).Select(r => r.jmsid).Distinct().ToArray();
            }
            public TJiamengshang GetJiamengshangById(int id)
            {
                return _db.TJiamengshangs.Single(r => r.id == id);
            }
            public short[] GetJiamengshangDaimas()
            {
                return _db.TJiamengshangs.Select(r => r.daima).ToArray();
            }
            /// <summary>
            /// 取某个加盟商所加盟的所有代理商信息
            /// </summary>
            /// <param name="jmsid"></param>
            /// <returns></returns>
            public TJiamengshang[] GetFuJiamengshangs(int jmsid)
            {
                return _db.TJiamengshangGXes.Where(r => r.jmsid == jmsid).Select(r=>r.Dls).ToArray();
            }
            public TJiamengshangGX[] GetFuJiamengshangGXes(int jmsid)
            {
                return _db.TJiamengshangGXes.Where(r => r.jmsid == jmsid).Include(r => r.Dls).Include(r=>r.Dls).ToArray();
            }
            /// <summary>
            /// 取得某个加盟商的所有下属加盟商信息
            /// </summary>
            /// <param name="jmsid"></param>
            /// <returns></returns>
            public TJiamengshang[] GetZiJiamengshangs(int jmsid)
            {
                return _db.TJiamengshangGXes.Where(r => r.dlsid == jmsid).Select(r=>r.Jms).ToArray();
            }
            public TJiamengshangGX[] GetZiJiamengshangGXes(int jmsid)
            {
                return _db.TJiamengshangGXes.Include(r=>r.Jms).Where(r => r.dlsid == jmsid).ToArray();
            }

            /// <summary>
            /// 查询某个加盟商的向上级申请加盟记录
            /// </summary>
            /// <param name="jmsid"></param>
            /// <returns></returns>
            public TJiamengshangGXSQ[] GetMySjSQ(int jmsid)
            {
                return _db.TJiamengshangGXSQs.Include(r=>r.Dls).Include(r=>r.Jms).Where(r => r.jmsid == jmsid).ToArray();
            }
            public TJiamengshangGXSQ GetJiamengGXSQById(int id)
            {
                return _db.TJiamengshangGXSQs.Include(r=>r.Jms).Single(r => r.id == id);
            }
            public TJiamengshangGX GetJiamengGXById(int id)
            {
                return _db.TJiamengshangGXes.Single(r => r.id == id);
            }
            public TJiamengshangGXSQ[] GetMyXjSQ(int jmsid)
            {
                return _db.TJiamengshangGXSQs.Include(r => r.Jms).Include(r => r.Dls).Where(r => r.dlsid == jmsid).ToArray();
            }
            /// <summary>
            /// 计算某个加盟商的分店库存详细记录的数量
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public int GetFDKucunCount(int jmsid)
            {
                return _db.TFendianKucunMXes.Where(r => r.TFendianKucun.TFendian.jmsid == jmsid).Count();
            }
            public int GetCKKucunCount(int jmsid)
            {
                return _db.TCangkuKucunMXes.Where(r => r.TCangkuKucun.TCangku.jmsid == jmsid).Count();
            }

            /// <summary>
            /// 计算某个加盟商的进出货明细记录的数量
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public int GetFDJinchuhuoCount(int jmsid)
            {
                return _db.TFendianJinchuhuoMXes.Where(r => r.TFendianJinchuhuo.TFendian.jmsid == jmsid).Count();
            }
            public int GetCKJinchuhuoCount(int jmsid)
            {
                return _db.TCangkuJinchuhuoMXes.Where(r => r.TCangkuJinchuhuo.TCangku.jmsid == jmsid).Count();
            }
            public TCangkuJinchuhuo[] GetCKJinchuhuoByCond(int? jmsid,int? ckid,DateTime? fssj_start,DateTime? fssj_end,DateTime? sbsj_start,DateTime? sbsj_end, int pageSize, int pageIndex, out int recordCount)
            {
                var jcs = _db.TCangkuJinchuhuos.Include(r => r.TCangku).Include(r => r.TCangku.TJiamengshang).
                    Include(r => r.TCangkuJinchuhuoMXes).AsQueryable();
                if (jmsid != null)
                {
                    jcs = jcs.Where(r => r.TCangku.jmsid == jmsid);
                }
                if (ckid != null)
                {
                    jcs = jcs.Where(r => r.ckid == ckid);
                }
                if (fssj_start != null)
                {
                    jcs = jcs.Where(r => r.fashengshijian >= fssj_start);
                }
                if (fssj_end != null)
                {
                    jcs = jcs.Where(r => r.fashengshijian < fssj_end);
                }
                if (sbsj_start != null)
                {
                    jcs = jcs.Where(r => r.shangbaoshijian >= sbsj_start);
                }
                if (sbsj_end != null)
                {
                    jcs = jcs.Where(r => r.shangbaoshijian < sbsj_end);
                }
                recordCount = jcs.Count();
                jcs = jcs.OrderByDescending(r => r.shangbaoshijian).Skip(pageSize * pageIndex).Take(pageSize);

                return jcs.ToArray();
            }
            public TCangkuKucun[] GetCKKucunByCond(int? jmsid, int? ckid, bool latest)
            {
                var kcs = _db.TCangkuKucuns.AsQueryable();
                if (ckid != null)
                {
                    kcs = kcs.Where(r => r.cangkuid == ckid);
                }
                if (jmsid != null)
                {
                    kcs = kcs.Where(r => r.TCangku.jmsid == jmsid);
                }
                //是否取最新的库存记录
                if (latest)
                {
                    kcs = kcs.GroupBy(r => r.cangkuid).Select(r => r.OrderByDescending(g => g.shangbaoshijian).FirstOrDefault());
                }

                kcs = kcs.Include(r => r.TCangku).Include(r=>r.TCangku.TJiamengshang).Include(r => r.TCangkuKucunMXes).
                    Include(r => r.TCangkuKucunMXes.Select(rx => rx.TTiaoma)).OrderByDescending(r => r.shangbaoshijian);

                return kcs.ToArray();
            }
            public TCangkuKucun GetCKKucunById(int id)
            {
                return _db.TCangkuKucuns.Include(r => r.TCangku).Single(r => r.id == id);
            }
            public TCangkuKucunMX[] GetCKKucunMXByKcId(int kcid)
            {
                return _db.TCangkuKucunMXes.Include(r => r.TTiaoma).Include(r => r.TTiaoma.TKuanhao).Where(r => r.kucunid == kcid).ToArray();
            }

            /// <summary>
            /// 取得指定地区的子地区
            /// </summary>
            /// <param name="fid"></param>
            /// <returns></returns>
            public TDiqu[] GetDiqusByFid(int? fid)
            {
                return _db.TDiqus.Where(r => r.fid == fid).ToArray();
            }
            public TDiqu GetDiquById(int id)
            {
                return _db.TDiqus.Single(r => r.id == id);
            }
            public VDiqu[] GetAllDiqus()
            {
                return _db.VDiqus.ToArray();
            }

            /// <summary>
            /// 检查某个加盟申请是否已经存在
            /// </summary>
            /// <param name="dlsid"></param>
            /// <param name="jmsid"></param>
            /// <returns></returns>
            public TJiamengshangGXSQ GetJiamengGXSQByDlsIdJmsId(int dlsid,int jmsid)
            {
                return _db.TJiamengshangGXSQs.SingleOrDefault(r => r.dlsid == dlsid && r.jmsid == jmsid);
            }            

            public int GetJMPinpaiCount(int jmsid)
            {
                return _db.TJiamengshangGXes.Where(r => r.jmsid == jmsid).Count();
            }

            /// <summary>
            /// 取得某个加盟商已有的子加盟商数
            /// </summary>
            /// <param name="jmsid"></param>
            /// <returns></returns>
            public int GetZiJiamengshangCount(int jmsid)
            {
                return _db.TJiamengshangGXes.Where(r => r.dlsid == jmsid).Count();
            }
            /// <summary>
            /// 取得本身以加盟的代理商数量
            /// </summary>
            /// <param name="jmsid"></param>
            /// <returns></returns>
            public int GetFuJiamengshangCount(int jmsid)
            {
                return _db.TJiamengshangGXes.Where(r => r.jmsid == jmsid).Count();
            }

            /// <summary>
            /// 取得某个品牌商或者代理商的子加盟商进货退货记录
            /// </summary>
            /// <param name="dlsid"></param>
            /// <returns></returns>
            public TJiamengshangJintuihuo[] GetJiamengshangJintuihuosByCond(int? dlsid,int? jmsid,DateTime? d_start,DateTime? d_end,int pageSize,int pageIndex,out int recordCount)
            {
                var data = _db.TJiamengshangJintuihuos.Include(r=>r.TJiamengshangJintuihuoMXes)
                    .Include(r => r.Dls).Include(r => r.Jms).AsQueryable();
                if (dlsid != null)
                {
                    data = data.Where(r => r.dlsid == dlsid);
                }
                if (jmsid != null)
                {
                    data = data.Where(r => r.jmsid == jmsid);
                }
                if (d_start != null)
                {
                    data = data.Where(r => r.fashengriqi >= d_start.Value);
                }
                if (d_end != null)
                {
                    data = data.Where(r => r.fashengriqi < d_end.Value);
                }

                recordCount = data.Count();
                data = data.OrderByDescending(r => r.fashengriqi).Skip(pageSize * pageIndex).Take(pageSize);

                return data.ToArray();
            }
            public TJiamengshangJintuihuo GetJiamengshangJintuihuosById(int id)
            {
                return _db.TJiamengshangJintuihuos.Single(r => r.id == id);
            }

            /// <summary>
            /// 取加盟商进退货的详细记录
            /// </summary>
            /// <param name="jtid"></param>
            /// <returns></returns>
            public TJiamengshangJintuihuoMX[] GetJiamengshangJintuihuoMXes(int jtid)
            {
                return _db.TJiamengshangJintuihuoMXes.Include(r => r.TTiaoma).Include(r => r.TTiaoma.TKuanhao).Where(r => r.jintuiid == jtid).ToArray();
            }

            public TJiamengshangJintuihuoMX GetJiamengshangJintuihuoMXById(int id)
            {
                return _db.TJiamengshangJintuihuoMXes.Include(r=>r.TJiamengshangJintuihuo).Single(r => r.id == id);
            }
        }
 
}