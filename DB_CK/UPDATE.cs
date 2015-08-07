using DB_CK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_CK
{
    public partial class DBContext
    {
        public void UpdateTiaomas(TTiaoma[] tms)
        {
            foreach (TTiaoma tm in tms)
            {
                TTiaoma ot = _db.TTiaomas.Single(r => r.id == tm.id);

                ot.kuanhao = tm.kuanhao;
                ot.tiaoma = tm.tiaoma;
                ot.gongyingshang = tm.gongyingshang;
                ot.gyskuanhao = tm.gyskuanhao;
                ot.leixing = tm.leixing;
                ot.pinming = tm.pinming;
                ot.yanse = tm.yanse;
                ot.chima = tm.chima;
                ot.jinjia = tm.jinjia;
                ot.shoujia = tm.shoujia;
                ot.xiugaishijian = tm.xiugaishijian;
            }

            _db.SaveChanges();
        }

        /// <summary>
        /// 修改出入库记录
        /// </summary>
        /// <param name="c"></param>
        public void UpdateChuruku(TChuruku c)
        {
            TChuruku oc = _db.TChurukus.Single(r => r.id == c.id);
            //方向不允许修改
            oc.laiyuanquxiang = c.laiyuanquxiang;
            oc.beizhu = c.beizhu;
            oc.xiugaishijian = c.xiugaishijian;

            _db.SaveChanges();
        }

        /// <summary>
        /// 修改出入库明细的数量
        /// </summary>
        /// <param name="mx"></param>
        public void UpdateChurukuMx(int id,short sl)
        {
            TChurukuMX om = _db.TChurukuMXes.Single(r => r.id == id);
            //只允许修改数量
            om.shuliang = sl;

            _db.SaveChanges();
        }

        /// <summary>
        /// 更新出入库记录的上报时间
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="sj"></param>
        public void UpdateChurukuShangbaoshijian(int[] ids, DateTime sj)
        {
            var crs = _db.TChurukus.Where(r => ids.Contains(r.id));
            foreach (TChuruku cr in crs)
            {
                cr.shangbaoshijian = sj;
            }

            _db.SaveChanges();
        }
    }
}
