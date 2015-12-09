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
    public partial class Page_CKKucun : MyPage
    {
        public Page_CKKucun()
        {
            _PageName = PageName.仓库库存;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //初始化分店下拉框
                DBContext db = new DBContext();

                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    TPinpaishang[] jmss = db.GetPinpaishangs(null);
                    Tool.CommonFunc.InitDropDownList(cmb_pps, jmss, "mingcheng", "id");
                    cmb_pps.Items.Insert(0, new ListItem("所有品牌商", ""));

                    cmb_ck.Items.Insert(0, new ListItem("所有仓库", ""));
                }
                else
                {
                    //隐藏搜索条件
                    div_sch_pps.Visible = false;
                    grid_kc.Columns[0].Visible = false;

                    TCangku[] fs = db.GetCangkusAsItems(_LoginUser.ppsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_ck, fs, "mingcheng", "id");
                    cmb_ck.Items.Insert(0, new ListItem("所有仓库", ""));
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
                ppsid = _LoginUser.ppsid.Value;
            }

            int? ckid = null;
            if (!string.IsNullOrEmpty(cmb_ck.SelectedValue))
            {
                ckid = int.Parse(cmb_ck.SelectedValue);
            }

            DBContext db = new DBContext();
            TCangkuKucun[] jcs = db.GetCKKucunByCond(ppsid, ckid);
            var xs = jcs.Select(r => new
            {
                pinpaishang = r.TCangku.TPinpaishang.mingcheng,
                ckid = r.cangkuid,
                cangku = r.TCangku.mingcheng,
                kucunshuliang = r.TCangkuKucunMXes.Sum(mr => mr.shuliang),
                chengbenjine = r.TCangkuKucunMXes.Sum(mr => mr.TTiaoma.jinjia * mr.shuliang),
                shoujiajine = r.TCangkuKucunMXes.Sum(mr => mr.TTiaoma.shoujia * mr.shuliang),
                r.shangbaoshijian
            });
            
            grid_kc.DataSource = Tool.CommonFunc.LINQToDataTable(xs);
            grid_kc.DataBind();

        }

        protected void cmb_pps_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_ck.Items.Clear();
            DBContext db = new DBContext();
            if (!string.IsNullOrEmpty(cmb_pps.SelectedValue))
            {
                int ppsid = int.Parse(cmb_pps.SelectedValue);
                TCangku[] fs = db.GetCangkusAsItems(ppsid);

                Tool.CommonFunc.InitDropDownList(cmb_ck, fs, "mingcheng", "id");
                cmb_ck.Items.Insert(0, new ListItem("所有仓库", ""));
            }
            else
            {
                cmb_ck.Items.Insert(0, new ListItem("所有仓库", ""));
            }
        }

        protected void grid_kc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                return;
            }

            int index = Convert.ToInt32(e.CommandArgument);
            int id = int.Parse(grid_kc.DataKeys[index].Value.ToString());

            DBContext db = new DBContext();
            if (e.CommandName == "DEL")
            {
                //检查权限
                Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

                TCangkuKucun ok = db.GetCKKucunById(id);
                if (ok.TCangku.ppsid != _LoginUser.ppsid.Value && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
                {
                    throw new MyException("非法操作，无法删除该数据", null);
                }
                db.DeleteCKKucun(id);

                btn_sch_Click(null,null);
            }
            else if (e.CommandName == "MX")
            {
                TCangkuKucunMX[] amxs = db.GetCKKucunMXByKcId(id);

                var mxs = amxs.Select(r => new
                {
                    r.TTiaoma.tiaoma,
                    r.TTiaoma.TKuanhao.kuanhao,
                    r.TTiaoma.gyskuanhao,
                    leixing = ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)r.TTiaoma.TKuanhao.leixing).ToString(),
                    r.TTiaoma.TKuanhao.pinming,
                    r.TTiaoma.yanse,
                    r.TTiaoma.chima,
                    r.TTiaoma.jinjia,
                    r.TTiaoma.shoujia,
                    r.shuliang,
                    r.jinhuoriqi
                });

                grid_mx.DataSource = Tool.CommonFunc.LINQToDataTable(mxs);
                grid_mx.DataBind();
            }
        }
    }
}