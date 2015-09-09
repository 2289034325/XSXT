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
    public partial class Page_Fendian : MyPage
    {
        public Page_Fendian()
        {
            _PageName = PageName.分店信息;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                DBContext db = new DBContext();
                //隐藏搜索条件
                div_sch.Visible = false;

                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    //显示搜索
                    div_sch.Visible = true;

                    TJiamengshang[] jmss = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmss, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));
                }
                else
                {
                    //加载所有分店信息
                    loadFendians();
                }

                //初始化下拉框
                Tool.CommonFunc.InitDropDownList(cmb_fzxz, typeof(Tool.JCSJ.DBCONSTS.FENDIAN_FZXB));
                Tool.CommonFunc.InitDropDownList(cmb_fzlx, typeof(Tool.JCSJ.DBCONSTS.FENDIAN_FZLX));
                Tool.CommonFunc.InitDropDownList(cmb_dc, typeof(Tool.JCSJ.DBCONSTS.FENDIAN_DC));
                Tool.CommonFunc.InitDropDownList(cmb_dpxz, typeof(Tool.JCSJ.DBCONSTS.FENDIAN_DPXZ));
                Tool.CommonFunc.InitDropDownList(cmb_zt, typeof(Tool.JCSJ.DBCONSTS.FENDIAN_ZT));
                //加载省市行政区
                VDiqu[] dqs = db.GetAllDiqus();
                //将第一级和第二级地区连接
                VDiqu[] ssdqs = dqs.Where(r => r.jibie == 1).ToArray();
                Tool.CommonFunc.InitDropDownList(cmb_xzdq, ssdqs, "lujing", "id");

                //品牌下拉框
                TJiamengshangPinpai[] ycpps = db.GetYuanchuangPinpaisByJmsId(_LoginUser.jmsid);
                TJiamengshangPinpai[] jmpps = db.GetJiamengPinpaisByJmsId(_LoginUser.jmsid);
                TJiamengshangPinpai[] pps = ycpps.Concat(jmpps).ToArray();
                Tool.CommonFunc.InitDropDownList(cmb_pp, pps, "mingcheng", "id");
            }
        }       

        private void loadFendians()
        {
            DBContext db = new DBContext();
            int? jmsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    jmsid = int.Parse(cmb_jms.SelectedValue);
                }
                grid_fendian.Columns[0].Visible = true;
            }
            else
            {
                jmsid = _LoginUser.jmsid;
                grid_fendian.Columns[0].Visible = false;
            }
            TFendian[] fs = db.GetFendians(jmsid);
            VDiqu[] dqs = db.GetAllDiqus();
            var dfs = fs.Select(r => new
            {
                id = r.id,
                jiamengshang = r.TJiamengshang.mingcheng,
                fzxingbie = ((Tool.JCSJ.DBCONSTS.FENDIAN_FZXB)r.fzxingbie).ToString(),
                fzleixing = ((Tool.JCSJ.DBCONSTS.FENDIAN_FZLX)r.fzleixing).ToString(),
                dianming = r.dianming,
                pinpai = r.TJiamengshangPinpai.mingcheng,
                mianji = r.mianji,
                keliuliang = r.keliuliang,
                dangci = ((Tool.JCSJ.DBCONSTS.FENDIAN_DC)r.dangci).ToString(),
                dpxingzhi = ((Tool.JCSJ.DBCONSTS.FENDIAN_DPXZ)r.dpxingzhi).ToString(),
                zhuanrangfei = r.zhuanrangfei,
                yuezu = r.yuezu,
                diqu = dqs.Single(rr=>rr.id == r.diquid).lujing,
                dizhi = r.dizhi,
                lianxiren = r.lianxiren,
                dianhua = r.dianhua,
                kaidianriqi = r.kaidianriqi.ToString("yyyy-MM-dd"),
                zhuangtai = ((Tool.JCSJ.DBCONSTS.FENDIAN_ZT)r.zhuangtai).ToString(),
                beizhu = r.beizhu,
                charushijian = r.charushijian,
                xiugaishijian = r.xiugaishijian,
                editParams = r.id + ",'" + r.fzxingbie + "','" + r.fzleixing + "','" + r.dianming + "',"+r.ppid+",'" + r.mianji + "','" + r.keliuliang + "','" +
                r.dangci + "','" + r.dpxingzhi + "','" + r.zhuanrangfei + "','" + r.yuezu + "','" + r.diquid + "','" + r.dizhi + "','" +
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
            Authenticate.CheckOperation(_PageName, PageOpt.修改, _LoginUser);

            TFendian f = getEditInfo();
            f.id = int.Parse(hid_id.Value);
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            TFendian of = db.GetFendianById(f.id);
            if (of.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法修改此分店信息", null);
            }
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
            int ppid = int.Parse(cmb_pp.SelectedValue);
            short mj = short.Parse(txb_mj.Text.Trim());
            short kll = short.Parse(txb_kll.Text.Trim());
            byte dc = byte.Parse(cmb_dc.SelectedValue);
            byte dpxz = byte.Parse(cmb_dpxz.SelectedValue);
            decimal zrf = decimal.Parse(txb_zrf.Text.Trim());
            decimal yz = decimal.Parse(txb_yz.Text.Trim());
            int dqid = int.Parse(cmb_xzdq.SelectedValue);
            string dz = txb_dz.Text.Trim();
            string lxr = txb_lxr.Text.Trim();
            string dh = txb_dh.Text.Trim();
            DateTime kdrq = DateTime.Parse(txb_kdrq.Text.Trim());
            byte zt = byte.Parse(cmb_zt.SelectedValue);
            string bz = txb_bz.Text.Trim();

            string errMsg = "非法操作，请刷新页面重新执行";
            if (!Enum.IsDefined(typeof(Tool.JCSJ.DBCONSTS.FENDIAN_FZXB), fzxb))
            {
                throw new MyException(errMsg, null);
            }
            if (!Enum.IsDefined(typeof(Tool.JCSJ.DBCONSTS.FENDIAN_FZLX), fzlx))
            {
                throw new MyException(errMsg, null);
            }
            if (!Enum.IsDefined(typeof(Tool.JCSJ.DBCONSTS.FENDIAN_DC), dc))
            {
                throw new MyException(errMsg, null);
            }
            if (!Enum.IsDefined(typeof(Tool.JCSJ.DBCONSTS.FENDIAN_DPXZ), dpxz))
            {
                throw new MyException(errMsg, null);
            }
            if (!Enum.IsDefined(typeof(Tool.JCSJ.DBCONSTS.FENDIAN_ZT), zt))
            {
                throw new MyException(errMsg, null);
            }

            TFendian f = new TFendian
            {
                fzxingbie = fzxb,
                fzleixing = fzlx,
                dianming = dm,
                ppid = ppid,
                mianji = mj,
                keliuliang = kll,
                dangci = dc,
                dpxingzhi = dpxz,
                zhuanrangfei = zrf,
                yuezu = yz,
                diquid = dqid,
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
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            TFendian f = getEditInfo();
            f.jmsid = _LoginUser.jmsid;
            f.jiqima = "";
            f.caozuorenid = _LoginUser.id;
            f.charushijian = DateTime.Now;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            //限制分店数
            int cc = db.GetFendianCount(_LoginUser.jmsid);
            if (cc >= _LoginUser.TJiamengshang.fendianshu)
            {
                throw new MyException("拥有的分店数量已到上限，如有需要增加更多分店请联系系统管理员", null);
            }
            db.InsertFendian(f);

            loadFendians();
        }

        /// <summary>
        /// 删除分店
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_fendian_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            int id = int.Parse(grid_fendian.DataKeys[e.RowIndex].Value.ToString());  

            DBContext db = new DBContext();
            TFendian of = db.GetFendianById(id);
            if (of.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法删除该分店", null);
            }
            db.DeleteFendian(id);

            loadFendians();
        }

        /// <summary>
        /// 搜索分店
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sch_Click(object sender, EventArgs e)
        {
            loadFendians();
        }
    }
}