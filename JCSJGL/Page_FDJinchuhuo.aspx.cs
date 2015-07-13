using DB_JCSJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

namespace JCSJGL
{
    public partial class Page_FDJinchuhuo : System.Web.UI.Page
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

                //日期下拉框
                txb_fsrq_start.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txb_fsrq_end.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //txb_sbrq_start.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //txb_sbrq_end.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
        { //取查询条件
            int? fdid = null;
            if (!string.IsNullOrEmpty(cmb_fd.SelectedValue))
            {
                fdid = int.Parse(cmb_fd.SelectedValue);
            }
            DateTime? xsrq_start = null;
            DateTime? xsrq_end = null;
            if (!string.IsNullOrEmpty(txb_fsrq_start.Text.Trim()))
            {
                xsrq_start = DateTime.Parse(txb_fsrq_start.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txb_fsrq_end.Text.Trim()))
            {
                xsrq_end = DateTime.Parse(txb_fsrq_end.Text.Trim());
            }
            DateTime? sbrq_start = null;
            DateTime? sbrq_end = null;
            if (!string.IsNullOrEmpty(txb_sbrq_start.Text.Trim()))
            {
                sbrq_start = DateTime.Parse(txb_sbrq_start.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txb_sbrq_end.Text.Trim()))
            {
                sbrq_end = DateTime.Parse(txb_sbrq_end.Text.Trim());
            }

            int recordCount = 0;
            DBContext db = new DBContext();
            TFendianJinchuhuo[] jcs = db.GetFDJinchuhuoByCond(fdid,
                xsrq_start, xsrq_end, sbrq_start, sbrq_end,
                grid_jinchu.PageSize, grid_jinchu.PageIndex, out recordCount);
            var xs = jcs.Select(r => new
            {
                id = r.id,
                fendian = r.TFendian.dianming,
                fangxiang = ((Tool.JCSJ.DBCONSTS.JCH_FX)r.fangxiang).ToString(),
                lyqx = ((Tool.JCSJ.DBCONSTS.JCH_LYQX)r.laiyuanquxiang).ToString(),
                jianshu = r.TFendianJinchuhuoMX.Sum(mr=>mr.shuliang),
                r.beizhu,
                r.fashengshijian,
                r.shangbaoshijian
            });

            grid_jinchu.VirtualItemCount = recordCount;
            grid_jinchu.DataSource = Tool.CommonFunc.LINQToDataTable(xs);
            grid_jinchu.DataBind();
        }

        /// <summary>
        /// 换页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_jinchu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_jinchu.PageIndex = e.NewPageIndex;
            search();
        }

    }
}