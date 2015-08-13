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
    public partial class Page_Jiamengshang : MyPage
    {
        public Page_Jiamengshang()
        {
            _PageName = PageName.加盟商信息;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                //加载所有加盟商信息
                loadJiamengshangs();
            }
            else
            {
                string opt = hid_opt.Value;
                if (opt == "DELETE")
                {
                    int id = int.Parse(hid_id.Value);
                    deleteJiamengshang(id);
                }

                //操作后清除操作标志
                hid_opt.Value = "";
            }
        }

        /// <summary>
        /// 删除一个加盟商
        /// </summary>
        /// <param name="id"></param>
        private void deleteJiamengshang(int id)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            DBContext db = new DBContext();
            db.DeleteJiamengshang(id);

            loadJiamengshangs();
        }

        /// <summary>
        /// 加载所有加盟商信息
        /// </summary>
        private void loadJiamengshangs()
        {
            DBContext db = new DBContext();
            TJiamengshang[] js = db.GetAllJiamengshangs();
            var dfs = js.Select(r => new
            {
                r.id,
                r.mingcheng,
                r.zhanghaoshu,
                r.tiaomashu,
                r.huiyuanshu,
                r.fendianshu,
                r.shoucifufei,
                r.xufeidanjia,
                r.jiezhiriqi,
                r.lianxiren,
                r.dianhua,
                r.beizhu,
                r.charushijian,
                r.xiugaishijian,
                editParams = string.Format("{0},'{1}',{2},{3},{4},{5},{6},{7},'{8}','{9}','{10}','{11}'", r.id, r.mingcheng, r.zhanghaoshu, r.tiaomashu, r.huiyuanshu, r.fendianshu, r.shoucifufei, r.xufeidanjia,
                r.jiezhiriqi,r.lianxiren,r.dianhua,r.beizhu)
            });

            grid_jiamengshang.DataSource = Tool.CommonFunc.LINQToDataTable(dfs);
            grid_jiamengshang.DataBind();
        }

        /// <summary>
        /// 修改加盟商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.修改, _LoginUser);

            TJiamengshang f = getEditInfo();
            f.id = int.Parse(hid_id.Value);
            f.caozuorenid = _LoginUser.id;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            db.UpdateJiamengshang(f);

            loadJiamengshangs();
        }

        /// <summary>
        /// 取得编辑信息
        /// </summary>
        /// <returns></returns>
        private TJiamengshang getEditInfo()
        {
            //int fendianid = int.Parse(cmb_fd.SelectedValue);
            string mc = txb_mc.Text.Trim();
            byte zhs = byte.Parse(txb_zhs.Text.Trim());
            int tms = int.Parse(txb_tms.Text.Trim());
            int hys = int.Parse(txb_hys.Text.Trim());
            short fds = short.Parse(txb_fds.Text.Trim());
            decimal scff = decimal.Parse(txb_scff.Text.Trim());
            decimal xfdj = decimal.Parse(txb_xfdj.Text.Trim());
            DateTime jzrq = DateTime.Parse(txb_jzrq.Text.Trim());
            string lxr = txb_lxr.Text.Trim();
            string dh = txb_dh.Text.Trim();
            string bz = txb_bz.Text.Trim();

            TJiamengshang j = new TJiamengshang
            {
                mingcheng = mc,
                 zhanghaoshu = zhs,
                 tiaomashu = tms,
                 huiyuanshu = hys,
                 fendianshu = fds,
                 shoucifufei = scff,
                 xufeidanjia = xfdj,
                 jiezhiriqi = jzrq,
                 lianxiren = lxr,
                 dianhua = dh,
                 beizhu = bz
            };

            return j;
        }

        /// <summary>
        /// 新增一个会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            TJiamengshang j= getEditInfo();
            j.caozuorenid = _LoginUser.id;
            j.charushijian = DateTime.Now;
            j.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            db.InsertJiamengshang(j);

            loadJiamengshangs();
        }
    }
}