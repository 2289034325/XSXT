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
using Tool.DB.FDXS;

namespace FDXS
{
    public partial class Form_Xiaoshou : MyForm
    {
        private TUser _user;
        //开单对话框
        private Dlg_xiaoshou _dlgKaidan;

        public Form_Xiaoshou(TUser user)
        {
            InitializeComponent();
            _dlgKaidan = null;
            _user = user;
        }

        /// <summary>
        /// 扫描枪事件
        /// </summary>
        /// <param name="tm"></param>
        public override void OnScan(string tm)
        {
            if (_dlgKaidan != null)
            {
                _dlgKaidan.OnScan(tm);
            }
            else
            {
                //打开开单对话框
                Dlg_xiaoshou dx = new Dlg_xiaoshou(tm);
                _dlgKaidan = dx;
                dx.ShowDialog();
                _dlgKaidan = null;
            }
        }

        /// <summary>
        /// 查询销售
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sch_Click(object sender, EventArgs e)
        {
            //查询条件
            string tmh = txb_tiaoma.Text.Trim();
            string kh = txb_kuanhao.Text.Trim();
            DateTime dstart = dp_start.Value;
            DateTime dend = dp_end.Value;

            //查询数据
            DBContext db= new DBContext();
            grid_xs.Rows.Clear();
            
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KucunYilan_Load(object sender, EventArgs e)
        {
            //类型下拉框
            //Tool.CommonFunc.InitCombbox(cmb_leixing, typeof(Tool.DB.JCSJ.DBCONSTS.KUANHAO_LX));
            //DataTable dt = (DataTable)cmb_leixing.DataSource;
            //dt.Rows.InsertAt(dt.NewRow(), 0);
            //cmb_leixing.SelectedIndex = 0;
        }

        /// <summary>
        /// 销售开单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_kd_Click(object sender, EventArgs e)
        {
            Dlg_xiaoshou dx = new Dlg_xiaoshou(null);
            _dlgKaidan = dx;
            dx.ShowDialog();
            _dlgKaidan = null;
        }
    }
}
