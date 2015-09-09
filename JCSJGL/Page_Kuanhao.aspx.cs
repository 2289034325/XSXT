﻿using DB_JCSJ;
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
    public partial class Page_Kuanhao : MyPage
    {
        public Page_Kuanhao()
        {
            _PageName = PageName.款号信息;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                //隐藏搜索条件
                div_sch_jms.Visible = false;

                DBContext db = new DBContext();
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    //显示搜索
                    div_sch_jms.Visible = true;

                    TJiamengshang[] jmss = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmss, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));
                }

                //初始化下拉框
                Tool.CommonFunc.InitDropDownList(cmb_lx_sch, typeof(Tool.JCSJ.DBCONSTS.KUANHAO_LX));
                cmb_lx_sch.Items.Insert(0, new ListItem("所有类型", ""));

                Tool.CommonFunc.InitDropDownList(cmb_lx, typeof(Tool.JCSJ.DBCONSTS.KUANHAO_LX));
                Tool.CommonFunc.InitDropDownList(cmb_xb, typeof(Tool.JCSJ.DBCONSTS.KUANHAO_XB));

                //品牌下拉框
                TJiamengshangPinpai[] pps = db.GetYuanchuangPinpaisByJmsId(_LoginUser.jmsid);
                Tool.CommonFunc.InitDropDownList(cmb_pp, pps, "mingcheng", "id");
            }
        }
       
        /// <summary>
        /// 加载款号
        /// </summary>
        private void loadKuanhaos()
        {
            //取查询条件
            byte? lx = null;
            if (!string.IsNullOrEmpty(cmb_lx_sch.SelectedValue))
            {
                lx = byte.Parse(cmb_lx_sch.SelectedValue);
            }
            string kh = txb_kh_sch.Text.Trim();
            string pm = txb_pm_sch.Text.Trim();
            int recordCount = 0;

            DBContext db = new DBContext();
            int? jmsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
               _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    jmsid = int.Parse(cmb_jms.SelectedValue);
                } 
                grid_kuanhao.Columns[0].Visible = true;
            }
            else
            {
                grid_kuanhao.Columns[0].Visible = false;
                jmsid = _LoginUser.jmsid;
            }
            TKuanhao[] fs = db.GetKuanhaosByCond(jmsid, lx, kh, pm, grid_kuanhao.PageSize, grid_kuanhao.PageIndex, out recordCount);
            var dfs = fs.Select(r => new
            {
                id = r.id,
                jiamengshang = r.TJiamengshangPinpai.TJiamengshang.mingcheng,
                pinpai = r.TJiamengshangPinpai.mingcheng,
                kuanhao = r.kuanhao,
                leixing = ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)r.leixing).ToString(),
                xingbie = ((Tool.JCSJ.DBCONSTS.KUANHAO_XB)r.xingbie).ToString(),
                pinming = r.pinming,
                beizhu = r.beizhu,
                charushijian = r.charushijian,
                xiugaishijian = r.xiugaishijian,
                editParams = r.id + "," + r.ppid + ",'" + r.kuanhao + "','" + r.leixing + "','" + r.xingbie + "','" + r.pinming + "','" + r.beizhu + "'"
            });

            grid_kuanhao.VirtualItemCount = recordCount;
            grid_kuanhao.DataSource = Tool.CommonFunc.LINQToDataTable(dfs);
            grid_kuanhao.DataBind();
        }

        /// <summary>
        /// 修改款号信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.修改, _LoginUser);

            TKuanhao f = getEditInfo();
            f.id = int.Parse(hid_id.Value);
            f.caozuorenid = _LoginUser.id;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            TKuanhao ok = db.GetKuanhaoById(f.id);
            if (ok.TJiamengshangPinpai.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法修改该款号", null);
            }
            db.UpdateKuanhao(f);

            loadKuanhaos();
        }

        /// <summary>
        /// 取得编辑信息
        /// </summary>
        /// <returns></returns>
        private TKuanhao getEditInfo()
        {
            string kuanhao = txb_kh.Text.Trim();
            int ppid = int.Parse(cmb_pp.SelectedValue);
            byte leixing = byte.Parse(cmb_lx.SelectedValue);
            byte xingbie = byte.Parse(cmb_xb.SelectedValue);
            string piming = txb_pm.Text.Trim();
            string bz = txb_bz.Text.Trim();

            string errMsg = "非法操作，请刷新页面重新执行";
            if (!Enum.IsDefined(typeof(Tool.JCSJ.DBCONSTS.KUANHAO_LX), leixing))
            {
                throw new MyException(errMsg, null);
            }
            if (!Enum.IsDefined(typeof(Tool.JCSJ.DBCONSTS.KUANHAO_XB), xingbie))
            {
                throw new MyException(errMsg, null);
            }

            TKuanhao f = new TKuanhao
            {
                ppid = ppid,
                kuanhao=kuanhao,
                leixing = leixing,
                xingbie = xingbie,
                pinming = piming,
                beizhu = bz
            };

            return f;
        }

        /// <summary>
        /// 增加一个款号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            TKuanhao f = getEditInfo();
            //f.jmsid = _LoginUser.jmsid;
            f.caozuorenid = _LoginUser.id;
            f.charushijian = DateTime.Now;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            int cc = db.GetKuanhaoCount(_LoginUser.jmsid);
            if (cc >= _LoginUser.TJiamengshang.kuanhaoshu)
            {
                throw new MyException("拥有的款号数量已到上限，如有需要增加更多款号请联系系统管理员", null);
            }
            db.InsertKuanhao(f);

            loadKuanhaos();
        }

        protected void grid_kuanhao_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_kuanhao.PageIndex = e.NewPageIndex;
            loadKuanhaos();
        }

        protected void btn_sch_Click(object sender, EventArgs e)
        {
            grid_kuanhao.PageIndex = 0;
            loadKuanhaos();
        }

        /// <summary>
        /// 删除一个款号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_kuanhao_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            int id = int.Parse(grid_kuanhao.DataKeys[e.RowIndex].Value.ToString());

            DBContext db = new DBContext();
            TKuanhao ok = db.GetKuanhaoById(id);
            if (ok.TJiamengshangPinpai.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法删除该款号", null);
            }
            db.DeleteKuanhao(id);

            loadKuanhaos();
        }
    }
}