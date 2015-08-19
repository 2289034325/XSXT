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
    public partial class Page_Cangku : MyPage
    {
        public Page_Cangku()
        {
            _PageName = PageName.仓库信息;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                //隐藏搜索条件
                div_sch.Visible = false;

                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    //显示搜索
                    div_sch.Visible = true;

                    DBContext db = new DBContext();
                    TJiamengshang[] jmss = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmss, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));
                }
                else
                {
                    //加载所有仓库信息
                    loadCangkus();
                }
            }
        }

        /// <summary>
        /// 加载仓库信息
        /// </summary>
        private void loadCangkus()
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
                grid_cangku.Columns[0].Visible = true;
            }
            else
            {
                grid_cangku.Columns[0].Visible = false;
                jmsid = _LoginUser.jmsid;
            }

            TCangku[] cs = db.GetCangkus(jmsid);
            var dfs = cs.Select(r => new
            {
                id = r.id,
                jiamengshang = r.TJiamengshang.mingcheng,
                mingcheng = r.mingcheng,
                dizhi = r.dizhi,
                lianxiren = r.lianxiren,
                dianhua = r.dianhua,
                beizhu = r.beizhu,
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
            Authenticate.CheckOperation(_PageName, PageOpt.修改, _LoginUser);

            TCangku f = getEditInfo();
            f.id = int.Parse(hid_id.Value);
            f.caozuorenid = _LoginUser.id;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            TCangku oc = db.GetCangkuById(f.id);
            if (oc.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法修改该仓库的信息");
            }
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
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            TCangku f = getEditInfo();
            f.jmsid = _LoginUser.jmsid;
            f.jiqima = "";
            f.caozuorenid = _LoginUser.id;
            f.charushijian = DateTime.Now;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            //限制可增加的仓库数量
            int cc = db.GetCangkusCount(f.jmsid);
            if (cc >= _LoginUser.TJiamengshang.cangkushu)
            {
                throw new MyException("拥有的仓库数量已到上限，如有需要增加更多仓库请联系系统管理员");
            }
            db.InsertCangku(f);

            loadCangkus();
        }

        /// <summary>
        /// 删除一个仓库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_cangku_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //检查权限
            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            int id = int.Parse(grid_cangku.DataKeys[e.RowIndex].Value.ToString()); 

            DBContext db = new DBContext();
            TCangku oc = db.GetCangkuById(id);
            if (oc.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法删除此仓库");
            }
            db.DeleteCangku(id);

            loadCangkus();
        }

        /// <summary>
        /// 搜索仓库信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sch_Click(object sender, EventArgs e)
        {
            loadCangkus();
        }
    }
}