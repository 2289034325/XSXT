using DB_FD;
using DB_FD.Models;
using FDXS.Properties;
using MyFormControls;
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
    public partial class Form_KucunYilan : MyForm
    {
        private const int _pageSize = 30;
        private int _pageIndex;
        private int _recordCount;
        private int _pageCount 
        {
            get 
            {
                return _recordCount / _pageSize + (_recordCount % _pageSize == 0 ? 0 : 1);
            }
        }

        //总的库存数据
        private int _totalKucun;
        private decimal _totalJinjia;
        private decimal _totalShoujia;
        //查询到的数据
        private int _schKucun;
        private decimal _schJinjia;
        private decimal _schShoujia;

        public Form_KucunYilan()
        {
            InitializeComponent();
            _pageIndex = 0;

            

            base.InitializeComponent();
        }

        /// <summary>
        /// 查询库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sch_Click(object sender, EventArgs e)
        {
            _pageIndex = 0;
            getData(); 
            lbl_zongji.Text = string.Format("数量{0}/{1}-成本{2}/{3}-售价{4}/{5}", _schKucun, _totalKucun, _schJinjia, _totalJinjia, _schShoujia, _totalShoujia);
        }

        private void getData()
        {
            //查询条件
            string tmh = txb_tiaoma.Text.Trim();
            string kh = txb_kuanhao.Text.Trim();
            string slx = cmb_leixing.SelectedValue.ToString();
            byte? lx = null;
            if (!string.IsNullOrEmpty(slx))
            {
                lx = byte.Parse(slx);
            }
            DateTime? jhrq_start = null;
            DateTime? jhrq_end = null;
            if (dp_start.Checked)
            {
                jhrq_start = dp_start.Value.Date;
            }
            if (dp_end.Checked)
            {
                jhrq_end = dp_end.Value.Date;
            }
            short? sl_start = null;
            if (chk_0.Checked)
            {
                sl_start = 1;
            }

            //入-出+库存修正
            DBContext db = IDB.GetDB();
            Dictionary<TTiaoma, short> ks = db.GetKucunView(tmh, kh, lx, sl_start, null, jhrq_start, jhrq_end, _pageSize, _pageIndex, out _recordCount,out _schKucun,out _schJinjia,out _schShoujia);

            grid_kc.Rows.Clear();
            foreach (KeyValuePair<TTiaoma, short> p in ks)
            {
                grid_kc.Rows.Add(new object[] 
                    {
                        p.Key.tiaoma,
                        p.Key.kuanhao,
                        p.Key.gyskuanhao,
                        ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)p.Key.leixing).ToString(),
                        p.Key.pinming,
                        p.Key.yanse,
                        p.Key.chima,
                        p.Key.shoujia,
                        p.Value
                    });
            }

            //col_sl.HeaderText = "数量(" + ks.Sum(r => r.Value) + ")";
            lbl_page.Text = _pageIndex + 1 + "/" + _pageCount;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KucunYilan_Load(object sender, EventArgs e)
        {
            //类型下拉框
            Tool.CommonFunc.InitCombbox(cmb_leixing, typeof(Tool.JCSJ.DBCONSTS.KUANHAO_LX));
            DataTable dt = (DataTable)cmb_leixing.DataSource;
            dt.Rows.InsertAt(dt.NewRow(), 0);
            cmb_leixing.SelectedIndex = 0;
        }

        /// <summary>
        /// 上报库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sbkc_Click(object sender, EventArgs e)
        {
            new Tool.ActionMessageTool(btn_sbkc_Click_sync, false).Start();    
        }

        private void btn_sbkc_Click_sync(Tool.ActionMessageTool.ShowMsg ShowMsg)
        {
            try
            {
                MyTask.SBKucun();
                ShowMsg("完成", false);
            }
            catch (Exception ex)
            {
                Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                ShowMsg(ex.Message, true);
            }  
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            if (_pageIndex == 0)
            {
                return;
            }

            _pageIndex--;

            getData();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (_pageIndex + 1 >= _pageCount)
            {
                return;
            }

            _pageIndex++;

            getData();
        }


        /// <summary>
        /// 查询总计的库存数量和成本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_zongji_Click(object sender, EventArgs e)
        {
            DBContext db = IDB.GetDB();

            db.GetKucunZongji(out _totalKucun, out _totalJinjia, out _totalShoujia);

            lbl_zongji.Text = string.Format("数量{0}/{1}-成本{2}/{3}-售价{4}/{5}", _schKucun, _totalKucun, _schJinjia, _totalJinjia, _schShoujia, _totalShoujia);
        }
    }
}
