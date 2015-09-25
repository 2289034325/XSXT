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
                DBContext db = new DBContext();
                //隐藏搜索条件
                div_sch_jms.Visible = false;

                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    //显示搜索
                    div_sch_jms.Visible = true;

                    TJiamengshang[] jmss = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmss, "mingcheng", "id");
                }

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
            DBContext db = new DBContext();
            //取查询条件
            int? jmsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    jmsid = int.Parse(cmb_jms.SelectedValue);
                }
            }
            else
            {
                jmsid = _LoginUser.jmsid;
            }

            int[] ppids = getPPids();
            int[] jmsids = getJmsids();
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

            //自己的款号
            //TXiaoshou[] mykhs = db.GetXiaoshousOfMyKhs(jmsid.Value, xsrq_start, xsrq_end);
            //加盟的品牌商款号
            //TJiamengshang[] dlses = db.GetFuJiamengshangs(jmsid.Value);
            //int[] dlsids = dlses.Select(r => r.id).ToArray();
            //TXiaoshou[] jmkhs = new TXiaoshou[] { };
            //if (dlsids.Length != 0)
            //{
            //    jmkhs = db.GetXiaoshousOfJmKhs(dlsids,jmsid.Value, xsrq_start, xsrq_end); ;
            //}

            //合并两个集合
            //TXiaoshou[] xses = mykhs.Concat(jmkhs).ToArray();

            int rCount = 0;
            TXiaoshou[] xses = db.GetXiaoshousByCond(ppids, jmsids, null, "", "", xsrq_start, xsrq_end, null, null, null, null, out rCount);

            return xses;
        }
        private int[] getJmsids()
        {
            DBContext db = new DBContext();
            List<int> jmsids = new List<int>();
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    TJiamengshang[] jmses = db.GetZiJiamengshangs(int.Parse(cmb_jms.SelectedValue));
                    jmsids.AddRange(jmses.Select(r => r.id));
                    jmsids.Add(int.Parse(cmb_jms.SelectedValue));
                }
            }
            else
            {
                //非系统管理员或总经理，只能查询自己直营店和加盟商的销售数据
                TJiamengshang[] jmses = db.GetZiJiamengshangs(_LoginUser.jmsid);
                jmsids.AddRange(jmses.Select(r => r.id));
                jmsids.Add(_LoginUser.jmsid);

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
                    TJiamengshang[] pps = db.GetFuJiamengshangs(int.Parse(cmb_jms.SelectedValue));
                    lppids.AddRange(pps.Select(r => r.id));
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

    }
}