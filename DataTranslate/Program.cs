using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranslate
{
    class Program
    {
        static void Main(string[] args)
        {
            int jcuserid = 0;
            int fduserid = 0;
            //条码信息
            Tiaoma_JCSJ(jcuserid);

            //进货信息
            Jinhuo_FD(fduserid);

            //销售记录
            Xiaoshou_FD(fduserid);
        }

        /// <summary>
        /// 销售记录
        /// </summary>
        /// <param name="fduserid"></param>
        private static void Xiaoshou_FD(int fduserid)
        {
            FD_BetaEntities db_beta = new FD_BetaEntities();
            DB_FD.Entities fdb = new DB_FD.Entities();

            //取销售记录
            TXiaoshou[] xss = db_beta.TXiaoshou.ToArray();
            //将条码号，转换成新的ID
            Dictionary<int, string> oidtms = db_beta.TJintuimingxi.ToDictionary(r => r.id, r => r.tiaoma.ToString());
            Dictionary<string, int> idtms = fdb.TTiaoma.ToDictionary(r => r.tiaoma, r => r.id);

            //做新销售记录
            DB_FD.TXiaoshou[] nxss = xss.Select(r => new DB_FD.TXiaoshou 
            {
                xiaoshoushijian = r.charushijian,
                xiaoshouyuan = "娜娜",
                tiaomaid =idtms[oidtms[r.shangpinid]]
            }).ToArray();

            fdb.TXiaoshou.AddRange(nxss);
        }

        /// <summary>
        /// 迁移进货信息
        /// </summary>
        /// <param name="fduserid"></param>
        private static void Jinhuo_FD(int fduserid)
        {
            FD_BetaEntities db_beta = new FD_BetaEntities();
            DB_FD.Entities fdb = new DB_FD.Entities();

            //取得现有库存
            Dictionary<string, short> kcs = new Dictionary<string, short>();
            //将条码号，转换成新的ID
            Dictionary<string, int> idtms = fdb.TTiaoma.ToDictionary(r => r.tiaoma, r => r.id);
            DB_FD.TJinchuMX[] mxs = kcs.Select(r => new DB_FD.TJinchuMX 
            {
                tiaomaid = r.Value,
                shuliang = kcs[r.Key]
            }).ToArray();

            //新作一个进货记录
            DB_FD.TJinchuhuo jc = new DB_FD.TJinchuhuo
            {
                fangxiang = (byte)Tool.FD.DBCONSTS.JCH_FX.进,
                laiyuanquxiang = (byte)Tool.FD.DBCONSTS.JCH_LYQX.内部,
                beizhu = "旧系统数据迁移",
                caozuorenid = fduserid,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now,
                shangbaoshijian = null
            };
            jc.TJinchuMX = mxs;

            fdb.TJinchuhuo.Add(jc);
        }

        /// <summary>
        /// 迁移条码信息
        /// </summary>
        private static void Tiaoma_JCSJ(int userid)
        {
            //取所有旧条码
            FD_BetaEntities fdb_beta = new FD_BetaEntities();
            TJintuimingxi[] ots = fdb_beta.TJintuimingxi.ToArray();

            //数据连接
            DB_JCSJ.Entities jdb = new DB_JCSJ.Entities();

            //做成新条码记录
            DB_JCSJ.TTiaoma[] jts = ots.Select(r => new DB_JCSJ.TTiaoma
            {
                TKuanhao = new DB_JCSJ.TKuanhao 
                {
                    kuanhao = "K"+r.id,
                    leixing = (byte)Tool.JCSJ.DBCONSTS.KUANHAO_LX.衣服,
                    xingbie = (byte)Tool.JCSJ.DBCONSTS.KUANHAO_XB.女,
                    pinming = r.pinming,
                    beizhu = "",
                    caozuorenid = userid,
                    charushijian = DateTime.Now,
                    xiugaishijian = DateTime.Now
                },
                gyskuanhao = r.kuanhao,
                tiaoma = r.tiaoma.ToString(),
                yanse  = r.yanse,
                chima = r.chima,
                jinjia = r.jinjia,
                shoujia = r.shoujia,
                caozuorenid = userid,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now
            }).ToArray();

            //插入基础数据库
            jdb.TTiaoma.AddRange(jts);
        }
    }
}
