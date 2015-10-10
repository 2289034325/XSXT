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
    public partial class Page_KuanhaoFenxi : MyPage
    {
        public Page_KuanhaoFenxi()
        {
            _PageName = PageName.款号分析;
        }
        private enum CHART_Y_TYPE:byte
        {
            销售量 = 1,
            销售额 = 2,
            利润 = 3
        }
        private enum CHART_X_TYPE:byte
        {
            销量前20=0,
            利润前20=5,
            类型=1,
            颜色=2,
            尺码=3,
            价格=4,
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //子加盟商和分店下拉框
                TFendian[] fs = new TFendian[] { };

                //隐藏搜索条件
                div_sch_jms.Visible = false;

                //初始化分店下拉框
                DBContext db = new DBContext();
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

                    //品牌ID
                    if (Request["ppid"] != null)
                    {
                        cmb_jms.SelectedValue = Request["ppid"];
                    }
                    if (Request["jmsid"] != null)
                    {
                        jmsid = int.Parse(Request["jmsid"]);
                        cmb_zjms.SelectedValue = Request["jmsid"];
                        fs = db.GetFendiansAsItems(jmsid.Value);
                    }
                }
                else
                {
                    jmsid = _LoginUser.jmsid;
                    //加载子加盟商，包括自己
                    TJiamengshangGX[] zjmsgxes = db.GetZiJiamengshangGXes(jmsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_zjms, zjmsgxes, "bzmingcheng", "jmsid");
                    cmb_zjms.Items.Insert(0, new ListItem(_LoginUser.TJiamengshang.mingcheng, _LoginUser.jmsid.ToString()));
                    cmb_zjms.Items.Insert(0, new ListItem("所有加盟商", ""));


                    //如果是店长，限制为可见的分店数据
                    if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.店长)
                    {
                        fs = db.GetUserFendiansByUserId(_LoginUser.id).Select(r => r.TFendian).ToArray();
                    }
                    else
                    {
                        //加载所有的直营店和加盟分店
                        TFendian[] zyds = db.GetFendiansAsItems(jmsid);
                        TFendian[] jmds = db.GetFendiansOfPinpaiAsItems(jmsid.Value);
                        fs = zyds.Concat(jmds).ToArray();
                    }

                    if (_LoginUser.TJiamengshang.zjmsshu <= 0)
                    {
                        div_sch_zjms.Visible = false;
                    }
                    else
                    {
                        //如果是店长，限制为可见的分店数据
                        if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.店长)
                        {
                            div_sch_zjms.Visible = false;
                        }
                        else
                        {
                            div_sch_zjms.Visible = true;
                        }
                    }
                }

                Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
                cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));

                //日期
                txb_xsrq_start.Text = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                txb_xsrq_end.Text = DateTime.Now.ToString("yyyy-MM-dd");

                //图表类型下拉框
                cmb_y.Items.Add(new ListItem(CHART_Y_TYPE.销售量.ToString(), ((byte)CHART_Y_TYPE.销售量).ToString()));
                cmb_y.Items.Add(new ListItem(CHART_Y_TYPE.销售额.ToString(), ((byte)CHART_Y_TYPE.销售额).ToString()));
                cmb_y.Items.Add(new ListItem(CHART_Y_TYPE.利润.ToString(), ((byte)CHART_Y_TYPE.利润).ToString()));

                chk_x.Items.Add(new ListItem(CHART_X_TYPE.销量前20.ToString(), ((byte)CHART_X_TYPE.销量前20).ToString()));
                chk_x.Items.Add(new ListItem(CHART_X_TYPE.利润前20.ToString(), ((byte)CHART_X_TYPE.利润前20).ToString()));
                chk_x.Items.Add(new ListItem(CHART_X_TYPE.类型.ToString(), ((byte)CHART_X_TYPE.类型).ToString()));
                chk_x.Items.Add(new ListItem(CHART_X_TYPE.颜色.ToString(), ((byte)CHART_X_TYPE.颜色).ToString()));
                chk_x.Items.Add(new ListItem(CHART_X_TYPE.尺码.ToString(), ((byte)CHART_X_TYPE.尺码).ToString()));
                chk_x.Items.Add(new ListItem(CHART_X_TYPE.价格.ToString(), ((byte)CHART_X_TYPE.价格).ToString()));

                chk_x.Items[0].Selected = true;
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
            //排除无条码销售的商品
            xss = xss.Where(r => r.TTiaoma != null).ToArray();

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


            if (xTypes.Contains((byte)CHART_X_TYPE.销量前20))
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Controls.Add(makeHotChart(xss));
                div_charts.Controls.Add(div);
            }
            if (xTypes.Contains((byte)CHART_X_TYPE.利润前20))
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Controls.Add(makeProfitChart(xss));
                div_charts.Controls.Add(div);
            }
            if (xTypes.Contains((byte)CHART_X_TYPE.类型))
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Controls.Add(makeTypeChart(xss));
                div_charts.Controls.Add(div);
            }
            if (xTypes.Contains((byte)CHART_X_TYPE.颜色))
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Controls.Add(makeColorChart(xss));
                div_charts.Controls.Add(div);
            }
            if (xTypes.Contains((byte)CHART_X_TYPE.尺码))
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Controls.Add(makeSizeChart(xss));
                div_charts.Controls.Add(div);
            }
            if (xTypes.Contains((byte)CHART_X_TYPE.价格))
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Controls.Add(makePriceChart(xss));
                div_charts.Controls.Add(div);
            }
        }

        /// <summary>
        /// 畅销前20的款号
        /// </summary>
        /// <param name="xss"></param>
        /// <returns></returns>
        private Chart makeHotChart(TXiaoshou[] xss)
        {
            byte yType = byte.Parse(cmb_y.SelectedValue);
            DataTable dt = new DataTable();
            if (yType == (byte)CHART_Y_TYPE.销售量)
            {
                var data = xss.GroupBy(r => new { r.TTiaoma.TKuanhao.kuanhao }).
                    Select(r => new
                    {
                        X = r.Key.kuanhao,
                        Y = r.Sum(rx => rx.shuliang)
                    }).OrderByDescending(r => r.Y).Take(20);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.销售额)
            {
                var data = xss.GroupBy(r => new { r.TTiaoma.TKuanhao.kuanhao }).
                    Select(r => new
                    {
                        X = r.Key.kuanhao,
                        Y = r.Sum(rx => rx.jine),
                        Z = r.Sum(rx => rx.shuliang)
                    }).OrderByDescending(r => r.Z).Take(20);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.利润)
            {
                var data = xss.GroupBy(r => new { r.TTiaoma.TKuanhao.kuanhao }).
                    Select(r => new
                    {
                        X = r.Key.kuanhao,
                        Y = r.Sum(rx => rx.lirun),
                        Z = r.Sum(rx => rx.shuliang)
                    }).OrderByDescending(r => r.Z).Take(20);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }

            Chart cht = new Chart();

            int wndWidth = int.Parse(hid_windowWidth.Value);
            cht.Width = Convert.ToInt32(wndWidth);
            cht.Series.Clear();
            cht.ChartAreas.Clear();
            ChartArea ca = cht.ChartAreas.Add("A1");
            ca.AxisX.LabelStyle.Interval = 1;
            Series ws = cht.Series.Add("S1");            
            ws.IsVisibleInLegend = false;
            ws.ToolTip = "#VAL";
            ws.ChartType = SeriesChartType.Column;
            ws.Points.DataBind(dt.AsEnumerable(), "X", "Y", "");

            for (int pointIndex = 0; pointIndex < ws.Points.Count; pointIndex++)
            {
                ws.Points[pointIndex].Url = string.Format("Page_Xiaoshou.aspx?xsrqstart={0}&xsrqend={1}&kh={2}&ppid={3}&jmsid={4}&fdid={5}",
                    txb_xsrq_start.Text, txb_xsrq_end.Text, ws.Points[pointIndex].AxisLabel, cmb_jms.SelectedValue,cmb_zjms.SelectedValue,cmb_fd.SelectedValue);
            }

            return cht;
        }

        /// <summary>
        /// 利润前20的款号
        /// </summary>
        /// <param name="xss"></param>
        /// <returns></returns>
        private Chart makeProfitChart(TXiaoshou[] xss)
        {
            byte yType = byte.Parse(cmb_y.SelectedValue);
            DataTable dt = new DataTable();
            if (yType == (byte)CHART_Y_TYPE.销售量)
            {
                var data = xss.GroupBy(r => new { r.TTiaoma.TKuanhao.kuanhao }).
                    Select(r => new
                    {
                        X = r.Key.kuanhao,
                        Y = r.Sum(rx => rx.shuliang),
                        Z = r.Sum(rx => rx.lirun)
                    }).OrderByDescending(r => r.Z).Take(20);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.销售额)
            {
                var data = xss.GroupBy(r => new { r.TTiaoma.TKuanhao.kuanhao }).
                    Select(r => new
                    {
                        X = r.Key.kuanhao,
                        Y = r.Sum(rx => rx.jine),
                        Z = r.Sum(rx => rx.lirun)
                    }).OrderByDescending(r => r.Z).Take(20);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.利润)
            {
                var data = xss.GroupBy(r => new { r.TTiaoma.TKuanhao.kuanhao }).
                    Select(r => new
                    {
                        X = r.Key.kuanhao,
                        Y = r.Sum(rx => rx.lirun),
                    }).OrderByDescending(r => r.Y).Take(20);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }

            Chart cht = new Chart();

            int wndWidth = int.Parse(hid_windowWidth.Value);
            cht.Width = Convert.ToInt32(wndWidth);
            cht.Series.Clear();
            cht.ChartAreas.Clear();
            ChartArea ca = cht.ChartAreas.Add("A1");
            ca.AxisX.LabelStyle.Interval = 1;
            Series ws = cht.Series.Add("S1");
            ws.IsVisibleInLegend = false;
            ws.ToolTip = "#VAL";
            ws.ChartType = SeriesChartType.Column;
            ws.Points.DataBind(dt.AsEnumerable(), "X", "Y", "");

            for (int pointIndex = 0; pointIndex < ws.Points.Count; pointIndex++)
            {
                ws.Points[pointIndex].Url = string.Format("Page_Xiaoshou.aspx?xsrqstart={0}&xsrqend={1}&kh={2}&ppid={3}&jmsid={4}&fdid={5}",
                    txb_xsrq_start.Text, txb_xsrq_end.Text, ws.Points[pointIndex].AxisLabel, cmb_jms.SelectedValue, cmb_zjms.SelectedValue, cmb_fd.SelectedValue);
            }

            return cht;
        }

        /// <summary>
        /// 价格区间分析
        /// </summary>
        /// <param name="xss"></param>
        /// <returns></returns>
        private Chart makePriceChart(TXiaoshou[] xss)
        {
            byte yType = byte.Parse(cmb_y.SelectedValue);
            DataTable dt = new DataTable();
            if (yType == (byte)CHART_Y_TYPE.销售量)
            {
                //退货的不统计
                var data = xss.Where(r => r.shuliang > 0).
                    Select(r => new { danjia = getJiageStr(50, 500, r.jine / r.shuliang), r.shuliang }).
                    GroupBy(r => r.danjia).Select(r => new
                    {
                        X = r.Key,
                        Y = r.Sum(rx => rx.shuliang)
                    }).OrderByDescending(r => r.Y);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.销售额)
            {
                //退货的不统计
                var data = xss.Where(r => r.shuliang > 0).
                Select(r => new { danjia = getJiageStr(50, 500, r.jine / r.shuliang), r.shuliang, r.jine }).
                GroupBy(r => r.danjia).Select(r => new
                {
                    X = r.Key,
                    Y = r.Sum(rx => rx.jine)
                }).OrderByDescending(r => r.Y);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.利润)
            {
                //退货的不统计
                var data = xss.Where(r => r.shuliang > 0).
                    Select(r => new
                    {
                        danjia = getJiageStr(50, 500, r.jine / r.shuliang),
                        r.shuliang,
                        //r.jine,
                        //jinjia = r.TTiaoma == null ? (r.jine / 2) : r.TTiaoma.jinjia
                        lr = r.lirun
                    }).
                    GroupBy(r => r.danjia).Select(r => new
                    {
                        X = r.Key,
                        //Y = r.Sum(rx => rx.jine - rx.jinjia * rx.shuliang)
                        Y = r.Sum(rx => rx.lr)
                    }).OrderByDescending(r => r.Y);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }

            Chart cht = new Chart();

            int wndWidth = int.Parse(hid_windowWidth.Value);
            cht.Width = Convert.ToInt32(wndWidth);
            cht.Series.Clear();
            cht.ChartAreas.Clear();
            cht.ChartAreas.Add("A1");
            Series ps = cht.Series.Add("S1");
            Legend pl = cht.Legends.Add("L1");
            pl.Docking = Docking.Bottom;
            pl.Alignment = System.Drawing.StringAlignment.Center;
            ps.ToolTip = "#VAL";
            ps.Label = "#PERCENT";
            ps.LegendText = "#VALX";
            ps["CollectedThreshold"] = "10";
            ps["CollectedLabel"] = "其他";
            ps["CollectedLegendText"] = "其他";
            ps.ChartType = SeriesChartType.Pie;
            ps.Points.DataBind(dt.AsEnumerable(), "X", "Y", "");

            return cht;
        }


        /// <summary>
        /// 颜色分析
        /// </summary>
        /// <param name="xss"></param>
        /// <returns></returns>
        private Chart makeColorChart(TXiaoshou[] xss)
        {
            byte yType = byte.Parse(cmb_y.SelectedValue);
            DataTable dt = new DataTable();
            if (yType == (byte)CHART_Y_TYPE.销售量)
            {
                var data = xss.GroupBy(r => r.TTiaoma == null ? "其他" : r.TTiaoma.yanse).
                    Select(r => new
                    {
                        X = r.Key,
                        Y = r.Sum(rx => rx.shuliang)
                    }).OrderByDescending(r => r.Y);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.销售额)
            {
                var data = xss.GroupBy(r => r.TTiaoma == null ? "其他" : r.TTiaoma.yanse).
                    Select(r => new
                    {
                        X = r.Key,
                        Y = r.Sum(rx => rx.jine)
                    }).OrderByDescending(r => r.Y);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.利润)
            {
                var data = xss.GroupBy(r => r.TTiaoma == null ? "其他" : r.TTiaoma.yanse).
                    Select(r => new
                    {
                        X = r.Key,
                        //Y = r.Sum(rx => rx.TTiaoma == null ? (rx.jine / 2) : rx.jine - rx.TTiaoma.jinjia * rx.shuliang)
                        Y = r.Sum(rx => rx.lirun)
                    }).OrderByDescending(r => r.Y);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }

            Chart cht = new Chart();

            int wndWidth = int.Parse(hid_windowWidth.Value);
            cht.Width = Convert.ToInt32(wndWidth);
            cht.Series.Clear();
            cht.ChartAreas.Clear();
            cht.ChartAreas.Add("A1");
            Series cs = cht.Series.Add("S1");
            Legend cl = cht.Legends.Add("L1");
            cl.Docking = Docking.Bottom;
            cl.Alignment = System.Drawing.StringAlignment.Center;
            cs.ToolTip = "#VAL";
            cs.Label = "#PERCENT";
            cs.LegendText = "#VALX";
            cs["CollectedThreshold"] = "10";
            cs["CollectedLabel"] = "其他";
            cs["CollectedLegendText"] = "其他";
            cs.ChartType = SeriesChartType.Pie;
            cs.Points.DataBind(dt.AsEnumerable(), "X", "Y", "");

            return cht;
        }

        /// <summary>
        /// 尺码分析
        /// </summary>
        /// <param name="xss"></param>
        /// <returns></returns>
        private Chart makeSizeChart(TXiaoshou[] xss)
        {
            byte yType = byte.Parse(cmb_y.SelectedValue);
            DataTable dt = new DataTable();
            if (yType == (byte)CHART_Y_TYPE.销售量)
            {
                var data = xss.GroupBy(r => r.TTiaoma == null ? "其他" : r.TTiaoma.chima).
                    Select(r => new
                    {
                        X = r.Key,
                        Y = r.Sum(rx => rx.shuliang)
                    }).OrderByDescending(r => r.Y);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.销售额)
            {
                var data = xss.GroupBy(r => r.TTiaoma == null ? "其他" : r.TTiaoma.chima).
                    Select(r => new
                    {
                        X = r.Key,
                        Y = r.Sum(rx => rx.jine)
                    }).OrderByDescending(r => r.Y);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.利润)
            {
                var data = xss.GroupBy(r => r.TTiaoma == null ? "其他" : r.TTiaoma.chima).
                    Select(r => new
                    {
                        X = r.Key,
                        Y = r.Sum(rx => rx.lirun)
                    }).OrderByDescending(r => r.Y);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }

            Chart cht = new Chart();

            int wndWidth = int.Parse(hid_windowWidth.Value);
            cht.Width = Convert.ToInt32(wndWidth);
            cht.Series.Clear();
            cht.ChartAreas.Clear();
            cht.ChartAreas.Add("A1");
            Series cs = cht.Series.Add("S1");
            Legend cl = cht.Legends.Add("L1");
            cl.Docking = Docking.Bottom;
            cl.Alignment = System.Drawing.StringAlignment.Center;
            cs.ToolTip = "#VAL";
            cs.Label = "#PERCENT";
            cs.LegendText = "#VALX";
            cs["CollectedThreshold"] = "10";
            cs["CollectedLabel"] = "其他";
            cs["CollectedLegendText"] = "其他";
            cs.ChartType = SeriesChartType.Pie;
            cs.Points.DataBind(dt.AsEnumerable(), "X", "Y", "");

            return cht;
        }

        /// <summary>
        /// 类型分析
        /// </summary>
        /// <param name="xss"></param>
        /// <returns></returns>
        private Chart makeTypeChart(TXiaoshou[] xss)
        {
            byte yType = byte.Parse(cmb_y.SelectedValue);
            DataTable dt = new DataTable();
            if (yType == (byte)CHART_Y_TYPE.销售量)
            {
                var data = xss.GroupBy(r => r.TTiaoma == null ? (byte)Tool.JCSJ.DBCONSTS.KUANHAO_LX.其他 : r.TTiaoma.TKuanhao.leixing).
                    Select(r => new
                    {
                        X = ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)r.Key).ToString(),
                        Y = r.Sum(rx => rx.shuliang)
                    }).OrderByDescending(r => r.Y);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.销售额)
            {
                var data = xss.GroupBy(r => r.TTiaoma == null ? (byte)Tool.JCSJ.DBCONSTS.KUANHAO_LX.其他 : r.TTiaoma.TKuanhao.leixing).
                    Select(r => new
                    {
                        X = ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)r.Key).ToString(),
                        Y = r.Sum(rx => rx.jine)
                    }).OrderByDescending(r => r.Y);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }
            else if (yType == (byte)CHART_Y_TYPE.利润)
            {
                var data = xss.GroupBy(r => r.TTiaoma == null ? (byte)Tool.JCSJ.DBCONSTS.KUANHAO_LX.其他 : r.TTiaoma.TKuanhao.leixing).
                    Select(r => new
                    {
                        X = ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)r.Key).ToString(),
                        //Y = r.Sum(rx => rx.TTiaoma == null ? (rx.jine / 2) : rx.jine - rx.TTiaoma.jinjia * rx.shuliang)
                        Y = r.Sum(rx => rx.lirun)
                    }).OrderByDescending(r => r.Y);

                dt = Tool.CommonFunc.LINQToDataTable(data);
            }

            Chart cht = new Chart();

            int wndWidth = int.Parse(hid_windowWidth.Value);
            cht.Width = Convert.ToInt32(wndWidth);
            cht.Series.Clear();
            cht.ChartAreas.Clear();
            cht.ChartAreas.Add("A1");
            Series pts = cht.Series.Add("S1");
            Legend ptl = cht.Legends.Add("L1");
            ptl.Docking = Docking.Bottom;
            ptl.Alignment = System.Drawing.StringAlignment.Center;
            pts.ToolTip = "#VAL";
            pts.Label = "#PERCENT";
            pts.LegendText = "#VALX";
            pts.ChartType = SeriesChartType.Pie;
            pts.Points.DataBind(dt.AsEnumerable(), "X", "Y", "");

            return cht;
        }

        /// <summary>
        /// 查询符合条件的销售数据
        /// </summary>
        /// <returns></returns>
        private TXiaoshou[] getXiaoshouData()
        {
            int[] ppids = getPPids();
            int[] jmsids = getJmsids();
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

            DBContext db = new DBContext();
            int rCount = 0;
            TXiaoshou[] xses = db.GetXiaoshousByCond(ppids, jmsids, fdids, "", "", xsrq_start, xsrq_end, null, null, null, null, out rCount);

            return xses;
        }
        private int[] getFdids()
        {
            int[] fdids = new int[] { };

            //下拉框没有选择全部，那就只查询选定的分店的数据
            if (!string.IsNullOrEmpty(cmb_fd.SelectedValue))
            {
                int fdid = int.Parse(cmb_fd.SelectedValue);
                fdids = new int[] { fdid };
            }
            //如果选择的是全部
            else
            {
                //如果是店长，则也限定为权限内可见范围的数据
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.店长)
                {
                    DBContext db = new DBContext();
                    TUserFendian[] ufs = db.GetUserFendiansByUserId(_LoginUser.id);
                    fdids = ufs.Select(r => r.fendianid).ToArray();
                }
            }

            return fdids;
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
                if (!string.IsNullOrEmpty(cmb_zjms.SelectedValue))
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
                TJiamengshang[] pps = db.GetFuJiamengshangs(_LoginUser.jmsid);
                lppids.AddRange(pps.Select(r => r.id));
                lppids.Add(_LoginUser.jmsid);
            }

            return lppids.ToArray();
        }
        /// <summary>
        /// 以50为一个档次，将销售单价分为几个区间
        /// </summary>
        /// <param name="danjia"></param>
        /// <returns></returns>
        private string getJiageStr(decimal interval, decimal max, decimal danjia)
        {
            string ret = "";

            if (interval < 0 || max < 0 || danjia < 0 || interval >= max)
            {
                throw new MyException("参数异常。价格不得为负数，价格区间不得大于等于最大价格。", null);
            }

            if (danjia < interval)
            {
                ret = "＜" + interval;
            }
            else if (danjia >= interval && danjia < max)
            {
                int i = 1;
                decimal iStart, iEnd;
                while (ret == "")
                {
                    iStart = interval * i;
                    iEnd = interval * (i + 1);
                    if (danjia >= iStart && danjia < iEnd)
                    {
                        ret = iStart + "-" + iEnd;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            else
            {
                ret = "≥" + max;
            }

            return ret;
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

        /// <summary>
        /// 子加盟商下拉框变动，加载相应的分店
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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