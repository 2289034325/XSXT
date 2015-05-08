using FDXS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;
using Tool.DB.FDXS;

namespace FDXS
{
    public partial class Dlg_xiaoshou : MyForm
    {
        private string _startTM;
        public Dlg_xiaoshou(string tm)
        {
            InitializeComponent();
            _startTM = tm;
        }

        /// <summary>
        /// 扫描枪事件
        /// </summary>
        /// <param name="tm">条码号</param>
        public override void OnScan(string tm)
        {            
                DBContext db = new DBContext();
                TTiaoma t = db.GetTiaomaByTmh(tm);
                if (t == null)
                {
                    MessageBox.Show("该条码不存在");
                    return;
                }

            //检查是否已经在开单表格中
            int index = 0;
            if (existsTM(tm,out index))
            {
                //在原有的行上数量加1
                short sl = (short)grid_kaidan.Rows[index].Cells[col_sl.Name].Value;
                grid_kaidan.Rows[index].Cells[col_sl.Name].Value = (short)(sl + 1);
            }
            else
            {
                TXiaoshou xs = new TXiaoshou
                {
                    TTiaoma = new TTiaoma 
                    {
                        id=t.id,
                        tiaoma = t.tiaoma,
                        kuanhao = t.kuanhao,
                        pinming = t.pinming,
                        yanse = t.yanse,
                        chima = t.chima
                    },
                    danjia = t.shoujia,
                    shuliang = 1,
                    zhekou = Settings.Default.MRZK,
                    moliing = 0,
                    beizhu = ""
                };

                addKaidan(xs);
            }
        }

        /// <summary>
        /// 增加一行开单
        /// </summary>
        /// <param name="xs"></param>
        private void addKaidan(TXiaoshou xs)
        {
            grid_kaidan.Rows.Add(new object[] 
            {
                xs.TTiaoma.id,
                xs.TTiaoma.tiaoma,
                xs.TTiaoma.kuanhao,
                xs.TTiaoma.pinming,
                xs.TTiaoma.yanse,
                xs.TTiaoma.chima,
                xs.shuliang,
                xs.TTiaoma.shoujia,
                xs.zhekou,
                xs.moliing,
                xs.danjia,
                xs.beizhu
            });
        }

        /// <summary>
        /// 检查条码是否已经在开单表格中
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        private bool existsTM(string tm,out int index)
        {
            index = 0;
            foreach (DataGridViewRow dr in grid_kaidan.Rows)
            {
                if (tm.Equals(dr.Cells[col_tm.Name].Value))
                {
                    index = dr.Index;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_xiaoshou_Load(object sender, EventArgs e)
        {
            //如果是传入了条码的构造
            if (!string.IsNullOrEmpty(_startTM))
            {
                //加入一行
                DBContext db = new DBContext();
                TTiaoma t = db.GetTiaomaByTmh(_startTM);
                if (t == null)
                {
                    MessageBox.Show("该条码不存在");
                    return;
                }

                TXiaoshou xs = new TXiaoshou
                {
                    TTiaoma = new TTiaoma
                    {
                        id = t.id,
                        tiaoma = t.tiaoma,
                        kuanhao = t.kuanhao,
                        pinming = t.pinming,
                        yanse = t.yanse,
                        chima = t.chima
                    },
                    danjia = t.shoujia,
                    shuliang = 1,
                    zhekou = Settings.Default.MRZK,
                    moliing = 0,
                    beizhu = ""
                };

                addKaidan(xs);
            }
        }

        /// <summary>
        /// 删除一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kaidan_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {

        }
        
    }
}