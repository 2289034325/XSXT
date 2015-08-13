using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

namespace JCSJGL
{
    public partial class Page_TongjiBiao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //初始化分店下拉框
                DBContext db = new DBContext();
                TFendian[] fs = db.GetFendiansAsItems();
                Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
                cmb_fd.Items.Insert(0, "");

                //日期下拉框
                txb_xsrq_start.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txb_xsrq_end.Text = DateTime.Now.ToString("yyyy-MM-dd");

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

                //有get参数的时候，用get参数初始化日期
                bool rq = false;
                bool fd = false;
                if (!string.IsNullOrEmpty(Request["rq"]))
                {
                    rq = bool.Parse(Request["rq"]);
                }
                if (!string.IsNullOrEmpty(Request["fd"]))
                {
                    fd = bool.Parse(Request["fd"]);
                }
                if (Request["xsrqstart"] != null)
                {
                    txb_xsrq_start.Text = Request["xsrqstart"];
                    if (!string.IsNullOrEmpty(txb_xsrq_start.Text.Trim()))
                    {
                        xsrq_start = DateTime.Parse(txb_xsrq_start.Text.Trim());
                    }
                    else
                    {
                        xsrq_start = null;
                    }
                }
                if (Request["xsrqend"] != null)
                {
                    txb_xsrq_end.Text = Request["xsrqend"];
                    if (!string.IsNullOrEmpty(txb_xsrq_end.Text.Trim()))
                    {
                        xsrq_end = DateTime.Parse(txb_xsrq_end.Text.Trim());
                    }
                    else
                    {
                        xsrq_end = null;
                    }
                }
                if (Request["fdid"] != null)
                {
                    cmb_fd.SelectedValue = Request["fdid"];
                    if (!string.IsNullOrEmpty(cmb_fd.SelectedValue))
                    {
                        fdid = int.Parse(cmb_fd.SelectedValue);
                    }
                    else
                    {
                        fdid = null;
                    }
                }
                
                searchXiaoshou(rq, xsrq_start, xsrq_end, fd, fdid);
            }
            //else
            //{
            //    int? fdid = null;
            //    if (!string.IsNullOrEmpty(cmb_fd.SelectedValue))
            //    {
            //        fdid = int.Parse(cmb_fd.SelectedValue);
            //    }
            //    DateTime? xsrq_start = null;
            //    DateTime? xsrq_end = null;
            //    if (!string.IsNullOrEmpty(txb_xsrq_start.Text.Trim()))
            //    {
            //        xsrq_start = DateTime.Parse(txb_xsrq_start.Text.Trim());
            //    }
            //    if (!string.IsNullOrEmpty(txb_xsrq_end.Text.Trim()))
            //    {
            //        xsrq_end = DateTime.Parse(txb_xsrq_end.Text.Trim());
            //    }

            //    bool rq = bool.Parse(hid_rq_bool.Value);
            //    string xsrq = hid_rq.Value;
            //    bool fd = bool.Parse(hid_fd_bool.Value);

            //    if (!string.IsNullOrEmpty(xsrq))
            //    {
            //        xsrq_start = DateTime.Parse(xsrq);
            //        xsrq_end = DateTime.Parse(xsrq);
            //    }
            //    if (!string.IsNullOrEmpty(hid_fd.Value))
            //    {
            //        fdid = int.Parse(hid_fd.Value);
            //    }

            //    searchXiaoshou(rq, xsrq_start, xsrq_end, fd, fdid);
            //}
        }
        

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sch_Click(object sender, EventArgs e)
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

            searchXiaoshou(false, xsrq_start, xsrq_end, false, fdid);        
        }

        private void searchXiaoshou(bool rq, DateTime? xsrq_start, DateTime? xsrq_end, bool fd, int? fdid)
        {
            grid_xiaoshou.Columns.Clear();

            int recordCount = 0;
            DBContext db = new DBContext();
            TXiaoshou[] xss = db.GetXiaoshousByCond(fdid,
                xsrq_start, xsrq_end, null, null,
                grid_xiaoshou.PageSize, grid_xiaoshou.PageIndex, out recordCount);
            DataTable dt = new DataTable();
            var xs = xss.Select(r => new
            {
                rq = r.xiaoshoushijian.Date.ToString("yyyy-MM-dd"),
                fdid = r.fendianid,
                fd = r.TFendian.dianming,
                xl = r.shuliang,
                xse = r.jine,
                lr = r.jine - r.shuliang * r.TTiaoma.jinjia
            });

            BoundField bfrq = new BoundField();
            bfrq.DataField = "rq";
            bfrq.HeaderText = "日期";
            BoundField bffdid = new BoundField();
            bffdid.DataField = "fdid";
            bffdid.HeaderText = "分店ID";
            bffdid.Visible = false;
            BoundField bffd = new BoundField();
            bffd.DataField = "fd";
            bffd.HeaderText = "分店";

            if (rq && fd)
            {
                var data = xs.GroupBy(r => new { r.rq,r.fdid, r.fd }).Select(r => new 
                {
                    r.Key.rq,
                    r.Key.fdid,
                    r.Key.fd,
                    xl = r.Sum(xr=>xr.xl),
                    xse = decimal.Round(r.Sum(xr=>xr.xse),2),
                    lr = decimal.Round(r.Sum(xr=>xr.lr),2)
                });
                dt = Tool.CommonFunc.LINQToDataTable(data);

                grid_xiaoshou.Columns.Add(bfrq);
                grid_xiaoshou.Columns.Add(bffdid);
                grid_xiaoshou.Columns.Add(bffd);
            }
            else if (rq && !fd)
            {
                var data = xs.GroupBy(r => new { r.rq }).Select(r => new
                {
                    r.Key.rq,
                    xl = r.Sum(xr => xr.xl),
                    xse = decimal.Round(r.Sum(xr => xr.xse), 2),
                    lr = decimal.Round(r.Sum(xr => xr.lr), 2)
                });
                dt = Tool.CommonFunc.LINQToDataTable(data);

                grid_xiaoshou.Columns.Add(bfrq);
            }
            else if (!rq && fd)
            {
                var data = xs.GroupBy(r => new { r.fdid,r.fd }).Select(r => new
                {
                    r.Key.fdid,
                    r.Key.fd,
                    xl = r.Sum(xr => xr.xl),
                    xse = decimal.Round(r.Sum(xr => xr.xse), 2),
                    lr = decimal.Round(r.Sum(xr => xr.lr), 2)
                });
                dt = Tool.CommonFunc.LINQToDataTable(data);

                grid_xiaoshou.Columns.Add(bffdid);
                grid_xiaoshou.Columns.Add(bffd);
            }
            else
            {
                var data = new int[] { 0 }.Select(r => new
                {
                    xl = xs.Sum(xr => xr.xl),
                    xse = decimal.Round(xs.Sum(xr => xr.xse), 2),
                    lr = decimal.Round(xs.Sum(xr => xr.lr), 2)
                });
                dt = Tool.CommonFunc.LINQToDataTable(data);
            }

            BoundField bfxl = new BoundField();
            bfxl.DataField = "xl";
            bfxl.HeaderText = "销量";
            bfxl.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            grid_xiaoshou.Columns.Add(bfxl);
            BoundField bfxse = new BoundField();
            bfxse.DataField = "xse";
            bfxse.HeaderText = "销售额";
            bfxse.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            grid_xiaoshou.Columns.Add(bfxse);
            BoundField bflr = new BoundField();
            bflr.DataField = "lr";
            bflr.HeaderText = "利润";
            bflr.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            grid_xiaoshou.Columns.Add(bflr);

            if (rq && fd)
            {
                HyperLinkField hfmx = new HyperLinkField();
                hfmx.DataNavigateUrlFields = new string[] { "fdid", "rq" };
                hfmx.DataNavigateUrlFormatString = "Page_Xiaoshou.aspx?fdid={0}&xsrqstart={1}&xsrqend={1}";
                hfmx.Text = "明细";
                grid_xiaoshou.Columns.Add(hfmx);
            }
            else if (rq && !fd)
            {
                HyperLinkField hffd = new HyperLinkField();
                hffd.DataNavigateUrlFields = new string[] { "rq" };
                hffd.DataNavigateUrlFormatString = "Page_TongjiBiao.aspx?rq=True&fd=true&xsrqstart={0}&xsrqend={0}&fdid=" + 
                    cmb_fd.SelectedValue;
                hffd.Text = "分店";
                grid_xiaoshou.Columns.Add(hffd);

                HyperLinkField hfmx = new HyperLinkField();
                hfmx.DataNavigateUrlFields = new string[] { "rq" };
                hfmx.DataNavigateUrlFormatString = "Page_Xiaoshou.aspx?fdid=" + cmb_fd.SelectedValue + "&xsrqstart={0}&xsrqend={0}";
                hfmx.Text = "明细";
                grid_xiaoshou.Columns.Add(hfmx);          
            }
            else if (!rq && fd)
            {
                HyperLinkField hfrq = new HyperLinkField();
                hfrq.DataNavigateUrlFields = new string[] { "fdid" };
                hfrq.DataNavigateUrlFormatString = "Page_TongjiBiao.aspx?rq=True&fd=true&xsrqstart=" + txb_xsrq_start.Text.Trim() +
                    "&xsrqend=" + txb_xsrq_end.Text.Trim() + "&fdid={0}";
                hfrq.Text = "日期";
                grid_xiaoshou.Columns.Add(hfrq);

                HyperLinkField hfmx = new HyperLinkField();
                hfmx.DataNavigateUrlFields = new string[] { "fdid" };
                hfmx.DataNavigateUrlFormatString = "Page_Xiaoshou.aspx?fdid={0}&xsrqstart=" + txb_xsrq_start.Text.Trim() +
                    "&xsrqend=" + txb_xsrq_end.Text.Trim();
                hfmx.Text = "明细";
                grid_xiaoshou.Columns.Add(hfmx);          
            }
            else
            {
                HyperLinkField hfrq = new HyperLinkField();
                hfrq.NavigateUrl = "Page_TongjiBiao.aspx?rq=True&xsrqstart=" + txb_xsrq_start.Text.Trim() +
                    "&xsrqend=" + txb_xsrq_end.Text.Trim() + "&fdid=" + cmb_fd.SelectedValue;
                //hfrq.NavigateUrl = "javascript:$('#hid_rq_bool').val('True');$('#form_main').submit()";
                hfrq.Text = "日期";
                grid_xiaoshou.Columns.Add(hfrq);

                HyperLinkField hffd = new HyperLinkField();
                hffd.NavigateUrl = "Page_TongjiBiao.aspx?fd=True&xsrqstart=" + txb_xsrq_start.Text.Trim() +
                    "&xsrqend=" + txb_xsrq_end.Text.Trim() + "&fdid=" + cmb_fd.SelectedValue;
                //hffd.NavigateUrl = "javascript:$('#hid_fd_bool').val('True');$('#form_main').submit()";
                hffd.Text = "分店";
                grid_xiaoshou.Columns.Add(hffd);

                HyperLinkField hfmx = new HyperLinkField();
                hfmx.NavigateUrl = "Page_Xiaoshou.aspx?fdid=" + cmb_fd.SelectedValue +
                    "&xsrqstart=" + txb_xsrq_start.Text.Trim() + "&xsrqend=" + txb_xsrq_end.Text.Trim();
                hfmx.Text = "明细";
                grid_xiaoshou.Columns.Add(hfmx);
            }

            grid_xiaoshou.DataSource = dt;
            grid_xiaoshou.DataBind();
        }

        protected void grid_xiaoshou_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }
    }
}