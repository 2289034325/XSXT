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
using Tool.DB.FDXS;

namespace FDXS
{
    public partial class Form_KucunGuanli : MyForm
    {
        public Form_KucunGuanli()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 处理扫描枪事件
        /// </summary>
        /// <param name="tm"></param>
        public override void OnScan(string tm)
        {
            //如果是盘点页
            if (tb_gl.SelectedTab.Equals(tbp_pd))
            {
                //检查条码
                DBContext db = new DBContext();
                TTiaoma t = db.GetTiaomaByTmh(tm);
                if (t == null)
                {
                    MessageBox.Show("该条码不存在，请先更新条码信息");
                }
                else
                {
                    //检查是否已经在盘点表中存在
                    TPandian pd = db.GetPandianByTmId(t.id);
                    if (pd == null)
                    {
                        //插入盘点表
                        pd = new TPandian
                        {
                            tiaomaid = t.id,
                            shuliang = 1,
                            charushijian = DateTime.Now
                        };

                        db.InsertPandian(pd);
                        addPandian(pd);
                    }
                    else
                    {
                        //已有的盘点记录数量加1
                        db.UpdatePandian(pd.id,true);
                        pandianShuliang(pd.id,true);
                    }
                }
            }
        }
        
        /// <summary>
        /// 在grid中增加一行盘点记录
        /// </summary>
        /// <param name="pd"></param>
        private void addPandian(TPandian pd)
        {
            grid_pd.Rows.Add(new object[] 
            {
                pd.id,
                pd.TTiaoma.tiaoma,
                pd.TTiaoma.kuanhao,
                pd.TTiaoma.pinming,
                pd.TTiaoma.yanse,
                pd.TTiaoma.chima,
                pd.shuliang,
                0,
                pd.charushijian
            });
        }

        /// <summary>
        /// 将表格中的盘点数量加减1
        /// </summary>
        /// <param name="pdid"></param>
        /// <param name="jiajian"></param>
        private void pandianShuliang(int pdid, bool jiajian)
        {
            //找到对应行
            foreach (DataGridViewRow dr in grid_pd.Rows)
            {
                if (pdid.Equals(dr.Cells[col_pd_id.Name].Value))
                {
                    if (jiajian)
                    {
                        dr.Cells[col_pd_pdsl.Name].Value = (int)dr.Cells[col_pd_pdsl.Name].Value + 1;
                    }
                    else
                    {
                        dr.Cells[col_pd_pdsl.Name].Value = (int)dr.Cells[col_pd_pdsl.Name].Value - 1;
                    }
                }
            }
        }

        /// <summary>
        /// 核对库存和盘点数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_pd_hd_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KucunGuanli_Load(object sender, EventArgs e)
        {
            //加载盘点记录
            DBContext db = new DBContext();
            TPandian[] ps = db.GetPandians();

            foreach (TPandian p in ps)
            {
                addPandian(p);
            }
        }
    }
}
