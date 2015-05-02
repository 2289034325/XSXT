using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool.DB.CK;

namespace CKGL
{
    public partial class Form_KucunYilan : Form
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
            string lx = cmb_leixing.SelectedValue.ToString();

            //入-出+库存修正
            DBContext db= new DBContext();
            Dictionary<TTiaoma, int> ks = db.GetKucunView(tmh,kh,lx);

            foreach (KeyValuePair<TTiaoma, int> p in ks)
            {
                grid_kc.Rows.Add(new object[] 
                {
                    p.Key.tiaoma,
                    p.Key.kuanhao,
                    p.Key.gyskuanhao,
                    ((Tool.DB.JCSJ.DBCONSTS.KUANHAO_LX)p.Key.leixing).ToString(),
                    p.Key.pinming,
                    p.Key.yanse,
                    p.Key.chima,
                    p.Key.shoujia,
                    p.Value
                });
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KucunYilan_Load(object sender, EventArgs e)
        {
            //类型下拉框
            Tool.CommonFunc.InitCombbox(cmb_leixing, typeof(Tool.DB.JCSJ.DBCONSTS.KUANHAO_LX));
            DataTable dt = (DataTable)cmb_leixing.DataSource;
            dt.Rows.InsertAt(dt.NewRow(), 0);
            cmb_leixing.SelectedIndex = 0;
        }
    }
}
