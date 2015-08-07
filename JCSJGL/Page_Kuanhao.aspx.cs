using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JCSJGL
{
    public partial class Page_Kuanhao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                //加载所有款号信息
                //loadKuanhaos();

                //初始化下拉框
                Tool.CommonFunc.InitDropDownList(cmb_lx_sch, typeof(Tool.JCSJ.DBCONSTS.KUANHAO_LX));
                cmb_lx_sch.Items.Insert(0, "");
                Tool.CommonFunc.InitDropDownList(cmb_lx, typeof(Tool.JCSJ.DBCONSTS.KUANHAO_LX));
                Tool.CommonFunc.InitDropDownList(cmb_xb, typeof(Tool.JCSJ.DBCONSTS.KUANHAO_XB));
            }
            else
            {
                string opt = hid_opt.Value;
                if (opt == "DELETE")
                {
                    int id = int.Parse(hid_id.Value);
                    deleteKuanhao(id);
                }

                //操作后清除操作标志
                hid_opt.Value = "";
            }
        }

        /// <summary>
        /// 删除款号
        /// </summary>
        /// <param name="id"></param>
        private void deleteKuanhao(int id)
        {
            DBContext db = new DBContext();
            db.DeleteKuanhao(id);

            loadKuanhaos();
        }

        /// <summary>
        /// 加载所有款号
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
            TKuanhao[] fs = db.GetKuanhaosByCond(lx, kh, pm, grid_kuanhao.PageSize, grid_kuanhao.PageIndex, out recordCount);
            var dfs = fs.Select(r => new
            {
                id = r.id,
                kuanhao=r.kuanhao,
                leixing = ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)r.leixing).ToString(),
                xingbie = ((Tool.JCSJ.DBCONSTS.KUANHAO_XB)r.xingbie).ToString(),
                pinming = r.pinming,
                beizhu = r.beizhu,
                caozuoren = r.TUser.yonghuming,
                charushijian = r.charushijian,
                xiugaishijian = r.xiugaishijian,
                editParams = r.id + ",'" + r.kuanhao + "','" + r.leixing + "','" + r.xingbie + "','" + r.pinming + "','" + r.beizhu + "'"
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
            TKuanhao f = getEditInfo();
            f.id = int.Parse(hid_id.Value);
            f.caozuorenid = ((TUser)Session["USER"]).id;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
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
            byte leixing = byte.Parse(cmb_lx.SelectedValue);
            byte xingbie = byte.Parse(cmb_xb.SelectedValue);
            string piming = txb_pm.Text.Trim();
            string bz = txb_bz.Text.Trim();

            TKuanhao f = new TKuanhao
            {
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
            TKuanhao f = getEditInfo();
            f.caozuorenid = ((TUser)Session["USER"]).id;
            f.charushijian = DateTime.Now;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
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
    }
}