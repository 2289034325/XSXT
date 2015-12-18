using DB_FD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_FD
{
    public partial class DBContext
    {
        public void UpdateTiaomas(TTiaoma[] tms)
        {
            foreach (TTiaoma tm in tms)
            {
                TTiaoma ot = _db.TTiaomas.Single(r => r.id == tm.id);

                ot.kuanhao = tm.kuanhao;
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

        public void UpdateTiaomaJinjia(int id, decimal jj)
        {
            TTiaoma ot = _db.TTiaomas.Single(r => r.id == id);

            ot.jinjia = jj;

            _db.SaveChanges();
        }

        /// <summary>
        /// 修改进出货记录
        /// </summary>
        /// <param name="c"></param>
        public void UpdateJinchuhuo(TJinchuhuo c)
        {
            TJinchuhuo oc = _db.TJinchuhuos.Single(r => r.id == c.id);
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
        public void UpdateJinchuhuoMx_sl(int id,short sl)
        {
            TJinchuMX om = _db.TJinchuMXes.Single(r => r.id == id);
            om.shuliang = sl;

            _db.SaveChanges();
        }
        public void UpdateJinchuhuoMx_jj(int id, decimal jj)
        {
            TJinchuMX om = _db.TJinchuMXes.Single(r => r.id == id);
            om.danjia = jj;

            _db.SaveChanges();
        }


        /// <summary>
        /// 给已有的盘点记录数量加减1
        /// </summary>
        /// <param name="jiajian"></param>
        public void UpdatePandian(int id, bool jiajian)
        {
            TPandian op = _db.TPandians.Single(r => r.id == id);
            if (jiajian)
            {
                op.pdshuliang = (short)(op.pdshuliang + 1);
            }
            else
            {
                op.pdshuliang = (short)(op.pdshuliang - 1);
            }

            _db.SaveChanges();
        }

        /// <summary>
        /// 修改库存修正的数量
        /// </summary>
        /// <param name="x"></param>
        public void UpdateKucunXZ(TKucunXZ x)
        {
            TKucunXZ ox = _db.TKucunXZs.Single(r => r.id == x.id);
            ox.shuliang = x.shuliang;
            ox.xiugaishijian = x.xiugaishijian;

            _db.SaveChanges();
        }

        /// <summary>
        /// 本地更新会员积分
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jf"></param>
        //public void UpdateAddHuiyuanJF(int id, decimal jf)
        //{
        //    THuiyuan h = _db.THuiyuans.Single(r => r.id == id);

        //    h.jifen += jf;

        //    _db.SaveChanges();
        //}

        /// <summary>
        /// 更新本地会员信息
        /// </summary>
        /// <param name="h"></param>
        public void UpdateHuiyuanInfo(THuiyuan h)
        {
            THuiyuan oh = _db.THuiyuans.Single(r => r.id == h.id);

            oh.shoujihao = h.shoujihao;
            oh.xingbie = h.xingbie;
            oh.xingming = h.xingming;
            oh.shengri = h.shengri;
            oh.xxgxshijian = h.xxgxshijian;

            _db.SaveChanges();
        }
        public void UpdateHuiyuanAll(THuiyuan h)
        {
            THuiyuan oh = _db.THuiyuans.Single(r => r.id == h.id);

            oh.shoujihao = h.shoujihao;
            oh.xingbie = h.xingbie;
            oh.xingming = h.xingming;
            oh.xxgxshijian = h.xxgxshijian;
            oh.jifen = h.jifen;
            oh.jfgxshijian = h.jfgxshijian;

            _db.SaveChanges();
        }

        /// <summary>
        /// 更新销售记录的上报时间
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="sbsj"></param>
        public void UpdateXiaoshouShangbaoshijian(int[] ids, DateTime sbsj)
        {
            var xss = _db.TXiaoshous.Where(r => ids.Contains(r.id));
            foreach (TXiaoshou x in xss)
            {
                x.shangbaoshijian = sbsj;
            }

            _db.SaveChanges();
        }

        /// <summary>
        /// 更新进出货记录的上报时间
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="sbsj"></param>
        public void UpdateJinchuhuoShangbaoshijian(int[] ids, DateTime? sbsj)
        {
            var jcs = _db.TJinchuhuos.Where(r => ids.Contains(r.id));
            foreach (TJinchuhuo jc in jcs)
            {
                jc.shangbaoshijian = sbsj;
            }

            _db.SaveChanges();
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="u"></param>
        public void UpdateUser(TUser u)
        {
            var ou = _db.TUsers.Single(r => r.id == u.id);

            ou.dengluming = u.dengluming;
            if (!string.IsNullOrEmpty(u.mima))
            {
                ou.mima = u.mima;
            }
            ou.yonghuming = u.yonghuming;
            ou.juese = u.juese;
            ou.zhuangtai = u.zhuangtai;
            ou.beizhu = u.beizhu;
            ou.xiuggaishijian = u.xiuggaishijian;

            _db.SaveChanges();
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="psw"></param>
        public void UpdateUserPsw(int id,string psw)
        {
            TUser u = _db.TUsers.Single(r => r.id == id);
            u.mima = psw;

            _db.SaveChanges();
        }

        public void UpdateJinchuhuoQueren(int id, bool queren)
        {
            TJinchuhuo oj = _db.TJinchuhuos.Single(r => r.id == id);

            oj.queding = queren;

            _db.SaveChanges();
        }
    }
}
