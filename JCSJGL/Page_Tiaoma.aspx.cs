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
    public partial class Page_Tiaoma : MyPage
    {
        public Page_Tiaoma()
        {
            _PageName = PageName.条码信息;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                DBContext db = new DBContext();

                //隐藏搜索条件
                div_sch_jms.Visible = false;

                int? jmsid = null;
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    //显示搜索
                    div_sch_jms.Visible = true;

                    TJiamengshang[] jmss = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmss, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));
                }
                else
                {
                    jmsid = _LoginUser.jmsid;
                }

                //初始化类型下拉框
                Tool.CommonFunc.InitDropDownList(cmb_lx, typeof(Tool.JCSJ.DBCONSTS.KUANHAO_LX));
                cmb_lx.Items.Insert(0, new ListItem("所有类型",""));
               
                TGongyingshang[] gs = db.GetGongyingshangs(jmsid);
                Tool.CommonFunc.InitDropDownList(cmb_gys, gs, "mingcheng", "id");
            }
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sch_Click(object sender, EventArgs e)
        {
            grid_tiaoma.PageIndex = 0;
            search();
        }

        /// <summary>
        /// 加载所有条码信息
        /// </summary>
        private void search()
        {
            //取查询条件
            byte? lx = null;
            if (!string.IsNullOrEmpty(cmb_lx.SelectedValue))
            {
                lx = byte.Parse(cmb_lx.SelectedValue);
            }
            string kh = txb_kh_sch.Text.Trim();
            string tmh = txb_tmh_sch.Text.Trim();
            int recordCount = 0;

            int? jmsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    jmsid = int.Parse(cmb_jms.SelectedValue);
                } 
                grid_tiaoma.Columns[0].Visible = true;
            }
            else
            {
                grid_tiaoma.Columns[0].Visible = false;
                jmsid = _LoginUser.jmsid;   
            }

            DBContext db = new DBContext();
            TTiaoma[] fs = db.GetTiaomasByCond(jmsid,lx, kh, tmh, null,null, grid_tiaoma.PageSize, grid_tiaoma.PageIndex, out recordCount);
            var dfs = fs.Select(r => new
            {
                id = r.id,
                jiamengshang = r.TJiamengshang.mingcheng,
                tiaoma = r.tiaoma,
                yanse = r.yanse,
                chima = r.chima,
                jinjia = r.jinjia,
                shoujia = r.shoujia,
                kuanhao = r.TKuanhao.kuanhao,
                pinpai = r.TKuanhao.TJiamengshang.mingcheng,
                leixing = ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)r.TKuanhao.leixing).ToString(),
                pinming = r.TKuanhao.pinming,
                gongyingshang = r.TGongyingshang.mingcheng,
                gysid = r.gysid,
                gyskuanhao = r.gyskuanhao,
                charushijian = r.charushijian,
                xiugaishijian = r.xiugaishijian,
                editParams = r.id + ",'" + r.tiaoma + "','" + r.yanse + "','" + r.chima + "','" + r.jinjia + "','" + r.shoujia + "','" +
                             r.TKuanhao.kuanhao + "','" + r.gysid + "','" + r.gyskuanhao + "'"
            });

            grid_tiaoma.VirtualItemCount = recordCount;
            grid_tiaoma.DataSource = Tool.CommonFunc.LINQToDataTable(dfs);
            grid_tiaoma.DataBind();
        }

        /// <summary>
        /// 修改条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.修改, _LoginUser);

            TTiaoma f = getEditInfo();
            f.id = int.Parse(hid_id.Value);
            f.caozuorenid = _LoginUser.id;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            TTiaoma ot = db.GetTiaomaById(f.id);
            TGongyingshang og = db.GetGongyingshangById(f.gysid);
            if (ot.jmsid != og.jmsid)
            {
                throw new MyException("非法操作，无法修改该条码信息", null);
            }
            if (ot.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("该条码不属于您，无法修改该条码信息", null);
            }

            db.UpdateTiaoma(f);

            search();
        }

        /// <summary>
        /// 取得编辑信息
        /// </summary>
        /// <returns></returns>
        private TTiaoma getEditInfo()
        {
            string tiaoma = txb_tm.Text.Trim();
            string yanse = txb_ys.Text.Trim();
            string chima = txb_cm.Text.Trim();
            decimal jinjia = decimal.Parse(txb_jj.Text.Trim());
            decimal shoujia = decimal.Parse(txb_sj.Text.Trim());
            string kuanhao = txb_kh.Text.Trim();
            DBContext db = new DBContext();

            //TODO
            //当前款号只在某品牌内不重复，如果某加盟商有多个品牌，而且不同的品牌内有相同款号的话，该方法就会报错
            TKuanhao[] ks = db.GetKuanhaosByMcJmsId(new string[]{kuanhao}, _LoginUser.jmsid);
            if (ks.Count() == 0)
            {
                throw new MyException("该款号不存在，或者该款号不属于您", null);
            }
            else if (ks.Count() > 1)
            {
                throw new MyException("款号["+kuanhao+"]重复，属于多个品牌，无法将条码指定为该款号", null);
            }
            TKuanhao k = ks[0];     

            int gysid = int.Parse(cmb_gys.SelectedValue);
            string gyskuanhao = txb_gyskh.Text.Trim();

            TTiaoma f = new TTiaoma
            {
                tiaoma = tiaoma,
                yanse = yanse,
                chima = chima,
                jinjia = jinjia,
                shoujia = shoujia,
                kuanhaoid = k.id,
                gysid = gysid,
                gyskuanhao = gyskuanhao,
            };

            return f;
        }

        /// <summary>
        /// 增加一个条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            TTiaoma f = getEditInfo();
            f.jmsid = _LoginUser.jmsid;
            f.caozuorenid = _LoginUser.id;
            f.charushijian = DateTime.Now;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            int cc = db.GetTiaomaCount(_LoginUser.jmsid);
            if (cc >= _LoginUser.TJiamengshang.tiaomashu)
            {
                throw new MyException("拥有的条码数已达到上限，如果需要增加更多条码请联系系统管理员", null);
            }
            db.InsertTiaoma(f);

            search();
        }

        /// <summary>
        /// 换页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_tiaoma_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid_tiaoma.PageIndex = e.NewPageIndex;
            search();
        }

        /// <summary>
        /// 删除一个条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_tiaoma_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            int id = int.Parse(grid_tiaoma.DataKeys[e.RowIndex].Value.ToString());

            DBContext db = new DBContext();
            TTiaoma ok = db.GetTiaomaById(id);
            if (ok.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法删除该条码", null);
            }

            db.DeleteTiaoma(id);

            search();
        }
    }
}