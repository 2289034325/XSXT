using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool.DB.JCSJ;

namespace JCSJG
{
    public partial class Page_Huiyuan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                //加载所有会员信息
                loadHuiyuans();

                OPT db = new OPT();
                TFendian[] fs = db.GetAllFendians();
                //初始化下拉框
                Tool.CommonFunc.InitCombbox(cmb_xb, typeof(CONSTS.HUIYUAN_XB));
                Tool.CommonFunc.InitCombbox(cmb_fd, fs, "dianming", "id");
            }
            else
            {
                string opt = hid_opt.Value;
                if (opt == "DELETE")
                {
                    int id = int.Parse(hid_id.Value);
                    deleteHuiyuan(id);
                }

                //操作后清除操作标志
                hid_opt.Value = "";
            }
        }

        /// <summary>
        /// 删除一个会员
        /// </summary>
        /// <param name="id"></param>
        private void deleteHuiyuan(int id)
        {
            OPT db = new OPT();
            db.DeleteHuihuan(id);

            loadHuiyuans();
        }

        /// <summary>
        /// 加载所有会员信息
        /// </summary>
        private void loadHuiyuans()
        {
            OPT db = new OPT();
            THuiyuan[] fs = db.GetAllHuiyuans();
            var dfs = fs.Select(r => new
            {
                id = r.id,
                fendian = r.TFendian.dianming,
                shoujihao = r.shoujihao,
                xingming = r.xingming,
                xingbie = ((CONSTS.HUIYUAN_XB)r.xingbie).ToString(),
                shengri = r.shengri.ToString("yyyy-MM-dd"),
                beizhu = r.beizhu,
                caozuoren = r.TUser.yonghuming,
                charushijian = r.charushijian,
                xiugaishijian = r.xiugaishijian,
                editParams = r.id + ",'" + r.fendianid + "','" + r.shoujihao + "','" + r.xingming + "','" + r.xingbie + "','" + r.shengri.ToString("yyyy-MM-dd") + "','" +
                             r.beizhu + "'"
            });

            grid_huiyuan.DataSource = Tool.CommonFunc.LINQToDataTable(dfs);
            grid_huiyuan.DataBind();
        }

        /// <summary>
        /// 修改会员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            THuiyuan f = getEditInfo();
            f.id = int.Parse(hid_id.Value);
            f.caozuorenid = ((TUser)Session["USER"]).id;
            f.xiugaishijian = DateTime.Now;

            OPT db = new OPT();
            db.UpdateHuiyuan(f);

            loadHuiyuans();
        }

        /// <summary>
        /// 取得编辑信息
        /// </summary>
        /// <returns></returns>
        private THuiyuan getEditInfo()
        {
            int fendianid = int.Parse(cmb_fd.SelectedValue);
            string shoujihao = txb_sjh.Text.Trim();
            string xingming = txb_xm.Text.Trim();
            byte xingbie = byte.Parse(cmb_xb.SelectedValue);
            DateTime shengri = DateTime.Parse(txb_sr.Text.Trim());
            string bz = txb_bz.Text.Trim();

            THuiyuan f = new THuiyuan
            {
                fendianid = fendianid,
                shoujihao = shoujihao,
                xingming = xingming,
                xingbie = xingbie,
                shengri = shengri,
                beizhu = bz
            };

            return f;
        }

        /// <summary>
        /// 新增一个会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            THuiyuan f = getEditInfo();
            f.caozuorenid = ((TUser)Session["USER"]).id;
            f.charushijian = DateTime.Now;
            f.xiugaishijian = DateTime.Now;

            OPT db = new OPT();
            db.InsertHuiyuan(f);

            loadHuiyuans();
        }
    }
}