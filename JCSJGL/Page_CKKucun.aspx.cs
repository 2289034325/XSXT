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
    public partial class Page_CKKucun : MyPage
    {
        public Page_CKKucun()
        {
            _PageName = PageName.仓库库存;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //初始化分店下拉框
                DBContext db = new DBContext();
                int? jmsid = null;
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    grid_kc_total.Columns[0].Visible = true;
                    grid_kc_ck.Columns[0].Visible = true;
                    grid_kc.Columns[0].Visible = true;
                }
                else
                {
                    grid_kc_total.Columns[0].Visible = false;
                    grid_kc_ck.Columns[0].Visible = false;
                    grid_kc.Columns[0].Visible = false;
                    jmsid = _LoginUser.jmsid;
                }

                TCangku[] fs = db.GetCangkusAsItems(jmsid);
                Tool.CommonFunc.InitDropDownList(cmb_ck, fs, "mingcheng", "id");
                cmb_ck.Items.Insert(0, new ListItem("所有仓库", ""));

                string ckid_s = Request["ckid"];
                if (!string.IsNullOrEmpty(ckid_s))
                {
                    int fdid = int.Parse(ckid_s);
                    cmb_ck.SelectedValue = fdid.ToString();

                    //加载某仓库的历史库存
                    loadHistroy(fdid);
                }
                else
                {
                    //加载总库存和加盟商旗下的每个分店的最新库存数据
                    int? fdid = null;
                    if (!string.IsNullOrEmpty(cmb_ck.SelectedValue))
                    {
                        fdid = int.Parse(cmb_ck.SelectedValue);
                    }
                    loadKCOfCangkus(fdid);
                }
            }
        }

        /// <summary>
        /// 加载所有仓库的最新库存数据
        /// </summary>
        private void loadKCOfCangkus(int? ckid)
        {
            grid_kc_total.Visible = true;
            grid_kc_ck.Visible = true;
            grid_kc.Visible = false;

            DBContext db = new DBContext();
            int? jmsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {

            }
            else
            {
                jmsid = _LoginUser.jmsid;
            }
            TCangkuKucun[] jcs = db.GetCKKucunByCond(jmsid, ckid, true);
            var xs = jcs.Select(r => new
            {
                jiamengshang = r.TCangku.TJiamengshang.mingcheng,
                ckid = r.cangkuid,
                cangku = r.TCangku.mingcheng,
                kucunshuliang = r.TCangkuKucunMXes.Sum(mr => mr.shuliang),
                chengbenjine = r.TCangkuKucunMXes.Sum(mr => mr.TTiaoma.jinjia * mr.shuliang),
                shoujiajine = r.TCangkuKucunMXes.Sum(mr => mr.TTiaoma.shoujia * mr.shuliang),
                r.shangbaoshijian
            });

            grid_kc_ck.DataSource = Tool.CommonFunc.LINQToDataTable(xs);
            grid_kc_ck.DataBind();

            //总库存
            var data = xs.GroupBy(r=>r.jiamengshang).Select(r => new
            {
                jiamengshang = r.Key,
                kucunshuliang = r.Sum(xr => xr.kucunshuliang),
                chengbenjine = decimal.Round(r.Sum(xr => xr.chengbenjine), 2),
                shoujiajine = decimal.Round(r.Sum(xr => xr.shoujiajine), 2),
                shangbaoshijian = r.Min(xr => (DateTime?)xr.shangbaoshijian)
            });

            grid_kc_total.DataSource = data;
            grid_kc_total.DataBind();
        }

        /// <summary>
        /// 加载某个分店的历史库存数据
        /// </summary>
        /// <param name="fdid"></param>
        private void loadHistroy(int ckid)
        {
            grid_kc_total.Visible = false;
            grid_kc_ck.Visible = false;
            grid_kc.Visible = true;

            DBContext db = new DBContext();
            int? jmsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {

            }
            else
            {
                jmsid = _LoginUser.jmsid;
            }
            TCangkuKucun[] jcs = db.GetCKKucunByCond(jmsid, ckid, false);
            var xs = jcs.Select(r => new
            {
                jiamengshang = r.TCangku.TJiamengshang.mingcheng,
                id = r.id,
                cangku = r.TCangku.mingcheng,
                kucunshuliang = r.TCangkuKucunMXes.Sum(mr => mr.shuliang),
                chengbenjine = r.TCangkuKucunMXes.Sum(mr => mr.TTiaoma.jinjia * mr.shuliang),
                shoujiajine = r.TCangkuKucunMXes.Sum(mr => mr.TTiaoma.shoujia * mr.shuliang),
                r.shangbaoshijian
            });

            grid_kc.DataSource = Tool.CommonFunc.LINQToDataTable(xs);
            grid_kc.DataBind();
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sch_Click(object sender, EventArgs e)
        {
            //加载总库存和加盟商旗下的每个分店的最新库存数据
            int? fdid = null;
            if (!string.IsNullOrEmpty(cmb_ck.SelectedValue))
            {
                fdid = int.Parse(cmb_ck.SelectedValue);
            }


            loadKCOfCangkus(fdid);
        }

        /// <summary>
        /// 删除一个历史库存记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_kc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //检查权限
            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            int id = int.Parse(grid_kc.DataKeys[e.RowIndex].Value.ToString());

            DBContext db = new DBContext();
            TCangkuKucun ok = db.GetCKKucunById(id);
            if (ok.TCangku.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法删除该数据");
            }
            db.DeleteCKKucun(id);

            loadHistroy(ok.cangkuid);            
        }
    }
}