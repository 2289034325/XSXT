using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Tool;

namespace JCSJGL
{
    public partial class Page_Fendian_TongjiTu : MyPage
    {
        public Page_Fendian_TongjiTu()
        {
            _PageName = PageName.分店销售统计图;
        }
        private enum CHART_Y_TYPE:byte
        {
            销售量 = 1,
            销售额 = 2,
            利润 = 3
        }
        private enum CHART_X_TYPE:byte
        {
            月份=7,
            日期=1,
            小时=2,
            星期=3
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DBContext db = new DBContext();

                TFendian[] fs = null;
                //初始化分店下拉框
                int? jmsid = null;
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    //显示搜索
                    div_sch_jms.Visible = true;

                    //品牌商
                    TJiamengshang[] jmss = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmss, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有品牌商", ""));

                    //加盟商
                    Tool.CommonFunc.InitDropDownList(cmb_zjms, jmss, "mingcheng", "id");
                    cmb_zjms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    //分店
                    if (Request["jmsid"] != null)
                    {
                        cmb_zjms.SelectedValue = Request["jmsid"];
                        TFendian[] zyds = db.GetFendiansAsItems(jmsid.Value);
                    }
                    else
                    {
                        fs = new TFendian[] { };
                    }
                }
                else
                {
                    //显示搜索
                    div_sch_jms.Visible = false;
                    jmsid = _LoginUser.jmsid;
                    //加载子加盟商，包括自己
                    TJiamengshangGX[] zjmsgxes = db.GetZiJiamengshangGXes(jmsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_zjms, zjmsgxes, "bzmingcheng", "jmsid");
                    cmb_zjms.Items.Insert(0, new ListItem(_LoginUser.TJiamengshang.mingcheng, _LoginUser.jmsid.ToString()));
                    cmb_zjms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    //加载所有的直营店和加盟分店
                    TFendian[] zyds = db.GetFendiansAsItems(jmsid);
                    TFendian[] jmds = db.GetFendiansOfPinpaiAsItems(jmsid.Value);
                    fs = zyds.Concat(jmds).ToArray();

                    if (_LoginUser.TJiamengshang.zjmsshu <= 0)
                    {
                        div_sch_zjms.Visible = false;
                    }
                    else
                    {
                        div_sch_zjms.Visible = true;
                    }
                }

                Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
                cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));

                //日期
                txb_xsrq_start.Text = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                txb_xsrq_end.Text = DateTime.Now.ToString("yyyy-MM-dd");

                //图表类型下拉框
                //cmb_ctype.DataSource = new string[] { "销售量", "销售额", "利润" };
                cmb_y.Items.Add(new ListItem(CHART_Y_TYPE.销售量.ToString(), ((byte)CHART_Y_TYPE.销售量).ToString()));
                cmb_y.Items.Add(new ListItem(CHART_Y_TYPE.销售额.ToString(), ((byte)CHART_Y_TYPE.销售额).ToString()));
                cmb_y.Items.Add(new ListItem(CHART_Y_TYPE.利润.ToString(), ((byte)CHART_Y_TYPE.利润).ToString()));

                chk_x.Items.Add(new ListItem(CHART_X_TYPE.月份.ToString(), ((byte)CHART_X_TYPE.月份).ToString()));
                chk_x.Items.Add(new ListItem(CHART_X_TYPE.日期.ToString(), ((byte)CHART_X_TYPE.日期).ToString()));
                chk_x.Items.Add(new ListItem(CHART_X_TYPE.小时.ToString(), ((byte)CHART_X_TYPE.小时).ToString()));
                chk_x.Items.Add(new ListItem(CHART_X_TYPE.星期.ToString(), ((byte)CHART_X_TYPE.星期).ToString()));

                chk_x.Items[0].Selected = true;
                chk_x.Items[1].Selected = true;
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
            //取数据
            TXiaoshou[] xss = getXiaoshouData();
            if (xss.Count() == 0)
            {
                div_charts.InnerHtml = "<div style='color:red;font-size:20px;position:relative;top:200px;text-align:center;'>指定条件内没有销售数据<div>";
                return;
            }
            else
            {
                div_charts.InnerHtml = "";
            }
            List<byte> xTypes = getXTypes();

            if (xTypes.Contains((byte)CHART_X_TYPE.月份))
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Controls.Add(makeMonthChart(xss));
                div_charts.Controls.Add(div);
            }

            if (xTypes.Contains((byte)CHART_X_TYPE.日期))
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Controls.Add(makeDateChart(xss));
                div_charts.Controls.Add(div);                
            }
            if (xTypes.Contains((byte)CHART_X_TYPE.小时))
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Controls.Add(makeHourChart(xss));
                div_charts.Controls.Add(div);
            }
            if (xTypes.Contains((byte)CHART_X_TYPE.星期))
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Controls.Add(makeWeekChart(xss));
                div_charts.Controls.Add(div);
            }
        }

        private Chart makeWeekChart(TXiaoshou[] xss)
        {
            DateTime startDate = xss.Min(r => r.xiaoshoushijian);
            DateTime endDate = xss.Max(r => r.xiaoshoushijian);

            byte yType = byte.Parse(cmb_y.SelectedValue);
            DataTable dt = new DataTable();
            if (yType == (byte)CHART_Y_TYPE.销售量)
            {
                var data = xss.GroupBy(r => r.xiaoshoushijian.Date).
                    Select(r => new
                    {
                        wn = r.Key.DayOfWeek.ToString(),
                        ws = (int)r.Key.DayOfWeek,
                        Y = r.Sum(rx => rx.shuliang)
                    }).GroupBy(r => new { r.wn, r.ws }).
                    Select(r => new
                    {
                        X = r.Key.wn,
                        xn = r.Key.ws,
                        //Y = Math.Round(r.Average(rr => rr.Y), 2)
                        Y = decimal.Round(r.Sum(rr=>rr.Y)/getWCountInTimeSpan(startDate,endDate,r.Key.ws), 2)
                    }).OrderBy(r => r.xn).ToList();

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.销售额)
            {
                var data = xss.GroupBy(r => r.xiaoshoushijian.Date).
                    Select(r => new
                    {
                        wn = r.Key.DayOfWeek.ToString(),
                        ws = (int)r.Key.DayOfWeek,
                        Y = r.Sum(rx => rx.jine)
                    }).GroupBy(r => new { r.wn, r.ws }).
                    Select(r => new
                    {
                        X = r.Key.wn,
                        xn = r.Key.ws,
                        //Y = Math.Round(r.Average(rr => rr.Y), 2)
                        Y = decimal.Round(r.Sum(rr => rr.Y) / getWCountInTimeSpan(startDate, endDate, r.Key.ws), 2)
                    }).OrderBy(r => r.xn).ToList();

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.利润)
            {
                var data = xss.GroupBy(r => r.xiaoshoushijian.Date).
                    Select(r => new
                    {
                        wn = r.Key.DayOfWeek.ToString(),
                        ws = (int)r.Key.DayOfWeek,
                        //Y = r.Sum(rx => rx.TTiaoma == null ? (rx.jine / 2) : rx.jine - rx.TTiaoma.jinjia * rx.shuliang)
                        Y = r.Sum(rx => rx.lirun)
                    }).GroupBy(r => new { r.wn, r.ws }).
                    Select(r => new
                    {
                        X = r.Key.wn,
                        xn = r.Key.ws,
                        //Y = Math.Round(r.Average(rr => rr.Y), 1)
                        Y = decimal.Round(r.Sum(rr => rr.Y) / getWCountInTimeSpan(startDate, endDate, r.Key.ws), 2)
                    }).OrderBy(r => r.xn).ToList();

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }

            Chart cht = new Chart();

            int wndWidth = int.Parse(hid_windowWidth.Value);
            cht.Width = Convert.ToInt32(wndWidth);
            cht.Series.Clear();
            cht.ChartAreas.Clear();
            cht.ChartAreas.Add("A1");
            Series ws = cht.Series.Add("S1");
            ws.IsVisibleInLegend = false;
            ws.ToolTip = "#VAL";
            ws.ChartType = SeriesChartType.Column;
            ws.Points.DataBind(dt.AsEnumerable(), "X", "Y", "");

            return cht;
        }

        /// <summary>
        /// 计算一个时间段之内，有多少个星期几
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private decimal getWCountInTimeSpan(DateTime startDate, DateTime endDate, int w)
        {
            decimal c = 0;
            for (DateTime dt = startDate.Date; dt <= endDate.Date; dt=dt.AddDays(1))
            {
                if ((int)dt.DayOfWeek == w)
                {
                    c++;
                }
            }

            return c;
        }

        private Chart makeHourChart(TXiaoshou[] xss)
        {
            DateTime startDate = xss.Min(r => r.xiaoshoushijian);
            DateTime endDate = xss.Max(r => r.xiaoshoushijian);
            decimal div = (endDate - startDate).Days + 1;

            byte yType = byte.Parse(cmb_y.SelectedValue);
            DataTable dt = new DataTable();
            if (yType == (byte)CHART_Y_TYPE.销售量)
            {
                var data = xss.GroupBy(r => new { hour = r.xiaoshoushijian.Hour }).
                   Select(r => new
                   {
                       X = r.Key.hour,
                       Y = r.Sum(rx => rx.shuliang)
                   }).GroupBy(r => r.X).
                   Select(r => new
                   {
                       X = r.Key,
                       Y = decimal.Round(r.Sum(rr => rr.Y) / div, 2)
                   }).OrderBy(r => r.X).ToList();

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.销售额)
            {
                var data = xss.GroupBy(r => new { date = r.xiaoshoushijian.Date, hour = r.xiaoshoushijian.Hour }).
                   Select(r => new
                   {
                       Xd = r.Key.date,
                       X = r.Key.hour,
                       Y = r.Sum(rx => rx.jine)
                   }).GroupBy(r => r.X).
                   Select(r => new
                   {
                       X = r.Key,                    
                       Y = decimal.Round(r.Sum(rr => rr.Y) / div, 2)
                   }).OrderBy(r => r.X).ToList();

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.利润)
            {
                var data = xss.GroupBy(r => new { date = r.xiaoshoushijian.Date, hour = r.xiaoshoushijian.Hour }).
                Select(r => new
                {
                    Xd = r.Key.date,
                    X = r.Key.hour,
                    //Y = r.Sum(rx => rx.TTiaoma == null ? (rx.jine / 2) : rx.jine - rx.TTiaoma.jinjia * rx.shuliang)
                    Y = r.Sum(rx => rx.lirun)
                }).GroupBy(r => r.X).
                Select(r => new
                {
                    X = r.Key,
                    Y = decimal.Round(r.Sum(rr => rr.Y) / div, 2)
                }).OrderBy(r => r.X).ToList();

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }

            Chart cht = new Chart();

            int wndWidth = int.Parse(hid_windowWidth.Value);
            cht.Width = wndWidth;
            cht.Series.Clear();
            cht.ChartAreas.Clear();
            cht.ChartAreas.Add("A1");
            Series xs = cht.Series.Add("S1");
            xs.IsVisibleInLegend = false;
            xs.ToolTip = "#VAL";
            xs.ChartType = SeriesChartType.Column;
            cht.ChartAreas[0].AxisX.Interval = 1;
            xs.Points.DataBind(dt.AsEnumerable(), "X", "Y", "");

            return cht;
        }

        private Chart makeDateChart(TXiaoshou[] xss)
        {
            //取得要统计的图表Y类型
            byte yType = byte.Parse(cmb_y.SelectedValue);
            DataTable dt = new DataTable();
            if (yType == (byte)CHART_Y_TYPE.销售量)
            {
                var data = xss.GroupBy(r => r.xiaoshoushijian.Date).
                           Select(r => new { X = r.Key, Y = r.Sum(rx => rx.shuliang) }).OrderBy(r => r.X).ToList();
                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.销售额)
            {
                var data = xss.GroupBy(r => r.xiaoshoushijian.Date).
                    Select(r => new { X = r.Key, Y = Math.Round(r.Sum(rx => rx.jine), 2) }).OrderBy(r => r.X).ToList();
                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.利润)
            {
                var data = xss.GroupBy(r => r.xiaoshoushijian.Date).
                    Select(r => new
                    {
                        X = r.Key,
                        //Y = Math.Round(r.Sum(rx => rx.TTiaoma == null ? (rx.jine / 2) : rx.jine - rx.TTiaoma.jinjia * rx.shuliang), 2)
                        Y = decimal.Round(r.Sum(rx => rx.lirun),2)
                    }).OrderBy(r => r.X).ToList();
                dt = Tool.CommonFunc.LINQToDataTable(data); 
            }

            Chart cht = new Chart();
            
            int wndWidth = int.Parse(hid_windowWidth.Value);
            cht.Width = wndWidth;
            cht.Series.Clear();
            cht.ChartAreas.Clear();
            cht.ChartAreas.Add("A1");
            cht.ChartAreas[0].AxisX.LabelStyle.Format = "MM-dd";
            Legend ptl = cht.Legends.Add("L1");
            ptl.Docking = Docking.Bottom;
            ptl.Alignment = System.Drawing.StringAlignment.Center;
            Series js = cht.Series.Add("S1");
            //js.IsVisibleInLegend = false;
            js.ToolTip = "#VAL";
            js.ChartType = SeriesChartType.Column;

            LegendCellColumn totalColumn = new LegendCellColumn();
            totalColumn.Text = "#TOTAL";
            totalColumn.HeaderText = "总计";
            totalColumn.Name = "TotalColumn";
            ptl.CellColumns.Add(totalColumn);
            LegendCellColumn avgColumn = new LegendCellColumn();
            avgColumn.Text = "#AVG{N2}";
            avgColumn.HeaderText = "平均";
            avgColumn.Name = "AvgColumn";
            ptl.CellColumns.Add(avgColumn);

            js.Points.DataBind(dt.AsEnumerable(), "X", "Y", "");

            return cht;
        }

        private Chart makeMonthChart(TXiaoshou[] xss)
        {
            //取得要统计的图表Y类型
            byte yType = byte.Parse(cmb_y.SelectedValue);
            DataTable dt = new DataTable();
            DataTable dt_s = new DataTable();
            DataTable dt_z = new DataTable();
            DataTable dt_x = new DataTable();
            if (yType == (byte)CHART_Y_TYPE.销售量)
            {
                var data = xss.Select(r => new { r.shuliang, month = new DateTime(r.xiaoshoushijian.Year,r.xiaoshoushijian.Month,1), xun = getXun(r.xiaoshoushijian) }).
                    GroupBy(r => new { r.month, r.xun }).Select(r => new { X = r.Key.month, r.Key.xun, Y = r.Sum(rx => rx.shuliang) }).
                    OrderBy(r => r.X).OrderBy(r => r.xun).ToList();
                dt = Tool.CommonFunc.LINQToDataTable(data);
                dt_s = Tool.CommonFunc.LINQToDataTable(data.Where(r => r.xun == "上旬"));
                dt_z = Tool.CommonFunc.LINQToDataTable(data.Where(r => r.xun == "中旬"));
                dt_x = Tool.CommonFunc.LINQToDataTable(data.Where(r => r.xun == "下旬"));
            }
            else if (yType == (byte)CHART_Y_TYPE.销售额)
            {
                var data = xss.Select(r => new { r.shuliang, r.jine, month = new DateTime(r.xiaoshoushijian.Year, r.xiaoshoushijian.Month, 1), xun = getXun(r.xiaoshoushijian) }).
                    GroupBy(r => new { r.month, r.xun }).Select(r => new { X = r.Key.month, r.Key.xun, Y = Math.Round(r.Sum(rx => rx.jine), 2) }).
                    OrderBy(r => r.X).OrderBy(r => r.xun).ToList();
                dt = Tool.CommonFunc.LINQToDataTable(data);
                dt_s = Tool.CommonFunc.LINQToDataTable(data.Where(r => r.xun == "上旬"));
                dt_z = Tool.CommonFunc.LINQToDataTable(data.Where(r => r.xun == "中旬"));
                dt_x = Tool.CommonFunc.LINQToDataTable(data.Where(r => r.xun == "下旬"));
            }
            else if (yType == (byte)CHART_Y_TYPE.利润)
            {
                var data = xss.Select(r => new
                {
                    lirun = r.lirun,
                    month = new DateTime(r.xiaoshoushijian.Year, r.xiaoshoushijian.Month, 1),
                    xun = getXun(r.xiaoshoushijian)
                }).
                GroupBy(r => new { r.month, r.xun }).Select(r => new
                {
                    X = r.Key.month,
                    r.Key.xun,
                    Y = Math.Round(r.Sum(rx => rx.lirun), 2)
                }).
                OrderBy(r => r.X).OrderBy(r => r.xun).ToList();
                dt = Tool.CommonFunc.LINQToDataTable(data);
                dt_s = Tool.CommonFunc.LINQToDataTable(data.Where(r => r.xun == "上旬"));
                dt_z = Tool.CommonFunc.LINQToDataTable(data.Where(r => r.xun == "中旬"));
                dt_x = Tool.CommonFunc.LINQToDataTable(data.Where(r => r.xun == "下旬"));
            }

            Chart cht = new Chart();

            int wndWidth = int.Parse(hid_windowWidth.Value);
            cht.Width = wndWidth;
            cht.Series.Clear();
            cht.ChartAreas.Clear();
            ChartArea ca = cht.ChartAreas.Add("A1");
            ca.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Months;
            ca.AxisX.LabelStyle.Interval = 1;
            ca.AxisX.LabelStyle.Format = "yyyy-MM";
            Legend ptl = cht.Legends.Add("L1");
            ptl.Docking = Docking.Bottom;
            ptl.Alignment = System.Drawing.StringAlignment.Center;
            Series jsx = cht.Series.Add("下旬");
            Series jsz = cht.Series.Add("中旬");
            Series jss = cht.Series.Add("上旬");
            jsx.ToolTip = "#VAL";
            jsx.ChartType = SeriesChartType.StackedColumn;
            jsx.Points.DataBind(dt_x.AsEnumerable(), "X", "Y", "");
            jsz.ToolTip = "#VAL";
            jsz.ChartType = SeriesChartType.StackedColumn;
            jsz.Points.DataBind(dt_z.AsEnumerable(), "X", "Y", "");
            jss.ToolTip = "#VAL";
            jss.ChartType = SeriesChartType.StackedColumn;
            jss.Points.DataBind(dt_s.AsEnumerable(), "X", "Y", "");
            cht.DataManipulator.InsertEmptyPoints(1, IntervalType.Months, "下旬, 中旬, 上旬");

            return cht;
        }

        /// <summary>
        /// 算出某个日期属于上中下询
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private string getXun(DateTime dateTime)
        {
            string ret = "";
            int i = dateTime.Day;
            if (i < 11)
            {
                ret = "上旬";
            }
            else if (i >= 11 && i < 20)
            {
                ret = "中旬";
            }
            else
            {
                ret = "下旬";
            }

            return ret;
        }

        /// <summary>
        /// 查询符合条件的销售数据
        /// </summary>
        /// <returns></returns>
        private TXiaoshou[] getXiaoshouData()
        {
            DBContext db = new DBContext();
            //限定查询的品牌范围
            int[] ppids = getPPids();
            int[] jmsids = getJmsids();
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
                xsrq_end = DateTime.Parse(txb_xsrq_end.Text.Trim()).Date.AddDays(1);
            }

            int recordCount = 0;
            TXiaoshou[] xss = db.GetXiaoshousByCond(ppids, jmsids, fdid, "", "", xsrq_start, xsrq_end, null, null, null, null, out recordCount);

            return xss;
        }
        private int[] getPPids()
        {
            List<int> lppids = new List<int>();
            //如果是品牌商查询，将子加盟商的名称替换为备注名称
            DBContext db = new DBContext();
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    lppids.Add(int.Parse(cmb_jms.SelectedValue));
                }
            }
            else
            {
                //grid_xiaoshou.Columns[0].Visible = false;
                TJiamengshang[] pps = db.GetFuJiamengshangs(_LoginUser.jmsid);
                lppids.AddRange(pps.Select(r => r.id));
                lppids.Add(_LoginUser.jmsid);
            }

            return lppids.ToArray();
        }
        private int[] getJmsids()
        {
            List<int> jmsids = new List<int>();
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                //加盟商
                if (!string.IsNullOrEmpty(cmb_zjms.SelectedValue))
                {
                    jmsids.Add(int.Parse(cmb_zjms.SelectedValue));
                }
            }
            else
            {
                //如果下拉框有选择，就只查询选择的子加盟商的数据
                if (string.IsNullOrEmpty(cmb_zjms.SelectedValue))
                {
                    jmsids.Add(int.Parse(cmb_zjms.SelectedValue));
                }
                else
                {
                    //非系统管理员或总经理，只能查询自己直营店和加盟商的销售数据
                    DBContext db = new DBContext();
                    TJiamengshang[] jmses = db.GetZiJiamengshangs(_LoginUser.jmsid);
                    jmsids.AddRange(jmses.Select(r => r.id));
                    jmsids.Add(_LoginUser.jmsid);
                }
            }
            return jmsids.ToArray();
        }
        /// <summary>
        /// 取得选中的X类型
        /// </summary>
        /// <returns></returns>
        private List<byte> getXTypes()
        {
            List<byte> ret = new List<byte>();
            for (int i = 0; i < chk_x.Items.Count; i++)
            {
                if (chk_x.Items[i].Selected == true)
                    ret.Add(byte.Parse(chk_x.Items[i].Value));
            }

            return ret;
        }
        protected void cmb_jms_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_zjms.Items.Clear();
            cmb_fd.Items.Clear();
            TJiamengshang[] zjmses;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                TFendian[] fs;
                DBContext db = new DBContext();
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    int jmsid = int.Parse(cmb_jms.SelectedValue);
                    TJiamengshang jms = db.GetJiamengshangById(jmsid);
                    //子加盟商
                    zjmses = db.GetZiJiamengshangs(jmsid);
                    Tool.CommonFunc.InitDropDownList(cmb_zjms, zjmses, "mingcheng", "id");
                    cmb_zjms.Items.Insert(0, new ListItem(jms.mingcheng, jmsid.ToString()));
                    cmb_zjms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    //分店
                    TFendian[] zyds = db.GetFendiansAsItems(jmsid);
                    TFendian[] jmds = db.GetFendiansOfPinpaiAsItems(jmsid);
                    fs = zyds.Concat(jmds).ToArray();
                }
                else
                {
                    zjmses = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_zjms, zjmses, "mingcheng", "id");
                    cmb_zjms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    fs = new TFendian[] { };
                }

                Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
                cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
            }
            else
            {
                //其他角色不可能触发该事件，如果有，判定为浏览器操作漏洞
                throw new MyException("非法操作，请刷新页面重新执行", null);
            }
        }
        protected void cmb_zjms_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBContext db = new DBContext();
            int? jmsid = null;
            TFendian[] fs;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
               _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    jmsid = int.Parse(cmb_jms.SelectedValue);
                    if (!string.IsNullOrEmpty(cmb_zjms.SelectedValue))
                    {
                        //加载属于某子加盟商的并且加盟到某品牌商的分店
                        int zjmsid = int.Parse(cmb_zjms.SelectedValue);
                        fs = db.GetFendiansAsItems(zjmsid).Where(r => r.ppid == jmsid.Value).ToArray();
                    }
                    else
                    {
                        //加载属于某品牌商的，和加盟到该品牌的分店
                        TFendian[] zyds = db.GetFendiansAsItems(jmsid);
                        TFendian[] jmds = db.GetFendiansOfPinpaiAsItems(jmsid.Value);
                        fs = zyds.Concat(jmds).ToArray();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(cmb_zjms.SelectedValue))
                    {
                        //加载属于某子加盟商的并且加盟到某品牌商的分店
                        int zjmsid = int.Parse(cmb_zjms.SelectedValue);
                        fs = db.GetFendiansAsItems(zjmsid);
                    }
                    else
                    {
                        fs = new TFendian[] { };
                    }
                }
            }
            else
            {
                jmsid = _LoginUser.jmsid;
                if (!string.IsNullOrEmpty(cmb_zjms.SelectedValue))
                {
                    //加载属于某子加盟商的并且加盟到某品牌商的分店
                    int zjmsid = int.Parse(cmb_zjms.SelectedValue);
                    if (zjmsid == jmsid)
                    {
                        //子加盟商选择了自己，表示某品牌商想查看自己的直营店
                        fs = db.GetFendiansAsItems(zjmsid);
                    }
                    else
                    {
                        fs = db.GetFendiansAsItems(zjmsid).Where(r => r.ppid == jmsid).ToArray();
                    }
                }
                else
                {
                    //加载属于某品牌商的，和加盟到该品牌的分店
                    TFendian[] zyds = db.GetFendiansAsItems(jmsid);
                    TFendian[] jmds = db.GetFendiansOfPinpaiAsItems(jmsid.Value);
                    fs = zyds.Concat(jmds).ToArray();
                }
            }

            Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
            cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
        }

    }
}