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
    public partial class Page_Fendian : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                //加载所有分店信息
                loadFendians();

                //初始化下拉框
                Tool.CommonFunc.InitDropDownList(cmb_fzxz, typeof(Tool.JCSJ.DBCONSTS.FENDIAN_FZXB));
                Tool.CommonFunc.InitDropDownList(cmb_fzlx, typeof(Tool.JCSJ.DBCONSTS.FENDIAN_FZLX));
                Tool.CommonFunc.InitDropDownList(cmb_dc, typeof(Tool.JCSJ.DBCONSTS.FENDIAN_DC));
                Tool.CommonFunc.InitDropDownList(cmb_dpxz, typeof(Tool.JCSJ.DBCONSTS.FENDIAN_DPXZ));
                Tool.CommonFunc.InitDropDownList(cmb_zt, typeof(Tool.JCSJ.DBCONSTS.FENDIAN_ZT));
            }
            else
            {
                string opt = hid_opt.Value;
                if (opt == "DELETE")
                {
                    int id = int.Parse(hid_id.Value);
                    deleteFendian(id);
                }

                //操作后清除操作标志
                hid_opt.Value = "";
            }
        }

        /// <summary>
        /// 删除分店
        /// </summary>
        /// <param name="id"></param>
        private void deleteFendian(int id)
        {
            DBContext db = new DBContext();
            db.DeleteFendian(id);

            loadFendians();
        }

        private void loadFendians()
        {
            DBContext db = new DBContext();
            TFendian[] fs = db.GetFendians();
            var dfs = fs.Select(r => new
            {
                id = r.id,
                fzxingbie = ((Tool.JCSJ.DBCONSTS.FENDIAN_FZXB)r.fzxingbie).ToString(),
                fzleixing = ((Tool.JCSJ.DBCONSTS.FENDIAN_FZLX)r.fzleixing).ToString(),
                dianming = r.dianming,
                mianji = r.mianji,
                keliuliang = r.keliuliang,
                dangci = ((Tool.JCSJ.DBCONSTS.FENDIAN_DC)r.dangci).ToString(),
                dpxingzhi = ((Tool.JCSJ.DBCONSTS.FENDIAN_DPXZ)r.dpxingzhi).ToString(),
                zhuanrangfei = r.zhuanrangfei,
                yuezu = r.yuezu,
                dizhi = r.dizhi,
                lianxiren = r.lianxiren,
                dianhua = r.dianhua,
                kaidianriqi = r.kaidianriqi.ToString("yyyy-MM-dd"),
                zhuangtai = ((Tool.JCSJ.DBCONSTS.FENDIAN_ZT)r.zhuangtai).ToString(),
                beizhu = r.beizhu,
                caozuoren = r.TUser.yonghuming,
                charushijian = r.charushijian,
                xiugaishijian = r.xiugaishijian,
                editParams = r.id + ",'" + r.fzxingbie + "','" + r.fzleixing + "','" + r.dianming + "','" + r.mianji + "','" + r.keliuliang + "','"+
                r.dangci + "','" + r.dpxingzhi + "','" + r.zhuanrangfei + "','" + r.yuezu + "','" + r.dizhi + "','" +
                r.lianxiren + "','" + r.dianhua + "','" + r.kaidianriqi.ToString("yyyy-MM-dd") + "','" + r.zhuangtai + "','" + r.beizhu + "'"
            });

            grid_fendian.DataSource = Tool.CommonFunc.LINQToDataTable(dfs);
            grid_fendian.DataBind();
        }

        /// <summary>
        /// 修改分店信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            TFendian f = getEditInfo();
            f.id = int.Parse(hid_id.Value);
            f.caozuorenid = ((TUser)Session["USER"]).id;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            db.UpdateFendian(f);

            loadFendians();
        }

        /// <summary>
        /// 取得编辑信息
        /// </summary>
        /// <returns></returns>
        private TFendian getEditInfo()
        {
            byte fzxb = byte.Parse(cmb_fzxz.SelectedValue);
            byte fzlx = byte.Parse(cmb_fzlx.SelectedValue);
            string dm = txb_dm.Text.Trim();
            short mj = short.Parse(txb_mj.Text.Trim());
            short kll = short.Parse(txb_kll.Text.Trim());
            byte dc = byte.Parse(cmb_dc.SelectedValue);
            byte dpxz = byte.Parse(cmb_dpxz.SelectedValue);
            decimal zrf = decimal.Parse(txb_zrf.Text.Trim());
            decimal yz = decimal.Parse(txb_yz.Text.Trim());
            string dz = txb_dz.Text.Trim();
            string lxr = txb_lxr.Text.Trim();
            string dh = txb_dh.Text.Trim();
            DateTime kdrq = DateTime.Parse(txb_kdrq.Text.Trim());
            byte zt = byte.Parse(cmb_zt.SelectedValue);
            string bz = txb_bz.Text.Trim();

            TFendian f = new TFendian
            {
                fzxingbie = fzxb,
                fzleixing = fzlx,
                dianming = dm,
                mianji = mj,
                keliuliang = kll,
                dangci = dc,
                dpxingzhi = dpxz,
                zhuanrangfei = zrf,
                yuezu = yz,
                dizhi = dz,
                lianxiren = lxr,
                dianhua = dh,
                kaidianriqi = kdrq,
                zhuangtai = zt,
                beizhu = bz
            };

            return f;
        }

        /// <summary>
        /// 新增一个分店
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            TFendian f = getEditInfo();
            f.caozuorenid = ((TUser)Session["USER"]).id;
            f.charushijian = DateTime.Now;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            db.InsertFendian(f);

            loadFendians();
        }
    }
}