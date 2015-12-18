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
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    //加盟商
                    TJiamengshang[] jmses = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmses, "mingcheng", "id");
                    //cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));
                }
                else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商经理)
                {
                    //加盟商
                    TJiamengshang[] jmses = db.GetZiJiamengshangs(_LoginUser.ppsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmses, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));
                }
                else
                {
                    //隐藏搜索条件
                    div_sch_jms.Visible = false;
                    grid_kc_jms.Columns[0].Visible = false;               
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
            grid_kc_jms.DataSource = null;
            grid_kc_jms.DataBind();
            grid_kc_fd.DataSource = null;
            grid_kc_fd.DataBind();
            grid_mx.DataSource = null;
            grid_mx.DataBind();

            DBContext db = new DBContext();

            int? ppsid = null;
            int[] fdids = new int[] { };
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                int jmsid = int.Parse(cmb_jms.SelectedValue);
                TFendian[] fds = db.GetFendians(jmsid);
                fdids = fds.Select(r => r.id).ToArray();
            }
            else if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商经理)
            {
                ppsid = _LoginUser.ppsid.Value;
                if (string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    TFendian[] fds = db.GetFendiansOfPinpaiAsItems(ppsid.Value);
                    fdids = fds.Select(r => r.id).ToArray();
                }
            }
            else
            {
                TFendian[] fds = db.GetFendians(_LoginUser.jmsid.Value);
                fdids = fds.Select(r => r.id).ToArray();
            }

            TFendianKucun[] jcs = db.GetFDKucunByCond(ppsid,fdids);
            var xs = jcs.Select(r => new
            {
                jmsid = r.TFendian.jmsid,
                jms = r.TFendian.TJiamengshang.mingcheng,
                fdid = r.fendianid,
                fendian = r.TFendian.dianming,
                kucunshuliang = r.TFendianKucunMXes.Sum(mr => (int?)mr.shuliang)??0,
                jine = r.TFendianKucunMXes.Sum(mr => (decimal?)mr.danjia * mr.shuliang)??0,
                r.shangbaoshijian
            });

            //按加盟商分组合并库存
            var data = xs.GroupBy(r => new { r.jmsid, r.jms }).Select(r => new
            {
                id = r.Key.jmsid,
                jiamengshang = r.Key.jms,
                kucunshuliang = r.Sum(xr => xr.kucunshuliang),
                jine = decimal.Round(r.Sum(xr => xr.jine), 2)
            });

            grid_kc_jms.DataSource = Tool.CommonFunc.LINQToDataTable(data);
            grid_kc_jms.DataBind();
        }

        /// <summary>
        /// 查看加盟商的分店库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_kc_jms_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                return;
            }

            if (e.CommandName == "FDKC")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int jmsid = int.Parse(grid_kc_jms.DataKeys[index].Value.ToString());

                DBContext db = new DBContext();
                TFendian[] fds = db.GetFendians(jmsid);
                int[] fdids = fds.Select(r => r.id).ToArray();

                int? ppsid = null;
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员 ||
                        _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商经理)
                {
                    ppsid = _LoginUser.ppsid.Value;
                }

                TFendianKucun[] jcs = db.GetFDKucunByCond(ppsid,fdids);
                var xs = jcs.Select(r => new
                {
                    r.id,
                    jiamengshang = r.TFendian.TJiamengshang.mingcheng,
                    fdid = r.fendianid,
                    fendian = r.TFendian.dianming,
                    kucunshuliang = r.TFendianKucunMXes.Sum(mr => mr.shuliang),
                    jine = r.TFendianKucunMXes.Sum(mr => mr.danjia * mr.shuliang),
                    r.shangbaoshijian
                });

                grid_kc_fd.DataSource = Tool.CommonFunc.LINQToDataTable(xs);
                grid_kc_fd.DataBind();
            }
        }

        protected void grid_kc_fd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                return;
            }

            int index = Convert.ToInt32(e.CommandArgument);
            int id = int.Parse(grid_kc_fd.DataKeys[index].Value.ToString()); 
            
            int? ppsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商经理)
            {
                ppsid = _LoginUser.ppsid.Value;
            }

            if (e.CommandName == "MX")
            {
                DBContext db = new DBContext();
                TFendianKucunMX[] amxs = db.GetFDKucunMXsByKcId(ppsid,id);

                var mxs = amxs.Select(r => new
                {
                    r.TTiaoma.tiaoma,
                    r.TTiaoma.TKuanhao.kuanhao,
                    r.TTiaoma.gyskuanhao,
                    leixing = ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)r.TTiaoma.TKuanhao.leixing).ToString(),
                    r.TTiaoma.TKuanhao.pinming,
                    r.TTiaoma.yanse,
                    r.TTiaoma.chima,
                    jinjia = r.danjia,
                    diaopaijia = r.TTiaoma.shoujia,
                    r.shuliang,
                    r.jinhuoriqi
                });

                grid_mx.DataSource = Tool.CommonFunc.LINQToDataTable(mxs);
                grid_mx.DataBind();
            }
        }
    }
}