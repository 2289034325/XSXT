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
    public partial class Page_Fendian_TongjiBiao : MyPage
    {
        public Page_Fendian_TongjiBiao()
        {
            _PageName = PageName.分店销售统计表;
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
                    //cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    //分店
                    int jmsid = int.Parse(cmb_jms.SelectedValue);
                    TFendian[] fds = db.GetFendians(jmsid);
                    Tool.CommonFunc.InitDropDownList(cmb_fd, fds, "dianming", "id");
                    cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                }
                else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商经理)
                {
                    //加盟商
                    TJiamengshang[] jmses = db.GetZiJiamengshangs(_LoginUser.ppsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmses, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                }
                else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商经理)
                {
                    //隐藏搜索条件
                    div_sch_jms.Visible = false;
                    grid_jms.Columns[0].Visible = false;
                    grid_jms_rq.Columns[0].Visible = false;

                    //分店
                    TFendian[] fds = db.GetFendians(_LoginUser.jmsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_fd, fds, "dianming", "id");
                    cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                }

                //日期下拉框
                txb_xsrq_start.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txb_xsrq_end.Text = DateTime.Now.ToString("yyyy-MM-dd");

                //非系统管理员进来时，自动加载数据
                if (!(_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理))
                {
                    btn_sch_Click(null, null);
                }
            }
        }

        /// <summary>
        /// 取子加盟商的备注名称
        /// </summary>
        /// <param name="jmsid"></param>
        /// <returns></returns>
        private Dictionary<int, string> getBeizhuMcs()
        {
            DBContext db = new DBContext();

            Dictionary<int, string> bzmcs = new Dictionary<int, string>();
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                bzmcs = db.GetJiamengshangs().ToDictionary(k => k.id, v => v.mingcheng);
            }
            else
            {
                bzmcs = db.GetZiJiamengGXes(_LoginUser.ppsid.Value).ToDictionary(k => k.jmsid, v => v.bzmingcheng);
            }

            return bzmcs;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sch_Click(object sender, EventArgs e)
        {
            grid_jms.DataSource = null;
            grid_jms.DataBind();
            grid_jms_rq.DataSource = null;
            grid_jms_rq.DataBind();
            grid_fd.DataSource = null;
            grid_fd.DataBind();
            grid_rq_fd.DataSource = null;
            grid_rq_fd.DataBind();

            DBContext db = new DBContext();
            //if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
            //        _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            //{
            //    grid_jms.Columns[0].Visible = true;
            //    grid_jms_rq.Columns[0].Visible = true;
            //}
            //else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员 ||
            //        _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商经理)
            //{
            //    grid_jms.Columns[0].Visible = true;
            //    grid_jms_rq.Columns[0].Visible = true;
            //}
            //else
            //{
            //    grid_jms.Columns[0].Visible = false;
            //    grid_jms_rq.Columns[0].Visible = false;
            //}

            //限定查询的品牌范围
            int? ppsid = getPpsid();
            int[] fdids = getFdids();     
            //加盟商的备注名称
            //Dictionary<int, string> bzmcs = getBeizhuMcs();   

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

            int recordCount = 0;
            TXiaoshou[] xss = db.GetXiaoshousByCond(ppsid, fdids, "", "", xsrq_start, xsrq_end, null, null, null, null, out recordCount);

            var data = xss.GroupBy(r => new { jms = r.TFendian.TJiamengshang.mingcheng, r.TFendian.jmsid }).Select(r => new
            {
                jmsid = r.Key.jmsid,
                jms = r.Key.jms,
                xl = r.Sum(g => (short?)g.shuliang) ?? 0,
                xse = decimal.Round(r.Sum(g => (decimal?)g.jine) ?? 0, 2),
                lr = decimal.Round(r.Sum(g => (decimal?)g.lirun) ?? 0, 2)
            });

            grid_jms.DataSource = Tool.CommonFunc.LINQToDataTable(data);
            grid_jms.DataBind();
        }

        private int? getPpsid()
        {
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商经理)
            {
                return _LoginUser.ppsid.Value;
            }

            return null;
        }

        private int[] getFdids()
        {
            DBContext db = new DBContext();
            int[] fdids = null;
            
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
            else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员 ||
                 _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商经理)
            {
                if (string.IsNullOrEmpty(cmb_fd.SelectedValue))
                {
                    if (string.IsNullOrEmpty(cmb_jms.SelectedValue))
                    {
                        TFendian[] fds = db.GetFendiansOfPinpaiAsItems(_LoginUser.ppsid.Value);
                        fdids = fds.Select(r => r.id).ToArray();
                    }
                    else
                    {
                        int jmsid = int.Parse(cmb_jms.SelectedValue);
                        TFendian[] fds = db.GetFendiansAsItems(jmsid);
                        fdids = fds.Select(r => r.id).ToArray();
                    }
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


            DBContext db = new DBContext();
            int? ppsid = getPpsid();
            int[] fdids = getFdids();
            Dictionary<int, string> bzmcs = getBeizhuMcs();
            int recordCount = 0;
            TXiaoshou[] xss = db.GetXiaoshousByCond(ppsid, fdids, "", "", xsrq_start, xsrq_end, null, null, null, null, out recordCount);
            if (e.CommandName == "FENDIAN")
            {
                TFendian[] fds = new TFendian[]{};
                if (!string.IsNullOrEmpty(cmb_fd.SelectedValue))
                {
                    fds = new TFendian[] { new TFendian { id = int.Parse(cmb_fd.SelectedValue), dianming = cmb_fd.SelectedItem.Text } };
                }
                else
                {
                    fds = db.GetFendians(jmsid);
                }
                var data = xss.GroupBy(r => new { jmsid = r.TFendian.jmsid, fdid = r.fendianid, fd = r.TFendian.dianming }).Select(r => new
                {
                    jmsid = r.Key.jmsid,
                    fdid = r.Key.fdid,
                    fd = r.Key.fd,
                    xl = r.Sum(g => g.shuliang),
                    xse = decimal.Round(r.Sum(g => g.jine), 2),
                    lr = decimal.Round(r.Sum(g => g.lirun), 2)
                });
                Dictionary<int, string> fdmcs = fds.ToDictionary(k => k.id, v => v.dianming);
                int[] aids = fds.Select(r => r.id).ToArray();
                int[] misids = aids.Except(data.Select(r => r.fdid)).ToArray();
                var misdata = misids.Select(r => new
                {
                    jmsid = jmsid,
                    fdid = r,
                    fd = fdmcs[r],
                    xl = 0,
                    xse = 0M,
                    lr = 0M
                });

                var adata = data.Concat(misdata);

                grid_jms.DataSource = null;
                grid_jms.DataBind();
                grid_jms_rq.DataSource = null;
                grid_jms_rq.DataBind();
                grid_fd.DataSource = null;
                grid_fd.DataBind();
                grid_rq_fd.DataSource = null;
                grid_rq_fd.DataBind();

                grid_fd.DataSource = Tool.CommonFunc.LINQToDataTable(adata);
                grid_fd.DataBind();
            }
            else if (e.CommandName == "RIQI")
            {
                var data = xss.GroupBy(r => new
                {
                    jmsid = r.TFendian.jmsid,
                    jms = bzmcs[r.TFendian.jmsid],
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

                grid_jms.DataSource = null;
                grid_jms.DataBind();
                grid_jms_rq.DataSource = null;
                grid_jms_rq.DataBind();
                grid_fd.DataSource = null;
                grid_fd.DataBind();
                grid_rq_fd.DataSource = null;
                grid_rq_fd.DataBind();

                grid_jms_rq.DataSource = Tool.CommonFunc.LINQToDataTable(data);
                grid_jms_rq.DataBind();
            }
            else if (e.CommandName == "XIANGXI")
            {
                Response.Redirect(string.Format("Page_Xiaoshou.aspx?jmsid={0}&fdid={1}&xsrqstart={2}&xsrqend={3}",
                   jmsid, cmb_fd.SelectedValue, txb_xsrq_start.Text.Trim(), txb_xsrq_end.Text.Trim()));
            }
        }

        protected void grid_jms_rq_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Page")
            {
                return;
            }

            int index = Convert.ToInt32(e.CommandArgument);
            int jmsid = int.Parse(grid_jms_rq.DataKeys[index].Values[0].ToString());
            string rq_s = grid_jms_rq.DataKeys[index].Values[1].ToString();
            DateTime rq_start = DateTime.Parse(rq_s);
            DateTime rq_end = rq_start.Date.AddDays(1);


            DBContext db = new DBContext();
            int? ppsid = getPpsid();
            int[] fdids = new int[] { };
            int recordCount = 0;
            TXiaoshou[] xss = db.GetXiaoshousByCond(ppsid, fdids, "", "", rq_start, rq_end, null, null, null, null, out recordCount);
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

                grid_jms.DataSource = null;
                grid_jms.DataBind();
                grid_jms_rq.DataSource = null;
                grid_jms_rq.DataBind();
                grid_fd.DataSource = null;
                grid_fd.DataBind();
                grid_rq_fd.DataSource = null;
                grid_rq_fd.DataBind();

                grid_rq_fd.DataSource = Tool.CommonFunc.LINQToDataTable(data);
                grid_rq_fd.DataBind();
            }
            else if (e.CommandName == "XIANGXI")
            {
                Response.Redirect(string.Format("Page_Xiaoshou.aspx?jmsid={0}&fdid={1}&xsrqstart={2}&xsrqend={2}",jmsid,cmb_fd.SelectedValue, rq_s));
            }
        }

        protected void grid_fd_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Page")
            {
                return;
            }

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

            DBContext db = new DBContext();
            int? ppsid = getPpsid();
            int[] fdids = new int[] { fdid };
            int recordCount = 0;
            TXiaoshou[] xss = db.GetXiaoshousByCond(ppsid, fdids, "", "", xsrq_start, xsrq_end, null, null, null, null, out recordCount);
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


                grid_jms.DataSource = null;
                grid_jms.DataBind();
                grid_jms_rq.DataSource = null;
                grid_jms_rq.DataBind();
                grid_fd.DataSource = null;
                grid_fd.DataBind();
                grid_rq_fd.DataSource = null;
                grid_rq_fd.DataBind();

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
            if (e.CommandName == "Page")
            {
                return;
            }

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

        /// <summary>
        /// 分店下拉框数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmb_jms_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_fd.Items.Clear();

            DBContext db = new DBContext();

            if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))            
            {
                int jmsid = int.Parse(cmb_jms.SelectedValue);
                TFendian[] fs = db.GetFendiansAsItems(jmsid);
                Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
            }

            cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
        }

        /// <summary>
        /// 换页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_jms_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_jms.PageIndex = e.NewPageIndex;
            btn_sch_Click(null, null);
        }
    }
}