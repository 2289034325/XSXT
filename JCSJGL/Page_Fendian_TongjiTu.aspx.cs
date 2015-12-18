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
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    //加盟商
                    TJiamengshang[] jmses = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmses, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    //分店下拉框
                    cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                }
                else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商经理)
                {
                    //加盟商
                    TJiamengshang[] jmses = db.GetZiJiamengshangs(_LoginUser.ppsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmses, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    //分店下拉框
                    cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                }
                else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商经理)
                {
                    //隐藏搜索条件
                    div_sch_jms.Visible = false;

                    TFendian[] fds = db.GetFendians(_LoginUser.jmsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_fd, fds, "dianming", "id");
                    cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                }
                //else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商店长)
                //{
                //    //隐藏搜索条件
                //    div_sch_jms.Visible = false;

                //    TFendian[] fds = db.GetUserFendiansByUserId(_LoginUser.id).Select(r => r.TFendian).ToArray();
                //    Tool.CommonFunc.InitDropDownList(cmb_fd, fds, "dianming", "id");
                //    cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                //}

                //日期下拉框
                txb_xsrq_start.Text = DateTime.Now.ToString("yyyy-MM-dd");
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

            //int wndWidth = int.Parse(hid_windowWidth.Value);
            //cht.Width = Convert.ToInt32(wndWidth);

            cht.Width = Unit.Parse(hid_windowWidth.Value);
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

            //int wndWidth = int.Parse(hid_windowWidth.Value);
            //cht.Width = wndWidth;

            cht.Width = Unit.Parse(hid_windowWidth.Value);
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
            
            //int wndWidth = int.Parse(hid_windowWidth.Value);
            //cht.Width = wndWidth;

            cht.Width = Unit.Parse(hid_windowWidth.Value);
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

            //int wndWidth = int.Parse(hid_windowWidth.Value);
            //cht.Width = wndWidth;

            cht.Width = Unit.Parse(hid_windowWidth.Value);
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

        private int[] getFdids()
        {
            DBContext db = new DBContext();
            int[] fdids = new int[] { };

            //如果是店长，则也限定为权限内可见范围的数据
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (string.IsNullOrEmpty(cmb_fd.SelectedValue))
                {
                    if (string.IsNullOrEmpty(cmb_jms.SelectedValue))
                    {
                        TFendian[] fds = db.GetFendiansAsItems(null);
                        fdids = fds.Select(r => r.id).ToArray();
                    }
                    else
                    {
                        int jmsid = int.Parse(cmb_jms.SelectedValue);
                        TFendian[] fds = db.GetFendiansAsItems(jmsid);
                        fdids = fds.Select(r => r.id).ToArray();
                    }
                }
                else
                {
                    fdids = new int[] { int.Parse(cmb_fd.SelectedValue) };
                }
            }
            else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商经理)
            {
                if (string.IsNullOrEmpty(cmb_fd.SelectedValue))
                {
                    if (string.IsNullOrEmpty(cmb_jms.SelectedValue))
                    {
                        TFendian[] fds = db.GetFendiansOfPinpaiAsItems(_LoginUser.ppsid.Value);
                        fdids = fds.Select(r => r.id).ToArray();
                    }
                    else
                    {
                        int jmsid = int.Parse(cmb_jms.SelectedValue);
                        TFendian[] fds = db.GetFendiansOfPinpaiAsItems(_LoginUser.ppsid.Value).Where(r => r.jmsid == jmsid).ToArray();
                        fdids = fds.Select(r => r.id).ToArray();
                    }
                }
                else
                {
                    fdids = new int[] { int.Parse(cmb_fd.SelectedValue) };
                }

            }
            else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商经理)
            {
                if (string.IsNullOrEmpty(cmb_fd.SelectedValue))
                {
                    TFendian[] fds = db.GetFendiansAsItems(_LoginUser.jmsid.Value);
                    fdids = fds.Select(r => r.id).ToArray();
                }
                else
                {
                    fdids = new int[] { int.Parse(cmb_fd.SelectedValue) };
                }
            }
            //else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商店长)
            //{
            //    TUserFendian[] ufs = db.GetUserFendiansByUserId(_LoginUser.id);
            //    fdids = ufs.Select(r => r.fendianid).ToArray();
            //}

            return fdids;
        }
        /// <summary>
        /// 查询符合条件的销售数据
        /// </summary>
        /// <returns></returns>
        private TXiaoshou[] getXiaoshouData()
        {
            DBContext db = new DBContext();
            //限定查询的品牌范围
            int? ppsid = getPpsid();
            int[] fdids = getFdids();
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
            TXiaoshou[] xss = db.GetXiaoshousByCond(ppsid, fdids, "", "", xsrq_start, xsrq_end, null, null, null, null, out recordCount);

            return xss;
        }

        private int? getPpsid()
        {
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商经理)
            {
                return _LoginUser.ppsid.Value;
            }

            return null;
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
            cmb_fd.Items.Clear();

            DBContext db = new DBContext();

            if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
            {
                int jmsid = int.Parse(cmb_jms.SelectedValue);
                TFendian[] fs = db.GetFendiansAsItems(jmsid);
                Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
            }

            cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
        }

    }
}