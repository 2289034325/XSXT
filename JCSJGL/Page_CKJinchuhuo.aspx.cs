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
    public partial class Page_CKJinchuhuo : MyPage
    {
        public Page_CKJinchuhuo()
        {
            _PageName = PageName.仓库进出货;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //初始化仓库下拉框
                DBContext db = new DBContext();
                int? jmsid = null;
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {

                }
                else
                {
                    jmsid = _LoginUser.jmsid;
                }

                TCangku[] fs = db.GetCangkusAsItems(jmsid);
                Tool.CommonFunc.InitDropDownList(cmb_ck, fs, "mingcheng", "id");
                cmb_ck.Items.Insert(0,new ListItem("所有仓库",""));

                //日期下拉框
                txb_fsrq_start.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txb_fsrq_end.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
            int? ckid = null;
            if (!string.IsNullOrEmpty(cmb_ck.SelectedValue))
            {
                ckid = int.Parse(cmb_ck.SelectedValue);
            }
            int? jmsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                 _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                //系统管理员和总经理可以按全部的加盟商数据
                grid_jinchu.Columns[0].Visible = true;
            }
            else
            {
                jmsid = _LoginUser.jmsid;
                grid_jinchu.Columns[0].Visible = false;
            }
            DateTime? xsrq_start = null;
            DateTime? xsrq_end = null;
            if (!string.IsNullOrEmpty(txb_fsrq_start.Text.Trim()))
            {
                xsrq_start = DateTime.Parse(txb_fsrq_start.Text.Trim()).Date;
            }
            if (!string.IsNullOrEmpty(txb_fsrq_end.Text.Trim()))
            {
                xsrq_end = DateTime.Parse(txb_fsrq_end.Text.Trim()).Date.AddDays(1);
            }
            DateTime? sbrq_start = null;
            DateTime? sbrq_end = null;
            if (!string.IsNullOrEmpty(txb_sbrq_start.Text.Trim()))
            {
                sbrq_start = DateTime.Parse(txb_sbrq_start.Text.Trim()).Date;
            }
            if (!string.IsNullOrEmpty(txb_sbrq_end.Text.Trim()))
            {
                sbrq_end = DateTime.Parse(txb_sbrq_end.Text.Trim()).Date.AddDays(1);
            }

            int recordCount = 0;
            DBContext db = new DBContext();
            TCangkuJinchuhuo[] jcs = db.GetCKJinchuhuoByCond(jmsid, ckid,
                xsrq_start, xsrq_end, sbrq_start, sbrq_end,
                grid_jinchu.PageSize, grid_jinchu.PageIndex, out recordCount);
            var xs = jcs.Select(r => new
            {
                id = r.id,
                jiamengshang = r.TCangku.TJiamengshang.mingcheng,
                cangku = r.TCangku.mingcheng,
                fangxiang = ((Tool.JCSJ.DBCONSTS.JCH_FX)r.fangxiang).ToString(),
                lyqx = ((Tool.JCSJ.DBCONSTS.JCH_LYQX)r.laiyuanquxiang).ToString(),
                jianshu = r.TCangkuJinchuhuoMXes.Sum(mr=>mr.shuliang),
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