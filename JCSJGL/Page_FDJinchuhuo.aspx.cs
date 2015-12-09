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
    public partial class Page_FDJinchuhuo : MyPage
    {
        public Page_FDJinchuhuo()
        {
            _PageName = PageName.分店进出货;
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

                    //分店
                    TFendian[] fds = db.GetFendians(int.Parse(cmb_jms.SelectedValue));
                    Tool.CommonFunc.InitDropDownList(cmb_fd, fds, "dianming", "id");
                    cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                }
                else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商经理)
                {
                    //隐藏搜索条件
                    div_sch_jms.Visible = false;
                    grid_jinchu.Columns[0].Visible = false;

                    TFendian[] fds = db.GetFendians(_LoginUser.jmsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_fd, fds, "dianming", "id");
                    cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                }
                
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
            grid_jinchu.DataSource = null;
            grid_jinchu.DataBind();
            grid_mx.DataSource = null;
            grid_mx.DataBind();

            search();           
        }

        private void search()
        {
            string kh = txb_kh.Text.Trim();
            string tm = txb_tm.Text.Trim();
            
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

            DBContext db = new DBContext();
            int[] fdids = getFdids();
            int recordCount = 0;
            TFendianJinchuhuo[] jcs = db.GetFDJinchuhuoByCond(fdids,kh,tm,
                xsrq_start, xsrq_end, null, null,
                grid_jinchu.PageSize, grid_jinchu.PageIndex, out recordCount);
            var xs = jcs.Select(r => new
            {
                id = r.id,
                jiamengshang = r.TFendian.TJiamengshang.mingcheng,
                fendian = r.TFendian.dianming,
                fangxiang = ((Tool.JCSJ.DBCONSTS.JCH_FX)r.fangxiang).ToString(),
                lyqx = ((Tool.JCSJ.DBCONSTS.LYQX_FD)r.laiyuanquxiang).ToString(),
                jianshu = r.TFendianJinchuhuoMXes.Sum(mr => (short?)mr.shuliang) ?? 0,
                jinjia = r.TFendianJinchuhuoMXes.Sum(mr => (decimal?)mr.TTiaoma.jinjia * mr.shuliang) ?? 0,
                shoujia = r.TFendianJinchuhuoMXes.Sum(mr => (decimal?)mr.TTiaoma.shoujia * mr.shuliang) ?? 0,
                r.beizhu,
                r.fashengshijian,
                r.shangbaoshijian
            });

            grid_jinchu.VirtualItemCount = recordCount;
            grid_jinchu.DataSource = Tool.CommonFunc.LINQToDataTable(xs);
            grid_jinchu.DataBind();
        }       

        private int[] getFdids()
        {
            DBContext db = new DBContext();
            int[] fdids = new int[] { };


            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (string.IsNullOrEmpty(cmb_fd.SelectedValue))
                {
                    int jmsid = int.Parse(cmb_jms.SelectedValue);
                    TFendian[] fds = db.GetFendiansAsItems(jmsid);
                    fdids = fds.Select(r => r.id).ToArray();
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

            return fdids;
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


        /// <summary>
        /// 子加盟商下拉框变动，加载相应的分店
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmb_jms_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBContext db = new DBContext();
            cmb_fd.Items.Clear();

            int jmsid = int.Parse(cmb_jms.SelectedValue);
            TFendian[] fs = db.GetFendians(jmsid);

            Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
            cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
        }

        protected void grid_jinchu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                return;
            }

            int index = Convert.ToInt32(e.CommandArgument);
            int id = int.Parse(grid_jinchu.DataKeys[index].Value.ToString());

            if (e.CommandName == "MX")
            {
                DBContext db = new DBContext();
                TFendianJinchuhuoMX[] amxs = db.GetFDJinchuhuoMXsByJcId(id);

                var mxs = amxs.Select(r => new
                {
                    r.TTiaoma.tiaoma,
                    r.TTiaoma.TKuanhao.kuanhao,
                    r.TTiaoma.gyskuanhao,
                    leixing = ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)r.TTiaoma.TKuanhao.leixing).ToString(),
                    r.TTiaoma.TKuanhao.pinming,
                    r.TTiaoma.yanse,
                    r.TTiaoma.chima,
                    r.TTiaoma.jinjia,
                    r.TTiaoma.shoujia,
                    r.shuliang
                });

                grid_mx.DataSource = Tool.CommonFunc.LINQToDataTable(mxs);
                grid_mx.DataBind();
            }
        }

    }
}