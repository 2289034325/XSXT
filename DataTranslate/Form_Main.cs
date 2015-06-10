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
        private int _jcid;
        private DB_FD.FDEntities _fdb;
        private FD_BetaEntities _db_beta;
        private DB_JCSJ.JCSJEntities _jdb;


        private int _jcuserid;
        private int _fduserid;

        public Form_Main()
        {
            InitializeComponent();
            _fdb = null;
            _db_beta = null;
            _jdb = null;
        }


        /// <summary>
        /// 将销售的数量加到进货数量上去
        /// </summary>
        private void AddXiaoshou_FD()
        {
            DB_FD.TXiaoshou[] xss = _fdb.TXiaoshou.ToArray();


            foreach (DB_FD.TXiaoshou xs in xss)
            {
                DB_FD.TJinchuMX mx = _fdb.TJinchuMX.SingleOrDefault(r => r.tiaomaid == xs.tiaomaid);
                if (mx == null)
                {
                    _fdb.TJinchuMX.Add(new DB_FD.TJinchuMX
                    {
                        jinchuid = _jcid,
                        tiaomaid = xs.tiaomaid,
                        shuliang = 1
                    });
                }
                else
                {
                    mx.shuliang++;
                }
            }

            _fdb.SaveChanges();
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
                tiaomaid = idtms[oidtms[r.shangpinid]]
            }).ToArray();

            _fdb.TXiaoshou.AddRange(nxss);
        }

        /// <summary>
        /// 迁移进货信息
        /// </summary>
        /// <param name="fduserid"></param>
        private void Jinhuo_FD()
        {
            //取得现有库存
            Dictionary<string, short> kcs = new Dictionary<string, short>();
            //将条码号，转换成新的ID
            Dictionary<string, int> idtms = _fdb.TTiaoma.ToDictionary(r => r.tiaoma, r => r.id);
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
                caozuorenid = _fduserid,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now,
                shangbaoshijian = null
            };
            jc.TJinchuMX = mxs;

            DB_FD.TJinchuhuo njc = _fdb.TJinchuhuo.Add(jc);
            _jcid = njc.id;
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
                    leixing = (byte)Tool.JCSJ.DBCONSTS.KUANHAO_LX.衣服,
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
            //将库存信息算作进货信息
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
            if (_db_beta == null)
            { _db_beta = new FD_BetaEntities("FD_BetaEntities"); }
            if (_fdb == null)
            { _fdb = new DB_FD.FDEntities("FDEntities"); }
        }
    }
}
