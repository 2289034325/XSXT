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

                    if (Request["jmsid"] != null)
                    {
                        cmb_jms.SelectedValue = Request["jmsid"];
                        fs = db.GetFendiansAsItems(jmsid);
                    }
                    else
                    {
                        fs = new TFendian[] { };
                    }
                }
                else
                {
                    jmsid = _LoginUser.jmsid;
                    fs = db.GetFendiansAsItems(jmsid);
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
            int? jmsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    jmsid = int.Parse(cmb_jms.SelectedValue);
                } 
                grid_xiaoshou.Columns[0].Visible = true;
            }
            else
            {
                grid_xiaoshou.Columns[0].Visible = false;
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

            int recordCount = 0;
            DBContext db = new DBContext();
            TXiaoshou[] xss = db.GetXiaoshousByCond(jmsid,fdid,
                xsrq_start, xsrq_end, sbrq_start, sbrq_end,
                grid_xiaoshou.PageSize, grid_xiaoshou.PageIndex, out recordCount);
            var xs = xss.Select(r => new
            {
                jiamengshang = r.TFendian.Jms.mingcheng,
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