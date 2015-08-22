using DB_FD;
using DB_FD.Models;
using FDXS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace FDXS
{
    public partial class Form_Tiaomaxinxi : MyForm
    {
        private Dlg_Tiaomahao _dlgtmh;
        public Form_Tiaomaxinxi()
        {
            InitializeComponent();
            _dlgtmh = new Dlg_Tiaomahao();
        }

        public override void OnScan(string tm)
        {
            if (_dlgtmh.Visible)
            {
                _dlgtmh.OnScan(tm);
            }
        }

        /// <summary>
        /// 下载最新条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xzzxtm_Click(object sender, EventArgs e)
        {
            //new Tool.ActionMessageTool(btn_xzzxtm_Click_sync, false).Start();    
            CommonMethod.DownLoadTiaomaInfo(dp_start.Value, dp_end.Value, false);
        }

        //private void btn_xzzxtm_Click_sync(Tool.ActionMessageTool.ShowMsg ShowMsg)
        //{
        //    try
        //    {
        //        JCSJData.TTiaoma[] jtms = JCSJWCF.GetTiaomasByUpdTime(dp_start.Value, dp_end.Value);
        //        CommonMethod.SaveTmsToLocal(jtms);

        //        ShowMsg("下载完毕，共下载" + jtms.Count() + "个条码信息", false);
        //    }
        //    catch (Exception ex)
        //    {
        //        Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
        //        ShowMsg(ex.Message, true);
        //    }  
        //}

        /// <summary>
        /// 下载指定条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xzzdtm_Click(object sender, EventArgs e)
        {
            if (_dlgtmh.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //string[] tmhs = dt.txb_tmhs.Text.Trim().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string[] tmhs = _dlgtmh.TMHs;
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
                    t.gongyingshang,
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
