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
                //隐藏搜索条件
                div_sch_pps.Visible = false;

                //初始化分店下拉框
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    //显示搜索
                    div_sch_pps.Visible = true;

                    //品牌商
                    TPinpaishang[] ppses = db.GetPinpaishangs(null);
                    Tool.CommonFunc.InitDropDownList(cmb_pps, ppses, "mingcheng", "id");
                    cmb_pps.Items.Insert(0, new ListItem("所有品牌商", ""));

                    //加盟商
                    TJiamengshang[] jmses = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_jms, ppses, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    //仓库
                    cmb_ck.Items.Insert(0, new ListItem("所有仓库", ""));
                }
                else
                {
                    //仓库
                    TCangku[] fs = db.GetCangkusAsItems(_LoginUser.ppsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_ck, fs, "mingcheng", "id");
                    cmb_ck.Items.Insert(0, new ListItem("所有仓库", ""));

                    //加盟商
                    TJiamengshang[] jmses = db.GetZiJiamengshangs(_LoginUser.ppsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmses, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    grid_jinchu.Columns[0].Visible = false;
                }

                //来源去向
                Tool.CommonFunc.InitDropDownList(cmb_lyqx, typeof(Tool.JCSJ.DBCONSTS.LYQX_CK));
                cmb_lyqx.Items.Insert(0, new ListItem("", ""));


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
            int? ppsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                 _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_pps.SelectedValue))
                {
                    ppsid = int.Parse(cmb_pps.SelectedValue);
                } 
            }
            else
            {
                ppsid = _LoginUser.ppsid;
            }
            int? jmsid = null; 
            if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
            {
                jmsid = int.Parse(cmb_jms.SelectedValue);
            }
            string picima = txb_pcm.Text.Trim();
            string tiaoma = txb_tm.Text.Trim();
            byte? lyqx = null;
            if (!string.IsNullOrEmpty(cmb_lyqx.SelectedValue))
            {
                lyqx = byte.Parse(cmb_lyqx.SelectedValue);
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

            int recordCount = 0;
            TCangkuJinchuhuo[] jcs = db.GetCKJinchuhuoByCond(ppsid, ckid,picima,tiaoma,lyqx,jmsid,
                xsrq_start, xsrq_end, grid_jinchu.PageSize, grid_jinchu.PageIndex, out recordCount);
            var xs = jcs.Select(r => new
            {
                id = r.id,
                pinpaishang = r.TCangku.TPinpaishang.mingcheng,
                cangku = r.TCangku.mingcheng,
                picima = r.picima,
                fangxiang = ((Tool.JCSJ.DBCONSTS.JCH_FX)r.fangxiang).ToString(),
                lyqx = ((Tool.JCSJ.DBCONSTS.LYQX_CK)r.laiyuanquxiang).ToString(),
                jiamengshang = r.TJiamengshang == null ? "" : r.TJiamengshang.mingcheng,
                jianshu = r.TCangkuJinchuhuoMXes.Sum(mr => mr.shuliang),
                zhekou = r.zhekou,
                zhongjia = r.TCangkuJinchuhuoMXes.Sum(mr => (short?)mr.shuliang * mr.danjia) ?? 0,
                r.beizhu,
                r.fashengshijian,
                r.shangbaoshijian
            });

            grid_jinchu.VirtualItemCount = recordCount;
            grid_jinchu.DataSource = Tool.CommonFunc.LINQToDataTable(xs);
            grid_jinchu.DataBind();

            grid_mx.DataSource = null;
            grid_mx.DataBind();
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

        protected void cmb_pps_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_ck.Items.Clear();
            DBContext db = new DBContext();
            if (!string.IsNullOrEmpty(cmb_pps.SelectedValue))
            {
                int jmsid = int.Parse(cmb_pps.SelectedValue);
                TCangku[] fs = db.GetCangkusAsItems(jmsid);

                Tool.CommonFunc.InitDropDownList(cmb_ck, fs, "mingcheng", "id");
                cmb_ck.Items.Insert(0, new ListItem("所有仓库", ""));
            }
            else
            {
                cmb_ck.Items.Insert(0, new ListItem("所有仓库", ""));
            }
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
                //加载详细数据
                TCangkuJinchuhuoMX[] mxes = db.GetCKJinchuhuoMXsByJcId(id);
                var data = mxes.Select(r => new 
                {
                    tiaoma = r.TTiaoma.tiaoma,
                    kuanhao = r.TTiaoma.TKuanhao.kuanhao,
                    pinming = r.TTiaoma.TKuanhao.pinming,
                    yanse = r.TTiaoma.yanse,
                    chima = r.TTiaoma.chima,
                    danjia = r.danjia,
                    diaopaijia = r.TTiaoma.shoujia,
                    zhekou = decimal.Round(r.danjia/r.TTiaoma.shoujia*10,2),
                    shuliang = r.shuliang
                });

                grid_mx.DataSource = Tool.CommonFunc.LINQToDataTable(data);
                grid_mx.DataBind();
            }
        }

    }
}