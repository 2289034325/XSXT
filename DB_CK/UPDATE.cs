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

            oc.fangxiang = c.fangxiang;
            oc.jmsid = c.jmsid;
            oc.zhekou = c.zhekou;
            oc.laiyuanquxiang = c.laiyuanquxiang;
            oc.beizhu = c.beizhu;
            oc.xiugaishijian = c.xiugaishijian;

            _db.SaveChanges();
        }


        public void UpdateChurukuQueren(int id, bool zt)
        {
            var oc = _db.TChurukus.Single(r => r.id == id);

            oc.queding = zt;

            _db.SaveChanges();
        }

        /// <summary>
        /// 修改出入库明细的数量
        /// </summary>
        /// <param name="mx"></param>
        public void UpdateChurukuMx_sl(int id,short sl)
        {
            TChurukuMX om = _db.TChurukuMXes.Single(r => r.id == id);

            om.shuliang = sl;

            _db.SaveChanges();
        }
        public void UpdateChurukuMx_dj(int id, decimal dj)
        {
            TChurukuMX om = _db.TChurukuMXes.Single(r => r.id == id);

            om.danjia = dj;

            _db.SaveChanges();
        }

        /// <summary>
        /// 更新出入库记录的上报时间
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="sj"></param>        
        public void UpdateChurukuShangbao(int id, string pcm,DateTime? sbsj)
        {
            var oc = _db.TChurukus.Single(r => r.id == id);

            oc.picima = pcm;
            oc.shangbaoshijian = sbsj;

            _db.SaveChanges();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mm"></param>
        public void UpdateUserPsw(int id, string mm)
        {
            TUser ou = _db.TUsers.Single(r => r.id == id);

            ou.mima = mm;

            _db.SaveChanges();
        }

        /// <summary>
        /// 将全部加盟商的状态设置为非子加盟商状态
        /// </summary>
        public void UpdateJiamengshangZhuangtai()
        {
            var jmses = _db.TJiamengshangs;
            foreach (TJiamengshang j in jmses)
            {
                j.zhuangtai = false;
            }

            _db.SaveChanges();
        }

        public void UpdateJiamengshang(TJiamengshang nj)
        {
            var oj = _db.TJiamengshangs.Single(r => r.id == nj.id);

            oj.mingcheng = nj.mingcheng;
            oj.daima = nj.daima;
            oj.dizhi = nj.dizhi;
            oj.lianxiren = nj.lianxiren;
            oj.dianhua = nj.dianhua;
            oj.zhuangtai = nj.zhuangtai;

            _db.SaveChanges();
        }
    }
}
