using CKGL.Properties;
using DB_CK;
using DB_CK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKGL.CK
{
    public partial class Form_Tiaomaxinxi : Form
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
            //DateTime start = dp_start.Value;
            //DateTime end = dp_end.Value;

            //CommonMethod.DownLoadTiaomaInfo(start, end, false);
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
                string[] tmhs = dt.TMHs;

                CommonMethod.DownLoadTiaomaInfo(tmhs, false);
            }
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
            //dp_start.Value = DateTime.Now.AddDays(-15);
            //dp_end.Value = DateTime.Now;

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
                        t.gongyingshang,
                        t.gyskuanhao,
                        ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)t.leixing).ToString(),
                        t.pinming,
                        t.yanse,
                        t.chima,
                        t.jinjia,
                        t.shoujia,
                        t.xiugaishijian
                    });
            }
        }
    }
}
