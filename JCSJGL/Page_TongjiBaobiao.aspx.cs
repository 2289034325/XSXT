using DB_JCSJ;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Tool;

namespace JCSJGL
{
    public partial class Page_TongjiBaobiao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //初始化分店下拉框
                DBContext db = new DBContext();
                TFendian[] fs = db.GetFendians();
                Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
                cmb_fd.Items.Insert(0,"");

                //日期
                txb_xsrq_start.Text = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                txb_xsrq_end.Text = DateTime.Now.ToString("yyyy-MM-dd");

                //图表类型下拉框
                //cmb_ctype.DataSource = new string[] { "销售量", "销售额", "利润" };
                cmb_ctype.Items.Add(new ListItem("销售量", "销售量"));
                cmb_ctype.Items.Add(new ListItem("销售额", "销售额"));
                cmb_ctype.Items.Add(new ListItem("利润", "利润"));
            }
        }
        

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sch_Click(object sender, EventArgs e)
        {
            search();           
        }

        private void search()
        {
            //取查询条件
            int? fdid = null;
            if (!string.IsNullOrEmpty(cmb_fd.SelectedValue))
            {
                fdid = int.Parse(cmb_fd.SelectedValue);
            }
            DateTime? xsrq_start = null;
            DateTime? xsrq_end = null;
            if (!string.IsNullOrEmpty(txb_xsrq_start.Text.Trim()))
            {
                xsrq_start = DateTime.Parse(txb_xsrq_start.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txb_xsrq_end.Text.Trim()))
            {
                xsrq_end = DateTime.Parse(txb_xsrq_end.Text.Trim());
            }

            DBContext db = new DBContext();
            int recordCount = 0;
            TXiaoshou[] xss = db.GetXiaoshousByCond(fdid, xsrq_start, xsrq_end, null, null, null, null, out recordCount);

            //图表类型
            DataTable dt_date = new DataTable();
            DataTable dt_hour = new DataTable();
            DataTable dt_week = new DataTable();

            if (cmb_ctype.SelectedValue == "销售量")
            {
                var d_date = xss.GroupBy(r => r.xiaoshoushijian.Date).
                    Select(r => new { X = r.Key, Y = r.Sum(rx => rx.shuliang) }).OrderBy(r => r.X).ToList();
                var d_hour = xss.GroupBy(r => new { date = r.xiaoshoushijian.Date, hour = r.xiaoshoushijian.Hour }).
                Select(r => new
                {
                    Xd = r.Key.date,
                    X = r.Key.hour,
                    Y = r.Sum(rx => rx.shuliang)
                }).GroupBy(r => r.X).
                Select(r => new { X = r.Key, Y = Math.Round(r.Average(rr => rr.Y), 2) }).
                OrderBy(r => r.X).ToList();
                var d_week = xss.GroupBy(r => r.xiaoshoushijian.Date).
                Select(r => new
                {
                    wn = r.Key.DayOfWeek.ToString(),
                    ws = (int)r.Key.DayOfWeek,
                    Y = r.Sum(rx => rx.shuliang)
                }).GroupBy(r => new { r.wn, r.ws }).
                Select(r => new { X = r.Key.wn, xn = r.Key.ws, Y = Math.Round(r.Average(rr => rr.Y), 2) }).
                OrderBy(r => r.xn).ToList();

                dt_date = Tool.CommonFunc.LINQToDataTable(d_date);
                dt_hour = Tool.CommonFunc.LINQToDataTable(d_hour);
                dt_week = Tool.CommonFunc.LINQToDataTable(d_week);
            }
            else if (cmb_ctype.SelectedValue == "销售额")
            {
                var d_date = xss.GroupBy(r => r.xiaoshoushijian.Date).
                    Select(r => new { X = r.Key, Y = Math.Round(r.Sum(rx => rx.jine)??0,2) }).OrderBy(r => r.X).ToList();
                var d_hour = xss.GroupBy(r => new { date = r.xiaoshoushijian.Date, hour = r.xiaoshoushijian.Hour }).
                Select(r => new
                {
                    Xd = r.Key.date,
                    X = r.Key.hour,
                    Y = r.Sum(rx => rx.jine)??0
                }).GroupBy(r => r.X).
                Select(r => new { X = r.Key, Y = Math.Round(r.Average(rr => rr.Y),2) }).
                OrderBy(r => r.X).ToList();
                var d_week = xss.GroupBy(r => r.xiaoshoushijian.Date).
                Select(r => new
                {
                    wn = r.Key.DayOfWeek.ToString(),
                    ws = (int)r.Key.DayOfWeek,
                    Y = r.Sum(rx => rx.jine)??0
                }).GroupBy(r => new { r.wn, r.ws }).
                Select(r => new { X = r.Key.wn, xn = r.Key.ws, Y = Math.Round(r.Average(rr => rr.Y), 2) }).
                OrderBy(r => r.xn).ToList();

                dt_date = Tool.CommonFunc.LINQToDataTable(d_date);
                dt_hour = Tool.CommonFunc.LINQToDataTable(d_hour);
                dt_week = Tool.CommonFunc.LINQToDataTable(d_week);
            }
            else if (cmb_ctype.SelectedValue == "利润")
            {
                var d_date = xss.GroupBy(r => r.xiaoshoushijian.Date).
                    Select(r => new { X = r.Key, Y = Math.Round(r.Sum(rx => rx.jine - rx.TTiaoma.jinjia)??0,2) }).OrderBy(r => r.X).ToList();
                var d_hour = xss.GroupBy(r => new { date = r.xiaoshoushijian.Date, hour = r.xiaoshoushijian.Hour }).
                Select(r => new
                {
                    Xd = r.Key.date,
                    X = r.Key.hour,
                    Y = r.Sum(rx => rx.jine - rx.TTiaoma.jinjia)??0
                }).GroupBy(r => r.X).
                Select(r => new { X = r.Key, Y =  Math.Round(r.Average(rr => rr.Y),2) }).
                OrderBy(r => r.X).ToList();
                var d_week = xss.GroupBy(r => r.xiaoshoushijian.Date).
                Select(r => new
                {
                    wn = r.Key.DayOfWeek.ToString(),
                    ws = (int)r.Key.DayOfWeek,
                    Y = r.Sum(rx => rx.jine - rx.TTiaoma.jinjia)??0
                }).GroupBy(r => new { r.wn, r.ws }).
                Select(r => new { X = r.Key.wn, xn = r.Key.ws, Y = Math.Round(r.Average(rr => rr.Y), 1) }).
                OrderBy(r => r.xn).ToList();

                dt_date = Tool.CommonFunc.LINQToDataTable(d_date);
                dt_hour = Tool.CommonFunc.LINQToDataTable(d_hour);
                dt_week = Tool.CommonFunc.LINQToDataTable(d_week);
            }

            //设置图表属性
            int wndWidth = int.Parse(hid_windowWidth.Value);
            cht_date.Width = Convert.ToInt32(wndWidth);
            cht_date.Series.Clear();
            cht_date.ChartAreas.Clear();
            cht_date.ChartAreas.Add("A1");
            cht_date.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Days;
            cht_date.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            cht_date.ChartAreas[0].AxisX.LabelStyle.Format = "MM-dd";
            Series js = cht_date.Series.Add("S1");
            js.IsVisibleInLegend = false;
            js.ToolTip = "#VAL";
            js.ChartType = SeriesChartType.Column;
            js.Points.DataBind(dt_date.AsEnumerable(), "X", "Y", "");

            cht_hour.Width = Convert.ToInt32(wndWidth);
            cht_hour.Series.Clear();
            cht_hour.ChartAreas.Clear();
            cht_hour.ChartAreas.Add("A1");
            Series xs = cht_hour.Series.Add("S1");
            xs.IsVisibleInLegend = false;
            xs.ToolTip = "#VAL";
            xs.ChartType = SeriesChartType.Column;
            cht_hour.ChartAreas[0].AxisX.Interval = 1;
            xs.Points.DataBind(dt_hour.AsEnumerable(), "X", "Y", "");

            cht_week.Width = Convert.ToInt32(wndWidth);
            cht_week.Series.Clear();
            cht_week.ChartAreas.Clear();
            cht_week.ChartAreas.Add("A1");
            Series ws = cht_week.Series.Add("S1");
            ws.IsVisibleInLegend = false;
            ws.ToolTip = "#VAL";
            ws.ChartType = SeriesChartType.Column;
            ws.Points.DataBind(dt_week.AsEnumerable(), "X", "Y", "");
        }

    }
}