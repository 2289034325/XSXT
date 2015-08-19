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
    public partial class Page_Gongyingshang : MyPage
    {
        public Page_Gongyingshang()
        {
            _PageName = PageName.供应商信息;
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
                    //加载供应商信息
                    loadGongyingshangs();
                }
            }
        }
        
        /// <summary>
        /// 加载所有供应商信息
        /// </summary>
        private void loadGongyingshangs()
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
                grid_gys.Columns[0].Visible = true;
            }
            else
            {
                grid_gys.Columns[0].Visible = false;
                jmsid = _LoginUser.jmsid;
            }

            TGongyingshang[] cs = db.GetGongyingshangs(jmsid);
            var dfs = cs.Select(r => new
            {
                id = r.id,
                jiamengshang = r.TJiamengshang.mingcheng,
                mingcheng = r.mingcheng,
                lianxiren = r.lianxiren,
                dianhua = r.dianhua,
                dizhi = r.dizhi,
                beizhu = r.beizhu,
                charushijian = r.charushijian,
                xiugaishijian = r.xiugaishijian,
                editParams = r.id + ",'" + r.mingcheng + "','" + r.lianxiren + "','" + r.dianhua + "','" + r.dizhi + "','" + r.beizhu + "'"
            });

            grid_gys.DataSource = Tool.CommonFunc.LINQToDataTable(dfs);
            grid_gys.DataBind();
        }

        /// <summary>
        /// 修改供应商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.修改, _LoginUser);

            TGongyingshang f = getEditInfo();
            f.id = int.Parse(hid_id.Value);
            f.caozuorenid = _LoginUser.id;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            TGongyingshang og = db.GetGongyingshangById(f.id);
            if (og.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法修改此供应商信息");
            }
            db.UpdateGongyingshang(f);

            loadGongyingshangs();
        }

        /// <summary>
        /// 取得编辑信息
        /// </summary>
        /// <returns></returns>
        private TGongyingshang getEditInfo()
        {
            string mc = txb_mc.Text.Trim();
            string dz = txb_dz.Text.Trim();
            string lxr = txb_lxr.Text.Trim();
            string dh = txb_dh.Text.Trim();
            string bz = txb_bz.Text.Trim();

            TGongyingshang f = new TGongyingshang
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
        /// 增加一个供应商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            TGongyingshang f = getEditInfo();
            f.jmsid = _LoginUser.jmsid;
            f.caozuorenid = _LoginUser.id;
            f.charushijian = DateTime.Now;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            int cc = db.GetGongyingshangCount(_LoginUser.jmsid);
            if (cc >= _LoginUser.TJiamengshang.gongyingshangshu)
            {
                throw new MyException("拥有的供应商数量已到上限，如有需要增加更多供应商请联系系统管理员");
            }
            db.InsertGongyingshang(f);

            loadGongyingshangs();

        }

        /// <summary>
        /// 删除一个供应商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_gys_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            int id = int.Parse(grid_gys.DataKeys[e.RowIndex].Value.ToString()); 

            DBContext db = new DBContext();
            TGongyingshang og = db.GetGongyingshangById(id);
            if (og.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法删除该供应商");
            }
            db.DeleteGongyingshang(id);

            loadGongyingshangs();
        }

        protected void btn_sch_Click(object sender, EventArgs e)
        {
            loadGongyingshangs();
        }
    }
}