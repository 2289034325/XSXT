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
    public partial class Page_TongjiBiao : MyPage
    {
        public Page_TongjiBiao()
        {
            _PageName = PageName.统计表;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DBContext db = new DBContext();

                TFendian[] fs = null;
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

                    //由于数据量，默认加载当前登陆用户的加盟商的数据
                    //fs = new TFendian[] { };
                    cmb_jms.SelectedValue = _LoginUser.jmsid.ToString();
                    fs = db.GetFendiansAsItems(jmsid);
                }
                else
                {
                    jmsid = _LoginUser.jmsid;
                    fs = db.GetFendiansAsItems(jmsid);
                }

                Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
                cmb_fd.Items.Insert(0, new ListItem("所有分店",""));

                //日期下拉框
                txb_xsrq_start.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txb_xsrq_end.Text = DateTime.Now.ToString("yyyy-MM-dd");

                btn_sch_Click(null, null);
            }
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sch_Click(object sender, EventArgs e)
        {
            int? jmsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    jmsid = int.Parse(cmb_jms.SelectedValue);
                }

                grid_jms.Columns[0].Visible = true;
                grid_jms_rq.Columns[0].Visible = true;
            }
            else
            {
                grid_jms.Columns[0].Visible = false;
                grid_jms_rq.Columns[0].Visible = false;

                jmsid = _LoginUser.jmsid;
            }
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
                xsrq_end = DateTime.Parse(txb_xsrq_end.Text.Trim()).Date.AddDays(1);
            }

            DBContext db = new DBContext();
            int recordCount = 0;
            TXiaoshou[] xss = db.GetXiaoshousByCond(jmsid, fdid, xsrq_start, xsrq_end, null, null, null, null, out recordCount);

            var data = xss.GroupBy(r => new { jms = r.TFendian.TJiamengshang.mingcheng, r.TFendian.jmsid }).Select(r => new
            {
                jmsid = r.Key.jmsid,
                jms = r.Key.jms,
                xl = r.Sum(g => g.shuliang),
                xse = decimal.Round(r.Sum(g => g.jine), 2),
                lr = decimal.Round(r.Sum(g => g.lirun), 2)
            });

            grid_jms.DataSource = null;
            grid_jms.DataBind();
            grid_jms_rq.DataSource = null;
            grid_jms_rq.DataBind();
            grid_fd.DataSource = null;
            grid_fd.DataBind();
            grid_rq_fd.DataSource = null;
            grid_rq_fd.DataBind();

            grid_jms.DataSource = Tool.CommonFunc.LINQToDataTable(data);
            grid_jms.DataBind();
        }


        protected void grid_jms_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int jmsid = int.Parse(grid_jms.DataKeys[index].Value.ToString());

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

            grid_jms.DataSource = null;
            grid_jms.DataBind();
            grid_jms_rq.DataSource = null;
            grid_jms_rq.DataBind();
            grid_fd.DataSource = null;
            grid_fd.DataBind();
            grid_rq_fd.DataSource = null;
            grid_rq_fd.DataBind();

            DBContext db = new DBContext();
            int recordCount = 0;
            TXiaoshou[] xss = db.GetXiaoshousByCond(jmsid, null, xsrq_start, xsrq_end, null, null, null, null, out recordCount);
            if (e.CommandName == "FENDIAN")
            {

                var data = xss.GroupBy(r => new { jmsid = r.TFendian.jmsid, fdid = r.fendianid, fd = r.TFendian.dianming }).Select(r => new
                {
                    jmsid = r.Key.jmsid,
                    fdid = r.Key.fdid,
                    fd = r.Key.fd,
                    xl = r.Sum(g => g.shuliang),
                    xse = decimal.Round(r.Sum(g => g.jine), 2),
                    lr = decimal.Round(r.Sum(g => g.lirun), 2)
                });

                grid_fd.DataSource = Tool.CommonFunc.LINQToDataTable(data);
                grid_fd.DataBind();
            }
            else if (e.CommandName == "RIQI")
            {
                var data = xss.GroupBy(r => new
                {
                    jmsid = r.TFendian.jmsid,
                    jms = r.TFendian.TJiamengshang.mingcheng,
                    rq = r.xiaoshoushijian.ToString("yyyy-MM-dd")
                }).Select(r => new
                {
                    jmsid = r.Key.jmsid,
                    jms = r.Key.jms,
                    rq = r.Key.rq,
                    xl = r.Sum(g => g.shuliang),
                    xse = decimal.Round(r.Sum(g => g.jine), 2),
                    lr = decimal.Round(r.Sum(g => g.lirun), 2)
                }).OrderBy(r => r.rq);

                grid_jms_rq.DataSource = Tool.CommonFunc.LINQToDataTable(data);
                grid_jms_rq.DataBind();
            }
            else if (e.CommandName == "XIANGXI")
            {
                Response.Redirect(string.Format("Page_Xiaoshou.aspx?fdid=&xsrqstart={0}&xsrqend={1}", 
                    txb_xsrq_start.Text.Trim(), txb_xsrq_end.Text.Trim()));
            }
        }

        protected void grid_jms_rq_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int jmsid = int.Parse(grid_jms_rq.DataKeys[index].Values[0].ToString());
            string rq_s = grid_jms_rq.DataKeys[index].Values[1].ToString();
            DateTime rq_start = DateTime.Parse(rq_s);
            DateTime rq_end = rq_start.Date.AddDays(1);

            grid_jms.DataSource = null;
            grid_jms.DataBind();
            grid_jms_rq.DataSource = null;
            grid_jms_rq.DataBind();
            grid_fd.DataSource = null;
            grid_fd.DataBind();
            grid_rq_fd.DataSource = null;
            grid_rq_fd.DataBind();

            DBContext db = new DBContext();
            int recordCount = 0;
            TXiaoshou[] xss = db.GetXiaoshousByCond(jmsid, null, rq_start, rq_end, null, null, null, null, out recordCount);
            if (e.CommandName == "FENDIAN")
            {
                var data = xss.GroupBy(r => new {jmsid = r.TFendian.jmsid,rq=r.xiaoshoushijian.ToString("yyyy-MM-dd"), fdid = r.fendianid, fd = r.TFendian.dianming }).Select(r => new
                {
                    jmsid = r.Key.jmsid,
                    fdid = r.Key.fdid,
                    fd = r.Key.fd,
                    rq = r.Key.rq,
                    xl = r.Sum(g => g.shuliang),
                    xse = decimal.Round(r.Sum(g => g.jine), 2),
                    lr = decimal.Round(r.Sum(g => g.lirun), 2)
                });

                grid_rq_fd.DataSource = Tool.CommonFunc.LINQToDataTable(data);
                grid_rq_fd.DataBind();
            }
            else if (e.CommandName == "XIANGXI")
            {
                Response.Redirect(string.Format("Page_Xiaoshou.aspx?jmsid={0}&fdid=&xsrqstart={1}&xsrqend={1}",jmsid, rq_s));
            }
        }

        protected void grid_fd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int jmsid = int.Parse(grid_fd.DataKeys[index].Values[0].ToString());
            int fdid = int.Parse(grid_fd.DataKeys[index].Values[1].ToString());

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

            grid_jms.DataSource = null;
            grid_jms.DataBind();
            grid_jms_rq.DataSource = null;
            grid_jms_rq.DataBind();
            grid_fd.DataSource = null;
            grid_fd.DataBind();
            grid_rq_fd.DataSource = null;
            grid_rq_fd.DataBind();

            DBContext db = new DBContext();
            int recordCount = 0;
            TXiaoshou[] xss = db.GetXiaoshousByCond(jmsid, fdid, xsrq_start, xsrq_end, null, null, null, null, out recordCount);
            if (e.CommandName == "RIQI")
            {
                var data = xss.GroupBy(r => new { jmsid = r.TFendian.jmsid, rq = r.xiaoshoushijian.ToString("yyyy-MM-dd"), fdid = r.fendianid, fd = r.TFendian.dianming }).Select(r => new
                {
                    jmsid = r.Key.jmsid,
                    fdid = r.Key.fdid,
                    fd = r.Key.fd,
                    rq = r.Key.rq,
                    xl = r.Sum(g => g.shuliang),
                    xse = decimal.Round(r.Sum(g => g.jine), 2),
                    lr = decimal.Round(r.Sum(g => g.lirun), 2)
                });

                grid_rq_fd.DataSource = Tool.CommonFunc.LINQToDataTable(data);
                grid_rq_fd.DataBind();
            }
            else if (e.CommandName == "XIANGXI")
            {
                Response.Redirect(string.Format("Page_Xiaoshou.aspx?jmsid={0}&fdid={1}&xsrqstart={2}&xsrqend={3}", 
                    jmsid, fdid,txb_xsrq_start.Text.Trim(),txb_xsrq_end.Text.Trim()));
            }
        }

        protected void grid_fd_rq_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int jmsid = int.Parse(grid_rq_fd.DataKeys[index].Values[0].ToString());
            int fdid = int.Parse(grid_rq_fd.DataKeys[index].Values[1].ToString());
            string rq_s = grid_rq_fd.DataKeys[index].Values[2].ToString();
            if (e.CommandName == "XIANGXI")
            {
                Response.Redirect(string.Format("Page_Xiaoshou.aspx?jmsid={0}&fdid={1}&xsrqstart={2}&xsrqend={2}",
                    jmsid, fdid, rq_s));
            }
        }

        protected void cmb_jms_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_jms.DataSource = null;
            grid_jms.DataBind();
            grid_jms_rq.DataSource = null;
            grid_jms_rq.DataBind();
            grid_fd.DataSource = null;
            grid_fd.DataBind();
            grid_rq_fd.DataSource = null;
            grid_rq_fd.DataBind();

            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                cmb_fd.Items.Clear();
                DBContext db = new DBContext();
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    int jmsid = int.Parse(cmb_jms.SelectedValue);
                    TFendian[] fs = db.GetFendiansAsItems(jmsid);

                    Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
                    cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                }
                else
                {
                    cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                }
            }
            else
            {
                //其他角色不可能触发该事件，如果有，判定为浏览器操作漏洞
                throw new MyException("非法操作，请刷新页面重新执行", null);
            }
        }

        
    }
}