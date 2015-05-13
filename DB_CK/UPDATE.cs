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
                TTiaoma ot = _db.TTiaoma.Single(r => r.id == tm.id);

                ot.kuanhao = tm.kuanhao;
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
            TChuruku oc = _db.TChuruku.Single(r => r.id == c.id);
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
        public void UpdateChurukuMx(TChurukuMX mx)
        {
            TChurukuMX om = _db.TChurukuMX.Single(r => r.id == mx.id);
            //只允许修改数量
            om.shuliang = mx.shuliang;

            _db.SaveChanges();
        }
    }
}
