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
    public partial class Page_Xiaoshou : System.Web.UI.Page
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
                txb_xsrq_start.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txb_xsrq_end.Text = DateTime.Now.ToString("yyyy-MM-dd");

                //取得get参数
                if (Request["fdid"]!= null)
                {
                    cmb_fd.SelectedValue = Request["fdid"];
                } 
                if (Request["xsrqstart"] != null)
                {
                    txb_xsrq_start.Text = Request["xsrqstart"];
                } 
                if (Request["xsrqend"] != null)
                {
                    txb_xsrq_end.Text = Request["xsrqend"];
                }

                searchXiaoshou();    
            }
        }
        

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sch_Click(object sender, EventArgs e)
        {
            searchXiaoshou();           
        }

        private void searchXiaoshou()
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
            TXiaoshou[] xss = db.GetXiaoshousByCond(fdid,
                xsrq_start, xsrq_end, sbrq_start, sbrq_end,
                grid_xiaoshou.PageSize, grid_xiaoshou.PageIndex, out recordCount);
            var xs = xss.Select(r => new
            {
                fendian = r.TFendian.dianming,
                r.TTiaoma.TKuanhao.kuanhao,
                leixing = (Tool.JCSJ.DBCONSTS.KUANHAO_LX)r.TTiaoma.TKuanhao.leixing,
                r.TTiaoma.TKuanhao.pinming,
                r.TTiaoma.tiaoma,
                r.TTiaoma.yanse,
                r.TTiaoma.chima,
                r.shuliang,
                r.danjia,
                r.zhekou,
                r.moling,
                jiage = decimal.Round(r.shuliang * r.danjia * r.zhekou / 10 - r.moling, 2),
                huiyuan = r.THuiyuan == null ? "" : "√",
                r.xiaoshouyuan,
                r.xiaoshoushijian,
                r.shangbaoshijian
            });

            grid_xiaoshou.VirtualItemCount = recordCount;
            grid_xiaoshou.DataSource = Tool.CommonFunc.LINQToDataTable(xs);
            grid_xiaoshou.DataBind();
        }

        /// <summary>
        /// 换页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_xiaoshou_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_xiaoshou.PageIndex = e.NewPageIndex;
            searchXiaoshou();
        }
    }
}