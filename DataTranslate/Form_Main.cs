using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataTranslate
{
    public partial class Form_Main : Form
    {
        //private int _jcid;
        private DB_FD.FDEntities _fdb;
        private FD_BetaEntities _db_beta;
        private DB_JCSJ.JCSJEntities _jdb;


        private int _jcuserid;
        private int _fduserid;
        private int _kcid;

        public Form_Main()
        {
            InitializeComponent();
            _fdb = null;
            _db_beta = null;
            _jdb = null;
        }


        /// <summary>
        /// 将销售的数量加到修正数量上去
        /// </summary>
        private void AddXiaoshou_FD()
        {
            var xss = _fdb.TXiaoshou.Select(r => new { r.tiaomaid, r.shuliang }).GroupBy(r => r.tiaomaid).
                Select(r => new { tmid = r.Key, sl = (short)r.Sum(rr => rr.shuliang) });
            List<DB_FD.TKucunXZ> nmxs = new List<DB_FD.TKucunXZ>();
            foreach (var xs in xss)
            {
                if (!_fdb.TKucunXZ.Any(r => r.tiaomaid == xs.tmid))
                {
                    nmxs.Add(
                    new DB_FD.TKucunXZ
                    {
                        tiaomaid = xs.tmid,
                        shuliang = xs.sl,
                        caozuorenid = _fduserid,
                        charushijian = DateTime.Now,
                        xiugaishijian = DateTime.Now

                    });
                }
                else
                {
                    DB_FD.TKucunXZ mx = _fdb.TKucunXZ.Single(r => r.tiaomaid == xs.tmid);
                    mx.shuliang += xs.sl;
                }
            }

            _fdb.SaveChanges();
            if (nmxs.Count != 0)
            {
                _fdb = new DB_FD.FDEntities("FDEntities");
                _fdb.TKucunXZ.AddRange(nmxs);
                _fdb.SaveChanges();
            }
        }


        /// <summary>
        /// 销售记录
        /// </summary>
        /// <param name="fduserid"></param>
        private void Xiaoshou_FD()
        {
            //取销售记录
            TXiaoshou[] xss = _db_beta.TXiaoshou.ToArray();
            //将条码号，转换成新的ID
            Dictionary<int, string> oidtms = _db_beta.TJintuimingxi.ToDictionary(r => r.id, r => r.tiaoma.ToString());
            Dictionary<string, int> idtms = _fdb.TTiaoma.ToDictionary(r => r.tiaoma, r => r.id);

            //做新销售记录
            DB_FD.TXiaoshou[] nxss = xss.Select(r => new DB_FD.TXiaoshou
            {
                xiaoshoushijian = r.charushijian,
                xiaoshouyuan = "娜娜",
                tiaomaid = idtms[oidtms[r.shangpinid]],
                huiyuanid = null,
                shuliang = r.shuliang,
                danjia = r.danjia,
                zhekou = r.zhekou,
                moling = r.moling,
                beizhu = "",
                caozuorenid = _fduserid,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now,
                shangbaoshijian = null
            }).ToArray();

            _fdb.TXiaoshou.AddRange(nxss);
            _fdb.SaveChanges();
        }

        /// <summary>
        /// 迁移进货信息
        /// </summary>
        /// <param name="fduserid"></param>
        private void Jinhuo_FD()
        {
            //取得现有库存
            Dictionary<string, short> kcs = _db_beta.TJintuihuo.Single(r => r.id == _kcid).TJintuimingxi.ToArray().ToDictionary(r => r.tiaoma.ToString(), r => r.shuliang);
            //将条码号，转换成新的ID
            Dictionary<string, int> idtms = _fdb.TTiaoma.ToDictionary(r => r.tiaoma, r => r.id);
            DB_FD.TKucunXZ[] mxs = kcs.Select(r => new DB_FD.TKucunXZ
            {
                tiaomaid = idtms[r.Key],
                shuliang = kcs[r.Key],
                caozuorenid = _fduserid,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now
            }).ToArray();

            //新作一个进货记录
            //DB_FD.TJinchuhuo jc = new DB_FD.TJinchuhuo
            //{
            //    fangxiang = (byte)Tool.JCSJ.DBCONSTS.JCH_FX.进,
            //    laiyuanquxiang = (byte)Tool.JCSJ.DBCONSTS.JCH_LYQX.仓库,
            //    beizhu = "旧系统数据迁移",
            //    caozuorenid = _fduserid,
            //    charushijian = DateTime.Now,
            //    xiugaishijian = DateTime.Now,
            //    shangbaoshijian = null
            //};
            //jc.TJinchuMX = mxs;

            //DB_FD.TJinchuhuo njc = _fdb.TJinchuhuo.Add(jc);
            _fdb.TKucunXZ.AddRange(mxs);
            _fdb.SaveChanges();
            //_jcid = njc.id;
        }

        /// <summary>
        /// 迁移条码信息
        /// </summary>
        private void Tiaoma_JCSJ()
        {
            //取所有旧条码
            TJintuimingxi[] ots = _db_beta.TJintuimingxi.Where(r=>r.TJintuihuo.jintui).ToArray();
            //做成新条码记录
            DB_JCSJ.TTiaoma[] jts = ots.Select(r => new DB_JCSJ.TTiaoma
            {
                TKuanhao = new DB_JCSJ.TKuanhao
                {
                    kuanhao = "K" + r.id,
                    leixing = (byte)Tool.JCSJ.DBCONSTS.KUANHAO_LX.上装,
                    xingbie = (byte)Tool.JCSJ.DBCONSTS.KUANHAO_XB.女,
                    pinming = r.pinming,
                    beizhu = "",
                    caozuorenid = _jcuserid,
                    charushijian = DateTime.Now,
                    xiugaishijian = DateTime.Now
                },
                gyskuanhao = r.kuanhao,
                tiaoma = r.tiaoma.ToString(),
                yanse = r.yanse,
                chima = r.chima,
                jinjia = r.jinjia,
                shoujia = r.shoujia,
                caozuorenid = _jcuserid,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now
            }).ToArray();

            //插入基础数据库
            _jdb.TTiaoma.AddRange(jts);
            _jdb.SaveChanges();
        }

        private void btn_tm_Click(object sender, EventArgs e)
        {
            //条码信息
            Tiaoma_JCSJ();
        }

        private void btn_kc_Click(object sender, EventArgs e)
        {
            //将库存信息算作库存修正
            Jinhuo_FD();
        }

        private void btn_xs_Click(object sender, EventArgs e)
        {
            //销售记录
            Xiaoshou_FD();
        }

        private void btn_xz_Click(object sender, EventArgs e)
        { 
            //将销售的数量加到进货数量上去
            AddXiaoshou_FD();

        }

        private void btn_jcsjzb_Click(object sender, EventArgs e)
        {
            _jcuserid = int.Parse(txb_jcsj.Text.Trim());
            if (_db_beta == null)
            { _db_beta = new FD_BetaEntities("FD_BetaEntities"); }
            if (_jdb == null)
            { _jdb = new DB_JCSJ.JCSJEntities("JCSJEntities"); }

        }

        private void btn_fdzb_Click(object sender, EventArgs e)
        {
            _fduserid = int.Parse(txb_fd.Text.Trim());
            _kcid = int.Parse(txb_kcid.Text.Trim());
            if (_db_beta == null)
            { _db_beta = new FD_BetaEntities("FD_BetaEntities"); }
            if (_fdb == null)
            {
                _fdb = new DB_FD.FDEntities("FDEntities");
                _fdb.Configuration.ProxyCreationEnabled = false;
            }
        }
    }
}
