using FDXS_Beta.Properties;
using RawInput_dll;
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

namespace FDXS_Beta
{
    public partial class Dlg_xiaoshou : Form
    {
        public List<TXiaoshou> Xses;

        public Dlg_xiaoshou(Int64? tiaoma)
        {
            InitializeComponent();
            Xses = new List<TXiaoshou>();
            gdv_kaidan.AutoGenerateColumns = false;

            if (tiaoma != null)
            {
                //扫描进来的条码
                addShangpin(tiaoma.Value);
            }
        }        

        /// <summary>
        /// 往开单中加入一个商品
        /// </summary>
        /// <param name="tiaoma"></param>
        public void addShangpin(long tiaoma)
        {
            gdv_kaidan.EndEdit();

            FDB_BetaEntities _en = new FDB_BetaEntities();
            //搜索数据库
            TJintuimingxi t = _en.TJintuimingxi.SingleOrDefault(r => r.tiaoma == tiaoma && r.TJintuihuo.jintui == true);
            if (t == null)
            {

                MessageBox.Show("条码"+tiaoma+"不存在");
                return;
            }


            //检查是否已加入开单
            TXiaoshou tx = Xses.SingleOrDefault(r => r.TJintuimingxi.id == t.id);
            if (tx != null)
            {
                tx.shuliang++;
            }
            else
            {
                //加入开单
                TXiaoshou x = new TXiaoshou
                {
                    shangpinid = t.id,
                    TJintuimingxi = t,
                    danjia = t.shoujia,
                    shuliang = 1,
                    zhekou = 10,
                    moling = 0,
                    charushijian = DateTime.Now
                };
                Xses.Add(x);
            }

            shuaxinGrid();
            shuaxinZongjia();
        }

        private void gdv_kaidan_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //取得条码
            DataGridViewRow dgr = gdv_kaidan.SelectedRows[0];
            long tiaoma = (long)dgr.Cells[1].Value;
            //从缓存移除
            Xses.Remove(Xses.Single(r => r.TJintuimingxi.tiaoma == tiaoma));
            //刷新grid
            //shuaxinGrid();
            //刷新总价
            shuaxinZongjia();
        }

        private void shuaxinGrid()
        {

            gdv_kaidan.DataSource = Tool.LINQToDataTable(Xses.Select(r => new
            {
                tiaoma = r.TJintuimingxi.tiaoma,
                kuanhao = r.TJintuimingxi.kuanhao,
                pinming = r.TJintuimingxi.pinming,
                yanse = r.TJintuimingxi.yanse,
                chima = r.TJintuimingxi.chima,
                danjia = r.danjia,
                shuliang = r.shuliang,
                zhekou = r.zhekou,
                moling = r.moling,
                yingshou = decimal.Round(r.danjia * r.shuliang * r.zhekou / 10 - r.moling, 2)
            }));

        }


        /// <summary>
        /// 确定开单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FDB_BetaEntities _en = new FDB_BetaEntities();
            txb_tiaoma.Focus();

            //检查行数
            if (Xses.Count == 0)
            {
                return;
            }

            //保存入数据库
            var xss = Xses.Select(x => new TXiaoshou 
            {
                shangpinid = x.shangpinid,
                danjia = x.danjia,
                shuliang = x.shuliang,
                zhekou = x.zhekou,
                moling = x.moling,
                charushijian = DateTime.Now
            });
            _en.TXiaoshou.AddRange(xss);

            _en.SaveChanges();

            //打印小票
            xiaopiao();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            Font printFont = this.lbl_printflg.Font;
            float yPosition = 0;
            float leftMargin = 0;
            float cH = printFont.GetHeight(printG);
            SolidBrush myBrush = new SolidBrush(Color.Black);//刷子

            printG.DrawString("      ", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("   Miss名店", label14.Font, myBrush, leftMargin, yPosition, new StringFormat());
            yPosition += cH;
            yPosition += cH;
            printG.DrawString("**********欢迎光临**********", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("品名", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            printG.DrawString("数量", printFont, myBrush, leftMargin+80, yPosition, new StringFormat());
            printG.DrawString("单价", printFont, myBrush, leftMargin + 110, yPosition, new StringFormat());
            printG.DrawString("金额", printFont, myBrush, leftMargin + 145, yPosition, new StringFormat());
            yPosition += cH;
            foreach (DataGridViewRow r in gdv_kaidan.Rows)
            {
                string tiaoma = r.Cells[1].Value.ToString();
                string pinming = r.Cells[3].Value.ToString();
                string shuliang = r.Cells[6].Value.ToString();
                string danjia = ((decimal)r.Cells[7].Value).ToString("0");
                string jine = r.Cells[10].Value.ToString();
                printG.DrawString(tiaoma, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                printG.DrawString(shuliang, printFont, myBrush, leftMargin + 90, yPosition, new StringFormat());
                printG.DrawString(danjia, printFont, myBrush, leftMargin + 110, yPosition, new StringFormat());
                printG.DrawString(jine, printFont, myBrush, leftMargin + 145, yPosition, new StringFormat());
                yPosition += cH;
                printG.DrawString(pinming, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                yPosition += cH;
            }
            printG.DrawString("_______________________________", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("小计", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            printG.DrawString(Xses.Sum(x => x.danjia * x.shuliang).ToString("0.00"), printFont, myBrush, leftMargin + 135, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("优惠", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            printG.DrawString(Xses.Sum(x => x.danjia * x.shuliang * (10 - x.zhekou) / 10 + x.moling).ToString("0.00"), printFont, myBrush, leftMargin + 135, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("应付", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            printG.DrawString(lbl_zongjia.Text, printFont, myBrush, leftMargin + 135, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("交易时间", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            printG.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), printFont, myBrush, leftMargin + 65, yPosition, new StringFormat());

            e.HasMorePages = false;
        }

        public int stringL(string Text)
        {
            int len = 0;
            for (int i = 0; i < Text.Length; i++)
            {
                byte[] byte_len = System.Text.Encoding.Default.GetBytes(Text.Substring(i, 1));
                if (byte_len.Length > 1)
                    len += 2;  //如果长度大于1，是中文，占两个字节，+2
                else
                    len++;
            }
            return len;
        }

        private void gdv_kaidan_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgr = gdv_kaidan.SelectedRows[0];
            long tiaoma = (long)dgr.Cells[1].Value;


            //重新计算价格
            short shuliang = (short)dgr.Cells[6].Value;
            decimal danjia = (decimal)dgr.Cells[7].Value;
            decimal zhekou = (decimal)dgr.Cells[8].Value;
            decimal moling = (decimal)dgr.Cells[9].Value;
            dgr.Cells[10].Value = decimal.Round(shuliang * danjia * zhekou / 10 - moling, 2);

            //存入变量
            Xses.Single(x => x.TJintuimingxi.tiaoma == tiaoma).shuliang = shuliang;
            Xses.Single(x => x.TJintuimingxi.tiaoma == tiaoma).danjia = danjia;
            Xses.Single(x => x.TJintuimingxi.tiaoma == tiaoma).zhekou = zhekou;
            Xses.Single(x => x.TJintuimingxi.tiaoma == tiaoma).moling = moling;

            //刷新总价
            shuaxinZongjia();

            txb_tiaoma.Focus();
        }

        /// <summary>
        /// 输入收钱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_shishou_TextChanged(object sender, EventArgs e)
        {
            shuaxinZongjia();
        }

        private void shuaxinZongjia()
        {
            decimal zongjia = Xses.Sum(x => decimal.Round(x.shuliang * x.danjia * x.zhekou / 10 - x.moling, 2));
            lbl_zongjia.Text = zongjia.ToString();
            decimal ss;
            if (decimal.TryParse(txb_shishou.Text.Trim(), out ss))
            {
                lbl_zhaoling.Text = (ss - zongjia).ToString();
            }
            else
            {
                lbl_zhaoling.Text = "";
            }
        }


        /// <summary>
        /// 折扣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_zhekou_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                decimal zhekou = 0;
                if (!decimal.TryParse(txb_zhekou.Text.Trim(), out zhekou))
                {
                    MessageBox.Show("折扣只能是数字");
                    return;
                }

                Xses.ForEach(x => x.zhekou = zhekou);

                shuaxinGrid();
                shuaxinZongjia();
            }
        }

        /// <summary>
        /// 输入条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_tiaoma_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\r')
            {
                Int64 tiaoma = 0;
                if (!Int64.TryParse(txb_tiaoma.Text.Trim(), out tiaoma))
                {
                    MessageBox.Show("条码只能是数字");
                    return;
                }

                addShangpin(tiaoma);
            }
        }

        /// <summary>
        /// 抹零小数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //将总价的零头在第一行抹去
            decimal zongjia = Xses.Sum(r => r.danjia * r.shuliang * r.zhekou / 10);

            decimal lingtou = zongjia-Math.Truncate(zongjia);
            Xses.First().moling = lingtou;

            txb_tiaoma.Focus();

            shuaxinGrid();
            shuaxinZongjia();
        }

        private void gdv_kaidan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("输入错误，请重新输入");
            e.ThrowException = false;
        }

        /// <summary>
        /// 8折快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Xses.ForEach(x => x.zhekou = 8);
            txb_tiaoma.Focus();

            shuaxinGrid();
            shuaxinZongjia();
        }

        /// <summary>
        /// 85折
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Xses.ForEach(x => x.zhekou = 8.5M);
            txb_tiaoma.Focus();

            shuaxinGrid();
            shuaxinZongjia();
        }

        private void Dlg_xiaoshou_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        /// <summary>
        /// 关闭前清除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_xiaoshou_FormClosing(object sender, FormClosingEventArgs e)
        {
            txb_tiaoma.Text = "";
            txb_shishou.Text = "";
            Xses.Clear();
            shuaxinGrid();
            shuaxinZongjia();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Xses.ForEach(x => x.zhekou = 7);
            txb_tiaoma.Focus();

            shuaxinGrid();
            shuaxinZongjia();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Xses.ForEach(x => x.zhekou = 7.5M);
            txb_tiaoma.Focus();

            shuaxinGrid();
            shuaxinZongjia();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //将总价的零头在第一行抹去
            decimal zongjia = Xses.Sum(r => r.danjia * r.shuliang * r.zhekou / 10);

            decimal lingtou = zongjia % 10;
            Xses.First().moling = lingtou;

            txb_tiaoma.Focus();

            shuaxinGrid();
            shuaxinZongjia();
        }
    }
}