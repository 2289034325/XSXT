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
    public partial class Page_Xiaoshou : MyPage
    {
        public Page_Xiaoshou()
        {
            _PageName = PageName.销售数据;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DBContext db = new DBContext();

                //子加盟商和分店下拉框
                TFendian[] fs = new TFendian[] { };

                //隐藏搜索条件
                div_sch_jms.Visible = false;

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
                        jmsid = int.Parse(Request["jmsid"]);
                        cmb_zjms.SelectedValue = Request["jmsid"];
                        fs = db.GetFendiansAsItems(jmsid.Value);
                    }
                }
                else
                {
                    jmsid = _LoginUser.jmsid;
                    //加载子加盟商，包括自己
                    TJiamengshangGX[] zjmsgxes = db.GetZiJiamengshangGXes(jmsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_zjms, zjmsgxes, "bzmingcheng", "jmsid");
                    cmb_zjms.Items.Insert(0, new ListItem(_LoginUser.TJiamengshang.mingcheng, _LoginUser.jmsid.ToString()));
                    cmb_zjms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    if (Request["jmsid"] != null)
                    {
                        //加载属于指定子加盟商的分店
                        int zjmsid = int.Parse(Request["jmsid"]);
                        cmb_zjms.SelectedValue = Request["jmsid"];
                        if (zjmsid == jmsid)
                        {
                            //如果是店长，限制为可见的分店数据
                            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.店长)
                            {
                                fs = db.GetUserFendiansByUserId(_LoginUser.id).Select(r => r.TFendian).ToArray();
                            }
                            else
                            {
                                //子加盟商ID和加盟商ID相同，表示想查看自己的所有店
                                fs = db.GetFendiansAsItems(zjmsid); 
                            }
                        }
                        //查看子加盟商的分店数据，所以要将分店的品牌限制为查看者加盟商ID，不让其看到非加盟店的数据
                        else
                        {
                            fs = db.GetFendiansAsItems(zjmsid).Where(r => r.ppid == jmsid.Value).ToArray();
                        }
                    }
                    else
                    {
                        //如果是店长，限制为可见的分店数据
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
                    }

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
                cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));

                //日期下拉框
                txb_xsrq_start.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txb_xsrq_end.Text = DateTime.Now.ToString("yyyy-MM-dd");

                //取得get参数
                if (Request["fdid"] != null)
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
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                }

                if (Request.UrlReferrer != null)
                {
                    if (!string.IsNullOrEmpty(Request.UrlReferrer.ToString()))
                    {
                        //从别的页面过来，才直接加在数据
                        searchXiaoshou();
                    }
                }
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
            //如果是品牌商查询，将子加盟商的名称替换为备注名称
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

            //限定查询范围
            int[] jmsids = getJmsids();
            int[] ppids = getPPids();
            int[] fdids = getFdids();


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
            DateTime? sbrq_start = null;
            DateTime? sbrq_end = null;
            if (!string.IsNullOrEmpty(txb_sbrq_start.Text.Trim()))
            {
                sbrq_start = DateTime.Parse(txb_sbrq_start.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txb_sbrq_end.Text.Trim()))
            {
                sbrq_end = DateTime.Parse(txb_sbrq_end.Text.Trim()).Date.AddDays(1);
            }
            string kh = txb_kh.Text.Trim();
            string tm = txb_tm.Text.Trim();

            int recordCount = 0;
            TXiaoshou[] xss = db.GetXiaoshousByCond(ppids,jmsids,fdids,kh,tm,
                xsrq_start, xsrq_end, sbrq_start, sbrq_end,
                grid_xiaoshou.PageSize, grid_xiaoshou.PageIndex, out recordCount);
            var xs = xss.Select(r => new
            {
                jiamengshang = bzmcs[r.TFendian.jmsid],
                fendian = r.TFendian.dianming,
                kuanhao = r.TTiaoma==null?"":r.TTiaoma.TKuanhao.kuanhao,
                leixing = r.TTiaoma == null ? "" : ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)r.TTiaoma.TKuanhao.leixing).ToString(),
                pinming = r.TTiaoma == null ? "" : r.TTiaoma.TKuanhao.pinming,
                tiaoma = r.TTiaoma == null ? "" : r.TTiaoma.tiaoma,
                yanse = r.TTiaoma == null ? "" : r.TTiaoma.yanse,
                chima = r.TTiaoma == null ? "" : r.TTiaoma.chima,
                r.shuliang,
                r.jinjia,
                r.shoujia,
                r.zhekou,
                r.moling,
                jiage = r.jine,
                lirun = r.lirun,
                huiyuan = r.THuiyuan == null ? "" :r.THuiyuan.xingming,
                r.xiaoshouyuan,
                r.xiaoshoushijian,
                r.shangbaoshijian,
                r.beizhu
                
            });

            grid_xiaoshou.VirtualItemCount = recordCount;
            grid_xiaoshou.DataSource = Tool.CommonFunc.LINQToDataTable(xs);
            grid_xiaoshou.DataBind();
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
        /// 取得当前用户可查询那些品牌的销售数据
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 取得当前用户可查询哪些加盟商的销售数据
        /// </summary>
        /// <returns></returns>
        private int[] getJmsids()
        {
            List<int> jmsids = new List<int>();
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                //加盟商
                if (!string.IsNullOrEmpty(cmb_zjms.SelectedValue))
                {
                    jmsids.Add(int.Parse(cmb_zjms.SelectedValue));
                }
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
                    DBContext db = new DBContext();
                    TJiamengshang[] jmses = db.GetZiJiamengshangs(_LoginUser.jmsid);
                    jmsids.AddRange(jmses.Select(r => r.id));
                    jmsids.Add(_LoginUser.jmsid);
                }
            }
            return jmsids.ToArray();
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

        /// <summary>
        /// 下拉框联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmb_jms_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_xiaoshou.DataSource = null;
            grid_xiaoshou.DataBind();
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
        /// 子加盟商下拉框变动，加载相应的分店
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
    }
}