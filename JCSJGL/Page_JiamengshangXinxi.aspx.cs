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
    public partial class Page_JiamengshangXinxi : MyPage
    {
        public Page_JiamengshangXinxi()
        {
            _PageName = PageName.加盟商信息;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                //地区下拉框
                DBContext db = new DBContext();
                VDiqu[] dqs = db.GetAllDiqus();
                //将第一级和第二级地区连接
                VDiqu[] ssdqs = dqs.Where(r => r.jibie == 1).ToArray();
                Tool.CommonFunc.InitDropDownList(cmb_xzdq, ssdqs, "lujing", "id");
            }
        }

        /// <summary>
        /// 加载所有加盟商信息
        /// </summary>
        private void loadJiamengshangs()
        {
            DBContext db = new DBContext();
            TJiamengshang[] js = db.GetJiamengshangs();
            VDiqu[] dqs = db.GetAllDiqus();
            var dfs = js.Select(r => new
            {
                r.id,
                r.mingcheng,
                r.daima,
                shoujihao = r.zhuceshouji,
                youxiang = r.zhuceyouxiang,
                diqu = dqs.Single(rr => rr.id == r.diquid).lujing,
                r.dizhi,
                r.lianxiren,
                r.dianhua,
                r.beizhu,

                r.fjmsshu,
                r.zjmsshu,
                r.zhanghaoshu,
                r.kuanhaoshu,
                r.tiaomashu,
                r.huiyuanshu,
                r.fendianshu,
                r.cangkushu,
                r.gongyingshangshu,
                r.xsjilushu,
                r.jchjilushu,
                r.kcjilushu,
                r.shoucifufei,
                r.xufeidanjia,
                jiezhiriqi = r.jiezhiriqi.ToString("yyyy/MM/dd"),
                r.charushijian,
                r.xiugaishijian,
                editParams = 
                            r.id+",'"+r.mingcheng+"','"+r.zhuceshouji+"','"+r.zhuceyouxiang+"',"+r.diquid+",'"+r.dizhi+"','"+r.lianxiren+"','"+r.dianhua+"','"+ r.beizhu+
                            "',"+r.fjmsshu+","+r.zjmsshu+","+ r.zhanghaoshu+","+r.kuanhaoshu+","+ r.tiaomashu+","+ r.huiyuanshu+","+ r.fendianshu+
                            ","+r.cangkushu+","+r.gongyingshangshu+","+r.xsjilushu+","+r.jchjilushu+","+r.kcjilushu+","+r.shoucifufei+","+ r.xufeidanjia+
                            ",'"+r.jiezhiriqi.ToString("yyyy-MM-dd")+"'"
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
            //父加盟商数量和子加盟商数量不得同时大于0
            if (f.fjmsshu > 0 && f.zjmsshu > 0)
            {
                throw new MyException("不允许中间代理商", null);
            }
            if (string.IsNullOrEmpty(hid_id.Value))
            {
                throw new MyException("请先选择需要修改的加盟商",null);
            }
            f.id = int.Parse(hid_id.Value);
            //以防重复操作
            hid_id.Value = "";
            //f.caozuorenid = _LoginUser.id;
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
            string mc = txb_mc.Text.Trim();
            string sjh = txb_sjh.Text.Trim();
            string yx = txb_yx.Text.Trim();
            int dq = int.Parse(cmb_xzdq.SelectedValue);
            string lxr = txb_lxr.Text.Trim();
            string dh = txb_dh.Text.Trim();
            string dz = txb_dz.Text.Trim();
            string bz = txb_bz.Text.Trim();

            byte fjmss = byte.Parse(txb_fjmss.Text.Trim());
            short zjmss = short.Parse(txb_zjmss.Text.Trim());
            byte zhs = byte.Parse(txb_zhs.Text.Trim());
            int khs = int.Parse(txb_khs.Text.Trim());
            int tms = int.Parse(txb_tms.Text.Trim());
            int hys = int.Parse(txb_hys.Text.Trim());
            short fds = short.Parse(txb_fds.Text.Trim());
            byte cks = byte.Parse(txb_cks.Text.Trim());
            short gyss = short.Parse(txb_gyss.Text.Trim());
            int xsjls = int.Parse(txb_xsjls.Text.Trim());
            int jchjls = int.Parse(txb_jchjls.Text.Trim());
            int kcjls = int.Parse(txb_kcjls.Text.Trim());
            decimal scff = decimal.Parse(txb_scff.Text.Trim());
            decimal xfdj = decimal.Parse(txb_xfdj.Text.Trim());
            DateTime jzrq = DateTime.Parse(txb_jzrq.Text.Trim());

            TJiamengshang j = new TJiamengshang
            {
                //基本信息
                mingcheng = mc,
                zhuceshouji = sjh,
                zhuceyouxiang = yx,
                diquid = dq,
                dizhi = dz,
                lianxiren = lxr,
                dianhua = dh,
                beizhu = bz,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now,
                dtyzm = Tool.CommonFunc.GetRandomNum(6),

                fjmsshu = fjmss,
                zjmsshu = zjmss,
                 zhanghaoshu = zhs,
                 kuanhaoshu = khs,
                 tiaomashu = tms,
                 huiyuanshu = hys,
                 fendianshu = fds,
                 cangkushu = cks,
                 gongyingshangshu = gyss,
                 xsjilushu = xsjls,
                 jchjilushu = jchjls,
                 kcjilushu = kcjls,
                 shoucifufei = scff,
                 xufeidanjia = xfdj,
                 jiezhiriqi = jzrq,
            };

            return j;
        }

        /// <summary>
        /// 新增一个加盟商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            //Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            //TJiamengshang j= getEditInfo();
            //j.dtyzm = Tool.CommonFunc.GetRandomNum(6);            
            ////j.caozuorenid = _LoginUser.id;
            //j.charushijian = DateTime.Now;
            //j.xiugaishijian = DateTime.Now;

            //DBContext db = new DBContext();
            //db.InsertJiamengshang(j);

            //loadJiamengshangs();
        }


        protected void grid_jiamengshang_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = int.Parse(grid_jiamengshang.DataKeys[index].Value.ToString());
            if (e.CommandName == "SC")
            {
                Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

                DBContext db = new DBContext();
                db.DeleteJiamengshang(id);

                loadJiamengshangs();
            }
            else
            {
                throw new MyException("非法操作", null);
            }
        }

        protected void btn_sch_Click(object sender, EventArgs e)
        {
            loadJiamengshangs();
        }
    }
}