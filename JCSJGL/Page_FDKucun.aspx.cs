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
    public partial class Page_FDKucun : MyPage
    {
        public Page_FDKucun()
        {
            _PageName = PageName.分店库存;
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

                    //加载所有的直营店和加盟分店
                    TFendian[] zyds = db.GetFendiansAsItems(jmsid);
                    TFendian[] jmds = db.GetFendiansOfPinpaiAsItems(jmsid.Value);
                    fs = zyds.Concat(jmds).ToArray();

                    if (_LoginUser.TJiamengshang.zjmsshu <= 0)
                    {
                        div_sch_zjms.Visible = false;
                    }
                    else
                    {
                        div_sch_zjms.Visible = true;
                    }
                }

                Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
                cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));

                //string fdid_s = Request["fdid"];
                //if (!string.IsNullOrEmpty(fdid_s))
                //{
                //    int fdid = int.Parse(fdid_s);
                //    cmb_fd.SelectedValue = fdid.ToString();

                //    //加载某分店的历史库存
                //    loadHistroy(fdid);
                //}
                //else
                //{
                //    //加载总库存和加盟商旗下的每个分店的最新库存数据
                //    loadKCOfFendians(null);
                //}
            }
        }

        /// <summary>
        /// 加载所有分店的最新库存数据
        /// </summary>
        private void loadKCOfFendians(int? fdid)
        {
            grid_kc_total.Visible = true;
            grid_kc_fd.Visible = true;
            grid_kc.Visible = false;

            DBContext db = new DBContext();
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                grid_kc_total.Columns[0].Visible = true;
                grid_kc_fd.Columns[0].Visible = true;
            }
            else
            {
                if (_LoginUser.TJiamengshang.zjmsshu <= 0)
                {
                    grid_kc_total.Columns[0].Visible = false;
                    grid_kc_fd.Columns[0].Visible = false;
                }
                else
                {
                    grid_kc_total.Columns[0].Visible = true;
                    grid_kc_fd.Columns[0].Visible = true;
                }
            }

            //限定查询的品牌范围
            int[] ppids = getPPids();
            int? jmsid = getJmsid();
            TFendianKucun[] jcs = db.GetFDKucunByCond(ppids,jmsid, fdid, true);
            var xs = jcs.Select(r => new
            {
                jiamengshang = r.TFendian.Jms.mingcheng,
                fdid = r.fendianid,
                fendian = r.TFendian.dianming,
                kucunshuliang = r.TFendianKucunMXes.Sum(mr => mr.shuliang),
                chengbenjine = r.TFendianKucunMXes.Sum(mr => mr.TTiaoma.jinjia * mr.shuliang),
                shoujiajine = r.TFendianKucunMXes.Sum(mr => mr.TTiaoma.shoujia * mr.shuliang),
                r.shangbaoshijian
            });

            grid_kc_fd.DataSource = Tool.CommonFunc.LINQToDataTable(xs);
            grid_kc_fd.DataBind();

            //总库存
            var data = xs.GroupBy(r=>r.jiamengshang).Select(r => new
            {
                jiamengshang = r.Key,
                kucunshuliang = r.Sum(xr => xr.kucunshuliang),
                chengbenjine = decimal.Round(r.Sum(xr => xr.chengbenjine), 2),
                shoujiajine = decimal.Round(r.Sum(xr => xr.shoujiajine), 2),
                shangbaoshijian = r.Min(xr=>(DateTime?)xr.shangbaoshijian)
            });

            grid_kc_total.DataSource = Tool.CommonFunc.LINQToDataTable(data);
            grid_kc_total.DataBind();
        }

        /// <summary>
        /// 加载某个分店的历史库存数据
        /// </summary>
        /// <param name="fdid"></param>
        private void loadHistroy(int fdid)
        {
            grid_kc_total.Visible = false;
            grid_kc_fd.Visible = false;
            grid_kc.Visible = true;

            DBContext db = new DBContext();
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                grid_kc.Columns[0].Visible = true;
            }
            else
            {
                if (_LoginUser.TJiamengshang.zjmsshu <= 0)
                {
                    grid_kc.Columns[0].Visible = false;
                }
                else
                {
                    grid_kc.Columns[0].Visible = true;
                }
            }

            //限定查询的品牌范围
            int[] ppids = getPPids();
            int? jmsid = getJmsid();
            TFendianKucun[] jcs = db.GetFDKucunByCond(ppids, jmsid, fdid, false);
            var xs = jcs.Select(r => new
            {
                jiamengshang = r.TFendian.Jms.mingcheng,
                id = r.id,
                fendian = r.TFendian.dianming,
                kucunshuliang = r.TFendianKucunMXes.Sum(mr => mr.shuliang),
                chengbenjine = r.TFendianKucunMXes.Sum(mr => mr.TTiaoma.jinjia * mr.shuliang),
                shoujiajine = r.TFendianKucunMXes.Sum(mr => mr.TTiaoma.shoujia * mr.shuliang),
                r.shangbaoshijian
            });

            grid_kc.DataSource = Tool.CommonFunc.LINQToDataTable(xs);
            grid_kc.DataBind();
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sch_Click(object sender, EventArgs e)
        {
            //取查询条件
            int? fdid = null;
            if (!string.IsNullOrEmpty(cmb_fd.SelectedValue))
            {
                fdid = int.Parse(cmb_fd.SelectedValue);
            }

            loadKCOfFendians(fdid);
        }

        /// <summary>
        /// 删除一个库存历史记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_kc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //检查权限
            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            int id = int.Parse(grid_kc.DataKeys[e.RowIndex].Value.ToString());

            DBContext db = new DBContext();
            TFendianKucun ok = db.GetFDKucunById(id);
            if (ok.TFendian.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法删除该数据", null);
            }

            db.DeleteFDKucun(id); 

            loadHistroy(ok.fendianid);
        }

        protected void cmb_jms_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_kc_total.DataSource = null;
            grid_kc_total.DataBind();
            grid_kc_fd.DataSource = null;
            grid_kc_fd.DataBind();
            grid_kc.DataSource = null;
            grid_kc.DataBind();

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
        /// 查看某分店的历史库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_kc_fd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int fdid = int.Parse(grid_kc_fd.DataKeys[index].Value.ToString());
            if (e.CommandName == "LSKC")
            {
                loadHistroy(fdid);
            }
        }
        private int? getJmsid()
        {
            int? jmsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                //加盟商
                if (!string.IsNullOrEmpty(cmb_zjms.SelectedValue))
                {
                    jmsid = int.Parse(cmb_zjms.SelectedValue);
                }
            }
            else
            {
                if (_LoginUser.TJiamengshang.zjmsshu <= 0)
                {
                    jmsid = _LoginUser.jmsid;
                }
                else
                {
                    //子加盟商
                    if (!string.IsNullOrEmpty(cmb_zjms.SelectedValue))
                    {
                        jmsid = int.Parse(cmb_zjms.SelectedValue);
                    }
                }
            }

            return jmsid;
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
    }
}