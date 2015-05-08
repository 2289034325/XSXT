using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DB.FDXS
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
        /// 修改进出货记录
        /// </summary>
        /// <param name="c"></param>
        public void UpdateChuruku(TJinchuhuo c)
        {
            TJinchuhuo oc = _db.TJinchuhuo.Single(r => r.id == c.id);
            //方向不允许修改
            oc.laiyuanquxiang = c.laiyuanquxiang;
            oc.beizhu = c.beizhu;
            oc.xiugaishijian = c.xiugaishijian;

            _db.SaveChanges();
        }

        /// <summary>
        /// 修改进出货明细的数量
        /// </summary>
        /// <param name="mx"></param>
        public void UpdateChurukuMx(TJinchuMX mx)
        {
            TJinchuMX om = _db.TJinchuMX.Single(r => r.id == mx.id);
            //只允许修改数量
            om.shuliang = mx.shuliang;

            _db.SaveChanges();
        }


        /// <summary>
        /// 给已有的盘点记录数量加减1
        /// </summary>
        /// <param name="jiajian"></param>
        public void UpdatePandian(int id,bool jiajian)
        {
            TPandian op = _db.TPandian.Single(r => r.id == id);
            if (jiajian)
            {
                op.shuliang = (short)(op.shuliang + 1);
            }
            else
            {
                op.shuliang = (short)(op.shuliang - 1);
            }

            _db.SaveChanges();
        }
    }
}
