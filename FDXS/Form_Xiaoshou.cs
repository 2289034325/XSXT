using DB_FD;
using FDXS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace FDXS
{
    public partial class Form_Xiaoshou : MyForm
    {
        //开单对话框
        private Dlg_xiaoshou _dlgKaidan;
        //开单数据
        private List<TXiaoshou> _XSS;

        public Form_Xiaoshou()
        {
            InitializeComponent();
            _dlgKaidan = null;
            _XSS = null;
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
                if (dx.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    xiaoshouDlgOK(dx.XSS,dx.Huiyuan);
                }
                _dlgKaidan = null;
            }
        }

        /// <summary>
        /// 销售对话框OK
        /// </summary>
        /// <param name="xss"></param>
        /// <param name="hy"></param>
        private void xiaoshouDlgOK(List<TXiaoshou> xss, THuiyuan hy)
        {
            //保存到数据库
            DBContext db = new DBContext();
            TXiaoshou[] nxss = db.InsertXiaoshous(xss.ToArray());
            foreach (TXiaoshou x in nxss)
            {
                addXiaoshou(x);
            }

            //将积分加给会员
            if (hy != null)
            {
                decimal zj = decimal.Round(xss.Sum(r => r.danjia * r.shuliang * r.zhekou / 10 - r.moliing), 0);
                db.UpdateHuiyuanJF(hy.id, zj);
            }

            _XSS = xss;

            //打印小票
            xiaopiao();
        }

        private void xiaopiao()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            try
            {
                printDocument.Print();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                printDocument.PrintController.OnEndPrint(printDocument, new PrintEventArgs());
            }
        }
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics printG = e.Graphics; //获得绘图对象 
            Font printFont = new System.Drawing.Font("宋体", 9);
            float yPosition = 0;
            float leftMargin = 0;
            float cH = printFont.GetHeight(printG);
            SolidBrush myBrush = new SolidBrush(Color.Black);//刷子

            printG.DrawString("      ", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("   Miss名店", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            yPosition += cH;
            yPosition += cH;
            printG.DrawString("**********欢迎光临**********", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("品名", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            printG.DrawString("数量", printFont, myBrush, leftMargin + 80, yPosition, new StringFormat());
            printG.DrawString("单价", printFont, myBrush, leftMargin + 110, yPosition, new StringFormat());
            printG.DrawString("金额", printFont, myBrush, leftMargin + 145, yPosition, new StringFormat());
            yPosition += cH;
            foreach (TXiaoshou x in _XSS)
            {
                string tiaoma = x.TTiaoma.tiaoma;
                string pinming = x.TTiaoma.pinming;
                short shuliang = x.shuliang;
                decimal danjia = x.danjia;
                decimal jine = decimal.Round(x.danjia * x.shuliang * x.zhekou / 10 - x.moliing, 2);
                printG.DrawString(tiaoma, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                printG.DrawString(shuliang.ToString(), printFont, myBrush, leftMargin + 90, yPosition, new StringFormat());
                printG.DrawString(danjia.ToString(), printFont, myBrush, leftMargin + 110, yPosition, new StringFormat());
                printG.DrawString(jine.ToString(), printFont, myBrush, leftMargin + 145, yPosition, new StringFormat());
                yPosition += cH;
                printG.DrawString(pinming, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                yPosition += cH;
            }
            printG.DrawString("_______________________________", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("小计", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            printG.DrawString(_XSS.Sum(x => x.danjia * x.shuliang).ToString("0.00"), printFont, myBrush, leftMargin + 135, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("优惠", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            printG.DrawString(_XSS.Sum(x => x.danjia * x.shuliang * (10 - x.zhekou) / 10 + x.moliing).ToString("0.00"), printFont, myBrush, leftMargin + 135, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("应付", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            printG.DrawString(_XSS.Sum(x => x.danjia * x.shuliang * x.zhekou / 10 - x.moliing).ToString("0.00"), printFont, myBrush, leftMargin + 135, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("交易时间", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            printG.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), printFont, myBrush, leftMargin + 65, yPosition, new StringFormat());

            e.HasMorePages = false;
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
            DateTime? dstart = dp_start.Checked ? (DateTime?)dp_start.Value.Date : null;
            DateTime? dend = dp_end.Checked ? (DateTime?)dp_end.Value.Date : null;

            //查询数据
            DBContext db= new DBContext();
            grid_xs.Rows.Clear();
            TXiaoshou[] xss = db.GetXiaoshousByCond(tmh, kh, dstart, dend);
            int tsl = 0;
            foreach (TXiaoshou x in xss)
            {
                tsl += x.shuliang;
                addXiaoshou(x);
            }

            //合計行
            //int index = grid_xs.Rows.Add();
            //grid_xs.Rows[index].Cells[col_tm.Name].Value = "合計";
            //grid_xs.Rows[index].Cells[col_sl.Name].Value = tsl;
            //grid_xs.Rows[index].DefaultCellStyle.ForeColor = Color.Red;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KucunYilan_Load(object sender, EventArgs e)
        {
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
                if (dx.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    xiaoshouDlgOK(dx.XSS, dx.Huiyuan);
                }
                _dlgKaidan = null;
        }

        /// <summary>
        /// 在grid中插入新的销售记录
        /// </summary>
        /// <param name="nxss"></param>
        private void addXiaoshou(TXiaoshou x)
        {
            grid_xs.Rows.Insert(0,new object[] 
            {
                x.id,
                x.TTiaoma.tiaoma,
                x.TTiaoma.kuanhao,
                x.TTiaoma.gyskuanhao,
                x.TTiaoma.pinming,
                x.TTiaoma.yanse,
                x.TTiaoma.chima,
                x.danjia,
                x.shuliang,
                x.zhekou,
                x.moliing,
                //价格
                (x.danjia*x.shuliang*(x.zhekou/10)-x.moliing).ToString("##.##"),
                //销售员
                x.xiaoshouyuan,
                x.xiaoshoushijian,
                x.shangbaoshijian
            });

            refreshTotal();
        }

        /// <summary>
        /// 刷新总数
        /// </summary>
        private void refreshTotal()
        {
            decimal tjg = 0;
            decimal tsl = 0;
            decimal tml = 0;
            foreach (DataGridViewRow dr in grid_xs.Rows)
            {
                decimal jg = decimal.Parse(dr.Cells[col_jg.Name].Value.ToString());
                decimal sl = decimal.Parse(dr.Cells[col_sl.Name].Value.ToString());
                decimal ml = decimal.Parse(dr.Cells[col_ml.Name].Value.ToString());
                tjg += jg;
                tsl += sl;
                tml += ml;
            }

            col_jg.HeaderText = "价格(" + tjg + ")";
            col_sl.HeaderText = "数量(" + tsl + ")";
            col_ml.HeaderText = "抹零(" + tml + ")";
        }

        /// <summary>
        /// 检查销售记录是否允许被删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_xs_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = (int)e.Row.Cells[col_id.Name].Value;

            DBContext db = new DBContext();
            TXiaoshou x = db.GetXiaoshouById(id);
            if (x.shangbaoshijian != null)
            {
                e.Cancel = true;
                MessageBox.Show("销售记录已经上报，不允许删除");
                return;
            }

            //检查是否会导致库存数量为负，因为有可能删除的是退货记录，销售数量为负数
            VKucun kc = db.GetKucunByTiaomaId(x.tiaomaid);
            if (kc.shuliang - x.shuliang < 0)
            {
                e.Cancel = true;
                MessageBox.Show("删除后会导致库存数量为负数");
                return;
            }
        }

        /// <summary>
        /// 删除一个销售记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_xs_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            int id = (int)e.Row.Cells[col_id.Name].Value;
            DBContext db = new DBContext();
            db.DeleteXiaoshou(id);

            //把会员积分减掉
            TXiaoshou x = db.GetXiaoshouById(id);
            if (x.huiyuanid != null)
            {
                decimal jf = 0 - decimal.Round(x.shuliang * x.danjia * x.zhekou / 10 - x.moliing, 2);
                db.UpdateHuiyuanJF(id, jf);
            }
        }

        /// <summary>
        /// 上报销售数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_shangbao_Click(object sender, EventArgs e)
        {

            DBContext db = new DBContext();
            //取得未上报的销售记录
            TXiaoshou[] xs = db.GetXiaoshousWeishangbao();
            if (xs.Count() == 0)
            {
                MessageBox.Show("没有需要上报的数据");
                return;
            }

            JCSJData.TXiaoshou[] jxss = xs.Select(r=>new JCSJData.TXiaoshou
            {
                oid = r.id,
                xiaoshoushijian = r.xiaoshoushijian,
                xiaoshouyuan = r.xiaoshouyuan,
                tiaomaid = r.tiaomaid,
                huiyuanid = r.huiyuanid,
                shuliang = r.shuliang,
                danjia = r.danjia,
                zhekou = r.zhekou,
                moling = r.moliing                
            }).ToArray();

            try
            {
                JCSJWCF.ShangbaoXiaoshou(jxss);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //更新本地上报时间
            int[] ids = xs.Select(r=>r.id).ToArray();
            db.UpdateXiaoshouShangbaoshijian(ids, DateTime.Now);

            MessageBox.Show("完成");
        }
    }
}
