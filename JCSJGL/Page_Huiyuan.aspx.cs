using DB_JCSJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JCSJGL
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
                loadHuiyuanZKs();

                DBContext db = new DBContext();
                TFendian[] fs = db.GetFendians();
                //初始化下拉框
                Tool.CommonFunc.InitDropDownList(cmb_xb, typeof(Tool.JCSJ.DBCONSTS.HUIYUAN_XB));
                //Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
            }
            else
            {
                string opt = hid_opt.Value;
                if (opt == "DELETE")
                {
                    int id = int.Parse(hid_id.Value);
                    deleteHuiyuan(id);
                }
                else if (opt == "DELETEZK")
                {
                    int id = int.Parse(hid_id.Value);
                    deleteHuiyuanZK(id);
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
            DBContext db = new DBContext();
            db.DeleteHuiyuan(id);

            loadHuiyuans();
        }
        private void deleteHuiyuanZK(int id)
        {
            DBContext db = new DBContext();
            db.DeleteHuiyuanZK(id);

            loadHuiyuanZKs();
        }

        /// <summary>
        /// 加载所有会员信息
        /// </summary>
        private void loadHuiyuans()
        {
            DBContext db = new DBContext();
            THuiyuan[] fs = db.GetHuiyuans();
            var dfs = fs.Select(r => new
            {
                id = r.id,
                fendian = r.TFendian.dianming,
                shoujihao = r.shoujihao,
                xingming = r.xingming,
                xingbie = ((Tool.JCSJ.DBCONSTS.HUIYUAN_XB)r.xingbie).ToString(),
                shengri = r.shengri.ToString("yyyy-MM-dd"),
                jifen = r.jifen,
                jfjsshijian = r.jfjsshijian,
                beizhu = r.beizhu,
                caozuoren = r.TUser.yonghuming,
                charushijian = r.charushijian,
                xiugaishijian = r.xiugaishijian,
                editParams = r.id + ",'" + r.shoujihao + "','" + r.xingming + "','" + r.xingbie + "','" + r.shengri.ToString("yyyy-MM-dd") + "','" +
                             r.beizhu + "'"
            });

            grid_huiyuan.DataSource = Tool.CommonFunc.LINQToDataTable(dfs);
            grid_huiyuan.DataBind();
        }

        /// <summary>
        /// 加载会员积分折扣规则
        /// </summary>
        private void loadHuiyuanZKs()
        {
            DBContext db = new DBContext();

            THuiyuanZK[] zs = db.GetHuiyuanZKs();
            grid_zhekou.DataSource = zs.OrderBy(r=>r.jifen).ToArray();
            grid_zhekou.DataBind();
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

            DBContext db = new DBContext();
            db.UpdateHuiyuan(f);

            loadHuiyuans();
        }

        /// <summary>
        /// 取得编辑信息
        /// </summary>
        /// <returns></returns>
        private THuiyuan getEditInfo()
        {
            //int fendianid = int.Parse(cmb_fd.SelectedValue);
            string shoujihao = txb_sjh.Text.Trim();
            string xingming = txb_xm.Text.Trim();
            byte xingbie = byte.Parse(cmb_xb.SelectedValue);
            DateTime shengri = DateTime.Parse(txb_sr.Text.Trim());
            string bz = txb_bz.Text.Trim();

            THuiyuan f = new THuiyuan
            {
                //fendianid = fendianid,
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

            DBContext db = new DBContext();
            db.InsertHuiyuan(f);

            loadHuiyuans();
        }

        /// <summary>
        /// 增加一个积分折扣规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_zk_add_Click(object sender, EventArgs e)
        {
            string sjf = txb_jf.Text.Trim();
            string szk = txb_zk.Text.Trim();

            decimal jf = decimal.Parse(sjf);
            decimal zk = decimal.Parse(szk);

            THuiyuanZK z = new THuiyuanZK 
            {
                jifen = jf,
                zhekou = zk
            };

            DBContext db = new DBContext();
            db.InsertHuiyuanZK(z);

            loadHuiyuanZKs();
        }
    }
}