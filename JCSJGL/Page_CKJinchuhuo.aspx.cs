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
                DBContext db = new DBContext();

                TCangku[] fs = null;
                //隐藏搜索条件
                div_sch_jms.Visible = false;

                //初始化分店下拉框
                int? jmsid = null;
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    //显示搜索
                    div_sch_jms.Visible = true;

                    TJiamengshang[] jmss = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmss, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    fs = new TCangku[] { };
                }
                else
                {
                    jmsid = _LoginUser.jmsid;
                    fs = db.GetCangkusAsItems(jmsid);
                }

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
            DBContext db = new DBContext();
            int? ckid = null;
            if (!string.IsNullOrEmpty(cmb_ck.SelectedValue))
            {
                ckid = int.Parse(cmb_ck.SelectedValue);
            }
            int? jmsid = null;
            Dictionary<int,string> jmses = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                 _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    jmsid = int.Parse(cmb_jms.SelectedValue);
                } 
                grid_jinchu.Columns[0].Visible = true;
                jmses = db.GetJiamengshangs().ToDictionary(k=>k.id,v=>v.mingcheng);
            }
            else
            {
                jmsid = _LoginUser.jmsid;
                grid_jinchu.Columns[0].Visible = false;
                jmses = db.GetZiJiamengshangGXes(jmsid.Value).ToDictionary(k=>k.id,v=>v.bzmingcheng);
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
                jianshu = r.TCangkuJinchuhuoMXes.Sum(mr => mr.shuliang),
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

        protected void cmb_jms_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_jinchu.DataSource = null;
            grid_jinchu.DataBind();

            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                cmb_ck.Items.Clear();
                DBContext db = new DBContext();
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    int jmsid = int.Parse(cmb_jms.SelectedValue);
                    TCangku[] fs = db.GetCangkusAsItems(jmsid);

                    Tool.CommonFunc.InitDropDownList(cmb_ck, fs, "mingcheng", "id");
                    cmb_ck.Items.Insert(0, new ListItem("所有仓库", ""));
                }
                else
                {
                    cmb_ck.Items.Insert(0, new ListItem("所有仓库", ""));
                }
            }
            else
            {
                //其他角色不可能触发该事件，如果有，判定为浏览器操作漏洞
                throw new MyException("非法操作，请刷新页面重新执行", null);
            }
        }

        protected void grid_jinchu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = int.Parse(grid_jinchu.DataKeys[index].Value.ToString());

            if (e.CommandName == "MX")
            {
                Response.Redirect(string.Format("Page_CKJinchuhuoMX.aspx?id={0}", id));
            }
        }

    }
}