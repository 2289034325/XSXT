using DB_FD;
using FDXS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace FDXS
{
    public partial class Form_Tiaomaxinxi : MyForm
    {
        public Form_Tiaomaxinxi()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 下载最新条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xzzxtm_Click(object sender, EventArgs e)
        {
            JCSJData.TTiaoma[] jtms;
            try
            {
                jtms = JCSJWCF.GetTiaomasByUpdTime(dp_start.Value, dp_end.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            saveToLocal(jtms);
        }

        /// <summary>
        /// 下载指定条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xzzdtm_Click(object sender, EventArgs e)
        {
            Dlg_Tiaomahao dt = new Dlg_Tiaomahao();
            if (dt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] tmhs = dt.txb_tmhs.Text.Trim().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                JCSJData.TTiaoma[] jtms;

                try
                {
                    jtms = JCSJWCF.GetTiaomasByTiaomahaos(tmhs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                saveToLocal(jtms);
            }
        }

        /// <summary>
        /// 把取得的条码信息保存到本地
        /// </summary>
        /// <param name="jtms"></param>
        private void saveToLocal(JCSJData.TTiaoma[] jtms)
        {
            List<TTiaoma> tms = new List<TTiaoma>();
            foreach (JCSJData.TTiaoma jtm in jtms)
            {
                TTiaoma tm = new TTiaoma
                {
                    id = jtm.id,
                    tiaoma = jtm.tiaoma,
                    kuanhao = jtm.TKuanhao.kuanhao,
                    gyskuanhao = jtm.gyskuanhao,
                    leixing = jtm.TKuanhao.leixing,
                    pinming = jtm.TKuanhao.pinming,
                    yanse = jtm.yanse,
                    chima = jtm.chima,
                    jinjia = jtm.jinjia,
                    shoujia = jtm.shoujia
                };
                tms.Add(tm);
            }

            //找出已经在本地存在的条码
            DBContext db = IDB.GetDB();
            TTiaoma[] otms = db.GetTiaomasByIds(tms.Select(r => r.id).ToArray());
            int[] oids = otms.Select(r => r.id).ToArray();
            //需要更新的条码和需要新插入的条码
            TTiaoma[] uts = tms.Where(r => oids.Contains(r.id)).ToArray();
            uts.ToList().ForEach(t => t.xiugaishijian = DateTime.Now);
            TTiaoma[] nts = tms.Where(r => !oids.Contains(r.id)).ToArray();
            nts.ToList().ForEach(t => { t.charushijian = DateTime.Now; t.xiugaishijian = DateTime.Now; });
            db.UpdateTiaomas(uts);
            db.InsertTiaomas(nts);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Tiaomaxinxi_Load(object sender, EventArgs e)
        {
            //类型下拉框
            Tool.CommonFunc.InitCombbox(cmb_lx, typeof(Tool.JCSJ.DBCONSTS.KUANHAO_LX));
            DataTable dt = (DataTable)cmb_lx.DataSource;
            dt.Rows.InsertAt(dt.NewRow(), 0);
            cmb_lx.SelectedIndex = 0;

            //日期
            dp_start.Value = DateTime.Now.AddDays(-15);
            dp_end.Value = DateTime.Now;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sch_Click(object sender, EventArgs e)
        {
            string tm = txb_tm.Text.Trim();
            string kh = txb_kh.Text.Trim();
            string lx = cmb_lx.SelectedValue.ToString();

            DBContext db = IDB.GetDB();
            TTiaoma[] tms = db.GetTiaomasByCond(tm, kh, lx);

            grid_tm.Rows.Clear();
            foreach (TTiaoma t in tms)
            {
                grid_tm.Rows.Add(new object[] 
                {
                    t.id,
                    t.tiaoma,
                    t.kuanhao,
                    t.gyskuanhao,
                    ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)t.leixing).ToString(),
                    t.pinming,
                    t.yanse,
                    t.chima,
                    t.shoujia,
                    t.xiugaishijian
                });
            }
        }
    }
}
