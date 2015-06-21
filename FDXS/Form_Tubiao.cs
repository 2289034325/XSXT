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
using System.Windows.Forms.DataVisualization.Charting;
using Tool;

namespace FDXS
{
    public partial class Form_Tubiao : MyForm
    {
        public Form_Tubiao()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 刷新图表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_shuaxin_Click(object sender, EventArgs e)
        {
            //取数据
            DBContext db = IDB.GetDB();
            TXiaoshou[] xss = db.GetXiaoshousByCond(null,null,null,null);
            var ddata_s = xss.GroupBy(r => r.charushijian.Date).
                Select(r => new { X = r.Key, Y = r.Sum(rx => rx.shuliang) }).OrderBy(r => r.X).ToList();
            var ddata_j = xss.GroupBy(r => r.charushijian.Date).
                Select(r => new
                {
                    X = r.Key,
                    Y = r.Sum(rx => decimal.Round(rx.danjia * rx.shuliang * rx.zhekou / 10 - rx.moliing, 2))
                }).OrderBy(r => r.X).ToList();

            var xdata_s = xss.GroupBy(r => new { date = r.charushijian.Date, hour = r.charushijian.Hour }).
                Select(r => new
                {
                    Xd = r.Key.date,
                    X = r.Key.hour,
                    Y = r.Sum(rx => rx.shuliang)
                }).GroupBy(r => r.X).
                Select(r => new { X = r.Key, Y = Math.Round(r.Average(rr => rr.Y),1) }).
                OrderBy(r => r.X).ToList();
            var xdata_j = xss.GroupBy(r => new { date = r.charushijian.Date, hour = r.charushijian.Hour }).
                Select(r => new
                {
                    Xd = r.Key.date,
                    X = r.Key.hour,
                    Y = r.Sum(rx => decimal.Round(rx.danjia * rx.shuliang * rx.zhekou / 10 - rx.moliing, 2))
                }).GroupBy(r => r.X).
                Select(r => new { X = r.Key, Y = Math.Round(r.Average(rr => rr.Y),1) }).
                OrderBy(r => r.X).ToList();

            var wdata_s = xss.GroupBy(r => r.charushijian.Date).
                Select(r => new
                {
                    wn = r.Key.DayOfWeek.ToString(),
                    ws = (int)r.Key.DayOfWeek,
                    Y = r.Sum(rx => rx.shuliang)
                }).GroupBy(r => new { r.wn, r.ws }).
                Select(r => new { X = r.Key.wn, xn = r.Key.ws, Y = Math.Round(r.Average(rr => rr.Y),1) }).
                OrderBy(r => r.xn).ToList();
            var wdata_j = xss.GroupBy(r => r.charushijian.Date).
                 Select(r => new
                 {
                     wn = r.Key.DayOfWeek.ToString(),
                     ws = (int)r.Key.DayOfWeek,
                     Y = r.Sum(rx => decimal.Round(rx.danjia * rx.shuliang * rx.zhekou / 10 - rx.moliing, 2))
                 }).GroupBy(r => new { r.wn, r.ws }).
                Select(r => new { X = r.Key.wn, xn = r.Key.ws, Y = Math.Round(r.Average(rr => rr.Y),1) }).
                OrderBy(r => r.xn).ToList();

            DataTable ddt, xdt, wdt;
            if (cmb_leixing.Text == "件数")
            {
                ddt = Tool.CommonFunc.LINQToDataTable(ddata_s);
                xdt = Tool.CommonFunc.LINQToDataTable(xdata_s);
                wdt = Tool.CommonFunc.LINQToDataTable(wdata_s);
            }
            else
            {
                ddt = Tool.CommonFunc.LINQToDataTable(ddata_j);
                xdt = Tool.CommonFunc.LINQToDataTable(xdata_j);
                wdt = Tool.CommonFunc.LINQToDataTable(wdata_j);
            }

            //做报表
            cht_meiri.Series.Clear();
            cht_meiri.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Days;
            cht_meiri.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            cht_meiri.ChartAreas[0].AxisX.LabelStyle.Format = "MM-dd";
            Series js = cht_meiri.Series.Add("S1");
            js.IsVisibleInLegend = false;
            js.ToolTip = "#VAL";
            js.ChartType = SeriesChartType.Column;
            js.Points.DataBind(ddt.AsEnumerable(), "X", "Y", "");

            //小时报表
            cht_xiaoshi.Series.Clear();
            Series xs = cht_xiaoshi.Series.Add("S1");
            xs.IsVisibleInLegend = false;
            xs.ToolTip = "#VAL";
            xs.ChartType = SeriesChartType.Column;
            cht_xiaoshi.ChartAreas[0].AxisX.Interval = 1;
            xs.Points.DataBind(xdt.AsEnumerable(), "X", "Y", "");


            //星期报表
            cht_xingqi.Series.Clear();
            Series ws = cht_xingqi.Series.Add("S1");
            ws.IsVisibleInLegend = false;
            ws.ToolTip = "#VAL";
            ws.ChartType = SeriesChartType.Column;
            ws.Points.DataBind(wdt.AsEnumerable(), "X", "Y", "");
        }
    }
}
