using DB_FD;
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
        public Form_KucunYilan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sch_Click(object sender, EventArgs e)
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
            //入-出+库存修正
            DBContext db = IDB.GetDB();
            Dictionary<TTiaoma, short> ks = db.GetKucunView(tmh,kh,lx,null,null);

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

            col_sl.HeaderText = "数量(" + ks.Sum(r => r.Value) + ")";
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
            Dlg_Progress dp = new Dlg_Progress();
            btn_sbkc_Click_sync(dp);
            dp.ShowDialog();      
        }

        private async void btn_sbkc_Click_sync(Dlg_Progress dp)
        {
            await Task.Run(() => 
            {
                try
                {
                    MyTask.SBKucun();
                    dp.lbl_msg.Text = "完成";
                }
                catch (Exception ex)
                {
                    dp.lbl_msg.Text = ex.Message;
                }
            });
            dp.ControlBox = true;
        }
    }
}
