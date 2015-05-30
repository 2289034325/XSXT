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
    public partial class Form_JifenZhekou : MyForm
    {
        public Form_JifenZhekou()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 更新积分规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sch_Click(object sender, EventArgs e)
        {
            JCSJData.THuiyuanZK[] zks;
            try
            {
                zks = JCSJWCF.GetHuiyuanZhekous();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            DBContext db = new DBContext();
            THuiyuanZK[] fzks = zks.Select(r => new THuiyuanZK 
            {
                jifen = r.jifen,
                zhekou = r.zhekou,
                gengxinshijian = DateTime.Now
            }).ToArray();
            db.DeleteHuiyuanZK();
            db.InsertHuiyuanZKs(fzks);

            grid_zk.Rows.Clear();
            foreach (THuiyuanZK zk in fzks)
            {
                grid_zk.Rows.Add(new object[] 
                {
                    zk.jifen,
                    zk.zhekou
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
            //加载积分折扣规则
            DBContext db = new DBContext();
            THuiyuanZK[] zks = db.GetHuiyuanZKs();
            zks = zks.OrderBy(z => z.jifen).ToArray();

            foreach (THuiyuanZK zk in zks)
            {
                grid_zk.Rows.Add(new object[] 
                {
                    zk.jifen,
                    zk.zhekou
                });
            }
        }
    }
}
