using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

namespace JCSJGL
{
    public partial class Page_FDKucun : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //初始化分店下拉框
                DBContext db = new DBContext();
                TFendian[] fs = db.GetFendiansAsItems();
                Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
                cmb_fd.Items.Insert(0,"");
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

            int recordCount = 0;
            DBContext db = new DBContext();
            TFendianKucun[] jcs = db.GetFDKucunByCond(fdid, grid_kc.PageSize, grid_kc.PageIndex,out recordCount);
            var xs = jcs.Select(r => new
            {
                id = r.id,
                fendian = r.TFendian.dianming,
                kucunshuliang = r.TFendianKucunMXes.Sum(mr=>mr.shuliang),
                chengbenjine = r.TFendianKucunMXes.Sum(mr=>mr.TTiaoma.jinjia*mr.shuliang),
                shoujiajine = r.TFendianKucunMXes.Sum(mr=>mr.TTiaoma.shoujia*mr.shuliang),
                r.shangbaoshijian
            });

            grid_kc.VirtualItemCount = recordCount;
            grid_kc.DataSource = Tool.CommonFunc.LINQToDataTable(xs);
            grid_kc.DataBind();
        }

        /// <summary>
        /// 换页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_kc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_kc.PageIndex = e.NewPageIndex;
            search();
        }
    }
}