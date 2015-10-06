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

                TFendian[] fs = null;
                //初始化分店下拉框
                int? jmsid = null;
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    //显示搜索
                    div_sch_jms.Visible = true;

                    //品牌商
                    TJiamengshang[] jmss = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmss, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有品牌商", ""));

                    //加盟商
                    Tool.CommonFunc.InitDropDownList(cmb_zjms, jmss, "mingcheng", "id");
                    cmb_zjms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    //分店
                    if (Request["jmsid"] != null)
                    {
                        cmb_zjms.SelectedValue = Request["jmsid"];
                        TFendian[] zyds = db.GetFendiansAsItems(jmsid.Value);
                    }
                    else
                    {
                        fs = new TFendian[] { };
                    }
                }
                else
                {
                    //显示搜索
                    div_sch_jms.Visible = false;
                    jmsid = _LoginUser.jmsid;
                    //加载子加盟商，包括自己
                    TJiamengshangGX[] zjmsgxes = db.GetZiJiamengshangGXes(jmsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_zjms, zjmsgxes, "bzmingcheng", "jmsid");
                    cmb_zjms.Items.Insert(0, new ListItem(_LoginUser.TJiamengshang.mingcheng, _LoginUser.jmsid.ToString()));
                    cmb_zjms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.店长)
                    {
                        fs = db.GetUserFendiansByUserId(_LoginUser.id).Select(r => r.TFendian).ToArray();
                    }
                    else
                    {
                        //加载所有的直营店和加盟分店
                        TFendian[] zyds = db.GetFendiansAsItems(jmsid);
                        TFendian[] jmds = db.GetFendiansOfPinpaiAsItems(jmsid.Value);
                        fs = zyds.Concat(jmds).ToArray();
                    }

                    //如果没有子加盟商，就不用显示下拉框查询条件了
                    if (_LoginUser.TJiamengshang.zjmsshu <= 0)
                    {
                        div_sch_zjms.Visible = false;
                    }
                    else
                    {
                        //如果是店长，限制为可见的分店数据
                        if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.店长)
                        {
                            div_sch_zjms.Visible = false;
                        }
                        else
                        {
                            div_sch_zjms.Visible = true;
                        }
                    }
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
                bzmcs = db.GetZiJiamengshangGXes(_LoginUser.jmsid).ToDictionary(k => k.jmsid, v => v.bzmingcheng);
                bzmcs.Add(_LoginUser.jmsid, _LoginUser.TJiamengshang.mingcheng);
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
            DBContext db = new DBContext();
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                grid_jms.Columns[0].Visible = true;
                grid_jms_rq.Columns[0].Visible = true;
            }
            else
            {
                //没有子加盟商的，就不在表格里显示加盟商名称了
                if (_LoginUser.TJiamengshang.zjmsshu <= 0)
                {
                    grid_jms.Columns[0].Visible = false;
                    grid_jms_rq.Columns[0].Visible = false;
                }
                else
                {
                    if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.店长)
                    {
                        grid_jms.Columns[0].Visible = false;
                        grid_jms_rq.Columns[0].Visible = false;
                    }
                    else
                    {
                        grid_jms.Columns[0].Visible = true;
                        grid_jms_rq.Columns[0].Visible = true;
                    }
                }
            }

            //限定查询的品牌范围
            int[] ppids = getPPids();
            int[] jmsids = getJmsids();
            int[] fdids = getFdids();     
            int[] ijmsids = jmsids.Skip(grid_jms.PageSize * grid_jms.PageIndex).Take(grid_jms.PageSize).ToArray();
            //加盟商的备注名称
            Dictionary<int, string> bzmcs = getBeizhuMcs();   

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
            TXiaoshou[] xss = db.GetXiaoshousByCond(ppids, ijmsids, fdids, "", "", xsrq_start, xsrq_end, null, null, null, null, out recordCount);

            var data = xss.GroupBy(r => new { jms = r.TFendian.Jms.mingcheng, r.TFendian.jmsid }).Select(r => new
            {
                jmsid = r.Key.jmsid,
                jms = bzmcs[r.Key.jmsid],
                xl = r.Sum(g => g.shuliang),
                xse = decimal.Round(r.Sum(g => g.jine), 2),
                lr = decimal.Round(r.Sum(g => g.lirun), 2)
            });

            int[] misids = ijmsids.Except(data.Select(r => r.jmsid)).ToArray();
            var misdata = misids.Select(r => new
            {
                jmsid = r,
                jms = bzmcs[r],
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

            grid_jms.VirtualItemCount = jmsids.Length;
            grid_jms.DataSource = Tool.CommonFunc.LINQToDataTable(adata);
            grid_jms.DataBind();
        }

        private int[] getFdids()
        {
            int[] fdids = new int[] { };

            //下拉框没有选择全部，那就只查询选定的分店的数据
            if (!string.IsNullOrEmpty(cmb_fd.SelectedValue))
            {
                int fdid = int.Parse(cmb_fd.SelectedValue);
                fdids = new int[] { fdid };
            }
            //如果选择的是全部
            else
            {
                //如果是店长，则也限定为权限内可见范围的数据
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.店长)
                {
                    DBContext db = new DBContext();
                    TUserFendian[] ufs = db.GetUserFendiansByUserId(_LoginUser.id);
                    fdids = ufs.Select(r => r.fendianid).ToArray();
                }
            }

            return fdids;
        }
        /// <summary>
        /// 限定要查询的销售所属的分店的加盟商ID
        /// </summary>
        /// <returns></returns>
        private int[] getJmsids()
        {
            DBContext db = new DBContext();
            List<int> jmsids = new List<int>();
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                //加盟商
                if (!string.IsNullOrEmpty(cmb_zjms.SelectedValue))
                {
                    jmsids.Add(int.Parse(cmb_zjms.SelectedValue));
                }
                else
                {
                    //不选择一个特定的，就查询所有加盟商
                    TJiamengshang[] jmses = db.GetJiamengshangs();
                    jmsids.AddRange(jmses.Select(r => r.id));
                }
            }
            else
            {
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.店长)
                {
                    jmsids.Add(_LoginUser.jmsid);
                }
                else
                {
                    //如果下拉框有选择，就只查询选择的子加盟商的数据
                    if (!string.IsNullOrEmpty(cmb_zjms.SelectedValue))
                    {
                        jmsids.Add(int.Parse(cmb_zjms.SelectedValue));
                    }
                    else
                    {
                        //非系统管理员或总经理，只能查询自己直营店和加盟商的销售数据
                        TJiamengshang[] jmses = db.GetZiJiamengshangs(_LoginUser.jmsid);
                        jmsids.AddRange(jmses.Select(r => r.id));
                        jmsids.Add(_LoginUser.jmsid);
                    }
                }
            }
            return jmsids.ToArray();
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
            int[] ppids = getPPids();
            int[] jmsids = new int[] { jmsid };
            int[] fdids = getFdids();
            Dictionary<int, string> bzmcs = getBeizhuMcs();
            int recordCount = 0;
            TXiaoshou[] xss = db.GetXiaoshousByCond(ppids,jmsids, fdids,"","", xsrq_start, xsrq_end, null, null, null, null, out recordCount);
            if (e.CommandName == "FENDIAN")
            {
                TFendian[] fds = new TFendian[]{};
                if (!string.IsNullOrEmpty(cmb_fd.SelectedValue))
                {
                    fds = new TFendian[] { new TFendian { id = int.Parse(cmb_fd.SelectedValue), dianming = cmb_fd.SelectedItem.Text } };
                }
                else
                {
                    fds = db.GetFendians(ppids, jmsid);
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
            int[] ppids = getPPids();
            int[] jmsids = new int[] { jmsid };
            int[] fdids = new int[] { };
            int recordCount = 0;
            TXiaoshou[] xss = db.GetXiaoshousByCond(ppids, jmsids, fdids, "", "", rq_start, rq_end, null, null, null, null, out recordCount);
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
            int[] ppids = getPPids();
            int[] jmsids = new int[] { jmsid };
            int[] fdids = new int[] { fdid };
            int recordCount = 0;
            TXiaoshou[] xss = db.GetXiaoshousByCond(ppids,jmsids, fdids,"","", xsrq_start, xsrq_end, null, null, null, null, out recordCount);
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
                    lppids.Add(int.Parse(cmb_jms.SelectedValue));
                }
            }
            else
            {
                //grid_xiaoshou.Columns[0].Visible = false;
                TJiamengshang[] pps = db.GetFuJiamengshangs(_LoginUser.jmsid);
                lppids.AddRange(pps.Select(r => r.id));
                lppids.Add(_LoginUser.jmsid);
            }

            return lppids.ToArray();
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

            cmb_zjms.Items.Clear();
            cmb_fd.Items.Clear();
            TJiamengshang[] zjmses;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                TFendian[] fs;
                DBContext db = new DBContext();
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    int jmsid = int.Parse(cmb_jms.SelectedValue);
                    TJiamengshang jms = db.GetJiamengshangById(jmsid);
                    //子加盟商
                    zjmses = db.GetZiJiamengshangs(jmsid);
                    Tool.CommonFunc.InitDropDownList(cmb_zjms, zjmses, "mingcheng", "id");
                    cmb_zjms.Items.Insert(0, new ListItem(jms.mingcheng, jmsid.ToString()));
                    cmb_zjms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    //分店
                    TFendian[] zyds = db.GetFendiansAsItems(jmsid);
                    TFendian[] jmds = db.GetFendiansOfPinpaiAsItems(jmsid);
                    fs = zyds.Concat(jmds).ToArray();
                }
                else
                {
                    zjmses = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_zjms, zjmses, "mingcheng", "id");
                    cmb_zjms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    fs = new TFendian[] { };
                }

                Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
                cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
            }
            else
            {
                //其他角色不可能触发该事件，如果有，判定为浏览器操作漏洞
                throw new MyException("非法操作，请刷新页面重新执行", null);
            }
        }

        /// <summary>
        /// 分店下拉框数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmb_zjms_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBContext db = new DBContext();
            int? jmsid = null;
            TFendian[] fs;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
               _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    jmsid = int.Parse(cmb_jms.SelectedValue);
                    if (!string.IsNullOrEmpty(cmb_zjms.SelectedValue))
                    {
                        //加载属于某子加盟商的并且加盟到某品牌商的分店
                        int zjmsid = int.Parse(cmb_zjms.SelectedValue);
                        fs = db.GetFendiansAsItems(zjmsid).Where(r => r.ppid == jmsid.Value).ToArray();
                    }
                    else
                    {
                        //加载属于某品牌商的，和加盟到该品牌的分店
                        TFendian[] zyds = db.GetFendiansAsItems(jmsid);
                        TFendian[] jmds = db.GetFendiansOfPinpaiAsItems(jmsid.Value);
                        fs = zyds.Concat(jmds).ToArray();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(cmb_zjms.SelectedValue))
                    {
                        //加载属于某子加盟商的并且加盟到某品牌商的分店
                        int zjmsid = int.Parse(cmb_zjms.SelectedValue);
                        fs = db.GetFendiansAsItems(zjmsid);
                    }
                    else
                    {
                        fs = new TFendian[] { };
                    }
                }
            }
            else
            {
                jmsid = _LoginUser.jmsid;
                if (!string.IsNullOrEmpty(cmb_zjms.SelectedValue))
                {
                    //加载属于某子加盟商的并且加盟到某品牌商的分店
                    int zjmsid = int.Parse(cmb_zjms.SelectedValue);
                    if (zjmsid == jmsid)
                    {
                        //子加盟商选择了自己，表示某品牌商想查看自己的直营店
                        fs = db.GetFendiansAsItems(zjmsid);
                    }
                    else
                    {
                        fs = db.GetFendiansAsItems(zjmsid).Where(r => r.ppid == jmsid).ToArray();
                    }
                }
                else
                {
                    //加载属于某品牌商的，和加盟到该品牌的分店
                    TFendian[] zyds = db.GetFendiansAsItems(jmsid);
                    TFendian[] jmds = db.GetFendiansOfPinpaiAsItems(jmsid.Value);
                    fs = zyds.Concat(jmds).ToArray();
                }
            }

            Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
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