using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool.DB.JCSJ;

namespace JCSJG
{
    public partial class Page_Cangku : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                //加载所有仓库信息
                loadCangkus();
            }
            else
            {
                string opt = hid_opt.Value;
                if (opt == "DELETE")
                {
                    int id = int.Parse(hid_id.Value);
                    deleteCangku(id);
                }

                //操作后清除操作标志
                hid_opt.Value = "";
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        private void deleteCangku(int id)
        {
            DBContext db = new DBContext();
            db.DeleteCangku(id);

            loadCangkus();
        }

        /// <summary>
        /// 加载所有仓库信息
        /// </summary>
        private void loadCangkus()
        {
            DBContext db = new DBContext();
            TCangku[] cs = db.GetCangkus();
            var dfs = cs.Select(r => new
            {
                id = r.id,
                mingcheng = r.mingcheng,
                dizhi = r.dizhi,
                lianxiren = r.lianxiren,
                dianhua = r.dianhua,
                beizhu = r.beizhu,
                caozuoren = r.TUser.yonghuming,
                charushijian = r.charushijian,
                xiugaishijian = r.xiugaishijian,
                editParams = r.id + ",'" + r.mingcheng + "','" + r.dizhi + "','" + r.lianxiren + "','" + r.dianhua + "','" + r.beizhu + "'"
            });

            grid_cangku.DataSource = Tool.CommonFunc.LINQToDataTable(dfs);
            grid_cangku.DataBind();
        }


        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            TCangku f = getEditInfo();
            f.id = int.Parse(hid_id.Value);
            f.caozuorenid = ((TUser)Session["USER"]).id;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            db.UpdateCangku(f);

            loadCangkus();
        }

        /// <summary>
        /// 取得编辑信息
        /// </summary>
        /// <returns></returns>
        private TCangku getEditInfo()
        {
            string mc = txb_mc.Text.Trim();
            string dz = txb_dz.Text.Trim();
            string lxr = txb_lxr.Text.Trim();
            string dh = txb_dh.Text.Trim();
            string bz = txb_bz.Text.Trim();

            TCangku f = new TCangku
            {
                mingcheng = mc,
                dizhi = dz,
                lianxiren = lxr,
                dianhua = dh,
                beizhu = bz
            };

            return f;
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            TCangku f = getEditInfo();
            f.caozuorenid = ((TUser)Session["USER"]).id;
            f.charushijian = DateTime.Now;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            db.InsertCangku(f);

            loadCangkus();
        }
    }
}