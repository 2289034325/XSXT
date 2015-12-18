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
                
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    //加盟商
                    TJiamengshang[] jmss = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmss, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    //分店
                    cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                }
                else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员 ||
                   _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商经理)
                {
                    grid_xiaoshou.Columns[0].Visible = false;

                    //加盟商
                    TJiamengshang[] jmss = db.GetZiJiamengshangs(_LoginUser.ppsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmss, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    //分店
                    cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                }
                else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商管理员 ||
                   _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商经理)
                {
                    div_sch_jms.Visible = false;
                    grid_xiaoshou.Columns[1].Visible = false;

                    //分店
                    TFendian[] fds = db.GetFendiansAsItems(_LoginUser.jmsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_fd, fds, "dianming", "id");
                    cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                }

                //日期下拉框
                txb_xsrq_start.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txb_xsrq_end.Text = DateTime.Now.ToString("yyyy-MM-dd");

                //取得get参数
                if (Request["jmsid"] != null)
                {
                    cmb_jms.SelectedValue = Request["jmsid"];

                    if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                    {
                        int jmsid = int.Parse(cmb_jms.SelectedValue);
                        TFendian[] fds = db.GetFendiansAsItems(jmsid);
                        Tool.CommonFunc.InitDropDownList(cmb_fd, fds, "dianming", "id");
                        cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                    }
                }
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
                if (!string.IsNullOrEmpty(Request["kh"]))
                {
                    txb_kh.Text = Request["kh"];
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
            grid_xiaoshou.PageIndex = 0;
            searchXiaoshou();           
        }

        private void searchXiaoshou()
        {
            //TODO:如果是品牌商查询，将子加盟商的名称替换为备注名称
            //Dictionary<int, string> bzmcs = new Dictionary<int, string>();
            //if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
            //        _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            //{
            //    bzmcs = db.GetJiamengshangs().ToDictionary(k => k.id, v => v.mingcheng);
            //}
            //else
            //{
            //    bzmcs = db.GetZiJiamengGXes(_LoginUser.jmsid).ToDictionary(k => k.jmsid, v => v.bzmingcheng);
            //    bzmcs.Add(_LoginUser.jmsid, _LoginUser.TJiamengshang.mingcheng);
            //}

            //限定查询范围
            //int[] jmsids = getJmsids();
            //int[] ppids = getPPids();

            int? ppsid = getPpsid();
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
            //if (!string.IsNullOrEmpty(txb_sbrq_start.Text.Trim()))
            //{
            //    sbrq_start = DateTime.Parse(txb_sbrq_start.Text.Trim());
            //}
            //if (!string.IsNullOrEmpty(txb_sbrq_end.Text.Trim()))
            //{
            //    sbrq_end = DateTime.Parse(txb_sbrq_end.Text.Trim()).Date.AddDays(1);
            //}
            string kh = txb_kh.Text.Trim();
            string tm = txb_tm.Text.Trim();

            DBContext db = new DBContext();
            int recordCount = 0;
            TXiaoshou[] xss = db.GetXiaoshousByCond(ppsid,fdids,kh,tm,
                xsrq_start, xsrq_end, sbrq_start, sbrq_end,
                grid_xiaoshou.PageSize, grid_xiaoshou.PageIndex, out recordCount);
            var xs = xss.Select(r => new
            {
                pinpaishang = r.TTiaoma == null ? "" : r.TTiaoma.TPinpaishang.mingcheng,
                jiamengshang = r.TFendian.TJiamengshang.mingcheng,
                fendian = r.TFendian.dianming,
                kuanhao = r.TTiaoma == null ? "" : r.TTiaoma.TKuanhao.kuanhao,
                pinming = r.TTiaoma == null ? "" : r.TTiaoma.TKuanhao.pinming,
                tiaoma = r.TTiaoma == null ? "" : r.TTiaoma.tiaoma,
                yanse = r.TTiaoma == null ? "" : r.TTiaoma.yanse,
                chima = r.TTiaoma == null ? "" : r.TTiaoma.chima,
                r.shuliang,
                r.jinjia,
                diaopaijia = r.shoujia,
                r.zhekou,
                r.moling,
                jiage = r.jine,
                lirun = r.lirun,
                huiyuan = r.THuiyuan == null ? "" : r.THuiyuan.xingming,
                r.xiaoshouyuan,
                r.xiaoshoushijian,
                r.shangbaoshijian,
                r.beizhu
            });
               

            grid_xiaoshou.VirtualItemCount = recordCount;
            grid_xiaoshou.DataSource = Tool.CommonFunc.LINQToDataTable(xs);
            grid_xiaoshou.DataBind();
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
                    if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
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
        /// 加盟商下拉框变动，加载相应的分店
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmb_jms_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_fd.Items.Clear();

            DBContext db = new DBContext();

            if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
            {
                TFendian[] fds = db.GetFendiansAsItems(int.Parse(cmb_jms.SelectedValue));
                Tool.CommonFunc.InitDropDownList(cmb_fd, fds, "dianming", "id");
            }

            cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));    
        }
    }
}